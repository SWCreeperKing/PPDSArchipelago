using HarmonyLib;
using Il2Cpp;

namespace PPDSAP.Patches;

public static class DuckPatch
{
    [HarmonyPatch(typeof(DuckManager), "Start"), HarmonyPostfix]
    public static void DuckSpawn(DuckManager __instance)
    {
        var names = ApDuckClient.Client!.PlayerNames;
        __instance.duckName.text = names[Random.Shared.Next(names.Length)];
    }
}