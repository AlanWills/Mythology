using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XXRpgLibrary.TileEngine
{
    public class Engine
    {
        #region Properties

        public static int TileWidth
        {
            get;
            private set;
        }

        public static int TileHeight
        {
            get;
            private set;
        }

        #endregion

        public Engine(int tileWidth, int tileHeight)
        {
            TileWidth = tileWidth;
            TileHeight = tileHeight;
        }

        public static Point VectorToCell(Vector2 position)
        {
            return new Point((int)position.X / TileWidth, (int)position.Y / TileHeight);
        }
    }
}
