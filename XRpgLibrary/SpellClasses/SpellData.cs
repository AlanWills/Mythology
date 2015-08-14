﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.SpellClasses
{
    public enum SpellType { Passive, Sustained, Activated }

    public class SpellData
    {
        #region Properties and Fields

        public string Name;
        public string[] AllowedClasses;
        public Dictionary<string, int> AttributeRequirements;
        public string[] SpellPrerequisites;
        public int LevelRequirement;
        public SpellType SpellType;
        public int ActivationCost;
        public string[] Effects;

        #endregion

        public SpellData()
        {
            AttributeRequirements = new Dictionary<string, int>();
        }

        #region Methods

        #endregion

        #region Virtual Methods

        public override string ToString()
        {
            string toString = Name;

            foreach (string s in AllowedClasses)
                toString += ", " + s;

            foreach (string s in AttributeRequirements.Keys)
                toString += ", " + s + "+" + AttributeRequirements[s].ToString();

            foreach (String s in SpellPrerequisites)
                toString += ", " + s;

            toString += ", " + LevelRequirement;
            toString += ", " + SpellType.ToString();
            toString += ", " + ActivationCost.ToString();

            foreach (string s in Effects)
                toString += ", " + s;

            return toString;
        }

        #endregion
    }
}
