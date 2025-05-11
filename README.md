# holo8 Archipelago Client
[<img src="https://i.imgur.com/X2EAzUB.png" height="250"/>](https://i.imgur.com/X2EAzUB.png)

This is a work-in-progress BepInEx mod for [holo8](https://store.steampowered.com/app/3373960/holo8/) that targets the [Archipelago Multiworld Randomizer](https://archipelago.gg/).

# Uh, fangame?

Aha, not so. holo8 [is published under the CCMC Corporation's HoloIndie project](https://ccmc-corp.com/en/202502/29/), which permits the game's developer to use Cover Corporation's intellectual property with full permission.

# What does Archipelago do to holo8? Isn't the game already fully random?

- Encountering and successfully determining an anomaly is a check. *You will not be given a check if you fail to detect an anomaly.*
- Certain anomalies will not be encountered until you have the respective item relating to the anomaly.
	- For instance, an anomaly containing Oozora Subaru will not be viewable until you obtain the *Hololive Generation 2* item.
	- Anomalies containing members of Hololive Project HOPE and Hololive Council have been consolidated into the *Hololive CouncilRyS* item.
	- This does not apply to anomalies affecting the default Ayame, Suisei and Marine characters already in the office; their anomalies are available at the start of the game.
- Various YAML settings exist to modify how anomalies generate.
	- You can choose to play with only anomalies from Normal Mode, Everyday Mode, or both at the same time.
	- You can choose whether certain hard-to-spot anomalies, such as the blinking AZKi poster or the invisible Botan, are included as checks.
	- You can choose how often floors with no anomalies appear (though this does not affect the built-in 2 anomaly failsafe). Likewise, you can also choose the likelihood that a floor with an anomaly you have already checked can appear.
- DeathLink support: If enabled, being killed by an anomaly will kill every other player in your multiworld that has the DeathLink option enabled in their YAML. Likewise, if someone else dies in their game, you will be sent back to Floor 8.

You will need to find the *Mikodanye* and *Taranchama* items before the elevator is allowed to progress past Floor 8. Once the elevator is working again, you simply need to escape the office to goal.

# Setup
You will need the following:
-   The latest version of holo8, downloaded from Steam
-   The Archipelago software from [their Releases page](https://github.com/ArchipelagoMW/Archipelago/releases/latest)
-   The apworld and patch files from our releases page
-   [BepInEx x64 5.4.23.x](https://github.com/BepInEx/BepInEx/releases)

### Installing
1. Navigate to holo8's local file directory. This can be found by right-clicking on the game in your Steam Library, selecting *Manage*, then selecting *Browse Local Files*.
2. Install BepInEx to your copy of holo8.
3. Install the contents of `Holo8_Patches.zip`to the BepInEx folder. You should have two folders in the BepInEx folder: `core` and `plugins`.
4. Run the game to generate BepInEx's and the mod's config data.

### APWorld Setup
1. Install Archipelago and open the Archipelago launcher.
2. Click "Install APWorld" and select the `holo8.apworld` file to install the holo8 apworld.
3. Click on "Generate Template Options" to generate a template YAML file for holo8.
4. Modify the YAML file to your liking and place it in the `Players` folder.

All further instructions can be found in the [official Archipelago Setup Guide](https://archipelago.gg/tutorial/Archipelago/setup/en#on-your-local-installation).

### Connection
1. In the `ArchipelagoHolo8.cfg` file in the `BepInEx\config` folder, enter your Archipelago server's IP address, your slot name, and your server's password if any.
2. Start holo8. The game should connect to the server automatically during bootup.

Note: It is HIGHLY recommended to have the Archipelago Text Client open alongside your game, as there are currently no indicators when you receive an item.

# Building
You will need the latest version of the [.NET SDK](https://dotnet.microsoft.com/download) installed.
- Place your vanilla holo8 `Assembly-CSharp.dll` and `netstandard.dll` in the project's lib folder. Both these dll files can be obtained from the `/holo8_Data/Managed` folder.
- Ensure you are building a BepInEx 5 Plugin targeting NET45 and Unity 2022.3.9.
- Run `dotnet build`.
- Move the resultant `ArchipelagoHolo8.dll`, as well as `Archipelago.MultiClient.Net.dll` and `Newtonsoft.Json.dll` to your BepInEx plugins folder.

# Todo
So so much to do.
- A proper GUI needs to be built for managing Archipelago settings and connections. As it stands, the existing Archipelago MultiClient GUI template does not seem to function properly with holo8.
- A visual modification that sets the elevator color to black when you are in BK mode.
- An option for logic to operate per-talent instead of per-generation. This will cut down on filler, but will also make the logic more Clique-esque.
- General code cleanup, on both the APWorld side and the client side.

# Special Thanks
- **TGRP0** for creating their [ULTRAKILL Archipelago implementation](https://github.com/TRPG0/ArchipelagoULTRAKILL/) that this project _heavily_ referenced data and code from
- **Jarno** for creating their [Timespinner Archipelago implementation](https://github.com/Jarno458/TsRandomizer) that I based a lot of the APWorld code off of
- **chandler05** for creating their [A Short Hike Archipelago implementation](https://github.com/chandler05/AShortHike.Randomizer) that immensely helped in regards to getting netstandard2.1 Unity games working with Archipelago
- **icsharpcode** for creating [ILSpy](https://github.com/icsharpcode/ILSpy) to decompile holo8's C# code
- **frog blend** for creating holo8
- **Anya Melfissa** for being wonderful background noise while I developed this client