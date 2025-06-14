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
using System.Xml.Linq;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace AidMateApp1
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
            //this.BackColor = Color.DarkSlateGray;
            //ApplyRoundedCorners(btnSignUp);
            btnSignUp.MouseEnter += BtnSignUp_MouseEnter;
            btnSignUp.MouseLeave += BtnSignUp_MouseLeave;
            this.Size = new Size(1280, 720);        // Set form size
            this.StartPosition = FormStartPosition.CenterScreen; // Center on screen
            this.FormBorderStyle = FormBorderStyle.FixedSingle;  // Prevent resizing
            this.MaximizeBox = false;

        }
       
        private void BtnSignUp_MouseEnter(object sender, EventArgs e)
        {
            btnSignUp.BackColor = Color.LightSkyBlue;
        }

        private void BtnSignUp_MouseLeave(object sender, EventArgs e)
        {
            btnSignUp.BackColor = Color.White;
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string fullName = textBoxFullName.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string connStr = @"Server=desktop-vbbn320\SQLEXPRESS;Database=AidMateDB;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Check if email already exists
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Email = @Email", conn);
                checkCmd.Parameters.AddWithValue("@Email", email);
                int exists = (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    MessageBox.Show("This email is already registered.");
                    return;
                }

                // Insert new user
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (FullName, Email, Password) VALUES (@FullName, @Email, @Password)", conn);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Signup successful! Please login now.");
                this.Hide();
                new Login().Show();
            }
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}
