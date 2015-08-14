using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XXRpgLibrary;
using XXRpgLibrary.CharacterClasses;
using XXRpgLibrary.SpriteClasses;
using XXRpgLibrary.TileEngine;

namespace Mythology
{
    public class Player
    {
        public Character Character
        {
            get;
            private set;
        }

        public AnimatedSprite Sprite
        {
            get { return Character.Sprite; }
        }

        public Player(Character character)
        {
            Character = character;
        }

        public void Update(GameTime gameTime)
        {
            Vector2 motion = new Vector2();

            if (InputHandler.KeyDown(Keys.W) ||
                InputHandler.ButtonDown(Buttons.LeftThumbstickUp, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Up;
                motion.Y = -1;
            }

            if (InputHandler.KeyDown(Keys.S) ||
                InputHandler.ButtonDown(Buttons.LeftThumbstickDown, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Down;
                motion.Y = 1;
            }

            if (InputHandler.KeyDown(Keys.A) ||
                InputHandler.ButtonDown(Buttons.LeftThumbstickLeft, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Left;
                motion.X = -1;
            }

            if (InputHandler.KeyDown(Keys.D) ||
                InputHandler.ButtonDown(Buttons.LeftThumbstickRight, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Right;
                motion.X = 1;
            }

            motion.Normalize();

            Sprite.IsAnimating = motion != Vector2.Zero;
            Sprite.Position += motion * Sprite.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Sprite.LockToMap();
            Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Character.Draw(spriteBatch);
        }
    }
}
