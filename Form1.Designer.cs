namespace AidMateApp1
{
    partial class Form1
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
            this.cpr = new System.Windows.Forms.Button();
            this.frac = new System.Windows.Forms.Button();
            this.burn = new System.Windows.Forms.Button();
            this.choke = new System.Windows.Forms.Button();
            this.bookmark = new System.Windows.Forms.Button();
            this.msg = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.searchlabel = new System.Windows.Forms.Label();
            this.quick = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnRetry = new System.Windows.Forms.Button();
            this.btnQuiz = new System.Windows.Forms.Button();
            this.btnkit = new System.Windows.Forms.Button();
            this.lblStat = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cpr
            // 
            this.cpr.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cpr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cpr.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpr.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cpr.Location = new System.Drawing.Point(520, 31);
            this.cpr.Name = "cpr";
            this.cpr.Size = new System.Drawing.Size(156, 55);
            this.cpr.TabIndex = 1;
            this.cpr.Text = "CPR";
            this.cpr.UseVisualStyleBackColor = false;
            this.cpr.Click += new System.EventHandler(this.cpr_Click);
            // 
            // frac
            // 
            this.frac.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.frac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.frac.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frac.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.frac.Location = new System.Drawing.Point(742, 31);
            this.frac.Name = "frac";
            this.frac.Size = new System.Drawing.Size(174, 58);
            this.frac.TabIndex = 2;
            this.frac.Text = "Fractures";
            this.frac.UseVisualStyleBackColor = false;
            this.frac.Click += new System.EventHandler(this.frac_Click);
            // 
            // burn
            // 
            this.burn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.burn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.burn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.burn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.burn.Location = new System.Drawing.Point(962, 31);
            this.burn.Name = "burn";
            this.burn.Size = new System.Drawing.Size(147, 57);
            this.burn.TabIndex = 3;
            this.burn.Text = "Burns";
            this.burn.UseVisualStyleBackColor = false;
            this.burn.Click += new System.EventHandler(this.burn_Click);
            // 
            // choke
            // 
            this.choke.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.choke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.choke.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choke.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.choke.Location = new System.Drawing.Point(1161, 28);
            this.choke.Name = "choke";
            this.choke.Size = new System.Drawing.Size(174, 65);
            this.choke.TabIndex = 4;
            this.choke.Text = "Choking";
            this.choke.UseVisualStyleBackColor = false;
            this.choke.Click += new System.EventHandler(this.choke_Click);
            // 
            // bookmark
            // 
            this.bookmark.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bookmark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bookmark.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookmark.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bookmark.Location = new System.Drawing.Point(40, 28);
            this.bookmark.Name = "bookmark";
            this.bookmark.Size = new System.Drawing.Size(207, 58);
            this.bookmark.TabIndex = 6;
            this.bookmark.Text = "Bookmarks";
            this.bookmark.UseVisualStyleBackColor = false;
            this.bookmark.Click += new System.EventHandler(this.bookmark_Click);
            // 
            // msg
            // 
            this.msg.AutoSize = true;
            this.msg.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.msg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.msg.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.msg.Location = new System.Drawing.Point(507, 768);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(998, 54);
            this.msg.TabIndex = 7;
            this.msg.Text = "Welcome To AidMate - Your Offline First Aid Guide! ";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSearch.Location = new System.Drawing.Point(1682, 91);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(130, 31);
            this.txtSearch.TabIndex = 8;
            this.txtSearch.Text = "Search here!";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lstResults
            // 
            this.lstResults.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lstResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstResults.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResults.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lstResults.FormattingEnabled = true;
            this.lstResults.ItemHeight = 25;
            this.lstResults.Location = new System.Drawing.Point(1682, 145);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(130, 102);
            this.lstResults.TabIndex = 9;
            this.lstResults.DoubleClick += new System.EventHandler(this.lstResults_DoubleClick);
            this.lstResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstResults_KeyDown);
            // 
            // searchlabel
            // 
            this.searchlabel.AutoSize = true;
            this.searchlabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.searchlabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchlabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.searchlabel.Location = new System.Drawing.Point(1677, 37);
            this.searchlabel.Name = "searchlabel";
            this.searchlabel.Size = new System.Drawing.Size(82, 30);
            this.searchlabel.TabIndex = 10;
            this.searchlabel.Text = "Search";
            // 
            // quick
            // 
            this.quick.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.quick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quick.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quick.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.quick.Location = new System.Drawing.Point(40, 828);
            this.quick.Name = "quick";
            this.quick.Size = new System.Drawing.Size(231, 55);
            this.quick.TabIndex = 11;
            this.quick.Text = "Quick Access";
            this.quick.UseVisualStyleBackColor = false;
            this.quick.Click += new System.EventHandler(this.quick_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Image = global::AidMateApp1.Properties.Resources.eicon;
            this.pictureBox2.Location = new System.Drawing.Point(108, 751);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(74, 69);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStatus.Location = new System.Drawing.Point(16, 385);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(64, 28);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "label1";
            // 
            // btnRetry
            // 
            this.btnRetry.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRetry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetry.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetry.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRetry.Location = new System.Drawing.Point(40, 295);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(285, 52);
            this.btnRetry.TabIndex = 14;
            this.btnRetry.Text = "Reconnect To Internet !";
            this.btnRetry.UseVisualStyleBackColor = false;
            this.btnRetry.Click += new System.EventHandler(this.btnRetry_Click);
            // 
            // btnQuiz
            // 
            this.btnQuiz.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuiz.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuiz.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnQuiz.Location = new System.Drawing.Point(40, 206);
            this.btnQuiz.Name = "btnQuiz";
            this.btnQuiz.Size = new System.Drawing.Size(285, 58);
            this.btnQuiz.TabIndex = 15;
            this.btnQuiz.Text = "Certify Yourself !";
            this.btnQuiz.UseVisualStyleBackColor = false;
            this.btnQuiz.Click += new System.EventHandler(this.btnQuiz_Click);
            // 
            // btnkit
            // 
            this.btnkit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnkit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnkit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnkit.Location = new System.Drawing.Point(40, 122);
            this.btnkit.Name = "btnkit";
            this.btnkit.Size = new System.Drawing.Size(285, 58);
            this.btnkit.TabIndex = 16;
            this.btnkit.Text = "My First Aid Kit";
            this.btnkit.UseVisualStyleBackColor = false;
            this.btnkit.Click += new System.EventHandler(this.btnkit_Click);
            // 
            // lblStat
            // 
            this.lblStat.AutoSize = true;
            this.lblStat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblStat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStat.Location = new System.Drawing.Point(770, 872);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(70, 28);
            this.lblStat.TabIndex = 17;
            this.lblStat.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AidMateApp1.Properties.Resources.aidmatelogo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(1654, 855);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 133);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImage = global::AidMateApp1.Properties.Resources.ChatGPT_Image_May_3__2025__12_08_43_AM;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1868, 1008);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblStat);
            this.Controls.Add(this.btnkit);
            this.Controls.Add(this.btnQuiz);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.quick);
            this.Controls.Add(this.searchlabel);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.msg);
            this.Controls.Add(this.bookmark);
            this.Controls.Add(this.choke);
            this.Controls.Add(this.burn);
            this.Controls.Add(this.frac);
            this.Controls.Add(this.cpr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cpr;
        private System.Windows.Forms.Button frac;
        private System.Windows.Forms.Button burn;
        private System.Windows.Forms.Button choke;
        private System.Windows.Forms.Button bookmark;
        private System.Windows.Forms.Label msg;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Label searchlabel;
        private System.Windows.Forms.Button quick;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.Button btnQuiz;
        private System.Windows.Forms.Button btnkit;
        private System.Windows.Forms.Label lblStat;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

