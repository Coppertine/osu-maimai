using osu.Framework.Graphics.Sprites;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Sentakki.Objects;
using System.Collections.Generic;

namespace osu.Game.Rulesets.Sentakki.Beatmaps
{
    public class SentakkiBeatmap : Beatmap<SentakkiHitObject>
    {
        public override IEnumerable<BeatmapStatistic> GetStatistics()
        {
            int beats = HitObjects.Count;

            return new[]
            {
                new BeatmapStatistic
                {
                    Name = "Hit objects",
                    Content = beats.ToString(),
                    Icon = FontAwesome.Solid.Circle
                }
            };
        }
    }
}
