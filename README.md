# ValheimMod

A BepInEx + Harmony mod for Valheim.

## Requirements

- [.NET SDK 8+](https://dotnet.microsoft.com/download) (only the SDK is needed to build; it compiles for .NET Framework 4.6.2)
- Valheim with [BepInEx 5](https://thunderstore.io/c/valheim/p/denikson/BepInExPack_Valheim/) installed

## Setup

The build assumes Valheim is at `C:\Program Files (x86)\Steam\steamapps\common\Valheim`.
If yours is elsewhere, copy `Environment.props.example` to `Environment.props` and set `ValheimPath`.

## Build

```powershell
dotnet build              # Debug build, auto-copied to <Valheim>\BepInEx\plugins\ValheimMod\
dotnet build -c Release
dotnet build -p:DeployToGame=false   # build without copying into the game
```

In VS Code, `Ctrl+Shift+B` runs the default build task.

Then launch Valheim and check `BepInEx\LogOutput.log` for `ValheimMod 0.1.0 loaded.`

## Layout

```
src/ValheimMod/
  Plugin.cs          BepInEx entry point: config, Harmony setup
  Patches/           Harmony patches, one file per patched game class
Directory.Build.props  shared paths (game dir, BepInEx dir)
```

## Notes

- `assembly_valheim` is referenced through BepInEx.AssemblyPublicizer, so private game fields and methods can be used directly in code without reflection.
- Rename the mod: change `AssemblyName`/`RootNamespace` in the `.csproj` and `PluginGuid`/`PluginName` in `Plugin.cs`.
