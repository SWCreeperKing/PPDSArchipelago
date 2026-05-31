using HarmonyLib;
using Il2Cpp;

namespace PPDSAP.Patches;

// [PatchAll]
public static class DuckManagerPatch
{
    [HarmonyPatch(typeof(DuckManager), "DuckQuack"), HarmonyPrefix]
    public static void OnQuack(DuckManager __instance)
    {
        Core.Log.Msg($"Quacked [{__instance.name}]");
    }
}