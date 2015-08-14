using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ArmourData
    {
        public string Name;
        public string Type;
        public int Price;
        public float Weight;
        public bool Equipped;
        public ArmourLocation ArmourLocation;
        public int DefenceValue;
        public int DefenceModifier;
        public string[] AllowableClasses;

        public ArmourData()
        {

        }

        public override string ToString()
        {
            string armourString = Name + ", ";
            armourString += Type + ", ";
            armourString += Price.ToString() + ", ";
            armourString += Weight.ToString() + ", ";
            armourString += ArmourLocation.ToString() + ", ";
            armourString += DefenceValue.ToString() + ", ";
            armourString += DefenceModifier.ToString() + ", ";

            foreach (string s in AllowableClasses)
                armourString += ", " + s;

            return armourString;
        }
    }
}
