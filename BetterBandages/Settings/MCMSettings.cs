using BetterBandages.Localization;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v1;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BetterBandages.Settings {

    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {


        [SettingPropertyGroup(RefValues.BandageText)]
        [SettingPropertyInteger(RefValues.BandageAmountText, 1, 100, "0 " + RefValues.BandageText, Order = 0, RequireRestart = false, HintText = RefValues.BandageAmountHint)]
        public int BandageAmount { get; set; } = 3;

        [SettingPropertyGroup(RefValues.BandageText)]
        [SettingPropertyFloatingInteger(RefValues.BandageHealthText, 1f, 1000f, "0.0 HP", Order = 0, RequireRestart = false, HintText = RefValues.BandageHealthHint)]
        public float BandageHealAmount { get; set; } = 10;

        [SettingPropertyGroup(RefValues.BandageText)]
        [SettingPropertyFloatingInteger(RefValues.BandageTimeText, 0f, 60f, "0.0 " + RefValues.SecondsText, Order = 0, RequireRestart = false, HintText = RefValues.BandageTimeHint)]
        public float BandageTime { get; set; } = 3;

        [SettingPropertyGroup(RefValues.BandageText)]
        [SettingProperty(RefValues.BandageKeyText, Order = 0, RequireRestart = true, HintText = RefValues.BandageKeyHint)]
        public string BandageKey { get; set; } = "B";

        [SettingPropertyGroup(RefValues.BandageText + "/" + RefValues.BleedText)]
        [SettingPropertyBool(RefValues.EnableBleedText, IsToggle = true, Order = 0, RequireRestart = false, HintText = RefValues.EnableBleedHint)]
        public bool BandageBleedEnabled { get; set; } = false;

        [SettingPropertyGroup(RefValues.BandageText + "/" + RefValues.BleedText)]
        [SettingPropertyFloatingInteger(RefValues.MinBleedText, 0.01f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = RefValues.MinBleedHint)]
        public float BandageBleedTiggerThreshold { get; set; } = .2f;

        [SettingPropertyGroup(RefValues.BandageText + "/" + RefValues.BleedText)]
        [SettingPropertyFloatingInteger(RefValues.BleedChanceText, 0.01f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = RefValues.BleedChanceHint)]
        public float BandageBleedChance { get; set; } = .2f;

        [SettingPropertyGroup(RefValues.BandageText + "/" + RefValues.BleedText)]
        [SettingPropertyFloatingInteger(RefValues.BleedDamageText, 0.01f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = RefValues.BleedDamageHint)]
        public float BandageBleedDamagePercent { get; set; } = .05f;

        [SettingPropertyGroup(RefValues.BandageText + "/" + RefValues.BleedText)]
        [SettingPropertyInteger(RefValues.BleedIntervalText, 1, 120, "0 " + RefValues.SecondsText, Order = 0, RequireRestart = false, HintText = RefValues.BleedIntervalHint)]
        public int BandageBleedInterval { get; set; } = 5;

        [SettingPropertyGroup(RefValues.BandageText + "/" + RefValues.BleedText)]
        [SettingPropertyInteger(RefValues.BleedDurationText, 1, 300, "0 " + RefValues.SecondsText, Order = 0, RequireRestart = false, HintText = RefValues.BleedDurationHint)]
        public int BandageBleedDuration { get; set; } = 60;



        [SettingPropertyGroup(RefValues.BandageText + "/" + RefValues.BleedText + "/" + RefValues.StackingText)]
        [SettingPropertyBool(RefValues.BleedStackText, IsToggle = true, Order = 0, RequireRestart = false, HintText = RefValues.BleedStackHint)]
        public bool BandageBleedStackEnabled { get; set; } = false;

        [SettingPropertyGroup(RefValues.BandageText + "/" + RefValues.BleedText + "/" + RefValues.StackingText)]
        [SettingPropertyInteger(RefValues.MaxStackText, 1, 100, "0 " + RefValues.StacksText, Order = 0, RequireRestart = false, HintText = RefValues.MaxStackHint)]
        public int BandageBleedStackSize { get; set; } = 3;

        [SettingPropertyGroup(RefValues.BandageText + "/" + RefValues.BleedText + "/" + RefValues.StackingText)]
        [SettingPropertyBool(RefValues.ClearStackText, Order = 0, RequireRestart = false, HintText = RefValues.ClearStackHint)]
        public bool BandageClearsBleedStack { get; set; } = false;


        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FolderName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
        public bool LoadMCMConfigFile { get; set; } = true;
    }
}
