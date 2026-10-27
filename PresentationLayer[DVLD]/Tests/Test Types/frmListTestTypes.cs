using BusinessLayer_DVLD_;
using DVLD.ApplicationTypes;
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
    public partial class frmListTestTypes : Form
    {
        private static DataTable _dtAllTestTypes;
        public frmListTestTypes()
        {
            InitializeComponent();
        }

        private void _RefreshTestTypesList()
        {
            DataTable dtAllTestTypes = clsTestTypes.GetAllTestTypes();

            dgvAllTestTypes.DataSource = dtAllTestTypes;
            lblRecordsCount.Text = dgvAllTestTypes.Rows.Count.ToString();
        }

        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            _dtAllTestTypes = clsTestTypes.GetAllTestTypes();
            dgvAllTestTypes.DataSource = _dtAllTestTypes;

            if (dgvAllTestTypes.Rows.Count > 0)
            {
                dgvAllTestTypes.Columns[0].HeaderText = "ID";
                dgvAllTestTypes.Columns[0].Width = 120;

                dgvAllTestTypes.Columns[1].HeaderText = "Title";
                dgvAllTestTypes.Columns[1].Width = 200;

                dgvAllTestTypes.Columns[2].HeaderText = "Description";
                dgvAllTestTypes.Columns[2].Width = 400;

                dgvAllTestTypes.Columns[3].HeaderText = "Fees";
                dgvAllTestTypes.Columns[3].Width = 120;

                lblRecordsCount.Text = dgvAllTestTypes.Rows.Count.ToString();
            }
        }

        private void toolStripMenuItemUpdateTestTypes_Click(object sender, EventArgs e)
        {
            frmUpdateTestTypes frm = new frmUpdateTestTypes((clsTestTypes.enTestType)dgvAllTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshTestTypesList();
        }
    }
}
