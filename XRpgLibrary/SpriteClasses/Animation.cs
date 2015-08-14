using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XXRpgLibrary.SpriteClasses
{
    public enum AnimationKey { Down, Left, Right, Up }

    public class Animation
    {
        #region Properties and Fields

        private int framesPerSecond;
        public int FramesPerSecond
        {
            get { return framesPerSecond; }
            set
            {
                if (value < 1)
                    framesPerSecond = 1;
                else if (value > 60)
                    framesPerSecond = 60;
                else
                    framesPerSecond = value;

                frameLength = TimeSpan.FromSeconds(1 / (double)framesPerSecond);
            }
        }

        private int currentFrame;
        public int CurrentFrame
        {
            get { return currentFrame; }
            set
            {
                currentFrame = (int)MathHelper.Clamp(currentFrame, 0, frames.Length - 1);
            }
        }

        public Rectangle CurrentFrameRectangle
        {
            get { return frames[currentFrame]; }
        }

        public int FrameWidth
        {
            get;
            private set;
        }

        public int FrameHeight
        {
            get;
            private set;
        }

        Rectangle[] frames;
        TimeSpan frameLength, frameTimer;

        #endregion

        public Animation(int frameCount, int frameWidth, int frameHeight, int xOffset, int yOffset)
        {
            frames = new Rectangle[frameCount];
            FrameWidth = frameWidth;
            FrameHeight = frameHeight;

            for (int i = 0; i < frameCount; i++)
            {
                frames[i] = new Rectangle(
                    xOffset + (frameWidth * i),
                    yOffset,
                    frameWidth,
                    frameHeight);
            }

            FramesPerSecond = 5;
            Reset();
        }

        private Animation(Animation animation)
        {
            frames = animation.frames;
            FramesPerSecond = 5;
        }

        #region Methods

        public void Update(GameTime gameTime)
        {
            frameTimer += gameTime.ElapsedGameTime;

            if (frameTimer >= frameLength)
            {
                frameTimer = TimeSpan.Zero;
                currentFrame = (currentFrame + 1) % frames.Length;
            }
        }

        public void Reset()
        {
            frameTimer = TimeSpan.Zero;
            currentFrame = 0;
        }

        public object Clone()
        {
            Animation animationClone = new Animation(this);

            animationClone.FrameWidth = FrameWidth;
            animationClone.FrameHeight = FrameHeight;
            animationClone.Reset();

            return animationClone;
        }

        #endregion
    }
}
