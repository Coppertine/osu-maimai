﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Extensions.IEnumerableExtensions;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Sentakki.Objects;
using osu.Game.Rulesets.Sentakki.UI;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Types;
using osuTK;
using osuTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace osu.Game.Rulesets.Sentakki.Beatmaps
{
    public class SentakkiBeatmapConverter : BeatmapConverter<SentakkiHitObject>
    {
        // todo: Check for conversion types that should be supported (ie. Beatmap.HitObjects.Any(h => h is IHasXPosition))
        // https://github.com/ppy/osu/tree/master/osu.Game/Rulesets/Objects/Types
        public override bool CanConvert() => Beatmap.HitObjects.All(h => h is IHasPosition);

        public SentakkiBeatmapConverter(IBeatmap beatmap, Ruleset ruleset)
            : base(beatmap, ruleset)
        {
        }

        protected override IEnumerable<SentakkiHitObject> ConvertHitObject(HitObject original, IBeatmap beatmap)
        {
            Vector2 CENTRE_POINT = new Vector2(256, 192);
            Vector2 newPos = (original as IHasPosition)?.Position ?? Vector2.Zero;
            newPos.Y = 384 - newPos.Y;
            float angle = Utils.GetNotePathFromDegrees(Utils.GetDegreesFromPosition(newPos, CENTRE_POINT));

            switch (original)
            {
                case IHasCurve curveData:
                    return new Hold
                    {
                        NoteColor = Color4.Crimson,
                        Angle = Utils.GetNotePathFromDegrees(Utils.GetDegreesFromPosition(newPos, CENTRE_POINT)),
                        NodeSamples = curveData.NodeSamples,
                        StartTime = original.StartTime,
                        EndTime = original.GetEndTime(),
                        endPosition = new Vector2(-(SentakkiPlayfield.IntersectDistance * (float)Math.Cos((angle + 90f) * (float)(Math.PI / 180))), -(SentakkiPlayfield.IntersectDistance * (float)Math.Sin((angle + 90f) * (float)(Math.PI / 180)))),
                        Position = new Vector2(-(SentakkiPlayfield.NoteStartDistance * (float)Math.Cos((angle + 90f) * (float)(Math.PI / 180))), -(SentakkiPlayfield.NoteStartDistance * (float)Math.Sin((angle + 90f) * (float)(Math.PI / 180)))),
                    }.Yield();

                case IHasEndTime endTimeData:
                    return new TouchHold
                    {
                        Position = Vector2.Zero,
                        StartTime = original.StartTime,
                        EndTime = endTimeData.EndTime,
                    }.Yield();

                default:
                    return new Tap
                    {
                        NoteColor = Color4.Orange,
                        Angle = Utils.GetNotePathFromDegrees(Utils.GetDegreesFromPosition(newPos, CENTRE_POINT)),
                        Samples = original.Samples,
                        StartTime = original.StartTime,
                        endPosition = new Vector2(-(SentakkiPlayfield.IntersectDistance * (float)Math.Cos((angle + 90f) * (float)(Math.PI / 180))), -(SentakkiPlayfield.IntersectDistance * (float)Math.Sin((angle + 90f) * (float)(Math.PI / 180)))),
                        Position = new Vector2(-(SentakkiPlayfield.NoteStartDistance * (float)Math.Cos((angle + 90f) * (float)(Math.PI / 180))), -(SentakkiPlayfield.NoteStartDistance * (float)Math.Sin((angle + 90f) * (float)(Math.PI / 180)))),
                    }.Yield();
            }
        }
    }
}
