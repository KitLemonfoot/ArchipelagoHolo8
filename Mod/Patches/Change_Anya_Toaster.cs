using HarmonyLib;

namespace ArchipelagoHolo8.Patches{
	
	//Handle check for interactive Anya toaster.
	[HarmonyPatch(typeof(Change_Anya_Toaster), "StartMove")]
	class Change_Anya_Toaster_StartMove_Patch{
		public static void Postfix(){
			LocationHandler.CheckLocation("special_anyatoaster");
		}
	}
	
}