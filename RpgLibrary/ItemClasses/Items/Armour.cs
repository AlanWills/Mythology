using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class Armour : BaseItem
    {
        #region Fields and Properties

        public ArmourLocation ArmourLocation
        {
            get;
            protected set;
        }

        public int DefenceValue
        {
            get;
            protected set;
        }

        public int DefenceModifier
        {
            get;
            protected set;
        }

        #endregion

        public Armour(string armourName, string armourType, int price, float weight, ArmourLocation location, int defenceValue, int defenceModifier, params string[] allowableClasses)
            : base(armourName, armourType, price, weight, allowableClasses)
        {
            ArmourLocation = location;
            DefenceValue = defenceValue;
            DefenceModifier = defenceModifier;
        }

        #region Overridable Methods

        public override object Clone()
        {
            string[] allowedClasses = new string[AllowableClasses.Count];

            for (int i = 0; i < AllowableClasses.Count; i++)
                allowedClasses[i] = AllowableClasses[i];

            Armour armour = new Armour(Name, Type, Price, Weight, ArmourLocation, DefenceValue, DefenceModifier, allowedClasses);

            return armour;
        }
        public override string ToString()
        {
            string ArmourString = base.ToString() + ", ";
            ArmourString += ArmourLocation.ToString() + ", ";
            ArmourString += DefenceValue.ToString() + ", ";
            ArmourString += DefenceModifier.ToString();

            foreach (string s in AllowableClasses)
                ArmourString += ", " + s;

            return ArmourString;
        }

        #endregion
    }
}
