using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.CharacterClasses;

namespace XRpgLibrary.TalentClasses
{
    public class Talent
    {
        #region Properties and Fields

        public string Name
        {
            get;
            private set;
        }

        public List<string> AllowedClasses
        {
            get;
            private set;
        }

        public Dictionary<string, int> AttributeRequirements
        {
            get;
            private set;
        }

        public List<string> TalentPrerequisites
        {
            get;
            private set;
        }

        public int LevelRequirement
        {
            get;
            private set;
        }

        public TalentType TalentType
        {
            get;
            private set;
        }

        public int ActivationCost
        {
            get;
            private set;
        }

        public List<string> Effects
        {
            get;
            private set;
        }

        #endregion

        private Talent()
        {
            AllowedClasses = new List<string>();
            AttributeRequirements = new Dictionary<string, int>();
            TalentPrerequisites = new List<string>();
            Effects = new List<string>();
        }

        #region Methods

        public static Talent FromTalentData(TalentData data)
        {
            Talent talent = new Talent();

            talent.Name = data.Name;

            foreach (string s in data.AllowedClasses)
                talent.AllowedClasses.Add(s.ToLower());

            foreach (string s in data.AttributeRequirements.Keys)
                talent.AttributeRequirements.Add(s.ToLower(), data.AttributeRequirements[s]);

            foreach (string s in data.TalentPrerequisites)
                talent.TalentPrerequisites.Add(s);

            talent.LevelRequirement = data.LevelRequirement;
            talent.TalentType = data.TalentType;
            talent.ActivationCost = data.ActivationCost;

            foreach (string s in data.Effects)
                talent.Effects.Add(s);

            return talent;

        }

        public static bool CanLearn(Entity entity, Talent talent)
        {
            bool canLearn = true;

            if (entity.Level < talent.LevelRequirement)
                canLearn = false;

            if (!talent.AllowedClasses.Contains(entity.EntityClass.ToLower()))
                canLearn = false;

            foreach (string s in talent.AttributeRequirements.Keys)
            {
                if (Mechanics.GetAttributeByString(entity, s) < talent.AttributeRequirements[s])
                {
                    canLearn = false;
                    break;
                }
            }

            foreach (string s in talent.TalentPrerequisites)
            {
                if (!entity.Talents.ContainsKey(s))
                {
                    canLearn = false;
                    break;
                }
            }

            return canLearn;
        }

        #endregion

        #region Virtual Methods

        #endregion
    }
}
