using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.CharacterClasses;

namespace XRpgLibrary.SpellClasses
{
    public class Spell
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

        public List<string> SpellPrerequisites
        {
            get;
            private set;
        }

        public int LevelRequirement
        {
            get;
            private set;
        }

        public SpellType SpellType
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

        private Spell()
        {
            AllowedClasses = new List<string>();
            AttributeRequirements = new Dictionary<string, int>();
            SpellPrerequisites = new List<string>();
            Effects = new List<string>();
        }

        #region Methods

        public static Spell FromSpellData(SpellData data)
        {
            Spell spell = new Spell();
            spell.Name = data.Name;

            foreach (string s in data.AllowedClasses)
                spell.AllowedClasses.Add(s.ToLower());

            foreach (string s in data.AttributeRequirements.Keys)
                spell.AttributeRequirements.Add(s.ToLower(), data.AttributeRequirements[s]);

            foreach (string s in data.SpellPrerequisites)
                spell.SpellPrerequisites.Add(s);

            spell.LevelRequirement = data.LevelRequirement;
            spell.SpellType = data.SpellType;
            spell.ActivationCost = data.ActivationCost;

            foreach (string s in data.Effects)
                spell.Effects.Add(s);

            return spell;
        }

        public static bool CanLearn(Entity entity, Spell spell)
        {
            bool canLearn = true;

            if (entity.Level < spell.LevelRequirement)
                canLearn = false;

            if (!spell.AllowedClasses.Contains(entity.EntityClass.ToLower()))
                canLearn = false;

            foreach (string s in spell.AttributeRequirements.Keys)
            {
                if (Mechanics.GetAttributeByString(entity, s) < spell.AttributeRequirements[s])
                {
                    canLearn = false;
                    break;
                }
            }

            foreach (string s in spell.SpellPrerequisites)
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
