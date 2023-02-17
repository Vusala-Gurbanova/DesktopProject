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
    public partial class Form4 : Form
    {       
        public int loggedUserId;
        public Form4(int loggedUserId)
        {
            InitializeComponent();
            this.loggedUserId = loggedUserId;
        }    
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(DALC.GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO CONTACTS " + "VALUES (@NAME, @SURNAME, @COMPANY, @COUNTRY_CODE, @PREFIX, " +
                "@NUMBER, @INSERT_USER)", con);
            cmd.Parameters.AddWithValue("@NAME", textBox1.Text);
            cmd.Parameters.AddWithValue("@SURNAME", textBox2.Text);
            cmd.Parameters.AddWithValue("@COMPANY", textBox3.Text);
            cmd.Parameters.AddWithValue("@COUNTRY_CODE", textBox4.Text);
            cmd.Parameters.AddWithValue("@PREFIX", textBox5.Text);
            cmd.Parameters.AddWithValue("@NUMBER", textBox6.Text);
            cmd.Parameters.AddWithValue("@INSERT_USER", loggedUserId);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("success");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                this.Hide();
                con.Close();                
                con.Dispose();
            }
        }

    }
}
