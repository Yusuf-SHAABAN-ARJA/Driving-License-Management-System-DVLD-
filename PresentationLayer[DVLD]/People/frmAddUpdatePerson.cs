using BusinessLayer_DVLD_;
using DVLD.Properties;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using DVLD.Global;
using DVLD.Global_Classes;

namespace DVLD.People
{
    public partial class frmAddUpdatePerson : Form
    {

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID); //why

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;  //why


        public enum enMode { AddNewMode = 1, UpdateMode = 2 }; //same but must be public
        public enum enGendor { Male = 0, Female = 1 }; //new

        private enMode _Mode;//same but must be private
        
        private clsPeople _Person;  //same
        private int _PersonID = -1;  //same


     
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();

            _Mode = enMode.UpdateMode;  //new
            _PersonID = PersonID;
        }

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNewMode; //new
        }

       


        private void _ResetDefaultValues()
        {
            _FillComboBoxWithCountries();

            if (_Mode == enMode.AddNewMode)
            {
                lblTitle.Text = "Add New Person";
                _Person = new clsPeople();
            }
            else
            {
                lblTitle.Text = "Update Person";
            }

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            cbCountry.SelectedIndex = cbCountry.FindString("Syria");

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";


        }
        private void _FillComboBoxWithCountries()
        {
            cbCountry.DataSource = clsCountries.GetAllCountries();
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";


            //DataTable dtCountries = clsCountry.GetAllCountries();

            //foreach (DataRow row in dtCountries.Rows)  way of doctor💪
            //{
            //    cbCountry.Items.Add(row["CountryName"]);
            //}
        }
        private void _LoadData()
        {

            _Person = clsPeople.Find(_PersonID);

            if(_Person==null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }


            lblPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gendor==(byte)enGendor.Male)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            cbCountry.SelectedValue = _Person.NationalityCountryID;
            

            if (!string.IsNullOrEmpty(_Person.ImagePath))
                pbPersonImage.ImageLocation = _Person.ImagePath;

            llRemoveImage.Visible = (_Person.ImagePath != "");
        }
       
        private void frmAddEditPersonInfo_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.UpdateMode)
                _LoadData();
           
        }
        private bool _HandlePersonImage()
        {
            if(_Person.ImagePath!=pbPersonImage.ImageLocation)
            {
                if(!string.IsNullOrEmpty(_Person.ImagePath))
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch(IOException)
                    {
                        // we could not delete the file
                        // i'll log it later
                    }
                }

                if(pbPersonImage.ImageLocation!=null)
                {
                    string SourceImageFile = pbPersonImage.ImageLocation;

                    if(clsUtil.CopyImageToProjectImageFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            if (!_HandlePersonImage())  // why
                return;


            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;

            if (rbMale.Checked)
                _Person.Gendor = (short)enGendor.Male;
            else
                _Person.Gendor = (short)enGendor.Female;

            _Person.NationalityCountryID = (int)cbCountry.SelectedValue;

            if (pbPersonImage.ImageLocation != null)
                _Person.ImagePath = pbPersonImage.ImageLocation;
            else
                _Person.ImagePath = "";


            if (_Person.Save())
            {
                lblPersonID.Text = _Person.PersonID.ToString();
                _Mode = enMode.UpdateMode;
                lblTitle.Text = "Update Person";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdSetPersonalImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            ofdSetPersonalImage.FilterIndex = 1;
            ofdSetPersonalImage.RestoreDirectory = true;

            if (ofdSetPersonalImage.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = ofdSetPersonalImage.FileName;
                pbPersonImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
                // ...
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            llRemoveImage.Visible = false;
        }
        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Female_512;
        }
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Male_512;
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender);

            if(string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                epAddEditPerson.SetError(Temp, "This field is required!");
            }
            else
            {
                epAddEditPerson.SetError(Temp, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;


            if (!clsValidation.ValidateEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                epAddEditPerson.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
                epAddEditPerson.SetError(txtEmail, null);
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                epAddEditPerson.SetError(txtNationalNo, "This field is required!");
                return;
            }
            else
            {
                epAddEditPerson.SetError(txtNationalNo, null);
            }

            // not valid to change the nationalno to the used national no
            if (txtNationalNo.Text.Trim() != _Person.NationalNo && clsPeople.isPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                epAddEditPerson.SetError(txtNationalNo, "National Number is used for another person!");
            }
            else
                epAddEditPerson.SetError(txtNationalNo, null);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
    }

