using System;
using HarmonyLib;

[HarmonyPatch(typeof(Terminal))]
public class TerminalAwakePatch
{
    [HarmonyPatch(nameof(Terminal.Awake))]
    [HarmonyPostfix]
    private static void Awake(ref Terminal __instance)
    {
        Console.WriteLine("Awake");
        CCEnv.Instance.Terminal = __instance;
        CCEnv.Instance.Refresh();
    }
}