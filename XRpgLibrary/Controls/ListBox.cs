using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XXRpgLibrary.Controls
{
    public class ListBox : Control
    {
        #region Events

        public event EventHandler SelectionChanged;
        public event EventHandler Enter;
        public event EventHandler Leave;

        #endregion

        #region Properties and Fields

        public List<string> Items
        {
            get;
            private set;
        }

        public Color SelectedColour
        {
            get;
            set;
        }

        private int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = (int)MathHelper.Clamp(value, 0f, Items.Count); }
        }

        public string SelectedItem
        {
            get { return Items[selectedIndex]; }
        }

        public override bool HasFocus
        {
            get { return hasFocus; }
            set
            {
                hasFocus = value;

                if (hasFocus)
                    OnEnter(EventArgs.Empty);
                else
                    OnLeave(EventArgs.Empty);
            }
        }

        Image background;
        Image cursor;

        int startItem;
        int lineCount;

        #endregion

        public ListBox(Texture2D backgroundTexture, Texture2D cursorTexture)
            : base()
        {
            HasFocus = false;
            TabStop = false;

            Items = new List<string>();

            background = new Image(backgroundTexture);
            cursor = new Image(cursorTexture);

            Size = new Vector2(backgroundTexture.Width, backgroundTexture.Height);

            lineCount = backgroundTexture.Height / SpriteFont.LineSpacing;
            Colour = Color.Black;
            SelectedColour = Color.Red;
        }

        public ListBox(Texture2D backgroundTexture, Texture2D cursorTexture, Vector2 position)
            : this(backgroundTexture, cursorTexture)
        {
            Position = position;

            background.Position = position;
            cursor.Position = new Vector2(background.Position.X - background.Size.X * 0.5f + 2, Position.Y - background.Size.Y * 0.5f + (SelectedIndex - startItem + 0.5f) * SpriteFont.LineSpacing);
        }

        #region Abstract Methods

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);

            for (int i = 0; i < lineCount; i++)
            {
                if (startItem + i >= Items.Count)
                    break;

                if (startItem + i == selectedIndex)
                {
                    spriteBatch.DrawString(
                        SpriteFont,
                        Items[startItem + i],
                        new Vector2(Position.X, Position.Y + (i + 0.5f) * SpriteFont.LineSpacing - background.Size.Y * 0.5f),
                        SelectedColour,
                        0,
                        ControlManager.SpriteFont.MeasureString(Items[startItem + i]) * 0.5f,
                        1,
                        SpriteEffects.None,
                        0);

                    cursor.Draw(spriteBatch);
                }
                else
                {
                    spriteBatch.DrawString(
                        SpriteFont,
                        Items[startItem + i],
                        new Vector2(Position.X, Position.Y + (i + 0.5f) * SpriteFont.LineSpacing - background.Size.Y * 0.5f),
                        Colour,
                        0,
                        ControlManager.SpriteFont.MeasureString(Items[startItem + i]) * 0.5f,
                        1,
                        SpriteEffects.None,
                        0);
                }
            }
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (!HasFocus)
                return;

            if (InputHandler.KeyReleased(Keys.Down) ||
                InputHandler.ButtonReleased(Buttons.LeftThumbstickDown, playerIndex))
            {
                if (SelectedIndex < Items.Count - 1)
                {
                    SelectedIndex++;
                    if (SelectedIndex >= startItem + lineCount)
                        startItem = SelectedIndex - lineCount + 1;

                    OnSelectionChanged(EventArgs.Empty);
                }
            }
            else if (InputHandler.KeyReleased(Keys.Up) ||
                InputHandler.ButtonReleased(Buttons.LeftThumbstickUp, playerIndex))
            {
                if (SelectedIndex > 0)
                {
                    SelectedIndex--;
                    if (SelectedIndex < startItem)
                        startItem = SelectedIndex;

                    OnSelectionChanged(EventArgs.Empty);
                }
            }

            if (InputHandler.KeyReleased(Keys.Enter) ||
                InputHandler.ButtonReleased(Buttons.A, playerIndex))
            {
                HasFocus = false;
                OnSelect(EventArgs.Empty);
            }

            if (InputHandler.KeyReleased(Keys.Escape) ||
                InputHandler.ButtonReleased(Buttons.B, playerIndex))
            {
                HasFocus = false;
            }
        }

        #endregion

        #region Methods

        protected virtual void OnSelectionChanged(EventArgs e)
        {
            cursor.Position = new Vector2(background.Position.X - background.Size.X * 0.5f + 5, Position.Y - background.Size.Y * 0.5f + (SelectedIndex - startItem + 0.5f) * SpriteFont.LineSpacing);

            if (SelectionChanged != null)
                SelectionChanged(this, e);
        }

        protected virtual void OnEnter(EventArgs e)
        {
            if (Enter != null)
                Enter(this, e);
        }

        protected virtual void OnLeave(EventArgs e)
        {
            if (Leave != null)
                Leave(this, e);
        }

        #endregion
    }
}
