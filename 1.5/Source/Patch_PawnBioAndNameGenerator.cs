using HarmonyLib;
using RimWorld;
using Verse;

namespace MoreUnyqueNames
{
    [HarmonyPatch(typeof(PawnBioAndNameGenerator))]
    [HarmonyPatch("GeneratePawnName_Shuffled")]
    public static class Patch_PawnBioAndNameGenerator_GeneratePawnName_Shuffled
    {
        public static void Postfix(PawnNameCategory nType, Gender gender, bool forceNoNick, ref NameTriple __result)
        {
            if (nType == PawnNameCategory.HumanStandard && !MoreUnyqueNamesSettings.OverrideAllNames && Rand.Chance(MoreUnyqueNamesSettings.Chance))
            {
                string firstName = NameGenerator.GenerateName(RulePackUtility.GetRulePack(gender));
                __result = new NameTriple(firstName, forceNoNick ? null : firstName, __result.Last);
            }
        }
    }

    [HarmonyPatch(typeof(PawnBioAndNameGenerator))]
    [HarmonyPatch(nameof(PawnBioAndNameGenerator.GenerateFullPawnName))]
    public static class Patch_PawnBioAndNameGenerator_GenerateFullPawnName
    {
        public static void Postfix(PawnNameCategory nameCategory, Gender gender, bool forceNoNick, ref Name __result)
        {
            if (nameCategory == PawnNameCategory.HumanStandard && MoreUnyqueNamesSettings.OverrideAllNames && Rand.Chance(MoreUnyqueNamesSettings.Chance))
            {
                string firstName = NameGenerator.GenerateName(RulePackUtility.GetRulePack(gender));
                if (__result is NameTriple)
                {
                    __result = new NameTriple(firstName, forceNoNick ? null : firstName, ((NameTriple)__result).Last);
                }
                else
                {
                    __result = new NameSingle(firstName);
                }
            }
        }
    }

    [HarmonyPatch(typeof(PawnBioAndNameGenerator))]
    [HarmonyPatch("TryGiveSolidBioTo")]
    public static class Patch_PawnBioAndNameGenerator_TryGiveSolidBioTo
    {
        public static void Postfix(Pawn pawn)
        {
            if (MoreUnyqueNamesSettings.OverrideAllNames && MoreUnyqueNamesSettings.OverrideSolidBio && Rand.Chance(MoreUnyqueNamesSettings.Chance))
            {
                string firstName = NameGenerator.GenerateName(RulePackUtility.GetRulePack(pawn.gender));
                if (pawn.Name is NameTriple)
                {
                    pawn.Name = new NameTriple(firstName, firstName, ((NameTriple)pawn.Name).Last);
                }
                else
                {
                    pawn.Name = new NameSingle(firstName);
                }
            }
        }
    }
}
