using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using DistractedCompany.patch;
using DistractedCompany.service;
using MoonSharp.Interpreter;

namespace DistractedCompany;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static Plugin Instance { get; set; }

    public static ManualLogSource Log => Instance.Logger;

    private readonly Harmony _harmony = new(PluginInfo.PLUGIN_GUID);

    public TemplateService Service;

    public Plugin()
    {
        Instance = this;
    }

    private void Awake()
    {
        Service = new TemplateService();

        Log.LogInfo($"Registering userdata...");
        UserData.RegisterAssembly();
        Log.LogInfo($"UserData registered");

        Log.LogInfo($"Applying patches...");

        var env = new CCEnv();
        env.RunString(@"
            function assert_available(...)
                local path = {...}
                print('Checking availability of ' .. table.concat(path, '.'))
                local current = _G
                for i = 1, select('#', ...) do
                    local part = select(i, ...)
                    local nxt = current[part]
                    if not nxt then
                        error('could not find path part ' .. part .. ' in ' .. table.concat(path, '.'))
                    end
                    current = nxt
                end
            end

            assert_available('game')
            assert_available('game', 'players')
            assert_available('game', 'day')
            assert_available('game', 'next_company_day')
            assert_available('game', 'quota_amount')
            assert_available('game', 'quota_fulfilled_amount')
            assert_available('game', 'funds')
            assert_available('ship')
            assert_available('ship', 'monitor')
            assert_available('ship', 'monitor', 'view_map')
            assert_available('ship', 'monitor', 'turn')
            assert_available('ship', 'monitor', 'switch')
            assert_available('ship', 'monitor', 'current_player')
            assert_available('ship', 'monitor', 'players_on_screen')
            assert_available('ship', 'monitor', 'enemies_on_screen')
            assert_available('ship', 'terminal')
            assert_available('ship', 'terminal', 'commands')
            assert_available('ship', 'lights')
            assert_available('ship', 'lights', 'are_on')
            assert_available('ship', 'lights', 'turn')
            assert_available('ship', 'signal_translator')
            assert_available('ship', 'signal_translator', 'send')
            assert_available('ship', 'teleporter')
            assert_available('ship', 'teleporter', 'seconds_until_ready')
            assert_available('ship', 'teleporter', 'beam')
            assert_available('ship', 'inverse_teleporter')
            assert_available('ship', 'inverse_teleporter', 'seconds_until_ready')
            assert_available('ship', 'inverse_teleporter', 'beam')
            assert_available('ship', 'horn')
            assert_available('ship', 'horn', 'sound')
            assert_available('ship', 'transmit')
            assert_available('ship', 'eject')
        ");

        ApplyPluginPatch();
        Log.LogInfo($"Patches applied");
    }

    /// <summary>
    /// Applies the patch to the game.
    /// </summary>
    private void ApplyPluginPatch()
    {
        _harmony.PatchAll(typeof(ShipLightsPatch));
        _harmony.PatchAll(typeof(PlayerControllerBPatch));
        _harmony.PatchAll(typeof(TerminalOnSubmitPatch));
        _harmony.PatchAll(typeof(TerminalAwakePatch));
    }
}
