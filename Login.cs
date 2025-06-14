using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AidMateApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            this.Size = new Size(1280, 720);        // Set form size
            this.StartPosition = FormStartPosition.CenterScreen; // Center on screen
            this.FormBorderStyle = FormBorderStyle.FixedSingle;  // Prevent resizing
            this.MaximizeBox = false;
            btnLogin.MouseEnter += btnLogin_MouseEnter;
            btnLogin.MouseLeave += btnLogin_MouseLeave;
            btnGuest.MouseEnter += btnGuest_MouseEnter;
            btnGuest.MouseLeave += btnGuest_MouseLeave;


        }

        private void Login_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.DimGray;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            string connStr = @"Server=desktop-vbbn320\SQLEXPRESS;Database=AidMateDB;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password", conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                int result = (int)cmd.ExecuteScalar();

                if (result > 0)
                {
                    MessageBox.Show("Login successful!");
                    this.Hide();
                    Form1 home = new Form1(email,isGuest:false);
                    home.Show();
                }
                else
                {
                    MessageBox.Show("Invalid email or password.");
                }
            }
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            string guestEmail = "guest@aidmate.com"; // virtual email
            Form1 home = new Form1(guestEmail, isGuest: true);
            home.Show();
            this.Hide();
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.LightGreen;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromName("Control");
        }

        // Hover effect for Guest button
        private void btnGuest_MouseEnter(object sender, EventArgs e)
        {
            btnGuest.BackColor = Color.LightBlue;
        }

        private void btnGuest_MouseLeave(object sender, EventArgs e)
        {
            btnGuest.BackColor = Color.FromName("Control");
        }


    }
}
