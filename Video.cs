using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;


namespace AidMateApp1
{
    public partial class Video : Form
    {
        public Video(string videoFilePath)
        {
            InitializeComponent();
            this.Size = new Size(1280, 720);        // Set form size
            this.StartPosition = FormStartPosition.CenterScreen; // Center on screen
            this.FormBorderStyle = FormBorderStyle.FixedSingle;  // Prevent resizing
            this.MaximizeBox = false;

            try
            {
                // Ensure the path is properly formatted
                string fullPath = Path.GetFullPath(videoFilePath);

                if (File.Exists(fullPath))
                {
                    axWindowsMediaPlayer1.URL = fullPath;
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    axWindowsMediaPlayer1.settings.autoStart = true;
                }
                else
                {
                    MessageBox.Show($"Video file not found at:\n{fullPath}");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing video: {ex.Message}");
                this.Close();
            }

        }


        private void Video_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
