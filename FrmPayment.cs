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
    public partial class FrmPayment : Form
    {
        Database.DatabaseProcess db = new Database.DatabaseProcess();
        public string sql, namePro, pricePro, idPro;
        public int empId = 1000000001;
        public double total, amount;
        public FrmPayment()
        {
            InitializeComponent();
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            db.connect();
            DataTable dataTable2 = new DataTable();
            dataTable2.Load(db.DisCart());
            dataGridView1.DataSource = dataTable2;

            string status2 = db.connect();
            DataTable dt1 = new DataTable();
            dt1.Load(db.DisPro());

            db.TotalPrice();
            string tt1 = Convert.ToString(db.tt);
            label10.Text = tt1;

            db.ShowReciept();
            label11.Text = db.date;
            label12.Text = db.fname;
            label13.Text = db.lname;
            label14.Text = db.sex;
            label15.Text = db.phone;
            label16.Text = db.address;
            db.disConnection();
        }
    }
}
