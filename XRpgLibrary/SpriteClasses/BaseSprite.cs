using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XXRpgLibrary.TileEngine;

namespace XXRpgLibrary.SpriteClasses
{
    public class BaseSprite
    {
        #region Properties and Fields

        public int Width
        {
            get { return sourceRectangle.Width; }
        }

        public int Height
        {
            get { return sourceRectangle.Height; }
        }

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)(Position.X - Width * 0.5f), (int)(Position.Y - Height * 0.5f), Width, Height);
            }
        }

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
                if (Velocity != Vector2.Zero)
                    velocity.Normalize();
            }
        }

        private float speed = 2.0f;
        public float Speed
        {
            get { return speed; }
            set { speed = MathHelper.Clamp(speed, 1.0f, 16.0f); }
        }

        protected Texture2D texture;
        protected Rectangle sourceRectangle;

        #endregion

        public BaseSprite(Texture2D image, Rectangle? sourceRectangle)
        {
            texture = image;

            if (sourceRectangle.HasValue)
                this.sourceRectangle = sourceRectangle.Value;
            else
                this.sourceRectangle = new Rectangle(0, 0, Width, Height);
        }

        public BaseSprite(Texture2D image, Point tile, Rectangle? sourceRectangle)
            : this(image, sourceRectangle)
        {
            Position = new Vector2(tile.X * Engine.TileWidth, tile.Y * Engine.TileHeight);
        }

        #region Methods

        #endregion

        #region Virtual Methods

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, sourceRectangle, Color.White, 0, new Vector2(Width, Height) * 0.5f, new Vector2(1), SpriteEffects.None, 0);
        }

        #endregion
    }
}
