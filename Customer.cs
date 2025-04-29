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
    
    public partial class Customer : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Khaze\Documents\Grain.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        public Customer()
        {
            InitializeComponent();
            con.Open();
            cmd = new SqlCommand("select * from [Customer]", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [Customer] (Id,Customer, contact, Adress) VALUES (@id,@Customer, @contact,@adress)", con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@Customer", textBox2.Text);
            cmd.Parameters.AddWithValue("@contact", textBox3.Text);
            cmd.Parameters.AddWithValue("@adress", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            cmd = new SqlCommand("select * from [Customer]", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 to = new Form2();
            to.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();



            cmd = new SqlCommand("DELETE FROM [Customer] WHERE Id = @id", con);
            cmd.Parameters.AddWithValue("@id", textBox5.Text);



            cmd.ExecuteNonQuery();



            MessageBox.Show("Record is Deleted Successfully");
            con.Close();
            con.Open();
            cmd = new SqlCommand("select * from [Customer]", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("UPDATE [Customer] SET  Customer = @Customer,contact=@Contact,Adress=@Adress WHERE   Id = @Id", con);
           
            cmd.Parameters.AddWithValue("@Customer", textBox2.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox3.Text);
            cmd.Parameters.AddWithValue("@Adress", textBox4.Text);

            cmd.Parameters.AddWithValue("@Id", textBox1.Text);

            cmd.ExecuteNonQuery();



            con.Close();
            con.Open();
            cmd = new SqlCommand("select * from [Customer]", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


            con.Close();
        }
    }
}
