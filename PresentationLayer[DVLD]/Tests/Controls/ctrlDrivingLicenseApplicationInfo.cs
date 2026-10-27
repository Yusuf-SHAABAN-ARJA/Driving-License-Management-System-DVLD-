using BusinessLayer_DVLD_;
using DVLD.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        private bool _ShowLicenseInfoEnabled = false;

        public bool ShowLicenseInfoEnabled { 
            get 
            {
                return _ShowLicenseInfoEnabled;
            }
            set
            {
                _ShowLicenseInfoEnabled = value;
                llShowLicenseInfo.Enabled = _ShowLicenseInfoEnabled;
            }
        }

        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;

        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadDrivingLicenseInfo(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.Find(LocalDrivingLicenseApplicationID);

            if(_LocalDrivingLicenseApplication==null)
            {
                MessageBox.Show("No Local Driving License Application with ID = " + LocalDrivingLicenseApplicationID, " Local Driving License Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            llViewPersonInfo.Enabled = true;
            lblDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblClassName.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblPassedTests.Text = (clsTests.GetNumberOfPassedTestsByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID)).ToString() + "/3";
            
           

            lblApplicationID.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();
            lblApplicationStatus.Text = _LocalDrivingLicenseApplication.ApplicationStatus.ToString();
            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblApplicationType.Text = _LocalDrivingLicenseApplication.ApplicationTypeInfo.ApplicationTypeTitle;
            lblApplicantPersonName.Text = _LocalDrivingLicenseApplication.PersonInfo.FullName;
            lblApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            lblApplicationLastStatusDate.Text = _LocalDrivingLicenseApplication.LastStatusDate.ToShortDateString();
            lblCreatedByUserName.Text = _LocalDrivingLicenseApplication.UserInfo.UserName;

        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            frm.ShowDialog();
        }
    }
}
