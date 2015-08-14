using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.CharacterClasses
{
    public class EntityData
    {
        #region Properties and Fields

        public string EntityName;

        public int Strength;
        public int Dexterity;
        public int Cunning;
        public int Willpower;
        public int Magic;
        public int Constitution;

        public string HealthFormula;
        public string StaminaFormula;
        public string MagicFormula;

        #endregion

        private EntityData()
        {

        }

        public EntityData(string entityName, int strength, int dexterity, int cunning, int willpower, int magic, int constitution, string health, string stamina, string mana)
        {
            EntityName = entityName;
            Strength = strength;
            Dexterity = dexterity;
            Cunning = cunning;
            Willpower = willpower;
            Magic = magic;
            Constitution = constitution;

            HealthFormula = health;
            StaminaFormula = stamina;
            MagicFormula = mana;
        }

        #region Methods

        public override string ToString()
        {
            string toString = EntityName + ", ";
            toString += Strength.ToString() + ", ";
            toString += Dexterity.ToString() + ", ";
            toString += Cunning.ToString() + ", ";
            toString += Willpower.ToString() + ", ";
            toString += Magic.ToString() + ", ";
            toString += Constitution.ToString() + ", ";
            toString += HealthFormula + ", ";
            toString += StaminaFormula + ", ";
            toString += MagicFormula;

            return toString;
        }

        public object Clone()
        {
            EntityData data = new EntityData();

            data.EntityName = EntityName;
            data.Strength = Strength;
            data.Dexterity = Dexterity;
            data.Cunning = Cunning;
            data.Willpower = Willpower;
            data.Magic = Magic;
            data.Constitution = Constitution;
            data.HealthFormula = HealthFormula;
            data.StaminaFormula = StaminaFormula;
            data.MagicFormula = MagicFormula;

            return data;
        }

        #endregion
    }
}
