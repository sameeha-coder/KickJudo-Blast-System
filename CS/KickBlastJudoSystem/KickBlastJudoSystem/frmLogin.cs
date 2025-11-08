using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KickBlastJudoSystem
{
    public partial class frmLogin : Form
    {
        public static string LoggedInUser = ""; 

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Test database connection
            if (!DatabaseHelper.TestConnection())
            {
                MessageBox.Show("⚠️ Cannot connect to database!\n\n" +
                    "Please check:\n" +
                    "1. SQL Server is running\n" +
                    "2. Database 'KickBlastJudoDB' exists\n" +
                    "3. Connection string is correct",
                    "Database Connection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtUsername.Focus();
        }

        // LOGIN BUTTON CLICK
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (AuthenticateUser(username, password))
            {
                UpdateLastLogin(username);

                LoggedInUser = username;

                MessageBox.Show($"✓ Welcome to KickBlast Judo System!\n\nLogged in as: {username}",
                    "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                this.Hide();
                frmMainDashboard dashboard = new frmMainDashboard();
                dashboard.ShowDialog();

                this.Show();
                ClearFields();
                LoggedInUser = "";
               

                ClearFields();
                MessageBox.Show("Dashboard will open here after we create it!",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("✗ Invalid username or password!\n\nPlease try again.",
                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        // Validate user inputs
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter your username.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter your password.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        // Authenticate user against database
        private bool AuthenticateUser(string username, string password)
        {
            try
            {
                string query = @"SELECT COUNT(*), FullName, Role 
                               FROM Users 
                               WHERE Username = @Username 
                               AND Password = @Password 
                               AND IsActive = 1
                               GROUP BY FullName, Role";

                SqlParameter[] parameters = {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", password)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0][0]) > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void UpdateLastLogin(string username)
        {
            try
            {
                string query = @"UPDATE Users 
                               SET LastLogin = GETDATE() 
                               WHERE Username = @Username";

                SqlParameter[] parameters = {
                    new SqlParameter("@Username", username)
                };

                DatabaseHelper.ExecuteNonQuery(query, parameters);
            }
            catch
            {
                
            }
        }

        private void ClearFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        // EXIT BUTTON CLICK
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit KickBlast Judo System?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
