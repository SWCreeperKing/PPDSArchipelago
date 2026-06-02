using Il2Cpp;
using MelonLoader;
using PPDSAP;
using PPDSAP.Patches;
using Slimipelago;
using UnityEngine;

[assembly: MelonInfo(typeof(Core), "PPDSAP", "0.3.0", "SW_CreeperKing", null)]
[assembly: MelonGame("Turbolento Games", "Placid Plastic Duck Simulator")]

namespace PPDSAP;

public class Core : MelonMod
{
    public const string DataFolder = "Mods/SW_CreeperKing.Duckipelago/Data";
    public static MelonLogger.Instance Log;

    public override void OnInitializeMelon()
    {
        Log = LoggerInstance;

        Log.Msg("Get dunc'd on");

        HarmonySetup.Init(MelonAssembly.Assembly, HarmonyInstance);

        var ducks = File.ReadAllLines($"{DataFolder}/ducks.txt").Select(line => line.Split('|')).ToArray();
        ApDuckClient.DuckIdToName = ducks.ToDictionary(arr => arr[1], arr => arr[0]);
        ApDuckClient.DuckDlcs = ducks.ToDictionary(arr => arr[1], arr => (DlcType)int.Parse(arr[2]));
        ApDuckClient.DuckColumns = ducks.GroupBy(arr => arr[3])
                                        .ToDictionary(g => int.Parse(g.Key) - 1, g => g.Select(arr => arr[1]).ToArray());

        Log.Msg($"columns: [{string.Join(", ", ApDuckClient.DuckColumns.Keys)}]");
        
        LoggerInstance.Msg("Initialized.");

        // KeyRegistry.AddKey(
        //     KeyCode.K, () =>
        //     {
        //         //         // var ducks = new Il2CppSystem.Collections.Generic.List<string>();
        //         //         // ducks.Add();
        //         //
        //         //         // var spawnPoint = BasicSpawner.I.GeneralManager.SpawnPoint;
        //         //         // var entries = GetIdFromUI.Entries.Keys.ToArray();
        //         //         // var randDuck = GetIdFromUI.Entries[entries[new System.Random().Next(entries.Length)]];
        //         //         //
        //         //         // BasicSpawner.I.GeneralManager.
        //         //         //
        //         //         // var duck = randDuck.duckRef.Instantiate(spawnPoint.position, spawnPoint.rotation).Result;
        //         //         // var manager = duck.GetComponent<DuckManager>();
        //         //         // BasicSpawner.I.OnDuckSpawned?.Invoke(manager);
        //         //         // var duck = randDuck.duckRef.Instantiate(spawnPoint.position, spawnPoint.rotation).Result;
        //         //         // duck.GetComponent<DuckManager>().Spawned();
        //         //
        //         var spawner = BasicSpawner.I;
        //         //         var unspawnable = ApDuckClient.DuckIdToName.Where(kv => !spawner.Ducks.ContainsKey(kv.Key)).Select(kv => kv.Value).ToArray();
        //         //         Log.Msg($"Unspawnable: [{string.Join(", ", unspawnable)}]");
        //
        //         if (!spawner.Ducks.TryGetValue("", out var duck)) return;
        //     }
        // );
    }

    public override void OnUpdate()
    {
        KeyRegistry.Update();
        if (GeneralManagerPatch.Manager is null) return;
        ApDuckClient.Update(GeneralManagerPatch.Manager);
    }
}

public enum DlcType
{
    BaseGame, DucksPlease, QuackingTheIce,
    DuckAddiction, HippospaceDownload, SoManyDucks,
    RooftopOnePercent, DucksGalore, Ducklings,
    VirtualThermae,
}