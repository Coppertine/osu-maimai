// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Rulesets.Replays;
using osuTK;
using System.Collections.Generic;

namespace osu.Game.Rulesets.Sentakki.Replays
{
    public class SentakkiReplayFrame : ReplayFrame
    {
        public ReplayEvent noteEvent = ReplayEvent.none;
        public Vector2 Position;
        public List<SentakkiAction> Actions = new List<SentakkiAction>();

        public SentakkiReplayFrame()
        {
        }

        public SentakkiReplayFrame(double time, Vector2 position, params SentakkiAction[] actions)
            : base(time)
        {
            Position = position;
            Actions.AddRange(actions);
        }
    }

    public enum ReplayEvent
    {
        none,
        TapDown,
        TapUp,
        TouchHoldDown,
        TouchHoldUp,
        HoldDown,
        HoldUp
    }
}
