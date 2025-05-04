using System;
using System.Collections.Generic;
using UnityEngine;
using BepInEx.Configuration;

namespace ArchipelagoHolo8{
	
	public static class MiscHandler{
		
		public static int noAnomaly = 50;
		public static int reusedAnomaly = 0;
		public static ConfigEntry<string> config_APip;
        public static ConfigEntry<string> config_APslot;
        public static ConfigEntry<string> config_APpassword;
		
		public static Dictionary<int, string> deathlinkMessages = new Dictionary<int, string>(){
			
			{40," got pummeled by Mikodanye and died."},
			{41," got eaten by Taranchama and died."},
			{44," got pummeled by Mitieru and died."},
			{45," got arrested by the Oozora Police and died."},
			{49," got ran over by Botan's shopping cart and died."},
			{51," was ambushed by Mumei's Nightmare and died."},
			{52," got spooked by Fuwamoco and died."},
			{60," got their hand crushed by Kanata and died."},
			{63," underestimated Mikodanye's flexibility and died."},
			{73," was murdered by Suicopath and died."},
			{74," got doxxed by AZKi and died."},
			{82," got jumped by Ririka and died."}
			
		};
		
		
		public static void handleDeathLink(int change){
			if(ConnectHandler.Authenticated){
				string sn = ConnectHandler.APSlot;
				string dm = " died to an unknown anomaly.";
				if(deathlinkMessages.ContainsKey(change)){
					dm = deathlinkMessages[change];
				}
				string final = sn + dm;
				ConnectHandler.sendDeathLink(final);
				
			}
		}
		
		//Using this for config of AP server, slot, and password fields.
		//Yes, this is catastrophically gross. But it'll have to do until I can sit down and make a proper GUI.
		public static void setConfig(ConfigFile cfg){
            config_APip = cfg.Bind("General", "ArchipelagoIP", "archipelago.gg:", "IP address of the Archipelago server you wish to connect to.");
            config_APslot = cfg.Bind("General", "ArchipelagoSlotName", "Holo8Player", "Slot name of the Archipelago server you wish to connect to.");
            config_APpassword = cfg.Bind("General", "ArchipelagoPassword", "", "Password of the Archipelago server you wish to connect to, if any.");
        }
		
		
	}
	
}