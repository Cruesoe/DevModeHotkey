using RimWorld;
using Verse;

namespace DevModeHotkey
{
    [DefOf]
    public static class NCDMHK_KeyBindingDefOf
    {
        public static KeyBindingDef NCDMHK_DevelopmentModeToggle = null!;

        static NCDMHK_KeyBindingDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(NCDMHK_KeyBindingDefOf));
        }
    }
}
