using System.Collections.Generic;
using MoonSharp.Interpreter;
using UnityEngine;

// game:players()          -- [string], e.g. {'kcza', 'josh'}
// game:day()              -- integer,  e.g. 10
// game:next_company_day() -- integer,  e.g. 12

[MoonSharpUserData]
public class CCGame
{
    public void Refresh() { }

    public string[] Players(string message)
    {
        var startOfRound = StartOfRound.Instance;
        var players = new List<string>(StartOfRound.Instance.allPlayerScripts.Length);
        foreach (var idx in startOfRound.fullyLoadedPlayers)
        {
            players.Add(startOfRound.allPlayerScripts[idx].playerUsername);
        }
        return players.ToArray();
    }

    public int CurrentDay()
    {
        return StartOfRound.Instance.gameStats.daysSpent;
    }

    public int CurrentHour()
    {
        return TimeOfDay.Instance.hour + 6;
    }

    public int DeadlineDays()
    {
        return TimeOfDay.Instance.daysUntilDeadline;
    }

    public int Quota()
    {
        return TimeOfDay.Instance.profitQuota;
    }

    public int Earned()
    {
        return TimeOfDay.Instance.quotaFulfilled;
    }

    public int Funds()
    {
        return Object.FindObjectOfType<Terminal>().groupCredits;
    }
}