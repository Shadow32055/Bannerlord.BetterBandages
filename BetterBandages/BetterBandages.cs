using BetterBandages.Behaviors;
using BetterBandages.Settings;
using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;

namespace BetterBandages {
    public class BetterBandages : MBSubModuleBase {

        public static MCMSettings Settings { get; private set; }
        public static MissionBehavior Bandages { get; private set; } = new Bandages();
        public static string ModName { get; private set; } = "BetterBandages";

        public static InputKey BandageKey { get; private set; } = InputKey.B;

        private bool isInitialized = false;
        private bool isLoaded = false;

        //FIRST
        protected override void OnSubModuleLoad() {
            try {
                base.OnSubModuleLoad();

               if (isInitialized)
                    return;

                Harmony h = new("Bannerlord.Shadow." + ModName);

                h.PatchAll();

                isInitialized = true;
            } catch (Exception e) {
                NotifyHelper.WriteError(ModName, "OnSubModuleLoad threw exception " + e);
            }
        }

        //SECOND
        protected override void OnBeforeInitialModuleScreenSetAsRoot() {
            try {
                base.OnBeforeInitialModuleScreenSetAsRoot();

                if (isLoaded)
                    return;

                ModName = base.GetType().Assembly.GetName().Name;

                Settings = MCMSettings.Instance ?? throw new NullReferenceException("Settings are null");
                RegisterBandageKey();

                NotifyHelper.WriteMessage(ModName + " Loaded.", MsgType.Good);
                Integrations.BetterBandagesLoaded = true;

                isLoaded = true;
            } catch (Exception e) {
                NotifyHelper.WriteError(ModName, "OnBeforeInitialModuleScreenSetAsRoot threw exception " + e);
            }
        }

        public override void OnMissionBehaviorInitialize(Mission mission) {
            base.OnMissionBehaviorInitialize(mission);
            try {
                mission.AddMissionBehavior(new Bandages());
            } catch (Exception e) {
                NotifyHelper.WriteError(ModName, "OnMissionBehaviorInitialize threw exception " + e);
            }
        }

        public static void RegisterBandageKey() {
            try {
                if (Enum.IsDefined(typeof(InputKey), Settings.BandageKey)) {
                    BandageKey = (InputKey)Enum.Parse(typeof(InputKey), Settings.BandageKey);
                    //DisplayWarningMsg("Key: " + settings.CallKey);
                } else {
                    throw new Exception();
                }
            } catch (Exception e) {
                NotifyHelper.WriteError(ModName, "Issue registering bandage key. '" + Settings.BandageKey + "' is not a valid key. Using deafult 'Q' key. Exception " + e);
            }
        }
    }
}
