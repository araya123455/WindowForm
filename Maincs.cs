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
    public partial class Maincs : Form
    {
        public Maincs()
        {
            InitializeComponent();
        }

        private void Maincs_Load(object sender, EventArgs e)
        {
            //OracleConfiguration.TnsAdmin = @"C:\Users\User\Oracle\network\admin\DB202202241350";
            //OracleConfiguration.WalletLocation = OracleConfiguration.TnsAdmin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Creditcs frm = new Creditcs();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cashcs frm = new Cashcs();
            frm.ShowDialog();
        }
    }
}
