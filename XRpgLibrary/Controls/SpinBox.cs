using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XXRpgLibrary.Controls
{
    public class SpinBox : Control
    {
        #region Events

        public event EventHandler SelectionChanged;

        #endregion

        #region Properties and Fields

        public Color SelectedColour
        {
            get;
            private set;
        }

        public int Increment
        {
            get;
            private set;
        }

        public int Width
        {
            get;
            private set;
        }

        private int minValue;
        public int MinimumValue
        {
            get { return minValue; }
            set
            {
                if (value > maxValue)
                    minValue = maxValue;
                else
                    minValue = value;
            }
        }

        private int maxValue;
        public int MaximumValue
        {
            get { return maxValue; }
            set
            {
                if (value < minValue)
                    maxValue = minValue;
                else
                    maxValue = value;
            }
        }

        private int current;
        public int CurrentValue
        {
            get { return current; }
            set { current = (int)MathHelper.Clamp(value, minValue, maxValue); }
        }

        Image leftArrow, rightArrow;
        Label valueLabel;

        #endregion

        public SpinBox(Texture2D leftTexture, Texture2D rightTexture)
            : base()
        {
            leftArrow = new Image(leftTexture);
            rightArrow = new Image(rightTexture);
            valueLabel = new Label(CurrentValue.ToString(), Position);

            Colour = Color.White;
            SelectedColour = Color.Red;

            minValue = 0;
            maxValue = 100;
            Increment = 1;
            Width = 50;

            TabStop = true;
        }

        public SpinBox(Texture2D leftTexture, Texture2D rightTexture, Vector2 position)
            : this(leftTexture, rightTexture)
        {
            Position = position;

            leftArrow.Position = new Vector2(position.X - Width * 0.5f, position.Y);
            rightArrow.Position = new Vector2(position.X + Width * 0.5f, position.Y);
        }

        #region Methods

        #endregion

        #region Virtual Methods

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (CurrentValue != MinimumValue)
                leftArrow.Draw(spriteBatch);

            if (CurrentValue != MaximumValue)
                rightArrow.Draw(spriteBatch);

            valueLabel.Draw(spriteBatch);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (InputHandler.ButtonReleased(Buttons.LeftThumbstickLeft, playerIndex) ||
                 InputHandler.ButtonReleased(Buttons.DPadLeft, playerIndex) ||
                 InputHandler.KeyReleased(Keys.Left))
            {
                CurrentValue -= Increment;
                if (CurrentValue < MinimumValue)
                    CurrentValue = MinimumValue;

                OnSelectionChanged();
            }

            if (InputHandler.ButtonReleased(Buttons.LeftThumbstickRight, playerIndex) ||
                InputHandler.ButtonReleased(Buttons.DPadRight, playerIndex) ||
                InputHandler.KeyReleased(Keys.Right))
            {
                CurrentValue += Increment;
                if (CurrentValue > MaximumValue)
                    CurrentValue = MaximumValue;

                OnSelectionChanged();
            }
        }

        protected virtual void OnSelectionChanged()
        {
            if (SelectionChanged != null)
                SelectionChanged(this, EventArgs.Empty);
        }

        #endregion
    }
}
