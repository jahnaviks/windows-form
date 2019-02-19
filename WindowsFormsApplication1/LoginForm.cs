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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = null, pswd = null;
            //{
            //    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=true;");
            //    SqlCommand cmd;
            //    
            //    string selectQuery = "select firstname,password from register where firstname='" + textBox1.Text + "'";
            //    con.Open();
            //    cmd = new SqlCommand(selectQuery, con);
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.Read())
            //    {
            //        fname = dr.GetValue(0).ToString();
            //        pswd = dr.GetValue(1).ToString();
            //    }
            //}
            // block to be deleted
            {
                fname = "virtusa";
                pswd = "virtusa@123";
            }
            if (fname == textBox1.Text && pswd == textBox2.Text)
            {
                RegisterForm temp = new RegisterForm();
                temp.Region = this.Region;
                temp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please enter valid credentials");
            }
        }
    }
}
