using System;
using System.Collections.Generic;
using UnityEngine;
using Archipelago.MultiClient.Net.Enums;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

//Handle Archipelago items.

namespace ArchipelagoHolo8{
	
	public static class ItemHandler{
		
		//Flags for generations.
		public static Dictionary<string, bool> generationFlags = new Dictionary<string, bool>(){
			{"Hololive Generation 0", false},
			{"Hololive Generation 1", false},
			{"Hololive Generation 2", false},
			{"Hololive GAMERS", false},
			{"Hololive Fantasy", false},
			{"HoloForce", false},
			{"NePoLaBo", false},
			{"HoloX Secret Society", false},
			{"ReGLOSS", false},
			{"FLOW GLOW", false},
			{"Area 15", false},
			{"Holoro", false},
			{"Holoh3ro", false},
			{"Hololive Myth", false},
			{"Hololive CouncilRyS", false},
			{"Hololive Advent", false},
			{"Hololive Justice", false},
			{"Mikodanye", false},
			{"Taranchama", false}
		};
		
		//Anomalies that are allowed to be a part of generation.
		public static List<int> allowableAnomalyList = new List<int>();
		public static List<int> allowableEverydayList = new List<int>();
		
		//Anomalies that have already been seen.
		public static List<int> seenAnomalyList = new List<int>();
		public static List<int> seenEverydayList = new List<int>();
		
		//These two fucking massive jagged arrays holds all the logic for every anomaly in the game.
		//I hate this, but the alternative is many special cases and no expandability, so it'll do for now.
		public static string[][] anomalyLogic = {
			new string[]{}, //black hair suisei
			new string[]{"hard"}, //ayame clothes
			new string[]{"Hololive Generation 0"}, //35P graffiti
			new string[]{"Taranchama", "hard"}, //taranchama eyes
			new string[]{"Hololive Generation 0"}, //35p ball
			new string[]{"ReGLOSS"}, //ririka poster
			new string[]{}, //red office
			new string[]{"Hololive Justice"}, //gigi buttons
			new string[]{}, //ayame glasses
			new string[]{}, //mitieru lights
			new string[]{}, //ayame dance
			new string[]{}, //fast dance
			new string[]{"ReGLOSS"}, //ao legs
			new string[]{"Hololive Generation 0"}, //35p poster
			new string[]{"Hololive Fantasy"}, //nousagi on ayame
			new string[]{"Hololive Generation 0"}, //35p on suisei
			new string[]{}, //marine strained back
			new string[]{"Hololive Generation 0"}, //micomet
			new string[]{"Hololive Fantasy"}, //large nousagi
			new string[]{}, //yagoo nameplate
			new string[]{"HoloForce"}, //watame chair
			new string[]{"HoloX Secret Society"}, //koyori
			new string[]{"Hololive Generation 1"}, //akirose in corner
			new string[]{"NePoLaBo"}, //botan laugh
			new string[]{"Hololive Generation 0"}, //elevator sora
			new string[]{"Hololive Generation 1", "Hololive Generation 2"}, //choco
			new string[]{"Hololive GAMERS"}, //mio
			new string[]{}, //poster move
			new string[]{"ReGLOSS"}, //kanade
			new string[]{}, //large phone
			new string[]{}, //large ayame
			new string[]{}, //large marine
			new string[]{}, //suisei shadow
			new string[]{}, //ayame look
			new string[]{}, //suisei smile
			new string[]{}, //ayame angry
			new string[]{}, //marine smile
			new string[]{"Hololive Generation 0"}, //azki elevator
			new string[]{"Hololive GAMERS"}, //ayame koronesuki
			new string[]{"Hololive Generation 0"}, //miko elevator
			new string[]{"Mikodanye"}, //mikodanye button
			new string[]{"Taranchama"}, //taranchama hallway
			new string[]{"Hololive GAMERS"}, //treekun
			new string[]{"Hololive Generation 1"}, //tired fubuzilla
			new string[]{"Hololive Generation 1"}, //mitieru in hallway
			new string[]{"Hololive Generation 2"}, //oozora police
			new string[]{"Hololive Generation 2"}, //aqushio broom
			new string[]{"HoloForce"}, //watame in private
			new string[]{"HoloForce"}, //kanata wall
			new string[]{"NePoLaBo"}, //botan cart
			new string[]{"Holoro"}, //ollie
			new string[]{"Hololive CouncilRyS"}, //mumei
			new string[]{"Hololive Advent"}, //fuwamoco
			new string[]{"ReGLOSS"}, //raden mask
			new string[]{"hard"}, //azki poster
			new string[]{"Hololive Myth"}, //kiara
			new string[]{"hard"}, //marine wrong eyes
			new string[]{"Hololive Generation 1"}, //fubuki in room
			new string[]{"Hololive GAMERS"}, //korone koronesuki
			new string[]{"Mikodanye", "Taranchama"}, //observation room
			new string[]{"HoloForce"}, //kanata handshake
			new string[]{"hard"}, //mitieru poster
			new string[]{}, //no overtime
			new string[]{"Mikodanye"}, //mikodanye stuck
			new string[]{"NePoLaBo"}, //polpeller
			new string[]{"hard"}, //eyepatch mark
			new string[]{"NePoLaBo"}, //nene beetle
			new string[]{"ReGLOSS", "FLOW GLOW"}, //vivi
			new string[]{"Mikodanye", "Taranchama"}, //construction
			new string[]{"Hololive Generation 0"}, //35p exit
			new string[]{"NePoLaBo", "hard"}, //invisible botan
			new string[]{"HoloForce"}, //coco kanata
			new string[]{"Hololive Generation 0"}, //hagebo
			new string[]{"Hololive Generation 0"}, //suicopath
			new string[]{"Hololive Generation 0"}, //azki phone
			new string[]{}, //onion
			new string[]{"hard"}, //sapling
			new string[]{"hard"}, //bath poster
			new string[]{"hard"}, //marine eye in wall
			new string[]{"Hololive Generation 0"}, //miko button
			new string[]{"Holoh3ro"}, //kaela
			new string[]{"Hololive Generation 2"}, //shion poster
			new string[]{"ReGLOSS"}, //ririka jump
			new string[]{"HoloForce"} //watame wall
		};
		//And for Everyday too.
		public static string[][] everydayLogic = {
			new string[]{"Hololive Fantasy"}, //fantasy tower
			new string[]{"NePoLaBo"}, //nepolabo cart
			new string[]{"Hololive Advent"}, //biboo tax
			new string[]{"Hololive Generation 0", "Hololive CouncilRyS", "Holoro"}, //miko japanese
			new string[]{"Hololive GAMERS"}, //pet koronesuki
			new string[]{"Hololive Generation 2", "HoloForce"}, //startend
			new string[]{"Hololive Generation 2"}, //subaru samr
			new string[]{"Hololive Generation 1", "Hololive Generation 2"}, //peep matsuri
			new string[]{"Hololive Generation 2", "HoloForce"}, //subaluna
			new string[]{"HoloX Secret Society"}, //chloe bath
			new string[]{"Hololive Myth"}, //smol ame
			new string[]{"HoloX Secret Society", "Holoh3ro"}, //zeta iroha
			new string[]{"Hololive Myth"}, //ina tentacle
			new string[]{}, //home on time
			new string[]{}, //achan
			new string[]{"Hololive Generation 0"}, //35p suisei
			new string[]{"Hololive GAMERS"}, //okanyan
			new string[]{}, //marine mosaic
			new string[]{}, //classmate marine
			new string[]{"NePoLaBo"}, //nekko
			new string[]{"HoloX Secret Society"}, //handwriting
			new string[]{"HoloX Secret Society"}, //secret iroha
			new string[]{"HoloX Secret Society"}, //lui
			new string[]{"Hololive GAMERS", "Area 15"}, //risu
			new string[]{"Area 15"}, //iofi
			new string[]{"Area 15"}, //moona
			new string[]{"Holoh3ro"}, //ckia
			new string[]{"Hololive Myth"}, //gura tub
			new string[]{"Hololive Generation 2", "Hololive Myth", "Hololive CouncilRyS"}, //oozora police chairs
			new string[]{"Hololive CouncilRyS"}, //fauna
			new string[]{"Hololive CouncilRyS"}, //kronii
			new string[]{"Hololive Advent"}, //nerissa window
			new string[]{"ReGLOSS"}, //ririka sos
			new string[]{"ReGLOSS"}, //hajime
			new string[]{"ReGLOSS"}, //ao
			new string[]{"Hololive CouncilRyS"}, //sana
			new string[]{}, //asacoco
			new string[]{}, //nodoka
			new string[]{"Hololive Myth"}, //calli
			new string[]{"Hololive CouncilRyS"}, //irys
			new string[]{"Hololive Generation 1", "Hololive GAMERS"}, //mio fubuki
			new string[]{"Hololive Generation 0", "Hololive Justice"}, //justice japanese
			new string[]{"Hololive Generation 0", "Hololive Generation 1"}, //mukirose
			new string[]{"Hololive Generation 1"}, //haachama cooking
			new string[]{"Hololive GAMERS"}, //korone chase
			new string[]{"Hololive Generation 1"}, //excited fubuki
			new string[]{"Hololive Generation 2"}, //aqua mask
			new string[]{"HoloX Secret Society"}, //mayo koyori
			new string[]{"Holoro"}, //reine
			new string[]{"HoloForce"}, //kanata melon
			new string[]{"Holoh3ro"}, //ableist
			new string[]{"Hololive Myth"}, //ame potato
			new string[]{"HoloX Secret Society"}, //laplus
			new string[]{"Hololive Generation 0", "Hololive Generation 1"}, //gomoku
			new string[]{"Hololive Generation 1"}, //cardboard
			new string[]{"Hololive GAMERS"}, //koronesuki poster
			new string[]{"Hololive Fantasy"}, //noel
			new string[]{"Hololive Fantasy"}, //pekorap
			new string[]{"NePoLaBo"}, //liverface lamy
			new string[]{"Hololive Generation 0"}, //sora ankimo
			new string[]{"Hololive Generation 1"}, //matsuri mascots
			new string[]{"HoloForce"}, //towa bibi
			new string[]{"Hololive CouncilRyS"}, //bae rats
			new string[]{"FLOW GLOW"}, //riona niko
			new string[]{"FLOW GLOW"}, //chihaya
			new string[]{"HoloForce","FLOW GLOW"}, //su kanata
			new string[]{"Hololive Generation 0"}, //roboco charge
			new string[]{"Holoro"}, //anya ghost
			new string[]{"Hololive Generation 1", "Hololive Fantasy"}, //flare pineapple
			new string[]{"Hololive Generation 2"}, //shion aqua
			new string[]{"Hololive Generation 2", "HoloX Secret Society"}, //shion chloe towel
			new string[]{"Hololive Generation 2"}, //gen2 dance
			new string[]{"Hololive Generation 2"}, //shiokko
			new string[]{"NePoLaBo"}, //menya botan
			new string[]{"Holoro"}, //toasterkun
			new string[]{"HoloForce"}, //watame sheep shear
			new string[]{"HoloForce"}, //gen4 coco
			new string[]{"Hololive Generation 0"} //azki icecream
		};
		
		//AP Slotdata
		public static int anomalyTypes = 0;
		public static bool hardAnomalies = false;
		
		public static void recieveItem(string itemName){
			//Generations.
			if(generationFlags.ContainsKey(itemName)){
				generationFlags[itemName]=true;
				recalculateAnomalyLogic();
				return;
			}
			//Other items
			switch(itemName){
				case "Nothing": break;
				default: Debug.Log("Invalid item "+itemName+", ignoring.");break;
			}
		}
		
		public static void wipeItems(){
			foreach(KeyValuePair<string, bool> kvp in generationFlags){
				generationFlags[kvp.Key] = false;
			}
		}
		
		//Calculate the anomaly logic on item recieve.
		public static void recalculateAnomalyLogic(){
			//Clear both lists.
			allowableAnomalyList.Clear();
			allowableEverydayList.Clear();
			bool ok = true;
			//Start with anomaly.
			if(anomalyTypes%2==0){
				for(int a = 0; a<anomalyLogic.Length; a++){
					//Trusted until untrusted
					ok = true;
					if(anomalyLogic[a] == null || anomalyLogic[a].Length == 0){
						allowableAnomalyList.Add(a);
						continue;
					}
					foreach(string l in anomalyLogic[a]){
						//If this is a hard anomaly and AP doesn't want to play with hard anomalies, do not add
						if(l=="hard"&&!hardAnomalies){
							ok=false;
							break;
						}
						//If we don't have the generation flag, we can't go to that anomaly
						if(!generationFlags[l]){
							ok = false;
							break;
						}
					}
					if(ok){
						allowableAnomalyList.Add(a);
					}
				}
			}
			//Then do everyday. Process is the same.
			if(anomalyTypes>0){
				for(int a = 0; a<everydayLogic.Length; a++){
					ok = true;
					if(everydayLogic[a] == null || everydayLogic[a].Length == 0){
						allowableEverydayList.Add(a);
						continue;
					}
					foreach(string l in everydayLogic[a]){
						if(!generationFlags[l]){
							ok = false;
							break;
						}
					}
					if(ok){
						allowableEverydayList.Add(a);
					}
				}
			}
		}

		//Determine a random anomaly from the list of seen anomalies.
		//I'm doing this here as to not muck with the user's existing Holo8 save, but I may adapt this into the existing holo8 code.
		public static int determineRandomFromAPSeenList_A(){
			int r;
			//If we've already seen every possible anomaly, or if we hit random for reused anomaly, then pick a truly random one.
			if(allowableAnomalyList.Count <= seenAnomalyList.Count || UnityEngine.Random.Range(1,101) <= MiscHandler.reusedAnomaly){
				r = UnityEngine.Random.Range(0, allowableAnomalyList.Count);
				return allowableAnomalyList[r];
			}
			//Otherwise, we will create a list of unseen anomalies.
			List<int> unseen = new List<int>();
			foreach(int a in allowableAnomalyList){
				if(!seenAnomalyList.Contains(a)){
					unseen.Add(a);
				}
			}
			//Pick a random anomaly from this list.
			r = UnityEngine.Random.Range(0, unseen.Count);
			return unseen[r];
		}

		//Same as above, but with Everyday.
		//I don't want to have to reuse code here, but seeing as the original Holo8 has two seperate lists for anomaly and everyday, I don't have much a choice
		public static int determineRandomFromAPSeenList_E(){
			int r;
			//If we've already seen every possible anomaly (BK), or if we hit random for reused anomaly, then pick a truly random one.
			if(allowableEverydayList.Count <= seenEverydayList.Count || UnityEngine.Random.Range(1,101) <= MiscHandler.reusedAnomaly){
				r = UnityEngine.Random.Range(0, allowableEverydayList.Count);
				return allowableEverydayList[r];
			}
			//Otherwise, we will create a list of unseen anomalies.
			List<int> unseen = new List<int>();
			foreach(int a in allowableEverydayList){
				if(!seenEverydayList.Contains(a)){
					unseen.Add(a);
				}
			}
			//Pick a random anomaly from this list.
			r = UnityEngine.Random.Range(0, unseen.Count);
			return unseen[r];
		}

		//Update the datastore whenever an anomaly is found.
		public static void updateDatastore(){
			if(ConnectHandler.Authenticated){
				ConnectHandler.Session.DataStorage[Scope.Slot, "seenAnomalyList"] = seenAnomalyList.ToArray();
				ConnectHandler.Session.DataStorage[Scope.Slot, "seenEverydayList"] = seenEverydayList.ToArray();
			}
			else{
				Debug.Log("Not connected to AP, skipping datastore update.");
			}
		}
		
		//Determine if we can goal.
		//Used to disable the infinitley looping elevator.
		public static bool canGoal(){
			return generationFlags["Mikodanye"] && generationFlags["Taranchama"];
		}
		
		
	}
}