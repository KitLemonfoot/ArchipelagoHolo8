using HarmonyLib;

namespace ArchipelagoHolo8.Patches{
	
	//Handle check for interactive Botan ramen cutscene.
	[HarmonyPatch(typeof(Change_Ramen_Botan), "LoopPointReached")]
	class Change_Ramen_Botan_LoopPointReached_Patch{
		public static void Postfix(){
			LocationHandler.CheckLocation("special_menyabotan");
		}
	}
	
}