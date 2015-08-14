using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.ItemClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XXRpgLibrary.TileEngine;

namespace XXRpgLibrary.WorldClasses
{
    public class World : DrawableGameComponent
    {
        #region Graphical Fields and Properties

        public Rectangle ScreenRectangle
        {
            get;
            private set;
        }

        #endregion

        #region Item Fields and Properties

        ItemManager itemManager;

        #endregion

        #region Level Fields and Properties

        public List<Level> Levels
        {
            get;
            private set;
        }

        private int currentLevel = -1;
        public int CurrentLevel
        {
            get { return currentLevel; }
            set
            {
                if (value < 0 || value >= Levels.Count)
                    throw new IndexOutOfRangeException();

                if (Levels[value] == null)
                    throw new NullReferenceException();

                currentLevel = value;
            }
        }

        #endregion

        public World(Game game, Rectangle screenRectangle)
            : base(game)
        {
            ScreenRectangle = screenRectangle;

            Levels = new List<Level>();
            itemManager = new ItemManager();
        }

        #region Methods

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public void DrawLevel(SpriteBatch spriteBatch, Camera camera)
        {
            Levels[currentLevel].Draw(spriteBatch, camera);
        }

        #endregion
    }
}