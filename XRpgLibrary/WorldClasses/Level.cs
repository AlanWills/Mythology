using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XXRpgLibrary.CharacterClasses;
using XXRpgLibrary.ItemClasses;
using XXRpgLibrary.TileEngine;

namespace XXRpgLibrary.WorldClasses
{
    public class Level
    {
        public TileMap Map
        {
            get;
            private set;
        }

        public List<Character> Characters
        {
            get;
            private set;
        }

        public List<ItemSprite> Chests
        {
            get;
            private set;
        }

        public Level(TileMap tileMap)
        {
            Map = tileMap;
            Characters = new List<Character>();
            Chests = new List<ItemSprite>();
        }

        public void Update(GameTime gameTime)
        {
            foreach (Character character in Characters)
                character.Update(gameTime);

            foreach (ItemSprite sprite in Chests)
                sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Map.Draw(spriteBatch, camera);

            foreach (Character character in Characters)
                character.Draw(spriteBatch);

            foreach (ItemSprite sprite in Chests)
                sprite.Draw(spriteBatch);
        }
    }
}
