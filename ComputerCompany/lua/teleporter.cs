using System;
using System.Data;
using MoonSharp.Interpreter;

// teleporter:seconds_until_ready()
// teleporter:beam() -- () -> error, where error can be 'not ready' or nil

[MoonSharpUserData]
public class CCTeleporter
{
    private TeleporterKind kind { get; }

    public CCTeleporter(TeleporterKind kind)
    {
        this.kind = kind;
    }

    public void Refresh() { }

    public bool IsAvailable()
    {
        // TODO: complete me!
        return true;
    }

    public int SecondsUntilReady()
    {
        // TODO: complete me!
        return -1;
    }

    public void Beam()
    {
        switch (kind)
        {
            case TeleporterKind.Normal:
                // TODO: complete me!
                break;
            case TeleporterKind.Inverse:
                // TODO: complete me!
                break;
        }
    }
}

public enum TeleporterKind
{
    Normal,
    Inverse
}