using BusinessLayer_DVLD_;
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
    public partial class frmListApplicationTypes : Form
    {

        private static DataTable _dtAllApplicationTypes;
        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void _RefreshApplicationTypesList()
        {
            DataTable dtAllApplicationTypes = clsApplicationTypes.GetAllApllicationTypes();

            dgvAllApplicationTypes.DataSource = dtAllApplicationTypes;
            lblRecordsCount.Text = dgvAllApplicationTypes.Rows.Count.ToString();
        }

        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            _dtAllApplicationTypes = clsApplicationTypes.GetAllApllicationTypes();
            dgvAllApplicationTypes.DataSource = _dtAllApplicationTypes;

            if(dgvAllApplicationTypes.Rows.Count>0)
            {
                dgvAllApplicationTypes.Columns[0].HeaderText = "ID";
                dgvAllApplicationTypes.Columns[0].Width = 120;

                dgvAllApplicationTypes.Columns[1].HeaderText = "Title";
                dgvAllApplicationTypes.Columns[1].Width = 400;

                dgvAllApplicationTypes.Columns[2].HeaderText = "Fees";
                dgvAllApplicationTypes.Columns[2].Width = 120;

                lblRecordsCount.Text = dgvAllApplicationTypes.Rows.Count.ToString();
            }
        }

        private void toolStripMenuItemUpdateApplicationTypes_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationTypes frm = new frmUpdateApplicationTypes((int)dgvAllApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshApplicationTypesList();
        }

        
    }
}
