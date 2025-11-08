using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KickBlastJudoSystem
{
    public partial class frmAthleteRegistration : Form
    {
        public frmAthleteRegistration()
        {
            InitializeComponent();
            this.Load += frmAthleteRegistration_Load;
        }

        private void frmAthleteRegistration_Load(object sender, EventArgs e)
        {
            InitializeForm();
            LoadNextAthleteID();
        }

        private void InitializeForm()
        {
            
            dtpDOB.MaxDate = DateTime.Now.AddYears(-5);  // minimum 5 years old
            dtpDOB.MinDate = DateTime.Now.AddYears(-80); // maximum 80 years old
            dtpDOB.Value = DateTime.Now.AddYears(-15);   // default 15 years old

            
            if (cmbGender.Items.Count == 0)
            {
                cmbGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
            }

            txtFirstName.Focus();
        }

        // Load next available Athlete IDs
        private void LoadNextAthleteID()
        {
            try
            {
                string query = "SELECT ISNULL(MAX(AthleteID), 1000) + 1 FROM Athletes";
                object result = DatabaseHelper.ExecuteScalar(query);

                if (result != null)
                {
                    txtAthleteID.Text = result.ToString();
                }
                else
                {
                    txtAthleteID.Text = "1001"; // Starting ID
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Athlete ID: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAthleteID.Text = "1001";
            }
        }

        // SAVE BUTTON 
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            DialogResult result = MessageBox.Show(
                "Are you sure you want to register this athlete?",
                "Confirm Registration",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (SaveAthleteToDatabase())
            {
                MessageBox.Show(
                    $"✓ Athlete registered successfully!\n\n" +
                    $"Athlete ID: {txtAthleteID.Text}\n" +
                    $"Name: {txtFirstName.Text} {txtLastName.Text}",
                    "Registration Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearAllFields();
                LoadNextAthleteID();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                ShowValidationError("Please enter First Name.", txtFirstName);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                ShowValidationError("Please enter Last Name.", txtLastName);
                return false;
            }

            if (cmbGender.SelectedIndex == -1)
            {
                ShowValidationError("Please select Gender.", cmbGender);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContact.Text))
            {
                ShowValidationError("Please enter Contact Number.", txtContact);
                return false;
            }

            if (txtContact.Text.Length < 10)
            {
                ShowValidationError("Contact Number must be at least 10 digits.", txtContact);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                ShowValidationError("Please enter Address.", txtAddress);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmergencyContact.Text))
            {
                ShowValidationError("Please enter Emergency Contact Name.", txtEmergencyContact);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmergencyPhone.Text))
            {
                ShowValidationError("Please enter Emergency Contact Phone.", txtEmergencyPhone);
                return false;
            }

            if (txtEmergencyPhone.Text.Length < 10)
            {
                ShowValidationError("Emergency Phone must be at least 10 digits.", txtEmergencyPhone);
                return false;
            }

            return true;
        }

        // error message
        private void ShowValidationError(string message, Control control)
        {
            MessageBox.Show(message, "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        // Save athlete to database
        private bool SaveAthleteToDatabase()
        {
            try
            {
                string query = @"INSERT INTO Athletes 
                    (FirstName, LastName, DateOfBirth, Gender, ContactNumber, Email, 
                     Address, EmergencyContactName, EmergencyContactPhone, CreatedBy)
                VALUES 
                    (@FirstName, @LastName, @DOB, @Gender, @Contact, @Email, 
                     @Address, @EmergencyContact, @EmergencyPhone, @CreatedBy)";

                SqlParameter[] parameters = {
                    new SqlParameter("@FirstName", txtFirstName.Text.Trim()),
                    new SqlParameter("@LastName", txtLastName.Text.Trim()),
                    new SqlParameter("@DOB", dtpDOB.Value.Date),
                    new SqlParameter("@Gender", cmbGender.SelectedItem.ToString()),
                    new SqlParameter("@Contact", txtContact.Text.Trim()),
                    new SqlParameter("@Email", string.IsNullOrWhiteSpace(txtEmail.Text) ?
                        (object)DBNull.Value : txtEmail.Text.Trim()),
                    new SqlParameter("@Address", txtAddress.Text.Trim()),
                    new SqlParameter("@EmergencyContact", txtEmergencyContact.Text.Trim()),
                    new SqlParameter("@EmergencyPhone", txtEmergencyPhone.Text.Trim()),
                    new SqlParameter("@CreatedBy", frmLogin.LoggedInUser)
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving athlete:\n\n{ex.Message}",
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

        private void ClearAllFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            dtpDOB.Value = DateTime.Now.AddYears(-15);
            cmbGender.SelectedIndex = -1;
            txtContact.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtEmergencyContact.Clear();
            txtEmergencyPhone.Clear();
            txtFirstName.Focus();
        }

        // CLOSE BUTTON
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtEmergencyPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
