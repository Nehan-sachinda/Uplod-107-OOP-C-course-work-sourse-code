using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POSsystem
{
    public partial class Bill : Form
    {
        // Replace with your database connection string
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DELL\\Documents\\POSsystem.mdf;Integrated Security=True;Connect Timeout=30";
        private decimal totalAmount = 0;

        public Bill()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Id, ProductName, Price FROM Products";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    cmbProducts.DataSource = table;
                    cmbProducts.DisplayMember = "ProductName";
                    cmbProducts.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddToBill_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedValue != null && int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "SELECT Price FROM Products WHERE Id = @Id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Id", cmbProducts.SelectedValue);
                        decimal price = Convert.ToDecimal(cmd.ExecuteScalar());

                        decimal lineTotal = price * quantity;
                        totalAmount += lineTotal;

                        dgvBill.Rows.Add(cmbProducts.Text, quantity, price, lineTotal);
                        lblTotal.Text = "Total: " + totalAmount.ToString("C");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding to bill: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a product and enter a valid quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClearBill_Click(object sender, EventArgs e)
        {
            dgvBill.Rows.Clear();
            totalAmount = 0;
            lblTotal.Text = "Total: $0.00";
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            if (dgvBill.Rows.Count > 0)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Loop through all rows in the DataGridView
                        foreach (DataGridViewRow row in dgvBill.Rows)
                        {
                            if (row.Cells["Product"].Value != null && row.Cells["Quantity"].Value != null && row.Cells["LineTotal"].Value != null)
                            {
                                // Get the product ID based on the product name
                                string productName = row.Cells["Product"].Value.ToString();
                                int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                                decimal totalPrice = Convert.ToDecimal(row.Cells["LineTotal"].Value);

                                // Query to get the ProductId from the database
                                string getProductIdQuery = "SELECT Id FROM Products WHERE ProductName = @ProductName";
                                SqlCommand cmdGetProductId = new SqlCommand(getProductIdQuery, conn);
                                cmdGetProductId.Parameters.AddWithValue("@ProductName", productName);
                                int productId = Convert.ToInt32(cmdGetProductId.ExecuteScalar());

                                // Insert the sale record into the Sales table
                                string insertQuery = @"
                            INSERT INTO Sales (ProductId, Quantity, TotalPrice, Date)
                            VALUES (@ProductId, @Quantity, @TotalPrice, @Date )";
                                SqlCommand cmdInsert = new SqlCommand(insertQuery, conn);
                                cmdInsert.Parameters.AddWithValue("@ProductId", productId);
                                cmdInsert.Parameters.AddWithValue("@Quantity", quantity);
                                cmdInsert.Parameters.AddWithValue("@TotalPrice", totalPrice);
                                cmdInsert.Parameters.AddWithValue("@Date", DateTime.Now);
                                 
                                cmdInsert.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Bill saved to Sales table and printed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear the DataGridView and reset total amount
                        dgvBill.Rows.Clear();
                        totalAmount = 0;
                        lblTotal.Text = "Total: $0.00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving bill: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No items in the bill to print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
