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

namespace project_1205
{
    public partial class Frmshop : Form
    {
        Database.DatabaseProcess db = new Database.DatabaseProcess();
        public string sql, namePro, pricePro, idPro;
        public int empId = 1000000001;
        public double total, amount;
        public Frmshop()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmShippingCast f = new FrmShippingCast();
            f.ShowDialog();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Frmshop_Load(object sender, EventArgs e)
        {
            string status = db.connect();
            DataTable dataTable = new DataTable();
            dataTable.Load(db.DisPro());
            dataGridView1.DataSource = dataTable;

            DataTable dataTable2 = new DataTable();
            dataTable2.Load(db.DisCart());
            dataGridView2.DataSource = dataTable2;

            string status2 = db.connect();
            DataTable dt1 = new DataTable();
            dt1.Load(db.DisPro());

            db.TotalPrice();
            string tt1 = Convert.ToString(db.tt);
            label8.Text = tt1;

            db.idName();
            label10.Text = db.idN;
            db.disConnection();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            db.connect();
            Status.Text = $"Status...";
            db.SaleDetail();
            db.SaleId();
            sql = $"insert into SALE_DETAIL (SALEDETAIL_ID, SALE_ID, PRODUCT_ID, SALEPRICE, AMOUNT) values " +
                $"({db.sdetail}, {db.idss}, {idPro}, {pricePro}, {numericUpDown1.Text})";
            int status2 = db.ExecuteSQL3(sql);
            DataTable dataTable2 = new DataTable();
            dataTable2.Load(db.DisCart());
            dataGridView2.DataSource = dataTable2;

            db.TotalPrice();
            string tt1 = Convert.ToString(db.tt);
            label8.Text = tt1;
            db.disConnection();
            Status.Text = $"Successfully Added The Product";
        }

        private void Status_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idPro = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            namePro = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            pricePro = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            this.textBox3.Text = idPro;
            this.textBox1.Text = namePro;
            this.textBox2.Text = pricePro;
        }
    }
}
