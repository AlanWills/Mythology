using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class Weapon : BaseItem
    {
        #region Properties and Fields

        public Hands NumberHands
        {
            get;
            protected set;
        }

        public int AttackValue
        {
            get;
            protected set;
        }

        public int AttackModifier
        {
            get;
            protected set;
        }

        public int DamageValue
        {
            get;
            protected set;
        }

        public int DamageModifier
        {
            get;
            protected set;
        }

        #endregion

        public Weapon(string weaponName, string weaponType, int price, float weight, Hands hands, int attackValue, int attackModifier, int damageValue, int damageModifier, params string[] allowableClasses)
            : base(weaponName, weaponType, price, weight, allowableClasses)
        {
            NumberHands = hands;
            AttackValue = attackValue;
            AttackModifier = attackModifier;
            DamageValue = damageValue;
            DamageModifier = damageModifier;
        }

        #region Overridable Methods

        public override object Clone()
        {
            string[] allowedClasses = new string[AllowableClasses.Count];

            for (int i = 0; i < AllowableClasses.Count; i++)
                allowedClasses[i] = AllowableClasses[i];

            Weapon weapon = new Weapon(Name, Type, Price, Weight, NumberHands, AttackValue, AttackModifier, DamageValue, DamageModifier, allowedClasses);

            return weapon;
        }

        public override string ToString()
        {
            string weaponString = base.ToString() + ", ";
            weaponString += NumberHands.ToString() + ", ";
            weaponString += AttackValue.ToString() + ", ";
            weaponString += AttackModifier.ToString() + ", ";
            weaponString += DamageValue.ToString() + ", ";
            weaponString += DamageModifier.ToString();

            foreach (string s in AllowableClasses)
                weaponString += ", " + s;

            return weaponString;
        }

        #endregion
    }
}
