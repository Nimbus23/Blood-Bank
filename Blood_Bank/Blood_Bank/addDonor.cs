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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Blood_Bank
{
    public partial class addDonor : Form
    {  public string list;
        public addDonor()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void addDonor_Load(object sender, EventArgs e)
        {
            DateTime date1 = DateTime.Now;
            label9.Text = date1.ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int minValue = 10000;
            int maxValue = 99999;

            int idrec = r.Next(minValue, maxValue + 1);

            if ((textBoxName.Text == "") || (textBoxSurname.Text == "") ||
                (textBoxsocialID.Text == "") || (textBoxphNumber.Text == "" || (textBoxemail.Text == "") || comboBox1.SelectedItem == null))
            {
                MessageBox.Show("Please enter full information.", "Error");
            }
            else
            {
                
                Donor d = new Donor();
                d.name = textBoxName.Text;
                d.surname=textBoxSurname.Text;
                d.socialID=textBoxsocialID.Text;
                d.email = textBoxemail.Text;
                d.phoneNumber = textBoxphNumber.Text;
                d.bloodtype = comboBox1.Text;
                d.dateOfDonation = label9.Text;
                list = idrec + ";"+ d.dateOfDonation  + ";"+d.name +";"+ d.surname + ";" + d.socialID + ";" + d.phoneNumber + ";"+ d.email + ";" +
                       d.bloodtype + ";";
                FileStream fs = new FileStream("donners.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(list);
                sw.Close();
                fs.Close();
                string binFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "picture");

                string fileName = idrec + ".jpg";
                string filePath = Path.Combine(binFolderPath, fileName);

                Directory.CreateDirectory(binFolderPath);

                pictureBox1.Image.Save(filePath);
                MessageBox.Show("New Donner has been added.");
                pictureBox1.Image = Image.FromFile("standart.jpg");
                textBoxName.Clear();
                textBoxSurname.Clear();
                textBoxsocialID.Clear();
                textBoxemail.Clear();
                textBoxphNumber.Clear();
                comboBox1.SelectedItem = null;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxsocialID_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxphNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter=  "Image Files|*.jpg;*.jpeg;*.png;*.gif;";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(selectedImagePath);

            }
        }
    }
}
