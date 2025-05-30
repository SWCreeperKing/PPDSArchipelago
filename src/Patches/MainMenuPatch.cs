using System;
using HarmonyLib;
using UnityEngine;

namespace PPDSAP.Patches;

public class MainMenuPatch
{
    public static GameObject NewGame;
    // public static bool Initialized = false;
    // public static int Attempts = 0;

    // [HarmonyPatch(typeof(IntroMenuScreen), "Update"), HarmonyPostfix]
    [HarmonyPatch(typeof(MainMenuManager), "Start"), HarmonyPrefix]
    public static void Update()
    {
        // if (Initialized) return;
        // try
        // {
        FindAndHide("MULTIPLAYER");
        FindAndHide("DLC1Button");
        FindAndHide("DLC2Button");
        FindAndHide("DLC3Button");
        FindAndHide("DLC4Button");
        FindAndHide("RESUME_Button");

        NewGame = GetObject("PLAY_Button");
        NewGame.SetActive(false);

        var baseGameSelect = GetObject("BaseSet");
        baseGameSelect.GetComponent<SetToggle>().enabled = false;

        var obj = GetObject("SelectDLCS_Panel");
        APGui.Offset = new Vector2(15, 250);
        obj.AddComponent<APGui>();

        //     Initialized = true;
        // }
        // catch (Exception e)
        // {
        //     Plugin.Log.LogError(e);
        //     Plugin.Log.LogInfo($"Failed to grab objs, trying again | attempt #{Attempts}");
        //     Attempts++;
        //     // ignored
        // }
    }

    public static GameObject GetObject(string name) => GameObject.Find(name);
    public static void FindAndHide(string name) => GetObject(name)?.SetActive(false);

    // [HarmonyPatch(typeof(SaveSlot), "LoadGame")]
    // [HarmonyPrefix]
    // public static bool SaveSelect(SaveSlot __instance)
    // {
    //     // Plugin.Log.LogInfo($"DENIED | [{__instance.HasSave}]");
    //     return true;
    // }

    // [HarmonyPatch(typeof(LoadSavesScreen), "Start")]
    // public static bool LoadSaveStart(LoadSavesScreen __instance)
    // {
    //     Plugin.Log.LogInfo($"Load/Save: [{(__instance._isSavePanel ? "Save" : "Load")}]");
    //     return true;
    // }
    //
    // [HarmonyPatch(typeof(SaveSlot), "PressLoad"), HarmonyPrefix]
    // public static bool SaveSelect(SaveSlot __instance)
    // {
    //     Plugin.Log.LogInfo($"DENIED | [{__instance.ID}]");
    //     if (!__instance.HasSave) return false;
    //     return true;
    // }

    [HarmonyPatch(typeof(StagesScreen), "NextStage"), HarmonyPrefix]
    public static bool StopNextStage() { return false; }

    [HarmonyPatch(typeof(StagesScreen), "PrevStage"), HarmonyPrefix]
    public static bool StopPrevStage() { return false; }
}