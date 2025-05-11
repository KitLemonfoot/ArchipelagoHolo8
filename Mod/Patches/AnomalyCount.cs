using HarmonyLib;
using UnityEngine;

namespace ArchipelagoHolo8.Patches{
	
	//Set the anomaly count to the current amount of anomalies in logic
	[HarmonyPatch(typeof(AnomalyCount), "GetRemainingCount_NoLockCount")]
	class AnomalyCount_GetRemainingCount_NoLockCount_Patch{
		public static bool Prefix(AnomalyCount __instance, ref int __result){
			if(!ConnectHandler.Authenticated){
                return true;
            }
            int num = (ItemHandler.allowableAnomalyList.Count - ItemHandler.seenAnomalyList.Count) + (ItemHandler.allowableEverydayList.Count - ItemHandler.seenEverydayList.Count);
            __result = num;
			return false;
		}
	}
	
}