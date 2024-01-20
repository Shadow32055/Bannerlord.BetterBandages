using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v1;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BetterBandages.Settings {

    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {

        [SettingPropertyGroup(Strings.BandageText)]
        [SettingPropertyInteger(Strings.BandageAmountText, 1, 100, "0 " + Strings.BandageText, Order = 0, RequireRestart = false, HintText = Strings.BandageAmountHint)]
        public int BandageAmount { get; set; } = 3;

        [SettingPropertyGroup(Strings.BandageText)]
        [SettingPropertyFloatingInteger(Strings.BandageHealthText, 1f, 1000f, "0.0 HP", Order = 0, RequireRestart = false, HintText = Strings.BandageHealthHint)]
        public float BandageHealAmount { get; set; } = 10;

        [SettingPropertyGroup(Strings.BandageText)]
        [SettingPropertyFloatingInteger(Strings.BandageTimeText, 0f, 60f, "0.0 " + Strings.SecondsText, Order = 0, RequireRestart = false, HintText = Strings.BandageTimeHint)]
        public float BandageTime { get; set; } = 3;

        [SettingPropertyGroup(Strings.BandageText)]
        [SettingProperty(Strings.BandageKeyText, Order = 0, RequireRestart = true, HintText = Strings.BandageKeyHint)]
        public string BandageKey { get; set; } = "B";

        [SettingPropertyGroup(Strings.BandageText + "/" + Strings.BleedText)]
        [SettingPropertyBool(Strings.EnableBleedText, IsToggle = true, Order = 0, RequireRestart = false, HintText = Strings.EnableBleedHint)]
        public bool BandageBleedEnabled { get; set; } = false;

        [SettingPropertyGroup(Strings.BandageText + "/" + Strings.BleedText)]
        [SettingPropertyFloatingInteger(Strings.MinBleedText, 0.01f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = Strings.MinBleedHint)]
        public float BandageBleedTiggerThreshold { get; set; } = .2f;

        [SettingPropertyGroup(Strings.BandageText + "/" + Strings.BleedText)]
        [SettingPropertyFloatingInteger(Strings.BleedChanceText, 0.01f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = Strings.BleedChanceHint)]
        public float BandageBleedChance { get; set; } = .2f;

        [SettingPropertyGroup(Strings.BandageText + "/" + Strings.BleedText)]
        [SettingPropertyFloatingInteger(Strings.BleedDamageText, 0.01f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = Strings.BleedDamageHint)]
        public float BandageBleedDamagePercent { get; set; } = .05f;

        [SettingPropertyGroup(Strings.BandageText + "/" + Strings.BleedText)]
        [SettingPropertyInteger(Strings.BleedIntervalText, 1, 120, "0 " + Strings.SecondsText, Order = 0, RequireRestart = false, HintText = Strings.BleedIntervalHint)]
        public int BandageBleedInterval { get; set; } = 5;

        [SettingPropertyGroup(Strings.BandageText + "/" + Strings.BleedText)]
        [SettingPropertyInteger(Strings.BleedDurationText, 1, 300, "0 " + Strings.SecondsText, Order = 0, RequireRestart = false, HintText = Strings.BleedDurationHint)]
        public int BandageBleedDuration { get; set; } = 60;



        [SettingPropertyGroup(Strings.BandageText + "/" + Strings.BleedText + "/" + Strings.StackingText)]
        [SettingPropertyBool(Strings.BleedStackText, IsToggle = true, Order = 0, RequireRestart = false, HintText = Strings.BleedStackHint)]
        public bool BandageBleedStackEnabled { get; set; } = false;

        [SettingPropertyGroup(Strings.BandageText + "/" + Strings.BleedText + "/" + Strings.StackingText)]
        [SettingPropertyInteger(Strings.MaxStackText, 1, 100, "0 " + Strings.StacksText, Order = 0, RequireRestart = false, HintText = Strings.MaxStackHint)]
        public int BandageBleedStackSize { get; set; } = 3;

        [SettingPropertyGroup(Strings.BandageText + "/" + Strings.BleedText + "/" + Strings.StackingText)]
        [SettingPropertyBool(Strings.ClearStackText, Order = 0, RequireRestart = false, HintText = Strings.ClearStackHint)]
        public bool BandageClearsBleedStack { get; set; } = false;


        [SettingPropertyGroup(Strings.BandageText + "/" + Strings.MedicalSkillText)]
        [SettingPropertyBool(Strings.MedicalSkillEnableText, IsToggle = true, Order = 0, RequireRestart = false, HintText = Strings.MedicalSkillEnabledHint)]
        public bool ExtraBandages { get; set; } = false;

        [SettingPropertyGroup(Strings.BandageText + "/" + Strings.MedicalSkillText)]
        [SettingPropertyInteger(Strings.MedicalAmountText, 1, 100, "0 " + Strings.PerBandageText, Order = 0, RequireRestart = false, HintText = Strings.MedicalAmountHint)]
        public int ExtraBandagesSP { get; set; } = 10;


        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FolderName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
        public bool LoadMCMConfigFile { get; set; } = true;
    }
}
