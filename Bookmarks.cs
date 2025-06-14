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
    public partial class Bookmarks : Form
    {

        private string connectionString = @"Server=desktop-vbbn320\SQLEXPRESS;Database=AidMateDB;Integrated Security=True;";
        private string currentUserEmail;

        public Bookmarks(string userEmail)
        {
            InitializeComponent();
            this.BackColor = Color.DarkGray;
            currentUserEmail = userEmail;
            this.Load += Bookmarks_Load;
            btnOpen.Click += btnOpen_Click;
            btnRemove.Click += btnRemove_Click;
            btnBack.Click += btnBack_Click;
            this.Size = new Size(1280, 720);        // Set form size
            this.StartPosition = FormStartPosition.CenterScreen; // Center on screen
            this.FormBorderStyle = FormBorderStyle.FixedSingle;  // Prevent resizing
            this.MaximizeBox = false;

            this.btnOpen.MouseEnter += new EventHandler(Button_MouseEnter);
            this.btnOpen.MouseLeave += new EventHandler(Button_MouseLeave);

            this.btnRemove.MouseEnter += new EventHandler(Button_MouseEnter);
            this.btnRemove.MouseLeave += new EventHandler(Button_MouseLeave);

            this.btnBack.MouseEnter += new EventHandler(Button_MouseEnter);
            this.btnBack.MouseLeave += new EventHandler(Button_MouseLeave);


            /*listBoxBookmarks.MouseDoubleClick += (s, e) =>
            {
                // Only open if a valid item was double-clicked
                if (listBoxBookmarks.SelectedItem != null && listBoxBookmarks.IndexFromPoint(e.Location) != ListBox.NoMatches)
                {
                    string category = listBoxBookmarks.SelectedItem.ToString();
                    CategoryUi guide = new CategoryUi(category, currentUserEmail);
                    guide.Show();
                }
            };*/
        }
       
        private void Bookmarks_Load(object sender, EventArgs e)
        {
            LoadBookmarks();

        }
        private void LoadBookmarks()
        {
            listBoxBookmarks.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT CategoryName FROM Bookmarks WHERE UserEmail = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", currentUserEmail);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        listBoxBookmarks.Items.Add(reader["CategoryName"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading bookmarks: " + ex.Message);
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (listBoxBookmarks.SelectedItem != null)
            {
                string category = listBoxBookmarks.SelectedItem.ToString();
                CategoryUi guide = new CategoryUi(category,currentUserEmail);
                guide.Show();
            }
            else
            {
                MessageBox.Show("Please select a guide to open.");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listBoxBookmarks.SelectedItem != null)
            {
                string selectedCategory = listBoxBookmarks.SelectedItem.ToString();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string deleteQuery = "DELETE FROM Bookmarks WHERE UserEmail = @Email AND CategoryName = @Category";
                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@Email", currentUserEmail);
                    cmd.Parameters.AddWithValue("@Category", selectedCategory);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Bookmark removed.");
                            LoadBookmarks(); // Refresh list
                        }
                        else
                        {
                            MessageBox.Show("Bookmark not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error removing bookmark: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a guide to remove.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();  // Back to home
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.LightGray; // Change to a lighter color on hover
            }
        }

        // Hover effect: revert the background color when mouse leaves
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = SystemColors.Control; // Revert to default color
            }
        }

        /*private void listBoxBookmarks_DoubleClick(object sender, EventArgs e)
        {
            btnOpen_Click(sender, e);
        }*/
    }


    // Hover effect: revert the background color when mouse leaves

}
