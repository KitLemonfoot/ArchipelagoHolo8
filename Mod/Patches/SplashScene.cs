using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ArchipelagoHolo8.Patches{
	
	//Connect to AP after the Unity screen.
	[HarmonyPatch(typeof(SplashScene), "Start")]
	class SplashScene_Start_Patch{
		public static bool Prefix(SplashScene __instance){
			ConnectHandler.ConnectToAP();
			return true;
		}
	}
	
}