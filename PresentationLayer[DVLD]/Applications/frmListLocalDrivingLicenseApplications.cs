using BusinessLayer_DVLD_;
using DVLD.Tests.Test_Appointments;
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
    public partial class frmListLocalDrivingLicenseApplications : Form
    {

        private DataTable _AllLocalDrivingLicenseApplications = new DataTable();
        private DataTable _AllLocalDrivingLicenseApplicationsSpecificColumns = new DataTable();
      

        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void _RefreshLocalDrivingLicenseApplicationsList()
        {
            _AllLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.GelAllLocalDrivingLicenseApplications();
            _AllLocalDrivingLicenseApplicationsSpecificColumns = _AllLocalDrivingLicenseApplications.DefaultView.ToTable(false, "LocalDrivingLicenseApplicationID",
                "ClassName", "NationalNo", "FullName", "ApplicationDate", "PassedTests", "StatusCaption", "Status");

            dgvAllLocalDrivingLicenseApplications.DataSource = _AllLocalDrivingLicenseApplicationsSpecificColumns;

            lblRecordsCount.Text = dgvAllLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {

            cbFilterBy.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
            _AllLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.GelAllLocalDrivingLicenseApplications();
            _AllLocalDrivingLicenseApplicationsSpecificColumns = _AllLocalDrivingLicenseApplications.DefaultView.ToTable(false, "LocalDrivingLicenseApplicationID",
                "ClassName", "NationalNo", "FullName", "ApplicationDate", "PassedTests", "StatusCaption","Status");

            dgvAllLocalDrivingLicenseApplications.DataSource = _AllLocalDrivingLicenseApplicationsSpecificColumns;

            if(dgvAllLocalDrivingLicenseApplications.Rows.Count>0)
            {
                dgvAllLocalDrivingLicenseApplications.Columns[0].HeaderText = "L.D.L.AppID";
                dgvAllLocalDrivingLicenseApplications.Columns[0].Width = 120;

                dgvAllLocalDrivingLicenseApplications.Columns[1].HeaderText = "Driving Class";
                dgvAllLocalDrivingLicenseApplications.Columns[1].Width = 300;

                dgvAllLocalDrivingLicenseApplications.Columns[2].HeaderText = "National No.";
                dgvAllLocalDrivingLicenseApplications.Columns[2].Width = 140;

                dgvAllLocalDrivingLicenseApplications.Columns[3].HeaderText = "Full Name";
                dgvAllLocalDrivingLicenseApplications.Columns[3].Width = 300;

                dgvAllLocalDrivingLicenseApplications.Columns[4].HeaderText = "Application Date";
                dgvAllLocalDrivingLicenseApplications.Columns[4].Width = 200;

                dgvAllLocalDrivingLicenseApplications.Columns[5].HeaderText = "Passed Tests";
                dgvAllLocalDrivingLicenseApplications.Columns[5].Width = 120;

                dgvAllLocalDrivingLicenseApplications.Columns[6].HeaderText = "Status";
                dgvAllLocalDrivingLicenseApplications.Columns[6].Width = 100;

                dgvAllLocalDrivingLicenseApplications.Columns["Status"].Visible = false;

                lblRecordsCount.Text = dgvAllLocalDrivingLicenseApplications.Rows.Count.ToString();
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None" && cbFilterBy.Text != "Status");
            cbStatus.Visible = cbFilterBy.Text == "Status";

            if(txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
            else
            {
                txtFilterValue.Text = string.Empty;
            }

            if (cbStatus.Visible)
                cbStatus.Focus();
            else
                cbStatus.SelectedIndex = 0;
               
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterValue = string.Empty;
            string FilterColumn = "Status";

            switch (cbStatus.Text)
            {
                case "New":
                    FilterValue = "1";
                    break;
                case "Completed":
                    FilterValue = "2";
                    break;
                case "Canceled":
                    FilterValue = "3";
                    break;
                default:
                    break;
            }

            if(cbStatus.Text=="All")
            {
                _AllLocalDrivingLicenseApplicationsSpecificColumns.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvAllLocalDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }

            _AllLocalDrivingLicenseApplicationsSpecificColumns.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            lblRecordsCount.Text = dgvAllLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = string.Empty;

            switch(cbFilterBy.Text)
            {
                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (FilterColumn == "None" || string.IsNullOrEmpty(txtFilterValue.Text.Trim()) || FilterColumn == "Status")
            {
                _AllLocalDrivingLicenseApplicationsSpecificColumns.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvAllLocalDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }

            if (FilterColumn != "LocalDrivingLicenseApplicationID")
            {
                _AllLocalDrivingLicenseApplicationsSpecificColumns.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilterValue.Text.Trim());
                lblRecordsCount.Text = dgvAllLocalDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }

            _AllLocalDrivingLicenseApplicationsSpecificColumns.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            lblRecordsCount.Text = dgvAllLocalDrivingLicenseApplications.Rows.Count.ToString();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == cbFilterBy.FindString("L.D.L.AppID"))
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void btnAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication();
            frm.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void toolStripMenuItemCancelApplication_Click(object sender, EventArgs e)
        {
            if(DialogResult.OK==MessageBox.Show("Are you sure you want to cancel this application?","Confirm",MessageBoxButtons.OKCancel,MessageBoxIcon.Question))
            {
                if (clsLocalDrivingLicenseApplications.CancelLocalDrivingLicenseApplication((int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Application Canceled Successfully", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshLocalDrivingLicenseApplicationsList();
                }
            }
        }

        private void toolStripMenuItemEditApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication((int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void toolStripMenuItemDeleteApplication_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Are you sure you want to delete this application?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                if (clsLocalDrivingLicenseApplications.DeleteLocalDrivingLicenseApplication((int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Application deleted Successfully", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshLocalDrivingLicenseApplicationsList();
                }
                else
                    MessageBox.Show("Faild To Delete Application", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripMenuItemScheduleVisionTest_Click(object sender, EventArgs e)
        {
            frmTestAppointments frm = new frmTestAppointments(((int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value),clsTestTypes.enTestType.VisionTest);
            frm.ShowDialog();
            
        }

        private void toolStripMenuItemScheduleWrittenTest_Click(object sender, EventArgs e)
        {
            frmTestAppointments frm = new frmTestAppointments(((int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value), clsTestTypes.enTestType.VisionTest);
            frm.ShowDialog();
        }


        private void toolStripMenuItemIssueDrivingLicenseFirstTime_Click(object sender, EventArgs e)
        {
            frmTestAppointments frm = new frmTestAppointments(((int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value), clsTestTypes.enTestType.WrittenTest);
            frm.ShowDialog();
        }

        
    }
}
