using System;
using System.Threading;
using System.Xml.Serialization;
using MoonSharp.Interpreter;

// monitor:view()              -- Toggle the console monitor underlay (i.e. run `view monitor`)
// monitor:turn_off()
// monitor:turn_on()
// monitor:switch_to(player)   -- (string) -> () switch to the given player
// monitor:viewing_player()    -- string         e.g. the person who's just been 'switch'd to
// monitor:players_on_screen() -- [string]       e.g. if viewing 'kcza' and 'josh' is right next to him, this is {'kcza', 'josh'} (order insignificant)
// monitor:enemies_on_screen() -- [string] (where string is an enum of dot sizes? not sure here, could be nice to allow if in_danger(player) then teleport(player) end)option to disable by default! Will fail with message 'nice try, config says no' if not

[MoonSharpUserData]
public class CCMonitor
{
    public void Refresh() { }

    public void ViewMap(string message)
    {
        // TODO: implement me!
    }

    public void Turn(string state)
    {
        switch (state)
        {
            case "on":
                break;
            case "off":
                break;
            default:
                // TODO: wtf
                break;
        }
    }

    public void Switch(string player)
    {
        // TODO: implement me!
    }

    public string CurrentPlayer(string player)
    {
        // TODO: implement me!
        throw new SystemException("unimplemented");
    }

    public string[] PlayersOnScreen(string player)
    {
        // TODO: implement me!
        throw new SystemException("unimplemented");
    }

    public CCEnemyInfo[] EnemiesOnScreen(string player)
    {
        // TODO: implement me!
        throw new SystemException("unimplemented");
    }
}