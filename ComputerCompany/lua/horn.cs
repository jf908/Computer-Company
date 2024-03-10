using System;
using System.Net.WebSockets;
using System.Threading;
using MoonSharp.Interpreter;

// horn:sound(millis) -- (number) -> ()

[MoonSharpUserData]
public class CCHorn
{
    private ShipAlarmCord cord;

    public void Refresh()
    {
        // StartOfRound.Instance.SpawnedShipUnlockables
        foreach (var u in StartOfRound.Instance.unlockablesList.unlockables)
        {
            Console.WriteLine(u);
        }
    }

    public bool IsAvailable()
    {
        // TODO: complete me!
        return true;
    }

    public void sound(double seconds)
    {
        // TODO: Complete me!
        cord.HoldCordDown();

        var millis = (int)(seconds / 1000.0);
        Thread.Sleep(millis);

        cord.StopHorn();
    }
}