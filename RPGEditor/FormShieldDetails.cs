using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using XRpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class FormShieldDetails : Form
    {
        #region Property Region

        public ShieldData Shield
        {
            get;
            set;
        }

        #endregion

        #region Constructor Region

        public FormShieldDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormShieldDetails_Load);
            this.FormClosing += new FormClosingEventHandler(FormShieldDetails_FormClosing);

            btnMoveAllowed.Click += new EventHandler(btnMoveAllowed_Click);
            btnRemoveAllowed.Click += new EventHandler(btnRemoveAllowed_Click);
            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        #endregion

        #region Event Handler Region

        void FormShieldDetails_Load(object sender, EventArgs e)
        {
            foreach (string s in FormDetails.EntityDataManager.EntityData.Keys)
                lbClasses.Items.Add(s);

            if (Shield != null)
            {
                tbName.Text = Shield.Name;
                tbType.Text = Shield.Type;
                mtbPrice.Text = Shield.Price.ToString();
                nudWeight.Value = (decimal)Shield.Weight;
                mtbDefenceValue.Text = Shield.DefenceValue.ToString();
                mtbDefenceModifier.Text = Shield.DefenceModifier.ToString();

                foreach (string s in Shield.AllowableClasses)
                {
                    if (lbClasses.Items.Contains(s))
                        lbClasses.Items.Remove(s);

                    lbAllowedClasses.Items.Add(s);
                }
            }
        }

        void FormShieldDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
        }

        void btnMoveAllowed_Click(object sender, EventArgs e)
        {
            if (lbClasses.SelectedItem != null)
            {
                lbAllowedClasses.Items.Add(lbClasses.SelectedItem);
                lbClasses.Items.RemoveAt(lbClasses.SelectedIndex);
            }
        }

        void btnRemoveAllowed_Click(object sender, EventArgs e)
        {
            if (lbAllowedClasses.SelectedItem != null)
            {
                lbClasses.Items.Add(lbAllowedClasses.SelectedItem);
                lbAllowedClasses.Items.RemoveAt(lbAllowedClasses.SelectedIndex);
            }
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            int price, defVal, defMod;
            float weight;

            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must enter a name for the item.");
                return;
            }

            if (!int.TryParse(mtbPrice.Text, out price))
            {
                MessageBox.Show("Price must be an integer value.");
                return;
            }

            weight = (float)nudWeight.Value;

            if (!int.TryParse(mtbDefenceValue.Text, out defVal))
            {
                MessageBox.Show("Defence value must be an integer value.");
                return;
            }

            if (!int.TryParse(mtbDefenceModifier.Text, out defMod))
            {
                MessageBox.Show("Defence value must be an integer value.");
                return;
            }

            List<string> allowedClasses = new List<string>();

            foreach (object o in lbAllowedClasses.Items)
                allowedClasses.Add(o.ToString());

            Shield = new ShieldData();
            Shield.Name = tbName.Text;
            Shield.Type = tbType.Text;
            Shield.Price = price;
            Shield.Weight = weight;
            Shield.DefenceValue = defVal;
            Shield.DefenceModifier = defMod;
            Shield.AllowableClasses = allowedClasses.ToArray();

            this.FormClosing -= FormShieldDetails_FormClosing;
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            Shield = null;
            this.FormClosing -= FormShieldDetails_FormClosing;
            this.Close();
        }

        #endregion
    }
}
