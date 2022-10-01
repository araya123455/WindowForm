using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace project_1205
{
    public partial class FrmLogin : Form
    {
        Database.DatabaseProcess db = new Database.DatabaseProcess();
        public string sql = "";


        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT Column1 FROM Login WHERE Login_id = '" + textBox1.Text + "' Password = '" + textBox2.Text + "'";
            DataTable dt = new DataTable();
            db.logId = int.Parse(textBox1.Text);
            db.loadlogin();
            int id = int.Parse(textBox1.Text), pass = int.Parse(textBox2.Text);
            if (db.logId == id && db.logPass == pass)
            {
                TextWriter file = new StreamWriter(db.filename, false);
                file.Write(string.Empty);
                file.WriteLine(textBox1.Text);
                file.Close();

                this.Hide();
                Form3 f = new Form3();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect", "An error occurred");
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            db.connect();
            DataTable dt = new DataTable();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAddMember f = new FrmAddMember();
            f.ShowDialog();
        }
    }
}
