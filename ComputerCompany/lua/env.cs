using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using MonoMod.Cil;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Platforms;

class CCEnv
{
    public static CCEnv Instance;

    // public Dictionary<string, DynValue> ScriptCommands;
    public Dictionary<string, DynValue> ScriptCommands;

    private CCGame game;
    private CCShip ship;

    static CCEnv()
    {
        Instance = new CCEnv();
        // Script.GlobalOptions.Platform = new LimitedPlatformAccessor();
    }

    private Script Script;

    public Terminal Terminal { get; set; }

    public CCEnv()
    {
        ScriptCommands = new Dictionary<string, DynValue>();

        var commands = new CCCommands(ScriptCommands);
        var terminal = new CCTerminal(commands);
        ship = new CCShip(terminal);

        game = new CCGame();

        RefreshScript();
    }

    public void Refresh()
    {
        game.Refresh();
        ship.Refresh();
        ScriptCommands.Clear();

        RefreshScript();
    }

    private void RefreshScript()
    {
        Script = new Script();
        Script.Globals.Set("require", DynValue.Nil); // Prevent multi-file scripts.
        Script.Globals.Set("ship", UserData.Create(ship));
        Script.Globals.Set("game", UserData.Create(game));
        Script.Options.DebugPrint = Print;
    }

    public void RunString(string code)
    {
        try
        {
            var result = Script.DoString(code);
            if (!result.IsVoid())
            {
                // TODO make get the last statement to return something
                Print(result.ToPrintString());
            }
        }
        catch (Exception ex)
        {
            Print(ex.ToString());
            Console.WriteLine(ex);
        }
    }

    public DynValue Call(DynValue func, DynValue[] args)
    {
        return Script.Call(func, args);
    }

    public DynValue MakeDynValue(object obj)
    {
        return DynValue.FromObject(Script, obj);
    }

    private void Print(string msg)
    {
        if (Terminal != null)
        {
            Terminal.screenText.text += msg;
        }
        else
        {
            Console.WriteLine(msg);
        }
    }
}