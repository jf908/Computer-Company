using System;
using MonoMod.Cil;
using MoonSharp.Interpreter;

// lights:are_on()   -- () -> bool
// lights:turn('on'|'off')  -- Guess

[MoonSharpUserData]
public class CCLights
{
    private ShipLights lights;

    public void Refresh()
    {
        lights = StartOfRound.Instance.shipRoomLights;
    }

    public bool AreOn()
    {
        Console.WriteLine(lights);
        if (lights == null)
        {
            return false;
        }
        return lights.areLightsOn;
    }

    public void Turn(string state)
    {
        Console.WriteLine(lights);
        if (lights == null)
        {
            return;
        }

        switch (state)
        {
            case "on":
                lights.SetShipLightsBoolean(true);
                break;
            case "off":
                lights.SetShipLightsBoolean(false);
                break;
            default:
                // TODO: complete me!
                break;
        }
    }
}