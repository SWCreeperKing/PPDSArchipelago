using System;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Il2CppInterop.Runtime.Injection;
using PPDSAP.Patches;

namespace PPDSAP;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, "0.1.0")]
public class Plugin : BasePlugin
{
    public new static ManualLogSource Log;

    public static event EventHandler<Plugin> Unloaded;

    public override void Load()
    {
        Log = base.Log;

        Log.LogInfo($"Get dunc'd on");
        Log.LogInfo($"Plugin [{MyPluginInfo.PLUGIN_GUID}] is loading!");
        
        ClassInjector.RegisterTypeInIl2Cpp<APGui>();
        ClassInjector.RegisterTypeInIl2Cpp<ApDisconnectWarn>();
        Harmony.CreateAndPatchAll(typeof(SpawnPatch));
        Harmony.CreateAndPatchAll(typeof(MainMenuPatch));
        Harmony.CreateAndPatchAll(typeof(GeneralManagerPatch));
            
        Log.LogInfo($"Plugin [{MyPluginInfo.PLUGIN_GUID}] has loaded!");
    }
    
    public override bool Unload()
    {
        Unloaded?.Invoke(this, this);
        Log.LogInfo($"Plugin [{MyPluginInfo.PLUGIN_GUID}] has unloaded!");
        return true;
    }
}