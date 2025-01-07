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
    public partial class MDIFrom : Form
    {
        SqlConnection con;
        public MDIFrom()
        {
            InitializeComponent();
        }

        private void MDIFrom_Load(object sender, EventArgs e)
        {
            string constr = "server=Sony;User Id=sa;Password=123;database=Microproject";
            con = new SqlConnection(constr);
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void addItemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddNewitem f1 = new AddNewitem();
            f1.Show();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edititem e1 = new Edititem();
            e1.Show();
        }

        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_item d = new Delete_item();
            d.Show();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_New_User a = new Add_New_User();
            a.Show();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_user d = new Delete_user();
            d.Show();
        }

        private void viewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_User vs = new View_User();
            vs.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_password cp = new Change_password();
            cp.Show();
        }

        private void newBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bill_Master bm = new Bill_Master();
            bm.Show();
        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Bill vb = new View_Bill();
            vb.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
