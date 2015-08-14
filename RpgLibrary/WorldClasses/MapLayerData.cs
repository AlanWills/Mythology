using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.WorldClasses
{
    public struct Tile
    {
        public int TileIndex;
        public int TileSetIndex;

        public Tile(int tileIndex, int tileSetIndex)
        {
            TileIndex = tileIndex;
            TileSetIndex = tileSetIndex;
        }
    }

    public class MapLayerData
    {
        public string MapLayerName;
        public int Width;
        public int Height;
        public Tile[] Layer;

        private MapLayerData()
        {

        }

        public MapLayerData(string mapLayerName, int width, int height)
        {
            MapLayerName = mapLayerName;
            Width = width;
            Height = height;

            Layer = new Tile[Height * width];
        }

        // Fills the map with a tile from a tileset
        public MapLayerData(string mapLayerName, int width, int height, int tileIndex, int tileSet)
            : this(mapLayerName, width, height)
        {
            Tile tile = new Tile(tileIndex, tileSet);

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    SetTile(x, y, tile);
                }
            }
        }

        public void SetTile(int x, int y, Tile tile)
        {
            Layer[y * Width + x] = tile;
        }

        public void SetTile(int x, int y, int tileIndex, int tileSetIndex)
        {
            Layer[y * Width + x] = new Tile(tileIndex, tileSetIndex);
        }

        public Tile GetTile(int x, int y)
        {
            return Layer[y * Width + x];
        }
    }
}
