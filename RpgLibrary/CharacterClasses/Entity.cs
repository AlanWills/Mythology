using RpgLibrary.SkillClasses;
using RpgLibrary.SpellClasses;
using RpgLibrary.TalentClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.CharacterClasses
{
    public enum EntityGender { Male, Female, Unknown }
    public enum EntityType { Character, NPC, Monster, Creature }

    public sealed class Entity
    {
        #region Vital Fields and Properties

        public string EntityName
        {
            get;
            private set;
        }

        public string EntityClass
        {
            get;
            private set;
        }

        public EntityType EntityType
        {
            get;
            private set;
        }

        public EntityGender Gender
        {
            get;
            private set;
        }
        
        #endregion

        #region Basic Attributes and Properties

        public int Strength
        {
            get { return strength + strengthModifier; }
            private set { strength = value; }
        }

        public int Dexterity
        {
            get { return dexterity + dexterityModifier; }
            private set { dexterity = value; }
        }

        public int Cunning
        {

            get { return cunning + cunningModifier; }
            private set { cunning = value; }
        }

        public int Willpower
        {
            get { return willpower + willpowerModifier; }
            private set { willpower = value; }
        }

        public int Magic
        {
            get { return magic + magicModifier; }
            private set { magic = value; }
        }

        public int Constitution
        {
            get { return constitution + constitutionModifier; }
            private set { constitution = value; }
        }

        private int strength;
        private int dexterity;
        private int cunning;
        private int willpower;
        private int magic;
        private int constitution;

        private int strengthModifier;
        private int dexterityModifier;
        private int cunningModifier;
        private int willpowerModifier;
        private int magicModifier;
        private int constitutionModifier;

        #endregion

        #region Calculated Attribute Fields and Properties

        public AttributePair Health
        {
            get;
            private set;
        }

        public AttributePair Stamina
        {
            get;
            private set;
        }

        public AttributePair Mana
        {
            get;
            private set;
        }

        private int attack, damage, defence;

        #endregion

        #region Level Field and Properties

        public int Level
        {
            get;
            private set;
        }

        public long Experience
        {
            get;
            private set;
        }

        #endregion

        #region Skill Fields and Properties

        public Dictionary<string, Skill> Skills
        {
            get;
            private set;
        }

        public List<Modifier> SkillModifiers
        {
            get;
            private set;
        }

        #endregion

        #region Spell Fields and Properties

        public Dictionary<string, Spell> Spells
        {
            get;
            private set;
        }

        public List<Modifier> SpellModifiers
        {
            get;
            private set;
        }

        #endregion

        #region Talent Fields and Properties

        public Dictionary<string, Talent> Talents
        {
            get;
            private set;
        }

        public List<Modifier> TalentModifiers
        {
            get;
            private set;
        }

        #endregion

        private Entity()
        {
            Health = new AttributePair(0);
            Stamina = new AttributePair(0);
            Mana = new AttributePair(0);

            Skills = new Dictionary<string, Skill>();
            Spells = new Dictionary<string, Spell>();
            Talents = new Dictionary<string, Talent>();

            SkillModifiers = new List<Modifier>();
            SpellModifiers = new List<Modifier>();
            TalentModifiers = new List<Modifier>();
        }

        public Entity(string name, EntityData entityData, EntityGender gender, EntityType type)
            : this()
        {
            EntityName = name;
            Gender = gender;
            EntityType = type;
            EntityClass = entityData.EntityName;
            Strength = entityData.Strength;
            Dexterity = entityData.Dexterity;
            Cunning = entityData.Cunning;
            Willpower = entityData.Willpower;
            Magic = entityData.Magic;
            Constitution = entityData.Constitution;
        }

        public void Update(TimeSpan elapsedGameTime)
        {
            foreach (Modifier modifier in SkillModifiers)
                modifier.Update(elapsedGameTime);

            foreach (Modifier modifier in SpellModifiers)
                modifier.Update(elapsedGameTime);

            foreach (Modifier modifier in TalentModifiers)
                modifier.Update(elapsedGameTime);
        }
    }
}
