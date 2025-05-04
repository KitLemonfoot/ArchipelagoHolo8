using HarmonyLib;
using UnityEngine;

namespace ArchipelagoHolo8.Patches{
	
	//Send goal on completing the game.
	[HarmonyPatch(typeof(CreditScene), "Start")]
	class CreditScene_Start_Patch{
		public static void Postfix(CreditScene __instance){
			if(ConnectHandler.Authenticated){
				LocationHandler.CheckLocation("Goal");
				ConnectHandler.SendCompletion();
			}
		}
	}
	
}