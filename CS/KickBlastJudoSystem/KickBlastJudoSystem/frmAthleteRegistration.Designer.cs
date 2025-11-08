namespace KickBlastJudoSystem
{
    partial class frmAthleteRegistration
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAthleteID = new System.Windows.Forms.Label();
            this.txtAthleteID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEmergencyContact = new System.Windows.Forms.Label();
            this.txtEmergencyContact = new System.Windows.Forms.TextBox();
            this.lblEmergencyPhone = new System.Windows.Forms.Label();
            this.txtEmergencyPhone = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblDOB = new System.Windows.Forms.Label();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(180, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(427, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ATHLETE REGISTRATION FORM";
            // 
            // lblAthleteID
            // 
            this.lblAthleteID.AutoSize = true;
            this.lblAthleteID.Location = new System.Drawing.Point(30, 70);
            this.lblAthleteID.Name = "lblAthleteID";
            this.lblAthleteID.Size = new System.Drawing.Size(64, 16);
            this.lblAthleteID.TabIndex = 1;
            this.lblAthleteID.Text = "Athlete ID";
            // 
            // txtAthleteID
            // 
            this.txtAthleteID.BackColor = System.Drawing.Color.LightGray;
            this.txtAthleteID.Location = new System.Drawing.Point(200, 67);
            this.txtAthleteID.Name = "txtAthleteID";
            this.txtAthleteID.ReadOnly = true;
            this.txtAthleteID.Size = new System.Drawing.Size(150, 22);
            this.txtAthleteID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(360, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "(Auto-generated)";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.ForeColor = System.Drawing.Color.Black;
            this.lblFirstName.Location = new System.Drawing.Point(30, 110);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(83, 16);
            this.lblFirstName.TabIndex = 4;
            this.lblFirstName.Text = "First Name: *";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(200, 107);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 22);
            this.txtFirstName.TabIndex = 5;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(30, 150);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(83, 16);
            this.lblLastName.TabIndex = 6;
            this.lblLastName.Text = "Last Name: *";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(200, 147);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 22);
            this.txtLastName.TabIndex = 7;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(30, 230);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(63, 16);
            this.lblGender.TabIndex = 8;
            this.lblGender.Text = "Gender: *";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.cmbGender.Location = new System.Drawing.Point(200, 227);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(200, 24);
            this.cmbGender.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(33, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "─── CONTACT INFORMATION ───";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(30, 306);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(114, 16);
            this.lblContact.TabIndex = 11;
            this.lblContact.Text = "Contact Number: *";
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(200, 300);
            this.txtContact.MaxLength = 15;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(200, 22);
            this.txtContact.TabIndex = 12;
            this.txtContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContact_KeyPress);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(30, 340);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(52, 16);
            this.lblEmail.TabIndex = 13;
            this.lblEmail.Text = "Email: *";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(200, 340);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 22);
            this.txtEmail.TabIndex = 14;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(30, 377);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(69, 16);
            this.lblAddress.TabIndex = 15;
            this.lblAddress.Text = "Address: *";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(200, 377);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(400, 70);
            this.txtAddress.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(30, 468);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "─── EMERGENCY CONTACT ───";
            // 
            // lblEmergencyContact
            // 
            this.lblEmergencyContact.AutoSize = true;
            this.lblEmergencyContact.Location = new System.Drawing.Point(19, 503);
            this.lblEmergencyContact.Name = "lblEmergencyContact";
            this.lblEmergencyContact.Size = new System.Drawing.Size(175, 16);
            this.lblEmergencyContact.TabIndex = 18;
            this.lblEmergencyContact.Text = "Emergency Contact Name: *";
            // 
            // txtEmergencyContact
            // 
            this.txtEmergencyContact.Location = new System.Drawing.Point(200, 500);
            this.txtEmergencyContact.Name = "txtEmergencyContact";
            this.txtEmergencyContact.Size = new System.Drawing.Size(200, 22);
            this.txtEmergencyContact.TabIndex = 19;
            // 
            // lblEmergencyPhone
            // 
            this.lblEmergencyPhone.AutoSize = true;
            this.lblEmergencyPhone.Location = new System.Drawing.Point(19, 541);
            this.lblEmergencyPhone.Name = "lblEmergencyPhone";
            this.lblEmergencyPhone.Size = new System.Drawing.Size(129, 16);
            this.lblEmergencyPhone.TabIndex = 20;
            this.lblEmergencyPhone.Text = "Emergency Phone: *";
            // 
            // txtEmergencyPhone
            // 
            this.txtEmergencyPhone.Location = new System.Drawing.Point(200, 541);
            this.txtEmergencyPhone.MaxLength = 15;
            this.txtEmergencyPhone.Name = "txtEmergencyPhone";
            this.txtEmergencyPhone.Size = new System.Drawing.Size(200, 22);
            this.txtEmergencyPhone.TabIndex = 21;
            this.txtEmergencyPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmergencyPhone_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(150, 600);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 45);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtClear
            // 
            this.txtClear.BackColor = System.Drawing.Color.Orange;
            this.txtClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClear.ForeColor = System.Drawing.Color.White;
            this.txtClear.Location = new System.Drawing.Point(290, 600);
            this.txtClear.Name = "txtClear";
            this.txtClear.Size = new System.Drawing.Size(120, 45);
            this.txtClear.TabIndex = 23;
            this.txtClear.Text = "CLEAR";
            this.txtClear.UseVisualStyleBackColor = false;
            this.txtClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(430, 600);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 45);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(33, 190);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(90, 16);
            this.lblDOB.TabIndex = 25;
            this.lblDOB.Text = "Date of Birth: *";
            // 
            // dtpDOB
            // 
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDOB.Location = new System.Drawing.Point(200, 187);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(200, 22);
            this.dtpDOB.TabIndex = 26;
            // 
            // frmAthleteRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 703);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtEmergencyPhone);
            this.Controls.Add(this.lblEmergencyPhone);
            this.Controls.Add(this.txtEmergencyContact);
            this.Controls.Add(this.lblEmergencyContact);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAthleteID);
            this.Controls.Add(this.lblAthleteID);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAthleteRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Athlete Registration";
            this.Load += new System.EventHandler(this.frmAthleteRegistration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAthleteID;
        private System.Windows.Forms.TextBox txtAthleteID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEmergencyContact;
        private System.Windows.Forms.TextBox txtEmergencyContact;
        private System.Windows.Forms.Label lblEmergencyPhone;
        private System.Windows.Forms.TextBox txtEmergencyPhone;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button txtClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.DateTimePicker dtpDOB;
    }
}