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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp12
{
    public partial class Form6 : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Khaze\Documents\Grain.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        public Form6()
        {
            InitializeComponent();
            conn.Open();
            cmd = new SqlCommand("Select * from [stock]", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();



            cmd = new SqlCommand("UPDATE [stock] SET Product = @Product, Price = @Price, Quantity=@Quantity WHERE   PId = @Id", conn);
            cmd.Parameters.AddWithValue("@Product", textBox2.Text);
            cmd.Parameters.AddWithValue("@Price", textBox3.Text);
            cmd.Parameters.AddWithValue("@Quantity", textBox4.Text);
           
            cmd.Parameters.AddWithValue("@Id", textBox1.Text);

            cmd.ExecuteNonQuery();


            MessageBox.Show("Record is updated Successfully");

            conn.Close();
            conn.Open();
            cmd = new SqlCommand("Select * from [stock]", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 to= new Form2();  
            to.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();



            cmd = new SqlCommand("DELETE FROM [stock] WHERE PId = @id", conn);
            cmd.Parameters.AddWithValue("@id", textBox5.Text);



            cmd.ExecuteNonQuery();



            MessageBox.Show("Record is Deleted Successfully");
            conn.Close();
            conn.Open();
            cmd = new SqlCommand("Select * from [stock]", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
