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
    public partial class Edititem : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet Ds;
        SqlDataAdapter dp; SqlCommandBuilder bldr; DataRow R;
        public Edititem()
        {
            InitializeComponent();
        }

        private void Edititem_Load(object sender, EventArgs e)
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

        private void btnEdit_Click(object sender, EventArgs e)
        {

            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            dr.Cells[1].Value = txtPrice.Text;
            MessageBox.Show("updated successfully");
                        
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtitem_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            txtitem.Text = dr.Cells[0].Value.ToString();
            txtPrice.Text = dr.Cells[1].Value.ToString();
            txtitem.ReadOnly = true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
