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
    public partial class expence : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Khaze\Documents\Grain.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        public expence()
        {
            InitializeComponent();
            con.Open();
            cmd = new SqlCommand("select * from [Exp]", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


            con.Close();
        }

        private void expence_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [Exp] (Detail,Date,Amunt) VALUES (@detail,@date, @amount)", con);
            cmd.Parameters.AddWithValue("@detail", textBox1.Text);
            cmd.Parameters.AddWithValue("@date", textBox2.Text);
            cmd.Parameters.AddWithValue("@amount", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            cmd = new SqlCommand("select * from [Exp]", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("UPDATE [Exp] SET Detail = @detail, Date =@date ,Amunt=@amount WHERE   Id = @Id", con);
            cmd.Parameters.AddWithValue("@detail", textBox1.Text);
            cmd.Parameters.AddWithValue("@date", textBox2.Text);
            cmd.Parameters.AddWithValue("@amount", textBox3.Text);

            cmd.Parameters.AddWithValue("@Id", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            cmd = new SqlCommand("select * from [Exp]", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


            con.Close();

          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("DELETE FROM [Exp] WHERE Id = @id", con);
            cmd.Parameters.AddWithValue("@id", textBox5.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            cmd = new SqlCommand("select * from [Exp]", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 to=new Form2();
            to.Show();
            this.Hide();
        }
    }
}
