using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XXRpgLibrary.TileEngine
{
    public class Tile
    {
        #region Properties

        public int TileIndex
        {
            get;
            private set;
        }

        public int Tileset
        {
            get;
            private set;
        }

        #endregion

        public Tile(int tileIndex, int tileset)
        {
            TileIndex = tileIndex;
            Tileset = tileset;
        }
    }
}
