using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Blood_Bank
{
    public partial class recordsForm : Form
    {
        pictureloger pic = new pictureloger();
        private int currentLineIndex = 0;
        private string[] lines;
        public int count =1;
        private void ReadAndFillLabels()
        {
            string[] parts = lines[currentLineIndex].Split(';');

            if (parts.Length >= 8)
            {
                label17.Text = parts[0];
                label9.Text = parts[1];
                label10.Text = parts[2];
                label11.Text = parts[3];
                label12.Text = parts[4];
                label13.Text = parts[5];
                label14.Text = parts[6];
                label15.Text = parts[7];
                pictureBox1.Image = Image.FromFile("picture\\"+label17.Text +".jpg");
            }
        }
        public class pictureloger
        {
            private List<string> strings;

            public pictureloger()
            {
                strings = new List<string>();
            }

            public void Logpic(string str)
            {
                strings.Add(str);
            }

            public void Delpic()
            {
                foreach (string str in strings)
                {
                    File.Delete("picture\\" + str + ".jpg");
                }
            }
        }
        public recordsForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resetLabels()
        {
            label17.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
        }
        

        private void recordsForm_Load(object sender, EventArgs e)
        {
            string filePath = "donners.txt";
            lines = File.ReadAllLines(filePath);

            if (lines.Length > 0)
            {
                ReadAndFillLabels();
                label20.Text = lines.Length.ToString();
            }
            else
            {
                MessageBox.Show("No more Donors");
            }
            label18.Text = count.ToString();
            button1.Enabled = false;
            if (Convert.ToInt32(label20.Text) <= 1) button4.Enabled = false;
            }


        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e) 
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Dispose();
            pic.Delpic();
            this.Close();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
        private void Check()
        {
            if ( Convert.ToInt32( label18.Text) <= 1)
            {
                button1.Enabled = false;
            }
            if (label18.Text == label20.Text)
            {
                button4.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button4.Enabled = true;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {

                resetLabels();
                currentLineIndex++;
                count++;
                label18.Text = count.ToString();
                if (count == lines.Length)
                {
                    button1.Enabled = true;
                    button4.Enabled = false;
                }
                if (currentLineIndex < lines.Length)
                {
                    ReadAndFillLabels();
                }
                else
                {
                    MessageBox.Show("No more Donnors");
                    currentLineIndex = lines.Length - 1;
                }
                Check();
            
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if ( Convert.ToInt32(label18.Text) > 1)
            {

                resetLabels();
                currentLineIndex--;
                count--;
                label18.Text = count.ToString();
                if (count == 1)
                {
                    button1.Enabled = false;
                }
                if (currentLineIndex < lines.Length)
                {
                    ReadAndFillLabels();
                }
                else
                {
                    MessageBox.Show("This is the start of the list");
                    currentLineIndex = lines.Length - 1;
                }
                Check();
            }
            if (Convert.ToInt32(label18.Text) <= 1)
            {
                button1.Enabled = false;
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string namepicdel = label17.Text;
            pic.Logpic(namepicdel);
            string[] lines2 = File.ReadAllLines("donners.txt");
            lines2 = lines2.Where((line, index) => index != currentLineIndex).ToArray();
            File.WriteAllLines("donners.txt", lines2);
            label20.Text = Convert.ToString(Convert.ToInt32(label20.Text)- 1);
            if (Convert.ToInt32(label18.Text) > 1)
            {
                Check();
                resetLabels();
                currentLineIndex--;
                count--;
                label18.Text = count.ToString();
                if (count == 1)
                {
                    button1.Enabled = false;
                }
                if (currentLineIndex < lines.Length)
                {
                    ReadAndFillLabels();
                }
                else
                {
                    MessageBox.Show("This is the start of the list");
                    currentLineIndex = lines.Length - 1;
                }
            }
            if (Convert.ToInt32(label18.Text) == 1)
            {
                    Check();
                    resetLabels();
                    string filePath = "donners.txt";
                    lines = File.ReadAllLines(filePath);

                    if (lines.Length > 0)
                    {
                        ReadAndFillLabels();
                        label20.Text = lines.Length.ToString();
                    }
                    else
                    {
                        MessageBox.Show("No more Donors");
                    }
                    label18.Text = count.ToString();
                   button1.Enabled = false;
            }
        }
    }
}
