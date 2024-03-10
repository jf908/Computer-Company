using MonoMod.Cil;
using MoonSharp.Interpreter;

// lights:are_on()   -- () -> bool
// lights:turn_on()  -- Guess
// lights:turn_off() -- Guess

[MoonSharpUserData]
public class CCLights
{
    private ShipLights lights;

    public void Refresh()
    {
        lights = StartOfRound.Instance.shipRoomLights;
    }

    public bool are_on()
    {
        if (lights == null)
        {
            return false;
        }
        return lights.areLightsOn;
    }

    public void turn(string state)
    {
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