using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.CharacterClasses;
using XRpgLibrary.SkillClasses;
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
    public class CharacterGeneratorScreen : BaseScreen
    {
        #region Properties and Fields

        public string SelectedGender
        {
            get { return genderSelector.SelectedItem; }
        }

        public string SelectedClass
        {
            get { return classSelector.SelectedItem; }
        }

        LeftRightSelector genderSelector, classSelector;

        string[] genderItems = { "Male", "Female" };
        string[] classItems;

        PictureBox characterImage;
        Texture2D[,] characterImages;

        Point tileMapDims = new Point(100, 100);

        #endregion

        public CharacterGeneratorScreen(GameStateManager stateManager)
            : base(stateManager)
        {

        }

        protected override void LoadContent()
        {
            base.LoadContent();

            classItems = new string[DataManager.EntityData.Count];
            int counter = 0;

            foreach (string className in DataManager.EntityData.Keys)
            {
                classItems[counter] = className;
                counter++;
            }

            LoadImages();
            CreateControls();
        }

        #region Method Region

        private void LoadImages()
        {
            characterImages = new Texture2D[genderItems.Length, classItems.Length];

            for (int i = 0; i < genderItems.Length; i++)
            {
                for (int j = 0; j < classItems.Length; j++)
                {
                    characterImages[i, j] = Content.Load<Texture2D>("PlayerSprites\\" + genderItems[i] + classItems[j]);
                }
            }
        }

        private void CreateControls()
        {
            AddBackground("Backgrounds\\MainMenu");

            Label label = new Label("Select Character", new Vector2(StateManager.ScreenCentre.X, StateManager.ScreenCentre.Y / 2));
            ControlManager.Add(label);

            genderSelector = new LeftRightSelector(
                Content.Load<Texture2D>("GUI\\leftarrowUp"),
                Content.Load<Texture2D>("GUI\\rightarrowUp"),
                label.Position + new Vector2(0, StateManager.Viewport.Height / 6));
            genderSelector.SetItems(genderItems);
            genderSelector.SelectionChanged += selectionChanged;
            ControlManager.Add(genderSelector);

            classSelector = new LeftRightSelector(
                Content.Load<Texture2D>("GUI\\leftarrowUp"),
                Content.Load<Texture2D>("GUI\\rightarrowUp"),
                genderSelector.Position + new Vector2(0, StateManager.Viewport.Height / 6));
            classSelector.SetItems(classItems);
            classSelector.SelectionChanged += selectionChanged;
            ControlManager.Add(classSelector);

            LinkLabel acceptCharacter = new LinkLabel(
                "Accept this character.", 
                classSelector.Position + new Vector2(0, StateManager.Viewport.Height / 6));
            acceptCharacter.Selected += new EventHandler(acceptCharacter_Selected);
            ControlManager.Add(acceptCharacter);

            characterImage = new PictureBox(
                characterImages[0, 0],
                new Vector2(StateManager.Viewport.Width * 0.75f, genderSelector.Position.Y),
                new Rectangle(0, 0, 32, 32));
            characterImage.Size = new Vector2(64, 64);
            ControlManager.Add(characterImage);

            ControlManager.NextControl();
        }

        void selectionChanged(object sender, EventArgs e)
        {
            characterImage.Image = characterImages[genderSelector.SelectedIndex, classSelector.SelectedIndex];
        }

        private void acceptCharacter_Selected(object sender, EventArgs e)
        {
            InputHandler.Flush();

            CreatePlayer();
            CreateWorld();

            Transition(new SkillScreen(StateManager, 25), ChangeType.Change);
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
                characterImages[genderSelector.SelectedIndex, classSelector.SelectedIndex], 
                animations);

            Entity entity = new Entity("Encelwyn", DataManager.EntityData[SelectedClass], (EntityGender)Enum.Parse(typeof(EntityGender), SelectedGender), EntityType.Character);

            foreach (string s in DataManager.SkillData.Keys)
            {
                Skill skill = Skill.SkillFromSkillData(DataManager.SkillData[s]);
                entity.Skills.Add(s, skill);
            }

            GamePlayScreen.Player = new Player(new Character(entity, sprite));
        }

        private void CreateWorld()
        {
            Engine engine = new Engine(32, 32);
            List<Tileset> tilesets = new List<Tileset>();

            Tileset tileset1 = new Tileset(Content.Load<Texture2D>("Tilesets\\tileset1"), 8, 8, 32, 32);
            tilesets.Add(tileset1);

            Tileset tileset2 = new Tileset(Content.Load<Texture2D>("Tilesets\\tileset2"), 8, 8, 32, 32);
            tilesets.Add(tileset1);

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
