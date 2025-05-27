using System.Linq;
using HarmonyLib;
using static PPDSAP.ApDuckClient;
using static PPDSAP.Locations;

namespace PPDSAP.Patches;

public class DuckUIPatch
{
    [HarmonyPatch(typeof(DuckUI), "Update"), HarmonyPrefix]
    public static void Update(DuckUI __instance)
    {
        __instance.duckArtwork.enabled = false;
        __instance.enabled = false;
        if (!DuckIdToLocationName.TryGetValue(__instance.ID, out var duckLocation)) return;
        __instance.enabled = true;
        var has = Client!.MissingLocations.All(kv => kv.Value.LocationName != duckLocation);
        var available = AvailableDuckIds.Contains(duckLocation);
        
        __instance.duckArtwork.enabled = available;
        if (!available) return;
        __instance.duckArtwork.sprite = has ? __instance.DuckArtworkSprite : __instance.LockedSprite;
    }
}