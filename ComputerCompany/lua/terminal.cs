using System.ComponentModel.Design;
using MoonSharp.Interpreter;

// console.commands
[MoonSharpUserData]
public class CCTerminal
{
    public CCCommands Commands { get; }

    public CCTerminal(CCCommands commands)
    {
        Commands = commands;
    }

    // public void Exec(string command)
    // {
    //     // TODO: complete me!
    // }

    public void Refresh() { }
}