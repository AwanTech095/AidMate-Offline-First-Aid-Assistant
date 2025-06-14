namespace AidMateApp1
{
    partial class FirstAidKit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstAidKit));
            this.lblTitleFak = new System.Windows.Forms.Label();
            this.ListBoxKitItems = new System.Windows.Forms.CheckedListBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.textBoxItems = new System.Windows.Forms.TextBox();
            this.lblQuant = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbstatus = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnClr = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblReminder = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitleFak
            // 
            this.lblTitleFak.AutoSize = true;
            this.lblTitleFak.BackColor = System.Drawing.Color.Gainsboro;
            this.lblTitleFak.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleFak.Location = new System.Drawing.Point(818, 37);
            this.lblTitleFak.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleFak.Name = "lblTitleFak";
            this.lblTitleFak.Size = new System.Drawing.Size(280, 48);
            this.lblTitleFak.TabIndex = 3;
            this.lblTitleFak.Text = "My First Aid Kit";
            // 
            // ListBoxKitItems
            // 
            this.ListBoxKitItems.BackColor = System.Drawing.Color.Gainsboro;
            this.ListBoxKitItems.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxKitItems.FormattingEnabled = true;
            this.ListBoxKitItems.Location = new System.Drawing.Point(38, 174);
            this.ListBoxKitItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ListBoxKitItems.Name = "ListBoxKitItems";
            this.ListBoxKitItems.Size = new System.Drawing.Size(548, 624);
            this.ListBoxKitItems.TabIndex = 4;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.BackColor = System.Drawing.Color.Gainsboro;
            this.lblItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(597, 174);
            this.lblItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(122, 28);
            this.lblItem.TabIndex = 5;
            this.lblItem.Text = "Item Name:";
            // 
            // textBoxItems
            // 
            this.textBoxItems.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxItems.Location = new System.Drawing.Point(828, 174);
            this.textBoxItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxItems.Name = "textBoxItems";
            this.textBoxItems.Size = new System.Drawing.Size(252, 31);
            this.textBoxItems.TabIndex = 6;
            // 
            // lblQuant
            // 
            this.lblQuant.AutoSize = true;
            this.lblQuant.BackColor = System.Drawing.Color.Gainsboro;
            this.lblQuant.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuant.Location = new System.Drawing.Point(597, 260);
            this.lblQuant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuant.Name = "lblQuant";
            this.lblQuant.Size = new System.Drawing.Size(100, 28);
            this.lblQuant.TabIndex = 7;
            this.lblQuant.Text = "Quantity:";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuantity.Location = new System.Drawing.Point(828, 260);
            this.textBoxQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(252, 31);
            this.textBoxQuantity.TabIndex = 8;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(597, 363);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(76, 28);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Status:";
            // 
            // cmbstatus
            // 
            this.cmbstatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbstatus.FormattingEnabled = true;
            this.cmbstatus.Location = new System.Drawing.Point(828, 358);
            this.cmbstatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbstatus.Name = "cmbstatus";
            this.cmbstatus.Size = new System.Drawing.Size(252, 33);
            this.cmbstatus.TabIndex = 10;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAdd.Location = new System.Drawing.Point(604, 469);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(142, 57);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.Gainsboro;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDel.Location = new System.Drawing.Point(854, 469);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(142, 57);
            this.btnDel.TabIndex = 24;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnClr
            // 
            this.btnClr.BackColor = System.Drawing.Color.Gainsboro;
            this.btnClr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClr.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClr.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClr.Location = new System.Drawing.Point(1101, 469);
            this.btnClr.Name = "btnClr";
            this.btnClr.Size = new System.Drawing.Size(142, 57);
            this.btnClr.TabIndex = 25;
            this.btnClr.Text = "Clear";
            this.btnClr.UseVisualStyleBackColor = false;
            this.btnClr.Click += new System.EventHandler(this.btnClr_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Gainsboro;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBack.Location = new System.Drawing.Point(56, 50);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 44);
            this.btnBack.TabIndex = 26;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblReminder
            // 
            this.lblReminder.AutoSize = true;
            this.lblReminder.BackColor = System.Drawing.Color.Gainsboro;
            this.lblReminder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReminder.Location = new System.Drawing.Point(846, 648);
            this.lblReminder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReminder.Name = "lblReminder";
            this.lblReminder.Size = new System.Drawing.Size(109, 28);
            this.lblReminder.TabIndex = 27;
            this.lblReminder.Text = "Reminder:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Gainsboro;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUpdate.Location = new System.Drawing.Point(1341, 469);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(142, 57);
            this.btnUpdate.TabIndex = 28;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // FirstAidKit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1924, 818);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblReminder);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClr);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbstatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.lblQuant);
            this.Controls.Add(this.textBoxItems);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.ListBoxKitItems);
            this.Controls.Add(this.lblTitleFak);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FirstAidKit";
            this.Text = "FirstAidKit";
            this.Load += new System.EventHandler(this.FirstAidKit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleFak;
        private System.Windows.Forms.CheckedListBox ListBoxKitItems;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.TextBox textBoxItems;
        private System.Windows.Forms.Label lblQuant;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbstatus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnClr;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblReminder;
        private System.Windows.Forms.Button btnUpdate;
    }
}