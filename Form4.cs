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
    public partial class Form4 : Form
    {
        String connectionString = "Data Source=Shirine\\SQLEXPRESS;Initial Catalog=Demo;Integrated Security=True";
        SqlDataAdapter adapter;
        SqlConnection connection;
        public Form4()
        {
            InitializeComponent();
            adapter = new SqlDataAdapter();
            connection = new SqlConnection(connectionString);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //delete a frensh word from the id input
            if (textBox1.Text == "")
            {
                MessageBox.Show("You have to enter id");
            }
            else
            {
                connection.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM motFr WHERE idFr=@idFr", connection);
                checkCmd.Parameters.AddWithValue("@idFr", int.Parse(textBox1.Text));
                int idCount = (int)checkCmd.ExecuteScalar();
                if (idCount > 0)
                {
                    SqlCommand deleteCmd = new SqlCommand("DELETE FROM motFr WHERE idFr=@idFr", connection);
                    deleteCmd.Parameters.AddWithValue("@idFr", int.Parse(textBox1.Text));
                    deleteCmd.ExecuteNonQuery();
                    MessageBox.Show("successfully Deleted !!");
                }
                else
                {
                    MessageBox.Show("idfr does not exist in the table");
                }
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //delete an english word from the id input
            if (textBox1.Text == "")
            {
                MessageBox.Show("You have to enter id");

            }
            else
            {
                connection.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM motEn WHERE idEn=@idEn", connection);
                checkCmd.Parameters.AddWithValue("@idEn", int.Parse(textBox1.Text));
                int idCount = (int)checkCmd.ExecuteScalar();
                if (idCount > 0)
                {
                    SqlCommand deleteCmd = new SqlCommand("DELETE FROM motEn WHERE idEn=@idEn", connection);
                    deleteCmd.Parameters.AddWithValue("@idEn", int.Parse(textBox1.Text));
                    deleteCmd.ExecuteNonQuery();
                    MessageBox.Show("successfully Deleted !!");
                }
                else
                {
                    MessageBox.Show("IdEn does not exist in the table");
                }
                connection.Close();
            }

        }
    }
}
