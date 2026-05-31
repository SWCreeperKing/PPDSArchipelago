using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;

namespace PPDSAP;

public static class HarmonySetup
{
    public static void Init(Assembly assembly, HarmonyLib.Harmony harmonyInstance)
    {
        var classesToPatch = assembly.GetTypes()
                                     .Where(t => t.GetCustomAttributes(typeof(PatchAllAttribute), false).Any())
                                     .ToArray();

        Core.Log.Msg($"Loading [{classesToPatch.Length}] Class patches");

        foreach (var patch in classesToPatch) { harmonyInstance.PatchAll(patch); }
    }

    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var l = instructions.ToList();
        var s = "Code:";
        var i = 0;
        foreach (var c in l)
        {
            // Optional: Highlight specific opcodes like calls
            if (c.opcode == OpCodes.Call || c.opcode == OpCodes.Callvirt) Core.Log.Warning($"{i}: {c}");
            else Core.Log.Msg($"{i}: {c}");
            s += $"\n{i}: {c}";
            i++;
            yield return c;
        }
        Core.Log.Error(s); // Or FileLog.Log(s) for a file dump
    }
}

[AttributeUsage(AttributeTargets.Class)]
public class PatchAllAttribute : Attribute;