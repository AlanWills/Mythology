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
    public partial class FormShield : FormDetails
    {
        #region Field Region
        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public FormShield()
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

            foreach (string s in FormDetails.ItemDataManager.ShieldData.Keys)
                lbDetails.Items.Add(FormDetails.ItemDataManager.ShieldData[s]);
        }

        private void AddShield(ShieldData ShieldData)
        {
            if (FormDetails.ItemDataManager.ShieldData.ContainsKey(ShieldData.Name))
            {
                DialogResult result = MessageBox.Show(
                    ShieldData.Name + " already exists. Overwrite it?",
                    "Existing shield",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                ItemDataManager.ShieldData[ShieldData.Name] = ShieldData;
                FillListBox();
                return;
            }
            ItemDataManager.ShieldData.Add(ShieldData.Name, ShieldData);
            lbDetails.Items.Add(ShieldData);
        }

        #region Button Event Handler Region

        void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormShieldDetails formShieldDetails = new FormShieldDetails())
            {
                formShieldDetails.ShowDialog();

                if (formShieldDetails.Shield != null)
                    AddShield(formShieldDetails.Shield);
            }
        }

        void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                ShieldData data = ItemDataManager.ShieldData[entity];
                ShieldData newData = null;

                using (FormShieldDetails formShieldDetails = new FormShieldDetails())
                {
                    formShieldDetails.Shield = data;
                    formShieldDetails.ShowDialog();

                    if (formShieldDetails.Shield == null)
                        return;

                    if (formShieldDetails.Shield.Name == entity)
                    {
                        ItemDataManager.ShieldData[entity] = formShieldDetails.Shield;
                        FillListBox();
                        return;
                    }

                    newData = formShieldDetails.Shield;
                }

                DialogResult result = MessageBox.Show(
                    "Name has changed.  Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if (ItemDataManager.ShieldData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists.  Use Edit to modify the entry.");
                    return;
                }

                lbDetails.Items.Add(newData);
                ItemDataManager.ShieldData.Add(newData.Name, newData);
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
                    ItemDataManager.ShieldData.Remove(entity);

                    if (File.Exists(FormMain.itemPath + @"\Shield\" + entity + ".xml"))
                        File.Delete(FormMain.itemPath + @"\Shield\" + entity + ".xml");
                }
            }
        }

        #endregion
    }
}
