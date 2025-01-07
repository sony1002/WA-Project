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
    public partial class Bill_Master : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public static string bn;
        Bill_Trans bt;
        SqlDataReader dr;
        double n1, n2, n3, n4, result,result1;

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text != "")
            {
                n1 = Convert.ToDouble(txtBillAmount.Text);
                n2 = Convert.ToDouble(txtService.Text);
                n3 = Convert.ToDouble(txtVat.Text);
                result = n1 + n2 + n3;
                n4 = Convert.ToDouble(txtDiscount.Text);
                //result = n1 + n2 + n3;
                result1 = (result) * (n4 / 100);
                result = result - result1;
                txtTotalBill.Text = result.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach(Control c in this.Controls)
            {
                if(c is TextBox)
                {
                    c.Text ="";
                }
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static  double bamount;
        public Bill_Master()
        {
            InitializeComponent();
        }

        private void Bill_Master_Load(object sender, EventArgs e)
        {
            string constr = "server=Sony;User Id=sa;Password=123;database=Microproject";
            con = new SqlConnection(constr);
            txtUserName.Text = Form1.s;
         
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bn = txtBillNo.Text;
            if (bt == null && !bn.Equals(""))
            {
                bt = new Bill_Trans();
                bt.ShowDialog();
            }
            txtBillAmount.Text = bamount.ToString();
            txtBillDate.Text = DateTime.Now.ToString();
            string query1 = "select*from tax";
            cmd = new SqlCommand(query1, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                txtService.Text = dr[0].ToString();
                txtVat.Text = dr[1].ToString();
                   
            }
            con.Close();
            
           
         
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = "insert into BillMaster values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@p1", bn);
            cmd.Parameters.AddWithValue("@p2", Convert.ToDateTime(txtBillDate.Text));
            cmd.Parameters.AddWithValue("@p3", txtBillAmount.Text);
            cmd.Parameters.AddWithValue("@p4", txtService.Text);
            cmd.Parameters.AddWithValue("@p5", txtVat.Text);
            cmd.Parameters.AddWithValue("@p6", txtDiscount.Text);
            cmd.Parameters.AddWithValue("@p7", txtTotalBill.Text);
            cmd.Parameters.AddWithValue("@p8", Form1.s);
            con.Open();
            int r = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("data stored in database");
            if (Bill_Trans.ds.HasChanges())
            {
                Bill_Trans.da.Update(Bill_Trans.ds, "BillTrans");
            }
        }
    }
}
