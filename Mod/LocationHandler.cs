using System;
using System.Collections.Generic;
using UnityEngine;

//Handle Archipelago locations.

namespace ArchipelagoHolo8{
	
	public static class LocationHandler{
		
		//Storage for locations.
		public static Dictionary<string, long> locations = new Dictionary<string, long>();
		public static Action<bool> s => SentCheck;
		
		public static void CheckLocation(string loc){
			
			if(locations.ContainsKey(loc) && ConnectHandler.Authenticated){
				Debug.Log("Checking location: "+loc);
				ConnectHandler.Session.Locations.CompleteLocationChecksAsync(locations[loc]);
			}
			else Debug.Log("Location \"" + loc + "\" does not exist or you are not connected to AP.");
		}
		
		public static void SentCheck(bool t){
		}
	}
	
}