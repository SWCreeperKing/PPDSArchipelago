using Il2CppInterop.Runtime.Injection;
using MelonLoader;
using PPDSAP;
using PPDSAP.Patches;

[assembly: MelonInfo(typeof(Plugin), "PPDSAP", "1.0.0", "SW_CreeperKing", null)]
[assembly: MelonGame("Turbolento Games", "Placid Plastic Duck Simulator")]
namespace PPDSAP;

public class Plugin : MelonMod
{
    public static MelonLogger.Instance Log;

    public override void OnInitializeMelon()
    {
        Log = LoggerInstance;

        Log.Msg("Get dunc'd on");
        
        HarmonyInstance.PatchAll(typeof(SpawnPatch));
        HarmonyInstance.PatchAll(typeof(MainMenuPatch));
        HarmonyInstance.PatchAll(typeof(GeneralManagerPatch));
        HarmonyInstance.PatchAll(typeof(DuckUIPatch));
        HarmonyInstance.PatchAll(typeof(DuckPatch));
            
        LoggerInstance.Msg("Initialized.");
    }
}