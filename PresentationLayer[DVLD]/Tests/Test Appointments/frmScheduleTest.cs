using BusinessLayer_DVLD_;
using DVLD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests.Test_Appointments
{
    public partial class frmScheduleTest : Form
    {
        private clsTestTypes.enTestType _TestType;

        private int _LocalDrivingLicenseApplicationID = -1;

        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplicationInfo;

        private enum _enMode { AddNew = 1, Update = 2 };

        private _enMode _Mode = _enMode.AddNew;
        public frmScheduleTest(int LocalDrivingLicenseApplicationID,clsTestTypes.enTestType TestType)
        {
            InitializeComponent();

            _TestType = TestType;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void _ResetDefaultValues()
        {  
            _LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplications.Find(_LocalDrivingLicenseApplicationID);

            lblTestFees.Text = clsTestTypes.Find(_TestType).TestTypeFees.ToString();
            dtpDate.Value = DateTime.Now;
            lblTrialCount.Text = clsTests.GetNumberOfTrials(_LocalDrivingLicenseApplicationID, (byte)_TestType).ToString();
            lblDrivingLicenseApplicationID.Text =
                _LocalDrivingLicenseApplicationInfo.LocalDrivingLicenseApplicationID.ToString();

            lblClassName.Text = _LocalDrivingLicenseApplicationInfo.LicenseClassInfo.ClassName;
            lblName.Text = _LocalDrivingLicenseApplicationInfo.PersonInfo.FullName;

            gbRetakeTestInfo.Enabled = false;

            switch (_TestType)
            {
                case clsTestTypes.enTestType.VisionTest:
                    {
                        gbScheduleTest.Text = "Vision Test";
                        pbTestType.Image = Resources.Vision_512;
                        lblTestScheduleTitle.Text = "Schedule Vision Test";
                    }
                    break;
                case clsTestTypes.enTestType.WrittenTest:
                    {
                        gbScheduleTest.Text = "Written Test";
                        pbTestType.Image = Resources.Written_Test_512;
                        lblTestScheduleTitle.Text = "Schedule Written Test";
                    }
                    break;
                case clsTestTypes.enTestType.StreetTest:
                    {
                        gbScheduleTest.Text = "Street Test";
                        pbTestType.Image = Resources.driving_test_512;
                        lblTestScheduleTitle.Text = "Schedule Street Test";
                    }
                    break;
            }
        }

        
        private void frmScheduleTest_Load(object sender, EventArgs e)
        {






            _ResetDefaultValues();



        }
    }
}
