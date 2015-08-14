﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using XRpgLibrary.ItemClasses;
using XRpgLibrary.TrapClasses;

namespace RpgEditor
{
    public partial class FormChest : FormDetails
    {
        #region Field Region
        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public FormChest()
        {
            InitializeComponent();

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
        }

        #endregion

        #region Event Handler Region

        void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormChestDetails frmChestDetails = new FormChestDetails())
            {
                frmChestDetails.ShowDialog();

                if (frmChestDetails.Chest != null)
                {
                    AddChest(frmChestDetails.Chest);
                }
            }
        }

        void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                ChestData data = ItemDataManager.ChestData[entity];
                ChestData newData = null;

                using (FormChestDetails frmChestData = new FormChestDetails())
                {
                    frmChestData.Chest = data;
                    frmChestData.ShowDialog();

                    if (frmChestData.Chest == null)
                        return;

                    if (frmChestData.Chest.Name == entity)
                    {
                        ItemDataManager.ChestData[entity] = frmChestData.Chest;
                        FillListBox();
                        return;
                    }

                    newData = frmChestData.Chest;
                }

                DialogResult result = MessageBox.Show(
                    "Name has changed. Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if (ItemDataManager.ChestData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use Edit to modify the entry.");
                    return;
                }

                lbDetails.Items.Add(newData);
                ItemDataManager.ChestData.Add(newData.Name, newData);
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
                    ItemDataManager.ChestData.Remove(entity);

                    if (File.Exists(FormMain.chestPath + "\\" + entity + ".xml"))
                        File.Delete(FormMain.chestPath + "\\" + entity + ".xml");
                }
            }
        }

        #endregion

        #region Method Region

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.ItemDataManager.ChestData.Keys)
                lbDetails.Items.Add(FormDetails.ItemDataManager.ChestData[s]);
        }

        private void AddChest(ChestData ChestData)
        {
            if (FormDetails.ItemDataManager.ChestData.ContainsKey(ChestData.Name))
            {
                DialogResult result = MessageBox.Show(
                    ChestData.Name + " already exists. Overwrite it?",
                    "Existing Chest",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                ItemDataManager.ChestData[ChestData.Name] = ChestData;
                FillListBox();
                return;
            }

            ItemDataManager.ChestData.Add(ChestData.Name, ChestData);
            lbDetails.Items.Add(ChestData);
        }

        #endregion
    }
}
