using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XXRpgLibrary.ItemClasses;
using XXRpgLibrary.SpriteClasses;

namespace XXRpgLibrary.CharacterClasses
{
    public class Character
    {
        #region Properties and Fields

        public Entity Entity
        {
            get;
            protected set;
        }

        public AnimatedSprite Sprite
        {
            get;
            protected set;
        }

        // Armour Fields
        public GameItem Head
        {
            get;
            protected set;
        }

        public GameItem Body
        {
            get;
            protected set;
        }

        public GameItem Hands
        {
            get;
            protected set;
        }

        public GameItem Feet
        {
            get;
            protected set;
        }

        // Weapon/Shield Fields
        public GameItem MainHand
        {
            get;
            protected set;
        }

        public GameItem OffHand
        {
            get;
            protected set;
        }

        public int HandsFree
        {
            get;
            protected set;
        }

        #endregion

        public Character(Entity entity, AnimatedSprite sprite)
        {
            Entity = entity;
            Sprite = sprite;
        }

        #region Methods

        #endregion

        #region Virtual Methods

        public virtual void Update(GameTime gameTime)
        {
            Entity.Update(gameTime.ElapsedGameTime);
            Sprite.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public virtual bool Unequip(GameItem gameItem)
        {
            bool success = false;

            return success;
        }

        #endregion
    }
}
