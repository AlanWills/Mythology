using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XXRpgLibrary.Controls
{
    public class PictureBox : Control
    {
        #region Properties

        public Texture2D Image
        {
            get;
            set;
        }

        public Rectangle SourceRectangle
        {
            get;
            private set;
        }

        public Rectangle DestinationRectangle
        {
            get {
                return new Rectangle(
                            (int)(Position.X - Scale.X * Image.Width * 0.5f),
                            (int)(Position.Y - Scale.Y * Image.Height * 0.5f),
                            (int)(Scale.X * Image.Width),
                            (int)(Scale.Y * Image.Height));
            }
        }

        private Vector2 Scale
        {
            get { return new Vector2(Size.X / (float)Image.Width, Size.Y / (float)Image.Height); }
        }

        #endregion

        public PictureBox(Texture2D image)
        {
            Image = image;
            SourceRectangle = new Rectangle(0, 0, image.Width, image.Height);
            Size = new Vector2(image.Width, image.Height);
            Colour = Color.White;
        }

        public PictureBox(Texture2D image, Vector2 position)
            : this(image)
        {
            Position = position;
        }

        public PictureBox(Texture2D image, Vector2 position, Vector2 size)
            : this(image)
        {
            Position = position;
            Size = size;
        }
        
        public PictureBox(Texture2D image, Vector2 position, Rectangle source)
            : this(image, position)
        {
            SourceRectangle = source;
        }

        public PictureBox(Texture2D image, Vector2 position, Vector2 size, Rectangle source)
            : this(image, position)
        {
            SourceRectangle = source;
            Size = size;
        }

        #region Abstract Method Region
        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Image != null)
            {
                spriteBatch.Draw(Image, DestinationRectangle, SourceRectangle, Colour, 0, Vector2.Zero, SpriteEffects.None, 0);
            }
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {

        }

        #endregion
    }
}
