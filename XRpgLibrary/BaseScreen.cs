using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XXRpgLibrary;
using XXRpgLibrary.Controls;
using XXRpgLibrary.TileEngine;

namespace Mythology.GameScreens
{
    public abstract partial class BaseScreen : GameState
    {
        public ContentManager Content
        {
            get { return StateManager.Content; }
        }

        public SpriteBatch SpriteBatch
        {
            get { return StateManager.SpriteBatch; }
        }

        public Viewport Viewport
        {
            get { return StateManager.Viewport; }
        }

        protected ControlManager ControlManager
        {
            get;
            set;
        }

        protected PlayerIndex PlayerIndexInControl
        {
            get;
            set;
        }

        protected BaseScreen TransitionTo
        {
            get;
            set;
        }

        protected bool Transitioning;
        protected ChangeType ChangeType;

        protected TimeSpan transitionTimer;
        protected TimeSpan transitionInterval = TimeSpan.FromSeconds(0.5f);

        public BaseScreen(GameStateManager manager)
            : base(manager)
        {
            SpriteFont menuFont = Content.Load<SpriteFont>("SpriteFonts\\ControlFont");
            ControlManager = new ControlManager(menuFont);

            PlayerIndexInControl = PlayerIndex.One;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            ControlManager.Update(gameTime, PlayerIndexInControl);

            HandleTransitioning(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            ControlManager.Draw(SpriteBatch);
        }

        #region Transition Methods

        private void HandleTransitioning(GameTime gameTime)
        {
            if (Transitioning)
            {
                transitionTimer += gameTime.ElapsedGameTime;

                if (transitionTimer >= transitionInterval)
                {
                    Transitioning = false;
                    switch (ChangeType)
                    {
                        case ChangeType.Change:
                            StateManager.ChangeState(TransitionTo);
                            break;
                        case ChangeType.Pop:
                            StateManager.PopState();
                            break;
                        case ChangeType.Push:
                            StateManager.PushState(TransitionTo);
                            break;
                    }
                }
            }
        }

        public virtual void Transition(BaseScreen transitionTo, ChangeType changeType)
        {
            Transitioning = true;
            TransitionTo = transitionTo;
            ChangeType = changeType;
            transitionTimer = TimeSpan.Zero;
        }

        #endregion

        #region Extra Functions for setting up a Screen

        protected void AddBackground(string backgroundAsset)
        {
            PictureBox background = new PictureBox(Content.Load<Texture2D>(backgroundAsset), new Vector2(Viewport.Width, Viewport.Height) / 2);
            background.TabStop = false;
            ControlManager.Add(background);
        }

        #endregion
    }
}
