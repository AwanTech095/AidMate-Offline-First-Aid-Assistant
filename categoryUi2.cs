using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AidMateApp1
{
    public partial class categoryUi2 : Form
    {

        private string connectionString = @"Server=desktop-vbbn320\SQLEXPRESS;Database=AidMateDB;Integrated Security=True;";
        private string currentCategory;
        private string currentUserEmail;
        private string videoFilePath;


        public categoryUi2(string categoryName, string userEmail)
        {
            InitializeComponent();
            currentCategory = categoryName;
            currentUserEmail = userEmail;
            label1.Text = categoryName; // Assuming labelCategory is the label in CategoryUi2 for category name
            LoadGuide(categoryName);
            this.Size = new Size(1100, 600);        // Set form size
            this.StartPosition = FormStartPosition.CenterScreen; // Center on screen
            this.FormBorderStyle = FormBorderStyle.FixedSingle;  // Prevent resizing
            this.MaximizeBox = false;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

        }
        private void LoadGuide(string categoryName)
        {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Title, Instructions, VideoFilePath FROM Guides WHERE CategoryId = (SELECT Id FROM Categories WHERE Name = @CategoryName)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        // Display text
                        richTextBoxUi.Text = dataTable.Rows[0]["Title"].ToString() + "\n\n" +
                                            dataTable.Rows[0]["Instructions"].ToString();

                        // Get video path - UNCOMMENT THIS
                        videoFilePath = dataTable.Rows[0]["VideoFilePath"].ToString();
                    }
                }


                // Set image from local resources
                switch (categoryName)
            {
                case "Burns":
                    pictureBox1.Image = Properties.Resources.burn;
                    break;
                case "CPR":
                    pictureBox1.Image = Properties.Resources.cpr1;
                    break;
                case "Fractures":
                    pictureBox1.Image = Properties.Resources.frac;
                    break;
                case "Choking":
                    pictureBox1.Image = Properties.Resources.choke;
                    break;
                case "Nosebleed":
                    pictureBox1.Image = Properties.Resources.nosebleed;
                    break;
                case "Heart Attack":
                    pictureBox1.Image = Properties.Resources.heartattack;
                    break;
                case "Seizure":
                    pictureBox1.Image = Properties.Resources.seizure;
                    break;
                case "Allergic Reaction":
                    pictureBox1.Image = Properties.Resources.allergicreaction;
                    break;
                case "Poisoning":
                    pictureBox1.Image = Properties.Resources.poisoning;
                    break;
                case "Fainting":
                    pictureBox1.Image = Properties.Resources.fainting;
                    break;
                case "Electric Shock":
                    pictureBox1.Image = Properties.Resources.electric;
                    break;
                default:
                    pictureBox1.Image = null; // fallback
                    break;
            }
        }


        private void categoryUi2_Load(object sender, EventArgs e)
        {

        }

        /*private void richTextBoxUi_TextChanged(object sender, EventArgs e)
        {
           // System.Diagnostics.Process.Start(e.LinkText);
        }*/

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Bookmarks (UserEmail, CategoryName) VALUES (@Email, @Category)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", currentUserEmail);
                cmd.Parameters.AddWithValue("@Category", currentCategory);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Guide bookmarked successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding bookmark: " + ex.Message);
                }
            }
        }

        private void VideoBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(videoFilePath))
            {
                MessageBox.Show("No video file path specified for this guide.");
                return;
            }

            try
            {
                // Convert to absolute path if needed
                string fullPath = Path.IsPathRooted(videoFilePath)
                    ? videoFilePath
                    : Path.Combine(Application.StartupPath, videoFilePath);

                if (File.Exists(fullPath))
                {
                    Video videoForm = new Video(fullPath);
                    videoForm.Show();
                }
                else
                {
                    MessageBox.Show($"Video file not found at:\n{fullPath}\n\nOriginal path: {videoFilePath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading video: {ex.Message}");
            }
        }
    }
}
