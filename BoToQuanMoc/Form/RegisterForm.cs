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
    public partial class RegisterForm : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Lenovo\Desktop\Stuff\BTQM\03_NguyenHoaiVietChuong_2431101169404_BòTơQuánMộc\Cơ sở dữ liệu\BTQM.mdf"";Integrated Security=True;Connect Timeout=30"); 
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void register_loginBtn_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            this.Hide();
        }

        private void register_showPass_CheckedChanged(object sender, EventArgs e)
        {
            register_password.PasswordChar = register_showPass.Checked ? '\0' : '*';
            register_cPassword.PasswordChar = register_showPass.Checked ? '\0' : '*';
        }

        public bool emptyFields()
        {
            if(register_username.Text == "" || register_password.Text == "" || register_cPassword.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void register_btn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Xin hãy điên đầy đủ thông tin.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                //Kiem tra
                if(connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();

                        string selectUsername = "SELECT * FROM Users WHERE username = @usern"; 

                        using (SqlCommand checkUsername = new SqlCommand(selectUsername, connect))
                        {
                            checkUsername.Parameters.AddWithValue("@usern", register_username.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(checkUsername);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                string usern = register_username.Text.Substring(0, 1).ToUpper() + register_username.Text.Substring(1);
                                MessageBox.Show(usern + " đã tồn tại.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if(register_password.Text != register_cPassword.Text)
                            {
                                MessageBox.Show("Password không trùng.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if(register_password.Text.Length < 8)
                            {
                                MessageBox.Show("Password không phù hợp, cần ít nhất 8 kí tự.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO Users (Username, Password, profile_image, role, status, date_regist) " +
                                    "VALUES(@usern, @pass, @image, @role, @status, @date)";
                                DateTime today = DateTime.Today;

                                using(SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@usern", register_username.Text.Trim());
                                    cmd.Parameters.AddWithValue("@pass", register_password.Text.Trim());
                                    cmd.Parameters.AddWithValue("@image", "");
                                    cmd.Parameters.AddWithValue("@role", "Cashier");
                                    cmd.Parameters.AddWithValue("@status", "Approval");
                                    cmd.Parameters.AddWithValue("@date", today);

                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Đăng ký thành công!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Chuyên qua LOGIN FORM
                                    LoginForm loginForm = new LoginForm();
                                    loginForm.Show();

                                    this.Hide();
                                }
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

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
