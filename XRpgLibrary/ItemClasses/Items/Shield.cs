using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.ItemClasses
{
    public class Shield : BaseItem
    {
        #region Properties and Fields

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

        public Shield(string shieldName, string shieldType, int price, float weight, int defenceValue, int defenceModifier, params string[] allowableClasses)
            : base (shieldName, shieldType, price, weight, allowableClasses)
        {
            DefenceValue = defenceValue;
            DefenceModifier = defenceModifier;
        }

        #region Overridable Methods

        public override object Clone()
        {
            string[] allowedClasses = new string[AllowableClasses.Count];

            for (int i = 0; i < AllowableClasses.Count; i++)
                allowedClasses[i] = AllowableClasses[i];

            Shield shield = new Shield(Name, Type, Price, Weight, DefenceValue, DefenceModifier, allowedClasses);

            return shield;
        }

        public override string ToString()
        {
            string shieldString = base.ToString() + ", ";
            shieldString += DefenceValue.ToString() + ", ";
            shieldString += DefenceModifier.ToString();
             
            foreach (string s in AllowableClasses)
                shieldString += ", " + s;
            
            return shieldString;
        }

        #endregion
    }
}
