using BusinessLayer_DVLD_;
using DVLD.Global;
using DVLD.People.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.ApplicationTypes
{
    public partial class frmUpdateApplicationTypes : Form
    {
        private int _ApplicationTypeID = -1;
        private clsApplicationTypes _ApplicationType;
        public frmUpdateApplicationTypes(int ApplicationTypeID)
        {
            InitializeComponent();

            this._ApplicationTypeID = ApplicationTypeID;
        }

        private void _LoadData()
        {
            _ApplicationType = clsApplicationTypes.Find(_ApplicationTypeID);

            if (_ApplicationType == null)
            {
                MessageBox.Show("No Application with ID = " + _ApplicationType, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            lblID.Text = _ApplicationType.ApplicationTypeID.ToString();
            txtApplicationTypeTitle.Text = _ApplicationType.ApplicationTypeTitle;
            txtApplicationFees.Text = _ApplicationType.ApplicationFees.ToString();
        }

        private void frmUpdateApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _ApplicationType.ApplicationTypeTitle = txtApplicationTypeTitle.Text;
            _ApplicationType.ApplicationFees = Convert.ToDecimal(txtApplicationFees.Text);

            if (_ApplicationType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtApplicationTypeTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar);
        }

        private void txtApplicationFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtApplicationTypeTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtApplicationTypeTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationTypeTitle, "This Field is Required");
            }
            else
                errorProvider1.SetError(txtApplicationTypeTitle, null);
        }

        private void txtApplicationFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtApplicationFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationFees, "This Field is Required");
            }
            else if (!clsValidation.IsNumber(txtApplicationFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationFees, "Invalid Number");
            }
            else
            {
                errorProvider1.SetError(txtApplicationFees, null);
            }
                
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
