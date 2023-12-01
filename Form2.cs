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
using System.Speech.Synthesis;

namespace Projet_mot
{
    public partial class Form2 : Form
    {
        String connectionString = "Data Source=Shirine\\SQLEXPRESS;Initial Catalog=Demo;Integrated Security=True";
        SqlDataAdapter adapter;
        SqlConnection connection;
        public Form2()
        {
            InitializeComponent();
            adapter = new SqlDataAdapter();
            connection = new SqlConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Traduction mot fr

            string query1 = "select * from motfr where nomFr=@nomFr";
            string countQuery = "select count(*) from motfr where nomFr=@nomFr";

            using (SqlCommand cmd = new SqlCommand(countQuery, connection))

            {
                connection.Open();

                cmd.Parameters.AddWithValue("@nomFr", textBox1.Text);
                int count = (int)cmd.ExecuteScalar();

                if (count >= 1)
                {
                    if (count > 1)
                    {
                        MessageBox.Show("Il y a " + count + " mots correspondants dans la base de données.");
                    }
                    this.dataGridView1.Rows.Clear();
                    cmd.CommandText = query1;

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            this.dataGridView1.Rows.Add(rd[0], rd[1], rd[2], rd[3], rd[4]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Désolé le mot fr n'existe pas dans la base de données.");
                }

            }
            connection.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Traduction mot En

            string query1 = "select * from motEn where nomEn=@nomEn";
            string countQuery = "select count(*) from motEn where nomEn=@nomEn";

            using (SqlCommand cmd = new SqlCommand(countQuery, connection))

            {
                connection.Open();

                cmd.Parameters.AddWithValue("@nomEn", textBox1.Text);
                int count = (int)cmd.ExecuteScalar();

                if (count >= 1)
                {
                    if (count > 1)
                    {
                        MessageBox.Show("Il y a " + count + " mots correspondants dans la base de données.");
                    }
                    this.dataGridView1.Rows.Clear();


                    cmd.CommandText = query1;

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            this.dataGridView1.Rows.Add(rd[0], rd[1], rd[2], rd[3], rd[4]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Désolé le mot En n'existe pas dans la base de données.");
                }

            }
            connection.Close();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            //update fr
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;
                string id = row.Cells[0].Value.ToString(); // l'ID de la ligne à modifier
                string nom = row.Cells[1].Value.ToString(); // le nouveau nom de la ligne
                string type = row.Cells[2].Value.ToString(); // le nouveau type de la ligne
                string traduction = row.Cells[3].Value.ToString(); // la nouvelle traduction de la ligne
                string exemple = row.Cells[4].Value.ToString(); // le nouvel exemple de la ligne

                // Mettre à jour la ligne dans la base de données
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE motFr SET nomFr = @nomFr, type = @type, traductionEn = @traductionEn, exemple = @exemple WHERE idFr = @idFr", connection);
                    cmd.Parameters.AddWithValue("@nomFr", nom);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@traductionEn", traduction);
                    cmd.Parameters.AddWithValue("@exemple", exemple);
                    cmd.Parameters.AddWithValue("@idFr", id);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("successfully updated !!");
                }
            }
        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            //updateEn
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;
                string id = row.Cells[0].Value.ToString(); // l'ID de la ligne à modifier
                string nom = row.Cells[1].Value.ToString(); // le nouveau nom de la ligne
                string type = row.Cells[2].Value.ToString(); // le nouveau type de la ligne
                string traduction = row.Cells[3].Value.ToString(); // la nouvelle traduction de la ligne
                string exemple = row.Cells[4].Value.ToString(); // le nouvel exemple de la ligne

                // Mettre à jour la ligne dans la base de données
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE motEn SET nomEn = @nomEn, type = @type, traductionFr = @traductionFr, exemple = @exemple WHERE idEn = @idEn", connection);
                    cmd.Parameters.AddWithValue("@nomEn", nom);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@traductionFr", traduction);
                    cmd.Parameters.AddWithValue("@exemple", exemple);
                    cmd.Parameters.AddWithValue("@idEn", id);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("successfully updated !!");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void f(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //fix image 
            Bitmap imagebtmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(imagebtmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(imagebtmp, 120, 20);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //show print
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
