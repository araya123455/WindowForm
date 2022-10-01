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
    public partial class Creditcs : Form
    {
        Database.DatabaseProcess db = new Database.DatabaseProcess();

        public Creditcs()
        {
            InitializeComponent();
        }

        private void Creditcs_Load(object sender, EventArgs e)
        {
            db.connect();
            DataTable dataTable = new DataTable();
            dataTable.Load(db.PAYMENT());
            dataGridView1.DataSource = dataTable;
            dataGridView1.Refresh();

            db.connect();
            DataTable dataTable1 = new DataTable();
            dataTable1.Load(db.CREDIT());
            dataGridView2.DataSource = dataTable1;
            dataGridView2.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
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
