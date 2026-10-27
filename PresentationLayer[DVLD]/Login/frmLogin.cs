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

namespace DVLD
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "This Field Is Required");
                return;
            }
            else
                errorProvider1.SetError(txtUserName, string.Empty);

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "This Field Is Required");
                return;
            }
            else
                errorProvider1.SetError(txtPassword, string.Empty);


            clsUsers User = clsUsers.FindByUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if(User!=null)
            {
                if (chkRememberMe.Checked)
                {
                    clsGlobal.SaveCredentials(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    clsGlobal.DeleteCredentials();
                }



                if (!User.IsActive)
                {
                    txtUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                clsGlobal.CurrentUser = User;
                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();
                _LoadStoredCredentials();
            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void _LoadStoredCredentials()
        {
            string UserName = "", Password = "";
            if (clsGlobal.GetStoredCredentials(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
            {
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
                chkRememberMe.Checked = false;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            _LoadStoredCredentials();
        }

        
    }
}
