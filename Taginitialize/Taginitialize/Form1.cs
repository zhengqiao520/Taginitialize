using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSHMySql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SSHConnectMySql();
        }
     
        public void SSHConnectMySql()
        {
            string SSHHost = "101.132.76.165";        // SSH地址
            int SSHPort = 22;              // SSH端口
            string SSHUser = "root";           // SSH用户名
            string SSHPassword = "ZhgZt20170904$$";           // SSH密码
            string sqlIPA = "127.0.0.1";// 映射地址  实际上也可以写其它的   Linux上的MySql的my.cnf bind-address 可以设成0.0.0.0 或者不设置
            string sqlHost = "127.0.0.1"; // mysql安装的机器IP 也可以是内网IP 比如：192.168.1.20
            uint sqlport = 3306;        // 数据库端口及映射端口
            string sqlConn = "Server=" + sqlIPA + ";Port=" + sqlport + ";Database=wdb007_dev;Uid=root;Pwd=Zt@165_20170906##;Pooling=false";
            string sqlSELECT = "select * from book_info";

            PasswordConnectionInfo connectionInfo = new PasswordConnectionInfo(SSHHost, SSHPort, SSHUser, SSHPassword);
            connectionInfo.Timeout = TimeSpan.FromSeconds(30);
            using (var client = new SshClient(connectionInfo))
            {
                try
                {
                    client.Connect();
                    if (!client.IsConnected)
                    {
                        MessageBox.Show("SSH connect failed");
                    }

                    var portFwdL = new ForwardedPortLocal(sqlIPA, sqlport, sqlHost, sqlport); //映射到本地端口
                    client.AddForwardedPort(portFwdL);
                    portFwdL.Start();
                    if (!client.IsConnected)
                    {
                        MessageBox.Show("port forwarding failed");
                    }

                    MySqlConnection conn = new MySqlConnection(sqlConn);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    myDataAdapter.SelectCommand = new MySqlCommand(sqlSELECT, conn);

                    try
                    {
                        conn.Open();
                        DataSet ds = new DataSet();
                        myDataAdapter.Fill(ds);
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }

                    client.Disconnect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}