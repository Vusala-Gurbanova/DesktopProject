﻿using System;
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
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }

    
        public void button1_Click(object sender, EventArgs e)
        {                     
           
            SqlConnection con = new SqlConnection();

            con = new SqlConnection(DALC.GetConnectionString());
            
            con.Open();

            string check = ("Select * from USERS where USERNAME= '" + textBox1.Text + "' and PASSWORD = '" + textBox2.Text + "'");                      

            SqlDataAdapter data = new SqlDataAdapter(check, con);

            DataTable table = new DataTable();

            data.Fill(table); 
            
            if(table.Rows.Count == 1)
            {
                int loggedUserID = Convert.ToInt32(table.Rows[0][0]);                
                Form3 frm3 = new Form3(loggedUserID);
                
                this.Hide();
                frm3.Show();
            }
            else
            {
                MessageBox.Show("Please check username/password or register");
            }
                     
                       
       
        }

        private int ConvertToInt(SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            string textbox1 = textBox1.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
