using BusinessLayer_DVLD_;
using DVLD.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {
        private enum _enMode { AddNew = 1, Update = 2 };

        private _enMode _Mode = _enMode.AddNew;

        private int _LocalDrivingLicenseApplicationID = -1;

        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;

        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();

            _Mode = _enMode.AddNew;
        }

        public frmAddUpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            _Mode = _enMode.Update;
        }

        private void _FillComboBoxWithLicenseClasses()
        {
            DataTable LicenseClasses = clsLicenseClasses.GetAllLicesneClasses();

            cbLicenseClasses.DataSource = LicenseClasses;

            cbLicenseClasses.ValueMember = "LicenseClassID";
            cbLicenseClasses.DisplayMember = "ClassName";
        }

        private void _ResetDefaultValues()
        {
            _FillComboBoxWithLicenseClasses();

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationTypes.NewLocalDrivingLicenseService).ApplicationFees.ToString();
             

            if(_Mode==_enMode.AddNew)
            {
                lblTitle.Text = "Add New Local Driving License Application";

                this.Text = "New Local Driving License Application";

                tpApplicationInfo.Enabled = false;

                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplications();

                ctrlPersonCardWithFilter1.FilterFocus();



            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";

                this.Text = "Update Local Driving License Application";

                tpApplicationInfo.Enabled = true;

                btnSave.Enabled = true;
            }
        }

        private void _LoadData()
        {

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.Find(_LocalDrivingLicenseApplicationID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;

            if(_LocalDrivingLicenseApplication==null)
            {
                MessageBox.Show("No Local Driving License Application with ID = " + _LocalDrivingLicenseApplication, "Local Driving License Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);

            lblApplicationIID.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();

            cbLicenseClasses.SelectedIndex = cbLicenseClasses.FindString(_LocalDrivingLicenseApplication.LicenseClassInfo.ClassName);

            lblApplicationFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();

            lblCreatedByUser.Text = _LocalDrivingLicenseApplication.UserInfo.UserName;
        }

        private void frmAddUpdateApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == _enMode.Update)
                _LoadData();
        }

        private void btnPersonInfoNext_Click(object sender, EventArgs e)
        {
            if (_Mode == _enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcLocalDrivingLicenseApplicationInfo.SelectedTab = tcLocalDrivingLicenseApplicationInfo.TabPages["tpApplicationInfo"];
                return;
            }

            if(ctrlPersonCardWithFilter1.PersonID!=-1)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcLocalDrivingLicenseApplicationInfo.SelectedTab = tcLocalDrivingLicenseApplicationInfo.TabPages["tpApplicationInfo"];
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int ApplicationID = clsLocalDrivingLicenseApplications.IsLocalDrivingLicenseApplicationActiveByApplicantPersonIDForThisLicenseClass
                  (ctrlPersonCardWithFilter1.PersonID, (int)cbLicenseClasses.SelectedValue);
            if (ApplicationID != -1)
            {
                MessageBox.Show("choose another License Class, the selected person already\n have an active application for the selected class with id = "+ ApplicationID, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsLocalDrivingLicenseApplications.IsLocalDrivingLicenseApplicationCompletedByApplicantPersonIDForThisLicenseClass
                (ctrlPersonCardWithFilter1.PersonID, (int)cbLicenseClasses.SelectedValue))
            {
                MessageBox.Show("This Person Already has a License from this License class ", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;
            _LocalDrivingLicenseApplication.LicenseClassID = (int)cbLicenseClasses.SelectedValue;
            _LocalDrivingLicenseApplication.PaidFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationTypes.NewLocalDrivingLicenseService).ApplicationFees;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.ApplicationTypeID = (int)clsApplicationTypes.enApplicationTypes.NewLocalDrivingLicenseService;

            if(_Mode==_enMode.AddNew)
            {
                _LocalDrivingLicenseApplication.ApplicationStatus = clsApplications.enApplicationStatus.New;
                _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            }

            if(_LocalDrivingLicenseApplication.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Saved",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblApplicationIID.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();
            }
        }
    }
}
