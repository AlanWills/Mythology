using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.EffectClasses;

namespace XRpgLibrary.ItemClasses
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
        public DamageEffectData DamageEffectData;
        public string[] AllowableClasses;

        public WeaponData()
        {
            DamageEffectData = new DamageEffectData();
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
            weaponString += DamageEffectData.ToString();

            foreach (string s in AllowableClasses)
                weaponString += ", " + s;

            return weaponString;
        }
    }
}
