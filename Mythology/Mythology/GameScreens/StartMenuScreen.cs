using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XXRpgLibrary;
using XXRpgLibrary.Controls;

namespace Mythology.GameScreens
{
    public class StartMenuScreen : BaseScreen
    {
        PictureBox arrowImage;
        LinkLabel startGame;
        LinkLabel loadGame;
        LinkLabel exitGame;

        public StartMenuScreen(GameStateManager manager)
            : base(manager)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            AddBackground("Backgrounds\\MainMenu");

            arrowImage = new PictureBox(Content.Load<Texture2D>("GUI\\leftarrowUp"));
            ControlManager.Add(arrowImage);

            startGame = new LinkLabel("The Story Begins");
            startGame.Selected += menuItem_Selected;
            ControlManager.Add(startGame);

            loadGame = new LinkLabel("The Story Continues");
            loadGame.Selected += menuItem_Selected;
            ControlManager.Add(loadGame);

            exitGame = new LinkLabel("The Story Ends");
            exitGame.Selected += menuItem_Selected;
            ControlManager.Add(exitGame);

            ControlManager.NextControl();
            ControlManager.FocusChanged += ControlManager_FocusChanged;

            Vector2 position = new Vector2(350, 500);
            foreach (Control c in ControlManager)
            {
                if (c is LinkLabel)
                {
                    c.Position = position;
                    position.Y += c.Size.Y + 5f;
                }
            }

            ControlManager_FocusChanged(startGame, EventArgs.Empty);
        }

        void ControlManager_FocusChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Vector2 position = new Vector2(control.Position.X + control.Size.X * 0.5f + 20f, control.Position.Y);

            arrowImage.Position = position;
        }

        private void menuItem_Selected(object sender, EventArgs e)
        {
            if (sender == startGame)
            {
                Transition(new CharacterGeneratorScreen(StateManager), ChangeType.Push);
            }
            else if (sender == loadGame)
            {
                Transition(new LoadGameScreen(StateManager), ChangeType.Push);
            }
            else if (sender == exitGame)
            {
                Game.Exit();
            }
        }
    }
}
