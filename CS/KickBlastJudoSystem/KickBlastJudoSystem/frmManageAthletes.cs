using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KickBlastJudoSystem
{
    public partial class frmManageAthletes : Form
    {
        public frmManageAthletes()
        {
            InitializeComponent();
            this.Load += FrmManageAthletes_Load;
        }

        private void FrmManageAthletes_Load(object sender, EventArgs e)
        {
            LoadAllAthletes();
            FormatGrid();
        }

        private void LoadAllAthletes()
        {
            try
            {
                string query = @"
                    SELECT 
                        AthleteID AS 'ID',
                        CONCAT(FirstName, ' ', LastName) AS 'Full Name',
                        FORMAT(DateOfBirth, 'dd/MM/yyyy') AS 'Date of Birth',
                        Age,
                        Gender,
                        ContactNumber AS 'Contact',
                        Email,
                        Address,
                        EmergencyContactName AS 'Emergency Contact',
                        EmergencyContactPhone AS 'Emergency Phone',
                        FORMAT(EnrollmentDate, 'dd/MM/yyyy') AS 'Enrolled On',
                        CASE WHEN IsActive = 1 THEN 'Active' ELSE 'Inactive' END AS 'Status'
                    FROM Athletes
                    ORDER BY AthleteID DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvAthletes.DataSource = dt;
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading athletes: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dgvAthletes.Columns.Count > 0)
            {
                dgvAthletes.Columns["ID"].Width = 60;
                dgvAthletes.Columns["Full Name"].Width = 150;
                dgvAthletes.Columns["Contact"].Width = 120;
                dgvAthletes.Columns["Status"].Width = 80;

                foreach (DataGridViewRow row in dgvAthletes.Rows)
                {
                    if (row.Cells["Status"].Value != null)
                    {
                        if (row.Cells["Status"].Value.ToString() == "Active")
                            row.Cells["Status"].Style.BackColor = System.Drawing.Color.LightGreen;
                        else
                            row.Cells["Status"].Style.BackColor = System.Drawing.Color.LightCoral;
                    }
                }
            }
        }

        // INSERT BUTTON 
        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmAthleteRegistration regForm = new frmAthleteRegistration();
            if (regForm.ShowDialog() == DialogResult.OK)
            {
                LoadAllAthletes();
                MessageBox.Show("✓ New athlete added successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // UPDATE BUTTON 
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAthletes.SelectedRows.Count == 0)
            {
                MessageBox.Show("⚠ Please select an athlete to update.",
                    "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int athleteID = Convert.ToInt32(dgvAthletes.SelectedRows[0].Cells["ID"].Value);
            string name = dgvAthletes.SelectedRows[0].Cells["Full Name"].Value.ToString();


            DialogResult result = MessageBox.Show(
                $"Update athlete information for:\n\n{name} (ID: {athleteID})\n\n" +
                "Enter new contact number:",
                "Update Athlete",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                UpdateAthleteContact(athleteID);
            }
        }

        private void UpdateAthleteContact(int athleteID)
        {
            try
            {
                string query = "SELECT ContactNumber, Email FROM Athletes WHERE AthleteID = @ID";
                SqlParameter[] parameters = { new SqlParameter("@ID", athleteID) };
                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    string currentContact = dt.Rows[0]["ContactNumber"].ToString();
                    string currentEmail = dt.Rows[0]["Email"].ToString();

                    // Get new contact number
                    string newContact = Microsoft.VisualBasic.Interaction.InputBox(
                        "Enter new contact number:",
                        "Update Contact",
                        currentContact);

                    if (string.IsNullOrEmpty(newContact))
                        return; 

                    // Get new email
                    string newEmail = Microsoft.VisualBasic.Interaction.InputBox(
                        "Enter new email address:",
                        "Update Email",
                        currentEmail);

                    // Update both contact and email
                    string updateQuery = @"UPDATE Athletes 
                SET ContactNumber = @Contact, 
                    Email = @Email, 
                    ModifiedDate = GETDATE() 
                WHERE AthleteID = @ID";

                    SqlParameter[] updateParams = {
                new SqlParameter("@Contact", newContact),
                new SqlParameter("@Email", string.IsNullOrWhiteSpace(newEmail) ?
                    (object)DBNull.Value : newEmail),
                new SqlParameter("@ID", athleteID)
            };

                    int rows = DatabaseHelper.ExecuteNonQuery(updateQuery, updateParams);

                    if (rows > 0)
                    {
                        MessageBox.Show("✓ Athlete information updated successfully!\n\n" +
                            $"New Contact: {newContact}\n" +
                            $"New Email: {(string.IsNullOrWhiteSpace(newEmail) ? "Not provided" : newEmail)}",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllAthletes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating athlete: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // DELETE BUTTON 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAthletes.SelectedRows.Count == 0)
            {
                MessageBox.Show("⚠ Please select an athlete to delete.",
                    "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int athleteID = Convert.ToInt32(dgvAthletes.SelectedRows[0].Cells["ID"].Value);
            string name = dgvAthletes.SelectedRows[0].Cells["Full Name"].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"⚠ WARNING ⚠\n\nAre you sure you want to PERMANENTLY DELETE:\n\n" +
                $"{name} (ID: {athleteID})?\n\n" +
                "This action CANNOT be undone!\n\n" +
                "All registration records for this athlete will also be deleted.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteAthlete(athleteID);
            }
        }

        private void DeleteAthlete(int athleteID)
        {
            try
            {
                string query = "DELETE FROM Athletes WHERE AthleteID = @ID";
                SqlParameter[] parameters = {
                    new SqlParameter("@ID", athleteID)
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("✓ Athlete deleted successfully!\n\n" +
                        "All related records have been removed from the database.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllAthletes();
                }
                else
                {
                    MessageBox.Show("✗ Failed to delete athlete.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting athlete:\n\n{ex.Message}\n\n" +
                    "Note: Cannot delete athlete with existing registrations.\n" +
                    "Delete their registrations first, or use 'Deactivate' instead.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SEARCH BUTTON
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Please enter a search term.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"
                    SELECT 
                        AthleteID AS 'ID',
                        CONCAT(FirstName, ' ', LastName) AS 'Full Name',
                        FORMAT(DateOfBirth, 'dd/MM/yyyy') AS 'Date of Birth',
                        Age,
                        Gender,
                        ContactNumber AS 'Contact',
                        Email,
                        Address,
                        EmergencyContactName AS 'Emergency Contact',
                        EmergencyContactPhone AS 'Emergency Phone',
                        FORMAT(EnrollmentDate, 'dd/MM/yyyy') AS 'Enrolled On',
                        CASE WHEN IsActive = 1 THEN 'Active' ELSE 'Inactive' END AS 'Status'
                    FROM Athletes
                    WHERE FirstName LIKE @Search OR LastName LIKE @Search 
                          OR CAST(AthleteID AS VARCHAR) LIKE @Search
                    ORDER BY AthleteID DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@Search", "%" + txtSearch.Text.Trim() + "%")
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                dgvAthletes.DataSource = dt;
                FormatGrid();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No athletes found.", "Search Result",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search error: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // REFRESH BUTTON
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadAllAthletes();
            MessageBox.Show("✓ Data refreshed!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // CLOSE BUTTON
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }
    }
}