using MoonSharp.Interpreter;
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

    public void send(string message)
    {
        // TODO: complete me!
    }
}