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
    public partial class frmTestAppointments : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        private clsTestTypes.enTestType _TestType;

        private DataTable _dtAllAppointments = new DataTable();
      
        public frmTestAppointments(int LocalDrivingLicenseApplicationID,clsTestTypes.enTestType TestType)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            _TestType = TestType;
        }

        private void _SetDefaultValue()
        {
            ctrlDrivingLicenseApplicationInfo1.LoadDrivingLicenseInfo(_LocalDrivingLicenseApplicationID);

            switch(_TestType)
            {
                case clsTestTypes.enTestType.VisionTest:
                    {
                        this.Text = "Vision Test Appointments";
                        this.lblTitle.Text = "Vision Test Appointments";
                        this.pbTestType.Image = Resources.Vision_512;
                    }
                    break;
                case clsTestTypes.enTestType.WrittenTest:
                    {
                        this.Text = "Written Test Appointments";
                        this.lblTitle.Text = "Written Test Appointments";
                        this.pbTestType.Image = Resources.Written_Test_512;
                    }
                    break;
                case clsTestTypes.enTestType.StreetTest:
                    {
                        this.Text = "Street Test Appointments";
                        this.lblTitle.Text = "Street Test Appointments";
                        this.pbTestType.Image = Resources.driving_test_512;
                    }
                    break;
                        
            }
        }

        private void _RefreshAppointmentsList()
        {
            _dtAllAppointments = clsTestAppointments.GetAllTestAppointmentsByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID, (byte)_TestType);


            dgvAppointmentsList.DataSource = _dtAllAppointments;

            lblRecordsCount.Text = dgvAppointmentsList.Rows.Count.ToString();
        }

        private void frmTestAppointments_Load(object sender, EventArgs e)
        {
            _SetDefaultValue();

            _dtAllAppointments = clsTestAppointments.GetAllTestAppointmentsByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID,(byte)_TestType);
            

            dgvAppointmentsList.DataSource = _dtAllAppointments;

            if(dgvAppointmentsList.Rows.Count>0)
            {
                dgvAppointmentsList.Columns[0].HeaderText = "Appointment ID";
                dgvAppointmentsList.Columns[0].Width = 120;

                dgvAppointmentsList.Columns[1].HeaderText = "Application Date";
                dgvAppointmentsList.Columns[1].Width = 120;

                dgvAppointmentsList.Columns[2].HeaderText = "Paid Fees";
                dgvAppointmentsList.Columns[2].Width = 120;

                dgvAppointmentsList.Columns[3].HeaderText = "Is Locked";
                dgvAppointmentsList.Columns[3].Width = 100;

                lblRecordsCount.Text = dgvAppointmentsList.Rows.Count.ToString();
            }

        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            if(clsTestAppointments.IsAppointmentActive(_LocalDrivingLicenseApplicationID,(byte)_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, you cannot add new appointment"
                    , "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
            }

            if(clsTests.IsPassedTest(_LocalDrivingLicenseApplicationID,(byte)_TestType))
            {
                MessageBox.Show("This Person already passed this test before, you can only retake faild tests"
                    , "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            
            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID,_TestType);
            frm.ShowDialog();
            _RefreshAppointmentsList();
        }
    }
}
