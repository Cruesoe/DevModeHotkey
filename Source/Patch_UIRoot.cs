using HarmonyLib;
using UnityEngine;
using Verse;

namespace DevModeHotkey;

/// <summary>
/// Hook the UI root instead of <see cref="Root.OnGUI"/>.
///
/// The original workshop mod postfixed <see cref="Root.OnGUI"/> and then called
/// <see cref="KeyBindingDef.KeyDownEvent"/> on every frame. During load,
/// <see cref="Root.OnGUI"/> draws the loading screen and returns before
/// <c>uiRoot.UIRootOnGUI()</c> runs, but Harmony still executes the postfix.
/// RimWorld 1.6's KeyDownEvent then reads <see cref="Find.WindowStack"/>, which
/// is null, and throws.
///
/// Patching <see cref="UIRoot.UIRootOnGUI"/> skips that window: it is not called
/// until the UI exists, and it still runs on the main menu and in-game.
/// </summary>
[HarmonyPatch(typeof(UIRoot), nameof(UIRoot.UIRootOnGUI))]
public static class Patch_UIRoot_UIRootOnGUI
{
    [HarmonyPostfix]
    public static void ToggleDevModeOnHotkey()
    {
        Event? ev = Event.current;
        if (ev is null || ev.type != EventType.KeyDown || ev.keyCode == KeyCode.None)
        {
            return;
        }

        KeyBindingDef? def = NCDMHK_KeyBindingDefOf.NCDMHK_DevelopmentModeToggle;
        if (def is null || KeyPrefs.KeyPrefsData?.keyPrefs is null || Find.WindowStack is null)
        {
            return;
        }

        if (def.KeyDownEvent)
        {
            Prefs.DevMode = !Prefs.DevMode;
        }
    }
}
