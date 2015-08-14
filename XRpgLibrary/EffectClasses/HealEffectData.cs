using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XXRpgLibrary.EffectClasses;

namespace XRpgLibrary.EffectClasses
{
    public enum HealType { Health, Mana, Stamina }

    public class HealEffectData : BaseEffectData
    {
        #region Properties and Fields

        public HealType HealType;
        public Mechanics.DieType DieType;
        public int NumberOfDice;
        public int Modifier;

        #endregion

        #region Methods

        #endregion

        #region Virtual Methods

        #endregion
    }
}
