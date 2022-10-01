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
    public partial class Form2 : Form
    {
        Database.DatabaseProcess db = new Database.DatabaseProcess();
        public string sql = "";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            FrmLogin f = new FrmLogin();
            f.ShowDialog();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FrmAddMember f = new FrmAddMember();
            f.ShowDialog();
        }
    }
}
