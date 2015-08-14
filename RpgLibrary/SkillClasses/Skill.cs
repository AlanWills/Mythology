using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.SkillClasses
{
    public enum DifficultyLevel
    {
        Master = -25,
        Expert = -10,
        Improved = -5,
        Normal = 0,
        Easy = 10
    }

    public class Skill
    {
        #region Properties and Fields

        public string SkillName
        {
            get;
            private set;
        }

        public int SkillValue
        {
            get;
            private set;
        }

        public string PrimaryAttribute
        {
            get;
            private set;
        }

        public Dictionary<string, int> ClassModifiers
        {
            get;
            private set;
        }

        #endregion

        private Skill()
        {
            SkillName = "";
            PrimaryAttribute = "";
            SkillValue = 0;
            ClassModifiers = new Dictionary<string, int>();
        }

        #region Methods

        public void IncreaseSkill(int value)
        {
            SkillValue += value;

            if (SkillValue > 100)
                SkillValue = 100;
        }

        public void DecreaseSkill(int value)
        {
            SkillValue -= value;

            if (SkillValue < 0)
                SkillValue = 0;
        }

        public static Skill SkillFromSkillData(SkillData data)
        {
            Skill skill = new Skill();

            skill.SkillName = data.Name;
            skill.SkillValue = 0;

            foreach (string s in data.ClassModifiers.Keys)
            {
                skill.ClassModifiers.Add(s, data.ClassModifiers[s]);
            }

            return skill;
        }

        public static int AttributeModifier(int attribute)
        {
            int result = 0;

            if (attribute < 25)
                result = 1;
            else if (attribute < 50)
                result = 2;
            else if (attribute < 75)
                result = 3;
            else if (attribute < 90)
                result = 4;
            else if (attribute < 95)
                result = 5;
            else
                result = 10;

            return result;
        }

        #endregion

        #region Virtual Methods

        #endregion
    }
}
