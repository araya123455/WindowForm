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
    public partial class Cashcs : Form
    {
        Database.DatabaseProcess db = new Database.DatabaseProcess();

        public Cashcs()
        {
            InitializeComponent();
        }

        private void Cashcs_Load(object sender, EventArgs e)
        {
            db.connect();
            db.SaleId();
            db.TotalPrice();
            string tt1 = Convert.ToString(db.tt);
            label4.Text = tt1;

            DataTable dataTable = new DataTable();
            dataTable.Load(db.PAYMENT());
            dataGridView1.DataSource = dataTable;
            dataGridView1.Refresh();

            db.connect();
            DataTable dataTable1 = new DataTable();
            dataTable1.Load(db.CASH());
            dataGridView2.DataSource = dataTable1;
            dataGridView2.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num;
            num = int.Parse(textBox2.Text);
            int change = num - db.tt;
            string cc = Convert.ToString(change);
            label5.Text = cc;
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmPayment f = new FrmPayment();
            f.ShowDialog();
        }
    }
}
