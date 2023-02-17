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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(DALC.GetConnectionString());

            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO USERS " + "VALUES (@USERNAME,@PASSWORD,@EMAIL)", con);

            cmd.Parameters.AddWithValue("@USERNAME", textBox1.Text);
            cmd.Parameters.AddWithValue("@PASSWORD", textBox2.Text);
            cmd.Parameters.AddWithValue("@EMAIL",textBox3.Text);


            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("Saved successfully", "SAVED", MessageBoxButtons.OK);
                
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            con.Close();
            this.Hide();
            con.Dispose();


            Form1 frm1 = new Form1();
            frm1.ShowDialog();

        }

       
    }
}
