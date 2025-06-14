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
    public partial class FirstAidKit : Form
    {

        private string connectionString = @"Server=desktop-vbbn320\SQLEXPRESS;Database=AidMateDB;Integrated Security=True;";
        private string currentUserEmail;

        public FirstAidKit(string userEmail)
        {
            InitializeComponent();
            currentUserEmail = userEmail;

            cmbstatus.Items.AddRange(new string[] { "Available", "Out of Stock" });
            cmbstatus.SelectedIndex = 0;

            LoadKitItems();

            ListBoxKitItems.SelectedIndexChanged += listBoxKitItems_SelectedIndexChanged;
            btnAdd.Click += btnAdd_Click;
            btnDel.Click += btnDel_Click;
            btnClr.Click += btnClr_Click;
            btnBack.Click += btnBack_Click;
        }
        private void LoadKitItems()
        {
            ListBoxKitItems.Items.Clear();
            int outOfStockCount = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM FirstAidKit WHERE UserEmail = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", currentUserEmail);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string display = $"{reader["ItemName"]} - Qty: {reader["Quantity"]} - {reader["Status"]}";
                        ListBoxKitItems.Items.Add(display);

                        if (reader["Status"].ToString() == "Out of Stock")
                            outOfStockCount++;
                    }

                    lblReminder.Text = $"Items out of stock: {outOfStockCount}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading kit items: " + ex.Message);
                }
            }
        }




        private void FirstAidKit_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Fetch and trim values
            string item = textBoxItems.Text.Trim();
            string qty = textBoxQuantity.Text.Trim();
            string status = cmbstatus.SelectedItem?.ToString();

            // Validation
            if (string.IsNullOrWhiteSpace(item) || string.IsNullOrWhiteSpace(qty) || string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Please enter all fields.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO FirstAidKit (UserEmail, ItemName, Quantity, Status) VALUES (@Email, @Name, @Qty, @Status)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", currentUserEmail);
                cmd.Parameters.AddWithValue("@Name", item);
                cmd.Parameters.AddWithValue("@Qty", qty);
                cmd.Parameters.AddWithValue("@Status", status);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item added!");

                    // Disable button temporarily to prevent spam clicking
                    btnAdd.Enabled = false;
                    ClearFields();
                    LoadKitItems();
                    btnAdd.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding item: " + ex.Message);
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (ListBoxKitItems.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }

            string selectedItem = ListBoxKitItems.SelectedItem.ToString();
            string itemName = selectedItem.Split('-')[0].Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM FirstAidKit WHERE UserEmail = @Email AND ItemName = @Name";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", currentUserEmail);
                cmd.Parameters.AddWithValue("@Name", itemName);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item deleted.");
                    LoadKitItems();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting item: " + ex.Message);
                }
            }
        }

        private void listBoxKitItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxKitItems.SelectedIndex == -1) return;

            string selected = ListBoxKitItems.SelectedItem.ToString();
            string[] parts = selected.Split('-');

            textBoxItems.Text = parts[0].Trim();
            textBoxQuantity.Text = parts[1].Replace("Qty:", "").Trim();
            cmbstatus.SelectedItem = parts[2].Trim();
        }

        private void btnClr_Click(object sender, EventArgs e) => ClearFields();
        
            private void ClearFields()
        {
            textBoxItems.Text = "";
            textBoxQuantity.Text = "";
            cmbstatus.SelectedIndex = -1;  // Clear the dropdown selection
        }
    
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Ensure item is selected from the list
            if (ListBoxKitItems.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to update.");
                return;
            }

            // Validate fields
            string item = textBoxItems.Text.Trim();
            string qty = textBoxQuantity.Text.Trim();
            string status = cmbstatus.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(item) || string.IsNullOrWhiteSpace(qty) || string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Please fill all fields to update.");
                return;
            }

            // Extract original item name from the selected list item
            string selectedText = ListBoxKitItems.SelectedItem.ToString();
            string originalItemName = selectedText.Split('-')[0].Trim();  // e.g., "Bandages" from "Bandages - Qty: 2 - Available"

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE FirstAidKit 
                         SET ItemName = @NewName, Quantity = @Qty, Status = @Status 
                         WHERE UserEmail = @Email AND ItemName = @OldName";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", currentUserEmail);
                cmd.Parameters.AddWithValue("@OldName", originalItemName);
                cmd.Parameters.AddWithValue("@NewName", item);
                cmd.Parameters.AddWithValue("@Qty", qty);
                cmd.Parameters.AddWithValue("@Status", status);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Item updated!");
                        LoadKitItems();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Item not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating item: " + ex.Message);
                }
            }
        }
    }
    
}
