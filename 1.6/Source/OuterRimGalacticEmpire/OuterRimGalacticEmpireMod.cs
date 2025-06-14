using HarmonyLib;
using OuterRimCore;
using RimWorld;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace OuterRimGalacticEmpire
{
    public class OuterRimGalacticEmpireMod : Mod
    {
        public static OuterRimGalacticEmpireMod mod;
        public static OuterRimGalacticEmpireSettings settings;

        internal static string VersionDir => Path.Combine(mod.Content.ModMetaData.RootDir.FullName, "Version.txt");
        public static string CurrentVersion { get; private set; }

        public OuterRimGalacticEmpireMod(ModContentPack content) : base(content)
        {
            mod = this;
            settings = GetSettings<OuterRimGalacticEmpireSettings>();

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            CurrentVersion = $"{version.Major}.{version.Minor}.{version.Build}";

            LogUtil.LogMessage($"{CurrentVersion} ::");

            if (Prefs.DevMode)
            {
                File.WriteAllText(VersionDir, CurrentVersion);
            }

            Harmony OuterRimHarmony = new Harmony("Neronix17.OuterRim.GalacticEmpire");
            OuterRimHarmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public void DoOptionsCategoryContents(Listing_Standard listing)
        {
            //listing.GapLine();
            //listing.Note("Galactic Empire", GameFont.Medium);
            //listing.GapLine();
            //listing.CheckboxEnhanced("Enable Inquisitors", "If enabled, raids can sometimes have Inquisitors show up, equipped with lightsabers and able to use a handful of force powers.", ref settings.enableInquisitors);
            //listing.GapLine();
            //listing.CheckboxEnhanced("Enable Occupation", "If enabled, the Occupation system will be active, making the world feel much more like the Empire are actually oppressing the population rather than just being there like any other faction.", ref settings.enableOccupation);
            //if (settings.enableOccupation)
            //{
            //    listing.CheckboxLabeled("- Flyovers", ref settings.occupationFlyovers, "If enabled, the Empire will pass overhead occasionally as an event, if a pawn considered a Rebel is detected (part of the Rebel Alliance faction, wearing Rebellion gear, or part of your faction and hostile to the Empire) then the base will be bombarded by turbolaser blasts for a short time.");
            //    listing.CheckboxLabeled("- Broadcasts", ref settings.occupationBroadcasts, "If enabled, periodic broadcasts will be sent in the form of letters, if the occupation strength is above 50% when they're sent they will provide a morale boost to Imperial aligned player pawns, while Rebel aligned player pawns recieve a small debuff. If occupation strength is below 50% the effects will be inverted.");
            //    listing.CheckboxLabeled("- Inspections", ref settings.occupationInspections, "If enabled, random inspection events will occur for Imperial aligned players, Imperial Officers and a handful of troops will show up and patrol your colony, if they find any signs of you being a traitor, they'll promptly leave, the Empire will turn hostile and a large Imperial raid will show up. You can however kill them before they leave to prevent this, their deaths will not contribute to lowering goodwill like normal visits.");
            //    listing.CheckboxLabeled("- Tax Collection", ref settings.occupationTaxes, "If enabled, a periodic event will happen where an Imperial Officer and some Stormtroopers will show up to collect taxes, if you pay up they'll leave and occupation strength will increase slightly, if you refuse to pay up before they leave then your relations with the Empire will lower significantly.");
            //    listing.CheckboxLabeled("- Dolores from HR", ref settings.darthDolores, "If enabled, an Imperial HR worker named Dolores will appear occasionally to cite you for any ISHA violations in your colony.");
            //}
            //listing.GapLine();
            //if (ModLister.GetActiveModWithIdentifier("Neronix17.OuterRim.Kashyyyk") != null)
            //{
            //    listing.CheckboxLabeled("Enable Wookiee Slaves", ref settings.enableWookieeSlaves, "If enabled, Imperial settlements will typically include a handful of Wookiee slaves, and rare Imperial raids of Wookiee slaves equipped with shoddy ill fitting equipment will show up.");
            //    listing.GapLine();
            //}
        }
    }
}
