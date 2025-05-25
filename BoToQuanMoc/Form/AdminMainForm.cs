using CafeShopManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoToQuanMoc
{
    public partial class AdminMainForm : Form
    {
        
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void adminAddUsers_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn chắc chắn muốn đăng xuất?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

                this.Hide();
            }
        }

        private void AddCashier_Click(object sender, EventArgs e)
        {
            adminDashBoard1.Visible = false;
            adminAddUsers1.Visible = true;
            adminAddProducts1.Visible = false;

            AdminAddUsers aaUsers = adminAddUsers1 as AdminAddUsers;

            if (aaUsers != null)
            {
                aaUsers.refreshData();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            cashierCustomersForm1.Visible = false;
            adminDashBoard1.Visible = true;
            adminAddUsers1.Visible = false;
            adminAddProducts1.Visible = false;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            cashierCustomersForm1.Visible = false;
            adminDashBoard1.Visible = false;
            adminAddUsers1.Visible = false;
            adminAddProducts1.Visible = true;

            AdminAddProducts aaUsers = adminAddProducts1 as AdminAddProducts;

            if (aaUsers != null)
            {
                aaUsers.refreshData();
            }
        }

        private void adminAddProducts1_Load(object sender, EventArgs e)
        {

        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            cashierCustomersForm1.Visible = true;
            adminDashBoard1.Visible = false;
            adminAddUsers1.Visible = false;
            adminAddProducts1.Visible = false;

            CashierCustomersForm Customer = cashierCustomersForm1 as CashierCustomersForm;

            if (Customer != null)
            {
                Customer.refreshData();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
