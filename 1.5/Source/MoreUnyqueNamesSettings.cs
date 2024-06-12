using UnityEngine;
using Verse;

namespace MoreUnyqueNames
{
    public class MoreUnyqueNamesSettings : ModSettings
    {
        public static float Chance = 0.1f;
        public static bool OverrideAllNames = false;
        public static bool OverrideSolidBio = false;

        public static void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);

            Chance = listingStandard.SliderLabeled("MoreUnyqueNames_Chance".Translate(Chance), Chance, 0f, 1f);
            listingStandard.CheckboxLabeled("MoreUnyqueNames_OverrideAllNames".Translate(), ref OverrideAllNames, "MoreUnyqueNames_OverrideAllNamesDesc".Translate());
            if (OverrideAllNames)
            {
                listingStandard.CheckboxLabeled("  " + "MoreUnyqueNames_OverrideSolidBio".Translate(), ref OverrideSolidBio, "MoreUnyqueNames_OverrideSolidBioDesc".Translate());
            }
            else
            {
                OverrideSolidBio = false;
            }

            listingStandard.End();
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref Chance, "Chance", 0.1f);
            Scribe_Values.Look(ref OverrideAllNames, "OverrideAllNames", false);
            Scribe_Values.Look(ref OverrideSolidBio, "OverrideSolidBio", false);
        }
    }
}
