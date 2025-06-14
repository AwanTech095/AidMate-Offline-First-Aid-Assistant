namespace AidMateApp1
{
    partial class CertificateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CertificateForm));
            this.lblTitleC = new System.Windows.Forms.Label();
            this.lbl1Cert = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitleC
            // 
            this.lblTitleC.AutoSize = true;
            this.lblTitleC.BackColor = System.Drawing.Color.Gainsboro;
            this.lblTitleC.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleC.Location = new System.Drawing.Point(468, 114);
            this.lblTitleC.Name = "lblTitleC";
            this.lblTitleC.Size = new System.Drawing.Size(587, 48);
            this.lblTitleC.TabIndex = 2;
            this.lblTitleC.Text = "Congratulations! You are certified";
            // 
            // lbl1Cert
            // 
            this.lbl1Cert.AutoSize = true;
            this.lbl1Cert.BackColor = System.Drawing.Color.Gainsboro;
            this.lbl1Cert.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1Cert.Location = new System.Drawing.Point(424, 281);
            this.lbl1Cert.Name = "lbl1Cert";
            this.lbl1Cert.Size = new System.Drawing.Size(92, 45);
            this.lbl1Cert.TabIndex = 3;
            this.lbl1Cert.Text = "label";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AidMateApp1.Properties.Resources.aidmatelogo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(1367, 485);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 82);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // CertificateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1494, 579);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl1Cert);
            this.Controls.Add(this.lblTitleC);
            this.Name = "CertificateForm";
            this.Text = "CertificateForm";
            this.Load += new System.EventHandler(this.CertificateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleC;
        private System.Windows.Forms.Label lbl1Cert;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}