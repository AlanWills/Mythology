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

    public partial class FormWeapon : FormDetails
    {
        #region Field Region
        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public FormWeapon()
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

            foreach (string s in FormDetails.ItemDataManager.WeaponData.Keys)
                lbDetails.Items.Add(FormDetails.ItemDataManager.WeaponData[s]);
        }

        private void AddWeapon(WeaponData WeaponData)
        {
            if (FormDetails.ItemDataManager.WeaponData.ContainsKey(WeaponData.Name))
            {
                DialogResult result = MessageBox.Show(
                    WeaponData.Name + " already exists. Overwrite it?",
                    "Existing Weapon",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                ItemDataManager.WeaponData[WeaponData.Name] = WeaponData;
                FillListBox();
                return;
            }
            ItemDataManager.WeaponData.Add(WeaponData.Name, WeaponData);
            lbDetails.Items.Add(WeaponData);
        }

        #region Button Event Handler Region

        void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormWeaponDetails formWeaponDetails = new FormWeaponDetails())
            {
                formWeaponDetails.ShowDialog();

                if (formWeaponDetails.Weapon != null)
                    AddWeapon(formWeaponDetails.Weapon);
            }
        }

        void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                WeaponData data = ItemDataManager.WeaponData[entity];
                WeaponData newData = null;

                using (FormWeaponDetails formWeaponDetails = new FormWeaponDetails())
                {
                    formWeaponDetails.Weapon = data;
                    formWeaponDetails.ShowDialog();

                    if (formWeaponDetails.Weapon == null)
                        return;

                    if (formWeaponDetails.Weapon.Name == entity)
                    {
                        ItemDataManager.WeaponData[entity] = formWeaponDetails.Weapon;
                        FillListBox();
                        return;
                    }

                    newData = formWeaponDetails.Weapon;
                }

                DialogResult result = MessageBox.Show(
                    "Name has changed.  Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if (ItemDataManager.WeaponData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists.  Use Edit to modify the entry.");
                    return;
                }

                lbDetails.Items.Add(newData);
                ItemDataManager.WeaponData.Add(newData.Name, newData);
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
                    ItemDataManager.WeaponData.Remove(entity);

                    if (File.Exists(FormMain.itemPath + @"\Weapon\" + entity + ".xml"))
                        File.Delete(FormMain.itemPath + @"\Weapon\" + entity + ".xml");
                }
            }
        }

        #endregion
    }
}
