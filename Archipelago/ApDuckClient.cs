#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using CreepyUtil.Archipelago;
using CreepyUtil.Archipelago.ApClient;
using Il2Cpp;
using PPDSAP.Patches;
using UnityEngine;
using static Archipelago.MultiClient.Net.Enums.ItemsHandlingFlags;
using Random = System.Random;

namespace PPDSAP;

public static class ApDuckClient
{
    public static ApClient? Client;
    public static int ColumnCount;
    public static int SpeedCount;
    public static int DuckCount;
    public static List<string> AvailableDuckIds = [];
    public static List<string> UniqueDuckIds = [];
    public static float Timer = 0;
    public static bool HasStartingDuck;
    public static Dictionary<string, string> DuckIdToName = [];
    public static Dictionary<string, DlcType> DuckDlcs = [];
    public static Dictionary<int, string[]> DuckColumns = [];
    public static HashSet<DlcType> DlcItems = [];

    public static string[]? TryConnect(int port, string slot, string address, string password)
    {
        try
        {
            Reset();
            Client = new ApClient();
            Core.Log.Msg($"Attempting to connect [{address}]:[{port}] [{password}] [{slot}]");

            Client.OnConnectionErrorReceived += (exception, message) => Core.Log.Error($"{exception}\n{message}");
            Client.ItemsSentNotification += s => Core.Log.Msg(s);
            Client.OnConnectionEvent += _ => UpdateColumns();

            var connectError = Client.TryConnect(
                new LoginInfo(port, slot, address, password),
                "Placid Plastic Duck Simulator", AllItems
            );

            if (connectError is not null && connectError.Length > 0)
            {
                Core.Log.Msg($"There was an Error");
                Core.Log.Error(string.Join("\n", connectError));
                Disconnect();
                return connectError;
            }

            HasConnected();
        }
        catch (Exception e)
        {
            Core.Log.Msg("There was an Error");
            Disconnect();
            return [e.Message, e.StackTrace!];
        }

        return null;
    }

    public static void Disconnect()
    {
        Client?.TryDisconnect();
        Client = null;
        Core.Log.Msg("Disconnected");
    }

    public static void HasConnected() => Core.Log.Msg("Connnected");
    public static bool IsConnected() => Client is not null && Client.IsConnected;

    public static void Reset()
    {
        HasStartingDuck = false;
        ColumnCount = 0;
        SpeedCount = 0;
        Timer = 0;
        AvailableDuckIds.Clear();
        UniqueDuckIds.Clear();
        DlcItems.Clear();
    }

    public static void Update(GeneralManager? manager)
    {
        var delta = Time.deltaTime;

        if (Client is null) return;
        Client.UpdateConnection();
        if (!Client.IsConnected) return;

        foreach (var item in Client.GetOutstandingItems())
        {
            switch (item!.ItemName)
            {
                case "Progressive Column Unlock":
                    ColumnCount++;
                    UpdateColumns();
                    break;
                case "Progressive Spawn Speed Upgrade": SpeedCount++; break;
                case "Random Duck": DuckCount++; break;
                case "Ducks Please Ducks":
                    DlcItems.Add(DlcType.DucksPlease);
                    UpdateColumns();
                    break;
                case "Duck Addiction Ducks":
                    DlcItems.Add(DlcType.DuckAddiction);
                    UpdateColumns();
                    break;
                case "So Many Ducks Ducks":
                    DlcItems.Add(DlcType.SoManyDucks);
                    UpdateColumns();
                    break;
                case "Ducks Galore Ducks":
                    DlcItems.Add(DlcType.DucksGalore);
                    UpdateColumns();
                    break;
                case "Ducklings Ducks":
                    DlcItems.Add(DlcType.Ducklings);
                    UpdateColumns();
                    break;
            }
        }

        if (manager is null) return;
        if (!HasStartingDuck)
        {
            HasStartingDuck = true;
            manager.basicSpawner.SpawnDuck("Duck1Base", false, "", -2);
        }

        Timer += delta;
        if (Timer >= 120 - SpeedCount * 10)
        {
            Timer = 0;
            manager.basicSpawner.SpawnDuck(GetNeededDuck(), false, "", -2);
        }

        if (DuckCount <= 0) return;
        if (manager.basicSpawner is null) return;
        manager.basicSpawner.SpawnDuck("Random Duck", false, playerID: -2);
        DuckCount--;
    }

    public static void UpdateColumns()
    {
        AvailableDuckIds.AddRange(
            Enumerable.Range(0, ColumnCount + 1).SelectMany(col => DuckColumns[col].Where(duckId =>
                {
                    var dlc = DuckDlcs[duckId];
                    return dlc is DlcType.BaseGame || DlcItems.Contains(dlc);
                }
            )
        ));

        Core.Log.Msg($"ducks available: [{string.Join(", ", AvailableDuckIds)}]");
        Core.Log.Msg($"ducks left before prune: [{string.Join(", ", UniqueDuckIds)}]");
        
        UniqueDuckIds = AvailableDuckIds.Where(id => Client!.MissingLocations.Contains(DuckIdToName[id])).ToList();

        Core.Log.Msg($"ducks left: [{string.Join(", ", UniqueDuckIds)}]");
    }

    public static string GetNeededDuck()
    {
        if (UniqueDuckIds.Count == 0) { return "Random Duck"; }

        var randomId = UniqueDuckIds[SpawnPatch.Random.Next(UniqueDuckIds.Count)];
        UniqueDuckIds.Remove(randomId);
        Core.Log.Msg($"ducks left: [{string.Join(", ", UniqueDuckIds)}]");

        if (UniqueDuckIds.Count == 0 && ColumnCount == 9) { Client!.TryGoal(); }

        return randomId;
    }
}