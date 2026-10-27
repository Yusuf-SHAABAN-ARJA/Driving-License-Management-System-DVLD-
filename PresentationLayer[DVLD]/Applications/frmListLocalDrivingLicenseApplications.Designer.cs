namespace DVLD.Applications
{
    partial class frmListLocalDrivingLicenseApplications
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
            this.components = new System.ComponentModel.Container();
            this.cmsEditDeleteCancel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemEditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSechduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemScheduleVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemScheduleWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemScheduleStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIssueDrivingLicenseFirstTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAllLocalDrivingLicenseApplications = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btnAddNewLocalDrivingLicenseApplication = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmsEditDeleteCancel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLocalDrivingLicenseApplications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsEditDeleteCancel
            // 
            this.cmsEditDeleteCancel.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsEditDeleteCancel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShowDetails,
            this.toolStripSeparator2,
            this.toolStripMenuItemEditApplication,
            this.toolStripMenuItemDeleteApplication,
            this.toolStripMenuItemCancelApplication,
            this.toolStripMenuItemSechduleTests,
            this.toolStripMenuItemIssueDrivingLicenseFirstTime,
            this.toolStripMenuItemShowLicense,
            this.toolStripMenuItemShowPersonLicenseHistory});
            this.cmsEditDeleteCancel.Name = "cmsAddEditDeleteShowDetailsSendEmailPhoneCall";
            this.cmsEditDeleteCancel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cmsEditDeleteCancel.Size = new System.Drawing.Size(326, 320);
            // 
            // toolStripMenuItemShowDetails
            // 
            this.toolStripMenuItemShowDetails.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemShowDetails.Image = global::DVLD.Properties.Resources.PersonDetails_322;
            this.toolStripMenuItemShowDetails.Name = "toolStripMenuItemShowDetails";
            this.toolStripMenuItemShowDetails.Size = new System.Drawing.Size(325, 36);
            this.toolStripMenuItemShowDetails.Text = "Show Application Details";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(322, 6);
            // 
            // toolStripMenuItemEditApplication
            // 
            this.toolStripMenuItemEditApplication.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemEditApplication.Image = global::DVLD.Properties.Resources.edit_32;
            this.toolStripMenuItemEditApplication.Name = "toolStripMenuItemEditApplication";
            this.toolStripMenuItemEditApplication.Size = new System.Drawing.Size(325, 36);
            this.toolStripMenuItemEditApplication.Text = "Edit Application";
            this.toolStripMenuItemEditApplication.Click += new System.EventHandler(this.toolStripMenuItemEditApplication_Click);
            // 
            // toolStripMenuItemDeleteApplication
            // 
            this.toolStripMenuItemDeleteApplication.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemDeleteApplication.Image = global::DVLD.Properties.Resources.Delete_32_2;
            this.toolStripMenuItemDeleteApplication.Name = "toolStripMenuItemDeleteApplication";
            this.toolStripMenuItemDeleteApplication.Size = new System.Drawing.Size(325, 36);
            this.toolStripMenuItemDeleteApplication.Text = "Delete Application";
            this.toolStripMenuItemDeleteApplication.Click += new System.EventHandler(this.toolStripMenuItemDeleteApplication_Click);
            // 
            // toolStripMenuItemCancelApplication
            // 
            this.toolStripMenuItemCancelApplication.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemCancelApplication.Image = global::DVLD.Properties.Resources.Delete_321;
            this.toolStripMenuItemCancelApplication.Name = "toolStripMenuItemCancelApplication";
            this.toolStripMenuItemCancelApplication.Size = new System.Drawing.Size(325, 36);
            this.toolStripMenuItemCancelApplication.Text = "Cancel Application";
            this.toolStripMenuItemCancelApplication.Click += new System.EventHandler(this.toolStripMenuItemCancelApplication_Click);
            // 
            // toolStripMenuItemSechduleTests
            // 
            this.toolStripMenuItemSechduleTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemScheduleVisionTest,
            this.toolStripMenuItemScheduleWrittenTest,
            this.toolStripMenuItemScheduleStreetTest});
            this.toolStripMenuItemSechduleTests.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemSechduleTests.Image = global::DVLD.Properties.Resources.Schedule_Test_32;
            this.toolStripMenuItemSechduleTests.Name = "toolStripMenuItemSechduleTests";
            this.toolStripMenuItemSechduleTests.Size = new System.Drawing.Size(325, 36);
            this.toolStripMenuItemSechduleTests.Text = "Sechdule Tests";
            // 
            // toolStripMenuItemScheduleVisionTest
            // 
            this.toolStripMenuItemScheduleVisionTest.Image = global::DVLD.Properties.Resources.Vision_Test_Schdule;
            this.toolStripMenuItemScheduleVisionTest.Name = "toolStripMenuItemScheduleVisionTest";
            this.toolStripMenuItemScheduleVisionTest.Size = new System.Drawing.Size(253, 36);
            this.toolStripMenuItemScheduleVisionTest.Text = "Schedule Vision Test";
            this.toolStripMenuItemScheduleVisionTest.Click += new System.EventHandler(this.toolStripMenuItemScheduleVisionTest_Click);
            // 
            // toolStripMenuItemScheduleWrittenTest
            // 
            this.toolStripMenuItemScheduleWrittenTest.Enabled = false;
            this.toolStripMenuItemScheduleWrittenTest.Name = "toolStripMenuItemScheduleWrittenTest";
            this.toolStripMenuItemScheduleWrittenTest.Size = new System.Drawing.Size(253, 36);
            this.toolStripMenuItemScheduleWrittenTest.Text = "Schedule Written Test";
            this.toolStripMenuItemScheduleWrittenTest.Click += new System.EventHandler(this.toolStripMenuItemScheduleWrittenTest_Click);
            // 
            // toolStripMenuItemScheduleStreetTest
            // 
            this.toolStripMenuItemScheduleStreetTest.Enabled = false;
            this.toolStripMenuItemScheduleStreetTest.Name = "toolStripMenuItemScheduleStreetTest";
            this.toolStripMenuItemScheduleStreetTest.Size = new System.Drawing.Size(253, 36);
            this.toolStripMenuItemScheduleStreetTest.Text = "Schedule Street Test";
            // 
            // toolStripMenuItemIssueDrivingLicenseFirstTime
            // 
            this.toolStripMenuItemIssueDrivingLicenseFirstTime.Enabled = false;
            this.toolStripMenuItemIssueDrivingLicenseFirstTime.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemIssueDrivingLicenseFirstTime.Image = global::DVLD.Properties.Resources.IssueDrivingLicense_32;
            this.toolStripMenuItemIssueDrivingLicenseFirstTime.Name = "toolStripMenuItemIssueDrivingLicenseFirstTime";
            this.toolStripMenuItemIssueDrivingLicenseFirstTime.Size = new System.Drawing.Size(325, 36);
            this.toolStripMenuItemIssueDrivingLicenseFirstTime.Text = "Issus Driving License (First Time)";
            this.toolStripMenuItemIssueDrivingLicenseFirstTime.Click += new System.EventHandler(this.toolStripMenuItemIssueDrivingLicenseFirstTime_Click);
            // 
            // toolStripMenuItemShowLicense
            // 
            this.toolStripMenuItemShowLicense.Enabled = false;
            this.toolStripMenuItemShowLicense.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemShowLicense.Name = "toolStripMenuItemShowLicense";
            this.toolStripMenuItemShowLicense.Size = new System.Drawing.Size(325, 36);
            this.toolStripMenuItemShowLicense.Text = "Show License";
            // 
            // toolStripMenuItemShowPersonLicenseHistory
            // 
            this.toolStripMenuItemShowPersonLicenseHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemShowPersonLicenseHistory.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_32;
            this.toolStripMenuItemShowPersonLicenseHistory.Name = "toolStripMenuItemShowPersonLicenseHistory";
            this.toolStripMenuItemShowPersonLicenseHistory.Size = new System.Drawing.Size(325, 36);
            this.toolStripMenuItemShowPersonLicenseHistory.Text = "Show Person License History";
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterValue.Location = new System.Drawing.Point(327, 283);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(254, 22);
            this.txtFilterValue.TabIndex = 12;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.Color.Gainsboro;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.DropDownWidth = 210;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(122, 281);
            this.cbFilterBy.Margin = new System.Windows.Forms.Padding(5);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(192, 24);
            this.cbFilterBy.TabIndex = 11;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 283);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Filter By:";
            // 
            // dgvAllLocalDrivingLicenseApplications
            // 
            this.dgvAllLocalDrivingLicenseApplications.AllowUserToAddRows = false;
            this.dgvAllLocalDrivingLicenseApplications.AllowUserToDeleteRows = false;
            this.dgvAllLocalDrivingLicenseApplications.AllowUserToOrderColumns = true;
            this.dgvAllLocalDrivingLicenseApplications.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAllLocalDrivingLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllLocalDrivingLicenseApplications.ContextMenuStrip = this.cmsEditDeleteCancel;
            this.dgvAllLocalDrivingLicenseApplications.Location = new System.Drawing.Point(14, 312);
            this.dgvAllLocalDrivingLicenseApplications.Margin = new System.Windows.Forms.Padding(5);
            this.dgvAllLocalDrivingLicenseApplications.Name = "dgvAllLocalDrivingLicenseApplications";
            this.dgvAllLocalDrivingLicenseApplications.ReadOnly = true;
            this.dgvAllLocalDrivingLicenseApplications.RowHeadersWidth = 51;
            this.dgvAllLocalDrivingLicenseApplications.Size = new System.Drawing.Size(1341, 348);
            this.dgvAllLocalDrivingLicenseApplications.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 670);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "# Records:   ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(419, 227);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(537, 37);
            this.label1.TabIndex = 18;
            this.label1.Text = "Local Driving License Applications";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(122, 670);
            this.lblRecordsCount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(0, 20);
            this.lblRecordsCount.TabIndex = 19;
            // 
            // cbStatus
            // 
            this.cbStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.DropDownWidth = 210;
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "All",
            "New",
            "Completed",
            "Canceled"});
            this.cbStatus.Location = new System.Drawing.Point(327, 281);
            this.cbStatus.Margin = new System.Windows.Forms.Padding(5);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(254, 24);
            this.cbStatus.TabIndex = 20;
            this.cbStatus.Visible = false;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // btnAddNewLocalDrivingLicenseApplication
            // 
            this.btnAddNewLocalDrivingLicenseApplication.FlatAppearance.BorderSize = 2;
            this.btnAddNewLocalDrivingLicenseApplication.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddNewLocalDrivingLicenseApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewLocalDrivingLicenseApplication.Image = global::DVLD.Properties.Resources.New_Application_64;
            this.btnAddNewLocalDrivingLicenseApplication.Location = new System.Drawing.Point(1275, 227);
            this.btnAddNewLocalDrivingLicenseApplication.Margin = new System.Windows.Forms.Padding(5);
            this.btnAddNewLocalDrivingLicenseApplication.Name = "btnAddNewLocalDrivingLicenseApplication";
            this.btnAddNewLocalDrivingLicenseApplication.Size = new System.Drawing.Size(80, 80);
            this.btnAddNewLocalDrivingLicenseApplication.TabIndex = 21;
            this.btnAddNewLocalDrivingLicenseApplication.UseVisualStyleBackColor = true;
            this.btnAddNewLocalDrivingLicenseApplication.Click += new System.EventHandler(this.btnAddNewLocalDrivingLicenseApplication_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1234, 670);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 45);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.Local_321;
            this.pictureBox2.Location = new System.Drawing.Point(769, 43);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 46);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Applications1;
            this.pictureBox1.Location = new System.Drawing.Point(551, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 208);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // frmListLocalDrivingLicenseApplications
            // 
            this.AcceptButton = this.btnAddNewLocalDrivingLicenseApplication;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1369, 724);
            this.Controls.Add(this.btnAddNewLocalDrivingLicenseApplication);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvAllLocalDrivingLicenseApplications);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListLocalDrivingLicenseApplications";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmListLocalDrivingLicenseApplications_Load);
            this.cmsEditDeleteCancel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLocalDrivingLicenseApplications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsEditDeleteCancel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowDetails;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditApplication;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCancelApplication;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAllLocalDrivingLicenseApplications;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Button btnAddNewLocalDrivingLicenseApplication;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSechduleTests;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIssueDrivingLicenseFirstTime;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowLicense;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemScheduleVisionTest;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemScheduleWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemScheduleStreetTest;
    }
}