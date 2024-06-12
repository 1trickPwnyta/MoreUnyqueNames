using HarmonyLib;
using Verse;

namespace MoreUnyqueNames
{
    public class MoreUnyqueNamesMod : Mod
    {
        public const string PACKAGE_ID = "moreunyquenames.1trickPwnyta";
        public const string PACKAGE_NAME = "More Unyque Names";

        public MoreUnyqueNamesMod(ModContentPack content) : base(content)
        {
            var harmony = new Harmony(PACKAGE_ID);
            harmony.PatchAll();

            Log.Message($"[{PACKAGE_NAME}] Loaded.");
        }
    }
}
