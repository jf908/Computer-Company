using System.Threading;
using System.Xml.Serialization;
using MoonSharp.Interpreter;
using UnityEngine;

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

    public void ViewMap()
    {
        // TODO: fix me!
        // var startOfRound = StartOfRound.Instance;
        // startOfRound.SetMapScreenInfoToCurrentLevel();
        // StartOfRound.Instance.SwitchMapMonitorPurpose(false);
        // StartOfRound.Instance.SwitchMapMonitorPurpose(false);
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
                throw new System.Exception("argument must be 'on' or 'off'");
        }
    }

    public void Switch(string player)
    {
        var terminal = Object.FindObjectOfType<Terminal>();
        int num = terminal.CheckForPlayerNameCommand("switch", player);
        if (num != -1)
        {
            StartOfRound.Instance.mapScreen.SwitchRadarTargetAndSync(num);
        }
    }

    public string CurrentPlayer()
    {
        // TODO: test me!
        return StartOfRound.Instance.mapScreen.radarTargets[StartOfRound.Instance.mapScreen.targetTransformIndex].name;
    }

    public string[] PlayersOnScreen()
    {
        // TODO: implement me!
        throw new System.Exception("unimplemented");
    }

    public CCEnemyInfo[] EnemiesOnScreen()
    {
        // TODO: implement me!
        throw new System.Exception("unimplemented");
    }
}