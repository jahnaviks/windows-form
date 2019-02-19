using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class HomePage : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["POCManagement"].ConnectionString);
        SqlDataAdapter adapt;
        public static int formid = 0;
        public HomePage()
        {
            InitializeComponent();
            DisplayData();
        }
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from socialclub", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void HomePage_Load(object sender, EventArgs e)
        {
            Clear_Text();
            // TODO: This line of code loads data into the 'pOCSocialClub.SocialClub' table. You can move, or remove it, as needed.
            this.socialClubTableAdapter3.Fill(this.pOCSocialClub.SocialClub);
            // TODO: This line of code loads data into the 'pOCSocialHealth.SocialClub' table. You can move, or remove it, as needed.
            this.socialClubTableAdapter2.Fill(this.pOCSocialHealth.SocialClub);
            // TODO: This line of code loads data into the 'pOCSocialMarital.SocialClub' table. You can move, or remove it, as needed.
            this.socialClubTableAdapter1.Fill(this.pOCSocialMarital.SocialClub);
            // TODO: This line of code loads data into the 'pOCSocialOccupation.SocialClub' table. You can move, or remove it, as needed.
            this.socialClubTableAdapter.Fill(this.pOCSocialOccupation.SocialClub);
        }

        private void Clear_Text()
        {
            textBox2.Text = String.Empty;
            dateTimePicker2.Text = String.Empty;
            comboBox7.Text = String.Empty;
            textBox5.Text = String.Empty;
            comboBox8.Text = String.Empty;
            comboBox9.Text = String.Empty;
            textBox6.Text = String.Empty;
            textBox1.Text = String.Empty;
            dateTimePicker1.Text = String.Empty;
            comboBox1.Text = String.Empty;
            comboBox2.Text = String.Empty;
            comboBox3.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.socialClubTableAdapter.Fill(this.pOCSocialOccupation.SocialClub);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.socialClubTableAdapter1.Fill(this.pOCSocialMarital.SocialClub);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                this.socialClubTableAdapter2.Fill(this.pOCSocialHealth.SocialClub);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || dateTimePicker2.Text == "" || comboBox7.Text == "" || textBox5.Text == "" || comboBox8.Text == "" || comboBox9.Text == "" || textBox6.Text == "")
            {
                if (textBox2.Text == "" && comboBox7.Text == "" && textBox5.Text == "" && comboBox8.Text == "" && comboBox9.Text == "" && textBox6.Text == "")
                {
                    MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (!(textBox2.Text == "" || dateTimePicker2.Text == "" || comboBox7.Text == "" || textBox5.Text == "" || comboBox8.Text == "" || comboBox9.Text == "" || textBox6.Text == ""))
            {
                if (textBox2.Text == "" && comboBox7.Text == "" && textBox5.Text == "" && comboBox8.Text == "" && comboBox9.Text == "" && textBox6.Text == "")
                {
                    MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (textBox2.Text == "")
                    {
                        MessageBox.Show("Please fill name field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (dateTimePicker2.Text == "")
                    {
                        MessageBox.Show("Please fill Date of birth field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (comboBox7.Text == "")
                    {
                        MessageBox.Show("Please fill occupation field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (textBox5.Text == "")
                    {
                        MessageBox.Show("Please fill salary field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (comboBox8.Text == "")
                    {
                        MessageBox.Show("Please fill marital status field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (comboBox9.Text == "")
                    {
                        MessageBox.Show("Please fill health status field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (textBox6.Text == "")
                    {
                        MessageBox.Show("Please fill number of children field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (!Regex.Match(textBox2.Text, "^[a-zA-Z ]{6,75}").Success)
                    {
                        MessageBox.Show("Invalid name, can have Alphabets and space of 6 to 75 characters.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox2.Focus();
                    }
                    if (!Regex.Match(textBox5.Text, "^[0-9]{4,}").Success)
                    {
                        MessageBox.Show("Invalid salary, can have only numbers more than 1000.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox5.Focus();
                    }
                    if (!Regex.Match(textBox6.Text, "^[0-9]{0,2}").Success)
                    {
                        MessageBox.Show("Invalid number of children, can have only numbers", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox5.Focus();
                    }
                }
            }
            else
            {
                con.Open();
                string insertQuery = "insert into socialclub(name,dob,occupation,maitalstatus,healthstatus,salary,numchild)values (@name,@dob,@occupation,@maitalstatus,@healthstatus,@salary,@numchild)";

                SqlCommand cmd1 = new SqlCommand(insertQuery, con);
                cmd1.Parameters.AddWithValue("@name", textBox2.Text);
                cmd1.Parameters.AddWithValue("@dob", Convert.ToDateTime(dateTimePicker2.Text));
                cmd1.Parameters.AddWithValue("@occupation", comboBox7.Text);
                cmd1.Parameters.AddWithValue("@maitalstatus", comboBox8.Text);
                cmd1.Parameters.AddWithValue("@healthstatus", comboBox9.Text);
                cmd1.Parameters.AddWithValue("@salary", Convert.ToInt64(textBox5.Text));
                cmd1.Parameters.AddWithValue("@numchild", Convert.ToInt16(textBox6.Text));
                cmd1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Registered");
                Clear_Text();
            }
            //string name = textBox2.Text;
            //DateTime dob = Convert.ToDateTime(dateTimePicker2.Text);
            //string occupation = comboBox7.Text;
            //long salary = Convert.ToInt64(textBox5.Text);
            //string marital = comboBox8.Text;
            //string health = comboBox9.Text;
            //int child = Convert.ToInt16(textBox6.Text);

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()!="")
            {
                DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
                formid = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            }            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            string updateQuery = "update socialclub set name=@name,dob=@dob,occupation=@occupation,maitalstatus=@maitalstatus,healthstatus=@healthstatus,salary=@salary,numchild=@numchild where id="+formid;

            SqlCommand cmd1 = new SqlCommand(updateQuery, con);
            cmd1.Parameters.AddWithValue("@name", textBox1.Text);
            cmd1.Parameters.AddWithValue("@dob", Convert.ToDateTime(dateTimePicker1.Text));
            cmd1.Parameters.AddWithValue("@occupation", comboBox1.Text);
            cmd1.Parameters.AddWithValue("@maitalstatus", comboBox2.Text);
            cmd1.Parameters.AddWithValue("@healthstatus", comboBox3.Text);
            cmd1.Parameters.AddWithValue("@salary", Convert.ToInt64(textBox3.Text));
            cmd1.Parameters.AddWithValue("@numchild", Convert.ToInt64(textBox4.Text));
            cmd1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated");
            DisplayData();
            Clear_Text();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            string deleteQuery = "delete from socialclub where id=" + formid;
            SqlCommand cmd1 = new SqlCommand(deleteQuery, con);
            cmd1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");
            DisplayData();
            Clear_Text();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox4.Text = String.Empty;
            comboBox5.Text = String.Empty;
            comboBox6.Text = String.Empty;
            DisplayData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            DataTable dt = new DataTable();
            string searchQuery = "select * from socialclub where occupation='" + comboBox4.Text+"' " + comboBox5.Text + " maitalstatus='"+comboBox6.Text+"'";
            adapt = new SqlDataAdapter(searchQuery, con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }  
    }
}
