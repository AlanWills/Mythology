using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XRpgLibrary.ItemClasses;
using XRpgLibrary.CharacterClasses;
using RPGEditor;
using System.IO;
using XRpgLibrary.SkillClasses;

namespace RpgEditor
{
    public partial class FormDetails : Form
    {
        #region Property Region

        public static ItemDataManager ItemDataManager
        {
            get;
            private set;
        }

        public static EntityDataManager EntityDataManager
        {
            get;
            private set;
        }

        public static SkillDataManager SkillDataManager
        {
            get;
            private set;
        }

        #endregion

        #region Constructor Region

        public FormDetails()
        {
            InitializeComponent();

            if (ItemDataManager == null)
                ItemDataManager = new ItemDataManager();

            if (EntityDataManager == null)
                EntityDataManager = new EntityDataManager();

            if (SkillDataManager == null)
                SkillDataManager = new SkillDataManager();

            this.FormClosing += new FormClosingEventHandler(FormDetails_FormClosing);
        }

        #endregion        

        public static void WriteEntityData()
        {
            foreach (string s in EntityDataManager.EntityData.Keys)
            {
                XNASerializer.Serialize<EntityData>(FormMain.classPath + "\\" + s + ".xml", EntityDataManager.EntityData[s]);
            }
        }

        public static void WriteItemData()
        {
            foreach (string s in ItemDataManager.ArmourData.Keys)
            {
                XNASerializer.Serialize<ArmourData>(FormMain.itemPath + "\\Armour\\" + s + ".xml", ItemDataManager.ArmourData[s]);
            }

            foreach (string s in ItemDataManager.ShieldData.Keys)
            {
                XNASerializer.Serialize<ShieldData>(FormMain.itemPath + "\\Shield\\" + s + ".xml", ItemDataManager.ShieldData[s]);
            }

            foreach (string s in ItemDataManager.WeaponData.Keys)
            {
                XNASerializer.Serialize<WeaponData>(FormMain.itemPath + "\\Weapon\\" + s + ".xml", ItemDataManager.WeaponData[s]);
            }
        }

        public static void WriteKeyData()
        {
            foreach (string s in ItemDataManager.KeyData.Keys)
            {
                XNASerializer.Serialize<KeyData>(
                FormMain.keyPath + @"\" + s + ".xml",
                ItemDataManager.KeyData[s]);
            }
        }

        public static void WriteChestData()
        {
            foreach (string s in ItemDataManager.ChestData.Keys)
            {
                XNASerializer.Serialize<ChestData>(
                FormMain.chestPath + @"\" + s + ".xml",
                ItemDataManager.ChestData[s]);
            }
        }

        public static void WriteSkillData()
        {
            foreach (string s in SkillDataManager.Dictionary.Keys)
            {
                XNASerializer.Serialize<SkillData>(
                    FormMain.skillPath + "\\" + s + ".xml",
                    SkillDataManager.Dictionary[s]);
            }
        }

        public static void ReadEntityData()
        {
            EntityDataManager = new EntityDataManager();

            string[] fileNames = Directory.GetFiles(FormMain.classPath, "*.xml");

            foreach (string s in fileNames)
            {
                EntityData entityData = XNASerializer.Deserialize<EntityData>(s);
                EntityDataManager.EntityData.Add(entityData.EntityName, entityData);
            }
        }

        public static void ReadItemData()
        {
            ItemDataManager = new ItemDataManager();

            string[] fileNames = Directory.GetFiles(Path.Combine(FormMain.itemPath, "Armour"), "*.xml");

            foreach (string s in fileNames)
            {
                ArmourData armourData = XNASerializer.Deserialize<ArmourData>(s);
                ItemDataManager.ArmourData.Add(armourData.Name, armourData);
            }

            fileNames = Directory.GetFiles(Path.Combine(FormMain.itemPath, "Shield"), "*.xml");

            foreach (string s in fileNames)
            {
                ShieldData shieldData = XNASerializer.Deserialize<ShieldData>(s);
                ItemDataManager.ShieldData.Add(shieldData.Name, shieldData);
            }

            fileNames = Directory.GetFiles(Path.Combine(FormMain.itemPath, "Weapon"), "*.xml");

            foreach (string s in fileNames)
            {
                WeaponData weaponData = XNASerializer.Deserialize<WeaponData>(s);
                ItemDataManager.WeaponData.Add(weaponData.Name, weaponData);
            }
        }

        public static void ReadKeyData()
        {
            string[] fileNames = Directory.GetFiles(FormMain.keyPath, "*.xml");
            foreach (string s in fileNames)
            {
                KeyData keyData = XNASerializer.Deserialize<KeyData>(s);
                ItemDataManager.KeyData.Add(keyData.Name, keyData);
            }
        }

        public static void ReadChestData()
        {
            string[] fileNames = Directory.GetFiles(FormMain.chestPath, "*.xml");
            foreach (string s in fileNames)
            {
                ChestData chestData = XNASerializer.Deserialize<ChestData>(s);
                ItemDataManager.ChestData.Add(chestData.Name, chestData);
            }
        }

        public static void ReadSkillData()
        {
            SkillDataManager = new SkillDataManager();

            string[] fileNames = Directory.GetFiles(FormMain.skillPath, "*.xml");
            foreach (string s in fileNames)
            {
                SkillData skillData = XNASerializer.Deserialize<SkillData>(s);
                SkillDataManager.Dictionary.Add(skillData.Name, skillData);
            }
        }

        #region Event Handlers

        void FormDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }

            if (e.CloseReason == CloseReason.MdiFormClosing)
            {
                e.Cancel = false;
                this.Close();
            }
        }

        #endregion
    }
}
