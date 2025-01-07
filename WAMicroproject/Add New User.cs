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
    public partial class Add_New_User : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public Add_New_User()
        {
            InitializeComponent();
        }

        private void Add_New_User_Load(object sender, EventArgs e)
        {
            string constr = "server=Sony;User Id=sa;Password=123;database=Microproject";
            con = new SqlConnection(constr);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string query = "insert into Users values(@p1,@p2,@p3,@p4,@p5,@p6)";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@p1", txtUname.Text);
            cmd.Parameters.AddWithValue("@p2", txtPassword.Text);
           // cmd.Parameters.AddWithValue("@p7", txtconfirmpassword.Text);
            cmd.Parameters.AddWithValue("@p3", txtFname.Text);
            cmd.Parameters.AddWithValue("@p4", txtLname.Text);
            cmd.Parameters.AddWithValue("@p5", combohintQ.Text);
            cmd.Parameters.AddWithValue("@p6", txtHAnswer.Text);
            con.Open();
            int r = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(r + "row(s)created");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach(Control c in this.Controls)
            {
                if(c is TextBox)
                {
                    c.Text = " ";
                }
            }
            combohintQ.ResetText();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
