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

namespace WAMicroproject
{
    public partial class Form1 : Form
    {
        SqlConnection con;SqlCommand cmd;
        SqlDataReader Dr;
        public static string s;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string constr = "server=Sony;User Id=sa;Password=123;database=Microproject";
            con = new SqlConnection(constr);
            string query = "select*from Users where Username=@p1 and Pasword=@p2";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            CommonData.UserName = txtName.Text;
            cmd.Parameters.AddWithValue("@p1", txtName.Text);
            cmd.Parameters.AddWithValue("@p2", txtPassword.Text);
            con.Open();
             Dr = cmd.ExecuteReader();
            if (Dr.Read())
            {
                MessageBox.Show("login successful");
                   MDIFrom m = new MDIFrom();
                m.Show();
            }
            else
                MessageBox.Show("login not successful");
            con.Close();
            s = txtName.Text;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
    }
}
