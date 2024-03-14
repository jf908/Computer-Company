using MoonSharp.Interpreter;
using Unity.Netcode;
using UnityEngine;

// signal_translator:send('gtfo')

[MoonSharpUserData]
public class CCSignalTranslator
{
    public void Refresh() { }

    public bool IsAvailable()
    {
        return Object.FindObjectOfType<SignalTranslator>() != null;
    }

    public void Send(string message)
    {
        SignalTranslator signalTranslator = UnityEngine.Object.FindObjectOfType<SignalTranslator>();
        if (!(signalTranslator != null) || !(Time.realtimeSinceStartup - signalTranslator.timeLastUsingSignalTranslator > 8f))
        {
            return;
        }

        string text = message.Substring(8);
        if (!string.IsNullOrEmpty(text))
        {
            if (!NetworkManager.Singleton.IsServer)
            {
                signalTranslator.timeLastUsingSignalTranslator = Time.realtimeSinceStartup;
            }

            HUDManager.Instance.UseSignalTranslatorServerRpc(text.Substring(0, Mathf.Min(text.Length, 10)));
        }
    }
}