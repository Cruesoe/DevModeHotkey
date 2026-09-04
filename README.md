# Dev Mode Hotkey

Steam Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=3782416970

Replacement for NightmareCorporation's [Development Mode Hotkey](https://steamcommunity.com/sharedfiles/filedetails/?id=3009274839). Same keypad-period toggle, without the RimWorld 1.6 loading-screen exception.

**Disable NightmareCorporation's original** before enabling this one. Do not run both.

## Install

Subscribe on Steam, or copy this folder to `RimWorld\Mods\`.

Default key: keypad period. Rebind under Options → Controls → Developer tools → Toggle Development Mode.

The original patches `Root.OnGUI`, which still runs during loading. Harmony postfixes run even after that method returns early, and RimWorld 1.6's `KeyDownEvent` then touches a null `Find.WindowStack`. This version patches `UIRoot.UIRootOnGUI` instead, which is not called until the UI exists.

## Build

```
dotnet build Source\DevModeHotkey.csproj
```

Output: `1.6\Assemblies\DevModeHotkey.dll`
