using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AidMateApp1
{
    public partial class QuizForm : Form
    {

        private int score = 0;

        public QuizForm()
        {
            InitializeComponent();
            this.Size = new Size(1280, 720);        // Set form size
            this.StartPosition = FormStartPosition.CenterScreen; // Center on screen
            this.FormBorderStyle = FormBorderStyle.FixedSingle;  // Prevent resizing
            this.MaximizeBox = false;

            btnSubmit.MouseEnter += new EventHandler(Button_MouseEnter);
            btnSubmit.MouseLeave += new EventHandler(Button_MouseLeave);

            btncert.MouseEnter += new EventHandler(Button_MouseEnter);
            btncert.MouseLeave += new EventHandler(Button_MouseLeave);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            score = 0;

            // Check each correct answer and update score
            if (radioBtnQ1a.Checked) score++;  // Q1 correct
            if (radioBtnq2b.Checked) score++;  // Q2 correct
            if (radioBtnq3b.Checked) score++;  // Q3 correct
            if (radioBtnq4c.Checked) score++;  // Q4 correct
            if (radioBtnq5b.Checked) score++;  // Q5 correct

            lblShowResult.Text = $"You scored {score}/5";

            if (score >= 3)
            {
                MessageBox.Show("Congratulations! You passed.");
                btncert.Enabled = true;
            }
            else
            {
                MessageBox.Show("You did not pass. Try again.");
                btncert.Enabled = false;
            }
        }

        private void btncert_Click(object sender, EventArgs e)
        {
            CertificateForm cert = new CertificateForm(score);
            cert.Show();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

