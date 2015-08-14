using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.TalentClasses
{
    public enum TalentType { Passive, Sustained, Activated }

    public class TalentData
    {
        #region Properties and Fields

        public string Name;
        public string[] AllowedClasses;
        public Dictionary<string, int> AttributeRequirements;
        public string[] TalentPrerequisites;
        public int LevelRequirement;
        public TalentType TalentType;
        public int ActivationCost;
        public string[] Effects;

        #endregion

        public TalentData()
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

            foreach (string s in TalentPrerequisites)
                toString += ", " + s;

            toString += ", " + LevelRequirement.ToString();
            toString += ", " + TalentType.ToString();
            toString += ", " + ActivationCost.ToString();

            foreach (string s in Effects)
                toString += ", " + s;

            return toString;
        }

        #endregion
    }
}
