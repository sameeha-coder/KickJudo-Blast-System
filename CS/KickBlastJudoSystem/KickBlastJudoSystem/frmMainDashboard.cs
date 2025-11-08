using System;
using System.Windows.Forms;

namespace KickBlastJudoSystem
{
    public partial class frmMainDashboard : Form
    {
        public frmMainDashboard()
        {
            InitializeComponent();
        }

        private void frmMainDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {frmLogin.LoggedInUser}";
        }

        // Button 1: Register New Athlete
        private void btnAthleteReg_Click(object sender, EventArgs e)
        {
            frmAthleteRegistration regForm = new frmAthleteRegistration();
            regForm.ShowDialog();
        }

        // Button 2: Calculate Monthly Fees
        private void btnFeeCalculator_Click(object sender, EventArgs e)
        {
            frmFeeCalculator calcForm = new frmFeeCalculator();
            calcForm.ShowDialog();
        }

        // Button 3: View All Registrations
        private void btnViewRegistrations_Click(object sender, EventArgs e)
        {
            frmViewRegistrations viewForm = new frmViewRegistrations();
            viewForm.ShowDialog();
        }

        // Button 4: Manage Athletes
        private void btnManageAthletes_Click(object sender, EventArgs e)
        {
            frmManageAthletes manageForm = new frmManageAthletes();
            manageForm.ShowDialog();
        }

        // Button 5: Logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close(); 
            }
        }
    }
}
