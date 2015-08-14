using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XXRpgLibrary.Controls
{
    public class Image : Control
    {
        #region Properties and Fields

        private Texture2D Texture;

        public Rectangle? SourceRectangle
        {
            get;
            set;
        }

        #endregion

        public Image(Texture2D texture)
            : base()
        {
            TabStop = false;
            Texture = texture;
            Size = new Vector2(texture.Width, texture.Height);
        }

        public Image(Texture2D texture, Vector2 position)
            : this(texture)
        {
            Position = position;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Texture != null)
            {
                spriteBatch.Draw(Texture, Position, SourceRectangle, Colour, 0, Size * 0.5f, new Vector2(1), SpriteEffects.None, 0);
            }
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            
        }
    }
}
