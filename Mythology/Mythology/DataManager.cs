using Microsoft.Xna.Framework.Content;
using XRpgLibrary.CharacterClasses;
using XRpgLibrary.ItemClasses;
using XRpgLibrary.SkillClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Mythology
{
    public static class DataManager
    {
        #region Properties and Fields

        private static Dictionary<string, ArmourData> armour = new Dictionary<string, ArmourData>();
        public static Dictionary<string, ArmourData> ArmourData
        {
            get { return armour; }
        }

        private static Dictionary<string, WeaponData> weapons = new Dictionary<string, WeaponData>();
        public static Dictionary<string, WeaponData> WeaponData
        {
            get { return weapons; }
        }

        private static Dictionary<string, ShieldData> shields = new Dictionary<string, ShieldData>();
        public static Dictionary<string, ShieldData> ShieldData
        {
            get { return shields; }
        }

        private static Dictionary<string, KeyData> keys = new Dictionary<string, KeyData>();
        public static Dictionary<string, KeyData> KeyData
        {
            get { return keys; }
        }

        private static Dictionary<string, ChestData> chests = new Dictionary<string, ChestData>();
        public static Dictionary<string, ChestData> ChestData
        {
            get { return chests; }
        }

        private static Dictionary<string, EntityData> entities = new Dictionary<string, EntityData>();
        public static Dictionary<string, EntityData> EntityData
        {
            get { return entities; }
        }

        private static Dictionary<string, SkillData> skills = new Dictionary<string, SkillData>();
        public static Dictionary<string, SkillData> SkillData
        {
            get { return skills; }
        }

        #endregion

        #region Methods

        public static void ReadEntityData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Classes", "*.xnb");
            foreach (string name in filenames)
            {
                string filename = @"Game\Classes\" + Path.GetFileNameWithoutExtension(name);
                EntityData data = Content.Load<EntityData>(filename);
                EntityData.Add(data.EntityName, data);
            }
        }

        public static void ReadArmorData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Items\Armour", "*.xnb");
            foreach (string name in filenames)
            {
                string filename = @"Game\Items\Armour\" + Path.GetFileNameWithoutExtension(name);
                ArmourData data = Content.Load<ArmourData>(filename);
                ArmourData.Add(data.Name, data);
            }
        }

        public static void ReadWeaponData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Items\Weapon", "*.xnb");
            foreach (string name in filenames)
            {
                string filename = @"Game\Items\Weapon\" + Path.GetFileNameWithoutExtension(name);
                WeaponData data = Content.Load<WeaponData>(filename);
                WeaponData.Add(data.Name, data);
            }
        }

        public static void ReadShieldData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Items\Shield", "*.xnb");
            foreach (string name in filenames)
            {
                string filename = @"Game\Items\Shield\" + Path.GetFileNameWithoutExtension(name);
                ShieldData data = Content.Load<ShieldData>(filename);
                ShieldData.Add(data.Name, data);
            }
        }

        public static void ReadKeyData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Keys", "*.xnb");
            foreach (string name in filenames)
            {
                string filename = @"Game\Keys\" + Path.GetFileNameWithoutExtension(name);
                KeyData data = Content.Load<KeyData>(filename);
                KeyData.Add(data.Name, data);
            }
        }

        public static void ReadChestData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Chests", "*.xnb");
            foreach (string name in filenames)
            {
                string filename = @"Game\Chests\" + Path.GetFileNameWithoutExtension(name);
                ChestData data = Content.Load<ChestData>(filename);
                ChestData.Add(data.Name, data);
            }
        }

        public static void ReadSkillData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Skills", "*.xnb");
            foreach (string name in filenames)
            {
                string filename = @"Game\Skills\" + Path.GetFileNameWithoutExtension(name);
                SkillData data = Content.Load<SkillData>(filename);
                SkillData.Add(data.Name, data);
            }
        }

        public static void ReadAllData(ContentManager Content)
        {
            ReadEntityData(Content);
            ReadArmorData(Content);
            ReadShieldData(Content);
            ReadWeaponData(Content);
            ReadChestData(Content);
            ReadKeyData(Content);
            ReadSkillData(Content);
        }

        #endregion

        #region Virtual Methods

        #endregion
    }
}
