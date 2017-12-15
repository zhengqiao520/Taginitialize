using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Phychips.Rcp;
using Phychips.Helper;
using System.IO;


namespace Phychips.PR9200
{
    public partial class ucRegistry : UserControl
    {
        public const byte V001 = 0x01;
        public const byte V004 = 0x04;
        public const byte V005 = 0x05;
        public const byte V006 = 0x06;

        // Common
        public const byte REG_VER = 0x00;

        public byte CUR_REG_ADDR = 0x00;
        
        public Thread RegistryThread;

        private string DataPath;
        private bool m_bRcpReceived = false;

        public const byte PR9200 = 0x00;
        public const byte PRM92x = 0x01;
        public const byte A100 = 0x20;

        public const byte KOREA = 0x11;
        public const byte USA = 0x21;
        public const byte EUROPE = 0x31;
        public const byte JAPAN = 0x41;
        public const byte CHINA = 0x51;
        
        public int curr_main, curr_sub, curr_fix;

        public int RegVer;
        public int ItemSize = 0;

        public bool lvInitFlag = true;
        public int lvParsingIndex = 0;

        public bool source = false;

        public ucRegistry()
        {
            InitializeComponent();
        }

        private void ucRegistry_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            this.DataPath = Application.StartupPath.ToString();            
        }

        private void InitListView(int version)
        {
            lvRegItem.Items.Clear();

            int nCmdCnt = 0;

            try
            {
                StreamReader sr;

                sr = new StreamReader(this.DataPath + string.Format("\\RegistryTypeDef\\registry_type_{0:X03}.txt", version));

                using (sr)
                {
                    string Line;
                    string[] Column;

                    while ((Line = sr.ReadLine()) != null)
                    {                        
                        Column = ParseLineToCommand(Line.ToLower());
                        if (Column.Length == 0) continue;
                        if (Column[0].IndexOf("//") == 0) continue;

                        if (Column.Length < 5)
                        {
                            ListViewItem lvt = new ListViewItem("");
                            lvt.SubItems.Add("");
                            lvt.SubItems.Add("");
                            lvt.SubItems.Add(Column[1]);
                            lvt.SubItems.Add(Column[0]);

                            lvRegItem.Items.Add(lvt);
                        }
                        else
                        {
                            ListViewItem lvt = new ListViewItem(Column[0]);
                            lvt.SubItems.Add(Column[1]);
                            lvt.SubItems.Add(Column[2]);
                            lvt.SubItems.Add(Column[4]);
                            lvt.SubItems.Add(Column[3]);

                            lvRegItem.Items.Add(lvt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("registry_type.txt in Line " + nCmdCnt.ToString() + " : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string[] ParseLineToCommand(string source)
        {
            source = source.Trim();
            return source.Split(new char[] { '\t', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private string[] SplitArray(string source)
        {
            source = source.Trim();
            return source.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private void WaitForReceived()
        {
            for (int j = 0; j < 100; j++)
            {
                System.Threading.Thread.Sleep(10);
                if (m_bRcpReceived) break;
            }
        }

        public void RcpGetRegistry()
        {
            byte[] param = new byte[2];
            int ItemCnt = 0;
            string[] Column;

            CUR_REG_ADDR = 0x00;
            param[0] = 0x00;
            param[1] = CUR_REG_ADDR;
            m_bRcpReceived = false;

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_GET_REGISTRY_ITEM, param))) { }      //  To get Registry Version
            System.Threading.Thread.Sleep(10);
            this.WaitForReceived();
            CUR_REG_ADDR++;

            if (!File.Exists(this.DataPath + string.Format("\\RegistryTypeDef\\registry_type_{0:X03}.txt", RegVer)))
            {
                return;
            }

            StreamReader SR = new StreamReader(this.DataPath + string.Format("\\RegistryTypeDef\\registry_type_{0:X03}.txt", RegVer));

            while (SR.Peek() > -1)
            {
                String ReadLine = SR.ReadLine();
                Column = ParseLineToCommand(ReadLine.ToLower());

                if (Column.Length == 5) ItemCnt++;
                else if (Column.Length == 0) continue;
            }

            ItemSize = ItemCnt;

            for (byte i = 1; i < ItemSize; i++)
            {
                m_bRcpReceived = false;

                param[0] = 0x00;
                param[1] = CUR_REG_ADDR;

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_GET_REGISTRY_ITEM, param))) { }
                System.Threading.Thread.Sleep(10);
                this.WaitForReceived();

                CUR_REG_ADDR++;
            }

            lvInitFlag = true;
            lvParsingIndex = 0;
        }

        private void buttonRegistry_Click(object sender, EventArgs e)
        {
            if (RegistryThread == null || RegistryThread.IsAlive == false)
            {
                RegistryThread = new Thread(new ThreadStart(RcpGetRegistry));
                RegistryThread.Start();                
            }
        }

        private void registry_active(int index, byte active)
        {
            switch (active)
            {
                case 0x00:
                    lvRegItem.Items[index].SubItems[2].Text = "INACTIVE";
                    break;
                case 0xA5:
                    lvRegItem.Items[index].SubItems[2].Text = "ACTIVE";
                    break;
                case 0xBC:
                    lvRegItem.Items[index].SubItems[2].Text = "READONLY";
                    break;
            }
        }

        private void RcpGetRegistryVersion(byte[] Data)
        {
            RegVer = (Data[8] << 8) | Data[7];

            InitListView(RegVer);
            registry_active(REG_VER, Data[5]);

            lvRegItem.Items[REG_VER].SubItems.Add(RegVer.ToString());
            lvRegItem.Items[REG_VER].SubItems.Add(RegVer.ToString("X02"));
        }

        private void buttonEepUpdate_Click(object sender, EventArgs e)
        {
            RegistryUpdate registryUpdate = new RegistryUpdate();            
            registryUpdate.StartPosition = FormStartPosition.CenterScreen;
            registryUpdate.Show();
        }

        private void buttonEepErase_Click(object sender, EventArgs e)
        {
            ByteBuilder bb = new ByteBuilder();

            bb.Append(0xff);

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_ERASE_FLASH, bb.GetByteArray()))) { }
        }

        internal void ParseRsp(byte[] Data)
        {
            int RxPayLoad;
            int RxPayLoadCnt = 0;
            int RxPayLoadCntTemp = 0;
            int Temp = 0;
            int RxPayLoadArraySize = 0;
            int RxPayLoadArrayCycle = 0;

            string DecValue = "";
            string HexValue = "";

            bool DataTypeSwitchFlag = false;

            if (lvInitFlag)
            {
                RcpGetRegistryVersion(Data);
                lvParsingIndex++;
                lvInitFlag = false;
            }
            else
            {
                registry_active(lvParsingIndex, Data[5]);

                if (lvRegItem.Items[lvParsingIndex].SubItems[4].Text == "uint8")
                {
                    RxPayLoad = (Data[3] << 8) + Data[4] - 1;
                }
                else
                {
                    RxPayLoad = (Data[3] << 8) + Data[4] - 3;
                }

                for (RxPayLoadCnt = 0; RxPayLoadCnt < RxPayLoad; )
                {
                    if (lvParsingIndex >= lvRegItem.Items.Count)
                    {
                        m_bRcpReceived = true;
                        return;
                    }

                    switch (lvRegItem.Items[lvParsingIndex].SubItems[4].Text)
                    {
                        case "uint8":

                            if (lvRegItem.Items[lvParsingIndex].SubItems[3].Text.IndexOf("[") < 0)
                            {
                                if (DataTypeSwitchFlag == false)
                                {
                                    lvRegItem.Items[lvParsingIndex].SubItems.Add(Data[6 + RxPayLoadCnt].ToString());
                                    lvRegItem.Items[lvParsingIndex].SubItems.Add(Data[6 + RxPayLoadCnt].ToString("X02"));

                                    lvParsingIndex++;
                                    RxPayLoadCnt++;
                                }
                                else
                                {
                                    lvRegItem.Items[lvParsingIndex].SubItems.Add(Data[7 + RxPayLoadCnt].ToString());
                                    lvRegItem.Items[lvParsingIndex].SubItems.Add(Data[7 + RxPayLoadCnt].ToString("X02"));

                                    lvParsingIndex++;
                                    RxPayLoadCnt++;
                                }                                
                            }
                            else
                            {
                                if (DataTypeSwitchFlag == false)
                                {
                                    if (lvRegItem.Items[lvParsingIndex - 1].SubItems[3].Text == "size")
                                    {
                                        RxPayLoadArraySize = Convert.ToInt16(lvRegItem.Items[lvParsingIndex - 1].SubItems[5].Text);
                                        RxPayLoadArrayCycle = RxPayLoadArraySize;
                                    }
                                    else
                                    {
                                        RxPayLoadArrayCycle = RxPayLoad;
                                    }

                                    RxPayLoadCntTemp = RxPayLoadCnt;

                                    for (int i = RxPayLoadCntTemp; i < RxPayLoadArrayCycle; i++)
                                    {
                                        DecValue += Data[6 + i].ToString() + ", ";
                                        HexValue += Data[6 + i].ToString("X04") + ", ";
                                        RxPayLoadCnt++;
                                    }

                                    lvRegItem.Items[lvParsingIndex].SubItems.Add(DecValue);
                                    lvRegItem.Items[lvParsingIndex].SubItems.Add(HexValue);

                                    lvParsingIndex++;
                                    RxPayLoadCnt = RxPayLoad;
                                    continue;
                                }
                                else
                                {
                                    if (lvRegItem.Items[lvParsingIndex - 1].SubItems[3].Text == "size")
                                    {
                                        RxPayLoadArraySize = Convert.ToInt16(lvRegItem.Items[lvParsingIndex - 1].SubItems[5].Text);
                                        RxPayLoadArrayCycle = RxPayLoadArraySize;
                                    }
                                    else
                                    {
                                        RxPayLoadArrayCycle = RxPayLoad;
                                    }

                                    RxPayLoadCntTemp = RxPayLoadCnt;
                                    for (int i = RxPayLoadCntTemp; i < RxPayLoadArrayCycle; i++)
                                    {
                                        DecValue += Data[7 + i].ToString() + ", ";
                                        HexValue += Data[7 + i].ToString("X04") + ", ";
                                        RxPayLoadCnt++;
                                    }

                                    lvRegItem.Items[lvParsingIndex].SubItems.Add(DecValue);
                                    lvRegItem.Items[lvParsingIndex].SubItems.Add(HexValue);

                                    lvParsingIndex++;
                                    RxPayLoadCnt = RxPayLoad;
                                    continue;
                                }
                            }
                            break;

                        case "uint16":

                            if (lvRegItem.Items[lvParsingIndex].SubItems[3].Text.IndexOf("[") < 0)
                            {

                                Temp = ((Data[8 + RxPayLoadCnt] << 8) + Data[7 + RxPayLoadCnt]);
                                lvRegItem.Items[lvParsingIndex].SubItems.Add(Temp.ToString());
                                lvRegItem.Items[lvParsingIndex].SubItems.Add(Temp.ToString("X04"));

                                lvParsingIndex++;
                                RxPayLoadCnt += 2;

                            }
                            else
                            {
                                if (lvRegItem.Items[lvParsingIndex - 1].SubItems[3].Text == "size")
                                {
                                    RxPayLoadArraySize = Convert.ToInt16(lvRegItem.Items[lvParsingIndex - 1].SubItems[5].Text);
                                    RxPayLoadArrayCycle = RxPayLoadArraySize;
                                }
                                else
                                {
                                    RxPayLoadArrayCycle = RxPayLoad;
                                }

                                RxPayLoadCntTemp = RxPayLoadCnt;

                                for (int i = RxPayLoadCntTemp; i < RxPayLoadArrayCycle; i += 2)
                                {
                                    Temp = (Data[7 + i] << 8) + Data[6 + i];
                                    DecValue += Temp.ToString() + ", ";
                                    HexValue += Temp.ToString("X04") + ", ";
                                    RxPayLoadCnt += 2;
                                }

                                lvRegItem.Items[lvParsingIndex].SubItems.Add(DecValue);
                                lvRegItem.Items[lvParsingIndex].SubItems.Add(HexValue);
                                lvParsingIndex++;

                                RxPayLoadCnt = RxPayLoad;
                                continue;
                            }
                            DataTypeSwitchFlag = true;
                            break;

                        case "int16":

                            if (lvRegItem.Items[lvParsingIndex].SubItems[3].Text.IndexOf("[") < 0)
                            {
                                Temp = (Int16)((Data[8 + RxPayLoadCnt] << 8) + Data[7 + RxPayLoadCnt]);
                                lvRegItem.Items[lvParsingIndex].SubItems.Add(Temp.ToString());
                                lvRegItem.Items[lvParsingIndex].SubItems.Add(Temp.ToString("X04"));

                                lvParsingIndex++;
                                RxPayLoadCnt += 2;
                            }
                            else
                            {
                                if (lvRegItem.Items[lvParsingIndex - 1].SubItems[3].Text == "size")
                                {
                                    RxPayLoadArraySize = Convert.ToInt16(lvRegItem.Items[lvParsingIndex - 1].SubItems[5].Text);
                                    RxPayLoadArrayCycle = RxPayLoadArraySize;
                                }
                                else
                                {
                                    RxPayLoadArrayCycle = RxPayLoad;
                                }

                                RxPayLoadCntTemp = RxPayLoadCnt;

                                for (int i = RxPayLoadCntTemp; i < RxPayLoadArrayCycle; i += 2)
                                {
                                    Temp = (Data[8 + i] << 8) + Data[7 + i];
                                    DecValue += Temp.ToString() + ", ";
                                    HexValue += Temp.ToString("X04") + ", ";
                                    RxPayLoadCnt += 2;
                                }

                                lvRegItem.Items[lvParsingIndex].SubItems.Add(DecValue);
                                lvRegItem.Items[lvParsingIndex].SubItems.Add(HexValue);
                                lvParsingIndex++;

                                RxPayLoadCnt = RxPayLoad;
                                continue;
                            }
                            DataTypeSwitchFlag = true;
                            break;
                    }
                }
            }
            m_bRcpReceived = true;
        }

        public void DecodeSerial()
        {
            if (lvRegItem.Items.Count == 0)
            {
                MessageBox.Show("Get Registry First", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                for (int i = 0; i < lvRegItem.Items.Count; i++)
                {
                    if (lvRegItem.Items[i].SubItems[1].Text.Contains("serial"))
                    {
                        try
                        {
                            string s = lvRegItem.Items[i].SubItems[6].Text;
                            string[] sa = s.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            byte[] ba = new byte[sa.Length];

                            string serial = string.Empty;

                            if (ba.Length != 0)
                            {
                                for (int j = 0; j < ba.Length; j++)
                                {
                                    ba[j] = byte.Parse(sa[j], System.Globalization.NumberStyles.HexNumber);
                                    serial += System.Convert.ToChar(ba[j]);
                                }
                            }

                            MessageBox.Show("Serial Number : " + serial,"Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }
    }
}
