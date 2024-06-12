using HarmonyLib;
using UnityEngine;
using Verse;

namespace MoreUnyqueNames
{
    public class MoreUnyqueNamesMod : Mod
    {
        public const string PACKAGE_ID = "moreunyquenames.1trickPwnyta";
        public const string PACKAGE_NAME = "More Unyque Names";

        public static MoreUnyqueNamesSettings Settings;

        public MoreUnyqueNamesMod(ModContentPack content) : base(content)
        {
            var harmony = new Harmony(PACKAGE_ID);
            harmony.PatchAll();

            Settings = GetSettings<MoreUnyqueNamesSettings>();

            Log.Message($"[{PACKAGE_NAME}] Loaded.");
        }

        public override string SettingsCategory() => PACKAGE_NAME;

        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            MoreUnyqueNamesSettings.DoSettingsWindowContents(inRect);
        }
    }
}
