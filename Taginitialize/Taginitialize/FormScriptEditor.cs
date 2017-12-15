using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

using Phychips.Helper;
using Phychips.Rcp;

namespace Phychips.PR9200
{
    public partial class FormScriptEditor : Form
    {
        static string CommonScriptPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Script";
        static string FileName = null;
        static string InitialFormName = "Script Editor";      

        public FormScriptEditor()
        {
            InitializeComponent();

            this.InitAssistor();
        }

        private void StrToMS(RichTextBox txtBox, bool withArr)
        {
            ScriptToRCP.ArrCnt = 0;
            string s;
            string[] sa;
            StreamWriter sw = new StreamWriter(FormScriptEditor.CommonScriptPath + "\\Gen\\" + (withArr?"rCPGen_withArray.txt":"rCPGen.txt"));

            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(txtBox.Text));
            TextReader reader = new StreamReader(ms, Encoding.ASCII);

            s = reader.ReadToEnd();
            s.Trim();
            s = s.Replace(" ", "");
            s = s.ToLower();

            if (s.Length == 0)
            {
                sw.Close();
                return;
            }

            if (s[s.Length - 1] == ',')
            {
                s = s.Substring(0, s.LastIndexOf(','));
            }

            sa = s.Split(new char[] { '\r', '\n'});

            for (int i = 0; i < sa.Length; i++)
            {
                if (sa[i] != "")
                {
                    string[] ss;
                    ss = sa[i].Split(new char[] { ',', ' '});

                    RCPBuilder valClass = (RCPBuilder)ScriptToRCP.ht[ss[0]];
                    try
                    {
                        if (ss.Length == 1)
                        {
                            sw.WriteLine(valClass.ByteArrToString(valClass.CmdToRCP(), withArr));
                        }
                        else if (ss.Length == 2)
                        {
                            try
                            {
                                sw.WriteLine(valClass.ByteArrToString(valClass.CmdToRCP(Convert.ToUInt16(ss[1])),withArr));
                            }
                            catch (GetSleepException)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            throw new FormatException();
                        }
                    }
                    catch (FormatException)
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int j = 1; j < ss.Length; j++)
                        {
                            sb.Append(ss[j] + ",");
                        }
                        try
                        {
                            sw.WriteLine(valClass.ByteArrToString(valClass.CmdToRCP(sb.ToString()),withArr));
                        }
                        catch (NotImplementedException)
                        {
                            MessageBox.Show("Syntax Error",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Syntax Error",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }                     
            sw.Close();            
            this.toolStripStatusLabelGen.Text = FormScriptEditor.CommonScriptPath + "\\Gen\\" + (withArr?"rCPGen_withArray.txt":"rCPGen.txt");
        }

        private void StrToMS(RichTextBox txtBox, bool withArr, bool Run)
        {
            ScriptToRCP.ArrCnt = 0;

            if (Run == true)
            {
                string s;
                string[] sa;
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(txtBox.Text));
                TextReader reader = new StreamReader(ms, Encoding.ASCII);
                
                s = reader.ReadToEnd();
                s.Trim();
                s = s.Replace(" ", "");
                s = s.ToLower();

                try
                {
                    if (s.Length != 0)
                    {
                        if (s[s.Length - 1] == ',')
                        {
                            s = s.Substring(0, s.LastIndexOf(','));
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                catch
                {
                    return;                    
                }
                

                sa = s.Split(new char[] { '\r', '\n' });
                
                for (int i = 0; i < sa.Length; i++)
                {
                    if (sa[i] != "")
                    {
                        string[] ss;
                        ss = sa[i].Split(new char[] { ',', ' ' });

                        RCPBuilder valClass = (RCPBuilder)ScriptToRCP.ht[ss[0]];
                        try
                        {
                            if (ss.Length == 1)
                            {
                                RcpProtocol.Instance.SendBytePkt(valClass.CmdToRCP());
                            }
                            else if (ss.Length == 2)
                            {
                                try
                                {
                                    RcpProtocol.Instance.SendBytePkt(valClass.CmdToRCP(Convert.ToUInt16(ss[1])));
                                }
                                catch (GetSleepException)
                                {                                    
                                    //System.Threading.Thread.Sleep(UInt16.Parse(ss[1]));
                                    Thread.Sleep(UInt16.Parse(ss[1]));
                                }
                                // If the ss[1] is not a number, FormatException will be generated by above method
                            }
                            else
                            {
                                throw new FormatException();
                            }
                        }
                        catch(FormatException)
                        {
                            StringBuilder sb = new StringBuilder();
                            for (int j = 1; j < ss.Length; j++)
                            {
                                sb.Append(ss[j] + ",");
                            }
                            try
                            {
                                RcpProtocol.Instance.SendBytePkt(valClass.CmdToRCP(sb.ToString()));   
                            }
                            catch (NotImplementedException)
                            {
                                MessageBox.Show("Syntax Error",
                                                "Error",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Syntax Error",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                    }
                    Thread.Sleep(50);
                }
            }
        }

        private void buildRCPOnlyToolStripMenuItem1_Click(object sender, EventArgs e)
        {                       
            StrToMS(richTextBoxScript,false);
            toolStripStatusLabelStatus.Text = "Work Complete";
        }

        private void buildRCPWithArrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StrToMS(richTextBoxScript, true);
            toolStripStatusLabelStatus.Text = "Work Complete";
        }

        private void buildRunToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            Thread thr = new Thread(new ThreadStart(threadRun));            
            thr.SetApartmentState(ApartmentState.MTA);
            thr.Start();
        }

        private void threadRun()
        {            
            if (!InvokeRequired)
            {
                this.Enabled = false;
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.Enabled = false;
                }));
            }

            if (!InvokeRequired)
            {                
                StrToMS(richTextBoxScript, false, true);                
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate()
                {                    
                    StrToMS(richTextBoxScript, false, true);                    
                }));
            }

            if (!InvokeRequired)
            {
                this.Enabled = true;
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.Enabled = true;
                }));
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBoxScript.Modified)
            {
                DialogResult r = MessageBox.Show(this,
                                 "Current Script has changed. Save Current Script?",
                                 "Save",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question,
                                 MessageBoxDefaultButton.Button1);

                if (r == DialogResult.Yes)
                {
                    SaveFileDialog svd = new SaveFileDialog();

                    svd.Title = "Save";
                    svd.Filter = "RTF files (*.rtf)|*.rtf";
                    svd.InitialDirectory = FormScriptEditor.CommonScriptPath;

                    if (svd.ShowDialog() == DialogResult.OK)
                    {
                        FormScriptEditor.FileName = svd.FileName.Substring(svd.FileName.LastIndexOf("\\") + 1);
                        this.Text = FormScriptEditor.FileName;
                        richTextBoxScript.SaveFile(FormScriptEditor.FileName);
                    }
                }
            }
            richTextBoxScript.Text = "";
            richTextBoxScript.Modified = true;
            this.Text = InitialFormName;
            FormScriptEditor.FileName = null;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Open Script";
            ofd.Filter = "RTF files (*.rtf)|*.rtf";
            ofd.InitialDirectory = FormScriptEditor.CommonScriptPath;

            if (richTextBoxScript.Modified)
            {
                DialogResult r = MessageBox.Show(this,
                                 "Current Script has changed. Save Current Script?",
                                 "Save",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question,
                                 MessageBoxDefaultButton.Button1);
                
                if (r == DialogResult.Yes)
                {
                    SaveFileDialog svd = new SaveFileDialog();

                    svd.Title = "Save";
                    svd.Filter = "RTF files (*.rtf)|*.rtf";
                    svd.InitialDirectory = FormScriptEditor.CommonScriptPath;

                    if (svd.ShowDialog() == DialogResult.OK)
                    {
                        FormScriptEditor.FileName = svd.FileName;
                        this.Text = FormScriptEditor.FileName.Substring(svd.FileName.LastIndexOf("\\") + 1);
                        richTextBoxScript.SaveFile(FormScriptEditor.FileName);
                    }
                }
            }

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FormScriptEditor.FileName = ofd.FileName;
                this.Text = ofd.FileName.Substring(ofd.FileName.LastIndexOf("\\") + 1);
                richTextBoxScript.LoadFile(FormScriptEditor.FileName);                
            }
            richTextBoxScript.Modified = false;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog();

            svd.Title = "Save";
            svd.Filter = "RTF files (*.rtf)|*.rtf";
            svd.InitialDirectory = FormScriptEditor.CommonScriptPath;

            if (FormScriptEditor.FileName != null)
            {
                this.Text = FormScriptEditor.FileName.Substring(FormScriptEditor.FileName.LastIndexOf("\\") + 1);
                richTextBoxScript.SaveFile(FormScriptEditor.FileName);
            }
            else if(svd.ShowDialog() == DialogResult.OK)
            {
                FormScriptEditor.FileName = svd.FileName;
                this.Text = FormScriptEditor.FileName.Substring(svd.FileName.LastIndexOf("\\") + 1);
                richTextBoxScript.SaveFile(FormScriptEditor.FileName);
            }
            richTextBoxScript.Modified = false;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog();

            svd.Title = "Save As";
            svd.Filter = "RTF files (*.rtf)|*.rtf";
            svd.InitialDirectory = FormScriptEditor.CommonScriptPath;
            svd.FileName = this.Text;

            if (svd.ShowDialog() == DialogResult.OK)
            {
                FormScriptEditor.FileName = svd.FileName;
                this.Text = FormScriptEditor.FileName.Substring(svd.FileName.LastIndexOf("\\") + 1);
                richTextBoxScript.SaveFile(FormScriptEditor.FileName);
            }
            richTextBoxScript.Modified = false;

            try
            {
                Application.Exit();
            }
            catch
            {
                
            }
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxScript.Undo();
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxScript.Redo();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxScript.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            richTextBoxScript.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxScript.Paste();
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxScript.SelectAll();
        }

        private void SaveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog();
            svd.Title = "Save As";
            svd.Filter = "RTF files (*.rtf)|*.rtf";
            svd.InitialDirectory = FormScriptEditor.CommonScriptPath;
            svd.FileName = this.Text;

            if (svd.ShowDialog() == DialogResult.OK)
            {
                FormScriptEditor.FileName = svd.FileName;
                this.Text = FormScriptEditor.FileName.Substring(svd.FileName.LastIndexOf("\\") + 1);
                richTextBoxScript.SaveFile(FormScriptEditor.FileName);
            }
            richTextBoxScript.Modified = false;
        }

        private void richTextBoxScript_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabelStatus.Text = string.Empty;                
        }

        private void InitAssistor()
        {
            for (int i = 0; i < ScriptToRCP.keyFragment.Length; i++)
            {
                RCPBuilder valClass = (RCPBuilder)ScriptToRCP.ht[ScriptToRCP.keyFragment[i]];

                string[] saDes = valClass.CmdtoDes.ToString().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                int idxTemp = richTextBoxAssistor.Text.Length;

                if (saDes.Length != 0)
                {
                    richTextBoxAssistor.AppendText(saDes[3].Split(',')[0]);
                    richTextBoxAssistor.AppendText("\r\n");

                    richTextBoxAssistor.Select(idxTemp, richTextBoxAssistor.Text.Length);
                    richTextBoxAssistor.SelectionFont = new Font(richTextBoxAssistor.Font, FontStyle.Bold);           
                }                
                richTextBoxAssistor.AppendText("\r\n");
            }            
        }

        private void richTextBoxScript_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Oemcomma || (richTextBoxAssistor.Text.IndexOf(',')>=0))
            {
                this.richTextBoxAssistor.Clear();
                string currentline = string.Empty;

                if (richTextBoxScript.Text == string.Empty)
                {
                    this.InitAssistor();
                    return;
                }

                try
                {
                    currentline = richTextBoxScript.Lines[richTextBoxScript.GetLineFromCharIndex(richTextBoxScript.SelectionStart)];

                    string[] sa = currentline.Split(',');
                    string keyFrg = string.Empty;

                    keyFrg = sa[0].ToLower();
                    keyFrg = keyFrg.Trim();
                    keyFrg = keyFrg.Replace(" ", "");

                    for (int i = 0; i < ScriptToRCP.keyFragment.Length; i++)
                    {
                        if (ScriptToRCP.keyFragment[i].IndexOf(keyFrg) >= 0)
                        {
                            RCPBuilder valClass = (RCPBuilder)ScriptToRCP.ht[ScriptToRCP.keyFragment[i]];

                            string[] saDes = valClass.CmdtoDes.ToString().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                            int idxTemp = richTextBoxAssistor.Text.Length;

                            for (int j = 0; j < saDes.Length; j++)
                            {
                                if (j == 0)
                                {
                                    richTextBoxAssistor.AppendText(saDes[3].Split(',')[0]);
                                    richTextBoxAssistor.AppendText("\r\n");

                                    richTextBoxAssistor.Select(idxTemp, richTextBoxAssistor.Text.Length);
                                    richTextBoxAssistor.SelectionFont = new Font(richTextBoxAssistor.Font, FontStyle.Bold);
                                }
                                else if (j == 1)
                                {
                                    richTextBoxAssistor.AppendText("-Description : ");
                                    richTextBoxAssistor.AppendText(saDes[j]);
                                    richTextBoxAssistor.AppendText("\r\n");
                                }
                                else if (j == 2)
                                {
                                    richTextBoxAssistor.AppendText("-Arguments : ");
                                    richTextBoxAssistor.AppendText(saDes[j]);
                                    richTextBoxAssistor.AppendText("\r\n");
                                }
                                else
                                {
                                    richTextBoxAssistor.AppendText("-Example : ");
                                    richTextBoxAssistor.AppendText(saDes[j]);
                                    richTextBoxAssistor.AppendText("\r\n");
                                }
                            }
                            richTextBoxAssistor.AppendText("\r\n");
                        }
                    }
                }
                catch
                {
                }
            }
            else
            {
                this.richTextBoxAssistor.Clear();
                string currentline = string.Empty;

                if (richTextBoxScript.Text == string.Empty)
                {
                    this.InitAssistor();
                    return;
                }

                try
                {
                    currentline = richTextBoxScript.Lines[richTextBoxScript.GetLineFromCharIndex(richTextBoxScript.SelectionStart)];

                    string[] sa = currentline.Split(',');
                    string keyFrg = string.Empty;

                    keyFrg = sa[0].ToLower();
                    keyFrg = keyFrg.Trim();
                    keyFrg = keyFrg.Replace(" ", "");

                    for (int i = 0; i < ScriptToRCP.keyFragment.Length; i++)
                    {
                        if (ScriptToRCP.keyFragment[i].IndexOf(keyFrg) >= 0)
                        {

                            RCPBuilder valClass = (RCPBuilder)ScriptToRCP.ht[ScriptToRCP.keyFragment[i]];

                            string[] saDes = valClass.CmdtoDes.ToString().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                            int idxTemp = richTextBoxAssistor.Text.Length;

                            if (saDes.Length != 0)
                            {
                                richTextBoxAssistor.AppendText(saDes[3].Split(',')[0]);
                                richTextBoxAssistor.AppendText("\r\n");

                                richTextBoxAssistor.Select(idxTemp, richTextBoxAssistor.Text.Length);
                                richTextBoxAssistor.SelectionFont = new Font(richTextBoxAssistor.Font, FontStyle.Bold);
                            }
                            richTextBoxAssistor.AppendText("\r\n");
                        }
                    }
                }
                catch
                {
                }    
            }
        }
    }
}
