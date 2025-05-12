using System;
using HarmonyLib;
using static PPDSAP.ApDuckClient;
using static PPDSAP.Locations;
using Random = System.Random;

namespace PPDSAP.Patches;

public class SpawnPatch
{
    public static Random Random = new();

    [HarmonyPatch(typeof(BasicSpawner), "SpawnDuck"), HarmonyPrefix]
    // override original method
    public static bool SpawnDuck(ref string duckId, bool saveSpawn, string fixedName, ref int playerID)
    {
        if (playerID != -2) return false;
        playerID = -1;
        // if (duckId != "Random Duck" && !AvailableDuckIds.Contains(DuckIdToLocationName[duckId]))
        // {
        //     duckId = LocationNameToDuckId[AvailableDuckIds[Random.Next(AvailableDuckIds.Count)]];
        //     Plugin.Log.LogInfo($"chose new from natural: {duckId}");
        // }

        if (duckId == "Random Duck")
        {
            duckId = LocationNameToDuckId[AvailableDuckIds[Random.Next(AvailableDuckIds.Count)]];
            Plugin.Log.LogInfo($"chose from rand: {duckId}");
        }
        else
        {
            var locationName = DuckIdToLocationName[duckId];
            var id = LocationNameToId[locationName];
            Plugin.Log.LogInfo($"sending new duck {duckId} = {locationName} = {id}");
            if (Client!.MissingLocations.ContainsKey(id))
            {
                Client.SendLocation(id);
            }
        }

        // Plugin.Log.LogInfo("new duck done");
        Plugin.Log.LogInfo($"Spawning: [{DuckIdToLocationName[duckId]}]");
        return true;
    }
}