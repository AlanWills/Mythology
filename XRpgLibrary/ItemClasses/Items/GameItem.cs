using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.ItemClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XXRpgLibrary.Controls;

namespace XXRpgLibrary.ItemClasses
{
    public class GameItem
    {
        #region Properties and Fields

        public Image Image
        {
            get;
            private set;
        }

        public Rectangle? SourceRectangle
        {
            get;
            set;
        }

        public BaseItem Item
        {
            get;
            private set;
        }

        public Type Type
        {
            get;
            private set;
        }

        #endregion

        public GameItem(BaseItem item, Texture2D texture, Rectangle? sourceRectangle)
        {
            Item = item;
            Image = new Image(texture);
            Image.SourceRectangle = sourceRectangle;

            Type = item.GetType();
        }

        #region Methods

        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }

        #endregion

        #region Virtual Methods

        #endregion
    }
}
