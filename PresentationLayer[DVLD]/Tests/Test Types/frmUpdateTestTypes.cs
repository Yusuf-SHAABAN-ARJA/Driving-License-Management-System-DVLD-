using BusinessLayer_DVLD_;
using DVLD.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests.Test_Types
{
   
    public partial class frmUpdateTestTypes : Form
    {
        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;
        private clsTestTypes _TestType;
        public frmUpdateTestTypes(clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();
            this._TestTypeID = TestTypeID;

        }

        private void _LoadData()
        {
            _TestType = clsTestTypes.Find(_TestTypeID);

            if (_TestType == null)
            {
                MessageBox.Show("No TestType with ID = " + _TestTypeID, "Test Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            lblID.Text = ((int)_TestType.TestTypeID).ToString();
            txtTestTypeTitle.Text = _TestType.TestTypeTitle;
            txtTestTypeDescription.Text = _TestType.TestTypeDescription;
            txtTestTypeFees.Text = _TestType.TestTypeFees.ToString();
        }

        private void frmUpdateTestTypes_Load(object sender, EventArgs e)
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

            _TestType.TestTypeTitle = txtTestTypeTitle.Text;
            _TestType.TestTypeDescription = txtTestTypeDescription.Text;
            _TestType.TestTypeFees = Convert.ToDecimal(txtTestTypeFees.Text);

            if (_TestType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtTestTypeTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTestTypeTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeTitle, "This Field is Required");
            }
            else
                errorProvider1.SetError(txtTestTypeTitle, null);
        }

        private void txtTestTypeDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTestTypeDescription.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeDescription, "This Field is Required");
            }
            else
                errorProvider1.SetError(txtTestTypeDescription, null);
        }

        private void txtTestTypeFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTestTypeFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeFees, "This Field is Required");
            }
            else if (!clsValidation.IsNumber(txtTestTypeFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeFees, "Invalid Number");
            }
            else
            {
                errorProvider1.SetError(txtTestTypeFees, null);
            }
        }
    }
}
