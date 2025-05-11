using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Packets;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.Models;
using Archipelago.MultiClient.Net.BounceFeatures.DeathLink;
using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ArchipelagoHolo8{
	
	public static class ConnectHandler{
		
		public static bool Authenticated;
        public static ArchipelagoSession Session;
		public static string APserver = null;
		public static string APSlot = null;
		public static bool doingDeathlink;
		public static DeathLinkService deathLinkService = null;
		
		public static void ConnectToAP(){
			Debug.Log("Trying to connect to AP. Please wait...");
			LoginResult result;
			APSlot = MiscHandler.config_APslot.Value;
			APserver = MiscHandler.config_APip.Value;
			
			try{
				Session = ArchipelagoSessionFactory.CreateSession(APserver);
				Session.Items.ItemReceived += ItemReceived;
				
				result = Session.TryConnectAndLogin(
					"holo8", 
					APSlot, 
					ItemsHandlingFlags.AllItems,
					new Version(0,6,1),
					null,
					null,
					MiscHandler.config_APpassword.Value == "" ? null : MiscHandler.config_APpassword.Value,
					true
				);
			}
			catch (Exception e){
				result = new LoginFailure(e.GetBaseException().Message);
			}
			if(result is LoginSuccessful loginSuccess){
				Debug.Log("Successfully connected to server, setting up...");
				Authenticated = true;

				syncItems();
				
				//Push locations
				LocationHandler.locations = ((JObject)loginSuccess.SlotData["locations"]).ToObject<Dictionary<string, long>>();
				
				//Handle YAML slotdata values.
				MiscHandler.noAnomaly = int.Parse(loginSuccess.SlotData["NoAnomalyPercentage"].ToString());
				MiscHandler.reusedAnomaly = int.Parse(loginSuccess.SlotData["ReusedAnomalyPercentage"].ToString());
				ItemHandler.anomalyTypes = int.Parse(loginSuccess.SlotData["AnomalyTypes"].ToString());
				ItemHandler.hardAnomalies = bool.Parse(loginSuccess.SlotData["HardAnomalies"].ToString());

				//Handle datastore pull.
				Session.DataStorage[Scope.Slot,"seenAnomalyList"].Initialize(new List<int>().ToArray());
				Session.DataStorage[Scope.Slot,"seenEverydayList"].Initialize(new List<int>().ToArray());
				ItemHandler.seenAnomalyList = Session.DataStorage[Scope.Slot,"seenAnomalyList"].To<List<int>>();
				ItemHandler.seenEverydayList = Session.DataStorage[Scope.Slot,"seenEverydayList"].To<List<int>>();
				
				//Setup deathlink.
				doingDeathlink = bool.Parse(loginSuccess.SlotData["death_link"].ToString());
				deathLinkService = Session.CreateDeathLinkService();
				if(doingDeathlink){
					deathLinkService.EnableDeathLink();
					deathLinkService.OnDeathLinkReceived += DeathLinkRecieved;
				}

				ItemHandler.recalculateAnomalyLogic();

				Debug.Log("Successfully set up a connection to Archipelago. Let's play!");
			}
			else if(result is LoginFailure failure){
				string errorMessage = $"Failed to connect to Archipelago.\n";
				foreach (ConnectionRefusedError error in failure.ErrorCodes){
					errorMessage += $"{error}: ";
				}
				foreach (string error in failure.Errors){
					errorMessage += $"{error}";
				}
				Debug.Log(errorMessage);
                Session = null;
				return;
			}
			
		}

		//For some baffling reason, holo8 really doesn't like Multiclient's item handler.
		//Instead, we have to manually update the item counts on every floor.
		public static void syncItems(){
			Debug.Log("Syncing items");
			while(Session.Items.Any()){
				ItemInfo item = Session.Items.PeekItem();
				string name = item.ItemName;
				ItemHandler.recieveItem(name);
				Session.Items.DequeueItem();
			}
		}
		
		public static void ItemReceived(IReceivedItemsHelper helper){
			ItemInfo item = helper.PeekItem();
			string name = item.ItemName;
			ItemHandler.recieveItem(name);
			helper.DequeueItem();
		}
		
		//Handle recieved deathlink and "kill" the player.
		//I'd like to do this more elegantly, but the existing death scripts is a minefield of private functions, so this will work for now
		public static void DeathLinkRecieved(DeathLink deathLink){
			if(Common.playSceneState_ != PLAY_STATE.PLAY){
				Debug.Log("Got a deathlink, but can't kill the player right now.");
			}
			else{
				Debug.Log("Got a deathlink; resetting player to Floor 8.");
				bool fakeC = !Common.isCurrentChange_;
				Common.playScene_.JudgeNext(fakeC);
			}
			
		}
		
		public static void sendDeathLink(string msg){
			deathLinkService.SendDeathLink(new DeathLink(ConnectHandler.APSlot, msg));
			Debug.Log("Deathlink sent");
		}
		
		public static void SendCompletion()
        {
            Session?.SetGoalAchieved();
        }
	}
	
}