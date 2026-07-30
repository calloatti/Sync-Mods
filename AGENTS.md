Include ..\AGENTS.md

# Sync Mods — Mod-Specific Agent Instructions

## Identity
- **Assembly:** `syncmods`
- **Namespace:** `Calloatti.SyncMods`
- **ModId:** `calloatti.syncmods`
- **Framework:** Harmony, Bindito DI
- **Min Game Version:** 1.0.12.5 — uses `timberborn-decompiled-1.0.*`

## What This Mod Does
Syncs enabled mods with the currently loaded save game. Automatically enables/disables mods when loading a save to match the save's mod configuration.

## Source Architecture (`Version-1.0/Source/`)

| File | Role |
|---|---|
| `ModStarter.cs` | Entry point — `IModStarter` |
| `ModConfigurator.cs` | DI configurator |
| `ModUIStateController.cs` | UI state management |
| `SyncModsInternal.cs` | Core sync logic |
| `MainMenuPanelPatch.cs` | Main menu UI patches |
| `LoadGameBoxPatch.cs` | Load game dialog patches |
| `GameRestarter.cs` | Game restart utility for mod changes |
| `Calloatti.Util.cs` | Shared utility helpers |
| `LocHelper.cs` | Localization helper |
