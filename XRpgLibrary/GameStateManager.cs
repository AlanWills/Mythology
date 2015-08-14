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
using XXRpgLibrary.TileEngine;
using XXRpgLibrary;


namespace XXRpgLibrary
{
    public enum ChangeType { Change, Pop, Push }

    public class GameStateManager : GameComponent
    {
        #region Events

        public event EventHandler OnStateChange;

        #endregion

        #region Properties and Fields

        private Stack<GameState> GameStates
        {
            get;
            set;
        }

        public Viewport Viewport
        {
            get;
            private set;
        }

        public SpriteBatch SpriteBatch
        {
            get;
            set;
        }

        public Camera Camera
        {
            get;
            private set;
        }

        public ContentManager Content
        {
            get { return Game.Content; }
        }

        public Vector2 ScreenCentre
        {
            get { return new Vector2(Viewport.Width, Viewport.Height) / 2; }
        }

        public GameState CurrentState
        {
            get { return GameStates.Peek(); }
        }

        const int startDrawOrder = 5000;
        const int drawOrderInc = 100;
        int drawOrder;

        #endregion

        public GameStateManager(Game game, Viewport viewport)
            : base(game)
        {
            drawOrder = startDrawOrder;

            GameStates = new Stack<GameState>();
            Viewport = viewport;
            Camera = new Camera(Viewport.Bounds);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Camera.Update(gameTime);
        }

        #region Methods Region

        public void PopState()
        {
            if (GameStates.Count > 0)
            {
                RemoveState();
                drawOrder -= drawOrderInc;

                if (OnStateChange != null)
                {
                    OnStateChange(this, EventArgs.Empty);
                }
            }
        }

        private void RemoveState()
        {
            GameState state = CurrentState;
            OnStateChange -= state.StateChange;
            Game.Components.Remove(state);
            GameStates.Pop();
        }

        public void PushState(GameState newState)
        {
            drawOrder += drawOrderInc;
            newState.DrawOrder = drawOrder;

            AddState(newState);

            if (OnStateChange != null)
            {
                OnStateChange(this, EventArgs.Empty);
            }
        }

        private void AddState(GameState newState)
        {
            GameStates.Push(newState);
            Game.Components.Add(newState);
            OnStateChange += newState.StateChange;
        }

        public void ChangeState(GameState newState)
        {
            while (GameStates.Count > 0)
            {
                RemoveState();
            }

            newState.DrawOrder = startDrawOrder;
            drawOrder = startDrawOrder;

            AddState(newState);

            if (OnStateChange != null)
            {
                OnStateChange(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}
