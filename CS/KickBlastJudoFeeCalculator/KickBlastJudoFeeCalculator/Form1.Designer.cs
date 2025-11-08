using System.Windows.Forms;

namespace KickBlastJudoFeeCalculator
{
    partial class frmKickBlastJudo
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblAthleteName = new Label();
            lblTrainingPlan = new Label();
            lblCurrentWeight = new Label();
            lblWeightCategory = new Label();
            lblCompetition = new Label();
            lblPrivateCoaching = new Label();
            txtAthleteName = new TextBox();
            cmbTrainingPlan = new ComboBox();
            txtCurrentWeight = new TextBox();
            cmbWeightCategory = new ComboBox();
            txtCompetitions = new TextBox();
            txtPrivateCoaching = new TextBox();
            btnCalculate = new Button();
            btnClear = new Button();
            grpOutput = new GroupBox();
            txtOutput = new TextBox();
            grpOutput.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F);
            lblTitle.Location = new Point(86, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(420, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "KickBlast Judo Monthly Fee Calculator";
            // 
            // lblAthleteName
            // 
            lblAthleteName.AutoSize = true;
            lblAthleteName.Location = new Point(24, 86);
            lblAthleteName.Name = "lblAthleteName";
            lblAthleteName.Size = new Size(101, 20);
            lblAthleteName.TabIndex = 1;
            lblAthleteName.Text = "Athlete Name";
            // 
            // lblTrainingPlan
            // 
            lblTrainingPlan.AutoSize = true;
            lblTrainingPlan.Location = new Point(26, 131);
            lblTrainingPlan.Name = "lblTrainingPlan";
            lblTrainingPlan.Size = new Size(94, 20);
            lblTrainingPlan.TabIndex = 2;
            lblTrainingPlan.Text = "Training Plan";
            // 
            // lblCurrentWeight
            // 
            lblCurrentWeight.AutoSize = true;
            lblCurrentWeight.Location = new Point(24, 180);
            lblCurrentWeight.Name = "lblCurrentWeight";
            lblCurrentWeight.Size = new Size(141, 20);
            lblCurrentWeight.TabIndex = 3;
            lblCurrentWeight.Text = "Current Weight (kg):";
            // 
            // lblWeightCategory
            // 
            lblWeightCategory.AutoSize = true;
            lblWeightCategory.Location = new Point(26, 223);
            lblWeightCategory.Name = "lblWeightCategory";
            lblWeightCategory.Size = new Size(123, 20);
            lblWeightCategory.TabIndex = 4;
            lblWeightCategory.Text = "Weight Category:";
            // 
            // lblCompetition
            // 
            lblCompetition.AutoSize = true;
            lblCompetition.Location = new Point(26, 267);
            lblCompetition.Name = "lblCompetition";
            lblCompetition.Size = new Size(177, 20);
            lblCompetition.TabIndex = 5;
            lblCompetition.Text = "Number of Competitions:";
            // 
            // lblPrivateCoaching
            // 
            lblPrivateCoaching.AutoSize = true;
            lblPrivateCoaching.Location = new Point(26, 316);
            lblPrivateCoaching.Name = "lblPrivateCoaching";
            lblPrivateCoaching.Size = new Size(249, 20);
            lblPrivateCoaching.TabIndex = 6;
            lblPrivateCoaching.Text = "Private Coaching Hours (per month):";
            // 
            // txtAthleteName
            // 
            txtAthleteName.Location = new Point(313, 86);
            txtAthleteName.Name = "txtAthleteName";
            txtAthleteName.Size = new Size(125, 27);
            txtAthleteName.TabIndex = 7;
            // 
            // cmbTrainingPlan
            // 
            cmbTrainingPlan.FormattingEnabled = true;
            cmbTrainingPlan.Items.AddRange(new object[] { "Beginner", "Intermediate", "Elite" });
            cmbTrainingPlan.Location = new Point(313, 131);
            cmbTrainingPlan.Name = "cmbTrainingPlan";
            cmbTrainingPlan.Size = new Size(151, 28);
            cmbTrainingPlan.TabIndex = 8;
            // 
            // txtCurrentWeight
            // 
            txtCurrentWeight.Location = new Point(313, 173);
            txtCurrentWeight.Name = "txtCurrentWeight";
            txtCurrentWeight.Size = new Size(125, 27);
            txtCurrentWeight.TabIndex = 9;
            // 
            // cmbWeightCategory
            // 
            cmbWeightCategory.FormattingEnabled = true;
            cmbWeightCategory.Items.AddRange(new object[] { "Flyweight", "Lightweight", "Light-Middleweight", "Middleweight", "Light-Heavyweight", "Heavyweight" });
            cmbWeightCategory.Location = new Point(313, 215);
            cmbWeightCategory.Name = "cmbWeightCategory";
            cmbWeightCategory.Size = new Size(151, 28);
            cmbWeightCategory.TabIndex = 10;
            // 
            // txtCompetitions
            // 
            txtCompetitions.Location = new Point(313, 267);
            txtCompetitions.Name = "txtCompetitions";
            txtCompetitions.Size = new Size(125, 27);
            txtCompetitions.TabIndex = 11;
            txtCompetitions.Text = "0";
            // 
            // txtPrivateCoaching
            // 
            txtPrivateCoaching.Location = new Point(313, 316);
            txtPrivateCoaching.Name = "txtPrivateCoaching";
            txtPrivateCoaching.Size = new Size(125, 27);
            txtPrivateCoaching.TabIndex = 12;
            txtPrivateCoaching.Text = "0";
            // 
            // btnCalculate
            // 
            btnCalculate.BackColor = Color.Thistle;
            btnCalculate.Location = new Point(72, 373);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(166, 29);
            btnCalculate.TabIndex = 13;
            btnCalculate.Text = "Calculate Monthly Fee";
            btnCalculate.UseVisualStyleBackColor = false;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Thistle;
            btnClear.Location = new Point(280, 373);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 14;
            btnClear.Text = "Clear Form";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // grpOutput
            // 
            grpOutput.Controls.Add(txtOutput);
            grpOutput.Location = new Point(40, 430);
            grpOutput.Name = "grpOutput";
            grpOutput.Size = new Size(424, 280);
            grpOutput.TabIndex = 15;
            grpOutput.TabStop = false;
            grpOutput.Text = "Monthly Fee Breakdown:";
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(18, 26);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(406, 250);
            txtOutput.TabIndex = 0;
            // 
            // frmKickBlastJudo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            ClientSize = new Size(703, 750);
            Controls.Add(grpOutput);
            Controls.Add(btnClear);
            Controls.Add(btnCalculate);
            Controls.Add(txtPrivateCoaching);
            Controls.Add(txtCompetitions);
            Controls.Add(cmbWeightCategory);
            Controls.Add(txtCurrentWeight);
            Controls.Add(cmbTrainingPlan);
            Controls.Add(txtAthleteName);
            Controls.Add(lblPrivateCoaching);
            Controls.Add(lblCompetition);
            Controls.Add(lblWeightCategory);
            Controls.Add(lblCurrentWeight);
            Controls.Add(lblTrainingPlan);
            Controls.Add(lblAthleteName);
            Controls.Add(lblTitle);
            Name = "frmKickBlastJudo";
            Text = "KickBlast Judo Fee Calculator";
            grpOutput.ResumeLayout(false);
            grpOutput.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblAthleteName;
        private Label lblTrainingPlan;
        private Label lblCurrentWeight;
        private Label lblWeightCategory;
        private Label lblCompetition;
        private Label lblPrivateCoaching;
        private TextBox txtAthleteName;
        private ComboBox cmbTrainingPlan;
        private TextBox txtCurrentWeight;
        private ComboBox cmbWeightCategory;
        private TextBox txtCompetitions;
        private TextBox txtPrivateCoaching;
        private Button btnCalculate;
        private Button btnClear;
        private GroupBox grpOutput;
        private TextBox txtOutput;
    }
}