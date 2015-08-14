using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XXRpgLibrary.Controls
{
    public abstract class Control
    {
        #region Events

        public event EventHandler Selected;

        #endregion

        #region Properties

        public string Name
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public Vector2 Size
        {
            get;
            set;
        }

        // Use an explicit variable so we can set individual components of the position vector
        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public object Value
        {
            get;
            set;
        }

        protected bool hasFocus;
        public virtual bool HasFocus
        {
            get { return hasFocus; }
            set { hasFocus = value; }
        }

        public bool Enabled
        {
            get;
            set;
        }

        public bool Visible
        {
            get;
            set;
        }

        public bool TabStop
        {
            get;
            set;
        }

        public SpriteFont SpriteFont
        {
            get;
            set;
        }

        public Color Colour
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        #endregion

        public Control()
        {
            Enabled = true;
            Visible = true;
            Colour = Color.White;
            SpriteFont = ControlManager.SpriteFont;
        }

        public Control(Vector2 position)
            : this()
        {
            Position = position;
        }

        #region Abstract Methods

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void HandleInput(PlayerIndex playerIndex);

        #endregion

        #region Virtual Methods

        protected virtual void OnSelect(EventArgs e)
        {
            if (Selected != null)
            {
                Selected(this, e);
            }
        }

        #endregion
    }
}
