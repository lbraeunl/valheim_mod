# ValheimMod

BepInEx 5 + HarmonyX mod for Valheim (Unity 6, Mono). Targets `net462` and is built with the .NET SDK (`dotnet build`).

- Game install: `C:\Program Files (x86)\Steam\steamapps\common\Valheim` (override in `Environment.props`).
- A build copies the DLL and PDB to `<Valheim>\BepInEx\plugins\ValheimMod\`. Runtime log: `<Valheim>\BepInEx\LogOutput.log`.
- `assembly_valheim` and `assembly_utils` are publicized at compile time, so private game members are directly accessible.
- Game code to patch lives in `assembly_valheim.dll`. To inspect it, decompile it with ILSpy/dnSpy (or look in `BepInEx\DumpedAssemblies`).
- Put patches in `src/ValheimMod/Patches/`, one file per patched game class. Respect `Plugin.ModEnabled` in patches.
- Other mods installed in the dev game (watch for conflicts): AzuAutoStore, AzuContainerSizes, AzuCraftyBoxes, AzuExtendedPlayerInventory, QuickStackStore, Magni, ConditionalConfigSync.
