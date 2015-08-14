using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.ItemClasses
{
    public class ShieldData
    {
        public string Name;
        public string Type;
        public int Price;
        public float Weight;
        public bool Equipped;
        public int DefenceValue;
        public int DefenceModifier;
        public string[] AllowableClasses;

        public ShieldData()
        {

        }

        public override string ToString()
        {
            string shieldString = Name + ", ";
            shieldString += Type + ", ";
            shieldString += Price.ToString() + ", ";
            shieldString += Weight.ToString() + ", ";
            shieldString += DefenceValue.ToString() + ", ";
            shieldString += DefenceModifier.ToString() + ", ";

            foreach (string s in AllowableClasses)
                shieldString += ", " + s;

            return shieldString;
        }
    }
}
