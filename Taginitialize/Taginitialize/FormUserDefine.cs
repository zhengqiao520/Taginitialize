using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Threading;

using Phychips.Rcp;

namespace Phychips.PR9200
{
    public partial class FormUserDefine : Form
    {
        static  string _path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Custom\\";
        private string _fileNmae = string.Empty;

        public delegate void deleUpdatebutton(object obj, EventArgs e);
        public event deleUpdatebutton EventUpdate;

        private enum ParseMode { NAME, DES, RCP };

        public FormUserDefine()
        {
            InitializeComponent();
        }

        public FormUserDefine(string s) : this()
        {
            _fileNmae = s;

            FileInfo finfo = new FileInfo(_path + _fileNmae);

            if (finfo.Exists == true)
            {
                TextReader tr = new StreamReader(_path + _fileNmae);
                string temp = string.Empty;

                ParseMode mode = ParseMode.NAME;

                while ( (temp = tr.ReadLine()) != null)
                {
                    switch (mode)
                    {
                        case ParseMode.NAME:
                            textBoxName.Text = temp.Substring(temp.IndexOf(">") + 1, temp.LastIndexOf("<") - temp.IndexOf(">") - 1);
                            this.Text = textBoxName.Text;
                            mode = ParseMode.DES;
                            break;
                        case ParseMode.DES:
                            if (temp.IndexOf("</DES>") >= 0)
                            {
                                mode = ParseMode.RCP;
                            }
                            else
                            {
                                if (!(temp.IndexOf("<") >= 0 || temp.IndexOf(">") >= 0 || temp.IndexOf("/") >= 0))
                                {
                                    if (temp != string.Empty)
                                    {
                                        textBoxDes.AppendText(temp + "\r\n");                        
                                    }                        
                                }    
                            }
                            break;
                        case ParseMode.RCP:
                            if (!(temp.IndexOf("<") >= 0 || temp.IndexOf(">") >= 0 || temp.IndexOf("/") >= 0))
                            {
                                if (temp != string.Empty)
                                {
                                    textBoxRCP.AppendText(temp + "\r\n");
                                }
                            }    
                            break;
                        default:
                            break;
                    }                            
                }                

                tr.Close();
            }
            else
            {
                MessageBox.Show("Invalid File Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            FileInfo finfo = new FileInfo(_path + _fileNmae);

            if (finfo.Exists == true)
            {
                StreamWriter sw = new StreamWriter(new FileStream(_path + _fileNmae, FileMode.OpenOrCreate));

                sw.WriteLine("<NAME>" + textBoxName.Text + "</NAME>");

                sw.WriteLine("<DES>");
                if (textBoxDes.Text != string.Empty)
                {
                    sw.WriteLine(textBoxDes.Text);
                }
                sw.WriteLine("</DES>");

                sw.WriteLine("<RCP>");
                if (textBoxRCP.Text != string.Empty)
                {
                    sw.WriteLine(textBoxRCP.Text);
                }                
                sw.WriteLine("</RCP>");
                sw.Close();

                if (EventUpdate != null)
                {
                    EventUpdate(null, null);
                }
            }
            else
            {
                MessageBox.Show("Invalid File Name", "Error",  MessageBoxButtons.OK,MessageBoxIcon.Error);
            }            
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (run == null || run.IsAlive == false)
            {
                run = new Thread(RunRcp);

                run.Start();
            }
        }

        Thread run;

        private void RunRcp()
        {
            string s = textBoxRCP.Text;
            string[] sa = s.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            if (sa.Length > 0)
            {
                toggleFormEnable();

                for (int i = 0; i < sa.Length; i++)
                {
                    string temp = sa[i];
                    string[] tempArr = sa[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    byte[] ba = new byte[tempArr.Length];

                    for (int j = 0; j < ba.Length; j++)
                    {
                        ba[j] = Convert.ToByte(tempArr[j],16);
                    }

                    RcpProtocol.Instance.SendBytePkt(ba);
                    System.Threading.Thread.Sleep(10);
                }

                toggleFormEnable();
            }
        }

        private void toggleFormEnable()
        {
            if (!InvokeRequired)
            {
                this.Enabled = !this.Enabled;
                return;
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.Enabled = !this.Enabled;
                }));
            }               
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string s = string.Empty;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                s = openFileDialog.FileName;

                TextReader tr = new StreamReader(s);
                string contents = tr.ReadToEnd();
                tr.Close();

                TextWriter tw = new StreamWriter(_path + _fileNmae);
                tw.Write(contents);
                tw.Close();

                if (EventUpdate != null)
                {
                    EventUpdate(null, null);

                    TextReader tr_ = new StreamReader(_path + _fileNmae);
                    string temp = string.Empty;

                    ParseMode mode = ParseMode.NAME;

                    while ((temp = tr_.ReadLine()) != null)
                    {
                        switch (mode)
                        {
                            case ParseMode.NAME:
                                textBoxName.Text = temp.Substring(temp.IndexOf(">") + 1, temp.LastIndexOf("<") - temp.IndexOf(">") - 1);
                                this.Text = textBoxName.Text;
                                mode = ParseMode.DES;
                                break;
                            case ParseMode.DES:
                                if (temp.IndexOf("</DES>") >= 0)
                                {
                                    mode = ParseMode.RCP;
                                }
                                else
                                {
                                    if (!(temp.IndexOf("<") >= 0 || temp.IndexOf(">") >= 0 || temp.IndexOf("/") >= 0))
                                    {
                                        if (temp != string.Empty)
                                        {
                                            textBoxDes.AppendText(temp + "\r\n");
                                        }
                                    }
                                }
                                break;
                            case ParseMode.RCP:
                                if (!(temp.IndexOf("<") >= 0 || temp.IndexOf(">") >= 0 || temp.IndexOf("/") >= 0))
                                {
                                    if (temp != string.Empty)
                                    {
                                        textBoxRCP.AppendText(temp + "\r\n");
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }

                    tr_.Close();
                }
            }
            else
            {

            }
        }
    }
}
