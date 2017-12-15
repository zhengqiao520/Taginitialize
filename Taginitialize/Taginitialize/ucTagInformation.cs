//! Copyright (C) 2007 Phychips
//! 
//! PR9200 DEMO
//!
//! Description
//! 	PR9200 DEMO
//!-------------------------------------------------------------------
//! History
//!-------------------------------------------------------------------
//! 1.0	2007/09/01	Jinsung Yi		Initial Release

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Phychips.Helper;
using Phychips.Rcp;
using System.Threading;
using System.Media;


namespace Phychips.PR9200
{
    public partial class ucTagInformation : UserControl
    {
        private bool m_bRcpReceived = false;
        //private bool m_bTagEpcReadDone = false;

        private int nTagCnt = 0;
        private StringBuilder msgSb = new StringBuilder();
        private int m_nMemBank = 0;
        
        private byte[] m_oReceivedTagMemoryData = null;
        private byte[] m_oTagMemoryReserved = null;
        private byte[] m_oTagMemoryEpc = null;
        private byte[] m_oTagMemoryTid = null;
        private byte[] m_oTagMemoryUser = null;

        public ucTagInformation()
        {
            InitializeComponent();
        }

        private void ucTagInformation_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;           

            this.cbTagRwTarMem.SelectedIndex = 0;
            this.cbTagKillRecomBit.SelectedIndex = 0;

            this.listViewEPC.ContextMenuStrip = contextMenuStripTagList;
            this.listViewTagMemory.ContextMenuStrip = contextMenuStripTagMemory;

            //this.tabControl1.TabPages.Remove(this.tabKillRecom);
            //this.tabControl1.TabPages.Remove(this.tabCustomCommand);
        }

        private void AutoRead()
        {
            byte[] param = new byte[3];

            UInt16 cycle = Convert.ToUInt16(this.textBox_RepeatCycle.Text);
            
            param[0] = 0x22;
            param[1] = (byte)( (cycle & ((UInt16)0xff00)) >> 8);
            param[2] = (byte)(cycle & ((UInt16)0x00FF));
            
            listViewEPC.Items.Clear();
                        
            nTagCnt = 0;
            lbTagCount.Text = nTagCnt.ToString();

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STRT_AUTO_READ, param))) { }
        }

        private void AutoRead2()
        {
            byte[] param = new byte[5];

            UInt16 cycle = 0;
            byte mtnu = 0;
            byte mtime = 0;

            try
            {
                cycle = Convert.ToUInt16(this.textBox_RepeatCycle.Text);
                mtnu = Convert.ToByte(this.textBox_MTNU.Text);
                mtime = Convert.ToByte(this.textBox_MTIME.Text);
            }
            catch
            {
                this.textBox_RepeatCycle.Text = "0";
                this.textBox_MTNU.Text = "0";
                this.textBox_MTIME.Text = "0";
                return;
            }

            param[0] = 0x02; // type C
            param[1] = mtnu; // MTNU
            param[2] = mtime; // MTNU
            param[3] = (byte)((cycle & ((UInt16)0xff00)) >> 8);
            param[4] = (byte)(cycle & ((UInt16)0x00FF));
                        
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STRT_AUTO_READ_EX, param))) { }
        }

        private string CalcTagRssi(byte[] Data)
        {
            double tag_rssi;
            int rssi_i;
            int rssi_q;
            int gain_i;
            int gain_q;
            double rfin_i;
            double rfin_q;
            
            rssi_i = Data[Data.Length - 7];
            rssi_q = Data[Data.Length - 6];
            gain_i = Data[Data.Length - 5];
            gain_q = Data[Data.Length - 4];

            rfin_i = (20 * Math.Log10(rssi_i) - gain_i - 33 - 30);
            rfin_q = (20 * Math.Log10(rssi_q) - gain_q - 33 - 30);

            rfin_i = Math.Pow(10, (rfin_i / 20));
            rfin_q = Math.Pow(10, (rfin_q / 20));

            tag_rssi = Math.Sqrt(Math.Pow(rfin_i, 2) + Math.Pow(rfin_q, 2));
            
            return String.Format("{0:0.0}", 20 * Math.Log10(tag_rssi)); 
         }

        SoundPlayer player = new SoundPlayer("ding.wav");
        private Thread soundThread = null;

        public bool soundOn = true;

        public void PlaySound()
        {
            if (soundOn) player.Play();

            System.Threading.Thread.Sleep(900);
        }

        public void ParseRsp(byte[] Data)
        {
            byte[] buf = Data;
            int len = (buf[3] << 8) + buf[4];
            int cmd_type = (int)buf[2];

            if (len > buf.Length - 5) len = buf.Length;

            if (Data.Length >= 8)
            {
                byte cmd = Data[2];

                switch (cmd)
                {
                    case RcpProtocol.RCP_CMD_READ_C_UII:                        
                        {
                            bool bDisplayed = false;
                            int index;
                            StringBuilder hsb = new StringBuilder();
                            string tag_rssi ="";

                            if ((((Data[5] >> 3) + 1) * 2) + 2 < len)
                            {
                                tag_rssi = CalcTagRssi(Data);
                                len -= 4;
                            }

                            for (int i = 5; i < len + 5; i++)
                            {
                                try
                                {
                                    hsb.Append(buf[i].ToString("X2") + " ");
                                }
                                catch
                                {
                                    break; 
                                }
                            }

                            for (index = 0; index < listViewEPC.Items.Count; index++)
                            {
                                //if ((string)listViewEPC.Items[index].SubItems[1].Text == hsb.ToString())
                                if ((string)listViewEPC.Items[index].SubItems[2].Text == hsb.ToString().Substring(6))
                                {
                                    bDisplayed = true;
                                    break;
                                }
                            }

                            if (!bDisplayed)
                            {
                                nTagCnt++;
                                lbTagCount.Text = nTagCnt.ToString();
                                                             
                                ListViewItem lvt = new ListViewItem(nTagCnt.ToString());
                                lvt.SubItems.Add(hsb.ToString().Substring(0,5));
                                lvt.SubItems.Add(hsb.ToString().Substring(6));
                                lvt.SubItems.Add("1");
                                lvt.SubItems.Add(tag_rssi);
                                lvt.Font = new Font("Courier New", 8);
                                listViewEPC.Items.Add(lvt);                                
                            }
                            else
                            {
                                int bItemCount = int.Parse(listViewEPC.Items[index].SubItems[3].Text) + 1;
                                listViewEPC.Items[index].SubItems[3].Text = bItemCount.ToString();
                                listViewEPC.Items[index].SubItems[4].Text = tag_rssi;
                            }
                        }

                        if (soundThread == null || soundThread.IsAlive == false)
                        {
                            soundThread = new Thread(new ThreadStart(PlaySound));
                            soundThread.Start();
                        }

                        break;
                    case RcpProtocol.RCP_CMD_READ_C_DT:                      
                        {
                            m_oReceivedTagMemoryData = new byte[len];
                            for (int i = 0; i < len; i++)
                            {
                                m_oReceivedTagMemoryData[i] = Data[i + 5];
                            }

                            if (tabControl1.SelectedTab == tabReadWriteErase)
                            {
                                StringBuilder read = new StringBuilder();
                                foreach (byte abyte in m_oReceivedTagMemoryData)
                                {
                                    read.AppendFormat("{0:X02} ", abyte);
                                }
                                this.textBoxRwData.Text = read.ToString();
                            }
                            else if (this.tabControl1.SelectedTab == this.tabTagMemory)
                            {
                                ListViewItem lvt = null;

                                for (int i = 0; i < ( (m_oReceivedTagMemoryData.Length + 15) / 16) ; i++)
                                {
                                    switch (m_nMemBank)
                                    {
                                        case 0:
                                            m_oTagMemoryReserved = (byte[]) m_oReceivedTagMemoryData.Clone();
                                            lvt = new ListViewItem("00 Reserved");
                                            lvt.BackColor = Color.AliceBlue;                                            
                                            break;
                                        case 1:
                                            m_oTagMemoryEpc = (byte[])m_oReceivedTagMemoryData.Clone();
                                            lvt = new ListViewItem("01 EPC");
                                            lvt.BackColor = Color.AntiqueWhite;
                                            break;
                                        case 2:
                                            m_oTagMemoryTid = (byte[])m_oReceivedTagMemoryData.Clone();
                                            lvt = new ListViewItem("10 TID");
                                            lvt.BackColor = Color.Lavender;
                                            break;
                                        case 3:
                                            m_oTagMemoryUser = (byte[])m_oReceivedTagMemoryData.Clone();
                                            lvt = new ListViewItem("11 USER");
                                            lvt.BackColor = Color.Beige;
                                            break;
                                    }

                                    lvt.SubItems.Add((i*8*16).ToString("X04"));

                                    StringBuilder read = new StringBuilder();
                                    StringBuilder sb = new StringBuilder();
                                    System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();

                                    for (int j = i*16; j < i*16 + 16; j++)
                                    {
                                        if (j < m_oReceivedTagMemoryData.Length)
                                        {
                                            read.AppendFormat("{0:X02} ", m_oReceivedTagMemoryData[j]);

                                            if (m_oReceivedTagMemoryData[j] >= 0x20 && m_oReceivedTagMemoryData[j] < 0x7F)
                                            {
                                                char[] chars = new char[1];
                                                d.GetChars(m_oReceivedTagMemoryData, j, 1, chars, 0);
                                                sb.Append(new System.String(chars));
                                            }
                                            else
                                            {
                                                sb.Append(" ");
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                    lvt.SubItems.Add(read.ToString());                                                                      

                                    lvt.SubItems.Add(sb.ToString());                                   

                                    lvt.Font = new Font("Courier New", 8);
                                    this.listViewTagMemory.Items.Add(lvt);
                                }
                            }
                        }
                        break;
                    case RcpProtocol.RCP_CMD_STRT_AUTO_READ:
                    case RcpProtocol.RCP_CMD_STRT_AUTO_READ_EX:
                        if (buf[5] == 0x1F)
                        {
                            this.buttonReadMultiple.Text = " Start ";

                            this.buttonStatus.BackColor = System.Drawing.Color.LimeGreen;

                        }
                        else
                        {
                            this.buttonReadMultiple.Text = " Stop ";

                            this.buttonStatus.BackColor = System.Drawing.Color.Red;
                        }
                        break;
                }

                m_bRcpReceived = true;
            }
        }

        private void buttonStopAutoRead_Click_Obsolete(object sender, EventArgs e)
        {            
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STOP_AUTO_READ, null))) { }
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems.Count == 0) return;

            string target = listViewEPC.SelectedItems[0].SubItems[2].Text;

            if (target.Length == 0) return;
            if (textBoxLockAccessPw.Text.Length == 0) return;
            if (textBoxLockData.Text.Length == 0) return;

            ByteBuilder bb = new ByteBuilder();

            byte[] ap;
            UInt16 uUiiLen;
            byte[] lockdata;

            try
            {
                uUiiLen = (UInt16)(StringHelper.ArgStringHexToByte(target)).Length;
                ap = StringHelper.ArgStringHexToByte(this.textBoxLockAccessPw.Text);
                lockdata = StringHelper.ArgStringBinaryToByte(this.textBoxLockData.Text, PadType.PAD_LEFT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ap == null || lockdata == null) return;
            if (lockdata.Length != 3) return;

            bb.Append(ap);// Access Password
            bb.Append(uUiiLen);
            bb.Append(StringHelper.ArgStringHexToByte(target));
            bb.Append(lockdata);

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_LOCK_C, bb.GetByteArray()))) { }
        }

        private void lockBitCheckedChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (checkBox19.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            if (checkBox18.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            sb.Append(" ");

            if (checkBox17.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            if (checkBox16.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            sb.Append(" ");

            if (checkBox15.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            if (checkBox14.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            sb.Append(" ");

            if (checkBox13.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            if (checkBox12.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            sb.Append(" ");

            if (checkBox11.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            if (checkBox10.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            sb.Append(" ");
            sb.Append(" ");
            sb.Append(" ");
            sb.Append(" ");

            if (checkBox9.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            if (checkBox8.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            sb.Append(" ");

            if (checkBox7.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            if (checkBox6.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            sb.Append(" ");

            if (checkBox5.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            if (checkBox4.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            sb.Append(" ");

            if (checkBox3.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            if (checkBox2.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            sb.Append(" ");

            if (checkBox1.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            if (checkBox0.Checked)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }

            textBoxLockData.Text = sb.ToString();
        }

        private void buttonKill_Click(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems.Count == 0) return;

            string target = listViewEPC.SelectedItems[0].SubItems[2].Text;

            if (target.Length == 0) return;
            if (textBoxLockAccessPw.Text.Length == 0) return;
            if (textBoxKillPw.Text.Length == 0) return;

            ByteBuilder bb = new ByteBuilder();

            UInt16 uUiiLen;
            byte[] Killpw;

            try
            {
                uUiiLen = (UInt16)(StringHelper.ArgStringHexToByte(target)).Length;
                Killpw = StringHelper.ArgStringHexToByte(this.textBoxKillPw.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Killpw == null) return;

            bb.Append(Killpw);// KP
            bb.Append(uUiiLen);
            bb.Append((StringHelper.ArgStringHexToByte(target)));
            
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_KILL_RECOM_C, bb.GetByteArray()))) { }
        }

        private void buttonWriteDataToTag_Click(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems.Count == 0) return;

            string target = listViewEPC.SelectedItems[0].SubItems[2].Text;

            //if (target.Length == 0) return;

            ByteBuilder bb = new ByteBuilder();

            byte[] ap;
            byte uMem;
            UInt16 uUiiLen;
            UInt16 uStartAdd;
            UInt16 uLength;
            UInt16 uDtLen;

            try
            {
                ap = StringHelper.ArgStringHexToByte(this.textBoxRwAccessPw.Text);
                uUiiLen = (UInt16)(StringHelper.ArgStringHexToByte(target)).Length;
                uStartAdd = UInt16.Parse(textBoxRwStartAdd.Text);
                uLength = UInt16.Parse(textBoxRwLength.Text);
                uMem = (byte)cbTagRwTarMem.SelectedIndex;
                uDtLen = (UInt16)(StringHelper.ArgStringHexToByte(textBoxRwData.Text)).Length;
                uDtLen /= 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ap == null) return;

            bb.Append(ap);// AP
            
            bb.Append(uUiiLen); // UL
            if (uUiiLen > 0)
            {
                bb.Append(StringHelper.ArgStringHexToByte(target)); // UII
            }
            bb.Append(uMem); // MB
            bb.Append(uStartAdd); // SA
            bb.Append(uDtLen); // DL            
            bb.Append(StringHelper.ArgStringHexToByte(textBoxRwData.Text)); // DT

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_WRIT_C_DT, bb.GetByteArray()))) { }

            if (uMem == 0x01) this.listViewEPC.Items.Clear();
        }

        private void tsMenuItemClear_Click(object sender, EventArgs e)
        {
            listViewEPC.Items.Clear();
            msgSb.Remove(0, msgSb.Length);
        }

        private void tsMenuItemCopy_Click(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems != null && listViewEPC.SelectedItems.Count != 0) Clipboard.SetText(listViewEPC.SelectedItems[0].SubItems[0].Text + "\t" + listViewEPC.SelectedItems[0].SubItems[1].Text + "\t" + listViewEPC.SelectedItems[0].SubItems[2].Text);
        }

        private void tsMenuItemCopyAll_Click(object sender, EventArgs e)
        {            
            if (msgSb != null && msgSb.Length != 0) Clipboard.SetText(msgSb.ToString());
        }

        private void buttonReadTagMemory_Click(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems.Count == 0) return;

            string target = listViewEPC.SelectedItems[0].SubItems[2].Text;

            //if (target.Length == 0) return;

            UInt16 uUiiLen;
            UInt16 uStartAdd;
            UInt16 uLength;
            byte[] ap;
            byte uMem;

            try
            {
                uUiiLen = (UInt16)(StringHelper.ArgStringHexToByte(target)).Length;
                uStartAdd = UInt16.Parse(textBoxRwStartAdd.Text);
                uLength = UInt16.Parse(textBoxRwLength.Text);
                uMem = (byte)cbTagRwTarMem.SelectedIndex;
                ap = StringHelper.ArgStringHexToByte(textBoxRwAccessPw.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ByteBuilder bb = new ByteBuilder();
            bb.Append(ap); // AP
            bb.Append(uUiiLen); // UL
            if (uUiiLen > 0)
            {
                bb.Append(StringHelper.ArgStringHexToByte(target)); // UII
            }
            bb.Append(uMem); // MB
            bb.Append(uStartAdd); // SA
            bb.Append(uLength); // DL

            m_oReceivedTagMemoryData = null;

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_READ_C_DT, bb.GetByteArray()))) { }
        }

        private void buttonBlockWriteDataToTag_Click(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems.Count == 0) return;

            string target = listViewEPC.SelectedItems[0].SubItems[2].Text;

            //if (target.Length == 0) return;

            ByteBuilder bb = new ByteBuilder();

            byte[] ap;
            byte uMem;
            UInt16 uUiiLen;
            UInt16 uStartAdd;
            UInt16 uLength;
            UInt16 uDtLen;

            try
            {
                ap = StringHelper.ArgStringHexToByte(this.textBoxRwAccessPw.Text);
                uUiiLen = (UInt16)(StringHelper.ArgStringHexToByte(target)).Length;
                uStartAdd = UInt16.Parse(textBoxRwStartAdd.Text);
                uLength = UInt16.Parse(textBoxRwLength.Text);
                uMem = (byte)cbTagRwTarMem.SelectedIndex;
                uDtLen = (UInt16)(StringHelper.ArgStringHexToByte(textBoxRwData.Text)).Length;
                uDtLen /= 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ap == null) return;

            bb.Append(ap);// AP
            bb.Append(uUiiLen); // UL
            if (uUiiLen > 0)
            {
                bb.Append(StringHelper.ArgStringHexToByte(target)); // UII
            }
            bb.Append(uMem); // MB
            bb.Append(uStartAdd); // SA
            bb.Append(uDtLen); // DL            
            bb.Append(StringHelper.ArgStringHexToByte(textBoxRwData.Text)); // DT

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_BLOCKWRITE_C_DT, bb.GetByteArray()))) {}
        }
        
        private void buttonReadMultiple_Click(object sender, EventArgs e)
        {
            if (buttonReadMultiple.Text == " Start ")
            {                
                this.listViewEPC.Items.Clear();
                this.listViewTagMemory.Items.Clear();

                nTagCnt = 0;
                lbTagCount.Text = nTagCnt.ToString();

                AutoRead2();
              
                this.buttonStatus.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                StopAutoRead_Click();
                StopAutoRead();
            }
        }

        public void StopAutoRead()
        {
            buttonReadMultiple.Text = " Start ";

            this.buttonStatus.BackColor = System.Drawing.Color.LimeGreen;
        }

        public void StopAutoRead_Click()
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STOP_AUTO_READ_EX, null))) { }
        }

        private void listViewEPC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems.Count == 0) return;

            listViewEPC.SelectedItems[0].BackColor = System.Drawing.SystemColors.MenuHighlight;
        }

        private void buttonBlockEraseTagMemory_Click(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems.Count == 0) return;

            string target = listViewEPC.SelectedItems[0].SubItems[2].Text;

            if (target.Length == 0) return;

            UInt16 uUiiLen;
            UInt16 uStartAdd;
            UInt16 uLength;
            byte[] ap;
            byte uMem;

            try
            {
                uUiiLen = (UInt16)(StringHelper.ArgStringHexToByte(target)).Length;
                uStartAdd = UInt16.Parse(textBoxRwStartAdd.Text);
                uLength = UInt16.Parse(textBoxRwLength.Text);
                uMem = (byte)cbTagRwTarMem.SelectedIndex;
                ap = StringHelper.ArgStringHexToByte(textBoxRwAccessPw.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ByteBuilder bb = new ByteBuilder();
            bb.Append(ap); // AP
            bb.Append(uUiiLen); // UL
            bb.Append(StringHelper.ArgStringHexToByte(target)); // UII
            bb.Append(uMem); // MB
            bb.Append(uStartAdd); // SA
            bb.Append(uLength); // DL

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_BLOCKERASE_C_DT, bb.GetByteArray()))) { }
        }

        private void copyTagIDToDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems.Count == 0) return;

            string target = listViewEPC.SelectedItems[0].SubItems[2].Text;
            //textBoxTagSel.Text = s.Remove(s.Length - 7);
            textBoxRwData.Text = target;

            this.tabControl1.SelectedTab = this.tabReadWriteErase;
        }

        private byte[] BuildSelectRcpPacket(string target)
        {
            ByteBuilder bb = new ByteBuilder();

            string[] temp = new string[0];

            if(target != null) temp = target.Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);

            byte[] mask = new byte[0];

            if (target != null)
            {
                mask = new byte[temp.Length];

                for (int i = 0; i < mask.Length; i++)
                {
                    mask[i] = Convert.ToByte(temp[i], 16);
                }
            }


            byte[] param = new byte[7];

            param[0] = 0x01;    // Bank : EPC
            param[1] = 0x00;
            param[2] = 0x00;
            param[3] = 0x00;
            param[4] = 0x20;    // Pointer : head of EPC
            param[5] = Convert.ToByte(temp.Length << 3);
            param[6] = 0;

            bb.Append(param);
            
            bb.Append(mask);

            return bb.GetByteArray();
        }

        private void selectThisTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems.Count == 0) return;

            string target = listViewEPC.SelectedItems[0].SubItems[2].Text;
            //textBoxTagSel.Text = s.Remove(s.Length - 7);
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_C_SEL_PARM, BuildSelectRcpPacket(target))))
            {
                return;
            }
            else
            {
                this.labelSelectedTag.Visible = true;
                this.labelSelectedTag.Text = "Selected EPC : " + target;
            }
        }

        private void TagMemoryView()
        {
            UInt16 uUiiLen = 0;
            string target = null;

            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate()
                {
                    try
                    {
                        if (listViewEPC.SelectedItems == null
                            || listViewEPC.SelectedItems.Count == 0) return;

                        target = listViewEPC.SelectedItems[0].SubItems[2].Text;

                        if (target.Length == 0) return;

                        uUiiLen = (UInt16)(StringHelper.ArgStringHexToByte(target)).Length;
                        //ap = StringHelper.ArgStringHexToByte(textBoxRwAccessPw.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }));

            if (target == null)
            {
                MessageBox.Show("Select Target Tag", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            m_oTagMemoryReserved = null;
            m_oTagMemoryEpc = null;
            m_oTagMemoryTid = null;
            m_oTagMemoryUser = null;

            for (m_nMemBank = 0; m_nMemBank < 4; m_nMemBank++)
            {
                ByteBuilder bb = new ByteBuilder();
                bb.Append(new byte[] { 0x00, 0x00, 0x00, 0x00 }); // AP
                bb.Append(uUiiLen); // UL
                bb.Append(StringHelper.ArgStringHexToByte(target)); // UII
                bb.Append((byte)m_nMemBank); // MB
                bb.Append(0); // SA
                bb.Append(0); // SA
                bb.Append(0); // DL
                bb.Append(0); // DL

                m_bRcpReceived = false;
                m_oReceivedTagMemoryData = null;

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_READ_C_DT, bb.GetByteArray()))) { break; }

                for (int j = 0; j < 200; j++)
                {
                    if (m_bRcpReceived) break;
                    System.Threading.Thread.Sleep(10);
                }
            }            
        }

        private Thread newThread = null;
        
        private void viewTagMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.tabTagMemory;
            this.listViewTagMemory.Items.Clear();

            if (newThread == null || newThread.IsAlive == false)
            {
                newThread = new Thread(new ThreadStart(TagMemoryView));
                newThread.Start();
            }
        }

        private byte[] GetTarget()
        {
            byte[] ret = null;

            try
            {
                if (listViewEPC.SelectedItems.Count == 0) return null;

                string target = listViewEPC.SelectedItems[0].SubItems[2].Text;
                ret = StringHelper.ArgStringHexToByte(target);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ret;
        }

        private void toolStripMenuItemTagMoreInformation_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ListViewItem lvTagInfo = this.listViewTagMemory.Items[this.listViewTagMemory.SelectedIndices[0]];

            if (lvTagInfo.SubItems[0].Text == "00 Reserved")
            {
                TagMemoryInfoModifyReserved(lvTagInfo);
            }
            else if (lvTagInfo.SubItems[0].Text == "01 EPC")
            {
                TagMemoryInfoModifyEpc(lvTagInfo);
            }
            else if (lvTagInfo.SubItems[0].Text == "10 TID")
            {
                TagMemoryInfoTid(lvTagInfo);
            }
            else if (lvTagInfo.SubItems[0].Text == "11 USER")
            {
                TagMemoryInfoModifyUser(lvTagInfo);
            }
        }

        private void TagMemoryInfoModifyUser(System.Windows.Forms.ListViewItem lvTagInfo)
        {
            FormTagInfoUser user = new FormTagInfoUser();
            if (lvTagInfo.SubItems[2].Text.Length >= 8 * 2 + 8)
            {
                user.LabelAddress.Text = (lvTagInfo.SubItems[1].Text);
                user.TextBoxUserRd.Text = (lvTagInfo.SubItems[2].Text).TrimEnd(new char[]{' '});
                user.TextBoxUserWrt.Text = (lvTagInfo.SubItems[2].Text).TrimEnd(new char[]{' '});
            }
            else
            {
                return;
            }

            if (GetTarget() == null)
            {
                MessageBox.Show("Select Target Tag", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;
            }

            user.ShowDialog();
            if (user.UserData != null)
            {
                ByteBuilder bb = new ByteBuilder();

                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append((UInt16)GetTarget().Length); // UL
                bb.Append(GetTarget()); // UII
                bb.Append(3); // MB
                bb.Append(user.UserDataAddress[0]); // SA
                bb.Append(user.UserDataAddress[1]); // SA
                bb.Append(0); // DL
                bb.Append((byte) (user.UserData.Length/2) ); // DL                    
                bb.Append(user.UserData); // DT

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_WRIT_C_DT, bb.GetByteArray()))) { }
                else
                {
                    viewTagMemoryToolStripMenuItem_Click(null, null);
                }
            }            
        }

        private void TagMemoryInfoTid(System.Windows.Forms.ListViewItem lvTagInfo)
        {
            if ( (m_oTagMemoryTid.Length >= 3) &&
                (m_oTagMemoryTid[0] == 0xE0) )
            {
                FormTagInfoTid7816 tid = new FormTagInfoTid7816();

                byte[] arrayAc = new byte[1];
                byte[] arrayMfgCode = new byte[1];
                byte[] arraySn = new byte[m_oTagMemoryTid.Length - 2];
                Array.Copy(m_oTagMemoryTid, 0, arrayAc, 0, arrayAc.Length);
                Array.Copy(m_oTagMemoryTid, 1, arrayMfgCode, 0, arrayMfgCode.Length);
                Array.Copy(m_oTagMemoryTid, 2, arraySn, 0, arraySn.Length);
                tid.TextBoxAc.Text = StringHelper.ArgByteToStringByte(arrayAc);
                tid.TextBoxMfgCode.Text = StringHelper.ArgByteToStringByte(arrayMfgCode);
                tid.TextBoxSn.Text = StringHelper.ArgByteToStringByte(arraySn);
                tid.SetMfg();               
                
                tid.ShowDialog();
            }
            else if ((m_oTagMemoryTid.Length >= 4) &&
                     (m_oTagMemoryTid[0] == 0xE2))
            {                
                FormTagInfoTidEpc tid = new FormTagInfoTidEpc();

                tid.TextBoxAc.Text = m_oTagMemoryTid[0].ToString("X02");
                tid.TextBoxXtid.Text = ((byte)(m_oTagMemoryTid[1] & 0x80) >> 7).ToString("X01");
                tid.TextBoxMdidCode.Text = ((UInt16)(((UInt16)(m_oTagMemoryTid[1] & 0x7F) << 4) | ((UInt16)(m_oTagMemoryTid[2] & 0xF0) >> 4))).ToString("X03");
                tid.TextBoxModelNumberCode.Text = ((UInt16)(((UInt16)(m_oTagMemoryTid[2] & 0x0F) << 8) | ((UInt16)m_oTagMemoryTid[3]))).ToString("X03");
                tid.SetMdidModel();

                if (tid.TextBoxXtid.Text == "1" && m_oTagMemoryTid.Length > 25)
                {
                    tid.TextBoxXtidHeader.Text = m_oTagMemoryTid[4].ToString("0X02") + " " + m_oTagMemoryTid[5].ToString("0X02");
                    tid.TextBoxSn.Text = m_oTagMemoryTid[6].ToString("0X02") + " "
                                         + m_oTagMemoryTid[7].ToString("0X02") + " "
                                         + m_oTagMemoryTid[8].ToString("0X02") + " "
                                         + m_oTagMemoryTid[9].ToString("0X02") + " "
                                         + m_oTagMemoryTid[10].ToString("0X02") + " "
                                         + m_oTagMemoryTid[11].ToString("0X02");

                    tid.TextBoxOptionalCmd.Text = m_oTagMemoryTid[12].ToString("0X02") + " "
                                                + m_oTagMemoryTid[13].ToString("0X02");

                    tid.TextBoxBlockWrtErase.Text = m_oTagMemoryTid[14].ToString("0X02") + " "
                                                + m_oTagMemoryTid[15].ToString("0X02") + " "
                                                + m_oTagMemoryTid[16].ToString("0X02") + " "
                                                + m_oTagMemoryTid[17].ToString("0X02") + " "
                                                + m_oTagMemoryTid[18].ToString("0X02") + " "
                                                + m_oTagMemoryTid[19].ToString("0X02") + " "
                                                + m_oTagMemoryTid[20].ToString("0X02") + " "
                                                + m_oTagMemoryTid[21].ToString("0X02");
                    tid.TextBoxBlockPermalock.Text = m_oTagMemoryTid[22].ToString("0X02") + " "
                                                + m_oTagMemoryTid[23].ToString("0X02") + " "
                                                + m_oTagMemoryTid[24].ToString("0X02") + " "
                                                + m_oTagMemoryTid[25].ToString("0X02");
                }
                tid.ShowDialog();
            }            
            else
            {
                return;
            }            
        }

        private void TagMemoryInfoModifyEpc(System.Windows.Forms.ListViewItem lvTagInfo)
        {
            FormTagInfoEpc epc = new FormTagInfoEpc();            
            if(m_oTagMemoryEpc.Length >= 6)
            {
                byte[] arrayCrc = new byte[2];
                byte[] arrayPc = new byte[2];
                byte[] arrayEpc = new byte[m_oTagMemoryEpc.Length - 4];
                Array.Copy(m_oTagMemoryEpc, 0, arrayCrc, 0, arrayCrc.Length);
                Array.Copy(m_oTagMemoryEpc, 2, arrayPc, 0, arrayPc.Length);
                Array.Copy(m_oTagMemoryEpc, 4, arrayEpc, 0, arrayEpc.Length);                
                epc.TextBoxCrcRd.Text = StringHelper.ArgByteToStringByte(arrayCrc);
                epc.TextBoxPcRd.Text = StringHelper.ArgByteToStringByte(arrayPc);
                epc.TextBoxEpcRd.Text = StringHelper.ArgByteToStringByte(arrayEpc).TrimEnd(new char[] { ' ' });
                epc.TextBoxEpcWrt.Text = StringHelper.ArgByteToStringByte(arrayEpc).TrimEnd(new char[] { ' ' });
            }
            else
            {
                return;
            }

            epc.ShowDialog();
            if (epc.Epc != null)
            {
                if (GetTarget() == null)
                {
                    MessageBox.Show("Select Target Tag", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UInt16 pc;
                ByteBuilder bb = new ByteBuilder();

                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append(00);// AP                
                bb.Append((UInt16)GetTarget().Length); // UL
                bb.Append(GetTarget()); // UII
                bb.Append(1); // MB
                bb.Append(0); // SA
                bb.Append(1); // SA
                bb.Append(0); // DL
                bb.Append((byte) ((epc.Epc.Length + 2) /2) ); // DL
                pc = (UInt16)((m_oTagMemoryEpc[2] << 8) | m_oTagMemoryEpc[3]);
                pc = (UInt16)((pc & 0x07FF) | ((epc.Epc.Length / 2) << 11));                
                bb.Append((UInt16)pc);  // PC
                bb.Append(epc.Epc); // DT

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_WRIT_C_DT, bb.GetByteArray()))) { }
                else
                {
                    this.listViewEPC.Items.Clear();

                    byte[] param = new byte[5];
                    param[0] = 0x02; // type C
                    param[1] = 1; // MTNU
                    param[2] = 1; // MTIME
                    param[3] = 0; // cycle
                    param[4] = 0; // cycle

                    if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STRT_AUTO_READ_EX, param))) { }                    
                }
            }
        }

        private void TagMemoryInfoModifyReserved(System.Windows.Forms.ListViewItem lvTagInfo)
        {
            FormTagInfoReserved reserved = new FormTagInfoReserved();
            if (m_oTagMemoryReserved.Length >= 8)          
            {
                byte[] arrayKillPw = new byte[4];
                byte[] arrayAccessPw = new byte[4];

                Array.Copy(m_oTagMemoryReserved, 0, arrayKillPw, 0, arrayKillPw.Length);
                Array.Copy(m_oTagMemoryReserved, 4, arrayAccessPw, 0, arrayAccessPw.Length);

                reserved.TextBoxKillPwRd.Text = StringHelper.ArgByteToStringByte(arrayKillPw).TrimEnd(new char[] { ' ' });
                reserved.TextBoxKillPwWrt.Text = StringHelper.ArgByteToStringByte(arrayKillPw).TrimEnd(new char[] { ' ' });

                reserved.TextBoxAccessPwRd.Text = StringHelper.ArgByteToStringByte(arrayAccessPw).TrimEnd(new char[] { ' ' });
                reserved.TextBoxAccessPwWrt.Text = StringHelper.ArgByteToStringByte(arrayAccessPw).TrimEnd(new char[] { ' ' });
            }
            else
            {
                return;
            }

            reserved.ShowDialog();
            if (reserved.KillPwWrt != null)
            {
                ByteBuilder bb = new ByteBuilder();

                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append((UInt16)GetTarget().Length); // UL
                bb.Append(GetTarget()); // UII
                bb.Append(0); // MB
                bb.Append(0); // SA
                bb.Append(0); // SA
                bb.Append(0); // DL
                bb.Append(2); // DL                    
                bb.Append(reserved.KillPwWrt); // DT

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_WRIT_C_DT, bb.GetByteArray()))) { }
                else
                {
                    viewTagMemoryToolStripMenuItem_Click(null, null);
                }
            }
            if (reserved.AccessPwWrt != null)
            {
                ByteBuilder bb = new ByteBuilder();

                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append((UInt16)GetTarget().Length); // UL
                bb.Append(GetTarget()); // UII
                bb.Append(0); // MB
                bb.Append(0); // SA
                bb.Append(2); // SA
                bb.Append(0); // DL
                bb.Append(2); // DL                    
                bb.Append(reserved.AccessPwWrt); // DT

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_WRIT_C_DT, bb.GetByteArray()))) { }
                else
                {
                    viewTagMemoryToolStripMenuItem_Click(null, null);
                }
            }
        }

        public void A100Configuration(bool enable)
        {
            if (enable)
                this.checkBoxBeepOnOff.Visible = true;
            else
                this.checkBoxBeepOnOff.Visible = false;
        }

        private void buttonNxpReadProtect_Click(object sender, EventArgs e)
        {
            if (GetTarget() == null)
            {
                MessageBox.Show("Select Target Tag", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBoxNxpAccessPw.Text.Length == 0) return;

            try
            {
                byte[] ap = StringHelper.ArgStringHexToByte(textBoxNxpAccessPw.Text);
                UInt16 uUiiLen = (UInt16)GetTarget().Length;

                ByteBuilder bb = new ByteBuilder();
                bb.Append(ap); // AP
                bb.Append(uUiiLen); // UL
                bb.Append(GetTarget()); // UII

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_NXP_READPROTECT, bb.GetByteArray()))) { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonNxpResetReadProtect_Click(object sender, EventArgs e)
        {
            if (textBoxNxpAccessPw.Text.Length == 0) return;

            try
            {
                byte[] ap = StringHelper.ArgStringHexToByte(textBoxNxpAccessPw.Text);

                ByteBuilder bb = new ByteBuilder();
                bb.Append(ap); // AP

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_NXP_RESET_READPROTECT, bb.GetByteArray()))) { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void buttonNxpChangeEAS_Click(object sender, EventArgs e)
        {
            if (GetTarget() == null)
            {
                MessageBox.Show("Select Target Tag", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBoxNxpAccessPw.Text.Length == 0) return;

            try
            {
                byte[] ap = StringHelper.ArgStringHexToByte(textBoxNxpAccessPw.Text);
                UInt16 uUiiLen = (UInt16)GetTarget().Length;
                byte change = (byte)comboBoxNxpChangeEAS.SelectedIndex;

                ByteBuilder bb = new ByteBuilder();
                bb.Append(ap); // AP
                bb.Append(uUiiLen); // UL
                bb.Append(GetTarget()); // UII
                bb.Append(change); // ChangeEAS bit

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_NXP_CHANGE_EAS, bb.GetByteArray()))) { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void buttonNxpEasAlarm_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_NXP_EAS_ALARM, null))) { }
        }

        private void buttonNxpCalibrate_Click(object sender, EventArgs e)
        {
            if (GetTarget() == null)
            {
                MessageBox.Show("Select Target Tag", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBoxNxpAccessPw.Text.Length == 0) return;

            try
            {
                byte[] ap = StringHelper.ArgStringHexToByte(textBoxNxpAccessPw.Text);
                UInt16 uUiiLen = (UInt16)GetTarget().Length;

                ByteBuilder bb = new ByteBuilder();
                bb.Append(ap); // AP
                bb.Append(uUiiLen); // UL
                bb.Append(GetTarget()); // UII

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_NXP_CALIBRATE, bb.GetByteArray()))) { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void buttonClearScreen_Click(object sender, EventArgs e)
        {
            this.listViewEPC.Items.Clear();

            if (this.labelSelectedTag.Visible)
            {
                this.labelSelectedTag.Visible = false;

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_C_SEL_PARM, BuildSelectRcpPacket(null)))) { return; }
            }
        }

        public void VisibleAdvanced()
        {
            this.listViewEPC.Width = 577;
            this.listViewEPC.Columns[2].Width = 350;
            /*
            this.tabControl1.TabPages.Add(this.tabKillRecom);
            this.tabControl1.TabPages.Add(this.tabCustomCommand);
            */
            this.groupBox2.Visible = true;

            this.tabControl1.Refresh();
        }

        public void InvisibleAdvanced()
        {
            this.listViewEPC.Width = 577;
            this.listViewEPC.Columns[2].Width = 350;

            /*
            this.tabControl1.TabPages.Remove(this.tabKillRecom);
            this.tabControl1.TabPages.Remove(this.tabCustomCommand);
            */
            this.groupBox2.Visible = true;

            this.tabControl1.Refresh();
        }
        
        private void textBox_MouseLeave(object sender, EventArgs e)
        {
            this.toolTip_Information.Active = false;
        }

        private void textBox_MTNU_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip_Information.AutomaticDelay = 0;
            this.toolTip_Information.AutoPopDelay = 3000;
            this.toolTip_Information.InitialDelay = 300;
            this.toolTip_Information.ReshowDelay = 0;

            this.toolTip_Information.Active = true;
            this.toolTip_Information.Show("0 to 100", this.textBox_MTNU, 50, -10);
        }

        private void textBox_MTIME_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip_Information.AutomaticDelay = 0;
            this.toolTip_Information.AutoPopDelay = 3000;
            this.toolTip_Information.InitialDelay = 300;
            this.toolTip_Information.ReshowDelay = 0;

            this.toolTip_Information.Active = true;
            this.toolTip_Information.Show("0 to 250", this.textBox_MTIME, 50, -10);
        }

        private void textBox_RepeatCycle_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip_Information.AutomaticDelay = 0;
            this.toolTip_Information.AutoPopDelay = 3000;
            this.toolTip_Information.InitialDelay = 300;
            this.toolTip_Information.ReshowDelay = 0;

            this.toolTip_Information.Active = true;
            this.toolTip_Information.Show("0 to 65500", this.textBox_RepeatCycle, 50, -10);
        }

        private void checkBoxBeepOnOff_CheckedChanged(object sender, EventArgs e)
        {
            byte[] status = new byte[1];

            if (this.checkBoxBeepOnOff.Checked)
            {
                this.checkBoxBeepOnOff.Text = "Beep on";

                status[0] = 0x01;
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_BEEP_ONOFF, status))) { }
            }
            else
            {
                this.checkBoxBeepOnOff.Text = "Beep off";

                status[0] = 0x00;
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_BEEP_ONOFF, status))) { }
            }
        }

        private void buttonPermalock_Click(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems.Count == 0) return;

            string target = listViewEPC.SelectedItems[0].SubItems[2].Text;

            //if (target.Length == 0) return;

            ByteBuilder bb = new ByteBuilder();

            int discard;

            byte[] ap;
            byte[] mask;
            byte RFU;
            byte ReadLock;
            byte uMemBank;
            byte BlockRange;
            UInt16 uUiiLen;
            UInt16 uStartAdd;

            try
            {
                ap = StringHelper.ArgStringHexToByte(this.textBoxLockAccessPw.Text);
                uUiiLen = (UInt16)(StringHelper.ArgStringHexToByte(target)).Length;
                RFU = 0x00;
                ReadLock = (byte)comboBox_BlockPermalockReadLock.SelectedIndex;
                uMemBank = (byte)comboBox_BlockPermalockMemBank.SelectedIndex;
                uStartAdd = UInt16.Parse(textBox_BlockPermalockBlockPtr.Text);
                BlockRange = byte.Parse(textBox_BlockPermalockBlockRange.Text);
                mask = HexEncoding.GetBytes(textBox_BlockPermalockMask.Text, out discard);
                Array.Resize(ref mask, ((BlockRange * 16) / 8));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ap == null) return;

            bb.Append(ap);// AP
            bb.Append(uUiiLen); // UL
            if (uUiiLen > 0)
            {
                bb.Append(StringHelper.ArgStringHexToByte(target)); // UII
            }
            bb.Append(RFU);
            bb.Append(ReadLock);
            bb.Append(uMemBank); // MB
            bb.Append(uStartAdd); // SA
            bb.Append(BlockRange);

            if (mask.Length > 0)
                bb.Append(mask);

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_PERMALOCK_C, bb.GetByteArray()))) { }
        }
    }
}
