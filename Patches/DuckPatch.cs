using HarmonyLib;
using Il2Cpp;

namespace PPDSAP.Patches;

[PatchAll]
public static class DuckPatch
{
    [HarmonyPatch(typeof(DuckManager), "Start"), HarmonyPostfix]
    public static void DuckSpawn(DuckManager __instance)
    {
        try
        {
            var names = ApDuckClient.Client!.PlayerNames;
            __instance.duckName.text = names[Random.Shared.Next(names.Length)];
        }
        catch (Exception e)
        {
            Core.Log.Error(e);
        }
    }
}