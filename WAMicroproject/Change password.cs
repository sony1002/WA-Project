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
    public partial class Change_password : Form
    {
        SqlCommand cmd;SqlConnection con;
        SqlDataAdapter da;SqlDataReader dr;
        public Change_password()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
            label5.Visible = false;
            comboHintQuestion.Visible = false;
            txthint.Visible = false;
            label1.Visible = true;
            txtOld.Visible = true;
        }

        private void txtsubmit_Click(object sender, EventArgs e)
        {
         //   string UserName = CommonData.UserName;
            if (radioButton1.Checked)
            {


                string query = "select count(*) from Users where UserName=@p1 and Pasword=@p2";
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@p1", CommonData.UserName);
                cmd.Parameters.AddWithValue("@p2", txtOld.Text);
                con.Open();
                int r = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                if (r == 0)
                    MessageBox.Show("invalid password");
                else
                {
                    string query1 = "update Users set Pasword=@p1 where  UserName=@p2";
                    cmd = new SqlCommand(query1, con);
                    cmd.Parameters.AddWithValue("@p1", txtNew.Text);
                    cmd.Parameters.AddWithValue("@p2", CommonData.UserName);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("updated password succesfully");
                }
            }

                 
             if(radioButton2.Checked)
            {
                
                //string query = "select count(*) from Users where UserName=@p1 and HintQuestion=@p2 and HintAnswer=@p3";
                //cmd = new SqlCommand(query, con);
                //cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@p1", CommonData.UserName);
                //cmd.Parameters.AddWithValue("@p2", comboHintQuestion.SelectedItem.ToString());
                //cmd.Parameters.AddWithValue("@p3", txthint.Text);
                //con.Open();
                //    //int r = Convert.ToInt32(cmd.ExecuteScalar());
                //dr = cmd.ExecuteReader();
                //con.Close();
                
                //if (dr.Read())
                //{
                    

                    string query1 = "update Users set  Pasword=@p3 where  HintAnswer=@p2 and UserName=@p1";
                    cmd = new SqlCommand(query1, con);
                    cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.AddWithValue("@p1", comboHintQuestion.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@p2", txthint.Text);
                    cmd.Parameters.AddWithValue("@p3", txtNew.Text);
                    cmd.Parameters.AddWithValue("@p1", CommonData.UserName);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("updated password succesfully");
                //}

                }
             }

        private void Change_password_Load(object sender, EventArgs e)
        {
            string constre=  "server = Sony; User Id = sa; Password = 123; database = Microproject";
            con = new SqlConnection(constre);
            cmd = new SqlCommand("select HintQuestion from Users", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                comboHintQuestion.Items.Add(dr["hintquestion"]);
            }
            con.Close();
           

        }
       

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label6.Visible = true;
            label5.Visible = true;
            comboHintQuestion.Visible = true;
            txthint.Visible = true;
            label1.Visible = false;
            txtOld.Visible = false;
        }

        private void txtClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
