using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace OuterRimGalacticEmpire
{
    public class OuterRimGalacticEmpireSettings : ModSettings
    {
        public bool enableInquisitors = true;
        public bool enableWookieeSlaves = true;

        public bool enableOccupation = true;
        public bool occupationFlyovers = true;
        public bool occupationBroadcasts = true;
        public bool occupationInspections = true;
        public bool occupationTaxes = true;
        public bool darthDolores = true;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref enableInquisitors, "enableInquisitors", true);
            Scribe_Values.Look(ref enableWookieeSlaves, "enableWookieeSlaves", true);

            Scribe_Values.Look(ref enableOccupation, "enableOccupation", true);
            Scribe_Values.Look(ref occupationFlyovers, "occupationFlyovers", true);
            Scribe_Values.Look(ref occupationBroadcasts, "occupationBroadcasts", true);
            Scribe_Values.Look(ref occupationInspections, "occupationInspections", true);
            Scribe_Values.Look(ref occupationTaxes, "occupationTaxes", true);
            Scribe_Values.Look(ref darthDolores, "darthDolores", true);
        }

        public bool IsValidSetting(string input)
        {
            if (GetType().GetFields().Where(p => p.FieldType == typeof(bool)).Any(i => i.Name == input))
            {
                return true;
            }

            return false;
        }

        public IEnumerable<string> GetEnabledSettings
        {
            get
            {
                return GetType().GetFields().Where(p => p.FieldType == typeof(bool) && (bool)p.GetValue(this)).Select(p => p.Name);
            }
        }
    }
}
