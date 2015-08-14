using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace XXRpgLibrary
{
    public class InputHandler : Microsoft.Xna.Framework.GameComponent
    {
        #region Property Region

        public static KeyboardState KeyboardState
        {
            get;
            private set;
        }

        public static KeyboardState PreviousKeyboardState
        {
            get;
            private set;
        }

        public static GamePadState[] GamePadStates
        {
            get;
            private set;
        }

        public static GamePadState[] PreviousGamePadStates
        {
            get;
            private set;
        }

        #endregion

        public InputHandler(Game game)
            : base(game)
        {
            KeyboardState = Keyboard.GetState();
            GamePadStates = new GamePadState[Enum.GetValues(typeof(PlayerIndex)).Length];

            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
                GamePadStates[(int)index] = GamePad.GetState(index);

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            PreviousKeyboardState = KeyboardState;
            KeyboardState = Keyboard.GetState();

            PreviousGamePadStates = (GamePadState[])GamePadStates.Clone();
            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
                GamePadStates[(int)index] = GamePad.GetState(index);

            base.Update(gameTime);
        }

        #region General Methods

        // Makes the KeyPressed and KeyReleased methods return false by setting the previous keyboardstate to the current keyboardstate
        public static void Flush()
        {
            PreviousKeyboardState = KeyboardState;
        }

        public static bool KeyReleased(Keys key)
        {
            return KeyboardState.IsKeyUp(key) && PreviousKeyboardState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return KeyboardState.IsKeyDown(key) && PreviousKeyboardState.IsKeyUp(key);
        }

        public static bool KeyDown(Keys key)
        {
            return KeyboardState.IsKeyDown(key);
        }

        public static bool ButtonReleased(Buttons button, PlayerIndex index)
        {
            return GamePadStates[(int)index].IsButtonUp(button) && PreviousGamePadStates[(int)index].IsButtonDown(button);
        }

        public static bool ButtonPressed(Buttons button, PlayerIndex index)
        {
            return GamePadStates[(int)index].IsButtonDown(button) && PreviousGamePadStates[(int)index].IsButtonUp(button);
        }

        public static bool ButtonDown(Buttons button, PlayerIndex index)
        {
            return GamePadStates[(int)index].IsButtonDown(button);
        }


        #endregion
    }
}
