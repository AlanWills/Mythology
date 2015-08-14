using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XXRpgLibrary.Controls
{
    public class LeftRightSelector : Control
    {
        #region Events

        public event EventHandler SelectionChanged;

        #endregion

        #region Properties and Fields

        public Color SelectedColour
        {
            get;
            set;
        }

        public List<string> Items
        {
            get;
            private set;
        }

        public int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = (int)MathHelper.Clamp(selectedIndex, 0f, Items.Count); }
        }

        public string SelectedItem
        {
            get { return Items[selectedIndex]; }
        }

        float maxItemWidth;
        Image leftImage, rightImage;
        Label textLabel;

        #endregion

        public LeftRightSelector(Texture2D leftArrow, Texture2D rightArrow)
            : base()
        {
            leftImage = new Image(leftArrow);
            rightImage = new Image(rightArrow);
            TabStop = true;
            Colour = Color.White;
            SelectedColour = Color.Red;
            Items = new List<string>();

            SetUpLabel();
        }

        public LeftRightSelector(Texture2D leftArrow, Texture2D rightArrow, Vector2 position)
            : this(leftArrow, rightArrow)
        {
            Position = position;

            SetUpLabel();
        }

        #region Methods

        private void SetUpLabel()
        {
            textLabel = new Label("", Position);
        }

        public void SetItems(string[] items)
        {
            Items.Clear();

            foreach (string s in items)
            {
                Items.Add(s);

                if (SpriteFont != null)
                {
                    if (SpriteFont.MeasureString(s).X > maxItemWidth)
                        maxItemWidth = SpriteFont.MeasureString(s).X;
                }
            }

            if (Items.Count > 0)
            {
                textLabel.Text = Items[0];
                leftImage.Position = Position - new Vector2(maxItemWidth * 0.5f + 10, 0);
                rightImage.Position = Position + new Vector2(maxItemWidth * 0.5f + 10, 0);
            }
        }

        public void SetItems(string[] items, int maxWidth)
        {
            SetItems(items);

            maxItemWidth = maxWidth;
        }

        protected void OnSelectionChanged()
        {
            if (Items.Count > 0)
                textLabel.Text = SelectedItem;

            if (SelectionChanged != null)
            {
                SelectionChanged(this, null);
            }
        }

        #endregion

        #region

        public override void Update(GameTime gameTime)
        {
            textLabel.HasFocus = HasFocus;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 drawTo = Position - new Vector2(maxItemWidth * 0.5f + 10f, 0);

            if (selectedIndex != 0)
                leftImage.Draw(spriteBatch);
            
            textLabel.Draw(spriteBatch);

            drawTo.X += maxItemWidth + 20f;

            if (selectedIndex != Items.Count - 1)
                rightImage.Draw(spriteBatch);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (Items.Count == 0)
                return;

            if (InputHandler.ButtonReleased(Buttons.LeftThumbstickLeft, playerIndex) ||
                InputHandler.ButtonReleased(Buttons.DPadLeft, playerIndex) ||
                InputHandler.KeyReleased(Keys.Left))
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = 0;

                OnSelectionChanged();
            }

            if (InputHandler.ButtonReleased(Buttons.LeftThumbstickRight, playerIndex) ||
                InputHandler.ButtonReleased(Buttons.DPadRight, playerIndex) ||
                InputHandler.KeyReleased(Keys.Right))
            {
                selectedIndex++;
                if (selectedIndex >= Items.Count)
                    selectedIndex = Items.Count - 1;

                OnSelectionChanged();
            }
        }

        #endregion
    }
}
