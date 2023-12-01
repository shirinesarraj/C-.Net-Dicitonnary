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

namespace Projet_mot
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        DataTable table1 = new DataTable();
        DataTable table2 = new DataTable();
        private void Form5_Load(object sender, EventArgs e)
        {
            table1.Columns.Add("Idfr", typeof(int));
            table1.Columns.Add("nomFr", typeof(String));
            table1.Columns.Add("type", typeof(String));
            table1.Columns.Add("tradcution", typeof(String));
            table1.Columns.Add("exampleFr", typeof(String));
            table1.Columns.Add("exampleEn", typeof(String));

            //table1.Rows.Add(Idfr, nomFr, type, traduction, exampleFr, exampleEn);
            table1.Rows.Add(1, "amitié", "Nom", "friendship", "faire quelque chose par amitié ", " to do something out of friendship ");
            table1.Rows.Add(2, "Livre", "Nom", "book", " j’ai lu ce livre ", " I read this book  ");
            table1.Rows.Add(3, "voir", "Nom", "see", "  il ne voit rien de l’oeil gauche", "he can’t see anything with his left eye");
            table1.Rows.Add(4, "arriver", "verb", "come", "j'arrive dans 2 minutes", " i'll come in 2 minutes");


            dataGridView1.DataSource = table1;

            table2.Columns.Add("IdEn", typeof(int));
            table2.Columns.Add("nomEn", typeof(String));
            table2.Columns.Add("type", typeof(String));
            table2.Columns.Add("tradcution", typeof(String));
            table2.Columns.Add("exampleFr", typeof(String));
            table2.Columns.Add("exampleEn", typeof(String));


            dataGridView2.DataSource = table2;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //export
            TextWriter writer = new StreamWriter(@"C:\Users\Hp\Desktop\table.txt");

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (j == dataGridView1.Columns.Count - 1)
                    {
                        writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }

                    else
                        writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");

                }
                writer.WriteLine("");
            }

            writer.Close();
            MessageBox.Show("Data Exported");


        }

        private void button2_Click(object sender, EventArgs e)
        {

            //import
            {
                string[] lines = File.ReadAllLines(@"C:\Users\Hp\Desktop\table.txt");
                string[] values;


                for (int i = 0; i < lines.Length; i++)
                {
                    values = lines[i].ToString().Split('|');
                    string[] row = new string[values.Length];

                    for (int j = 0; j < values.Length; j++)
                    {
                        row[j] = values[j].Trim();
                    }
                    table2.Rows.Add(row);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
