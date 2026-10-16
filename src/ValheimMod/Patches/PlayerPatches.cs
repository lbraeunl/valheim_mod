using HarmonyLib;

namespace ValheimMod.Patches
{
    // Example patch: logs once when the local player spawns. Replace with real mod logic.
    [HarmonyPatch(typeof(Player), nameof(Player.OnSpawned))]
    internal static class PlayerOnSpawnedPatch
    {
        private static void Postfix(Player __instance)
        {
            if (!Plugin.ModEnabled.Value || __instance != Player.m_localPlayer)
                return;

            Plugin.Log.LogInfo($"Local player spawned: {__instance.GetPlayerName()}");
        }
    }
}
