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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frmshop f = new Frmshop();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmShippingCast f = new FrmShippingCast();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Maincs f = new Maincs();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frmeditmember f = new Frmeditmember();
            f.ShowDialog();
        }
    }
}
