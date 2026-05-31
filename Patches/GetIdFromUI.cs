using HarmonyLib;
using Il2Cpp;
using UnityEngine;

namespace PPDSAP.Patches;

// [PatchAll]
public static class GetIdFromUI
{
    public static Dictionary<string, DuckEntry> Entries = [];
    // public static SetsManager DuckSetManager = null;

    // public static Dictionary<int, PriorityQueue<string, int>> Ducks = [];
    // public static PriorityQueue<string, int> Ducks = new();

    // [HarmonyPatch(typeof(DuckUI), "Start"), HarmonyPostfix]
    // public static void Start(DuckUI __instance)
    // {
    //     var page = __instance.gameObject.transform.parent.gameObject;
    //     var pageNumber = int.Parse($"{page.name[4]}");
    //
    //     // if (!Ducks.ContainsKey(pageNumber)) Ducks[pageNumber] = new PriorityQueue<string, int>();
    //     // Ducks[pageNumber].Enqueue(__instance.ID, __instance.gameObject.transform.GetSiblingIndex());
    //     Ducks.Enqueue(__instance.ID, pageNumber * 1000 + __instance.gameObject.transform.GetSiblingIndex());
    //
    //     Core.Log.Msg($"added: [{__instance.ID}]");
    // }

    [HarmonyPatch(typeof(SetsManager), "AddSet", typeof(DuckSet), typeof(bool)), HarmonyPostfix]
    public static void SetDuckSetManager(SetsManager __instance)
    {
        if (Entries.Count > 0) return;
        foreach (var set in __instance.Sets)
        {
            foreach (var duck in set.commonDucks.ToArray().Concat(set.rareDucks.ToArray())
                                    .Concat(set.superRareDucks.ToArray()))
            {
                Entries[duck.duckID] = duck;
                // Core.Log.Msg($"Added: [{duck.duckID}]");
            }
        }
    }
}