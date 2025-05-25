using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace BoToQuanMoc
{
    public partial class LoginForm : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Lenovo\Desktop\Stuff\BTQM\03_NguyenHoaiVietChuong_2431101169404_BòTơQuánMộc\Cơ sở dữ liệu\BTQM.mdf"";Integrated Security=True;Connect Timeout=30");

        public LoginForm()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_registerBtn_Click(object sender, EventArgs e)
        {
            RegisterForm regForm = new RegisterForm();
            regForm.Show();

            this.Hide();
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }

        public bool emptyFields()
        {
            if(login_username.Text == "" || login_password.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Cần điền đầy đủ thông tin.", "Error Message", MessageBoxButtons.OK);
            }
            else
            {
                if(connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();

                        string selectAccount = "SELECT COUNT(*) FROM users WHERE username = @usern AND password = @pass AND status = @status";

                        using (SqlCommand cmd = new SqlCommand(selectAccount, connect))
                        {
                            cmd.Parameters.AddWithValue("@usern", login_username.Text.Trim());
                            cmd.Parameters.AddWithValue("@pass", login_password.Text.Trim());
                            cmd.Parameters.AddWithValue("@status", "Active");
                            int rowCount = (int)cmd.ExecuteScalar();

                            if(rowCount > 0)
                            {
                                string selectRole = "SELECT role FROM users WHERE username = @usern AND password = @pass";

                                using(SqlCommand getRole = new SqlCommand(selectRole, connect))
                                {
                                    getRole.Parameters.AddWithValue("@usern", login_username.Text.Trim());
                                    getRole.Parameters.AddWithValue("@pass", login_password.Text.Trim());

                                    string userRole = getRole.ExecuteScalar() as string;

                                    MessageBox.Show("Đăng nhập thành công!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    if (userRole == "Admin")
                                    {
                                        //username = login_username.Text;
                                        AdminMainForm adminForm = new AdminMainForm();
                                        adminForm.Show();

                                        this.Hide();
                                    }
                                    else if (userRole == "Cashier")
                                    {
                                        CashierMainForm cashierForm = new CashierMainForm();
                                        cashierForm.Show();

                                        this.Hide();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Username/Password không đúng hoặc chưa được duyệt bởi Admin.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
