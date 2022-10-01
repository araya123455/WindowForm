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
   
    public partial class FrmAddMember : Form
    {
        Database.DatabaseProcess db = new Database.DatabaseProcess();
        public string sql = "",sql2 = "", sql3 = "";
        public string memId;
        public int empId = 1000000001;

        public FrmAddMember()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            sql = $"insert into member (member_id,fname, lname, sex, phone, address) values " +
                 $"({textBox1.Text}, '{textBox2.Text}', '{textBox3.Text}','{comboBox1.Text}', '{textBox4.Text}', '{textBox5.Text}')";
            //$" '{comboBox1.SelectedValue}')";
           
            textBox6.Text = sql;

            

        }

        private void FrmAddMember_Load(object sender, EventArgs e)
        {
            db.connect();
            DataTable dt = new DataTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.connect();
            int status = db.ExecuteSQL(sql);
            db.disConnection();
            label7.Text = $"Member ID: {textBox1.Text} has been inserted";

            TextWriter file = new StreamWriter(db.filename, false);
            file.Write(string.Empty);
            file.WriteLine(textBox1.Text);
            file.Close();

            db.connect();
            db.Sale();
            sql2 = $"insert into SALE (MEMBER_ID, SALE_ID, PAYSTATUS, TOTALSALEPRICE,EMP_ID) values " +
             $"({textBox1.Text}, {db.saleid}, 'N', 0, {empId})";
            int status2 = db.ExecuteSQL2(sql2);
            db.DisCart();
            db.mId = int.Parse(textBox1.Text); 


            sql3 = $"insert into LOGIN (LOGIN_ID, PASSWORD) values " +
             $"({textBox1.Text}, {textBox7.Text})";
            int status3 = db.ExecuteSQL5(sql3);
            db.disConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frmviewmember f = new Frmviewmember();
            f.ShowDialog();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
           

        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f = new Form3();
            f.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Frmshop f = new Frmshop();
            f.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
