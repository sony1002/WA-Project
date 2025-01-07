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
    public partial class Bill_Trans : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlCommandBuilder cb;
        DataRow r;
        double tprice;
       public static DataSet ds;
       public static SqlDataAdapter da;
        static double  billAmount;
        public Bill_Trans()
        {
            InitializeComponent();
        }
        private void getdata()
        {
            string query = "select itemname from Items ";
           
            cmd = new SqlCommand(query, con);
           
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboItem.Items.Add(dr["ItemName"]);
            }
            con.Close();
        }

        private void Bill_Trans_Load(object sender, EventArgs e)
        {
            string constr = "server=Sony;User Id=sa;Password=123;Database=MicroProject";
            con = new SqlConnection(constr);
            string query = "select*from BillTrans where BillNumber=@p1";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@p1", Bill_Master.bn);
            ds = new DataSet();
            da.Fill(ds, "BillTrans");
            da.FillSchema(ds, SchemaType.Source, "BillTrans");
            cb = new SqlCommandBuilder(da);
            dataGridView1.DataSource = ds.Tables[0];
            getdata();

        }
       
      

        private void btnOk_Click(object sender, EventArgs e)
        {
         
            
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            r = ds.Tables[0].NewRow();
            r[0] = Bill_Master.bn;
            r[1] = comboItem.Text;
            r[2] = txtPrice.Text;
           
            r[3] = txtQuantity.Text;
            r[4] = txtTotalPrice.Text;
           tprice += Convert.ToDouble(txtTotalPrice.Text);
            Bill_Master.bamount = tprice;
            ds.Tables[0].Rows.Add(r);
           
         
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text != "")
            {
                double n1, n2, result;
                n1 = Convert.ToDouble(txtPrice.Text);
                n2 = Convert.ToDouble(txtQuantity.Text);
                result = n1 * n2;
                txtTotalPrice.Text = result.ToString();
                billAmount = billAmount + result;
            }
        }

        private void comboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select *from Items where itemname=@p1 ";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@p1", comboItem.SelectedItem);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            txtPrice.Text = dr[1].ToString();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
