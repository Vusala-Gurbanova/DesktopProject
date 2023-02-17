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

namespace _1st_PROJECT
{
    public partial class Form5 : Form
    {
        Form3 frm3;
        public object dataGridView1;

        public Form5()
        {
            InitializeComponent();
             
        }

        public void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(DALC.GetConnectionString());
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE CONTACTS SET NAME =@ad, SURNAME =@soyad, COMPANY =@company,COUNTRY_CODE =@kod, " +
                "PREFIX=@prefix, NUMBER =@phone_number WHERE ID = @id", conn);

            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@company", textBox3.Text);
            cmd.Parameters.AddWithValue("@kod", textBox4.Text);
            cmd.Parameters.AddWithValue("@prefix", textBox5.Text);
            cmd.Parameters.AddWithValue("@phone_number", textBox6.Text);
            cmd.Parameters.AddWithValue("@id", textBox1.Tag);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
           
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("UPDATED");
            this.Hide();
            return;


        }

    }
}
