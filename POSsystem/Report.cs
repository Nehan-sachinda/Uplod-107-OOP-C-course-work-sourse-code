using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POSsystem
{
    public partial class Report : Form
    {
        // Replace with your database connection string
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DELL\\Documents\\POSsystem.mdf;Integrated Security=True;Connect Timeout=30";

        public Report()
        {
            InitializeComponent();
            LoadDefaultReport();
        }

        private void LoadDefaultReport()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Sales"; // Example query for default sales report
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvReport.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Sales WHERE Date >= @StartDate AND Date <= @EndDate";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value);
                    cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvReport.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying filter: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReport.Rows.Count > 0)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "CSV files (*.csv)|*.csv",
                        Title = "Save Report"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog.FileName))
                        {
                            // Write column headers
                            for (int i = 0; i < dgvReport.Columns.Count; i++)
                            {
                                file.Write(dgvReport.Columns[i].HeaderText + (i == dgvReport.Columns.Count - 1 ? "\n" : ","));
                            }

                            // Write rows
                            foreach (DataGridViewRow row in dgvReport.Rows)
                            {
                                for (int i = 0; i < dgvReport.Columns.Count; i++)
                                {
                                    file.Write(row.Cells[i].Value + (i == dgvReport.Columns.Count - 1 ? "\n" : ","));
                                }
                            }
                        }

                        MessageBox.Show("Report exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No data available to export.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
