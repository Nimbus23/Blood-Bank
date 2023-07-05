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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addDonor add = new addDonor();
            add.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePath = "donners.txt";
            string [] lines = File.ReadAllLines(filePath);
            if (lines.Length > 0)
            {
               recordsForm rec = new recordsForm();
                rec.ShowDialog();
            }
            else MessageBox.Show("No Donors");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
