using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.TileEngine;

namespace XXRpgLibrary.TileEngine
{
    public class TileMap
    {
        #region Properties

        private List<Tileset> Tilesets
        {
            get;
            set;
        }

        private List<ILayer> MapLayers
        {
            get;
            set;
        }

        static int mapWidth, mapHeight;

        public static int WidthInPixels
        {
            get { return mapWidth * Engine.TileWidth; }
        }

        public static int HeightInPixels
        {
            get { return mapHeight * Engine.TileHeight; }
        }

        #endregion

        public TileMap(List<Tileset> tilesets, MapLayer baseLayer, MapLayer buildingLayer, MapLayer splatterLayer)
        {
            Tilesets = tilesets;
            MapLayers = new List<ILayer>();

            MapLayers.Add(baseLayer);

            mapWidth = baseLayer.Width;
            mapHeight = baseLayer.Height;

            AddLayer(buildingLayer);
            AddLayer(splatterLayer);
        }

        public TileMap(Tileset tileSet, MapLayer baseLayer)
        {
            Tilesets = new List<Tileset>();
            Tilesets.Add(tileSet);

            MapLayers = new List<ILayer>();
            MapLayers.Add(baseLayer);

            mapWidth = baseLayer.Width;
            mapHeight = baseLayer.Height;
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            foreach (MapLayer layer in MapLayers)
            {
                layer.Draw(spriteBatch, camera, Tilesets);
            }
        }

        #region Methods

        public void AddLayer(ILayer layer)
        {
            MapLayer mapLayer = layer as MapLayer;

            if (mapLayer != null)
            {
                if (mapLayer.Width != mapWidth || mapLayer.Height != mapHeight)
                    throw new Exception("Map layer size exception");

                MapLayers.Add(layer);
            }
        }

        public void AddTileset(Tileset tileset)
        {
            Tilesets.Add(tileset);
        }

        public void Update(GameTime gameTime)
        {
            foreach (ILayer layer in MapLayers)
            {
                layer.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            foreach (MapLayer layer in MapLayers)
            {
                layer.Draw(spriteBatch, camera, Tilesets);
            }
        }

        #endregion
    }
}