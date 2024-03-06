using MoonSharp.Interpreter;

// lights:are_on()   -- () -> bool
// lights:turn_on()  -- Guess
// lights:turn_off() -- Guess

[MoonSharpUserData]
public class CCLights {
    public bool are_on() {
        // TODO: complete me!
        return false;
    }

    public void turn(string state) {
        switch (state) {
        case "on":
            // TODO: complete me!
            break;
        case "off":
            // TODO: complete me!  
            break;
        default:
            // TODO: complete me!
            break;
        }
    }
}