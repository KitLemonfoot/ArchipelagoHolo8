using System;
using System.Collections.Generic;
using UnityEngine;
using Archipelago.MultiClient.Net.Enums;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

//Handle Archipelago items.

namespace ArchipelagoHolo8{
	
	public static class ItemHandler{

		//Flags for talents.
		public static Dictionary<string, bool> talentFlags = new Dictionary<string, bool>(){
			{"Tokino Sora", false},
			{"Roboco", false},
			{"Sakura Miko", false},
			{"Hoshimachi Suisei", false},
			{"AZKi", false},
			{"Aki Rosenthal", false},
			{"Akai Haato", false},
			{"Shirakami Fubuki", false},
			{"Natsuiro Matsuri", false},
			{"Minato Aqua", false},
			{"Murasaki Shion", false},
			{"Nakiri Ayame", false},
			{"Yuzuki Choco", false},
			{"Oozora Subaru", false},
			{"Ookami Mio", false},
			{"Nekomata Okayu", false},
			{"Inugami Korone", false},
			{"Usada Pekora", false},
			{"Shiranui Flare", false},
			{"Shirogane Noel", false},
			{"Houshou Marine", false},
			{"Amane Kanata", false},
			{"Tsunomaki Watame", false},
			{"Kiryu Coco", false},
			{"Tokoyami Towa", false},
			{"Himemori Luna", false},
			{"Yukihana Lamy", false},
			{"Shishiro Botan", false},
			{"Momosuzu Nene", false},
			{"Omaru Polka", false},
			{"Laplus Darknesss", false},
			{"Takane Lui", false},
			{"Hakui Koyori", false},
			{"Sakamata Chloe", false},
			{"Kazama Iroha", false},
			{"Hiodoshi Ao", false},
			{"Otonose Kanade", false},
			{"Ichijou Ririka", false},
			{"Juufuutei Raden", false},
			{"Todoroki Hajime", false},
			{"Isaki Riona", false},
			{"Koganei Niko", false},
			{"Mizumiya Su", false},
			{"Rindo Chihaya", false},
			{"Kikirara Vivi", false},
			{"Ayunda Risu", false},
			{"Moona Hoshinova", false},
			{"Airani Iofifteen", false},
			{"Kureiji Ollie", false},
			{"Anya Melfissa", false},
			{"Pavolia Reine", false},
			{"Vestia Zeta", false},
			{"Kaela Kovalskia", false},
			{"Kobo Kanaeru", false},
			{"Mori Calliope", false},
			{"Takanashi Kiara", false},
			{"Ninomae Inanis", false},
			{"Gawr Gura", false},
			{"Amelia Watson", false},
			{"IRyS", false},
			{"Tsukumo Sana", false},
			{"Ceres Fauna", false},
			{"Ouro Kronii", false},
			{"Nanashi Mumei", false},
			{"Hakos Baelz", false},
			{"Shiori Novella", false},
			{"Koseki Bijou", false},
			{"Nerissa Ravencroft", false},
			{"FUWAMOCO", false},
			{"Elizabeth Rose Bloodflame", false},
			{"Gigi Murin", false},
			{"Cecilia Immergreen", false},
			{"Raora Panthera", false},
			{"Mikodanye", false},
			{"Taranchama", false}
		};

		//Lists of generations: used when determining what to give the player in generation mode.
		public static Dictionary<string, string[]> generationLists = new Dictionary<string, string[]>(){
			{"Hololive Generation 0", ["Tokino Sora", "Roboco", "Sakura Miko", "Hoshimachi Suisei", "AZKi"]},
			{"Hololive Generation 1", ["Shirakami Fubuki", "Natsuiro Matsuri", "Aki Rosenthal", "Akai Haato"]},
			{"Hololive Generation 2", ["Minato Aqua", "Murasaki Shion", "Nakiri Ayame", "Yuzuki Choco", "Oozora Subaru"]},
			{"Hololive GAMERS", ["Ookami Mio", "Nekomata Okayu", "Inugami Korone"]},
			{"Hololive Fantasy", ["Usada Pekora", "Shiranui Flare", "Shirogane Noel", "Houshou Marine"]},
			{"HoloForce", ["Amane Kanata", "Tsunomaki Watame", "Kiryu Coco", "Tokoyami Towa", "Himemori Luna"]},
			{"NePoLaBo", ["Yukihana Lamy", "Shishiro Botan", "Momosuzu Nene", "Omaru Polka"]},
			{"HoloX Secret Society", ["Laplus Darknesss", "Takane Lui", "Hakui Koyori", "Sakamata Chloe", "Kazama Iroha"]},
			{"ReGLOSS", ["Hiodoshi Ao", "Otonose Kanade", "Ichijou Ririka", "Juufuutei Raden", "Todoroki Hajime"]},
			{"FLOW GLOW", ["Isaki Riona", "Koganei Niko", "Mizumiya Su", "Rindo Chihaya", "Kikirara Vivi"]},
			{"Area 15", ["Ayunda Risu", "Moona Hoshinova", "Airani Iofifteen"]},
			{"Holoro", ["Kureiji Ollie", "Anya Melfissa", "Pavolia Reine"]},
			{"Holoh3ro", ["Vestia Zeta", "Kaela Kovalskia", "Kobo Kanaeru"]},
			{"Hololive Myth", ["Mori Calliope", "Takanashi Kiara", "Ninomae Inanis", "Gawr Gura", "Amelia Watson"]},
			{"Hololive CouncilRyS", ["IRyS", "Tsukumo Sana", "Ceres Fauna", "Ouro Kronii", "Nanashi Mumei", "Hakos Baelz"]},
			{"Hololive Advent", ["Shiori Novella", "Koseki Bijou", "Nerissa Ravencroft", "FUWAMOCO"]},
			{"Hololive Justice", ["Elizabeth Rose Bloodflame", "Gigi Murin", "Cecilia Immergreen", "Raora Panthera"]}
		};
		
		//Anomalies that are allowed to be a part of generation.
		public static List<int> allowableAnomalyList = new List<int>();
		public static List<int> allowableEverydayList = new List<int>();
		
		//Anomalies that have already been seen.
		public static List<int> seenAnomalyList = new List<int>();
		public static List<int> seenEverydayList = new List<int>();
		
		//These two fucking massive jagged arrays holds all the logic for every anomaly in the game.
		//I hate this, but the alternative is many special cases and no expandability, so it'll do for now.
		public static string[][] anomalyLogic = {
			new string[]{}, //black hair suisei
			new string[]{"hard"}, //ayame clothes
			new string[]{"Sakura Miko"}, //35P graffiti
			new string[]{"Taranchama", "hard"}, //taranchama eyes
			new string[]{"Sakura Miko"}, //35p ball
			new string[]{"Ichijou Ririka"}, //ririka poster
			new string[]{}, //red office
			new string[]{"Gigi Murin"}, //gigi buttons
			new string[]{}, //ayame glasses
			new string[]{}, //mitieru lights
			new string[]{}, //ayame dance
			new string[]{}, //fast dance
			new string[]{"Hiodoshi Ao"}, //ao legs
			new string[]{"Sakura Miko"}, //35p poster
			new string[]{"Usada Pekora"}, //nousagi on ayame
			new string[]{"Sakura Miko"}, //35p on suisei
			new string[]{}, //marine strained back
			new string[]{"Sakura Miko", "Hoshimachi Suisei"}, //micomet
			new string[]{"Usada Pekora"}, //large nousagi
			new string[]{}, //yagoo nameplate
			new string[]{"Tsunomaki Watame"}, //watame chair
			new string[]{"Hakui Koyori"}, //koyori
			new string[]{"Aki Rosenthal"}, //akirose in corner
			new string[]{"Shishiro Botan"}, //botan laugh
			new string[]{"Tokino Sora"}, //elevator sora
			new string[]{"Shirakami Fubuki", "Yuzuki Choco"}, //choco
			new string[]{"Nakiri Ayame", "Ookami Mio"}, //mio
			new string[]{}, //poster move
			new string[]{"Otonose Kanade"}, //kanade
			new string[]{}, //large phone
			new string[]{}, //large ayame
			new string[]{}, //large marine
			new string[]{}, //suisei shadow
			new string[]{}, //ayame look
			new string[]{}, //suisei smile
			new string[]{}, //ayame angry
			new string[]{}, //marine smile
			new string[]{"AZKi"}, //azki elevator
			new string[]{"Inugami Korone"}, //ayame koronesuki
			new string[]{"Sakura Miko"}, //miko elevator
			new string[]{"Mikodanye"}, //mikodanye button
			new string[]{"Taranchama"}, //taranchama hallway
			new string[]{"Inugami Korone"}, //treekun
			new string[]{"Shirakami Fubuki"}, //tired fubuzilla
			new string[]{"Shirakami Fubuki"}, //mitieru in hallway
			new string[]{"Oozora Subaru"}, //oozora police
			new string[]{"Minato Aqua", "Murasaki Shion"}, //aqushio broom
			new string[]{"Tsunomaki Watame"}, //watame in private
			new string[]{"Amane Kanata"}, //kanata wall
			new string[]{"Shishiro Botan"}, //botan cart
			new string[]{"Kureiji Ollie"}, //ollie
			new string[]{"Nanashi Mumei"}, //mumei
			new string[]{"FUWAMOCO"}, //fuwamoco
			new string[]{"Juufuutei Raden"}, //raden mask
			new string[]{"hard"}, //azki poster
			new string[]{"Takanashi Kiara"}, //kiara
			new string[]{"hard"}, //marine wrong eyes
			new string[]{"Shirakami Fubuki"}, //fubuki in room
			new string[]{"Inugami Korone"}, //korone koronesuki
			new string[]{"Mikodanye", "Taranchama"}, //observation room
			new string[]{"Amane Kanata"}, //kanata handshake
			new string[]{"hard"}, //mitieru poster
			new string[]{}, //no overtime
			new string[]{"Mikodanye"}, //mikodanye stuck
			new string[]{"Omaru Polka"}, //polpeller
			new string[]{"hard"}, //eyepatch mark
			new string[]{"Momosuzu Nene"}, //nene beetle
			new string[]{"Juufuutei Raden", "Kikirara Vivi"}, //vivi
			new string[]{"Mikodanye", "Taranchama"}, //construction
			new string[]{"Sakura Miko"}, //35p exit
			new string[]{"Shishiro Botan", "hard"}, //invisible botan
			new string[]{"Amane Kanata", "Kiryu Coco"}, //coco kanata
			new string[]{"Roboco"}, //hagebo
			new string[]{"Hoshimachi Suisei"}, //suicopath
			new string[]{"AZKi"}, //azki phone
			new string[]{}, //onion
			new string[]{"hard"}, //sapling
			new string[]{"hard"}, //bath poster
			new string[]{"Houshou Marine"}, //marine eye in wall
			new string[]{"Sakura Miko"}, //miko button
			new string[]{"Kaela Kovalskia"}, //kaela
			new string[]{"Murasaki Shion"}, //shion poster
			new string[]{"Ichijou Ririka"}, //ririka jump
			new string[]{"Tsunomaki Watame"} //watame wall
		};
		//And for Everyday too.
		public static string[][] everydayLogic = {
			new string[]{"Usada Pekora", "Shiranui Flare", "Shirogane Noel", "Houshou Marine"}, //fantasy tower
			new string[]{"Yukihana Lamy", "Shishiro Botan", "Momosuzu Nene", "Omaru Polka"}, //nepolabo cart
			new string[]{"Shiori Novella", "Koseki Bijou", "Nerissa Ravencroft", "FUWAMOCO"}, //biboo tax
			new string[]{"Sakura Miko", "IRyS", "Anya Melfissa"}, //miko japanese
			new string[]{"Nekomata Okayu","Inugami Korone"}, //pet koronesuki
			new string[]{"Hoshimachi Suisei", "Minato Aqua", "Tokoyami Towa"}, //startend
			new string[]{"Yuzuki Choco", "Oozora Subaru"}, //subaru samr
			new string[]{"Natsuiro Matsuri", "Oozora Subaru"}, //peep matsuri
			new string[]{"Oozora Subaru", "Himemori Luna"}, //subaluna
			new string[]{"Laplus Darknesss", "Sakamata Chloe"}, //chloe bath
			new string[]{"Amelia Watson"}, //smol ame
			new string[]{"Kazama Iroha", "Vestia Zeta"}, //zeta iroha
			new string[]{"Ninomae Inanis"}, //ina tentacle
			new string[]{}, //home on time
			new string[]{}, //achan
			new string[]{"Sakura Miko"}, //35p suisei
			new string[]{"Nekomata Okayu"}, //okanyan
			new string[]{}, //marine mosaic
			new string[]{}, //classmate marine
			new string[]{"Momosuzu Nene"}, //nekko
			new string[]{"Sakamata Chloe"}, //handwriting
			new string[]{"Kazama Iroha"}, //secret iroha
			new string[]{"Nakiri Ayame", "Takane Lui"}, //lui
			new string[]{"Inugami Korone", "Ayunda Risu"}, //risu
			new string[]{"Airani Iofifteen"}, //iofi
			new string[]{"Moona Hoshinova"}, //moona
			new string[]{"Kaela Kovalskia"}, //ckia
			new string[]{"Gawr Gura"}, //gura tub
			new string[]{"Oozora Subaru", "Gawr Gura", "Hakos Baelz"}, //oozora police chairs
			new string[]{"Ceres Fauna"}, //fauna
			new string[]{"Ouro Kronii"}, //kronii
			new string[]{"Nerissa Ravencroft"}, //nerissa window
			new string[]{"Ichijou Ririka"}, //ririka sos
			new string[]{"Otonose Kanade", "Todoroki Hajime"}, //hajime
			new string[]{"Hiodoshi Ao"}, //ao
			new string[]{"Tsukumo Sana"}, //sana
			new string[]{}, //asacoco
			new string[]{}, //nodoka
			new string[]{"Hoshimachi Suisei", "Mori Calliope"}, //calli
			new string[]{"IRyS"}, //irys
			new string[]{"Shirakami Fubuki", "Ookami Mio"}, //mio fubuki
			new string[]{"Sakura Miko", "Elizabeth Rose Bloodflame", "Gigi Murin", "Cecilia Immergreen", "Raora Panthera"}, //justice japanese
			new string[]{"Sakura Miko", "Aki Rosenthal"}, //mukirose
			new string[]{"Akai Haato"}, //haachama cooking
			new string[]{"Inugami Korone"}, //korone chase
			new string[]{"Shirakami Fubuki"}, //excited fubuki
			new string[]{"Minato Aqua"}, //aqua mask
			new string[]{"Hakui Koyori"}, //mayo koyori
			new string[]{"Pavolia Reine"}, //reine
			new string[]{"Amane Kanata"}, //kanata melon
			new string[]{"Kobo Kanaeru"}, //ableist
			new string[]{"Amelia Watson"}, //ame potato
			new string[]{"Laplus Darknesss"}, //laplus
			new string[]{"Sakura Miko", "Shirakami Fubuki"}, //gomoku
			new string[]{"Shirakami Fubuki"}, //cardboard
			new string[]{"Inugami Korone", "Houshou Marine"}, //koronesuki poster
			new string[]{"Shirogane Noel"}, //noel
			new string[]{"Usada Pekora"}, //pekorap
			new string[]{"Yukihana Lamy"}, //liverface lamy
			new string[]{"Tokino Sora"}, //sora ankimo
			new string[]{"Natsuiro Matsuri"}, //matsuri mascots
			new string[]{"Tokoyami Towa"}, //towa bibi
			new string[]{"Hakos Baelz"}, //bae rats
			new string[]{"Isaki Riona", "Koganei Niko"}, //riona niko
			new string[]{"Rindo Chihaya"}, //chihaya
			new string[]{"Amane Kanata","Mizumiya Su"}, //su kanata
			new string[]{"Roboco"}, //roboco charge
			new string[]{"Anya Melfissa"}, //anya ghost
			new string[]{"Shirakami Fubuki", "Shiranui Flare"}, //flare pineapple
			new string[]{"Minato Aqua", "Murasaki Shion"}, //shion aqua
			new string[]{"Murasaki Shion", "Sakamata Chloe"}, //shion chloe towel
			new string[]{"Minato Aqua", "Murasaki Shion", "Nakiri Ayame", "Yuzuki Choco", "Oozora Subaru"}, //gen2 dance
			new string[]{"Murasaki Shion"}, //shiokko
			new string[]{"Yukihana Lamy", "Shishiro Botan", "Momosuzu Nene", "Omaru Polka"}, //menya botan
			new string[]{"Anya Melfissa"}, //toasterkun
			new string[]{"Tsunomaki Watame"}, //watame sheep shear
			new string[]{"Amane Kanata", "Tsunomaki Watame", "Kiryu Coco", "Tokoyami Towa", "Himemori Luna"}, //gen4 coco
			new string[]{"AZKi"} //azki icecream
		};
		
		//AP Slotdata
		public static int anomalyTypes = 0;
		public static bool hardAnomalies = false;
		
		public static void recieveItem(string itemName){
			//Individual talents.
			if(talentFlags.ContainsKey(itemName)){
				talentFlags[itemName]=true;
				recalculateAnomalyLogic();
				return;
			}
			//Generation handler.
			if(generationLists.ContainsKey(itemName)){
				foreach(string t in generationLists[itemName]){
					talentFlags[t]=true;
				}
				recalculateAnomalyLogic();
				return;
			}
			//Other items
			switch(itemName){
				case "Nothing": break;
				default: Debug.Log("Invalid item "+itemName+", ignoring.");break;
			}
		}
		
		public static void wipeItems(){
			foreach(KeyValuePair<string, bool> kvp in talentFlags){
				talentFlags[kvp.Key] = false;
			}
		}
		
		//Calculate the anomaly logic on item recieve.
		public static void recalculateAnomalyLogic(){
			//Clear both lists.
			allowableAnomalyList.Clear();
			allowableEverydayList.Clear();
			bool ok = true;
			//Start with anomaly.
			if(anomalyTypes%2==0){
				for(int a = 0; a<anomalyLogic.Length; a++){
					//Trusted until untrusted
					ok = true;
					if(anomalyLogic[a] == null || anomalyLogic[a].Length == 0){
						allowableAnomalyList.Add(a);
						continue;
					}
					foreach(string l in anomalyLogic[a]){
						//If this is a hard anomaly and AP doesn't want to play with hard anomalies, do not add
						if(l=="hard"&&!hardAnomalies){
							ok=false;
							break;
						}
						if(l=="hard"){
							continue;
						}
						//If we don't have the generation flag, we can't go to that anomaly
						if(!talentFlags[l]){
							ok = false;
							break;
						}
					}
					if(ok){
						allowableAnomalyList.Add(a);
					}
				}
			}
			//Then do everyday. Process is the same.
			if(anomalyTypes>0){
				for(int a = 0; a<everydayLogic.Length; a++){
					ok = true;
					if(everydayLogic[a] == null || everydayLogic[a].Length == 0){
						allowableEverydayList.Add(a);
						continue;
					}
					foreach(string l in everydayLogic[a]){
						if(!talentFlags[l]){
							ok = false;
							break;
						}
					}
					if(ok){
						allowableEverydayList.Add(a);
					}
				}
			}
		}

		//Determine a random anomaly from the list of seen anomalies.
		//I'm doing this here as to not muck with the user's existing Holo8 save, but I may adapt this into the existing holo8 code.
		public static int determineRandomFromAPSeenList_A(){
			int r;
			//If we've already seen every possible anomaly, or if we hit random for reused anomaly, then pick a truly random one.
			if(allowableAnomalyList.Count <= seenAnomalyList.Count || UnityEngine.Random.Range(1,101) <= MiscHandler.reusedAnomaly){
				r = UnityEngine.Random.Range(0, allowableAnomalyList.Count);
				return allowableAnomalyList[r];
			}
			//Otherwise, we will create a list of unseen anomalies.
			List<int> unseen = new List<int>();
			foreach(int a in allowableAnomalyList){
				if(!seenAnomalyList.Contains(a)){
					unseen.Add(a);
				}
			}
			//Pick a random anomaly from this list.
			r = UnityEngine.Random.Range(0, unseen.Count);
			return unseen[r];
		}

		//Same as above, but with Everyday.
		//I don't want to have to reuse code here, but seeing as the original Holo8 has two seperate lists for anomaly and everyday, I don't have much a choice
		public static int determineRandomFromAPSeenList_E(){
			int r;
			//If we've already seen every possible anomaly (BK), or if we hit random for reused anomaly, then pick a truly random one.
			if(allowableEverydayList.Count <= seenEverydayList.Count || UnityEngine.Random.Range(1,101) <= MiscHandler.reusedAnomaly){
				r = UnityEngine.Random.Range(0, allowableEverydayList.Count);
				return allowableEverydayList[r];
			}
			//Otherwise, we will create a list of unseen anomalies.
			List<int> unseen = new List<int>();
			foreach(int a in allowableEverydayList){
				if(!seenEverydayList.Contains(a)){
					unseen.Add(a);
				}
			}
			//Pick a random anomaly from this list.
			r = UnityEngine.Random.Range(0, unseen.Count);
			return unseen[r];
		}

		//Update the datastore whenever an anomaly is found.
		public static void updateDatastore(){
			if(ConnectHandler.Authenticated){
				ConnectHandler.Session.DataStorage[Scope.Slot, "seenAnomalyList"] = seenAnomalyList.ToArray();
				ConnectHandler.Session.DataStorage[Scope.Slot, "seenEverydayList"] = seenEverydayList.ToArray();
			}
			else{
				Debug.Log("Not connected to AP, skipping datastore update.");
			}
		}
		
		//Determine if we can goal.
		//Used to disable the infinitley looping elevator.
		public static bool canGoal(){
			return talentFlags["Mikodanye"] && talentFlags["Taranchama"];
		}
		
		
	}
}