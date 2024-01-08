using BetterCore.Utils;
using System;
using TaleWorlds.Library;
using TaleWorlds.InputSystem;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace BetterBandages.Behaviors {
    public class Bandages : MissionBehavior {

        private static MissionTime bandageTime;
        private static MissionTime bleedInterval;
        private static MissionTime bleedDuration;

        private static bool activlyBandaging = false;
        private static bool isBleeding = false;

        private int bandageCount;

        public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

        public override void AfterStart() {
            base.AfterStart();
            bandageCount = BetterBandages.Settings.BandageAmount;
        }

        public override void OnMissionTick(float dt) {
            base.OnMissionTick(dt);
            try {
                //Check if we are in a mission
                if (Mission.Current != null && Mission.Current.MainAgent != null) {

                    if (activlyBandaging) {
                        if (IsMoving(Mission.Current.MainAgent.MovementVelocity)) {
                            NotifyHelper.ChatMessage(new TextObject("{=BC_qezRvY}Bandaging canceled due to movment!").ToString(), MsgType.Alert);
                            activlyBandaging = false;
                        }

                        if (bandageTime.IsPast) {
                            float healAmount = HealthHelper.GetMaxHealAmount(BetterBandages.Settings.BandageHealAmount, Mission.MainAgent);

                            Mission.Current.MainAgent.Health += healAmount;
                            bandageCount--;

                            if (isBleeding) {
                                isBleeding = false;
                                NotifyHelper.ChatMessage(new TextObject("{=BC_qezRvY}Bleeding removed.").ToString(), MsgType.Good);
                            }
                            activlyBandaging = false;

                            string text;
                            if (bandageCount < 2) {
                                text = new TextObject("{=BC_q2WCze}Bandage applied!") + bandageCount.ToString() + new TextObject("{=BC_YZj7gF}bandage left!");
                            } else {
                                text = new TextObject("{=BC_q2WCze}Bandage applied!") + bandageCount.ToString() + new TextObject("{=BC_YZj2gF}bandages left!");
                            }

                            NotifyHelper.ChatMessage(text, MsgType.Good);
                        }
                    }

                    if (Input.IsKeyPressed(BetterBandages.BandageKey)) {
                        UseBandage();
                    }

                    if (isBleeding && BetterBandages.Settings.BandageBleedEnabled) {
                        if (bleedInterval.IsPast) {
                            Mission.Current.MainAgent.Health -= (BetterBandages.Settings.BandageBleedDamagePercent * Mission.MainAgent.HealthLimit);

                            if (Mission.Current.MainAgent.Health < 0) {
                                Mission.Current.MainAgent.Die(new Blow());
                            }

                            bleedInterval = MissionTime.SecondsFromNow(BetterBandages.Settings.BandageBleedInterval);
                        }
                    }

                    if (bleedDuration.IsPast) {
                        isBleeding = false;
                    }
                }
            } catch (Exception e) {
                NotifyHelper.ReportError(BetterBandages.ModName, "Problem with bandages, cause: " + e);
            }
        }

        private static bool IsMoving(Vec2 velocity) {
            Vec2 vec = Vec2.Zero - new Vec2(1, 1);
            Vec2 vec2 = Vec2.Zero + new Vec2(1, 1);

            return velocity.x < vec.x || velocity.x > vec2.x || velocity.y < vec.y || velocity.y > vec2.y;
        }

        public void UseBandage() {
            if (!IsMoving(Mission.Current.MainAgent.MovementVelocity)) {
                if (bandageCount > 0) {
                    if (!activlyBandaging) {
                        if (Mission.Current.MainAgent.Health != Mission.Current.MainAgent.HealthLimit) {
                            bandageTime = MissionTime.SecondsFromNow(BetterBandages.Settings.BandageTime);
                            activlyBandaging = true;
                            NotifyHelper.ChatMessage(new TextObject("{=BC_RnoIZo}Applying bandage... It will take ") + BetterBandages.Settings.BandageTime.ToString() + new TextObject(" seconds."), MsgType.Good);
                        } else {
                            NotifyHelper.ChatMessage(new TextObject("{=BC_359Qlt}You're health is full. You have ") + bandageCount.ToString() + new TextObject(" bandages"), MsgType.Alert);
                        }
                    } else {
                        NotifyHelper.ChatMessage(new TextObject("{=BC_v3QHtG}You're already applying a bandage!").ToString(), MsgType.Alert);
                    }
                } else {
                    NotifyHelper.ChatMessage(new TextObject("{=BC_dU1uDF}Out of bandages!").ToString(), MsgType.Alert);
                }
            } else {
                NotifyHelper.ChatMessage(new TextObject("{=BC_CfS4GM}You can't bandage while moving!").ToString(), MsgType.Alert);
            }
        }

        public override void OnAgentHit(Agent affectedAgent, Agent affectorAgent, in MissionWeapon affectorWeapon, in Blow blow, in AttackCollisionData attackCollisionData) {
            base.OnAgentHit(affectedAgent, affectorAgent, affectorWeapon, blow, attackCollisionData);
            try {
                if (BetterBandages.Settings.BandageBleedEnabled) {
                    if (affectedAgent == null) {
                        return;
                    }

                    if (affectedAgent == Mission.MainAgent) {
                        //NotifyHelper.ChatMessage("Considering bleed", MsgType.Risk);
                        if (HealthHelper.GetHealthPercentage(affectedAgent) < BetterBandages.Settings.BandageBleedTiggerThreshold) {
                            if (MathHelper.RandomChance(BetterBandages.Settings.BandageBleedChance)) {
                                bleedInterval = MissionTime.SecondsFromNow(BetterBandages.Settings.BandageBleedInterval);
                                bleedDuration = MissionTime.SecondsFromNow(BetterBandages.Settings.BandageBleedDuration);
                                isBleeding = true;
                                NotifyHelper.ChatMessage("bleed applied", MsgType.Warning);
                            }
                        }
                    }
                }

            } catch (Exception e){
                NotifyHelper.ReportError(BetterBandages.ModName, "OnAgentHit threw exception " + e);
            }


        }
    }
}
