namespace KickBlastJudoSystem
{
    partial class frmFeeCalculator
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
            this.btnSearchAthlete = new System.Windows.Forms.Button();
            this.lblAthleteName = new System.Windows.Forms.Label();
            this.txtAthleteName = new System.Windows.Forms.TextBox();
            this.lblTrainingPlan = new System.Windows.Forms.Label();
            this.cmbTrainingPlan = new System.Windows.Forms.ComboBox();
            this.lblCurrentWeight = new System.Windows.Forms.Label();
            this.txtCurrentWeight = new System.Windows.Forms.TextBox();
            this.lblWeightCategory = new System.Windows.Forms.Label();
            this.cmbWeightCategory = new System.Windows.Forms.ComboBox();
            this.lblCompetitions = new System.Windows.Forms.Label();
            this.txtCompetitions = new System.Windows.Forms.TextBox();
            this.lblPrivateCoaching = new System.Windows.Forms.Label();
            this.txtPrivateCoaching = new System.Windows.Forms.TextBox();
            this.lblBillMonth = new System.Windows.Forms.Label();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.dgvOutput = new System.Windows.Forms.DataGridView();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCLose = new System.Windows.Forms.Button();
            this.grpOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(121, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(644, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "KICKBLAST JUDO - MONTHLY FEE CALCULATOR";
            // 
            // lblAthleteID
            // 
            this.lblAthleteID.AutoSize = true;
            this.lblAthleteID.Location = new System.Drawing.Point(30, 80);
            this.lblAthleteID.Name = "lblAthleteID";
            this.lblAthleteID.Size = new System.Drawing.Size(75, 16);
            this.lblAthleteID.TabIndex = 1;
            this.lblAthleteID.Text = "Athlete ID: *";
            // 
            // txtAthleteID
            // 
            this.txtAthleteID.Location = new System.Drawing.Point(200, 77);
            this.txtAthleteID.Name = "txtAthleteID";
            this.txtAthleteID.Size = new System.Drawing.Size(100, 22);
            this.txtAthleteID.TabIndex = 2;
            // 
            // btnSearchAthlete
            // 
            this.btnSearchAthlete.BackColor = System.Drawing.Color.LightBlue;
            this.btnSearchAthlete.Location = new System.Drawing.Point(310, 75);
            this.btnSearchAthlete.Name = "btnSearchAthlete";
            this.btnSearchAthlete.Size = new System.Drawing.Size(100, 30);
            this.btnSearchAthlete.TabIndex = 3;
            this.btnSearchAthlete.Text = "🔍 Search";
            this.btnSearchAthlete.UseVisualStyleBackColor = false;
            this.btnSearchAthlete.Click += new System.EventHandler(this.btnSearchAthlete_Click);
            // 
            // lblAthleteName
            // 
            this.lblAthleteName.AutoSize = true;
            this.lblAthleteName.Location = new System.Drawing.Point(30, 120);
            this.lblAthleteName.Name = "lblAthleteName";
            this.lblAthleteName.Size = new System.Drawing.Size(99, 16);
            this.lblAthleteName.TabIndex = 4;
            this.lblAthleteName.Text = "Athlete Name: *";
            // 
            // txtAthleteName
            // 
            this.txtAthleteName.BackColor = System.Drawing.Color.LightGray;
            this.txtAthleteName.Location = new System.Drawing.Point(200, 117);
            this.txtAthleteName.Name = "txtAthleteName";
            this.txtAthleteName.ReadOnly = true;
            this.txtAthleteName.Size = new System.Drawing.Size(289, 22);
            this.txtAthleteName.TabIndex = 5;
            // 
            // lblTrainingPlan
            // 
            this.lblTrainingPlan.AutoSize = true;
            this.lblTrainingPlan.Location = new System.Drawing.Point(30, 170);
            this.lblTrainingPlan.Name = "lblTrainingPlan";
            this.lblTrainingPlan.Size = new System.Drawing.Size(97, 16);
            this.lblTrainingPlan.TabIndex = 6;
            this.lblTrainingPlan.Text = "Training Plan: *";
            // 
            // cmbTrainingPlan
            // 
            this.cmbTrainingPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrainingPlan.FormattingEnabled = true;
            this.cmbTrainingPlan.Location = new System.Drawing.Point(200, 167);
            this.cmbTrainingPlan.Name = "cmbTrainingPlan";
            this.cmbTrainingPlan.Size = new System.Drawing.Size(200, 24);
            this.cmbTrainingPlan.TabIndex = 7;
            // 
            // lblCurrentWeight
            // 
            this.lblCurrentWeight.AutoSize = true;
            this.lblCurrentWeight.Location = new System.Drawing.Point(30, 210);
            this.lblCurrentWeight.Name = "lblCurrentWeight";
            this.lblCurrentWeight.Size = new System.Drawing.Size(131, 16);
            this.lblCurrentWeight.TabIndex = 8;
            this.lblCurrentWeight.Text = "Current Weight (kg): *";
            // 
            // txtCurrentWeight
            // 
            this.txtCurrentWeight.Location = new System.Drawing.Point(200, 207);
            this.txtCurrentWeight.Name = "txtCurrentWeight";
            this.txtCurrentWeight.Size = new System.Drawing.Size(150, 22);
            this.txtCurrentWeight.TabIndex = 9;
            // 
            // lblWeightCategory
            // 
            this.lblWeightCategory.AutoSize = true;
            this.lblWeightCategory.Location = new System.Drawing.Point(30, 250);
            this.lblWeightCategory.Name = "lblWeightCategory";
            this.lblWeightCategory.Size = new System.Drawing.Size(118, 16);
            this.lblWeightCategory.TabIndex = 10;
            this.lblWeightCategory.Text = "Weight Category: *";
            // 
            // cmbWeightCategory
            // 
            this.cmbWeightCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWeightCategory.FormattingEnabled = true;
            this.cmbWeightCategory.Location = new System.Drawing.Point(200, 247);
            this.cmbWeightCategory.Name = "cmbWeightCategory";
            this.cmbWeightCategory.Size = new System.Drawing.Size(200, 24);
            this.cmbWeightCategory.TabIndex = 11;
            // 
            // lblCompetitions
            // 
            this.lblCompetitions.AutoSize = true;
            this.lblCompetitions.Location = new System.Drawing.Point(30, 290);
            this.lblCompetitions.Name = "lblCompetitions";
            this.lblCompetitions.Size = new System.Drawing.Size(96, 16);
            this.lblCompetitions.TabIndex = 12;
            this.lblCompetitions.Text = "Competitions: *";
            // 
            // txtCompetitions
            // 
            this.txtCompetitions.Location = new System.Drawing.Point(200, 287);
            this.txtCompetitions.Name = "txtCompetitions";
            this.txtCompetitions.Size = new System.Drawing.Size(100, 22);
            this.txtCompetitions.TabIndex = 13;
            this.txtCompetitions.Text = "0";
            // 
            // lblPrivateCoaching
            // 
            this.lblPrivateCoaching.AutoSize = true;
            this.lblPrivateCoaching.Location = new System.Drawing.Point(30, 330);
            this.lblPrivateCoaching.Name = "lblPrivateCoaching";
            this.lblPrivateCoaching.Size = new System.Drawing.Size(164, 16);
            this.lblPrivateCoaching.TabIndex = 14;
            this.lblPrivateCoaching.Text = "Private Coaching (hours): *";
            // 
            // txtPrivateCoaching
            // 
            this.txtPrivateCoaching.Location = new System.Drawing.Point(200, 327);
            this.txtPrivateCoaching.Name = "txtPrivateCoaching";
            this.txtPrivateCoaching.Size = new System.Drawing.Size(100, 22);
            this.txtPrivateCoaching.TabIndex = 15;
            this.txtPrivateCoaching.Text = "0";
            // 
            // lblBillMonth
            // 
            this.lblBillMonth.AutoSize = true;
            this.lblBillMonth.Location = new System.Drawing.Point(30, 370);
            this.lblBillMonth.Name = "lblBillMonth";
            this.lblBillMonth.Size = new System.Drawing.Size(75, 16);
            this.lblBillMonth.TabIndex = 16;
            this.lblBillMonth.Text = "Bill Month: *";
            // 
            // dtpMonth
            // 
            this.dtpMonth.CustomFormat = "MMMM yyyy";
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(200, 367);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.Size = new System.Drawing.Size(200, 22);
            this.dtpMonth.TabIndex = 17;
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.dgvOutput);
            this.grpOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOutput.Location = new System.Drawing.Point(506, 80);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(542, 400);
            this.grpOutput.TabIndex = 18;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "MONTHLY FEE BREAKDOWN";
            // 
            // dgvOutput
            // 
            this.dgvOutput.AllowUserToAddRows = false;
            this.dgvOutput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOutput.BackgroundColor = System.Drawing.Color.White;
            this.dgvOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutput.Location = new System.Drawing.Point(15, 30);
            this.dgvOutput.Name = "dgvOutput";
            this.dgvOutput.ReadOnly = true;
            this.dgvOutput.RowHeadersWidth = 51;
            this.dgvOutput.RowTemplate.Height = 24;
            this.dgvOutput.Size = new System.Drawing.Size(521, 350);
            this.dgvOutput.TabIndex = 0;
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.Green;
            this.btnCalculate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.Location = new System.Drawing.Point(113, 528);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(140, 50);
            this.btnCalculate.TabIndex = 19;
            this.btnCalculate.Text = "CALCULATE";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Blue;
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(475, 528);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 50);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "SAVE ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCLose
            // 
            this.btnCLose.BackColor = System.Drawing.Color.Red;
            this.btnCLose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCLose.ForeColor = System.Drawing.Color.White;
            this.btnCLose.Location = new System.Drawing.Point(802, 528);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.Size = new System.Drawing.Size(140, 50);
            this.btnCLose.TabIndex = 21;
            this.btnCLose.Text = "CLOSE";
            this.btnCLose.UseVisualStyleBackColor = false;
            this.btnCLose.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmFeeCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 703);
            this.Controls.Add(this.btnCLose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.grpOutput);
            this.Controls.Add(this.dtpMonth);
            this.Controls.Add(this.lblBillMonth);
            this.Controls.Add(this.txtPrivateCoaching);
            this.Controls.Add(this.lblPrivateCoaching);
            this.Controls.Add(this.txtCompetitions);
            this.Controls.Add(this.lblCompetitions);
            this.Controls.Add(this.cmbWeightCategory);
            this.Controls.Add(this.lblWeightCategory);
            this.Controls.Add(this.txtCurrentWeight);
            this.Controls.Add(this.lblCurrentWeight);
            this.Controls.Add(this.cmbTrainingPlan);
            this.Controls.Add(this.lblTrainingPlan);
            this.Controls.Add(this.txtAthleteName);
            this.Controls.Add(this.lblAthleteName);
            this.Controls.Add(this.btnSearchAthlete);
            this.Controls.Add(this.txtAthleteID);
            this.Controls.Add(this.lblAthleteID);
            this.Controls.Add(this.lblTitle);
            this.MaximizeBox = false;
            this.Name = "frmFeeCalculator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monthly Fee Calculator";
            this.grpOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAthleteID;
        private System.Windows.Forms.TextBox txtAthleteID;
        private System.Windows.Forms.Button btnSearchAthlete;
        private System.Windows.Forms.Label lblAthleteName;
        private System.Windows.Forms.TextBox txtAthleteName;
        private System.Windows.Forms.Label lblTrainingPlan;
        private System.Windows.Forms.ComboBox cmbTrainingPlan;
        private System.Windows.Forms.Label lblCurrentWeight;
        private System.Windows.Forms.TextBox txtCurrentWeight;
        private System.Windows.Forms.Label lblWeightCategory;
        private System.Windows.Forms.ComboBox cmbWeightCategory;
        private System.Windows.Forms.Label lblCompetitions;
        private System.Windows.Forms.TextBox txtCompetitions;
        private System.Windows.Forms.Label lblPrivateCoaching;
        private System.Windows.Forms.TextBox txtPrivateCoaching;
        private System.Windows.Forms.Label lblBillMonth;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.GroupBox grpOutput;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCLose;
        private System.Windows.Forms.DataGridView dgvOutput;
    }
}