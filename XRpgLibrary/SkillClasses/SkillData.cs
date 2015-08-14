using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.SkillClasses
{
    public class SkillData
    {
        #region Properties and Fields

        public string Name;
        public string PrimaryAttribute;
        public Dictionary<string, int> ClassModifiers;

        #endregion

        public SkillData()
        {
            ClassModifiers = new Dictionary<string, int>();
        }

        #region Methods

        #endregion

        #region Virtual Methods

        public override string ToString()
        {
            string skillString = Name + ", ";
            skillString += PrimaryAttribute + ", ";

            foreach (KeyValuePair<string, int> modifier in ClassModifiers)
                skillString += ", " + modifier.Key + "+" + modifier.Value.ToString();

            return skillString;
        }

        #endregion
    }
}
