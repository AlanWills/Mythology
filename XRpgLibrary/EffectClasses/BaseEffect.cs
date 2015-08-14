using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.CharacterClasses;

namespace XXRpgLibrary.EffectClasses
{
    public enum EffectType { Damage, Heal }

    public abstract class BaseEffect
    {
        #region Properties and Fields

        public string Name
        {
            get;
            protected set;
        }

        #endregion

        protected BaseEffect()
        {

        }

        #region Methods

        #endregion

        #region Virtual Methods

        public abstract void Apply(Entity entity);

        #endregion
    }
}
