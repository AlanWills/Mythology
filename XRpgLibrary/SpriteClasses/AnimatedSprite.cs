using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XXRpgLibrary.TileEngine;

namespace XXRpgLibrary.SpriteClasses
{
    public class AnimatedSprite
    {
        #region Properties and Fields

        public AnimationKey CurrentAnimation
        {
            get;
            set;
        }

        public bool IsAnimating
        {
            get;
            set;
        }

        public int Width
        {
            get { return animations[CurrentAnimation].FrameWidth; }
        }

        public int Height
        {
            get { return animations[CurrentAnimation].FrameHeight; }
        }

        private float speed = 200.0f;
        public float Speed
        {
            get { return speed; }
            set { speed = MathHelper.Clamp(speed, 1.0f, 400.0f); }
        }

        // We use an explicit variable here so we can set individual components of the position
        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        private Vector2 velocity;
        public Vector2 Velocity
        {
            get { return velocity; }
            set
            {
                velocity = value;
                if (velocity != Vector2.Zero)
                    velocity.Normalize();
            }
        }

        Dictionary<AnimationKey, Animation> animations;
        Texture2D texture;

        #endregion

        public AnimatedSprite(Texture2D sprite, Dictionary<AnimationKey, Animation> animation)
        {
            texture = sprite;
            animations = new Dictionary<AnimationKey, Animation>();

            foreach (AnimationKey animationKey in animation.Keys)
            {
                animations.Add(animationKey, (Animation)animation[animationKey].Clone());
            }
        }

        #region Methods

        public void Update(GameTime gameTime)
        {
            if (IsAnimating)
                animations[CurrentAnimation].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animations[CurrentAnimation].CurrentFrameRectangle, Color.White);
        }

        public void LockToMap()
        {
            position.X = MathHelper.Clamp(position.X, Width * 0.5f, TileMap.WidthInPixels - Width * 0.5f);
            position.Y = MathHelper.Clamp(position.Y, Height * 0.5f, TileMap.HeightInPixels - Height * 0.5f);
        }

        #endregion
    }
}
