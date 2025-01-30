using POSsystem;
using System;
using System.Windows.Forms;

namespace POSsystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            Inventory inventoryForm = new Inventory();
            inventoryForm.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Customer customerForm = new Customer();
            customerForm.Show();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            Bill employeeForm = new Bill();
            employeeForm.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Report reportsForm = new Report();
            reportsForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            this.Hide();
            loginForm.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}
