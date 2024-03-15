using System.Threading;
using MoonSharp.Interpreter;
using UnityEngine;

// horn:sound(millis) -- (number) -> ()

[MoonSharpUserData]
public class CCHorn
{
    private ShipAlarmCord cord;

    public void Refresh()
    {
    }

    public bool IsAvailable()
    {
        return Object.FindObjectOfType<ShipAlarmCord>() != null;
    }

    public void Sound(double seconds)
    {
        // TODO: Complete me!
        cord.HoldCordDown();

        var millis = (int)(seconds / 1000.0);
        Thread.Sleep(millis);

        cord.StopHorn();
    }
}