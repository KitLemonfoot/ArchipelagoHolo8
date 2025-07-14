using HarmonyLib;

namespace ArchipelagoHolo8.Patches{
	
	//Handle check for interactive AZKi bar.
	[HarmonyPatch(typeof(Change_AZKi_bar), "LoopPointReached")]
	class Change_AZKi_bar_LoopPointReached_Patch{
		public static void Postfix(Change_AZKi_bar __instance){
			LocationHandler.CheckLocation("special_azkibar");
		}
	}
	
}