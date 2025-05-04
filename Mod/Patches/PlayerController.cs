using HarmonyLib;
using UnityEngine;

namespace ArchipelagoHolo8.Patches{
	
	//Make the player move faster.
	[HarmonyPatch(typeof(PlayerController), "Start")]
	class PlayerController_Start_Patch{
		public static bool Prefix(PlayerController __instance){
			Traverse.Create(__instance).Field("SPEED_").SetValue(5f);
			Traverse.Create(__instance).Field("DASH_SPEED_").SetValue(7f);
			return true;
		}
	}
	
}