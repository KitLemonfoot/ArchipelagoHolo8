using HarmonyLib;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;

namespace ArchipelagoHolo8;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
        
    private void Awake()
    {
        MiscHandler.setConfig(base.Config);
		//Harmony setup
		Harmony harmony = new Harmony("archipelago");
		harmony.PatchAll();
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }
}
