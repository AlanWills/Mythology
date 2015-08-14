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
    public abstract partial class GameState : DrawableGameComponent
    {
        #region Properties

        public List<GameComponent> Components
        {
            get;
            private set;
        }

        public GameState Tag
        {
            get;
            private set;
        }

        protected GameStateManager StateManager
        {
            get;
            set;
        }

        #endregion

        public GameState(GameStateManager manager)
            : base(manager.Game)
        {
            StateManager = manager;
            Components = new List<GameComponent>();
            Tag = this;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (GameComponent component in Components)
            {
                if (component.Enabled)
                {
                    component.Update(gameTime);
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            DrawableGameComponent drawComponent;

            foreach (GameComponent component in Components)
            {
                if (component is DrawableGameComponent)
                {
                    drawComponent = component as DrawableGameComponent;

                    if (drawComponent.Visible)
                    {
                        drawComponent.Draw(gameTime);
                    }
                }
            }
        }

        #region GameState Method Region

        internal protected virtual void StateChange(object sender, EventArgs e)
        {
            if (StateManager.CurrentState == Tag)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        protected virtual void Show()
        {
            Visible = true;
            Enabled = true;
            foreach (GameComponent component in Components)
            {
                component.Enabled = true;
                if (component is DrawableGameComponent)
                {
                    ((DrawableGameComponent)component).Visible = true;
                }
            }
        }

        protected virtual void Hide()
        {
            Visible = false;
            Enabled = false;
            foreach (GameComponent component in Components)
            {
                component.Enabled = false;
                if (component is DrawableGameComponent)
                {
                    ((DrawableGameComponent)component).Visible = false;
                }
            }
        }

        #endregion
    }
}
