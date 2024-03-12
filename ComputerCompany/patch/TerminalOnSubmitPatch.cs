using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using HarmonyLib;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using MoonSharp.Interpreter;
using TMPro;

namespace DistractedCompany.patch;

[HarmonyPatch(typeof(Terminal))]
public class TerminalOnSubmitPatch
{
    [HarmonyPatch(nameof(Terminal.OnSubmit))]
    [HarmonyPrefix]
    private static bool OnSubmit(ref Terminal __instance, MethodBase __originalMethod)
    {
        Console.WriteLine("WAAAA");
        HUDManager.Instance.AddTextToChatOnServer("WAAAAAAA");

        __instance.broadcastedCodeThisFrame = false; // ?
        string raw_input = __instance.screenText.text.Substring(__instance.screenText.text.Length - __instance.textAdded);
        string trimmed_input = raw_input.Trim();

        if (trimmed_input == "refresh")
        {
            CCEnv.Instance.Terminal.modifyingText = true;
            CCEnv.Instance.Terminal.screenText.text = CCEnv.Instance.Terminal.screenText.text.Substring(0, CCEnv.Instance.Terminal.screenText.text.Length - CCEnv.Instance.Terminal.textAdded);
            CCEnv.Instance.Terminal.currentText = CCEnv.Instance.Terminal.screenText.text;
            CCEnv.Instance.Terminal.textAdded = 0;

            CCEnv.Instance.Refresh();

            CCEnv.Instance.Terminal.LoadNewNode(new TerminalNode { displayText = "done\n\n" });
            CCEnv.Instance.Terminal.LoadNewNode(new TerminalNode { displayText = "" });
            CCEnv.Instance.Terminal.screenText.ActivateInputField();
            CCEnv.Instance.Terminal.screenText.Select();
            return false;
        }

        if (trimmed_input.StartsWith('$'))
        {
            CCEnv.Instance.Terminal.modifyingText = true;
            CCEnv.Instance.Terminal.screenText.text = CCEnv.Instance.Terminal.screenText.text.Substring(0, CCEnv.Instance.Terminal.screenText.text.Length - CCEnv.Instance.Terminal.textAdded);
            CCEnv.Instance.Terminal.currentText = CCEnv.Instance.Terminal.screenText.text;
            CCEnv.Instance.Terminal.textAdded = 0;

            string code = trimmed_input[1..];
            CCEnv.Instance.RunString(code);

            CCEnv.Instance.Terminal.LoadNewNode(new TerminalNode { displayText = "done\n\n" });
            CCEnv.Instance.Terminal.LoadNewNode(new TerminalNode { displayText = "" });
            CCEnv.Instance.Terminal.screenText.ActivateInputField();
            CCEnv.Instance.Terminal.screenText.Select();
            // if (CCEnv.Instance.Terminal.forceScrollbarCoroutine != null)
            // {
            //     ((MonoBehaviour)__instance).StopCoroutine(CCEnv.Instance.Terminal.forceScrollbarCoroutine);
            // }
            // CCEnv.Instance.Terminal.forceScrollbarCoroutine = ((MonoBehaviour)__instance).StartCoroutine(CCEnv.Instance.Terminal.forceScrollbarUp());
            return false;
        }

        string[] words = __instance.RemovePunctuation(trimmed_input).Split(" ", StringSplitOptions.RemoveEmptyEntries);
        DynValue func = null;
        if (words.Length >= 1 && CCEnv.Instance.ScriptCommands.TryGetValue(words[0], out func))
        {
            var args = new List<DynValue>(words.Length - 1);
            foreach (var word in words[1..])
            {
                args.Add(CCEnv.Instance.MakeDynValue(word));
            }
            CCEnv.Instance.Call(func, args.ToArray());
        }

        return true;
    }
}