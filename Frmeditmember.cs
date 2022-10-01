using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.IO;

namespace project_1205
{
    public partial class Frmeditmember : Form
    {
        Database.DatabaseProcess db = new Database.DatabaseProcess();
        OracleConnection conn = new OracleConnection();
        public string memId;
        public Frmeditmember()
        {
            InitializeComponent();
        }

        private void Frmeditmember_Load(object sender, EventArgs e)
        {

            db.connect();
            DataTable dataTable = new DataTable();
            dataTable.Load(db.loadmember());
            dataGridView1.DataSource = dataTable;
            db.disConnection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedCells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedCells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.connect();
            db.MemberId();
            string sql = $"update member set fname = '{textBox1.Text}', lname = '{textBox2.Text}', address = '{textBox3.Text}' where member_id = {db.lmember}";
            db.ExecuteSQL(sql);
            db.disConnection();
            Frmeditmember_Load(sender, e);

            //db.connect();
            //string sql = $"update member set  fname = '{textBox1.Text}', lname = '{textBox2.Text}', address = '{textBox3.Text}' where member = {dataGridView1.SelectedCells[0].Value.ToString()}";
            //if (dataGridView1.SelectedCells[0].Value.ToString() == "")
            //{
            //    MessageBox.Show("Please select to Address you wish to Edit.");
            //}

            //if (MessageBox.Show("Want to edit Address!!", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    try
            //    {
            //        sql = $"update member set fname = '{textBox1.Text}', lname = '{textBox2.Text}', address = '{textBox3.Text}' where  member = {dataGridView1.SelectedCells[0].Value.ToString()}";
            //        db.ExecuteSQL(sql);

            //        DataTable dataTable = new DataTable();
            //        dataTable.Load(db.DisCart());
            //        dataGridView1.DataSource = dataTable;
            //        Frmeditmember_Load(sender, e);
            //        label3.Text = $"Address : {dataGridView1.SelectedCells[0].Value.ToString()} has been edit";

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            //db.disConnection();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedCells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedCells[3].Value.ToString();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            memId = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

        }
    }
}
