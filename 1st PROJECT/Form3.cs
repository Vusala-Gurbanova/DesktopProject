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
    public partial class Form3 : Form
    {
        
        public int loggedUserId;

        public Form3(int loggedUserId)
        {
            InitializeComponent();
            this.loggedUserId = loggedUserId;
        }

        public void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4(loggedUserId);
            frm4.Show();
            

        }

        public void uPDATEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            
            frm5.ShowDialog();            
            
            
        }
        
        public void gETToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            
            SqlConnection con = new SqlConnection(DALC.GetConnectionString());

            con.Open();
                        
            SqlCommand cmd = new SqlCommand("SELECT * FROM Contacts WHERE INSERT_USER = @UserId", con);

            cmd.Parameters.AddWithValue("@UserId",loggedUserId);
            
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
                        
            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dr);

            dataGridView1.DataSource = dt;            

        }

        internal static void sentData(object getuser)
        {
            throw new NotImplementedException();
        }
             

        private void dataGridView1_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //DoubleClick was used (the same code can be usefull in "Click")

            Form5 frm5 = new Form5();
            frm5.textBox1.Tag = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm5.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm5.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm5.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm5.textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm5.textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            frm5.textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            frm5.ShowDialog();
        }

        private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(DALC.GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Contacts WHERE ID = @id", con);
            DataGridViewRow row = dataGridView1.CurrentRow;

            string contactId = row.Cells["ID"].Value.ToString();
            cmd.Parameters.AddWithValue("@id", contactId);

            DialogResult dialog = MessageBox.Show("Do you really want to delete selected row?", "Delete", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            
            if (dialog == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Done");
            }
            else if (dialog == DialogResult.No)
            {
                return;
               
            }                      
            
            con.Close();
            
        }

        
    }
}
