using System;
using System.Runtime.CompilerServices;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Platforms;

class CCEnv
{
    private Script Script;

    static CCEnv()
    {
        // Script.GlobalOptions.Platform = new LimitedPlatformAccessor();
    }

    public CCEnv()
    {
        this.Refresh();
    }

    public void Refresh()
    {
        Script = new Script();
        Script.Globals.Set("require", DynValue.Nil); // Prevent multi-file scripts.
        Script.Globals.Set("ship", UserData.Create(new CCShip()));
        Script.Globals.Set("game", UserData.Create(new CCGame()));
        Script.Globals["print"] = (Action<DynValue>)Print;
    }

    public void ExecString(string code)
    {
        Script.DoString(code);
    }

    private void Print(DynValue msg)
    {
        // TODO: complete me
        Console.WriteLine(msg.ToPrintString());
    }
}