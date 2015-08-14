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
    public partial class FormArmourDetails : Form
    {
        #region Properties and Fields

        public ArmourData Armour
        {
            get;
            set;
        }

        #endregion

        public FormArmourDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormArmourDetails_Load);
            this.FormClosing += new FormClosingEventHandler(FormArmourDetails_FormClosing);

            btnMoveAllowed.Click += new EventHandler(btnMoveAllowed_Click);
            btnRemoveAllowed.Click += new EventHandler(btnRemoveAllowed_Click);
            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        #region Event Handler Region

        void FormArmourDetails_Load(object sender, EventArgs e)
        {
            foreach (string s in FormDetails.EntityDataManager.EntityData.Keys)
                lbClasses.Items.Add(s);

            foreach (ArmourLocation location in Enum.GetValues(typeof(ArmourLocation)))
                cboArmourLocation.Items.Add(location);

            cboArmourLocation.SelectedIndex = 0;

            if (Armour != null)
            {
                tbName.Text = Armour.Name;
                tbType.Text = Armour.Type;
                mtbPrice.Text = Armour.Price.ToString();
                nudWeight.Value = (decimal)Armour.Weight;
                cboArmourLocation.SelectedIndex = (int)Armour.ArmourLocation;
                mtbDefenceValue.Text = Armour.DefenceValue.ToString();
                mtbDefenceModifier.Text = Armour.DefenceModifier.ToString();

                foreach (string s in Armour.AllowableClasses)
                {
                    if (lbClasses.Items.Contains(s))
                        lbClasses.Items.Remove(s);

                    lbAllowedClasses.Items.Add(s);
                }
            }
        }

        void FormArmourDetails_FormClosing(object sender, FormClosingEventArgs e)
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

            Armour = new ArmourData();
            Armour.Name = tbName.Text;
            Armour.Type = tbType.Text;
            Armour.Price = price;
            Armour.Weight = weight;
            Armour.ArmourLocation = (ArmourLocation)cboArmourLocation.SelectedIndex;
            Armour.DefenceValue = defVal;
            Armour.DefenceModifier = defMod;
            Armour.AllowableClasses = allowedClasses.ToArray();

            this.FormClosing -= FormArmourDetails_FormClosing;
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            Armour = null;
            this.FormClosing -= FormArmourDetails_FormClosing;
            this.Close();
        }

        #endregion
    }
}
