using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XXRpgLibrary.ItemClasses
{
    public class GameItemManager : Manager<GameItem>
    {
        #region Properties and Fields

        public static SpriteFont SpriteFont
        {
            get;
            private set;
        }

        #endregion

        public GameItemManager(SpriteFont spriteFont)
        {
            SpriteFont = spriteFont;
        }

        #region Methods

        #endregion

        #region Virtual Methods

        #endregion
    }
}
