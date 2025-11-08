namespace KickBlastJudoSystem
{
    partial class frmMainDashboard
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnAthleteReg = new System.Windows.Forms.Button();
            this.btnFeeCalculator = new System.Windows.Forms.Button();
            this.btnViewRegistrations = new System.Windows.Forms.Button();
            this.btnManageAthletes = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.DarkBlue;
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(904, 93);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(702, 50);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "KICKBLAST JUDO - MAIN DASHBOARD";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.DarkBlue;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(20, 70);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(133, 23);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome, Admin";
            // 
            // btnAthleteReg
            // 
            this.btnAthleteReg.BackColor = System.Drawing.Color.LightBlue;
            this.btnAthleteReg.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAthleteReg.Location = new System.Drawing.Point(550, 144);
            this.btnAthleteReg.Name = "btnAthleteReg";
            this.btnAthleteReg.Size = new System.Drawing.Size(282, 60);
            this.btnAthleteReg.TabIndex = 2;
            this.btnAthleteReg.Text = "Register New Athlete";
            this.btnAthleteReg.UseVisualStyleBackColor = false;
            this.btnAthleteReg.Click += new System.EventHandler(this.btnAthleteReg_Click);
            // 
            // btnFeeCalculator
            // 
            this.btnFeeCalculator.BackColor = System.Drawing.Color.LightGreen;
            this.btnFeeCalculator.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeeCalculator.Location = new System.Drawing.Point(550, 252);
            this.btnFeeCalculator.Name = "btnFeeCalculator";
            this.btnFeeCalculator.Size = new System.Drawing.Size(282, 60);
            this.btnFeeCalculator.TabIndex = 3;
            this.btnFeeCalculator.Text = "Calculate Monthly Fees";
            this.btnFeeCalculator.UseVisualStyleBackColor = false;
            this.btnFeeCalculator.Click += new System.EventHandler(this.btnFeeCalculator_Click);
            // 
            // btnViewRegistrations
            // 
            this.btnViewRegistrations.BackColor = System.Drawing.Color.LightPink;
            this.btnViewRegistrations.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewRegistrations.Location = new System.Drawing.Point(550, 462);
            this.btnViewRegistrations.Name = "btnViewRegistrations";
            this.btnViewRegistrations.Size = new System.Drawing.Size(282, 62);
            this.btnViewRegistrations.TabIndex = 4;
            this.btnViewRegistrations.Text = "View All Registrations";
            this.btnViewRegistrations.UseVisualStyleBackColor = false;
            this.btnViewRegistrations.Click += new System.EventHandler(this.btnViewRegistrations_Click);
            // 
            // btnManageAthletes
            // 
            this.btnManageAthletes.BackColor = System.Drawing.Color.Thistle;
            this.btnManageAthletes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageAthletes.Location = new System.Drawing.Point(550, 357);
            this.btnManageAthletes.Name = "btnManageAthletes";
            this.btnManageAthletes.Size = new System.Drawing.Size(282, 54);
            this.btnManageAthletes.TabIndex = 5;
            this.btnManageAthletes.Text = "Manage Athletes";
            this.btnManageAthletes.UseVisualStyleBackColor = false;
            this.btnManageAthletes.Click += new System.EventHandler(this.btnManageAthletes_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(550, 567);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(282, 55);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KickBlastJudoSystem.Properties.Resources.istockphoto_95946334_612x612;
            this.pictureBox1.Location = new System.Drawing.Point(0, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(531, 635);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // frmMainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(904, 753);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManageAthletes);
            this.Controls.Add(this.btnViewRegistrations);
            this.Controls.Add(this.btnFeeCalculator);
            this.Controls.Add(this.btnAthleteReg);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.panelHeader);
            this.Name = "frmMainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KickBlast Judo - Main Dashboard";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnAthleteReg;
        private System.Windows.Forms.Button btnFeeCalculator;
        private System.Windows.Forms.Button btnViewRegistrations;
        private System.Windows.Forms.Button btnManageAthletes;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}