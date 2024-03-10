using MoonSharp.Interpreter;

// game:players()          -- [string], e.g. {'kcza', 'josh'}
// game:day()              -- integer,  e.g. 10
// game:next_company_day() -- integer,  e.g. 12

[MoonSharpUserData]
public class CCGame
{
    public void Refresh() { }

    public string[] Players(string message)
    {
        throw new System.Exception("unimplemented idc");
    }

    public int Day()
    {
        throw new System.Exception("unimplemented idc");
    }

    public int NextCompanyDay()
    {
        throw new System.Exception("unimplemented idc");
    }

    public int QuotaAmount()
    {
        throw new System.Exception("unimplemented idc");
    }

    public int QuotaFulfilledAmount()
    {
        throw new System.Exception("unimplemented idc");
    }

    public int Funds()
    {
        throw new System.Exception("unimplemented idc");
    }
}