using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XXRpgLibrary.EffectClasses;

namespace XRpgLibrary.EffectClasses
{
    public enum DamageType { Weapon, Poison, Disease, Fire, Ice, Lightning, Earth, Water, Air }
    public enum AttackType { Health, Mana, Stamina }

    public class DamageEffectData : BaseEffectData
    {
        #region Properties and Fields

        public DamageType DamageType;
        public AttackType AttackType;
        public Mechanics.DieType DieType;
        public int NumberOfDice;
        public int Modifier;

        #endregion

        #region Methods

        #endregion

        #region Virtual Methods

        public override string ToString()
        {
            string toString = Name + ", " + DamageType.ToString() + ", ";
            toString += AttackType.ToString() + ", ";
            toString += DieType.ToString() + ", ";
            toString += NumberOfDice.ToString() + ", ";
            toString += Modifier.ToString();

            return toString;
        }

        #endregion
    }
}
