using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.ItemClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XXRpgLibrary.SpriteClasses;

namespace XXRpgLibrary.ItemClasses
{
    public class ItemSprite
    {
        #region Properties and Fields

        public BaseSprite Sprite
        {
            get;
            private set;
        }

        public BaseItem Item
        {
            get;
            private set;
        }

        #endregion

        public ItemSprite(BaseItem item, BaseSprite sprite)
        {
            Item = item;
            Sprite = sprite;
        }

        #region Methods

        #endregion

        #region Virtual Methods

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        #endregion
    }
}
