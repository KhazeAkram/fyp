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
    public partial class Form7 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Khaze\Documents\Grain.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;

        public Form7()
        {
            InitializeComponent();
            conn.Open();
            cmd=new SqlCommand("Select * from [Recieveable]",conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [Recieveable] (CId,Name,Recieveable,Description,Contact) VALUES (@Cid,@name,@Recieveable, @Description,@Contact)", conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Recieveable", textBox2.Text);
            cmd.Parameters.AddWithValue("@Description", textBox3.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox4.Text);
            cmd.Parameters.AddWithValue("@CId", textBox6.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Open();
            cmd = new SqlCommand("Select * from [Recieveable]",conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("DELETE FROM [Recieveable] WHERE CId = @id", conn);
            cmd.Parameters.AddWithValue("@id", textBox5.Text);
            
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Open() ;
            cmd = new SqlCommand("Select * from [Recieveable]", conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("UPDATE [Recieveable] SET Name = @name, Recieveable = Recieveable, Description=@Description,Contact=@Contact WHERE   CId = @Id", conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Recievable", textBox2.Text);
            cmd.Parameters.AddWithValue("@Description", textBox3.Text); 
            cmd.Parameters.AddWithValue("@Contact", textBox4.Text);

            cmd.Parameters.AddWithValue("@Id", textBox6.Text);

            cmd.ExecuteNonQuery();



            conn.Close();
            conn.Open();
            cmd = new SqlCommand("Select * from [Recieveable]", conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 to=new Form2();
            to.Show();
            this.Hide();
        }
    }
}
