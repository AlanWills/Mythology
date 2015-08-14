using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XXRpgLibrary.Controls
{
    public class LinkLabel : Control
    {
        #region Properties

        public Color SelectedColour
        {
            get;
            set;
        }

        #endregion

        #region Constructors

        public LinkLabel(string text)
            : base()
        {
            TabStop = true;
            Text = text;
            Size = SpriteFont.MeasureString(Text);
            SelectedColour = Color.Red;
        }

        public LinkLabel(string text, Vector2 position)
            : this(text)
        {
            Position = position;
        }

        public LinkLabel(string text, Color selectedColour)
            : this(text)
        {
            SelectedColour = selectedColour;
        }

        public LinkLabel(string text, Vector2 position, Color selectedColour)
            : this(text, position)
        {
            SelectedColour = selectedColour;
        }

        #endregion

        #region Abstract Methods

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (HasFocus)
                spriteBatch.DrawString(SpriteFont, Text, Position, SelectedColour, 0, SpriteFont.MeasureString(Text) / 2, new Vector2(1, 1), SpriteEffects.None, 0);
            else
                spriteBatch.DrawString(SpriteFont, Text, Position, Colour, 0, SpriteFont.MeasureString(Text) / 2, new Vector2(1, 1), SpriteEffects.None, 0);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (!HasFocus)
                return;

            if (InputHandler.KeyReleased(Keys.Enter) ||
                InputHandler.ButtonReleased(Buttons.A, playerIndex))
            {
                base.OnSelect(EventArgs.Empty);
            }
        }

        #endregion
    }
}
