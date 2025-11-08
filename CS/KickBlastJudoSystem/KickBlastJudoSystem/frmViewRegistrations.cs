using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KickBlastJudoSystem
{
    public partial class frmViewRegistrations : Form
    {
        public frmViewRegistrations()
        {
            InitializeComponent();
            this.Load += FrmViewRegistrations_Load;
        }

        private void FrmViewRegistrations_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.Size = new System.Drawing.Size(900, 600);

            LoadAllRegistrations();
            FormatDataGridView();
        }

        // Method: Load all registrations from database. 
        private void LoadAllRegistrations()
        {
            try
            {
                string query = @"
            SELECT 
                mr.RegistrationID AS 'Fee ID',
                mr.AthleteID AS 'Athlete ID',
                CONCAT(a.FirstName, ' ', a.LastName) AS 'Athlete Name',
                tp.PlanName AS 'Training Plan',
                wc.CategoryName AS 'Weight Category',
                mr.CurrentWeight AS 'Current Weight (kg)',
                FORMAT(mr.RegistrationMonth, 'MMMM yyyy') AS 'Month',
                mr.TrainingPlanCost AS 'Training Plan Cost (Rs.)',
                mr.NumCompetitions AS 'No. of Competitions',
                mr.CompetitionCost AS 'Competition Cost (Rs.)',
                mr.PrivateCoachingHours AS 'Private Coaching Hours',
                mr.PrivateCoachingCost AS 'Private Coaching Cost (Rs.)',
                mr.TotalMonthlyCost AS 'Total Cost (Rs.)',
                mr.PaymentStatus AS 'Payment Status'
            FROM MonthlyRegistrations mr
            INNER JOIN Athletes a ON mr.AthleteID = a.AthleteID
            INNER JOIN TrainingPlans tp ON mr.PlanID = tp.PlanID
            INNER JOIN WeightCategories wc ON mr.CategoryID = wc.CategoryID
            ORDER BY mr.RegistrationDate DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvRegistrations.DataSource = dt;
                UpdateSummary(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading registrations:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method: DataGridView 
        private void FormatDataGridView()
        {
            if (dgvRegistrations.Columns.Count > 0)
            {
                dgvRegistrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgvRegistrations.AllowUserToAddRows = false;
                dgvRegistrations.AllowUserToDeleteRows = false;
                dgvRegistrations.ReadOnly = true;
                dgvRegistrations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvRegistrations.MultiSelect = false;
                dgvRegistrations.RowHeadersWidth = 25;


                dgvRegistrations.Columns["Fee ID"].Width = 60;
                dgvRegistrations.Columns["Athlete ID"].Width = 75;
                dgvRegistrations.Columns["Athlete Name"].Width = 130;
                dgvRegistrations.Columns["Training Plan"].Width = 100;
                dgvRegistrations.Columns["Weight Category"].Width = 110;
                dgvRegistrations.Columns["Current Weight (kg)"].Width = 110;
                dgvRegistrations.Columns["Month"].Width = 100;
                dgvRegistrations.Columns["Training Plan Cost (Rs.)"].Width = 120;
                dgvRegistrations.Columns["No. of Competitions"].Width = 100;
                dgvRegistrations.Columns["Competition Cost (Rs.)"].Width = 120;
                dgvRegistrations.Columns["Private Coaching Hours"].Width = 120;
                dgvRegistrations.Columns["Private Coaching Cost (Rs.)"].Width = 140;
                dgvRegistrations.Columns["Total Cost (Rs.)"].Width = 110;
                dgvRegistrations.Columns["Payment Status"].Width = 100;


                dgvRegistrations.Columns["Training Plan Cost (Rs.)"].DefaultCellStyle.Format = "N2";
                dgvRegistrations.Columns["Competition Cost (Rs.)"].DefaultCellStyle.Format = "N2";
                dgvRegistrations.Columns["Private Coaching Cost (Rs.)"].DefaultCellStyle.Format = "N2";
                dgvRegistrations.Columns["Total Cost (Rs.)"].DefaultCellStyle.Format = "N2";

                
                dgvRegistrations.Columns["Training Plan Cost (Rs.)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvRegistrations.Columns["Competition Cost (Rs.)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvRegistrations.Columns["Private Coaching Cost (Rs.)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvRegistrations.Columns["Total Cost (Rs.)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                
                dgvRegistrations.Columns["Fee ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRegistrations.Columns["Athlete ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRegistrations.Columns["No. of Competitions"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRegistrations.Columns["Private Coaching Hours"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRegistrations.Columns["Payment Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRegistrations.Columns["Current Weight (kg)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                
                foreach (DataGridViewRow row in dgvRegistrations.Rows)
                {
                    if (row.Cells["Payment Status"].Value != null)
                    {
                        string status = row.Cells["Payment Status"].Value.ToString();
                        if (status == "Paid")
                            row.Cells["Payment Status"].Style.BackColor = System.Drawing.Color.LightGreen;
                        else if (status == "Pending")
                            row.Cells["Payment Status"].Style.BackColor = System.Drawing.Color.LightYellow;
                        else if (status == "Overdue")
                            row.Cells["Payment Status"].Style.BackColor = System.Drawing.Color.LightCoral;
                    }
                }
            }
        }

        private void UpdateSummary(DataTable dt)
        {
            int totalRecords = dt.Rows.Count;
            double totalRevenue = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Total Cost (Rs.)"] != DBNull.Value)
                {
                    totalRevenue += Convert.ToDouble(row["Total Cost (Rs.)"]);
                }
            }

            lblTotalRecords.Text = $"Total Records: {totalRecords}";
            lblTotalRevenue.Text = $"Total Revenue: Rs. {totalRevenue:N2}";
        }

        // SEARCH BUTTON 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Please enter an athlete name to search.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearch.Focus();
                return;
            }

            SearchByAthleteName(txtSearch.Text.Trim());
        }

        // Method: Search registrations by athlete name 
        private void SearchByAthleteName(string searchText)
        {
            try
            {
                string query = @"
            SELECT 
                mr.RegistrationID AS 'Fee ID',
                mr.AthleteID AS 'Athlete ID',
                CONCAT(a.FirstName, ' ', a.LastName) AS 'Athlete Name',
                tp.PlanName AS 'Training Plan',
                wc.CategoryName AS 'Weight Category',
                mr.CurrentWeight AS 'Current Weight (kg)',
                FORMAT(mr.RegistrationMonth, 'MMMM yyyy') AS 'Month',
                mr.TrainingPlanCost AS 'Training Plan Cost (Rs.)',
                mr.NumCompetitions AS 'No. of Competitions',
                mr.CompetitionCost AS 'Competition Cost (Rs.)',
                mr.PrivateCoachingHours AS 'Private Coaching Hours',
                mr.PrivateCoachingCost AS 'Private Coaching Cost (Rs.)',
                mr.TotalMonthlyCost AS 'Total Cost (Rs.)',
                mr.PaymentStatus AS 'Payment Status'
            FROM MonthlyRegistrations mr
            INNER JOIN Athletes a ON mr.AthleteID = a.AthleteID
            INNER JOIN TrainingPlans tp ON mr.PlanID = tp.PlanID
            INNER JOIN WeightCategories wc ON mr.CategoryID = wc.CategoryID
            WHERE a.FirstName LIKE @Search 
               OR a.LastName LIKE @Search
               OR CONCAT(a.FirstName, ' ', a.LastName) LIKE @Search
               OR CAST(mr.AthleteID AS VARCHAR) LIKE @Search
            ORDER BY mr.RegistrationDate DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@Search", "%" + searchText + "%")
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                dgvRegistrations.DataSource = dt;
                FormatDataGridView();
                UpdateSummary(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show($"No records found for '{searchText}'.\n\nTip: Try searching by:\n• First name\n• Last name\n• Athlete ID",
                        "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"✓ Found {dt.Rows.Count} record(s)!",
                        "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search error:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // REFRESH BUTTON 
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadAllRegistrations();
            FormatDataGridView();
            MessageBox.Show("✓ Data refreshed successfully!",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // EXPORT BUTTON 
        private void btnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Export to Excel feature coming soon!\n\n" +
                "This will export all registration data to an Excel file.",
                "Feature Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                e.Handled = true;
            }
        }
    }
}