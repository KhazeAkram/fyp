using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WindowsFormsApp12
{
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Khaze\Documents\Grain.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        public Form5()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Khaze\source\repos\WindowsFormsApp12\858.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
            SqlCommand cm = new SqlCommand("Delete  from [Table] ", conn);
            cm.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT Product,Price FROM [stock] WHERE Pid = @id", con);
            {
                // create a parameter object with the value of the row to search
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                // open the connection
                con.Open();

                // execute the command and get a data reader object
                var reader = cmd.ExecuteReader();
                {
                    // check if the reader has any rows
                    if (reader.HasRows)
                    {
                        // read the first row
                        reader.Read();

                        // get the values of the columns

                        textBox2.Text = reader["Price"].ToString();
                        textBox5.Text = reader["Product"].ToString();
                    }
                    else
                    {
                        // no rows found
                        MessageBox.Show("No Product with the given ID");
                    }
                    con.Close();

                    cmd = new SqlCommand("SELECT Customer FROM [Customer] WHERE id = @id", con);
                    {
                        // create a parameter object with the value of the row to search
                        cmd.Parameters.AddWithValue("@id", textBox6.Text);
                        // open the connection
                        con.Open();

                        // execute the command and get a data reader object
                        var reader1 = cmd.ExecuteReader();
                        {
                            // check if the reader has any rows
                            if (reader1.HasRows)
                            {
                                // read the first row
                                reader1.Read();

                                // get the values of the columns

                                textBox7.Text = reader1["Customer"].ToString();
                                
                            }
                            else
                            {
                                // no rows found
                                MessageBox.Show("No Product with the given ID");
                            }
                            con.Close();

                        }
                    }
                }
            }
        }
        int i=0;

        private void button1_Click(object sender, EventArgs e)
        {

            double a = Convert.ToDouble(textBox2.Text.ToString()) + (Convert.ToDouble(textBox2.Text.ToString()) * Convert.ToDouble(textBox4.Text.ToString())) / 100;
            MessageBox.Show("Comission percentage is "+ textBox4.Text);
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Khaze\source\repos\WindowsFormsApp12\858.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
            SqlCommand cm = new SqlCommand("INSERT INTO[Table]( Id,Customer,Product, Price, Quantity) VALUES( @Id,@Customer,@Product, @Price, @Quantity)", conn);


            int id = ++i;
            cm.Parameters.AddWithValue("@Price", a);
            cm.Parameters.AddWithValue("@Customer", textBox7.Text);
            cm.Parameters.AddWithValue("@Quantity", textBox3.Text);
            cm.Parameters.AddWithValue("@Product", textBox5.Text);
            cm.Parameters.AddWithValue("@Id", id);
            cm.ExecuteNonQuery();
            conn.Close();
            conn.Open();
            cm = new SqlCommand("select * from [Table]", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();


            string createTriggerSQL = @"
                CREATE TRIGGER trgResetIdentityOnEmpty
                ON dbo.Bill
                AFTER DELETE
                AS
                BEGIN
                    -- Check if the table is empty
                    IF NOT EXISTS (SELECT 1 FROM dbo.Bill)
                    BEGIN
                        -- Reset the identity seed to 0 (next insert will start from 1)
                        DBCC CHECKIDENT ('dbo.Bill', RESEED, 0);
                    END
                END;";

            // Execute the command
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Khaze\Documents\Grain.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlCommand command = new SqlCommand(createTriggerSQL, con);
                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Trigger created successfully.");
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            
        }
            con.Close() ;
        con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO[Bill](Customer, Product, Price, Quantity,Cost) VALUES(@Customer, @Product, @Price, @Quantity,@Cost)", con);


            cmd.Parameters.AddWithValue("@Customer", textBox7.Text);
            cmd.Parameters.AddWithValue("@Price", a);
            cmd.Parameters.AddWithValue("@Quantity", textBox3.Text);
            cmd.Parameters.AddWithValue("@Product", textBox5.Text);
            
            cmd.Parameters.AddWithValue("@Cost", textBox2.Text);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 to = new Form2();
            to.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bill_gen to= new Bill_gen();
            to.Show();
        }
    }
}