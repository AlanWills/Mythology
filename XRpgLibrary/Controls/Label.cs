using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XXRpgLibrary.Controls
{
    public class Label : Control
    {
        #region Properties and Fields

        public Color SelectedColour
        {
            get;
            set;
        }

        #endregion

        public Label(string text)
            : base()
        {
            TabStop = false;
            Text = text;
            Size = SpriteFont.MeasureString(Text);
            SelectedColour = Color.Red;
        }

        public Label(string text, Vector2 position)
            : this(text)
        {
            Position = position;
        }

        public Label(string text, Color selectedColour)
            : this(text)
        {
            SelectedColour = selectedColour;
        }

        public Label(string text, Vector2 position, Color selectedColour)
            : this(text, position)
        {
            SelectedColour = selectedColour;
        }

        #region Abstract Methods

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (HasFocus)
                spriteBatch.DrawString(SpriteFont, Text, Position, SelectedColour, 0, SpriteFont.MeasureString(Text) * 0.5f, new Vector2(1, 1), SpriteEffects.None, 0);
            else
                spriteBatch.DrawString(SpriteFont, Text, Position, Colour, 0, SpriteFont.MeasureString(Text) * 0.5f, new Vector2(1, 1), SpriteEffects.None, 0);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            
        }

        #endregion
    }
}
