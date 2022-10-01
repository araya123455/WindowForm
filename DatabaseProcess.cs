using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.IO;

namespace Database
{
    class DatabaseProcess
    {
        OracleConnection conn;
        public int count = 0;
        public int saleid, sdetail, idss, logPass, logId;
        public int mId, lmember, tt;
        public int[] total;
        public string filename = @"file.txt", idN;
        public string fname, lname, sex, phone, address, date;
        public DatabaseProcess()
        {
        }
        public string connect()
        {
            string state = "", dSource, ChaineConnect;
            try
            {
                OracleConfiguration.TnsAdmin = @"C:\Users\User\Oracle\network\admin\DB202202241350"; ;//porperty
                OracleConfiguration.WalletLocation = OracleConfiguration.TnsAdmin;
            }
            catch (Exception e)
            {
                //database already has been connected.
            }
            conn = new OracleConnection(); //สร้าง instance
            dSource = "(description= (retry_count=20)(retry_delay=3)(connection_timeout=240)(address=(protocol=tcps)(port =1522)(host=adb.ap-seoul-1.oraclecloud.com))(connect_data=(service_name=aixfsmupi1dbjf1_db202202241350_tp.adb.oraclecloud.com))(security=(ssl_server_cert_dn=\"CN = adb.ap-seoul-1.oraclecloud.com, OU = Oracle ADB SEOUL, O = Oracle Corporation, L = Redwood City, ST = California, C = US\")))";

            ChaineConnect = "Data Source =" + dSource
            + "Min Pool Size=10;Connection Lifetime=100000;Connection Timeout=240;User ID=ora2;Password=19i@Mahanakorn@2022";

            conn.ConnectionString = ChaineConnect; //กำหนดค่าการเชื่อมต่อฐานข้อมูล
            conn.Open();
            state = conn.State.ToString();
            if (state == "Open")
                return "Database has been connected.";
            else return "Database cannot be connect.";
        }
        public void disConnection()
        {
            conn.Close();
        }
        public OracleDataReader loadpay_detail()
        {

            OracleCommand command = conn.CreateCommand();
            OracleDataReader dtreader;
            command.CommandText = "select * from pay_detail";
            return dtreader = command.ExecuteReader(); ;

        }
        public OracleDataReader loadmember()
        {
            MemberId();
            OracleCommand command = conn.CreateCommand();
            OracleDataReader dtreader;
            command.CommandText = $"select * from member WHERE MEMBER_ID = {lmember}";
            return dtreader = command.ExecuteReader(); ;

        }
        // ID Name
        public OracleDataReader idName()
        {
            OracleCommand command = conn.CreateCommand();
            OracleDataReader dtreader;
            MemberId();
            command.CommandText = $"select MEMBER_ID, FNAME from member WHERE MEMBER_ID = {lmember}";
            OracleDataReader dtReader1 = command.ExecuteReader();
            while (dtReader1.Read())
            {
                idN = $"" + dtReader1.GetString(0) + "    " + dtReader1.GetString(1);
            }
            return dtreader = command.ExecuteReader(); ;

        }
        // Reciept
        public OracleDataReader ShowReciept()
        {
            OracleCommand command = conn.CreateCommand();
            OracleDataReader dtreader;
            MemberId();
            command.CommandText = $"select FNAME, LNAME, SEX, PHONE, ADDRESS from member WHERE MEMBER_ID = {lmember}";
            OracleDataReader dtReader1 = command.ExecuteReader();
            while (dtReader1.Read())
            {
                fname = dtReader1.GetString(0);
                lname = dtReader1.GetString(1);
                sex = dtReader1.GetString(2);
                phone = dtReader1.GetString(3);
                address = dtReader1.GetString(4);
            }

            OracleCommand command1 = conn.CreateCommand();
            MemberId();
            command1.CommandText = $"select PAYDATE from PAYMENT WHERE MEMBER_ID = {lmember}";
            OracleDataReader dtReader3 = command1.ExecuteReader();
            while (dtReader3.Read())
            {
                date = dtReader3.GetString(0);
            }
            return dtreader = command.ExecuteReader(); ;

        }
        // Logpass
        public OracleDataReader loadlogin()
        {
            OracleCommand command = conn.CreateCommand();
            OracleDataReader dtreader;
            command.CommandText = $"select LOGIN_ID, PASSWORD from login WHERE LOGIN_ID = {logId}";
            OracleDataReader dtReader1 = command.ExecuteReader();
            while (dtReader1.Read())
            {
                logId = int.Parse(dtReader1.GetString(0));
                logPass = int.Parse(dtReader1.GetString(1));
            }
            return dtreader = command.ExecuteReader(); ;

        }

        public int ExecuteSQL5(string sql)
        {
            OracleCommand command = conn.CreateCommand();
            command.CommandText = sql;
            int numResult = command.ExecuteNonQuery();
            return numResult;
        }
        public OracleDataReader Loadsale_detail()
        {
            OracleCommand command = conn.CreateCommand();
            OracleDataReader dtreader;
            command.CommandText = "select * from sale_detail";
            return dtreader = command.ExecuteReader(); ;
        }

        public int ExecuteSQL(string sql)
        {
            OracleCommand command = conn.CreateCommand();
            command.CommandText = sql;
            int numResult = command.ExecuteNonQuery();
            return numResult;
        }
        public int ExecuteSQL2(string sql2)
        {
            OracleCommand command2 = conn.CreateCommand();
            command2.CommandText = sql2;

            int numRe = command2.ExecuteNonQuery();
            return numRe;
        }
        public void DeleteSQL(string sql)
        {
            OracleCommand command = conn.CreateCommand();
            command.CommandText = sql;
            command.CommandType = System.Data.CommandType.Text;
            command.ExecuteNonQuery();
        }

        public OracleDataReader DisPro()
        {
            OracleCommand command = conn.CreateCommand();
            OracleDataReader dtreader;
            command.CommandText = "select product_id, product_price, productname from PRODUCT";
            return dtreader = command.ExecuteReader();
        }

        // Cart
        public OracleDataReader DisCart()
        {
            OracleCommand command = conn.CreateCommand();
            OracleDataReader dtreader;
            SaleId();
            command.CommandText = $"SELECT * FROM SALE_DETAIL WHERE SALE_ID = {idss}";

            return dtreader = command.ExecuteReader();
        }
        public OracleDataReader SaleId()
        {
            OracleCommand command = conn.CreateCommand();
            OracleDataReader dtreader;
            MemberId();
            command.CommandText = $"SELECT SALE_ID FROM SALE WHERE MEMBER_ID = {lmember}";
            OracleDataReader dtReader1 = command.ExecuteReader();
            while (dtReader1.Read())
            {
                idss = int.Parse(dtReader1.GetString(0));
            }
            return dtreader = command.ExecuteReader();
        }
        // Member ID
        public void MemberId()
        {
            string read, data = "";
            StreamReader file = new StreamReader(filename);
            while ((read = file.ReadLine()) != null)
            {
                data += read;
            }
            lmember = int.Parse(data);
        }
        //Shopping
        public OracleDataReader Sale()
        {
            OracleCommand command1 = conn.CreateCommand();
            command1.CommandText = "Select SALE_ID From SALE";
            OracleDataReader dtReader1 = command1.ExecuteReader();
            int max = 0;
            while (dtReader1.Read())
            {
                int nr = int.Parse(dtReader1.GetString(0));
                if (nr > max)
                {
                    max = nr;
                }
            }
            saleid = max + 1;
            return dtReader1 = command1.ExecuteReader();
        }

        //Shopping
        public OracleDataReader SaleDetail()
        {
            OracleCommand command1 = conn.CreateCommand();
            command1.CommandText = "Select SALEDETAIL_ID From SALE_DETAIL";
            OracleDataReader dtReader1 = command1.ExecuteReader();
            int max = 0;
            while (dtReader1.Read())
            {
                int nr = int.Parse(dtReader1.GetString(0));
                if (nr > max)
                {
                    max = nr;
                }
            }
            sdetail = max + 1;
            return dtReader1 = command1.ExecuteReader();

        }

        //Shopping ADD

        public int ExecuteSQL3(string sql)
        {
            OracleCommand command = conn.CreateCommand();
            command.CommandText = sql;
            int numResult = command.ExecuteNonQuery();
            return numResult;
        }

        // Total
        public OracleDataReader TotalPrice()
        {
            OracleCommand command1 = conn.CreateCommand();
            command1.CommandText = $"Select SALEPRICE, AMOUNT From SALE_DETAIL WHERE SALE_ID = {idss}";
            OracleDataReader dtReader1 = command1.ExecuteReader();

            OracleCommand command2 = conn.CreateCommand();
            command2.CommandText = $"Select COUNT(SALE_ID) From SALE_DETAIL WHERE SALE_ID = {idss}";
            OracleDataReader dtReader2 = command2.ExecuteReader();
            int n = 0;
            while (dtReader2.Read())
            {
                n = int.Parse(dtReader2.GetString(0));
            }
            total = new int[n];

            int nr1, nr2, i = 0;
            tt = 0;
            while (dtReader1.Read())
            {
                nr1 = int.Parse(dtReader1.GetString(0));
                nr2 = int.Parse(dtReader1.GetString(1));
                total[i] = nr1 * nr2;
                i++;
            }
            for (int o = 0; o < total.Length; o++)
            {
                tt += total[o];
            }
            return dtReader1 = command1.ExecuteReader();

        }

        // Payment
        public OracleDataReader PAYMENT()
        {
            OracleCommand command = conn.CreateCommand();
            OracleDataReader dtReader;
            command.CommandText = "select * from PAYMENT";
            return dtReader = command.ExecuteReader();
        }
        public OracleDataReader CREDIT()
        {
            OracleCommand command = conn.CreateCommand();
            OracleDataReader dtReader;
            command.CommandText = "select * from CREDIT";
            return dtReader = command.ExecuteReader();
        }
        public OracleDataReader CASH()
        {
            OracleCommand command = conn.CreateCommand();
            OracleDataReader dtReader;
            command.CommandText = "select * from CASH";
            return dtReader = command.ExecuteReader();
        }
        public int ExecuteSQL4(string sql)
        {
            OracleCommand command = conn.CreateCommand();
            command.CommandText = sql;
            int numResult = command.ExecuteNonQuery();
            return numResult;
        }

    }
}
