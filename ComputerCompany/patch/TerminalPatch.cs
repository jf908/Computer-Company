using System;
using System.Reflection;
using HarmonyLib;
using UnityEngine.UIElements;

namespace DistractedCompany.patch;

[HarmonyPatch(typeof(Terminal))]
public class TerminalPatch
{
    // [HarmonyPatch(nameof(Terminal.ParsePlayerSentence))]
    [HarmonyPrefix]
    private static bool ParsePlayerSentence(ref Terminal __instance, MethodBase __originalMethod)
    {
        HUDManager.Instance.AddTextToChatOnServer("WAAAAAAA");

        __instance.broadcastedCodeThisFrame = false; // ?
        string s = __instance.RemovePunctuation(__instance.screenText.text.Substring(__instance.screenText.text.Length - __instance.textAdded));
        string[] words = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        if (words.Length < 1)
        {
            return true;
        }
        if (words.Length >= 2)
        {
            if (words[0] == "run" && words[1] == "lua")
            {
                // TODO(kcza): reload the lua here!
                return false;
            }
        }

        return true;
    }
}