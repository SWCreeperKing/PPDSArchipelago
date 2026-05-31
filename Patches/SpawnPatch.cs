using HarmonyLib;
using Il2Cpp;
using Il2CppFusion;
using static PPDSAP.ApDuckClient;
using Random = System.Random;

namespace PPDSAP.Patches;

[PatchAll]
public class SpawnPatch
{
    public static Random Random = new();
    
    [HarmonyPatch(typeof(BasicSpawner), "SpawnDuck"), HarmonyPrefix]
    public static bool SpawnDuck(BasicSpawner __instance, ref string duckId, bool saveSpawn, string fixedName, ref int playerID)
    {
        try
        {
            if (playerID != -2) return false;
            playerID = -1;

            if (duckId != "Random Duck" && !DuckIdToName.ContainsKey(duckId))
            {
                Core.Log.Warning($"Duck Name not found: [{duckId}]");
                duckId = "Random Duck";
            }

            if (duckId != "Random Duck" && !__instance.Ducks.ContainsKey(duckId))
            {
                Core.Log.Warning($"Duck ID not found: [{duckId}]");
                duckId = "Random Duck";
            }

            if (duckId == "Random Duck")
            {
                duckId = AvailableDuckIds[Random.Next(AvailableDuckIds.Count)];
                Core.Log.Msg($"chose from rand: {duckId}");
            }
            else
            {
                var locationName = DuckIdToName[duckId];
                Core.Log.Msg($"sending new duck {duckId} = {locationName}");
                Client!.SendLocation(DuckIdToName[duckId]);
            }

            Core.Log.Msg($"Spawning: [{DuckIdToName[duckId]}]");
            return true;
        }
        catch (Exception e)
        {
            Core.Log.Error(e);
            return false;
        }
    }
}