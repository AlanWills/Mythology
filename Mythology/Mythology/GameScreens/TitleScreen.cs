using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XXRpgLibrary;
using XXRpgLibrary.Controls;

namespace Mythology.GameScreens
{
    public class TitleScreen : BaseScreen
    {
        public TitleScreen(GameStateManager manager)
            : base(manager)
        {

        }

        protected override void LoadContent()
        {
            base.LoadContent();

            AddBackground("Backgrounds\\MainMenu");

            LinkLabel startLabel = new LinkLabel("Press ENTER to begin", new Vector2(350, 500));
            startLabel.Selected += new EventHandler(startLabel_selected);

            ControlManager.Add(startLabel);
            ControlManager.NextControl();
        }

        #region Title Screen Events

        private void startLabel_selected(object sender, EventArgs e)
        {
            Transition(new StartMenuScreen(StateManager), ChangeType.Push);
        }

        #endregion
    }
}
