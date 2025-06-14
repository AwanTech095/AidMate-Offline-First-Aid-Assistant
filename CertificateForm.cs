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
    public partial class CertificateForm : Form
    {
        public CertificateForm(int score)
        {
            InitializeComponent();
            lblTitleC.Text = "🎉 First Aid Quiz Certificate 🎉";
            lbl1Cert.Text = $"You passed with a score of {score}/5.\nThis certifies your basic first aid knowledge.";

        }

        private void CertificateForm_Load(object sender, EventArgs e)
        {

        }
    }
}
