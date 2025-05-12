using System;
using HarmonyLib;
using JetBrains.Annotations;
using UnityEngine;

namespace PPDSAP.Patches;

public class GeneralManagerPatch
{
    [HarmonyPatch(typeof(GeneralManager), "Start"), HarmonyPrefix]
    public static void GeneralAwake(GeneralManager __instance)
    {
        __instance.spawnStop = true;
        __instance.gameObject.AddComponent<ApDisconnectWarn>();
        
        FindAndHide("SAVE_Button");
        FindAndHide("SaveBeforeExitScreen/Popup/Info_Panel/Buttons/ConfirmButton");
    }

    [HarmonyPatch(typeof(GeneralManager), "Update"), HarmonyPrefix]
    public static void Update(GeneralManager __instance) => ApDuckClient.Update(__instance);
    
    public static GameObject GetObject(string name) => GameObject.Find(name);
    public static void FindAndHide(string name) => GetObject(name).SetActive(false);
}