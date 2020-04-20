using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Game.Overlays.Settings;
using osu.Game.Rulesets.Sentakki.Configuration;

namespace osu.Game.Rulesets.Sentakki.UI
{
    public class SentakkiSettingsSubsection : RulesetSettingsSubsection
    {
        protected override string Header => "sentakki";

        public SentakkiSettingsSubsection(Ruleset ruleset)
            : base(ruleset)
        {
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            var config = (SentakkiRulesetConfigManager)Config;

            // for an odd reason, Config seems to be passed as null when creating it. doesnt even get called...
            if (config == null)
                return;

            Children = new Drawable[]
            {
                new SettingsCheckbox
                {
                    LabelText = "Use Sentakki style judgement text (In-game only)",
                    Bindable = config.GetBindable<bool>(SentakkiRulesetSettings.SentakkiJudgements)
                },
                new SettingsCheckbox
                {
                    LabelText = "Show Kiai effects",
                    Bindable = config.GetBindable<bool>(SentakkiRulesetSettings.KiaiEffects)
                },
                new SettingsCheckbox
                {
                    LabelText = "Show note start indicators",
                    Bindable = config.GetBindable<bool>(SentakkiRulesetSettings.ShowNoteStartIndicators)
                },
                new SettingsCheckbox
                {
                    LabelText = "Change ring color based on difficulty rating",
                    Bindable = config.GetBindable<bool>(SentakkiRulesetSettings.DiffBasedRingColor)
                },
                new SettingsSlider<double>
                {
                    LabelText = "Note entry animation duration",
                    Bindable = config.GetBindable<double>(SentakkiRulesetSettings.AnimationDuration)
                },
                new SettingsSlider<float>
                {
                    LabelText = "Ring Opacity",
                    Bindable = config.GetBindable<float>(SentakkiRulesetSettings.RingOpacity),
                    KeyboardStep = 0.01f,
                    DisplayAsPercentage = true
                },
            };
        }
    }
}
