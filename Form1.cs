using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Data.SqlClient;

namespace AidMateApp1
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Server=desktop-vbbn320\SQLEXPRESS;Database=AidMateDB;Integrated Security=True;";

        private List<string> categories = new List<string>();
        private string currentUserEmail;
        private bool isGuestUser;

        public Form1(string email, bool isGuest)
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form1_Load);
            this.lstResults.DoubleClick += new EventHandler(this.lstResults_DoubleClick);
            isGuestUser = isGuest;
            this.FormClosed += (s, e) => Application.Exit();
            currentUserEmail = email;
            this.Size = new Size(1280, 720);        // Set form size
            this.StartPosition = FormStartPosition.CenterScreen; // Center on screen
            this.FormBorderStyle = FormBorderStyle.FixedSingle;  // Prevent resizing
            this.MaximizeBox = false;

           

            bookmark.MouseEnter += new EventHandler(Button_MouseEnter);
            bookmark.MouseLeave += new EventHandler(Button_MouseLeave);

            btnQuiz.MouseEnter += new EventHandler(Button_MouseEnter);
            btnQuiz.MouseLeave += new EventHandler(Button_MouseLeave);

            btnkit.MouseEnter += new EventHandler(Button_MouseEnter);
            btnkit.MouseLeave += new EventHandler(Button_MouseLeave);


        }

        private bool IsInternetAvailable()
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send("8.8.8.8", 1000); // Google's DNS server
                return reply.Status == IPStatus.Success;
            }
            catch
            {
                return false;
            }
        }

        //function to check internet connection and update label
        private void CheckInternetConnection()
        {
            bool isConnected = IsInternetAvailable();
            if (!isConnected)
            {
                lblStatus.Text = "You are offline. Some features may not be available.";
                lblStatus.ForeColor = Color.Red;
            }
            else
            {
                lblStatus.Text = "You are online. All features are available.";
                lblStatus.ForeColor = Color.DarkBlue;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //check for internet connection when the form loads
            CheckInternetConnection();
            LoadCategories();
            if (isGuestUser)
            {
                bookmark.Enabled = false;
                btnkit.Enabled = false;
                btnQuiz.Enabled = false;

                // Optional: hide them completely
                bookmark.Visible = false;
                btnkit.Visible = false;
                btnQuiz.Visible = false;

                // Optional message to show guest mode
                lblStat.Text = "Guest Mode: Some features are disabled.";
                lblStat.ForeColor = Color.LightGray;
            }
            else
            {
                // Not in guest mode
                lblStat.Text = "All features are available!";
                lblStat.ForeColor = Color.DarkGray;
            }


        }

        //private bool suppressSelectionChanged = true; // 👈 Add this at class level

        /*private void LoadCategories()
        {
            categories.Clear();  // Clear the list before fetching fresh data

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Name FROM Categories";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        categories.Add(reader["Name"].ToString());
                    }

                    // Update the ListBox with categories
                    lstResults.DataSource = categories;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching categories: " + ex.Message);
                }
            }
        }*/
        //private bool suppressSelectionChanged = true; // 👈 Add this at class level
        private void LoadCategories()
        {
            categories.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Name FROM Categories";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        categories.Add(reader["Name"].ToString());
                    }

                    //suppressSelectionChanged = true; // prevent false trigger
                    lstResults.DataSource = null;    // optional cleanup
                    lstResults.DataSource = categories;
                    //suppressSelectionChanged = false; // re-enable after load
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching categories: " + ex.Message);
                }
            }
        }

        private void cpr_Click(object sender, EventArgs e) => OpenCategoryForm("CPR");
        private void frac_Click(object sender, EventArgs e) => OpenCategoryForm("Fractures");
        private void burn_Click(object sender, EventArgs e) => OpenCategoryForm("Burns");
        private void choke_Click(object sender, EventArgs e) => OpenCategoryForm("Choking");

        private void OpenCategoryForm(string categoryName)
        {
            categoryUi2 categoryForm = new categoryUi2(categoryName, currentUserEmail);
            categoryForm.Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = txtSearch.Text.ToLower();
            var results = categories
                .Where(c => c.ToLower().Contains(query))
                .ToList();

            lstResults.DataSource = results;
        }

        /*private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstResults.SelectedItem != null)
            {
                string selectedCategory = lstResults.SelectedItem.ToString();
                CategoryUi categoryForm = new CategoryUi(selectedCategory);  //only one argument
                categoryForm.Show();
            }
        }*/

        /*private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppressSelectionChanged) return;

            if (lstResults.SelectedItem != null)
            {
                string selectedCategory = lstResults.SelectedItem.ToString();
                CategoryUi categoryForm = new CategoryUi(selectedCategory);
                categoryForm.Show();
            }
        }*/
        private void lstResults_DoubleClick(object sender, EventArgs e)
        {
            if (lstResults.SelectedItem != null)
            {
                string selectedCategory = lstResults.SelectedItem.ToString();
                categoryUi2 categoryForm = new categoryUi2(selectedCategory, currentUserEmail);
                categoryForm.Show();
            }
        }


        private void lstResults_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstResults.SelectedItem != null)
            {
                string selectedCategory = lstResults.SelectedItem.ToString();
                categoryUi2 categoryForm = new categoryUi2(selectedCategory, currentUserEmail); //or pass 'this' if needed
                categoryForm.Show();
            }
        }

        private void quick_Click(object sender, EventArgs e)
        {
          
          Emergency emergencyForm = new Emergency();
          emergencyForm.Show(); //display the emergency form
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            CheckInternetConnection();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bookmark_Click(object sender, EventArgs e)
        {
            Bookmarks bookmarkForm = new Bookmarks(currentUserEmail);
            bookmarkForm.Show();
        }

        private void btnQuiz_Click(object sender, EventArgs e)
        {
            QuizForm quiz = new QuizForm();
            quiz.Show();
        }

        private void btnkit_Click(object sender, EventArgs e)
        {
            FirstAidKit kitForm = new FirstAidKit(currentUserEmail);
            kitForm.Show();
        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BackColor = Color.LightGreen; // Change color on hover
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BackColor = SystemColors.Control; // Default color when not hovered
            }
        }
    }
}
