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

namespace WindowsFormsApp12
{
    public partial class Bill_gen : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Khaze\source\repos\WindowsFormsApp12\858.mdf;Integrated Security=True;Connect Timeout=30");
        public Bill_gen()
        {
            InitializeComponent();

            conn.Open();
            SqlCommand  cm = new SqlCommand("select * from [Table]", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select SUM (Total) from [Table]", conn);
            var a= cmd.ExecuteScalar();
            textBox1.Text = a.ToString();
        }

        private void Bill_gen_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
