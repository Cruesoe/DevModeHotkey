using HarmonyLib;
using Verse;

namespace DevModeHotkey
{
    [StaticConstructorOnStartup]
    public static class Startup
    {
        static Startup()
        {
            new Harmony("cruesoe.devmodehotkey").PatchAll();
        }
    }
}
