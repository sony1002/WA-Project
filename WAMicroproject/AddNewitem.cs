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
    public partial class AddNewitem : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet Ds;
        SqlDataAdapter dp;SqlCommandBuilder bldr; DataRow R;
        public AddNewitem()
        {
            InitializeComponent();
        }

        private void AddNewitem_Load(object sender, EventArgs e)
        {
            string constr = "server=Sony;User Id=sa;Password=123;database=Microproject";
            con = new SqlConnection(constr);
            string query = "select*from Items";
            cmd = new SqlCommand(query, con);
            dp = new SqlDataAdapter(cmd);
            Ds = new DataSet();
            dp.Fill(Ds, "Items");
            dp.FillSchema(Ds, SchemaType.Source, " ");
            bldr = new SqlCommandBuilder(dp);
            dataGridView1.DataSource = Ds.Tables[0];

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            R = Ds.Tables[0].NewRow();
            R[0] = txtitem.Text;
            R[1] = txtPrice.Text;
            Ds.Tables[0].Rows.Add(R);
            MessageBox.Show("successfully data inserted into data results set table");

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(Ds.HasChanges())
            {
                dp.Update(Ds, "items");
                MessageBox.Show("successfully data saved in database");
            }
            else
            {
                MessageBox.Show("data no modification at database");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
