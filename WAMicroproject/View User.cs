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
    public partial class View_User : Form
    {
        SqlConnection con;SqlCommand cmd;SqlDataAdapter da;
        DataRow r;DataSet ds;
        SqlCommandBuilder cd;
        public View_User()
        {
            InitializeComponent();
        }

        private void View_User_Load(object sender, EventArgs e)
        {
            string constr = "server=Sony;User Id=sa;Password=123;database=Microproject";
            con = new SqlConnection(constr);
            string query = "select*from Users";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "Users");
            da.FillSchema(ds, SchemaType.Source, "Users");
            cd = new SqlCommandBuilder(da);

            dataGridView1.DataSource=ds.Tables[0];

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
