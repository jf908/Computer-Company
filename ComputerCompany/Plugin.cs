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

    double MoonSharpFactorial()
    {
        string script = @"    
		-- defines a factorial function
		function fact (n)
			if (n == 0) then
				return 1
			else
				return n*fact(n - 1)
			end
		end

	return fact(5)";

        DynValue res = Script.RunString(script);
        return res.Number;
    }

    private void Awake()
    {
        Service = new TemplateService();

        Log.LogInfo($"Applying patches...");
        Log.LogInfo($"Applying" + MoonSharpFactorial());
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
    }
}
