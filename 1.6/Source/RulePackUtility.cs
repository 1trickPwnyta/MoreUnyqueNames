using Verse;

namespace MoreUnyqueNames
{
    public static class RulePackUtility
    {
        public static RulePackDef GetRulePack(Gender gender)
        {
            if (gender == Gender.Female)
            {
                return RulePackDef.Named("MoreUnyqueNames_Female");
            }
            else
            {
                return RulePackDef.Named("MoreUnyqueNames_Male");
            }
        }
    }
}
