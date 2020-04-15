// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Extensions.Color4Extensions;
using osu.Game.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Maimai.UI.Components
{
    public class ColorBlastPiece : CircularContainer
    {
        private readonly Sprite color;

        public ColorBlastPiece()
        {
            Masking = true;
            FillAspectRatio = 1;
            FillMode = FillMode.Fit;
            RelativeSizeAxes = Axes.Both;
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Children = new Drawable[]
            {
                color = new Sprite
                {
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = Vector2.Zero,
                },
            };
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            color.Texture = textures.Get("TestColorBlast3");
        }

        protected override void LoadComplete()
        {
            this.Spin(20000, RotationDirection.Clockwise).Loop();
        }

        public void Blast()
        {
            color.FinishTransforms();
            color.ScaleTo(1, 400, Easing.OutCubic).Then().FadeOut(800).Then().ScaleTo(0).FadeIn();
        }
    }
}
