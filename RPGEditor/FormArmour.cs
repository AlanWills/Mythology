using XRpgLibrary.ItemClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RpgEditor
{
    public partial class FormArmour : FormDetails
    {
        #region Property and Fields
        #endregion

        #region Constructor Region

        public FormArmour()
        {
            InitializeComponent();

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
        }

        #endregion

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.ItemDataManager.ArmourData.Keys)
                lbDetails.Items.Add(FormDetails.ItemDataManager.ArmourData[s]);
        }

        private void AddArmour(ArmourData armourData)
        {
            if (FormDetails.ItemDataManager.ArmourData.ContainsKey(armourData.Name))
            {
                DialogResult result = MessageBox.Show(
                    armourData.Name + " already exists. Overwrite it?",
                    "Existing Armour",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                ItemDataManager.ArmourData[armourData.Name] = armourData;
                FillListBox();
                return;
            }
            ItemDataManager.ArmourData.Add(armourData.Name, armourData);
            lbDetails.Items.Add(armourData);
        }

        #region Button Event Handler Region

        void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormArmourDetails formArmourDetails = new FormArmourDetails())
            {
                formArmourDetails.ShowDialog();

                if (formArmourDetails.Armour != null)
                    AddArmour(formArmourDetails.Armour);
            }
        }

        void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                ArmourData data = ItemDataManager.ArmourData[entity];
                ArmourData newData = null;

                using (FormArmourDetails formArmourDetails = new FormArmourDetails())
                {
                    formArmourDetails.Armour = data;
                    formArmourDetails.ShowDialog();

                    if (formArmourDetails.Armour == null)
                        return;

                    if (formArmourDetails.Armour.Name == entity)
                    {
                        ItemDataManager.ArmourData[entity] = formArmourDetails.Armour;
                        FillListBox();
                        return;
                    }

                    newData = formArmourDetails.Armour;
                }

                DialogResult result = MessageBox.Show(
                    "Name has changed.  Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if (ItemDataManager.ArmourData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists.  Use Edit to modify the entry.");
                    return;
                }

                lbDetails.Items.Add(newData);
                ItemDataManager.ArmourData.Add(newData.Name, newData);
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = (string)lbDetails.SelectedItem;
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete " + entity + "?",
                    "Delete",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    ItemDataManager.ArmourData.Remove(entity);

                    if (File.Exists(FormMain.itemPath + @"\Armour\" + entity + ".xml"))
                        File.Delete(FormMain.itemPath + @"\Armour\" + entity + ".xml");
                }
            }
        }

        #endregion
    }
}
