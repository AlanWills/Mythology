﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.WorldClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.TileEngine;

namespace XXRpgLibrary.TileEngine
{
    public class MapLayer : ILayer
    {
        #region Properties

        private Tile[,] Map
        {
            get;
            set;
        }

        public int Width
        {
            get { return Map.GetLength(1); }
        }

        public int Height
        {
            get { return Map.GetLength(0); }
        }

        #endregion

        public MapLayer(Tile[,] map)
        {
            Map = (Tile[,])map.Clone();
        }

        public MapLayer(int width, int height)
        {
            Map = new Tile[height, width];
            
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Map[y, x] = new Tile(0, 0);
                }
            }
        }

        #region Methods

        public Tile GetTile(int x, int y)
        {
            return Map[y, x];
        }

        public void SetTile(int x, int y, Tile tile)
        {
            Map[y, x] = tile;
        }

        public void SetTile(int x, int y, int tileIndex, int tileset)
        {
            Map[y, x] = new Tile(tileIndex, tileset);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Camera camera, List<Tileset> tilesets)
        {
            float inverseZoom = (1 / camera.Zoom);
            Point cameraPoint = Engine.VectorToCell(camera.Position * inverseZoom);
            Point viewPoint = Engine.VectorToCell(
                new Vector2(
                    (camera.Position.X + camera.ViewportRectangle.Width) * inverseZoom,
                    (camera.Position.Y + camera.ViewportRectangle.Height) * inverseZoom));

            Point min = new Point(), max = new Point();

            min.X = Math.Max(0, cameraPoint.X - 1);
            min.Y = Math.Max(0, cameraPoint.Y - 1);
            max.X = Math.Min(viewPoint.X + 1, Width);
            max.Y = Math.Min(viewPoint.Y + 1, Height);

            Rectangle destination = new Rectangle(0, 0, Engine.TileWidth, Engine.TileHeight);
            Tile tile;

            for (int y = min.Y; y < max.Y; y++)
            {
                destination.Y = y * Engine.TileHeight;

                for (int x = min.X; x < max.X; x++)
                {
                    tile = GetTile(x, y);
                    if (tile.TileIndex == -1 || tile.Tileset == -1)
                        continue;

                    destination.X = x * Engine.TileWidth;

                    spriteBatch.Draw(
                        tilesets[tile.Tileset].Texture,
                        destination,
                        tilesets[tile.Tileset].SourceRectangles[tile.TileIndex],
                        Color.White);
                }
            }
        }

        public static MapLayer FromMapLayerData(MapLayerData data)
        {
            MapLayer layer = new MapLayer(data.Width, data.Height);

            for (int y = 0; y < data.Height; y++)
            {
                for (int x = 0; x < data.Width; x++)
                {
                    layer.SetTile(x, y, data.GetTile(x, y).TileIndex, data.GetTile(x, y).TileSetIndex);
                }
            }

            return layer;
        }

        #endregion
    }
}
