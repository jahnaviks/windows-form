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

namespace WindowsFormsApplication1
{
    public partial class RegisterForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=true;");
        SqlCommand cmd;
        SqlDataAdapter adapt;  
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "insert into register values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','"+textBox6.Text+"'";
            con.Open();
            cmd = new SqlCommand(insertQuery, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePage temp = new HomePage();
            temp.Region = this.Region;
            temp.Show();
            this.Hide();
        }
    }
}
