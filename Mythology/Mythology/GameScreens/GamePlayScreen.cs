using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XXRpgLibrary;
using XXRpgLibrary.SpriteClasses;
using XXRpgLibrary.TileEngine;
using XXRpgLibrary.WorldClasses;

namespace Mythology.GameScreens
{
    public class GamePlayScreen : BaseScreen
    {
        #region Properties and Fields

        public static World World
        {
            get;
            set;
        }

        public static Player Player
        {
            get;
            set;
        }

        #endregion

        public GamePlayScreen(GameStateManager manager)
            : base(manager)
        {
            StateManager.Camera.CameraMode = CameraMode.Free;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            World.Update(gameTime);
            Player.Update(gameTime);

            CheckForInput();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            World.DrawLevel(SpriteBatch, StateManager.Camera);
            Player.Draw(SpriteBatch);
        }

        #region Input Checks

        private void CheckForInput()
        {
            if (InputHandler.KeyReleased(Keys.F) ||
                InputHandler.ButtonReleased(Buttons.RightStick, PlayerIndex.One))
            {
                StateManager.Camera.ToggleCameraMode();
            }
            /*
            if (player.Camera.CameraMode != CameraMode.Follow)
            {
                if (InputHandler.KeyReleased(Keys.C) ||
                    InputHandler.ButtonReleased(Buttons.LeftStick, PlayerIndex.One))
                {
                    player.Camera.LockToSprite(sprite);
                }
            }*/
        }

        #endregion
    }
}
