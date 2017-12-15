using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Threading;

using Phychips.Rcp;

namespace Phychips.PR9200
{
    public partial class UserControlCustom : UserControl
    {
        public UserControlCustom()
        {
            if (this.DesignMode)
                return;      

            InitializeComponent();

            UpdateButtonName();
        }

        Thread run;

        private void buttonUser1_Click(object sender, EventArgs e)
        {
            if (run == null || run.IsAlive == false)
            {
                run = new Thread(delegate() { RunRcp(Path.GetDirectoryName(Application.ExecutablePath) + "\\Custom\\" + "UserDefine_1.txt"); });

                run.Start();
            }
        }

        private void buttonUser2_Click(object sender, EventArgs e)
        {
            if (run == null || run.IsAlive == false)
            {
                run = new Thread(delegate() { RunRcp(Path.GetDirectoryName(Application.ExecutablePath) + "\\Custom\\" + "UserDefine_2.txt"); });

                run.Start();
            }
        }

        private void buttonUser3_Click(object sender, EventArgs e)
        {
            if (run == null || run.IsAlive == false)
            {
                run = new Thread(delegate() { RunRcp(Path.GetDirectoryName(Application.ExecutablePath) + "\\Custom\\" + "UserDefine_3.txt"); });

                run.Start();
            }
        }

        private void buttonUser4_Click(object sender, EventArgs e)
        {
            if (run == null || run.IsAlive == false)
            {
                run = new Thread(delegate() { RunRcp(Path.GetDirectoryName(Application.ExecutablePath) + "\\Custom\\" + "UserDefine_4.txt"); });

                run.Start();
            }
        }

        private void buttonUser5_Click(object sender, EventArgs e)
        {
            if (run == null || run.IsAlive == false)
            {
                run = new Thread(delegate() { RunRcp(Path.GetDirectoryName(Application.ExecutablePath) + "\\Custom\\" + "UserDefine_5.txt"); });

                run.Start();
            }
        }

        private void buttonConfig1_Click(object sender, EventArgs e)
        {
            FormUserDefine fud = new FormUserDefine("UserDefine_1.txt");
            fud.EventUpdate += fud_EventUpdateButton;

            fud.Show();
        }

        private void buttonConfig2_Click(object sender, EventArgs e)
        {
            FormUserDefine fud = new FormUserDefine("UserDefine_2.txt");
            fud.EventUpdate += fud_EventUpdateButton;

            fud.Show();
        }

        private void buttonConfig3_Click(object sender, EventArgs e)
        {
            FormUserDefine fud = new FormUserDefine("UserDefine_3.txt");
            fud.EventUpdate += fud_EventUpdateButton;

            fud.Show();
        }

        private void buttonConfig4_Click(object sender, EventArgs e)
        {
            FormUserDefine fud = new FormUserDefine("UserDefine_4.txt");
            fud.EventUpdate += fud_EventUpdateButton;

            fud.Show();
        }

        private void buttonConfig5_Click(object sender, EventArgs e)
        {
            FormUserDefine fud = new FormUserDefine("UserDefine_5.txt");
            fud.EventUpdate += fud_EventUpdateButton;

            fud.Show();
        }

        private void fud_EventUpdateButton(object obj, EventArgs e)
        {
            UpdateButtonName();
        }

        private void UpdateButtonName()
        {
            DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(Application.ExecutablePath) + "\\Custom\\");

            if (di.Exists)
            {
                string[] files = Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath) + "\\Custom\\", "*.txt");
                Button[] buttonArr = new Button[] { buttonUser1, buttonUser2, buttonUser3, buttonUser4, buttonUser5 };

                for (int i = 0; i < buttonArr.Length; i++)
                {
                    TextReader tr = new StreamReader(files[i]);
                    string temp = string.Empty;

                    while ((temp = tr.ReadLine()) != null)
                    {
                        if (temp.IndexOf("NAME") >= 0)
                        {
                            buttonArr[i].Text = temp.Substring(temp.IndexOf(">") + 1, temp.LastIndexOf("<") - temp.IndexOf(">") - 1);
                            break;
                        }
                    }

                    tr.Close();
                }
            }
        }

        private void RunRcp(string path)
        {
            FileInfo finfo = new FileInfo(path);

            if (finfo.Exists)
            {
                TextReader tr = new StreamReader(path);

                bool convert = false;
                string temp = string.Empty;

                while ((temp = tr.ReadLine()) != null)
                {
                    if (convert == true)
                    {
                        if (temp.IndexOf("</RCP") >= 0)
                        {
                            convert = false;
                            break;
                        }
                        else
                        {
                            string[] sa = temp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            if (sa.Length > 0)
                            {
                                byte[] ba = new byte[sa.Length];

                                for (int j = 0; j < ba.Length; j++)
                                {
                                    ba[j] = Convert.ToByte(sa[j], 16);                                    
                                }

                                RcpProtocol.Instance.SendBytePkt(ba);
                                System.Threading.Thread.Sleep(10);
                            }
                        }
                    }
                    else
                    {
                        if (temp.IndexOf("<RCP>") >= 0)
                        {
                            convert = true;
                        }
                    }
                }

                tr.Close();
            }         
        }
    }
}
