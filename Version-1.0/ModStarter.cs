using Calloatti.Util;
using HarmonyLib;
using System;
using Timberborn.Modding; // Required for IModStarter and IModEnvironment
using Timberborn.ModManagerScene;
using UnityEngine;

namespace Calloatti.SyncMods
{
  // Extracted your Log class so it remains accessible everywhere
  public class Log
  {
    public static readonly string Prefix = "[SyncMods]";
    public static void Info(string message) => Debug.Log($"{Prefix} {message}");
  }

  public class ModStarter : IModStarter
  {
    private const string HarmonyId = "calloatti.SyncMods";

    // The master flag that our Configurators will check
    public static bool ShouldRun = true;

    public void StartMod(IModEnvironment environment)
    {
      // 1. The Stealth Check
      if (ModCheck.IsModEnabled("syncmodspro"))
      {
        ShouldRun = false;
        Log.Info("Sync Mods Pro detected. Soft-disabling to prevent conflicts.");
        return; // Play dead! Skip Harmony entirely.
      }

      // 2. Normal Boot
      Log.Info("Mod initialized");
      ApplyHarmonyPatches();
    }

    private void ApplyHarmonyPatches()
    {
      var harmonyInstance = new Harmony(HarmonyId);
      try
      {
        harmonyInstance.PatchAll();
        Log.Info("Harmony patches applied successfully.");
      }
      catch (Exception ex)
      {
        Log.Info($"Failed to apply harmony patches: {ex.Message}");
      }
    }
  }
}