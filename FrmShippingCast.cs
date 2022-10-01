using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_1205
{
    public partial class FrmShippingCast : Form
    {
        Database.DatabaseProcess db = new Database.DatabaseProcess();
        string sql = "";

        public FrmShippingCast()
        {
            InitializeComponent();
        }

        private void FrmShippingCast_Load(object sender, EventArgs e)
        {
            db.connect();
            DataTable dataTable = new DataTable();
            dataTable.Load(db.DisCart());
            dataGridView1.DataSource = dataTable;
            db.disConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.connect();
            sql = $"DELETE from sale_detail WHERE saledetail_id  = {dataGridView1.SelectedCells[0].Value.ToString()}";
            if (dataGridView1.SelectedCells[0].Value.ToString() == "")
            {
                MessageBox.Show("Please select to Sale detail ID you wish to delete.");
            }

            if (MessageBox.Show("Want to delete data!!", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    sql = $"DELETE from sale_detail WHERE saledetail_id  = {dataGridView1.SelectedCells[0].Value.ToString()}";
                    db.DeleteSQL(sql);
                    DataTable dataTable = new DataTable();
                    dataTable.Load(db.DisCart());
                    dataGridView1.DataSource = dataTable;
                    label2.Text = $"Sale Detail: {dataGridView1.SelectedCells[0].Value.ToString()} has been deleted";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            db.disConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.connect();
            string sql = $"update sale_detail set amount = '{textBox1.Text}' where amount = {dataGridView1.SelectedCells[0].Value.ToString()}";
            if (dataGridView1.SelectedCells[0].Value.ToString() == "")
            {
                MessageBox.Show("Please select to Amount you wish to Edit.");
            }

            if (MessageBox.Show("Want to edit data!!", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    sql = $"update sale_detail set amount = '{textBox1.Text}' where amount = {dataGridView1.SelectedCells[0].Value.ToString()}";
                    db.ExecuteSQL(sql);

                    DataTable dataTable = new DataTable();
                    dataTable.Load(db.DisCart());
                    dataGridView1.DataSource = dataTable;
                    FrmShippingCast_Load(sender, e);
                    label3.Text = $"Amount : {dataGridView1.SelectedCells[0].Value.ToString()} has been edit";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            db.disConnection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Maincs f = new Maincs();
            f.ShowDialog();
        }
    }
}
