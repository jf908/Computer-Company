using MoonSharp.Interpreter;

// ship.monitor            -- Monitor
// ship.console            -- Console
// ship.lights             -- Lights
// ship.signal_translator  -- nil | SignalTranslator
// ship.teleporter         -- nil | Teleporter
// ship.inverse_teleporter -- nil | Teleporter
// ship.horn               -- nil | Horn
// ship:transmit(message)  -- Transmit a message, e.g. k9
// ship:eject()            -- Ejects everyone, will need config option to disable by default! Will fail with message 'nice try, config says no' if not

[MoonSharpUserData]
public class CCShip
{
    public CCMonitor Monitor { get; }
    public CCTerminal Terminal { get; }
    public CCLights Lights { get; }
    private readonly CCSignalTranslator signalTranslator;
    public CCSignalTranslator SignalTranslator
    {
        get
        {
            return signalTranslator.IsAvailable() ? signalTranslator : null;
        }
    }
    private readonly CCTeleporter teleporter;
    public CCTeleporter Teleporter
    {
        get
        {
            return teleporter.IsAvailable() ? teleporter : null;
        }
    }
    private readonly CCTeleporter inverseTeleporter;
    public CCTeleporter InverseTeleporter
    {
        get
        {
            return inverseTeleporter.IsAvailable() ? inverseTeleporter : null;
        }
    }
    private readonly CCHorn horn;
    public CCHorn Horn
    {
        get
        {
            return horn.IsAvailable() ? horn : null;
        }
    }

    public CCShip(CCTerminal terminal)
    {
        Terminal = terminal;

        Monitor = new CCMonitor();
        Lights = new CCLights();
        signalTranslator = new CCSignalTranslator();
        teleporter = new CCTeleporter(TeleporterKind.Normal);
        inverseTeleporter = new CCTeleporter(TeleporterKind.Inverse);
        horn = new CCHorn();
    }

    public void Refresh()
    {
        Terminal.Refresh();
        Monitor.Refresh();
        Lights.Refresh();
        signalTranslator.Refresh();
        teleporter.Refresh();
        inverseTeleporter.Refresh();
        horn.Refresh();
    }

    // public void Transmit(string message)
    // {
    //     // TODO: implement me!
    // }

    public void Eject(string message)
    {
        // TODO: implement me!
        // if (base.IsServer && !StartOfRound.Instance.isChallengeFile && StartOfRound.Instance.inShipPhase && !StartOfRound.Instance.firingPlayersCutsceneRunning)
        // {
        //     StartOfRound.Instance.ManuallyEjectPlayersServerRpc();
        // }
    }
}