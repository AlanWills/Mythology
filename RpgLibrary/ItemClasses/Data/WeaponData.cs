using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class WeaponData
    {
        public string Name;
        public string Type;
        public int Price;
        public float Weight;
        public bool Equipped;
        public Hands NumberHands;
        public int AttackValue;
        public int AttackModifier;
        public int DamageValue;
        public int DamageModifier;
        public string[] AllowableClasses;

        public WeaponData()
        {

        }

        public override string ToString()
        {
            string weaponString = Name + ", ";
            weaponString += Type + ", ";
            weaponString += Price.ToString() + ", ";
            weaponString += Weight.ToString() + ", ";
            weaponString += NumberHands.ToString() + ", ";
            weaponString += AttackValue.ToString() + ", ";
            weaponString += AttackModifier.ToString() + ", ";
            weaponString += DamageValue.ToString() + ", ";
            weaponString += DamageModifier.ToString() + ", ";

            foreach (string s in AllowableClasses)
                weaponString += ", " + s;

            return weaponString;
        }
    }
}
