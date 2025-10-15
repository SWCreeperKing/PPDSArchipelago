using System;
using HarmonyLib;
using Il2Cpp;
using JetBrains.Annotations;
using UnityEngine;

namespace PPDSAP.Patches;

public class GeneralManagerPatch
{
    public static GeneralManager Manager;
    
    [HarmonyPatch(typeof(GeneralManager), "Start"), HarmonyPrefix]
    public static void GeneralAwake(GeneralManager __instance)
    {
        Manager = __instance;
        __instance.spawnStop = true;
        __instance.gameObject.AddComponent<ApDisconnectWarn>();
        
        FindAndHide("SAVE_Button");
        FindAndHide("SaveBeforeExitScreen/Popup/Info_Panel/Buttons/ConfirmButton");
    }
    
    public static GameObject GetObject(string name) => GameObject.Find(name);
    public static void FindAndHide(string name) => GetObject(name).SetActive(false);
}