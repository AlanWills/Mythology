using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XXRpgLibrary.TileEngine
{
    public class Tileset
    {
        #region Properties

        public Texture2D Texture
        {
            get;
            private set;
        }

        public int TileWidth
        {
            get;
            private set;
        }

        public int TileHeight
        {
            get;
            private set;
        }

        public int TilesWide
        {
            get;
            private set;
        }

        public int TilesHigh
        {
            get;
            private set;
        }

        Rectangle[] sourceRectangles;
        public Rectangle[] SourceRectangles
        {
            get { return (Rectangle[])sourceRectangles.Clone(); }
        }

        #endregion

        public Tileset(Texture2D image, int tilesWide, int tilesHigh, int tileWidth, int tileHeight)
        {
            Texture = image;
            TilesWide = tilesWide;
            TilesHigh = tilesHigh;
            TileWidth = tileWidth;
            TileHeight = tileHeight;

            int tiles = tilesWide * tilesHigh;
            sourceRectangles = new Rectangle[tiles];

            for (int y = 0; y < tilesHigh; y++)
            {
                for (int x = 0; x < tilesWide; x++)
                {
                    sourceRectangles[x + y * tilesWide] = new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight);
                }
            }
        }
    }
}
