using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.ItemClasses
{
    public enum Hands { One, Two }

    public enum ArmourLocation { Body, Head, Hands, Feet }

    public abstract class BaseItem
    {
        #region Properites and Fields

        public List<string> AllowableClasses
        {
            get;
            protected set;
        }

        public string Type
        {
            get;
            protected set;
        }

        public string Name
        {
            get;
            protected set;
        }

        public int Price
        {
            get;
            protected set;
        }

        public float Weight
        {
            get;
            protected set;
        }

        public bool IsEquipped
        {
            get;
            protected set;
        }

        #endregion

        public BaseItem(string name, string type, int price, float weight, params string[] allowableClasses)
        {
            AllowableClasses = new List<string>();

            foreach (string s in AllowableClasses)
                AllowableClasses.Add(s);

            Name = name;
            Type = type;
            Price = price;
            Weight = weight;
            IsEquipped = false;
        }

        #region Overridable Methods

        public abstract object Clone();

        public virtual bool CanEquip(string characterString)
        {
            return AllowableClasses.Contains(characterString);
        }

        public override string ToString()
        {
            string itemString = "";

            itemString += Name + ", ";
            itemString += Type + ", ";
            itemString += Price.ToString() + ", ";
            itemString += Weight.ToString();

            return itemString;
        }

        #endregion
    }
}
