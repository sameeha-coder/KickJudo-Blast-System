using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KickBlastJudoSystem
{
    public partial class frmFeeCalculator : Form
    {
        private int athleteID = 0;
        private int planID = 0;
        private int categoryID = 0;
        private double trainingPlanCost = 0;
        private double competitionCost = 0;
        private double privateCoachingCost = 0;
        private double totalMonthlyCost = 0;
        private string weightStatus = "";

        public frmFeeCalculator()
        {
            InitializeComponent();
            this.Load += FrmFeeCalculator_Load;
        }

        private void FrmFeeCalculator_Load(object sender, EventArgs e)
        {
            InitializeFormDefaults();
            LoadTrainingPlans();
            LoadWeightCategories();
        }

        // Method 1: Initialize form defaults
        private void InitializeFormDefaults()
        {
            dtpMonth.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtAthleteID.Focus();
        }

        // Method 2: Load training plans from database
        private void LoadTrainingPlans()
        {
            try
            {
                string query = "SELECT PlanID, PlanName FROM TrainingPlans WHERE IsActive = 1 ORDER BY PlanID";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                cmbTrainingPlan.DataSource = dt;
                cmbTrainingPlan.DisplayMember = "PlanName";
                cmbTrainingPlan.ValueMember = "PlanID";
                cmbTrainingPlan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading training plans: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method 3: Load weight categories from database
        private void LoadWeightCategories()
        {
            try
            {
                string query = "SELECT CategoryID, CategoryName FROM WeightCategories WHERE IsActive = 1 ORDER BY CategoryID";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                cmbWeightCategory.DataSource = dt;
                cmbWeightCategory.DisplayMember = "CategoryName";
                cmbWeightCategory.ValueMember = "CategoryID";
                cmbWeightCategory.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading weight categories: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SEARCH BUTTON 
        private void btnSearchAthlete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAthleteID.Text))
            {
                MessageBox.Show("Please enter Athlete ID.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAthleteID.Focus();
                return;
            }

            if (!int.TryParse(txtAthleteID.Text, out int id))
            {
                MessageBox.Show("Athlete ID must be a number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAthleteID.Focus();
                return;
            }

            SearchAthleteByID(id);
        }

        // Method 4: Search and load athlete details
        private void SearchAthleteByID(int id)
        {
            try
            {
                string query = @"SELECT AthleteID, CONCAT(FirstName, ' ', LastName) AS FullName 
                               FROM Athletes 
                               WHERE AthleteID = @AthleteID AND IsActive = 1";

                SqlParameter[] parameters = {
                    new SqlParameter("@AthleteID", id)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    athleteID = Convert.ToInt32(dt.Rows[0]["AthleteID"]);
                    txtAthleteName.Text = dt.Rows[0]["FullName"].ToString();

                    MessageBox.Show("✓ Athlete found!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    athleteID = 0;
                    txtAthleteName.Clear();
                    MessageBox.Show("✗ Athlete not found!\n\nPlease check the Athlete ID.",
                        "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching athlete: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CALCULATE BUTTON

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateAllInputs())
                    return;

                string trainingPlan = cmbTrainingPlan.Text;
                double currentWeight = double.Parse(txtCurrentWeight.Text);
                string weightCategory = cmbWeightCategory.Text;
                int numCompetitions = int.Parse(txtCompetitions.Text);
                double privateCoachingHours = double.Parse(txtPrivateCoaching.Text);

                planID = Convert.ToInt32(cmbTrainingPlan.SelectedValue);
                categoryID = Convert.ToInt32(cmbWeightCategory.SelectedValue);
 
                trainingPlanCost = CalculateTrainingPlanCost(planID);

                competitionCost = CalculateCompetitionCost(trainingPlan, ref numCompetitions);

                privateCoachingCost = CalculatePrivateCoachingCost(ref privateCoachingHours);

                totalMonthlyCost = CalculateTotalMonthlyCost(trainingPlanCost, competitionCost,
                    privateCoachingCost);

                double categoryLimit = GetWeightCategoryLimit(categoryID);
                weightStatus = CompareWeightWithCategory(currentWeight, categoryLimit);

                DisplayFeeBreakdown(txtAthleteName.Text, trainingPlan, currentWeight,
                    weightCategory, numCompetitions, privateCoachingHours);

                btnSave.Enabled = true;

                MessageBox.Show("✓ Calculation completed successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Calculation error: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Method 5: Validate all inputs
        private bool ValidateAllInputs()
        {
            if (athleteID == 0)
            {
                ShowValidationError("Please search for an athlete first.", txtAthleteID);
                return false;
            }

            if (cmbTrainingPlan.SelectedIndex == -1)
            {
                ShowValidationError("Please select a Training Plan.", cmbTrainingPlan);
                return false;
            }

            if (!double.TryParse(txtCurrentWeight.Text, out double weight) || weight <= 0)
            {
                ShowValidationError("Please enter valid Current Weight.", txtCurrentWeight);
                return false;
            }

            if (cmbWeightCategory.SelectedIndex == -1)
            {
                ShowValidationError("Please select Weight Category.", cmbWeightCategory);
                return false;
            }

            if (!int.TryParse(txtCompetitions.Text, out int comp) || comp < 0)
            {
                ShowValidationError("Please enter valid number of Competitions.", txtCompetitions);
                return false;
            }

            if (!double.TryParse(txtPrivateCoaching.Text, out double hours) || hours < 0)
            {
                ShowValidationError("Please enter valid Private Coaching hours.", txtPrivateCoaching);
                return false;
            }

            return true;
        }

        // Method 6: Show validation error
        private void ShowValidationError(string message, Control control)
        {
            MessageBox.Show(message, "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        // FEE CALCULATION METHODS 

        // Method 7: Calculate training plan cost 
        private double CalculateTrainingPlanCost(int planID)
        {
            try
            {
                string query = "SELECT WeeklyFee FROM TrainingPlans WHERE PlanID = @PlanID";
                SqlParameter[] parameters = {
                    new SqlParameter("@PlanID", planID)
                };

                object result = DatabaseHelper.ExecuteScalar(query, parameters);
                double weeklyFee = Convert.ToDouble(result);

                return weeklyFee * 4; // Monthly cost
            }
            catch
            {
                return 0;
            }
        }

        // Method 8: Calculate competition cost 
        private double CalculateCompetitionCost(string trainingPlan, ref int numCompetitions)
        {
            // Beginners cannot compete
            if (trainingPlan == "Beginner" && numCompetitions > 0)
            {
                MessageBox.Show("⚠ Beginner athletes cannot enter competitions!\n\n" +
                    "Competition count set to 0.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numCompetitions = 0;
                txtCompetitions.Text = "0";
            }

            const double COMPETITION_FEE = 220.00;
            return numCompetitions * COMPETITION_FEE;
        }

        // Method 9: Calculate private coaching cost 
        private double CalculatePrivateCoachingCost(ref double hours)
        {
            const double MAX_HOURS = 20.0;
            const double HOURLY_RATE = 90.50;

            if (hours > MAX_HOURS)
            {
                MessageBox.Show($"⚠ Maximum private coaching is 5 hours/week ({MAX_HOURS} hours/month).\n\n" +
                    $"Hours adjusted to {MAX_HOURS}.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hours = MAX_HOURS;
                txtPrivateCoaching.Text = MAX_HOURS.ToString();
            }

            return hours * HOURLY_RATE;
        }

        // Method 10: Calculate total monthly cost
        private double CalculateTotalMonthlyCost(double planCost, double compCost, double coachingCost)
        {
            return planCost + compCost + coachingCost;
        }

        // Method 11: Get weight category upper limit
        private double GetWeightCategoryLimit(int categoryID)
        {
            try
            {
                string query = "SELECT UpperWeightLimit FROM WeightCategories WHERE CategoryID = @CategoryID";
                SqlParameter[] parameters = {
            new SqlParameter("@CategoryID", categoryID)
        };

                object result = DatabaseHelper.ExecuteScalar(query, parameters);
                return Convert.ToDouble(result);
            }
            catch
            {
                return 0;
            }
        }

        // Method 12: Compare current weight with category limit
        private string CompareWeightWithCategory(double currentWeight, double categoryLimit)
        {
            if (categoryLimit > 100) 
            {
                if (currentWeight > 100)
                    return "Athlete is in correct weight category.";
                else
                    return "Athlete can increase weight to match category.";
            }
            else
            {
                if (currentWeight <= categoryLimit)
                    return "Athlete is in correct weight category.";
                else
                    return "Athlete needs to reduce weight.";
            }
        }


        // Method 13: Display itemized fee breakdown 
        private void DisplayFeeBreakdown(string athleteName, string trainingPlan, double currentWeight,
            string weightCategory, int numCompetitions, double privateCoachingHours)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Item", typeof(string));
            dt.Columns.Add("Details", typeof(string));
            dt.Columns.Add("Amount", typeof(string));

            dt.Rows.Add("═════════════════════", "═════════════════════", "═════════════");
            dt.Rows.Add("ATHLETE:", athleteName.ToUpper(), "");
            dt.Rows.Add("MONTH:", dtpMonth.Value.ToString("MMMM yyyy"), "");
            dt.Rows.Add("═════════════════════", "═════════════════════", "═════════════");
            dt.Rows.Add("", "", "");

            dt.Rows.Add("ITEM", "DESCRIPTION", "AMOUNT (Rs.)");
            dt.Rows.Add("─────────────────────", "─────────────────────", "─────────────");
            dt.Rows.Add("Training Plan", trainingPlan, trainingPlanCost.ToString("N2"));
            dt.Rows.Add("Competitions", $"{numCompetitions} entries", competitionCost.ToString("N2"));
            dt.Rows.Add("Private Coaching", $"{privateCoachingHours} hours", privateCoachingCost.ToString("N2"));
            dt.Rows.Add("═════════════════════", "═════════════════════", "═════════════");
            dt.Rows.Add("TOTAL MONTHLY COST", "", totalMonthlyCost.ToString("N2"));
            dt.Rows.Add("═════════════════════", "═════════════════════", "═════════════");
            dt.Rows.Add("", "", "");

            dt.Rows.Add("WEIGHT ANALYSIS", "", "");
            dt.Rows.Add("─────────────────────", "─────────────────────", "─────────────");
            dt.Rows.Add("Current Weight:", $"{currentWeight} kg", "");
            dt.Rows.Add("Category:", weightCategory, "");
            dt.Rows.Add("Status:", weightStatus, "");


            dgvOutput.DataSource = dt;

            dgvOutput.ColumnHeadersVisible = false;
            dgvOutput.RowHeadersVisible = false;
            dgvOutput.AllowUserToResizeRows = false;
            dgvOutput.AllowUserToResizeColumns = false;
            dgvOutput.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOutput.MultiSelect = false;
            dgvOutput.ReadOnly = true;

            dgvOutput.Columns[0].Width = 150;
            dgvOutput.Columns[1].Width = 140;
            dgvOutput.Columns[2].Width = 100;

            dgvOutput.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOutput.Columns[2].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);

            dgvOutput.Rows[11].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            dgvOutput.Rows[11].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            dgvOutput.Rows[11].DefaultCellStyle.ForeColor = System.Drawing.Color.DarkGreen;

            dgvOutput.Rows[0].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            dgvOutput.Rows[1].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            dgvOutput.Rows[2].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;

            dgvOutput.Rows[5].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            dgvOutput.Rows[14].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
        }

        // SAVE TO DATABASE METHOD
        

        // SAVE BUTTON 
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (totalMonthlyCost == 0)
            {
                MessageBox.Show("Please calculate fees first before saving.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to save this monthly registration?",
                "Confirm Save",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (SaveToDatabase())
            {
                MessageBox.Show("✓ Monthly registration saved successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllFields();
            }
        }

        // Method 14: Save registration to database
        private bool SaveToDatabase()
        {
            try
            {
                string query = @"INSERT INTO MonthlyRegistrations 
                    (AthleteID, PlanID, CategoryID, RegistrationMonth, CurrentWeight, 
                     NumCompetitions, PrivateCoachingHours, TrainingPlanCost, CompetitionCost, 
                     PrivateCoachingCost, TotalMonthlyCost, WeightStatus, CreatedBy)
                VALUES 
                    (@AthleteID, @PlanID, @CategoryID, @Month, @Weight, 
                     @Competitions, @Coaching, @PlanCost, @CompCost, 
                     @CoachingCost, @Total, @Status, @CreatedBy)";

                SqlParameter[] parameters = {
                    new SqlParameter("@AthleteID", athleteID),
                    new SqlParameter("@PlanID", planID),
                    new SqlParameter("@CategoryID", categoryID),
                    new SqlParameter("@Month", dtpMonth.Value.Date),
                    new SqlParameter("@Weight", double.Parse(txtCurrentWeight.Text)),
                    new SqlParameter("@Competitions", int.Parse(txtCompetitions.Text)),
                    new SqlParameter("@Coaching", double.Parse(txtPrivateCoaching.Text)),
                    new SqlParameter("@PlanCost", trainingPlanCost),
                    new SqlParameter("@CompCost", competitionCost),
                    new SqlParameter("@CoachingCost", privateCoachingCost),
                    new SqlParameter("@Total", totalMonthlyCost),
                    new SqlParameter("@Status", weightStatus),
                    new SqlParameter("@CreatedBy", frmLogin.LoggedInUser)
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving to database:\n\n{ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // CLEAR BUTTON
        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to clear all fields?",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ClearAllFields();
            }
        }

        // Method 15: Clear all fields
        private void ClearAllFields()
        {
            txtAthleteID.Clear();
            txtAthleteName.Clear();
            cmbTrainingPlan.SelectedIndex = -1;
            txtCurrentWeight.Clear();
            cmbWeightCategory.SelectedIndex = -1;
            txtCompetitions.Text = "0";
            txtPrivateCoaching.Text = "0";
            dgvOutput.DataSource = null;

            athleteID = 0;
            trainingPlanCost = 0;
            competitionCost = 0;
            privateCoachingCost = 0;
            totalMonthlyCost = 0;
            weightStatus = "";

            btnSave.Enabled = false;
            txtAthleteID.Focus();
        }

        // CLOSE BUTTON
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAthleteID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtCurrentWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtCompetitions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtPrivateCoaching_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}