using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp12
{
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Khaze\Documents\Grain.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;   
        public Form4()
        {
            InitializeComponent();
            con.Open();
            cmd = new SqlCommand("select Pid,Product, Price, Quantity from [stock]", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


            con.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [stock] (Pid,Product, Price, Quantity) VALUES (@id,@Product, @Price,@Quantity)", con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@Price", textBox2.Text);
            cmd.Parameters.AddWithValue("@Quantity", textBox3.Text);
            cmd.Parameters.AddWithValue("@Product", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            button2_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 to=new Form2();
            to.Show();
            this.Hide();
        }
    }
}
