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

namespace DVLD.People
{
    public partial class frmListPeople : Form
    {
        private static DataTable _dtAllPeople = clsPeople.GetAllPeople(); // added

        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");
        

        public frmListPeople()
        {
            InitializeComponent();
        }

       

        private void _RefreshPeopleList()
        {
            _dtAllPeople = clsPeople.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");
            dgvAllPeople.DataSource = _dtPeople;
            lblRecordsNumber.Text = dgvAllPeople.Rows.Count.ToString();
          
        }

       
        private void frmListPeople_Load(object sender, EventArgs e)
        {
            dgvAllPeople.DataSource = _dtPeople;
            lblRecordsNumber.Text = dgvAllPeople.Rows.Count.ToString();

            cbFilterBy.SelectedIndex = 0;
            if(dgvAllPeople.Rows.Count>0)
            {

                dgvAllPeople.Columns[0].HeaderText = "Person ID";
                dgvAllPeople.Columns[0].Width = 110;

                dgvAllPeople.Columns[1].HeaderText = "National No.";
                dgvAllPeople.Columns[1].Width = 120;


                dgvAllPeople.Columns[2].HeaderText = "First Name";
                dgvAllPeople.Columns[2].Width = 120;

                dgvAllPeople.Columns[3].HeaderText = "Second Name";
                dgvAllPeople.Columns[3].Width = 140;


                dgvAllPeople.Columns[4].HeaderText = "Third Name";
                dgvAllPeople.Columns[4].Width = 120;

                dgvAllPeople.Columns[5].HeaderText = "Last Name";
                dgvAllPeople.Columns[5].Width = 120;

                dgvAllPeople.Columns[6].HeaderText = "Gendor";
                dgvAllPeople.Columns[6].Width = 120;

                dgvAllPeople.Columns[7].HeaderText = "Date Of Birth";
                dgvAllPeople.Columns[7].Width = 140;

                dgvAllPeople.Columns[8].HeaderText = "Nationality";
                dgvAllPeople.Columns[8].Width = 120;


                dgvAllPeople.Columns[9].HeaderText = "Phone";
                dgvAllPeople.Columns[9].Width = 120;


                dgvAllPeople.Columns[10].HeaderText = "Email";
                dgvAllPeople.Columns[10].Width = 170;
            }
        }

        

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = string.Empty;

            switch(cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }


            if(txtFilterValue.Text.Trim()==""||FilterColumn=="None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordsNumber.Text = dgvAllPeople.Rows.Count.ToString();
                return;
            }

            if(FilterColumn=="PersonID")
            _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsNumber.Text = dgvAllPeople.Rows.Count.ToString();
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }



        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(); // there is a different
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();  //true
            _RefreshPeopleList();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();     //true
            _RefreshPeopleList();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Are you sure you want to delete this person [" + dgvAllPeople.CurrentRow.Cells[0].Value+"]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                if (clsPeople.DeletePerson((int)dgvAllPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully", "Successful", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    _RefreshPeopleList();   //true
                }
                else
                {
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvAllPeople.CurrentRow.Cells[0].Value); // true
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();  //true
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dgvAllPeople_DoubleClick(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvAllPeople.CurrentRow.Cells[0].Value); // true
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (cbFilterBy.Text == "Person ID")   //validation
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
