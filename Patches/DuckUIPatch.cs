using HarmonyLib;
using Il2Cpp;
using static PPDSAP.ApDuckClient;

namespace PPDSAP.Patches;

[PatchAll]
public class DuckUIPatch
{
    [HarmonyPatch(typeof(DuckUI), "Update"), HarmonyPrefix]
    public static void Update(DuckUI __instance)
    {
        __instance.duckArtwork.enabled = false;
        __instance.enabled = false;
        if (!DuckIdToName.TryGetValue(__instance.duckID, out var duckLocation)) return;
        __instance.enabled = true;
        var has = !Client!.MissingLocations.Contains(duckLocation);
        var available = AvailableDuckIds.Contains(__instance.duckID);
        
        __instance.duckArtwork.enabled = available;
        if (!available) return;
        __instance.duckArtwork.sprite = has ? __instance.DuckArtworkSprite : __instance.LockedSprite;
    }
}