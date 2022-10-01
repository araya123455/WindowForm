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
    public partial class Frmviewmember : Form
    {

        Database.DatabaseProcess db = new Database.DatabaseProcess();
        public Frmviewmember()
        {
            InitializeComponent();
        }

        private void Frmviewmember_Load(object sender, EventArgs e)
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
    }
}
