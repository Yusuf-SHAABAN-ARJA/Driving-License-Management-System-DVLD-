namespace DVLD
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msMainMenue = new System.Windows.Forms.MenuStrip();
            this.servicesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDrivingLicensesServices = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNewDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLocalLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemManageApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemManageLocalDrivingLicenseApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.manageApplicationTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemManageTestTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.msMainMenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // msMainMenue
            // 
            this.msMainMenue.AutoSize = false;
            this.msMainMenue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMainMenue.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMainMenue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.servicesToolStripMenuItem1,
            this.peopleToolStripMenuItem2,
            this.driversToolStripMenuItem3,
            this.employeesToolStripMenuItem4,
            this.closeToolStripMenuItem5});
            this.msMainMenue.Location = new System.Drawing.Point(0, 0);
            this.msMainMenue.Name = "msMainMenue";
            this.msMainMenue.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.msMainMenue.Size = new System.Drawing.Size(1421, 89);
            this.msMainMenue.TabIndex = 1;
            this.msMainMenue.Text = "menuStrip1";
            // 
            // servicesToolStripMenuItem1
            // 
            this.servicesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDrivingLicensesServices,
            this.toolStripSeparator2,
            this.toolStripMenuItemManageApplications,
            this.toolStripSeparator3,
            this.manageApplicationTypesToolStripMenuItem,
            this.toolStripMenuItemManageTestTypes});
            this.servicesToolStripMenuItem1.Image = global::DVLD.Properties.Resources.Applications_64;
            this.servicesToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.servicesToolStripMenuItem1.Name = "servicesToolStripMenuItem1";
            this.servicesToolStripMenuItem1.Size = new System.Drawing.Size(208, 85);
            this.servicesToolStripMenuItem1.Text = "Applications";
            // 
            // toolStripMenuItemDrivingLicensesServices
            // 
            this.toolStripMenuItemDrivingLicensesServices.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNewDrivingLicense});
            this.toolStripMenuItemDrivingLicensesServices.Image = global::DVLD.Properties.Resources.Driver_License_48;
            this.toolStripMenuItemDrivingLicensesServices.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemDrivingLicensesServices.Name = "toolStripMenuItemDrivingLicensesServices";
            this.toolStripMenuItemDrivingLicensesServices.Size = new System.Drawing.Size(393, 70);
            this.toolStripMenuItemDrivingLicensesServices.Text = "Driving Licenses Services";
            // 
            // toolStripMenuItemNewDrivingLicense
            // 
            this.toolStripMenuItemNewDrivingLicense.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLocalLicense});
            this.toolStripMenuItemNewDrivingLicense.Image = global::DVLD.Properties.Resources.New_Driving_License_32;
            this.toolStripMenuItemNewDrivingLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemNewDrivingLicense.Name = "toolStripMenuItemNewDrivingLicense";
            this.toolStripMenuItemNewDrivingLicense.Size = new System.Drawing.Size(304, 38);
            this.toolStripMenuItemNewDrivingLicense.Text = "New Driving License";
            // 
            // toolStripMenuItemLocalLicense
            // 
            this.toolStripMenuItemLocalLicense.Image = global::DVLD.Properties.Resources.Local_32;
            this.toolStripMenuItemLocalLicense.Name = "toolStripMenuItemLocalLicense";
            this.toolStripMenuItemLocalLicense.Size = new System.Drawing.Size(222, 32);
            this.toolStripMenuItemLocalLicense.Text = "Local License";
            this.toolStripMenuItemLocalLicense.Click += new System.EventHandler(this.toolStripMenuItemLocalLicense_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(390, 6);
            // 
            // toolStripMenuItemManageApplications
            // 
            this.toolStripMenuItemManageApplications.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemManageLocalDrivingLicenseApplications});
            this.toolStripMenuItemManageApplications.Image = global::DVLD.Properties.Resources.Manage_Applications_64;
            this.toolStripMenuItemManageApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemManageApplications.Name = "toolStripMenuItemManageApplications";
            this.toolStripMenuItemManageApplications.Size = new System.Drawing.Size(393, 70);
            this.toolStripMenuItemManageApplications.Text = "Manage Applications";
            // 
            // toolStripMenuItemManageLocalDrivingLicenseApplications
            // 
            this.toolStripMenuItemManageLocalDrivingLicenseApplications.Image = global::DVLD.Properties.Resources.LocalDriving_License;
            this.toolStripMenuItemManageLocalDrivingLicenseApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemManageLocalDrivingLicenseApplications.Name = "toolStripMenuItemManageLocalDrivingLicenseApplications";
            this.toolStripMenuItemManageLocalDrivingLicenseApplications.Size = new System.Drawing.Size(434, 38);
            this.toolStripMenuItemManageLocalDrivingLicenseApplications.Text = "Local Driving License Applications";
            this.toolStripMenuItemManageLocalDrivingLicenseApplications.Click += new System.EventHandler(this.toolStripMenuItemManageLocalDrivingLicenseApplications_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(390, 6);
            // 
            // manageApplicationTypesToolStripMenuItem
            // 
            this.manageApplicationTypesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageApplicationTypesToolStripMenuItem.Image = global::DVLD.Properties.Resources.Application_Types_64;
            this.manageApplicationTypesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageApplicationTypesToolStripMenuItem.Name = "manageApplicationTypesToolStripMenuItem";
            this.manageApplicationTypesToolStripMenuItem.Size = new System.Drawing.Size(393, 70);
            this.manageApplicationTypesToolStripMenuItem.Text = "Manage Application Types";
            this.manageApplicationTypesToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.manageApplicationTypesToolStripMenuItem.Click += new System.EventHandler(this.manageApplicationTypesToolStripMenuItem_Click);
            // 
            // toolStripMenuItemManageTestTypes
            // 
            this.toolStripMenuItemManageTestTypes.Image = global::DVLD.Properties.Resources.Test_Type_641;
            this.toolStripMenuItemManageTestTypes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemManageTestTypes.Name = "toolStripMenuItemManageTestTypes";
            this.toolStripMenuItemManageTestTypes.Size = new System.Drawing.Size(393, 70);
            this.toolStripMenuItemManageTestTypes.Text = "Manage Test Types";
            this.toolStripMenuItemManageTestTypes.Click += new System.EventHandler(this.toolStripMenuItemManageTestTypes_Click);
            // 
            // peopleToolStripMenuItem2
            // 
            this.peopleToolStripMenuItem2.Image = global::DVLD.Properties.Resources.People_64;
            this.peopleToolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.peopleToolStripMenuItem2.Name = "peopleToolStripMenuItem2";
            this.peopleToolStripMenuItem2.Size = new System.Drawing.Size(153, 85);
            this.peopleToolStripMenuItem2.Text = "People";
            this.peopleToolStripMenuItem2.Click += new System.EventHandler(this.peopleToolStripMenuItem2_Click);
            // 
            // driversToolStripMenuItem3
            // 
            this.driversToolStripMenuItem3.Image = global::DVLD.Properties.Resources.Drivers_64;
            this.driversToolStripMenuItem3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.driversToolStripMenuItem3.Name = "driversToolStripMenuItem3";
            this.driversToolStripMenuItem3.Size = new System.Drawing.Size(158, 85);
            this.driversToolStripMenuItem3.Text = "Drivers";
            // 
            // employeesToolStripMenuItem4
            // 
            this.employeesToolStripMenuItem4.Image = global::DVLD.Properties.Resources.Users_2_64;
            this.employeesToolStripMenuItem4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.employeesToolStripMenuItem4.Name = "employeesToolStripMenuItem4";
            this.employeesToolStripMenuItem4.Size = new System.Drawing.Size(141, 85);
            this.employeesToolStripMenuItem4.Text = "Users";
            this.employeesToolStripMenuItem4.Click += new System.EventHandler(this.employeesToolStripMenuItem4_Click);
            // 
            // closeToolStripMenuItem5
            // 
            this.closeToolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.toolStripSeparator1,
            this.signOutToolStripMenuItem});
            this.closeToolStripMenuItem5.Image = global::DVLD.Properties.Resources.account_settings_64;
            this.closeToolStripMenuItem5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.closeToolStripMenuItem5.Name = "closeToolStripMenuItem5";
            this.closeToolStripMenuItem5.Size = new System.Drawing.Size(251, 85);
            this.closeToolStripMenuItem5.Text = "Account Settings";
            // 
            // currentUserToolStripMenuItem
            // 
            this.currentUserToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.currentUserToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.currentUserToolStripMenuItem.Name = "currentUserToolStripMenuItem";
            this.currentUserToolStripMenuItem.Size = new System.Drawing.Size(275, 38);
            this.currentUserToolStripMenuItem.Text = "&Current User Info";
            this.currentUserToolStripMenuItem.Click += new System.EventHandler(this.currentUserToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = global::DVLD.Properties.Resources.Password_321;
            this.changePasswordToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(275, 38);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(272, 6);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Image = global::DVLD.Properties.Resources.sign_out_32__2;
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(275, 38);
            this.signOutToolStripMenuItem.Text = "Sign out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Logo_Final;
            this.pictureBox1.Location = new System.Drawing.Point(0, 89);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1421, 587);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1421, 676);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.msMainMenue);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.msMainMenue.ResumeLayout(false);
            this.msMainMenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip msMainMenue;
        private System.Windows.Forms.ToolStripMenuItem servicesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemManageTestTypes;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDrivingLicensesServices;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLocalLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemManageApplications;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemManageLocalDrivingLicenseApplications;
    }
}

