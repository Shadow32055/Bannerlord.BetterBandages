using BetterBandages.Localization;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v1;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BetterBandages.Settings {

    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {


        [SettingPropertyGroup(RefValues.BandageText)]
        [SettingPropertyInteger("{=BC_WI3k5M}Number of Bandages", 1, 100, "0 {=BC_wj2XMD}Bandages", Order = 0, RequireRestart = false, HintText = "{=BC_AuTuGq}Number of bandages for use each mission")]
        public int BandageAmount { get; set; } = 3;

        [SettingPropertyGroup(RefValues.BandageText)]
        [SettingPropertyFloatingInteger("{=BC_kKKj82}Health Per Bandage", 1f, 1000f, "0.0 HP", Order = 0, RequireRestart = false, HintText = "{=BC_Z7T6KB}How much health each bandage applies")]
        public float BandageHealAmount { get; set; } = 10;

        [SettingPropertyGroup(RefValues.BandageText)]
        [SettingPropertyFloatingInteger("{=BC_L2llEt}Bandage Time", 0f, 60f, "0.0 {=BC_mIjl1T}Seconds", Order = 0, RequireRestart = false, HintText = "{=BC_IdToPT}How long it takes to bandage, can't move during this time")]
        public float BandageTime { get; set; } = 3;

        [SettingPropertyGroup(RefValues.BandageText)]
        [SettingProperty("{=BC_MfXZnQ}Bandage Key", Order = 0, RequireRestart = true, HintText = "{=BC_19RaR4}What key to use for Bandages. Examples 'Q', 'Numpad0'")]
        public string BandageKey { get; set; } = "B";

        [SettingPropertyGroup(RefValues.BandageText + "/Bleed Effect")]
        [SettingPropertyBool("{=BC_licHNP}Bleed Effect", IsToggle = true, Order = 0, RequireRestart = false, HintText = "{=BC_xACH0R}SHould bleeding be possible")]
        public bool BandageBleedEnabled { get; set; } = false;

        [SettingPropertyGroup(RefValues.BandageText + "/Bleed Effect")]
        [SettingPropertyFloatingInteger("{=BC_L2llEt}Lowest Health Percent for Bleed Effect", 0.01f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = "{=BC_IdToPT}How long it takes to bandage, can't move during this time")]
        public float BandageBleedTiggerThreshold { get; set; } = .2f;

        [SettingPropertyGroup(RefValues.BandageText + "/Bleed Effect")]
        [SettingPropertyFloatingInteger("{=BC_L2llEt}Bleed Chance", 0.01f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = "{=BC_IdToPT}How long it takes to bandage, can't move during this time")]
        public float BandageBleedChance { get; set; } = .2f;

        [SettingPropertyGroup(RefValues.BandageText + "/Bleed Effect")]
        [SettingPropertyFloatingInteger("{=BC_L2llEt}Bleed Damage", 0.01f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = "{=BC_IdToPT}How long it takes to bandage, can't move during this time")]
        public float BandageBleedDamagePercent { get; set; } = .05f;

        [SettingPropertyGroup(RefValues.BandageText + "/Bleed Effect")]
        [SettingPropertyInteger("{=BC_L2llEt}Bleed Interval", 1, 120, "0.0 {=BC_mIjl1T}Seconds", Order = 0, RequireRestart = false, HintText = "{=BC_IdToPT}How long it takes to bandage, can't move during this time")]
        public int BandageBleedInterval { get; set; } = 5;

        [SettingPropertyGroup(RefValues.BandageText + "/Bleed Effect")]
        [SettingPropertyInteger("{=BC_L2llEt}Bleed Duration", 1, 300, "0.0 {=BC_mIjl1T}Seconds", Order = 0, RequireRestart = false, HintText = "{=BC_IdToPT}How long it takes to bandage, can't move during this time")]
        public int BandageBleedDuration { get; set; } = 60;


        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FolderName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
        public bool LoadMCMConfigFile { get; set; } = true;
    }
}
