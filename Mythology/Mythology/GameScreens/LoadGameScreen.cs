using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XXRpgLibrary;
using XXRpgLibrary.CharacterClasses;
using XXRpgLibrary.Controls;
using XXRpgLibrary.SpriteClasses;
using XXRpgLibrary.TileEngine;
using XXRpgLibrary.WorldClasses;

namespace Mythology.GameScreens
{
    public class LoadGameScreen : BaseScreen
    {
        #region Properties and Fields

        ListBox loadListBox;
        LinkLabel loadLinkLabel, exitLinkLabel;

        Point tileMapDims = new Point(100, 100);

        #endregion

        public LoadGameScreen(GameStateManager stateManager)
            : base(stateManager)
        {

        }

        #region Methods

        protected override void LoadContent()
        {
            base.LoadContent();

            AddBackground("Backgrounds\\MainMenu");

            loadLinkLabel = new LinkLabel("Select game", new Vector2(Viewport.Width * 0.25f, Viewport.Height * 0.5f - ControlManager.SpriteFont.LineSpacing));
            loadLinkLabel.Selected += new EventHandler(loadLinkLabel_Selected);
            ControlManager.Add(loadLinkLabel);

            exitLinkLabel = new LinkLabel("Back", new Vector2(loadLinkLabel.Position.X, loadLinkLabel.Position.Y + 2 * loadLinkLabel.SpriteFont.LineSpacing));
            exitLinkLabel.Selected += new EventHandler(exitLinkLabel_Selected);
            ControlManager.Add(exitLinkLabel);

            loadListBox = new ListBox(Content.Load<Texture2D>("GUI\\listBoxImage"), Content.Load<Texture2D>("GUI\\rightarrowUp"), new Vector2(Viewport.Width * 0.5f, Viewport.Height * 0.5f));
            loadListBox.Selected += new EventHandler(loadListBox_Selected);
            loadListBox.Leave += new EventHandler(loadListBox_Leave);

            for (int i = 0; i < 20; i++)
                loadListBox.Items.Add("Game number: " + i.ToString());
            ControlManager.Add(loadListBox);

            ControlManager.NextControl();
        }

        #endregion

        #region Methods

        void loadListBox_Leave(object sender, EventArgs e)
        {
            ControlManager.AcceptInput = true;
        }

        void loadLinkLabel_Selected(object sender, EventArgs e)
        {
            ControlManager.AcceptInput = false;
            loadLinkLabel.HasFocus = false;
            loadListBox.HasFocus = true;

            InputHandler.Flush();
        }

        void loadListBox_Selected(object sender, EventArgs e)
        {
            loadLinkLabel.HasFocus = true;
            loadListBox.HasFocus = false;
            ControlManager.AcceptInput = true;

            Transition(new GamePlayScreen(StateManager), ChangeType.Change);
            CreatePlayer();
            CreateWorld();
        }

        void exitLinkLabel_Selected(object sender, EventArgs e)
        {
            Transition(null, ChangeType.Pop);
        }

        private void CreatePlayer()
        {
            Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();

            Animation animation = new Animation(3, 32, 32, 0, 0);
            animations.Add(AnimationKey.Down, animation);

            animation = new Animation(3, 32, 32, 0, 32);
            animations.Add(AnimationKey.Left, animation);

            animation = new Animation(3, 32, 32, 0, 64);
            animations.Add(AnimationKey.Right, animation);

            animation = new Animation(3, 32, 32, 0, 96);
            animations.Add(AnimationKey.Up, animation);

            AnimatedSprite sprite = new AnimatedSprite(
                Content.Load<Texture2D>("PlayerSprites\\malefighter"), 
                animations);

            Entity entity = new Entity("Encelwyn", DataManager.EntityData["Fighter"], EntityGender.Male, EntityType.Character);
            GamePlayScreen.Player = new Player(new Character(entity, sprite));
        }

        private void CreateWorld()
        {
            Engine engine = new Engine(32, 32);
            List<Tileset> tilesets = new List<Tileset>();

            Tileset tileset1 = new Tileset(Content.Load<Texture2D>("Tilesets\\tileset1"), 8, 8, 32, 32);
            tilesets.Add(tileset1);

            Tileset tileset2 = new Tileset(Content.Load<Texture2D>("Tilesets\\tileset2"), 8, 8, 32, 32);
            tilesets.Add(tileset2);

            MapLayer layer = new MapLayer(tileMapDims.X, tileMapDims.Y);
            for (int y = 0; y < layer.Height; y++)
            {
                for (int x = 0; x < layer.Width; x++)
                {
                    Tile tile = new Tile(0, 0);
                    layer.SetTile(x, y, tile);
                }
            }

            MapLayer environment = new MapLayer(tileMapDims.X, tileMapDims.Y);
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(0, tileMapDims.X);
                int y = random.Next(0, tileMapDims.Y);
                int index = random.Next(2, 14);

                Tile tile = new Tile(index, 0);
                environment.SetTile(x, y, tile);
            }

            environment.SetTile(1, 0, new Tile(0, 1));
            environment.SetTile(2, 0, new Tile(2, 1));
            environment.SetTile(3, 0, new Tile(0, 1));

            TileMap map = new TileMap(tileset1, layer);
            map.AddTileset(tileset2);
            map.AddLayer(environment);

            Level level = new Level(map);

            World world = new World(Game, Viewport.Bounds);
            world.Levels.Add(level);
            world.CurrentLevel = 0;

            GamePlayScreen.World = world;
        }

        #endregion
    }
}
