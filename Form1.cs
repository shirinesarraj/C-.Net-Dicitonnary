using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Projet_mot
{
    public partial class Form1 : Form
    {

        private string text;
        private int len = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            text = label1.Text;
            label1.Text = "";
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
          

        
    }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (len < text.Length)
            {
                label1.Text = label1.Text + text.ElementAt(len);
                len++;
            }
            else
                timer1.Stop();
        }
    } 
}
