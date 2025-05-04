using HarmonyLib;
using UnityEngine;
using System;

namespace ArchipelagoHolo8.Patches{
	
	//Handle death.
	[HarmonyPatch(typeof(Change_GameOver), "OnTriggerEnter")]
	class Change_GameOver_OnTriggerEnter_Patch{
		public static bool Prefix(Change_GameOver __instance, Collider other){
			//Fuck enums
			int act = Convert.ToInt32(Traverse.Create(__instance).Field("type_").GetValue());
			if(act == 0 && other.gameObject.tag == "PlayScene_Player"){
				int change = Common_CheckAnomaly.anomalyNum_;
				MiscHandler.handleDeathLink(change);
			}
			return true;
		}
	}
	
}