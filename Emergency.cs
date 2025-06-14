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
    public partial class Emergency : Form
    {

        private string connectionString = @"Server=desktop-vbbn320\SQLEXPRESS;Database=AidMateDB;Integrated Security=True;";
        public Emergency()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Emergency_Load);
            this.BackColor = Color.DarkGray;

            this.cmbCity.MouseEnter += new System.EventHandler(this.cmbCity_MouseEnter);
            this.cmbCity.MouseLeave += new System.EventHandler(this.cmbCity_MouseLeave);

            //for hovering
            this.back2.MouseEnter += new System.EventHandler(this.back2_MouseEnter);
            this.back2.MouseLeave += new System.EventHandler(this.back2_MouseLeave);

            policetxt.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RichTextBox_LinkClicked);
            firetxt.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RichTextBox_LinkClicked);
            rescuetxt.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RichTextBox_LinkClicked);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Emergency_Load(object sender, EventArgs e)
        {
            cmbCity.Items.AddRange(new string[]
            {
                "Karachi", "Lahore", "Islamabad", "Faisalabad", "Multan",
                "Quetta", "Rawalpindi", "Peshawar", "Gujranwala"
            });
            cmbCity.SelectedIndex = 0;
        }


        /*private void Emergency_Load(object sender, EventArgs e)
        {
            //populating the ComboBox with city names
            cmbCity.Items.Add("Karachi");
            cmbCity.Items.Add("Lahore");
            cmbCity.Items.Add("Islamabad");
            cmbCity.Items.Add("Faisalabad");
            cmbCity.Items.Add("Multan");
            cmbCity.Items.Add("Quetta");
            cmbCity.Items.Add("Rawalpindi");
            cmbCity.Items.Add("Peshawar");
            cmbCity.Items.Add("Gujranwala");
            cmbCity.SelectedIndex = 0;  // defaukt set to karachi
        }*/

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCity = cmbCity.SelectedItem.ToString();

            // Clear fields before loading
            policetxt.Clear();
            firetxt.Clear();
            rescuetxt.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM EmergencyContacts WHERE City = @City";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@City", selectedCity);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string type = reader["ServiceType"].ToString();
                    string info = $"Phone Num: {reader["PhoneNumber"]}\n" +
                                  $"Location: {reader["Location"]}\n" +
                                  $"24/7 Availability: {reader["Availability"]}\n" +
                                  $"Website: {reader["Website"]}\n" +
                                  $"Email: {reader["Email"]}\n" +
                                  $"Special Services: {reader["SpecialServices"]}\n" +
                                  $"Note: {reader["Notes"]}";

                    if (type == "Police") policetxt.Text = "Police:\n" + info;
                    else if (type == "Fire Brigade") firetxt.Text = "Fire Brigade:\n" + info;
                    else if (type == "Rescue") rescuetxt.Text = "Rescue:\n" + info;
                }
                reader.Close();
            }
        }



        /*private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCity = cmbCity.SelectedItem.ToString(); 

            //based on the selected city,populated the contact information
            switch (selectedCity)
            {
                case "Karachi":
                    policetxt.Text = "Police:\nPhone Num: 021-99214000\nLocation: Saddar, Karachi\n24/7 Availability: Yes\nWebsite: www.karachi-police.gov.pk\nEmail: police@karachi.gov.pk\nSpecial Services: Cybercrime, Anti-Terrorism, Women’s Cell\nImportant Note: In case of an accident or emergency, stay calm and give clear information about the situation and your location.";
                    firetxt.Text = "Fire Brigade:\nPhone Num: 102\nLocation: Korangi, Karachi\n24/7 Availability: Yes\nWebsite: www.karachi-firebrigade.gov.pk\nEmail: fire@karachi.gov.pk\nSafety Tip: Never use water on electrical fires, use a fire extinguisher.\nEvacuate the area immediately in case of fire; do not use elevators.";
                    rescuetxt.Text = "Rescue:\nPhone Num: 1122\nLocation: Gulshan-e-Iqbal, Karachi\n24/7 Availability: Yes\nWebsite: www.rescue1122.gov.pk\nEmail: rescue@karachi.gov.pk\nMedical Assistance: First aid for burns, fractures, trauma, and other injuries.\nImportant Note: If you or someone is injured, stay still and avoid movement to prevent further injuries.";
                    break;

                case "Lahore":
                    policetxt.Text = "Police:\nPhone Num: 042-99211111\nLocation: Shahdara, Lahore\n24/7 Availability: Yes\nWebsite: www.lahore-police.gov.pk\nEmail: police@lahore.gov.pk\nSpecial Services: Anti-Crime Unit, Women’s Cell\nImportant Note: If you see suspicious activity, report it immediately to ensure safety.";
                    firetxt.Text = "Fire Brigade:\nPhone Num: 16\nLocation: Near Liberty Market, Lahore\n24/7 Availability: Yes\nWebsite: www.lahore-firebrigade.gov.pk\nEmail: fire@lahore.gov.pk\nSafety Tip: Always check smoke detectors; if you smell gas, do not use open flames.";
                    rescuetxt.Text = "Rescue:\nPhone Num: 1122\nLocation: Gulberg, Lahore\n24/7 Availability: Yes\nWebsite: www.rescue1122.gov.pk\nEmail: rescue@lahore.gov.pk\nMedical Assistance: First aid for burns, fractures, and trauma.\nImportant Note: If you’re in a crowd during a disaster, stay close to your family and call for help immediately.";
                    break;

                case "Islamabad":
                    policetxt.Text = "Police:\nPhone Num: 051-9259065\nLocation: Blue Area, Islamabad\n24/7 Availability: Yes\nWebsite: www.islamabad-police.gov.pk\nEmail: police@islamabad.gov.pk\nSpecial Services: Cybercrime, Child Protection\nImportant Note: Always call the police immediately when you witness criminal activity.";
                    firetxt.Text = "Fire Brigade:\nPhone Num: 16\nLocation: Sector G-7, Islamabad\n24/7 Availability: Yes\nWebsite: www.islamabad-firebrigade.gov.pk\nEmail: fire@islamabad.gov.pk\nSafety Tip: Keep a fire extinguisher in your kitchen and near electrical appliances.";
                    rescuetxt.Text = "Rescue:\nPhone Num: 1122\nLocation: F-6, Islamabad\n24/7 Availability: Yes\nWebsite: www.rescue1122.gov.pk\nEmail: rescue@islamabad.gov.pk\nMedical Assistance: First aid for burns, fractures, trauma, and more.\nImportant Note: Avoid moving someone who is seriously injured unless it’s necessary.";
                    break;

                case "Faisalabad":
                    policetxt.Text = "Police:\nPhone Num: 041-9200000\nLocation: Civil Lines, Faisalabad\n24/7 Availability: Yes\nWebsite: www.faisalabad-police.gov.pk\nEmail: police@faisalabad.gov.pk\nSpecial Services: Anti-Terrorism, Crime Investigation\nImportant Note: Contact the police immediately if you encounter any suspicious activity.";
                    firetxt.Text = "Fire Brigade:\nPhone Num: 16\nLocation: Madina Town, Faisalabad\n24/7 Availability: Yes\nWebsite: www.faisalabad-firebrigade.gov.pk\nEmail: fire@faisalabad.gov.pk\nSafety Tip: In case of a fire, evacuate the building and do not use elevators.";
                    rescuetxt.Text = "Rescue:\nPhone Num: 1122\nLocation: Sargodha Road, Faisalabad\n24/7 Availability: Yes\nWebsite: www.rescue1122.gov.pk\nEmail: rescue@faisalabad.gov.pk\nMedical Assistance: First aid for trauma, burns, and fractures.\nImportant Note: Ensure you stay calm during emergencies and follow the instructions of emergency responders.";
                    break;

                case "Multan":
                    policetxt.Text = "Police:\nPhone Num: 061-9200222\nLocation: Bosan Road, Multan\n24/7 Availability: Yes\nWebsite: www.multan-police.gov.pk\nEmail: police@multan.gov.pk\nSpecial Services: Anti-Drug Unit, Investigation\nImportant Note: Report any suspicious activities immediately to the police.";
                    firetxt.Text = "Fire Brigade:\nPhone Num: 16\nLocation: Shujabad Road, Multan\n24/7 Availability: Yes\nWebsite: www.multan-firebrigade.gov.pk\nEmail: fire@multan.gov.pk\nSafety Tip: Always have a fire escape plan and ensure your family knows the route.";
                    rescuetxt.Text = "Rescue:\nPhone Num: 1122\nLocation: Cantt Area, Multan\n24/7 Availability: Yes\nWebsite: www.rescue1122.gov.pk\nEmail: rescue@multan.gov.pk\nMedical Assistance: First aid for burns, fractures, trauma.\nImportant Note: Always call for help immediately after an accident.";
                    break;

                case "Quetta":
                    policetxt.Text = "Police:\nPhone Num: 081-9200000\nLocation: Brewery Road, Quetta\n24/7 Availability: Yes\nWebsite: www.quetta-police.gov.pk\nEmail: police@quetta.gov.pk\nSpecial Services: Anti-Crime, Women’s Protection\nImportant Note: Do not hesitate to contact the police in case of emergency.";
                    firetxt.Text = "Fire Brigade:\nPhone Num: 16\nLocation: Jinnah Road, Quetta\n24/7 Availability: Yes\nWebsite: www.quetta-firebrigade.gov.pk\nEmail: fire@quetta.gov.pk\nSafety Tip: Evacuate immediately in case of fire and avoid using elevators.";
                    rescuetxt.Text = "Rescue:\nPhone Num: 1122\nLocation: Civil Lines, Quetta\n24/7 Availability: Yes\nWebsite: www.rescue1122.gov.pk\nEmail: rescue@quetta.gov.pk\nMedical Assistance: First aid for injuries, burns, and trauma.\nImportant Note: Avoid panic and stay away from dangerous areas in case of a disaster.";
                    break;

                case "Rawalpindi":
                    policetxt.Text = "Police:\nPhone Num: 051-9271122\nLocation: Saddar, Rawalpindi\n24/7 Availability: Yes\nWebsite: www.rawalpindi-police.gov.pk\nEmail: police@rawalpindi.gov.pk\nSpecial Services: Cybercrime, Crime Prevention\nImportant Note: If you are in danger, stay calm and provide the location.";
                    firetxt.Text = "Fire Brigade:\nPhone Num: 16\nLocation: Murree Road, Rawalpindi\n24/7 Availability: Yes\nWebsite: www.rawalpindi-firebrigade.gov.pk\nEmail: fire@rawalpindi.gov.pk\nSafety Tip: Keep fire exits clear and know the evacuation routes.";
                    rescuetxt.Text = "Rescue:\nPhone Num: 1122\nLocation: Raja Bazaar, Rawalpindi\n24/7 Availability: Yes\nWebsite: www.rescue1122.gov.pk\nEmail: rescue@rawalpindi.gov.pk\nMedical Assistance: First aid for burns, injuries, and other emergency medical issues.\nImportant Note: Stay away from fire hazards and call for help immediately.";
                    break;

                case "Peshawar":
                    policetxt.Text = "Police:\nPhone Num: 091-9212121\nLocation: Saddar, Peshawar\n24/7 Availability: Yes\nWebsite: www.peshawar-police.gov.pk\nEmail: police@peshawar.gov.pk\nSpecial Services: Anti-Terrorism, Crime Prevention\nImportant Note: In case of emergency, provide clear and accurate information to the police.";
                    firetxt.Text = "Fire Brigade:\nPhone Num: 16\nLocation: University Road, Peshawar\n24/7 Availability: Yes\nWebsite: www.peshawar-firebrigade.gov.pk\nEmail: fire@peshawar.gov.pk\nSafety Tip: Never use water on electrical fires, use fire extinguishers or call for help immediately.";
                    rescuetxt.Text = "Rescue:\nPhone Num: 1122\nLocation: Khyber Bazaar, Peshawar\n24/7 Availability: Yes\nWebsite: www.rescue1122.gov.pk\nEmail: rescue@peshawar.gov.pk\nMedical Assistance: First aid for burns, fractures, and trauma.\nImportant Note: Stay calm and follow the instructions given by the emergency responders.";
                    break;

                case "Gujranwala":
                    policetxt.Text = "Police:\nPhone Num: 055-9200000\nLocation: GT Road, Gujranwala\n24/7 Availability: Yes\nWebsite: www.gujranwala-police.gov.pk\nEmail: police@gujranwala.gov.pk\nSpecial Services: Crime Prevention, Traffic Control\nImportant Note: Always provide clear information to the police during emergencies.";
                    firetxt.Text = "Fire Brigade:\nPhone Num: 16\nLocation: Alipur, Gujranwala\n24/7 Availability: Yes\nWebsite: www.gujranwala-firebrigade.gov.pk\nEmail: fire@gujranwala.gov.pk\nSafety Tip: If you see smoke or smell gas, leave the area immediately and call the fire brigade.";
                    rescuetxt.Text = "Rescue:\nPhone Num: 1122\nLocation: Model Town, Gujranwala\n24/7 Availability: Yes\nWebsite: www.rescue1122.gov.pk\nEmail: rescue@gujranwala.gov.pk\nMedical Assistance: First aid for injuries, burns, trauma, and more.\nImportant Note: Always stay calm and wait for professional help.";
                    break;

                default:
                    //clear TextBoxes if city is not recognized
                    policetxt.Clear();
                    firetxt.Clear();
                    rescuetxt.Clear();
                    break;
            }


        }
        */


        private void back2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void back2_MouseEnter(object sender, EventArgs e)
        {
            back2.BackColor = Color.LightGreen;
        }

        private void back2_MouseLeave(object sender, EventArgs e)
        {
            back2.BackColor = Color.White;
        }

        private void cmbCity_MouseEnter(object sender, EventArgs e)
        {
            cmbCity.BackColor = Color.LightCyan;
        }

        private void cmbCity_MouseLeave(object sender, EventArgs e)
        {
            cmbCity.BackColor = Color.White;
        }

        private void RichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            // Open the URL in the default web browser
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
