using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using System.Data.OleDb;




namespace test
{
    public partial class frmLogin : Form
    {
        //数据源
        /*public const string connString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=172.27.152.151)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ZCL50)));Persist Security Info=True;User ID=shanmu;Password=sm888;";
        OracleConnection conn = new OracleConnection(connString);//实例化*/

        public static string ConnectOracle()
        {
            try
            {
                string connString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=172.27.152.151)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ZCL50)));Persist Security Info=True;User ID=shanmu;Password=sm888;";
                OracleConnection con = new OracleConnection(connString);
                con.Open(); return "连接成功";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtUserID.Text = "";
            txtPWD.Text = "";
            txtUserID.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmLogin frmlogin = new frmLogin();
            //MDI frm = new MDI();
            if (txtUserID.Text == "" || txtPWD.Text == "")
            {
                MessageBox.Show("用户账号和密码不能为空！");
            }
           /* if (txtstID.Text == "" || txtstName.Text == "")
            {
                MessageBox.Show("学号和姓名不能为空", "提示", MessageBoxButtons.OK);
                return (0);
            }*/
            else if (txtUserID.TextLength != 11 )
            {
                MessageBox.Show("请输入正确的11位手机号", "提示", MessageBoxButtons.OK);
            }
            else
            {
                //frmstinfo.Show();
                //frm.Show();
                this.Close();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string oradb = "Data Source=(DESCRIPTION="
             + "(ADDRESS=(PROTOCOL=TCP)(HOST=DESKTOP-94OBPDN)(PORT=1521))"
             + "(CONNECT_DATA=(SERVICE_NAME=ZCL50)));"
             + "User Id=shanmu;Password=sm888;";

            try
            {
                OracleConnection conn = new OracleConnection(oradb);
                conn.Open();
                string strsql;
                strsql = "SELECT * FROM customer";
                //OleDbCommand mycmOleDBCommand1 = new OleDbCommand(strSQL1, myConnection);
                OracleCommand cmd = new OracleCommand(strsql , conn);
                cmd.CommandType = CommandType.Text;

                //大容量数据，可以进行修改，使用DataSet和DataAdapter
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                //使用DataReader，读取数据
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) // C#
                {
                    comboBox1.Items.Add(dr["cname"].ToString());
                }

                dr.Close();

                conn.Dispose(); //Close()也可以。

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
            finally
            {

            }
        }
    }
}
