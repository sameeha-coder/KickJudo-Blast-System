using System;
using System.Windows.Forms;

namespace KickBlastJudoFeeCalculator
{
    public partial class frmKickBlastJudo : Form
    {
        // Class-level variables to store calculation results
        private double trainingPlanCost = 0;
        private double competitionCost = 0;
        private double privateCoachingCost = 0;
        private double totalMonthlyCost = 0;
        private string weightStatus = "";

        public frmKickBlastJudo()
        {
            InitializeComponent();
            InitializeFormDefaults();
        }

        // Method 1: Initialize form default values
        private void InitializeFormDefaults()
        {
            if (cmbTrainingPlan.Items.Count > 0)
                cmbTrainingPlan.SelectedIndex = 0;
            if (cmbWeightCategory.Items.Count > 0)
                cmbWeightCategory.SelectedIndex = 0;
        }

        // CALCULATE BUTTON - Now calls separate methods (Activity 3 requirement)
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Step 1: Validate all inputs
                if (!ValidateInputs())
                    return;

                // Step 2: Get input values
                string athleteName = txtAthleteName.Text.Trim();
                string trainingPlan = cmbTrainingPlan.SelectedItem.ToString();
                double currentWeight = double.Parse(txtCurrentWeight.Text);
                string weightCategory = cmbWeightCategory.SelectedItem.ToString();
                int numCompetitions = int.Parse(txtCompetitions.Text);
                double privateCoachingHours = double.Parse(txtPrivateCoaching.Text);

                // Step 3: Calculate training plan cost
                trainingPlanCost = CalculateTrainingPlanCost(trainingPlan);

                // Step 4: Calculate competition cost (with eligibility check)
                competitionCost = CalculateCompetitionCost(trainingPlan, ref numCompetitions);

                // Step 5: Calculate private coaching cost (with validation)
                privateCoachingCost = CalculatePrivateCoachingCost(ref privateCoachingHours);

                // Step 6: Calculate total monthly cost
                totalMonthlyCost = CalculateTotalCost(trainingPlanCost, competitionCost, privateCoachingCost);

                // Step 7: Compare weight with category
                double categoryLimit = GetWeightCategoryLimit(weightCategory);
                weightStatus = CompareWeight(currentWeight, categoryLimit);

                // Step 8: Display output
                DisplayOutput(athleteName, trainingPlan, currentWeight, weightCategory,
                             numCompetitions, privateCoachingHours);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method 2: Validate all user inputs
        private bool ValidateInputs()
        {
            // Validate athlete name
            if (string.IsNullOrWhiteSpace(txtAthleteName.Text))
            {
                ShowValidationError("Please enter athlete name.", txtAthleteName);
                return false;
            }

            // Validate training plan selection
            if (cmbTrainingPlan.SelectedIndex == -1)
            {
                ShowValidationError("Please select a training plan.", cmbTrainingPlan);
                return false;
            }

            // Validate current weight
            if (!double.TryParse(txtCurrentWeight.Text, out double weight) || weight <= 0)
            {
                ShowValidationError("Please enter a valid current weight (kg).", txtCurrentWeight);
                return false;
            }

            // Validate weight category selection
            if (cmbWeightCategory.SelectedIndex == -1)
            {
                ShowValidationError("Please select a weight category.", cmbWeightCategory);
                return false;
            }

            // Validate number of competitions
            if (!int.TryParse(txtCompetitions.Text, out int competitions) || competitions < 0)
            {
                ShowValidationError("Please enter a valid number of competitions (0 or more).", txtCompetitions);
                return false;
            }

            // Validate private coaching hours
            if (!double.TryParse(txtPrivateCoaching.Text, out double hours) || hours < 0)
            {
                ShowValidationError("Please enter valid private coaching hours (0 or more).", txtPrivateCoaching);
                return false;
            }

            return true;
        }

        // Method 3: Show validation error message
        private void ShowValidationError(string message, Control control)
        {
            MessageBox.Show(message, "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        // Method 4: Calculate training plan cost (Pseudocode Step 2)
        private double CalculateTrainingPlanCost(string trainingPlan)
        {
            double weeklyCost = 0;

            switch (trainingPlan)
            {
                case "Beginner":
                    weeklyCost = 250.00;
                    break;
                case "Intermediate":
                    weeklyCost = 300.00;
                    break;
                case "Elite":
                    weeklyCost = 350.00;
                    break;
            }

            // Monthly cost = Weekly fee × 4 weeks
            return weeklyCost * 4;
        }

        // Method 5: Calculate competition cost (Pseudocode Step 3)
        private double CalculateCompetitionCost(string trainingPlan, ref int numCompetitions)
        {
            // Beginners cannot compete
            if (trainingPlan == "Beginner" && numCompetitions > 0)
            {
                MessageBox.Show("Beginner athletes cannot enter competitions. " +
                    "Competition count set to 0.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                numCompetitions = 0;
                txtCompetitions.Text = "0";
            }

            // Competition cost = Number of competitions × Rs. 220
            return numCompetitions * 220.00;
        }

        // Method 6: Calculate private coaching cost (Pseudocode Step 4)
        private double CalculatePrivateCoachingCost(ref double privateCoachingHours)
        {
            // Maximum 5 hours per week × 4 weeks = 20 hours per month
            const double MAX_HOURS = 20.0;
            const double HOURLY_RATE = 90.50;

            if (privateCoachingHours > MAX_HOURS)
            {
                MessageBox.Show($"Maximum private coaching is 5 hours per week " +
                    $"({MAX_HOURS} hours per month). Hours adjusted to {MAX_HOURS}.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                privateCoachingHours = MAX_HOURS;
                txtPrivateCoaching.Text = MAX_HOURS.ToString();
            }

            // Coaching cost = Hours × Rs. 90.50
            return privateCoachingHours * HOURLY_RATE;
        }

        // Method 7: Calculate total monthly cost (Pseudocode Step 5)
        private double CalculateTotalCost(double planCost, double compCost, double coachingCost)
        {
            return planCost + compCost + coachingCost;
        }

        // Method 8: Get weight category upper limit
        private double GetWeightCategoryLimit(string category)
        {
            switch (category)
            {
                case "Flyweight":
                    return 66.00;
                case "Lightweight":
                    return 73.00;
                case "Light-Middleweight":
                    return 81.00;
                case "Middleweight":
                    return 90.00;
                case "Light-Heavyweight":
                    return 100.00;
                case "Heavyweight":
                    return 101.00; // Unlimited (over 100)
                default:
                    return 0;
            }
        }

        // Method 9: Compare current weight with competition category (Pseudocode Step 7)
        private string CompareWeight(double currentWeight, double categoryLimit)
        {
            if (categoryLimit > 100) // Heavyweight category
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

        // Method 10: Display itemised output (Pseudocode Step 6)
        private void DisplayOutput(string athleteName, string trainingPlan, double currentWeight,
                                   string weightCategory, int numCompetitions, double privateCoachingHours)
        {
            string output = "═══════════════════════════════════════\n";
            output += $"ATHLETE: {athleteName.ToUpper()}\n";
            output += "═══════════════════════════════════════\n\n";
            output += "ITEMISED MONTHLY COSTS:\n";
            output += "───────────────────────────────────────\n";
            output += $"Training Plan ({trainingPlan}):\n";
            output += $"  Rs. {trainingPlanCost:F2}\n\n";
            output += $"Competitions Entered ({numCompetitions}):\n";
            output += $"  Rs. {competitionCost:F2}\n\n";
            output += $"Private Coaching ({privateCoachingHours} hours):\n";
            output += $"  Rs. {privateCoachingCost:F2}\n\n";
            output += "═══════════════════════════════════════\n";
            output += $"TOTAL MONTHLY COST: Rs. {totalMonthlyCost:F2}\n";
            output += "═══════════════════════════════════════\n\n";
            output += "WEIGHT CATEGORY ANALYSIS:\n";
            output += "───────────────────────────────────────\n";
            output += $"Current Weight: {currentWeight} kg\n";
            output += $"Category: {weightCategory}\n";
            output += $"Status: {weightStatus}\n";

            txtOutput.Text = output;
        }

        // Clear button - resets all fields
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        // Method 11: Clear all form fields
        private void ClearAllFields()
        {
            txtAthleteName.Clear();
            cmbTrainingPlan.SelectedIndex = 0;
            txtCurrentWeight.Clear();
            cmbWeightCategory.SelectedIndex = 0;
            txtCompetitions.Text = "0";
            txtPrivateCoaching.Text = "0";
            txtOutput.Clear();

            // Reset calculation variables
            trainingPlanCost = 0;
            competitionCost = 0;
            privateCoachingCost = 0;
            totalMonthlyCost = 0;
            weightStatus = "";

            txtAthleteName.Focus();
        }
    }
}


