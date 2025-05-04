using HarmonyLib;
using UnityEngine;
using System;
using System.Collections;

namespace ArchipelagoHolo8.Patches{
	
	// //output anomaly test text on default
	// [HarmonyPatch(typeof(PlayScene), "CreateChangeForDefault")]
	// class PlayScene_CreateChangeForDefault_Patch{
	// 	public static void Postfix(PlayScene __instance){
	// 		int ccn = Convert.ToInt32(Traverse.Create(__instance).Field("currentChangeNum_").GetValue());
	// 		Debug.Log("!!! Anomaly generated: " + ccn);
	// 	}
	// }
	
	// //output anomaly test text on everyday
	// [HarmonyPatch(typeof(PlayScene), "CreateChangeForNoHorror")]
	// class PlayScene_CreateChangeForNoHorror_Patch{
	// 	public static void Postfix(PlayScene __instance){
	// 		int ccn = Convert.ToInt32(Traverse.Create(__instance).Field("currentChangeNum_").GetValue());
	// 		Debug.Log("!!! Anomaly generated: " + ccn);
	// 	}
	// }
	
	//Handle non-anomalous scenes accordant to AP YAML.
	[HarmonyPatch(typeof(PlayScene), "SetTrueOrFalse")]
	class PlayScene_SetTrueOrFalse_Patch{
		public static bool Prefix(PlayScene __instance){
			//If we aren't connected to AP, return to original game code.
			if(ConnectHandler.Authenticated==false){
				Debug.Log("Not connected to AP, letting game determine t/f.");
				return true;
			}
			
			//Original game code for 2-anomaly failsafe.
			if(Common.noAnomalyCount_ == 2){
				Common.isCurrentChange_ = true;
				Common.noAnomalyCount_ = 0;
				return false;
			}
			
			//Randomize based on YAML setting.
			if(UnityEngine.Random.Range(1,101) <= MiscHandler.noAnomaly){
				Common.isCurrentChange_ = false;
				Common.noAnomalyCount_++;
			}
			else{
				Common.isCurrentChange_ = true;
				Common.noAnomalyCount_ = 0;
			}
			return false;
		}
	}
	
	//Handle anomaly cross-gamemode randomization.
	[HarmonyPatch(typeof(PlayScene), "SetChange")]
	class PlayScene_SetChange_Patch{
		public static bool Prefix(PlayScene __instance){
			//If we aren't connected to AP, return to original game code.
			if(ConnectHandler.Authenticated==false){
				return true;
			}
			//Pull the AP anomaly types and determine which gamemode we're playing.
			//If we're playing both, choose one or the other at random.
			if(ItemHandler.anomalyTypes<2){
				Common.gameMode_ = (GAME_MODE_TYPE)ItemHandler.anomalyTypes;
			}
			else{
				//If we've already found every type of anomaly in a certain type, then focus on the other type.
				//Otherwise, pick randomly.
				//Ran out of anomaly
				bool AnomalyOut = ItemHandler.allowableAnomalyList.Count <= ItemHandler.seenAnomalyList.Count;
				//Ran out of Everyday
				bool EverydayOut = ItemHandler.allowableEverydayList.Count <= ItemHandler.seenEverydayList.Count;
				if(AnomalyOut && !EverydayOut){
					Common.gameMode_ = GAME_MODE_TYPE.NO_HORROR;
					return true;
				}
				if(EverydayOut && !AnomalyOut){
					Common.gameMode_ = GAME_MODE_TYPE.DEFAULT;
					return true;
				}
				Common.gameMode_ = (GAME_MODE_TYPE)UnityEngine.Random.Range(0,2);
			}
			return true;
		}
	}

	//Handle random change.
	[HarmonyPatch(typeof(PlayScene), "SetRandomChange")]
	class PlayScene_SetRandomChange_Patch{
		public static bool Prefix(PlayScene __instance){
			//If we aren't connected to AP, return to original game code.
			if(ConnectHandler.Authenticated==false){
				return true;
			}
			//Otherwise, pull a random anomaly from AP lists.
			int changeNo=0;
			int ccct = Convert.ToInt32(Traverse.Create(__instance).Field("currentCreateChangeType_").GetValue());
			switch(ccct){
				case 0:
					changeNo = ItemHandler.determineRandomFromAPSeenList_A();
					break;
				case 1:
					changeNo = ItemHandler.determineRandomFromAPSeenList_E();
					break;
			}
			Traverse.Create(__instance).Field("currentChangeNum_").SetValue(changeNo);
			return false;
		}
	}
	
	//Handle giving locations for finding anomalies.
	//NextStage isn't called in Anomaly List, so we don't have to worry about illicit checks leaking from there.
	[HarmonyPatch(typeof(PlayScene), "NextStage")]
	class PlayScene_NextStage_Patch{
		public static bool Prefix(PlayScene __instance, bool isSelectTrue){
			//If we successfully determined an anomaly, then give the player a check.
			if(Common.isCurrentChange_ && isSelectTrue==Common.isCurrentChange_){
				int gm = Convert.ToInt32(Common.gameMode_);
				int change = Convert.ToInt32(Traverse.Create(__instance).Field("currentChangeNum_").GetValue());
				LocationHandler.CheckLocation(gm+"_"+change);
				//Handle AP's seen anomaly list.
				if(gm==0&&!ItemHandler.seenAnomalyList.Contains(change)){
					ItemHandler.seenAnomalyList.Add(change);
					ItemHandler.updateDatastore();
				}
				if(gm==1&&!ItemHandler.seenEverydayList.Contains(change)){
					ItemHandler.seenEverydayList.Add(change);
					ItemHandler.updateDatastore();
				}
			}
			//Update items.
			ConnectHandler.syncItems();
			//Handle elevator infinite loop.
			if(ConnectHandler.Authenticated && !ItemHandler.canGoal()){
				Debug.Log("User cannot goal, refusing elevator progression.");
				Common.currentClearCount_ = -1;
			}
			return true;
		}
	}
	
	
}