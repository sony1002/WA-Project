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
    public partial class View_Bill : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder cd;
        public View_Bill()
        {
            InitializeComponent();
        } 

        private void label1_Click(object sender, EventArgs e)
        {

        }
       

        private void View_Bill_Load(object sender, EventArgs e)
        {
            string constr = "server=Sony;User Id=sa;Password=123;database=Microproject";
            con = new SqlConnection(constr);
            string query = "select BillNumber from  BillMaster ";

            cmd = new SqlCommand(query, con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["billnumber"]);
            }
            con.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string query = "Select*from BillMaster where BillNumber=@p1";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);


            cmd.Parameters.AddWithValue("@p1", comboBox1.SelectedItem);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "Billmaster");
            da.FillSchema(ds, SchemaType.Source, "Billmaster");
            cd = new SqlCommandBuilder(da);
            dataGridView1.DataSource = ds.Tables[0];

            //  SqlDataReader dr = cmd.ExecuteReader();


            con.Close();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string query = "select*from BillTrans where BillNumber=@p1";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@p1", comboBox1.SelectedItem);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "BillTrans");
            da.FillSchema(ds, SchemaType.Source, "BillTrans");
            cd = new SqlCommandBuilder(da);
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();
        }
    }
}
