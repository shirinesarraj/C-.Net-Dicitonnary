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

namespace Projet_mot
{
    public partial class Form3 : Form
    {
        String connectionString = "Data Source=Shirine\\SQLEXPRESS;Initial Catalog=Demo;Integrated Security=True";
        SqlDataAdapter adapter;
        SqlConnection connection;
        public Form3()
        {
            InitializeComponent();
            adapter = new SqlDataAdapter();
            connection = new SqlConnection(connectionString);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add a new french word to the database
            connection.Open();

            // vérifier si l'ID existe déjà dans la table
            SqlCommand checkIdCmd = new SqlCommand("SELECT idFr FROM motFr WHERE idFr = @idFr", connection);
            checkIdCmd.Parameters.AddWithValue("@idFr", textBox1.Text.Trim());
            SqlDataReader reader = checkIdCmd.ExecuteReader();

            if (reader.HasRows)
            {
                // l'ID existe déjà, afficher un message d'erreur
                MessageBox.Show("This ID already exists in the table!");
            }
            else
            {
                // l'ID n'existe pas encore, procéder à l'insertion
                reader.Close();

                SqlCommand insertCmd = new SqlCommand("INSERT INTO motFr VALUES (@idFr, @nomFr, @type, @traductionEn, @exemple)", connection);
                insertCmd.Parameters.AddWithValue("@idFr", textBox1.Text.Trim());
                insertCmd.Parameters.AddWithValue("@nomFr", textBox2.Text.Trim());
                insertCmd.Parameters.AddWithValue("@type", textBox3.Text.Trim());
                insertCmd.Parameters.AddWithValue("@traductionEn", textBox4.Text.Trim());
                insertCmd.Parameters.AddWithValue("@exemple", textBox5.Text.Trim());
                insertCmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved!");
            }

            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Ajout mot en motEn
            connection.Open();

            // vérifier si l'ID existe déjà dans la table
            SqlCommand checkIdCmd = new SqlCommand("SELECT idEn FROM motEn WHERE idEn = @idEn", connection);
            checkIdCmd.Parameters.AddWithValue("@idEn", textBox10.Text.Trim());
            SqlDataReader reader = checkIdCmd.ExecuteReader();

            if (reader.HasRows)
            {
                // l'ID existe déjà, afficher un message d'erreur
                MessageBox.Show("This ID already exists in the table!");
            }
            else
            {
                reader.Close();
                SqlCommand cmd = new SqlCommand("insert into motEn values(@idEn, @nomEn, @type, @traductionFr, @exemple)", connection);
                cmd.Parameters.AddWithValue("@idEn", textBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@nomEn", textBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@type", textBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@traductionFr", textBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@exemple", textBox6.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("successfully saved !!");

            }
            connection.Close();
        }
    }
}
