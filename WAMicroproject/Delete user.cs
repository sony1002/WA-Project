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
    public partial class Delete_user : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet Ds;
        SqlDataAdapter dp; SqlCommandBuilder bldr; DataRow R;
        public Delete_user()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Delete_user_Load(object sender, EventArgs e)
        {
            
            string constr = "server=Sony;User Id=sa;Password=123;database=Microproject";
            con = new SqlConnection(constr);
            string query = "select*from Users";
            cmd = new SqlCommand(query, con);
            dp = new SqlDataAdapter(cmd);
            Ds = new DataSet();
            dp.Fill(Ds, "Users");
            dp.FillSchema(Ds, SchemaType.Source, "Users");
            bldr = new SqlCommandBuilder(dp);
            dataGridView1.DataSource = Ds.Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            dataGridView1.Rows.Remove(row);
            dp.Update(Ds, "Users");
            MessageBox.Show("successfulyy data delete");
        
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          //  DataGridViewRow dr = dataGridView1.SelectedRows[0];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
