using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using AxWMPLib; // Add this to use the Windows Media Player control

namespace AidMateApp1
{
    public partial class CategoryUi : Form
    {

        private string connectionString = @"Server=desktop-vbbn320\SQLEXPRESS;Database=AidMateDB;Integrated Security=True;";

        private string videoFilePath;
        private string currentUserEmail; // pass this from Form1
        private string currentCategory;
       

        public CategoryUi(string categoryName, string userEmail)
        {
            InitializeComponent();
            label1.Text = categoryName;
            LoadGuide(categoryName);
            currentUserEmail = userEmail;
            currentCategory = categoryName;

        }


        /*private void LoadGuide(string categoryName)
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
                    richTextBox1.Text = dataTable.Rows[0]["Title"].ToString() + "\n\n" +
                                        dataTable.Rows[0]["Instructions"].ToString();

                    // Play video
                    videoFilePath = dataTable.Rows[0]["VideoFilePath"].ToString();
                    axWindowsMediaPlayer1.URL = videoFilePath;
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    axWindowsMediaPlayer1.Visible = true;  // Make sure the player is visible
                }
                else
                {
                    // If no video is available, you can hide the player control
                    axWindowsMediaPlayer1.Visible = false;
                }
            }

            // Set image from local resources
            switch (categoryName)
            {
                case "Burns":
                    pictureBox2.Image = Properties.Resources.burn;
                    break;
                case "CPR":
                    pictureBox2.Image = Properties.Resources.cpr1;
                    break;
                case "Fractures":
                    pictureBox2.Image = Properties.Resources.frac;
                    break;
                case "Choking":
                    pictureBox2.Image = Properties.Resources.choke;
                    break;
                case "Nosebleed":
                    pictureBox2.Image = Properties.Resources.nosebleed;
                    break;
                case "Heart Attack":
                    pictureBox2.Image = Properties.Resources.heartattack;
                    break;
                case "Seizure":
                    pictureBox2.Image = Properties.Resources.seizure;
                    break;
                case "Allergic Reaction":
                    pictureBox2.Image = Properties.Resources.allergicreaction;
                    break;
                case "Poisoning":
                    pictureBox2.Image = Properties.Resources.poisoning;
                    break;
                case "Fainting":
                    pictureBox2.Image = Properties.Resources.fainting;
                    break;
                case "Electric Shock":
                    pictureBox2.Image = Properties.Resources.electric;
                    break;
                default:
                    pictureBox2.Image = null; // fallback
                    break;
            }
        }*/
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
                    richTextBox1.Text = dataTable.Rows[0]["Title"].ToString() + "\n\n" +
                                        dataTable.Rows[0]["Instructions"].ToString();

                    // Get video path
                    videoFilePath = dataTable.Rows[0]["VideoFilePath"].ToString();

                    // Ensure the Windows Media Player control is visible and correctly sized
                    axWindowsMediaPlayer1.Visible = true;
                    axWindowsMediaPlayer1.Width = 640; // Adjust width as needed
                    axWindowsMediaPlayer1.Height = 360; // Adjust height as needed
                    axWindowsMediaPlayer1.Location = new Point(10, 200); // Adjust position as needed

                    // Play video if the file path is valid
                    if (!string.IsNullOrEmpty(videoFilePath) && System.IO.File.Exists(videoFilePath))
                    {
                        axWindowsMediaPlayer1.URL = videoFilePath;
                        axWindowsMediaPlayer1.Ctlcontrols.play();
                    }
                    else
                    {
                        MessageBox.Show("Invalid video file path or video file not found.");
                        axWindowsMediaPlayer1.Visible = false; // Hide if the video is not available
                    }
                }
                else
                {
                    // If no data found, hide the player
                    axWindowsMediaPlayer1.Visible = false;
                }
            }

            // Set image from local resources
            switch (categoryName)
            {
                case "Burns":
                    pictureBox2.Image = Properties.Resources.burn;
                    break;
                case "CPR":
                    pictureBox2.Image = Properties.Resources.cpr1;
                    break;
                case "Fractures":
                    pictureBox2.Image = Properties.Resources.frac;
                    break;
                case "Choking":
                    pictureBox2.Image = Properties.Resources.choke;
                    break;
                case "Nosebleed":
                    pictureBox2.Image = Properties.Resources.nosebleed;
                    break;
                case "Heart Attack":
                    pictureBox2.Image = Properties.Resources.heartattack;
                    break;
                case "Seizure":
                    pictureBox2.Image = Properties.Resources.seizure;
                    break;
                case "Allergic Reaction":
                    pictureBox2.Image = Properties.Resources.allergicreaction;
                    break;
                case "Poisoning":
                    pictureBox2.Image = Properties.Resources.poisoning;
                    break;
                case "Fainting":
                    pictureBox2.Image = Properties.Resources.fainting;
                    break;
                case "Electric Shock":
                    pictureBox2.Image = Properties.Resources.electric;
                    break;
                default:
                    pictureBox2.Image = null; // fallback
                    break;
            }
        }



        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);  //open the link in the browser
        }
        private void CategoryUi_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();         //close category form
           
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGreen;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void btnBookmark_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=desktop-vbbn320\SQLEXPRESS;Database=AidMateDB;Integrated Security=True;";

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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


    }
}
