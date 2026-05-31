using System;
using HarmonyLib;
using Il2Cpp;
using UnityEngine;

namespace PPDSAP.Patches;

[PatchAll]
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
    //
    // [HarmonyPatch(typeof(LoadSavesScreen), "Start")]
    // public static bool LoadSaveStart(LoadSavesScreen __instance)
    // {
    //     // Core.Log.LogInfo($"Load/Save: [{(__instance._isSavePanel ? "Save" : "Load")}]");
    //     return true;
    // }
    //
    // [HarmonyPatch(typeof(SaveSlot), "PressLoad"), HarmonyPrefix]
    // public static bool SaveSelect(SaveSlot __instance)
    // {
    //     // Plugin.Log.LogInfo($"DENIED | [{__instance.ID}]");
    //     if (!__instance.HasSave) return false;
    //     return true;
    // }

    [HarmonyPatch(typeof(StagesScreen), "NextStage"), HarmonyPrefix]
    public static bool StopNextStage() { return false; }

    [HarmonyPatch(typeof(StagesScreen), "PrevStage"), HarmonyPrefix]
    public static bool StopPrevStage() { return false; }
    
    // [HarmonyPatch(typeof(StagesScreen), "NextStage"), HarmonyPostfix]
    // public static void StopNextStage(StagesScreen __instance)
    // {
    //     
    // }
    //
    // [HarmonyPatch(typeof(StagesScreen), "PrevStage"), HarmonyPostfix]
    // public static void StopPrevStage(StagesScreen __instance)
    // { 
    // }
    //
    // [HarmonyPatch(typeof(StagesScreen), "OnButtonPlay"), HarmonyPrefix]
    // public static bool ButtonPlay(StagesScreen __instance)
    // {
    //     return false;
    // }
}