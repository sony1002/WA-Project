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
    public partial class Delete_item : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet Ds;
        SqlDataAdapter dp; SqlCommandBuilder bldr; DataRow R;
        public Delete_item()
        {
            InitializeComponent();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void Delete_item_Load(object sender, EventArgs e)
        {
            string constr = "server=Sony;User Id=sa;Password=123;database=Microproject";
            con = new SqlConnection(constr);
            string query = "select*from Items";
            cmd = new SqlCommand(query, con);
            dp = new SqlDataAdapter(cmd);
            Ds = new DataSet();
            dp.Fill(Ds, "Items");
            dp.FillSchema(Ds, SchemaType.Source, "Items");
            bldr = new SqlCommandBuilder(dp);
            dataGridView1.DataSource = Ds.Tables[0];
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            R = Ds.Tables[0].Rows.Find(txtitem.Text);
            R.Delete();
            MessageBox.Show("successfully data deleted");
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            dp.Update(Ds, "items");
            MessageBox.Show("successfully data saved in database");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            txtitem.Text = dr.Cells[0].Value.ToString();
            txtprice.Text = dr.Cells[1].Value.ToString();
            
        }
    }
}
