using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace ValheimMod
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInProcess("valheim.exe")]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "com.yourname.valheimmod";
        public const string PluginName = "ValheimMod";
        public const string PluginVersion = "0.1.0";

        internal static ManualLogSource Log;
        internal static ConfigEntry<bool> ModEnabled;

        private Harmony _harmony;

        private void Awake()
        {
            Log = Logger;

            ModEnabled = Config.Bind("General", "Enabled", true, "Enable or disable the mod.");

            _harmony = new Harmony(PluginGuid);
            _harmony.PatchAll(typeof(Plugin).Assembly);

            Log.LogInfo($"{PluginName} {PluginVersion} loaded.");
        }

        private void OnDestroy()
        {
            _harmony?.UnpatchSelf();
        }
    }
}
