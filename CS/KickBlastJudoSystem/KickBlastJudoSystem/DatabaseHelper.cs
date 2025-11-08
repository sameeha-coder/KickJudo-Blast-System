using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KickBlastJudoSystem
{
    /// <summary>
    /// Database Helper Class - Handles all database connections and operations
    /// </summary>
    public class DatabaseHelper
    {
        private static string connectionString =
    @"Data Source=DELL-LAPTOP\SQLEXPRESS;Initial Catalog=KickBlastJudoDB;Integrated Security=True;TrustServerCertificate=True";

        // OR if using full SQL Server:
        // private static string connectionString = 
        //     @"Server=localhost;Database=KickBlastJudoDB;Trusted_Connection=True;";

        // Alternative connection string for SQL Server
        // private static string connectionString = 
        //     @"Server=localhost;Database=KickBlastJudoDB;Trusted_Connection=True;";

        /// <summary>
        /// Get a new database connection
        /// </summary>
        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection error: {ex.Message}",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Test database connection
        /// </summary>
        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot connect to database.\n\nError: {ex.Message}",
                    "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Execute SELECT query and return DataTable
        /// </summary>
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Query error: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        /// <summary>
        /// Execute INSERT, UPDATE, DELETE queries
        /// </summary>
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        conn.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database operation failed: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return rowsAffected;
        }

        /// <summary>
        /// Execute query and return single value (for COUNT, MAX, etc.)
        /// </summary>
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            object result = null;
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        conn.Open();
                        result = cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database operation failed: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        /// <summary>
        /// Fill ComboBox with data from database
        /// </summary>
        public static void FillComboBox(ComboBox comboBox, string query,
                                       string displayMember, string valueMember)
        {
            try
            {
                DataTable dt = ExecuteQuery(query);
                comboBox.DataSource = dt;
                comboBox.DisplayMember = displayMember;
                comboBox.ValueMember = valueMember;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}",
                    "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}