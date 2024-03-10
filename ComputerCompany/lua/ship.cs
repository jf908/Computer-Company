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
    public CCSignalTranslator SignalTranslator { get; }
    public CCTeleporter Teleporter { get; }
    public CCTeleporter InverseTeleporter { get; }
    public CCHorn Horn { get; }

    public CCShip(CCTerminal terminal)
    {
        Terminal = terminal;

        Monitor = new CCMonitor();
        Lights = new CCLights();
        SignalTranslator = new CCSignalTranslator();
        Teleporter = new CCTeleporter(TeleporterKind.Normal);
        InverseTeleporter = new CCTeleporter(TeleporterKind.Inverse);
        Horn = new CCHorn();
    }

    public void Refresh()
    {
        Terminal.Refresh();
        Monitor.Refresh();
        Lights.Refresh();
        SignalTranslator.Refresh();
        Teleporter.Refresh();
        InverseTeleporter.Refresh();
        Horn.Refresh();
    }

    public void Transmit(string message)
    {
        // TODO: implement me!
    }

    public void Eject(string message)
    {
        // TODO: implement me!
        // TODO: check whether host allows this?
    }
}