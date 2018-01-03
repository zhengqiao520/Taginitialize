using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using Infrastructure;
using Infrastructure.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace RFIDStation
{
    public partial class ISO15693 : DevExpress.XtraEditors.XtraForm
    {
        

        private int serialDevice;                   //串口设备
        public static Thread receiveFrameThread = null;
        public bool bOperatingSerial;
        public delegate void Delegate(object obj);
        public Form fatherForm;
        public FileStream opTagLogFile;
        public StreamWriter opTagLogFileWrite;
        private int opTagTimers = 0;
        private int directOpTagMode = 0;
        //定时器
        private System.Windows.Forms.Timer autoTiggerTimer = new System.Windows.Forms.Timer();

        private void clearOpResult()
        { 
            this.radioButtonOpISO15693TagRltOpOK.Checked = false;
            this.radioButtonOpISO15693TagRltOpFail.Checked = false;

            this.radioButtonOpISO15693ErrTypeOK.Checked = false;
            this.radioButtonOpISO15693ErrTypeCrc.Checked = false;
            this.radioButtonOpISO15693ErrTypeTag.Checked = false;
            this.radioButtonOpISO15693ErrTypeRsp.Checked = false;

            this.textBoxOpISO15693TagRltSrcAddr.Text = "";
            this.textBoxOpISO15693TagRltDestAddr.Text = "";

            //this.labelUserTimer.Text = "0ms";
        }

        private void DisplayOpResult(ref HFREADER_OPRESULT pResult)
        {
            this.textBoxOpISO15693TagRltSrcAddr.Text = pResult.srcAddr.ToString("X").PadLeft(4, '0');
            this.textBoxOpISO15693TagRltDestAddr.Text = pResult.targetAddr.ToString("X").PadLeft(4, '0');
            if (pResult.flag == 0)
            {
                this.radioButtonOpISO15693TagRltOpOK.Checked = true;
                this.radioButtonOpISO15693ErrTypeOK.Checked = true;
            }
            else
            {
                this.radioButtonOpISO15693TagRltOpFail.Checked = true;
                if (pResult.errType == 0x01)
                {
                    this.radioButtonOpISO15693ErrTypeTag.Checked = true;
                }
                else if (pResult.errType == 0x02)
                {
                    this.radioButtonOpISO15693ErrTypeCrc.Checked = true;
                }
                else if (pResult.errType == 0x03)
                {
                    this.radioButtonOpISO15693ErrTypeRsp.Checked = true;
                }
                else if (pResult.errType == 0x04)
                {
                    this.radioButtonOpISO15693ErrTypeParam.Checked = true;
                }
                else
                {
                    this.radioButtonOpISO15693ErrTypeRsp.Checked = true;
                }
            }
            //this.labelUserTimer.Text = pResult.t.ToString("D") + "ms";
        }


        private void ISO15693_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisableIso15693();
            Dispose();
            Close();
            fatherForm.Close();
        }

        public ISO15693(bool readerStatus)
        {
            InitializeComponent();
            serialDevice = -1;
            bOperatingSerial = false;

            DateTime date=TagInfoDAL.GetMysqlSeverDateTime();
           //var res= TagInfoDAL.InsertBookEntity(new BookEntity {
           //      rfidCode="110",
           //       isbnNo="112",
           //        createTime= date,
           //        status=1
           // });
            this.textBoxWMBlockData.Text = "01020304\r\n01020304";

            if (readerStatus)
            {
                autoTiggerTimer.Enabled = true;
                autoTiggerTimer.Interval = 1000;
                autoTiggerTimer.Tick += AutoTiggerTimer_Tick;
            }
        }


        private void AutoTiggerTimer_Tick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtISBN.Text)&& autoTiggerTimer.Enabled)
            {
                buttonReadTags_Click(null, null);
            }
        }

        #region 标签操作
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTagID.Text = txtISBN.Text = "";
            txtISBNHidden.Text = "";
            txtISBN.Focus();
            txtISBNHidden.Focus();
            lueBookInfo.Properties.DataSource = null;
            this.barCodeISBN2.Text = null;
        }
        private void txtISBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && txtISBN.Text.Length > 12)
            {
                //SaveISBN();
                SelectSetBookInfo(txtISBN.Text.Trim());
            }
            if (txtISBN.Text.Length > 18) {
                MessageBox.Show("ISBN长度超出范围，请检查数据准确性", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnClear_Click(null, null);
            }

            txtISBN.Focus();
            txtISBNHidden.Focus();
        }
        /*查询设置书籍信息*/
        private void SelectSetBookInfo(string isbn)
        {
            bool isMulitiBook = true;
            List<BookInfo> listBookInfo = TagInfoDAL.SelectBookInfoListBy(isbn, isVagueQuery: isMulitiBook);
            if (null != listBookInfo)
            {
                radioBookType.SelectedIndex = listBookInfo.Count > 1 ? 1 : 0;
                lueBookInfo.Properties.DataSource = null;
                lueBookInfo.Properties.DataSource = listBookInfo;
                lueBookInfo.Properties.DisplayMember = "book_name";
                lueBookInfo.Properties.ValueMember = "isbn_no";
                lueBookInfo.ItemIndex = 0;
                return;
            }
            MessageBox.Show("根据ISBN未检测到图书基本信息，无法建档！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            btnClear_Click(null, null);
        }
        private async void SaveISBN()
        {
            var tagID = txtTagID.Text.Trim();
            var isbn = txtISBN.Text.Trim();
            if (isbn.Length > 20)
            {
                MessageBox.Show("ISBN编号格式不正确,请重新扫描录入！", "系统提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtISBN.Text = null;
                return;
            }
            if (string.IsNullOrEmpty(tagID) || string.IsNullOrEmpty(isbn))
            {
                MessageBox.Show("TagID或ISBN编号不能为空！","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            WriteNFCBlock(txtISBN.Text.Trim());
            var tagInfo = TagInfoDAL.SelectBookInitMapping(tagID);
            if (tagInfo == null)
            {
                var listBookInfo = lueBookInfo.Properties.DataSource as List<BookInfo>;
                if (listBookInfo == null) {
                     MessageBox.Show("图书信息不存在，无法入库请完善图书信息！", "系统提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                int serializCount = listBookInfo.Count;
                /*1单本isbn图书 2多本isbn丛书系列*/
                int isbnType = serializCount > 1 ? 1 : 2;
                isbn = serializCount > 1 ? lueBookInfo.EditValue.ToString() : isbn;
                bool isMulitiBooks = serializCount > 1;
                var insertResult = TagInfoDAL.InsertBookInitMapping(new Book_init_mapping
                {
                    tag_id = tagID,
                    isbn = isbn,
                    create_time = DateTime.Now,
                    status = (int)InitStatusEnum.RecordInit,
                    tag_type = (int)TagTypeEnum.HighFrequency,
                    account = UserInfo.Instance.user_account,
                    isbn_type = isbnType,
                    isbn_sequence = 1
                });
                toolStripTagSyncStatus.Text = $"{tagID}同步成功!";
                btnClear_Click(null, null);
            }
            else
            {
                if (MessageBox.Show("RFID标签ID已存在,是否更新图书ISBN号？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bool updateResult = TagInfoDAL.UpdateBookInitMapping(isbn, tagID);
                    toolStripTagSyncStatus.Text = $"记录已存在！更新标签：{tagID}对应的ISBN!";
                    btnClear_Click(null, null);
                }
            }
            BindTagList();
            first_char = null;
        }
        private void BindTagList()
        {
            var listTagInfo = TagInfoDAL.GetBookInitMappingExt(tagType:0);
            grdRecordList.DataSource = listTagInfo;
        }

        private void ISO15693_Load(object sender, EventArgs e)
        {
            var evn = ConnectInit.IsUATDataBase ? "【测试环境】" : "【生产环境】";
            Text = Text + $" 当前登录为：{evn}";
            txtISBN.Focus();
            txtISBNHidden.Focus();
            BindTagList();
            //btnSave.Enabled = !chkAutoSave.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveISBN();
            }
            catch(Exception ee) {
                MessageBox.Show("系统异常" + ee.Message, "系统提示");
            }
        }

        private void chkAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            //btnSave.Enabled = !chkAutoSave.Checked;
        }

        #endregion


        public void EnableIso15693(int h)
        {
            serialDevice = h;

            this.tabControlISO15693TagOp.Enabled = true;
            receiveFrameThread = new Thread(new ThreadStart(ReceiveFrame));
            receiveFrameThread.IsBackground = true;
            receiveFrameThread.Start();  
        }

        public void DisableIso15693()
        {
            if (receiveFrameThread != null)
            {
                receiveFrameThread.Abort();
            }
            this.tabControlISO15693TagOp.Enabled = false;
            serialDevice = -1;
        }

        private void AddDisplayInfo(object obj)
        {
            if (this.textBoxInf.InvokeRequired)
            {
                Delegate d = new Delegate(AddDisplayInfo);
                this.textBoxInf.Invoke(d, obj);

            }
            else
            {
                this.textBoxInf.Text = obj.ToString();
            }
        }

        private void AddOpTagInfo(object obj)
        {
            if (this.textBoxInf.InvokeRequired)
            {
                Delegate d = new Delegate(AddOpTagInfo);
                this.textBoxOpTagInfo.Invoke(d, obj);

            }
            else
            {
                this.textBoxOpTagInfo.Text = obj.ToString();
            }
        }

        private void AddActiveSendUID(object obj)
        {
            if (this.listBoxTagIn.InvokeRequired)
            {
                Delegate d = new Delegate(AddActiveSendUID);
                this.listBoxTagIn.Invoke(d, obj);

            }
            else
            {
                //this.listBoxTagIn.Text = obj.ToString();
                String uid;
                int index = 0;
                uid = obj.ToString();
                index = listBoxTagIn.FindString(uid);
                if (index < 0)
                {
                    int count = 0;
                    listBoxTagIn.Items.Add(uid);
                    count = listBoxTagIn.Items.Count;
                    this.textBoxTagInNum.Text = count.ToString("X").PadLeft(2, '0');
                }

            }
        }

        private void AddActiveSendEAS(object obj)
        {
            if (this.listBoxEasAlarm.InvokeRequired)
            {
                Delegate d = new Delegate(AddActiveSendEAS);
                this.listBoxEasAlarm.Invoke(d, obj);

            }
            else
            {
                //this.listBoxTagIn.Text = obj.ToString();
                String uid;
                int index = 0;
                uid = obj.ToString();
                index = listBoxEasAlarm.FindString(uid);
                if (index < 0)
                {
                    int count = 0;
                    listBoxEasAlarm.Items.Add(uid);
                    count = listBoxEasAlarm.Items.Count;
                    this.textBoxEasNum.Text = count.ToString("X").PadLeft(2, '0');
                }

            }
        }

        public void DisplaySendInf(Byte[] pSendBuf, String cmdNmae)
        {
            String text = this.textBoxInf.Text;
            int i = 0;
            int len = pSendBuf[2] + 3;
            String s = cmdNmae;
            for (i = 0; i < len; i++)
            {
                s += pSendBuf[i].ToString("X").PadLeft(2, '0');
                s += " ";
            }
            s += "\r\n";
            AddDisplayInfo(s + text);
        }

        public void DisplayRcvInf(Byte[] pRcvBuf, String cmdNmae)
        {
            String text = this.textBoxInf.Text;
            int i = 0;
            int len = pRcvBuf[2] + 3;
            String s = cmdNmae;
            if (pRcvBuf[2] > 0)
            {
                for (i = 0; i < len; i++)
                {
                    s += pRcvBuf[i].ToString("X").PadLeft(2, '0');
                    s += " ";
                }
            }

            s += "\r\n\r\n";
            AddDisplayInfo(s + text);
        }

        private void ReceiveFrame()
        {
            HFREADER_ACTIVEFRAME pActiveFrame = new HFREADER_ACTIVEFRAME();
            pActiveFrame.uid = new Byte[hfReaderDll.HFREADER_BUFFER_MAX * hfReaderDll.HFREADER_FRAME_MAX_NUM];
            pActiveFrame.frame = new Byte[hfReaderDll.HFREADER_BUFFER_MAX * hfReaderDll.HFREADER_FRAME_MAX_NUM];

            while (true)
            {
                if (serialDevice > 0 && (!bOperatingSerial))
                {
                    
                    //直接操作帧
                    if (directOpTagMode > 0)
                    {
                        Byte[] txFrame = new Byte[4096];
                        Byte[] rxFrame = new Byte[4096];
                        Byte[] uid = new Byte[4096];
                        Byte[] block = new Byte[4096];
                        Byte[] addr = new Byte[4];
                        int uidNum = 0;
                        int blockNum = 0;
                        String sUid = "", sBlock = "", sList = "", sInfo = "" ;
                        Stopwatch sw = new Stopwatch();

                        opTagTimers++;

                        sw.Start();
                        //只需要读取UID
                        if (directOpTagMode == 1)
                        {
                            int rlt = hfReaderDll.iso15693OpTagsRUidAndBlock(serialDevice, 0x0000, 0x0001, addr, 0, uid, block, txFrame, rxFrame);
                            if (rlt > 0)
                            {
                                uidNum = rlt / hfReaderDll.HFREADER_ISO15693_SIZE_UID;
                            }
                        }
                        //读取UID和数据块
                        else if (directOpTagMode == 2)
                        {
                            
                            Byte[] num = new Byte[1];
                            Byte[] blockAddr = new Byte[4];

                            if (GetHexInput(this.textBoxOpTagRBlockAddr1.Text, addr, 1) <= 0)
                            {
                                return;
                            }
                            blockAddr[0] = addr[0];

                            if (GetHexInput(this.textBoxOpTagRBlockAddr2.Text, addr, 1) <= 0)
                            {
                                return;
                            }
                            blockAddr[1] = addr[0];

                            if (GetHexInput(this.textBoxOpTagRBlockAddr3.Text, addr, 1) <= 0)
                            {
                                return;
                            }
                            blockAddr[2] = addr[0];

                            if (GetHexInput(this.textBoxOpTagRBlockAddr4.Text, addr, 1) <= 0)
                            {
                                return;
                            }
                            blockAddr[3] = addr[0];

                            if (GetHexInput(this.textBoxOpTagRBlockNum.Text, num, 1) <= 0)
                            {
                                return;
                            }
                            if (num[0] > 4)
                            {
                                num[0] = 4;
                                textBoxOpTagRBlockNum.Text = num[0].ToString("X").PadLeft(2, '0');
                            }

                            int rlt = hfReaderDll.iso15693OpTagsRUidAndBlock(serialDevice, 0x0000, 0x0001, blockAddr, num[0], uid, block, txFrame, rxFrame);
                            if (rlt > 0)
                            {
                                uidNum = rlt / hfReaderDll.HFREADER_ISO15693_SIZE_UID;
                                blockNum = num[0];
                            }
                        }
                        sw.Stop();
                        //sw.Elapsed.TotalMilliseconds;
                        int i = 0, j = 0;
                        for (i = 0; i < uidNum; i++)
                        {
                            sUid = "";
                            sBlock = "";
                            for (j = 0; j < hfReaderDll.HFREADER_ISO15693_SIZE_UID; j++)
                            {
                                sUid += uid[i * hfReaderDll.HFREADER_ISO15693_SIZE_UID + hfReaderDll.HFREADER_ISO15693_SIZE_UID - 1 - j].ToString("X").PadLeft(2, '0');
                            }
                            for (j = 0; j < hfReaderDll.HFREADER_ISO15693_SIZE_BLOCK * blockNum; j++)
                            {
                                sBlock += block[i * hfReaderDll.HFREADER_ISO15693_SIZE_BLOCK * blockNum + j].ToString("X").PadLeft(2, '0');
                            }
                            sList += i.ToString("D").PadLeft(2, ' ') + ":" + sUid + "        " + sBlock + "\r\n";
                        }
                        AddOpTagInfo(sList);

                        sUid = "";
                        sBlock = "";
                        for (i = 0; i < uidNum; i++)
                        {
                            for (j = 0; j < hfReaderDll.HFREADER_ISO15693_SIZE_UID; j++)
                            {
                                sUid += uid[i * hfReaderDll.HFREADER_ISO15693_SIZE_UID + hfReaderDll.HFREADER_ISO15693_SIZE_UID - 1 - j].ToString("X").PadLeft(2, '0');
                            }
                            for (j = 0; j < hfReaderDll.HFREADER_ISO15693_SIZE_BLOCK * blockNum; j++)
                            {
                                sBlock += block[i * hfReaderDll.HFREADER_ISO15693_SIZE_BLOCK * blockNum + j].ToString("X").PadLeft(2, '0');
                            }
                        }
                        sInfo = "第" + opTagTimers.ToString("D") + "次：标签数目：" + uidNum.ToString("D") + "枚    " + "测试时间" + sw.ElapsedMilliseconds.ToString("D") + "ms\r\n";
                        sInfo += "Uid  ：" + sUid + "\r\n";
                        if (blockNum > 0)
                        {
                            sInfo += "Block：" + sBlock + "\r\n";
                        }
                        sInfo += "\r\n";
                        if (checkBoxOpTagLog.Checked)
                        {
                            WriteOpTagLog(sInfo);
                        }
                        AddDisplayInfo(sInfo);
                        
                    }
                    else
                    //主动帧
                    {
                        Array.Clear(pActiveFrame.uid, 0, hfReaderDll.HFREADER_BUFFER_MAX * hfReaderDll.HFREADER_FRAME_MAX_NUM);
                        Array.Clear(pActiveFrame.frame, 0, hfReaderDll.HFREADER_BUFFER_MAX * hfReaderDll.HFREADER_FRAME_MAX_NUM);
                        bOperatingSerial = true;
                        int rlt = hfReaderDll.hfReaderReceive(serialDevice, ref pActiveFrame);
                        bOperatingSerial = false;
                        if (rlt > 0)
                        {
                            String s = "";
                            int i = 0;
                            for (i = 0; i < pActiveFrame.num; i++)
                            {
                                Byte[] buffer = new Byte[hfReaderDll.HFREADER_BUFFER_MAX];
                                for (int k = 0; k < hfReaderDll.HFREADER_BUFFER_MAX; k++)
                                {
                                    buffer[k] = pActiveFrame.frame[i * hfReaderDll.HFREADER_BUFFER_MAX + k];
                                }
                                DisplayRcvInf(buffer, "阅读器主动上报数据：");
                                s = "";
                                if (pActiveFrame.frame[i * hfReaderDll.HFREADER_BUFFER_MAX + hfReaderDll.HFREADER_FRAME_POS_CMD] == hfReaderDll.HFREADER_ISO15693_CMD_ACTIVE_SUID)
                                {
                                    int j = 0;
                                    for (j = 0; j < 8; j++)
                                    {
                                        s += pActiveFrame.uid[i * hfReaderDll.HFREADER_BUFFER_MAX + j].ToString("X").PadLeft(2, '0');
                                    }
                                    AddActiveSendUID(s);
                                }
                                else if (pActiveFrame.frame[i * hfReaderDll.HFREADER_BUFFER_MAX + hfReaderDll.HFREADER_FRAME_POS_CMD] == hfReaderDll.HFREADER_ISO15693_CMD_ACTIVE_EAS)
                                {
                                    int j = 0;
                                    for (j = 0; j < 8; j++)
                                    {
                                        s += pActiveFrame.uid[i * hfReaderDll.HFREADER_BUFFER_MAX + j].ToString("X").PadLeft(2, '0');
                                    }
                                    AddActiveSendEAS(s);
                                }

                            }
                        }
                        System.Threading.Thread.Sleep(200);
                    }

                }
                
            }
            
        }

        private void buttonClearInTag_Click(object sender, EventArgs e)
        {
            this.listBoxTagIn.Items.Clear();
            this.textBoxTagInNum.Text = "00";
        }

        private void buttonClearEas_Click(object sender, EventArgs e)
        {
            this.listBoxEasAlarm.Items.Clear();
            this.textBoxEasNum.Text = "00";
        }

        private void listBoxTagIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBoxTagIn.SelectedItem != null)
            {
                this.textBoxSelectedIso15693Uid.Text = this.listBoxTagIn.SelectedItem.ToString(); 
            }
        }

        public int GetHexInput(String s, Byte[] buffer)
        {
            int i = 0;
            int num = 0;
            for (i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if ((c < '0' || c > '9') && (c < 'a' || c > 'f') && (c < 'A' || c > 'F'))
                {
                    MessageBox.Show("请以16进制格式输入数据，例如：00 01 FF");
                    return 0;
                }
            }
            num = s.Length / 2;
            for (i = 0; i < num; i++)
            {
                buffer[i] = Convert.ToByte(s.Substring(i * 2, 2), 16);
            }

            return num;
        }

        public int GetHexInput(String s, Byte[] buffer, int num)
        {
            int i = 0;
            if (s.Length != 2 * num)
            {
                MessageBox.Show("数据长度错误");
                return -1;
            }
            for (i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if ((c < '0' || c > '9') && (c < 'a' || c > 'f') && (c < 'A' || c > 'F'))
                {
                    MessageBox.Show("请以16进制格式输入数据，例如：00 01 FF");
                    return -1;
                }
            }
            for (i = 0; i < num; i++)
            {
                buffer[i] = Convert.ToByte(s.Substring(i * 2, 2), 16);
            }

            return num;
        }

        private bool GetDeviceAddr(ushort[] addArray)
        {
            bool b = false;
            byte[] buffer = new Byte[255];
            if (GetHexInput(textBoxISO15693SrcAddr.Text, buffer, 2) > 0)
            {
                addArray[0] = (ushort)(buffer[0] * 256 + buffer[1]);
                if (GetHexInput(textBoxISO15693DestAddr.Text, buffer, 2) > 0)
                {
                    addArray[1] = (ushort)(buffer[0] * 256 + buffer[1]);
                    b = true;
                }
            }

            return b;
        }

        private void buttonReadTags_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                autoTiggerTimer.Enabled = false;
                return;
            }
            if (!autoTiggerTimer.Enabled)
            {
                autoTiggerTimer.Enabled = true;
            }
            clearOpResult();

            Byte[] buffer = new Byte[255];
            ushort[] addrArray = new ushort[2];
            Byte mode = 0;

            ISO15693_UIDPARAM pGetUid = new ISO15693_UIDPARAM();
            pGetUid.uid = new Byte[hfReaderDll.HFREADER_ISO15693_SIZE_UID * hfReaderDll.HFREADER_ISO15693_MAX_UID_NUM];
            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (this.radioButtonReadTagNormal.Checked)
            {
                mode = hfReaderDll.HFREADER_READ_UID_NORMAL;
            }
            else
            {
                mode = hfReaderDll.HFREADER_READ_UID_REPEAT;
            }

            while (bOperatingSerial) ;
            bOperatingSerial = true;
            int rlt = hfReaderDll.iso15693GetUid(serialDevice, addrArray[0], addrArray[1], mode, ref pGetUid, sendBuffer, rcvBuffer);
            bOperatingSerial = false;
            if (rlt > 0)
            {
                this.textBoxOpISO15693TagRltSrcAddr.Text = pGetUid.result.srcAddr.ToString("X").PadLeft(4, '0');
                this.textBoxOpISO15693TagRltDestAddr.Text = pGetUid.result.targetAddr.ToString("X").PadLeft(4, '0');
                

                if (pGetUid.num > 0)
                {
                    int i = 0, j = 0;
                    String s;
                    for (i = 0; i < pGetUid.num; i++)
                    {
                        s = "";
                        for (j = 0; j < 8; j++)
                        {
                            s += pGetUid.uid[i * 8 + j].ToString("X").PadLeft(2, '0');
                        }
                        //将下拉框改为文本框
                        txtTagID.Text = s;
                        /*
                            if (this.listBoxUID.FindString(s) < 0)
                            {
                                this.listBoxUID.Items.Add(s);
                            }
                        */
                    }
                    this.textBoxReadTagNum.Text = this.listBoxUID.Items.Count.ToString("X").PadLeft(2, '0');
                    this.textBoxRemainTagNum.Text = pGetUid.remainNum.ToString("X").PadLeft(2, '0');
                }
            }
            if (!string.IsNullOrEmpty(txtISBN.Text) && !string.IsNullOrEmpty(txtTagID.Text)) {
                btnSave_Click(null, null);
            }
            txtISBN.Focus();
            txtISBNHidden.Focus();
            //DisplayRcvInf(rcvBuffer, "查询场内标签返回：");
            //DisplaySendInf(sendBuffer, "查询场内标签：");
        }

        private void listBoxUID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBoxUID.SelectedItem != null)
            {
                this.textBoxSelectedIso15693Uid.Text = this.listBoxUID.SelectedItem.ToString();
            }
            
        }

        private void buttonClearListBox_Click(object sender, EventArgs e)
        {
            this.textBoxReadTagNum.Text = "00";
            this.textBoxRemainTagNum.Text = "00";
            this.listBoxUID.Items.Clear();
        }

        private void buttonLockBlock_Click(object sender, EventArgs e)
        {
            LockTag(textBoxLBlockAddr.Text, textBoxSelectedIso15693Uid.Text);
        }

        private void LockTag(string lockAddress,string tag_id) {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            clearOpResult();

            Byte[] uid = new Byte[hfReaderDll.HFREADER_ISO15693_SIZE_UID];
            ushort[] addrArray = new ushort[2];
            Byte[] blockAddr = new Byte[1];
            Byte[] blockNum = new Byte[1];

            HFREADER_OPRESULT pResult = new HFREADER_OPRESULT();
            Byte[] sendBuffer = new Byte[hfReaderDll.HFREADER_BUFFER_MAX];
            Byte[] rcvBuffer = new Byte[hfReaderDll.HFREADER_BUFFER_MAX];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (GetHexInput(tag_id, uid, hfReaderDll.HFREADER_ISO15693_SIZE_UID) <= 0)
            {
                return;
            }

            if (GetHexInput(lockAddress, blockAddr, 1) <= 0)
            {
                return;
            }

            while (bOperatingSerial) ;
            bOperatingSerial = true;
            int rlt = hfReaderDll.iso15693LockBlock(serialDevice, addrArray[0], addrArray[1], uid, blockAddr[0], ref pResult, sendBuffer, rcvBuffer);
            bOperatingSerial = false;
            if (rlt > 0)
            {
                DisplayOpResult(ref pResult);
            }
            DisplayRcvInf(rcvBuffer, "锁定数据块返回：");
            DisplaySendInf(sendBuffer, "锁定数据块：");
        }
        private void buttonReadMBlock_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            clearOpResult();

            int i = 0;

            Byte[] uid = new Byte[hfReaderDll.HFREADER_ISO15693_SIZE_UID];
            ushort[] addrArray = new ushort[2];
            Byte[] blockAddr = new Byte[1];
            Byte[] blockNum = new Byte[1];

            ISO15693_BLOCKPARAM pBlock = new ISO15693_BLOCKPARAM();
            pBlock.block = new Byte[hfReaderDll.HFREADER_ISO15693_SIZE_BLOCK * hfReaderDll.HFREADER_ISO15693_MAX_BLOCK_NUM];
            Byte[] sendBuffer = new Byte[hfReaderDll.HFREADER_BUFFER_MAX];
            Byte[] rcvBuffer = new Byte[hfReaderDll.HFREADER_BUFFER_MAX];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (GetHexInput(this.textBoxSelectedIso15693Uid.Text, uid, hfReaderDll.HFREADER_ISO15693_SIZE_UID) <= 0)
            {
                return;
            }

            if (GetHexInput(this.textBoxRMBlockAddr.Text, blockAddr, 1) <= 0)
            {
                return;
            }
            pBlock.addr = blockAddr[0];

            if (GetHexInput(this.textBoxRMBlockNum.Text, blockNum, 1) <= 0)
            {
                return;
            }
            pBlock.num = blockNum[0];

            if (blockNum[0] > hfReaderDll.HFREADER_ISO15693_MAX_BLOCK_NUM)
            {
                MessageBox.Show("最多可以读取" + hfReaderDll.HFREADER_ISO15693_MAX_BLOCK_NUM.ToString("X").PadLeft(2, '0') + "块");
                return;
            }

            while (bOperatingSerial) ;
            bOperatingSerial = true;
            int rlt = hfReaderDll.iso15693ReadBlock(serialDevice, addrArray[0], addrArray[1], uid, ref pBlock, sendBuffer, rcvBuffer);
            bOperatingSerial = false;
            if (rlt > 0)
            {
                if (pBlock.result.flag == 0)
                {
                    String s = "";
                    int j = 0;
                    for (j = 0; j < pBlock.num; j++)
                    {
                        for (i = 0; i < 4; i++)
                        {
                            s += pBlock.block[j * 4 + i].ToString("X").PadLeft(2, '0');
                        }
                        s += "\r\n";
                    }
                    s += "\r\n";
                    this.textBoxRMBlockData.Text += s;
                }
                DisplayOpResult(ref pBlock.result);
            }
            DisplayRcvInf(rcvBuffer, "读多块数据返回：");
            DisplaySendInf(sendBuffer, "读多块数据：");
        }

        private void buttonWriteMBlock_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            clearOpResult();
            int i = 0;

            Byte[] uid = new Byte[hfReaderDll.HFREADER_ISO15693_SIZE_UID];
            ushort[] addrArray = new ushort[2];
            Byte[] blockAddr = new Byte[1];
            Byte[] blockNum = new Byte[1];

            ISO15693_BLOCKPARAM pBlock = new ISO15693_BLOCKPARAM();
            pBlock.block = new Byte[hfReaderDll.HFREADER_ISO15693_SIZE_BLOCK * hfReaderDll.HFREADER_ISO15693_MAX_BLOCK_NUM];
            Byte[] sendBuffer = new Byte[hfReaderDll.HFREADER_BUFFER_MAX];
            Byte[] rcvBuffer = new Byte[hfReaderDll.HFREADER_BUFFER_MAX];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (GetHexInput(this.textBoxWMBlockAddr.Text, blockAddr, 1) <= 0)
            {
                return;
            }
            pBlock.addr = blockAddr[0];
            if (GetHexInput(this.textBoxWMBlockNum.Text, blockNum, 1) <= 0)
            {
                return;
            }
            pBlock.num = blockNum[0];

            //if (GetHexInput(this.textBoxSelectedIso15693Uid.Text, uid, hfReaderDll.HFREADER_ISO15693_SIZE_UID) <= 0)
            if (GetHexInput(this.txtTagID.Text, uid, hfReaderDll.HFREADER_ISO15693_SIZE_UID) <= 0)
            {
                return;
            }

            String s = this.textBoxWMBlockData.Text;
            String[] dataString = new String[32];
            dataString = s.Split('\n');
            if (blockNum[0] > hfReaderDll.HFREADER_ISO15693_MAX_BLOCK_NUM)
            {
                MessageBox.Show("最多可以写入" + hfReaderDll.HFREADER_ISO15693_MAX_BLOCK_NUM.ToString("X").PadLeft(2, '0') + "块");
                return;
            }
            if (blockNum[0] > dataString.Length)
            {
                MessageBox.Show("数据不足，请继续填写");
                return;
            }
            else
            {
                int j = 0;
                for (i = 0; i < blockNum[0]; i++)
                {
                    int pos = dataString[i].IndexOf('\r');
                    Byte[] data = new Byte[hfReaderDll.HFREADER_ISO15693_SIZE_BLOCK];
                    if (pos >= 0)
                    {
                        dataString[i] = dataString[i].Remove(pos);
                    }

                    pos = dataString[i].IndexOf(' ');
                    if (pos >= 0)
                    {
                        dataString[i] = dataString[i].Remove(pos);
                    }

                    s = dataString[i];

                    if (GetHexInput(s, data, hfReaderDll.HFREADER_ISO15693_SIZE_BLOCK) <= 0)
                    {
                        return;
                    }
                    else
                    {
                        for (j = 0; j < hfReaderDll.HFREADER_ISO15693_SIZE_BLOCK; j++)
                        {
                            pBlock.block[i * hfReaderDll.HFREADER_ISO15693_SIZE_BLOCK + j] = data[j];
                        }
                    }
                }
            }
            
            while (bOperatingSerial) ;
            bOperatingSerial = true;
            int rlt = hfReaderDll.iso15693WriteBlock(serialDevice, addrArray[0], addrArray[1], uid, ref pBlock, sendBuffer, rcvBuffer);
            bOperatingSerial = false;
            if (rlt > 0)
            {
                DisplayOpResult(ref pBlock.result);
            }
            DisplayRcvInf(rcvBuffer, "写多块数据返回：");
            DisplaySendInf(sendBuffer, "写多块数据：");
        }

        private void buttonClearMultBlock_Click(object sender, EventArgs e)
        {
            this.textBoxRMBlockData.Text = "";
        }

        private void buttonCfgRltReset_Click(object sender, EventArgs e)
        {
            clearOpResult();
        }

        private void buttonCtrlAfi_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            clearOpResult();

            Byte[] uid = new Byte[hfReaderDll.HFREADER_ISO15693_SIZE_UID];
            ushort[] addrArray = new ushort[2];
            Byte[] afi = new Byte[1];

            HFREADER_OPRESULT pResult = new HFREADER_OPRESULT();
            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (GetHexInput(this.textBoxSelectedIso15693Uid.Text, uid, hfReaderDll.HFREADER_ISO15693_SIZE_UID) <= 0)
            {
                return;
            }

            if (GetHexInput(this.textBoxAFIValue.Text, afi, 1) <= 0)
            {
                return;
            }

            while (bOperatingSerial) ;
            bOperatingSerial = true;
            int rlt = 0;
            if (this.radioButtonWriteAFI.Checked)
            {
                rlt = hfReaderDll.iso15693WriteAfi(serialDevice, addrArray[0], addrArray[1], uid, afi[0], ref pResult, sendBuffer, rcvBuffer);
            }
            else
            {
                rlt = hfReaderDll.iso15693LockAfi(serialDevice, addrArray[0], addrArray[1], uid, ref pResult, sendBuffer, rcvBuffer);
            }
            
            bOperatingSerial = false;
            if (rlt > 0)
            {
                DisplayOpResult(ref pResult);
                
                

            }
            if (this.radioButtonWriteAFI.Checked)
            {
                DisplayRcvInf(rcvBuffer, "写AFI返回：");
                DisplaySendInf(sendBuffer, "写AFI：");
            }
            else
            {
                DisplayRcvInf(rcvBuffer, "锁定AFI返回：");
                DisplaySendInf(sendBuffer, "锁定AFI：");
            }
        }

        private void buttonCtrlDsfid_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }

            Byte[] uid = new Byte[hfReaderDll.HFREADER_ISO15693_SIZE_UID];
            ushort[] addrArray = new ushort[2];
            Byte[] dsfid = new Byte[1];

            HFREADER_OPRESULT pResult = new HFREADER_OPRESULT();
            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (GetHexInput(this.textBoxSelectedIso15693Uid.Text, uid, hfReaderDll.HFREADER_ISO15693_SIZE_UID) <= 0)
            {
                return;
            }

            if (GetHexInput(this.textBoxDSFIDValue.Text, dsfid, 1) <= 0)
            {
                return;
            }

            while (bOperatingSerial) ;
            bOperatingSerial = true;
            int rlt = 0;
            if (this.radioButtonWriteDSFID.Checked)
            {
                rlt = hfReaderDll.iso15693WriteDsfid(serialDevice, addrArray[0], addrArray[1], uid, dsfid[0], ref pResult, sendBuffer, rcvBuffer);
            }
            else
            {
                rlt = hfReaderDll.iso15693LockDsfid(serialDevice, addrArray[0], addrArray[1], uid, ref pResult, sendBuffer, rcvBuffer);
            }

            bOperatingSerial = false;
            if (rlt > 0)
            {
                DisplayOpResult(ref pResult);
            }
            if (this.radioButtonWriteDSFID.Checked)
            {
                DisplayRcvInf(rcvBuffer, "写DSFID返回：");
                DisplaySendInf(sendBuffer, "写DSFID：");
            }
            else
            {
                DisplayRcvInf(rcvBuffer, "锁定DSFID返回：");
                DisplaySendInf(sendBuffer, "锁定DSFID：");
            }
        }

        private void buttonCtrlEas_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            clearOpResult();

            Byte[] uid = new Byte[hfReaderDll.HFREADER_ISO15693_SIZE_UID];
            ushort[] addrArray = new ushort[2];
            Byte cmd = 0;

            HFREADER_OPRESULT pResult = new HFREADER_OPRESULT();
            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (GetHexInput(this.textBoxSelectedIso15693Uid.Text, uid, hfReaderDll.HFREADER_ISO15693_SIZE_UID) <= 0)
            {
                return;
            }

            while (bOperatingSerial) ;
            bOperatingSerial = true;
            int rlt = 0;
            if (this.radioButtonSetEAS.Checked)
            {
                cmd = hfReaderDll.HFREADER_ISO15693_CMD_SET_EAS;
            }
            else if (this.radioButtonResetEAS.Checked)
            {
                cmd = hfReaderDll.HFREADER_ISO15693_CMD_RESET_EAS;
            }
            else
            {
                cmd = hfReaderDll.HFREADER_ISO15693_CMD_LOCK_EAS;
            }
            rlt = hfReaderDll.iso15693SetEas(serialDevice, addrArray[0], addrArray[1], uid, cmd, ref pResult, sendBuffer, rcvBuffer);

            bOperatingSerial = false;
            if (rlt > 0)
            {
                DisplayOpResult(ref pResult);
            }
            if (this.radioButtonSetEAS.Checked)
            {
                DisplayRcvInf(rcvBuffer, "设置EAS返回：");
                DisplaySendInf(sendBuffer, "设置EAS：");
            }
            else if (this.radioButtonResetEAS.Checked)
            {
                DisplayRcvInf(rcvBuffer, "复位EAS返回：");
                DisplaySendInf(sendBuffer, "复位EAS：");
            }
            else
            {
                DisplayRcvInf(rcvBuffer, "锁定EAS返回：");
                DisplaySendInf(sendBuffer, "锁定EAS：");
            }
        }

        private void buttonReadTagInf_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            clearOpResult();

            Byte[] uid = new Byte[hfReaderDll.HFREADER_ISO15693_SIZE_UID];
            ushort[] addrArray = new ushort[2];

            ISO15693_TAGPARAM pTagInfo = new ISO15693_TAGPARAM();
            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (GetHexInput(this.textBoxSelectedIso15693Uid.Text, uid, hfReaderDll.HFREADER_ISO15693_SIZE_UID) <= 0)
            {
                return;
            }

            while (bOperatingSerial) ;
            bOperatingSerial = true;
            int rlt = hfReaderDll.iso15693ReadTagInfo(serialDevice, addrArray[0], addrArray[1], uid, ref pTagInfo, sendBuffer, rcvBuffer);

            bOperatingSerial = false;
            if (rlt > 0)
            {
                if (pTagInfo.result.flag == 0)
                {
                    this.textBoxTagInfFlag.Text = pTagInfo.infoFlag.ToString("X").PadLeft(2, '0');
                    this.textBoxTagInfDSFID.Text = pTagInfo.dsfid.ToString("X").PadLeft(2, '0');
                    this.textBoxTagInfBlockNum.Text = pTagInfo.blockNum.ToString("X").PadLeft(2, '0');
                    this.textBoxTagInfBlockSize.Text = pTagInfo.blockSize.ToString("X").PadLeft(2, '0');
                    this.textBoxTagInfICRef.Text = pTagInfo.ic.ToString("X").PadLeft(2, '0');
                    this.textBoxTagInfAFI.Text = pTagInfo.afi.ToString("X").PadLeft(2, '0');
                }
                DisplayOpResult(ref pTagInfo.result);
            }
            DisplayRcvInf(rcvBuffer, "读标签系统信息返回：");
            DisplaySendInf(sendBuffer, "读标签系统信息：");
        }

        private void buttonClearInfo_Click(object sender, EventArgs e)
        {
            this.textBoxInf.Text = "";
        }

        private void buttonClearTagInfo_Click(object sender, EventArgs e)
        {
            this.textBoxTagInfFlag.Text = "";
            this.textBoxTagInfDSFID.Text = "";
            this.textBoxTagInfBlockNum.Text = "";
            this.textBoxTagInfBlockSize.Text = "";
            this.textBoxTagInfICRef.Text = "";
            this.textBoxTagInfAFI.Text = "";
        }

        private void buttonClearLockBlock_Click(object sender, EventArgs e)
        {
            this.textBoxLBlockAddr.Text = "";
        }

        private void buttonClearWMBlock_Click(object sender, EventArgs e)
        {
            this.textBoxWMBlockData.Text = "";
        }

        private void buttonDtu_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            clearOpResult();

            ushort[] addrArray = new ushort[2];
            Byte[] rxLen  = new Byte[1];

            ISO15693_DTU pDtu = new ISO15693_DTU();
            pDtu.txFrame = new Byte[hfReaderDll.HFREADER_BUFFER_MAX];
            pDtu.rxFrame = new Byte[hfReaderDll.HFREADER_BUFFER_MAX];

            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (GetHexInput(this.textBoxDtuRxLen.Text, rxLen, 1) <= 0)
            {
                return;
            }
            pDtu.rxLen = rxLen[0];

            pDtu.txLen = (uint)(GetHexInput(this.textBoxDtuTx.Text, pDtu.txFrame));

            pDtu.timeout = Convert.ToUInt32(this.textBoxDtuTime.Text, 10);

            while (bOperatingSerial) ;
            bOperatingSerial = true;
            int rlt = hfReaderDll.iso15693Dtu(serialDevice, addrArray[0], addrArray[1], ref pDtu, sendBuffer, rcvBuffer);
            bOperatingSerial = false;

            if (rlt > 0)
            {
                if (pDtu.result.flag == 0)
                {
                    string s = "";
                    for (uint i = 0; i < pDtu.rxLen; i++)
                    {
                        s += pDtu.rxFrame[i].ToString("X").PadLeft(2, '0');
                    }
                    this.textBoxDtuRx.Text = s;
                }
                DisplayOpResult(ref pDtu.result);
            }
            DisplayRcvInf(rcvBuffer, "透传返回：");
            DisplaySendInf(sendBuffer, "透传：");
        }

        private void buttonDtuTxClear_Click(object sender, EventArgs e)
        {
            this.textBoxDtuTx.Text = "";
        }

        private void buttonDtuRxClear_Click(object sender, EventArgs e)
        {
            this.textBoxDtuRx.Text = "";
        }

        private void WriteOpTagLog(String s)
        {
            if (opTagLogFile != null)
            {
                opTagLogFileWrite.Flush();
                opTagLogFileWrite.BaseStream.Seek(0, SeekOrigin.End);
                opTagLogFileWrite.Write(s);
                opTagLogFileWrite.Write("\r\n");
            }

        }
        private void buttonOpTagStart_Click(object sender, EventArgs e)
        {
            if (directOpTagMode > 0)
            {
                buttonOpTagStart.Text = "开始";
                directOpTagMode = 0;
                checkBoxOpTagLog.Enabled = true;
                checkBoxOpTagRBlock.Enabled = true;
                textBoxOpTagRBlockAddr1.Enabled = checkBoxOpTagRBlock.Checked;
                textBoxOpTagRBlockAddr2.Enabled = checkBoxOpTagRBlock.Checked;
                textBoxOpTagRBlockAddr3.Enabled = checkBoxOpTagRBlock.Checked;
                textBoxOpTagRBlockAddr4.Enabled = checkBoxOpTagRBlock.Checked;
                textBoxOpTagRBlockNum.Enabled = checkBoxOpTagRBlock.Checked;
                this.fatherForm.Enabled = true;
                this.textBoxInf.Text = "";
                WriteOpTagLog("Stop\r\n");

                if (opTagLogFile != null)
                {
                    opTagLogFile.Close();
                    opTagLogFile = null;
                }

            }
            else
            {
                if (serialDevice < 0)
                {
                    MessageBox.Show("请先打开串口");
                    return;
                }

                ushort[] addrArray = new ushort[2];
                Byte WorkMode = 0;
                int rlt = 0;
                HFREADER_CONFIG pReaderConfig = new HFREADER_CONFIG();
                HFREADER_OPRESULT pResult = new HFREADER_OPRESULT();
                if (!GetDeviceAddr(addrArray))
                {
                    return;
                }

                WorkMode |= hfReaderDll.HFREADER_CFG_TYPE_ISO15693 | hfReaderDll.HFREADER_CFG_WM_INVENTORY;
                pReaderConfig.workMode = WorkMode;
                pReaderConfig.cmdMode = hfReaderDll.HFREADER_CFG_INVENTORY_TRIGGER;
                pReaderConfig.uidSendMode = hfReaderDll.HFREADER_CFG_UID_POSITIVE;
                pReaderConfig.beepStatus = hfReaderDll.HFREADER_CFG_BUZZER_ENABLE;
                pReaderConfig.afiCtrl = hfReaderDll.HFREADER_CFG_AFI_DISABLE;
                pReaderConfig.tagStatus = hfReaderDll.HFREADER_CFG_TAG_QUIET;
                pReaderConfig.baudrate = hfReaderDll.HFREADER_CFG_BAUDRATE38400;
                pReaderConfig.afi = 0x00;
                pReaderConfig.readerAddr = (ushort)(addrArray[1]);

                while (bOperatingSerial) ;
                bOperatingSerial = true;
                rlt = hfReaderDll.hfReaderSetConfig(serialDevice, addrArray[0], addrArray[1], ref pReaderConfig, null, null);
                bOperatingSerial = false;
                if (rlt <= 0)
                {
                    MessageBox.Show("设置读写器失败");
                    return;
                }

                while (bOperatingSerial) ;
                bOperatingSerial = true;
                rlt = hfReaderDll.hfReaderCtrlRf(serialDevice, addrArray[0], addrArray[1], hfReaderDll.HFREADER_RF_CLOSE, ref pResult, null, null);
                bOperatingSerial = false;
                if (rlt <= 0)
                {
                    MessageBox.Show("关闭射频失败");
                    return;
                }

                opTagLogFile = null;
                if (checkBoxOpTagLog.Checked)
                {
                    String fileName = "";
                    DateTime t = DateTime.Now;
                    fileName = t.ToLongDateString();
                    fileName += " log.txt";

                    opTagLogFile = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    opTagLogFileWrite = new StreamWriter(opTagLogFile);
                    WriteOpTagLog(t.ToLongTimeString());
                }

                buttonOpTagStart.Text = "停止";
                directOpTagMode = 1;
                checkBoxOpTagLog.Enabled = false;
                checkBoxOpTagRBlock.Enabled = false;

                if (checkBoxOpTagRBlock.Checked)
                {
                    directOpTagMode = 2;
                }
                this.fatherForm.Enabled = false;
                this.textBoxInf.Text = "";
                textBoxOpTagRBlockAddr1.Enabled = false;
                textBoxOpTagRBlockAddr2.Enabled = false;
                textBoxOpTagRBlockAddr3.Enabled = false;
                textBoxOpTagRBlockAddr4.Enabled = false;
                textBoxOpTagRBlockNum.Enabled = false;

//                 Byte[] txFrame = new Byte[4096];
//                 Byte[] rxFrame = new Byte[4096];
//                 Byte[] uid = new Byte[4096];
//                 Byte[] block = new Byte[4096];
// 
//                 if (directOpTagMode == 1)
//                 {
//                     rlt = hfReaderDll.iso15693OpTagsRUid(serialDevice, 0x0000, 0xFFFF, uid, txFrame, rxFrame);
//                     if (rlt > 0)
//                     {
// 
//                     }
//                 }
            }
        }

        private void tabControlISO15693TagOp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControlISO15693TagOp_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (directOpTagMode > 0)
            {
                e.Cancel = true;
            }
        }

        private void checkBoxOpTagRBlock_CheckedChanged(object sender, EventArgs e)
        {
            textBoxOpTagRBlockAddr1.Enabled = checkBoxOpTagRBlock.Checked;
            textBoxOpTagRBlockAddr2.Enabled = checkBoxOpTagRBlock.Checked;
            textBoxOpTagRBlockAddr3.Enabled = checkBoxOpTagRBlock.Checked;
            textBoxOpTagRBlockAddr4.Enabled = checkBoxOpTagRBlock.Checked;
            textBoxOpTagRBlockNum.Enabled = checkBoxOpTagRBlock.Checked;
        }

        private void ISO15693_FormClosed(object sender, FormClosedEventArgs e)
        {
            autoTiggerTimer.Stop();
        }

        private void gvRecordList_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName.ToLower() == "status" && e.Value != null)
            {
                if (e.Value.ToString() == "0")
                {
                    e.DisplayText = "标签建档";
                }
                if (e.Value.ToString() == "1")
                {
                    e.DisplayText = "已采集";
                }
                if (e.Value.ToString() == "2")
                {
                    e.DisplayText = "已校对";
                }
                else
                {
                    e.DisplayText = "已入库";
                }
            }
        }

        private void chkAutoRead_CheckedChanged(object sender, EventArgs e)
        {
            autoTiggerTimer.Enabled = chkAutoRead.Checked;
            buttonReadTags.Visible = !autoTiggerTimer.Enabled;
        }

        /// <summary>
        /// 删除选中标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                int[] rowHanders = gvRecordList.GetSelectedRows();
                if ((rowHanders.Length > 0))
                {
                    DialogResult result = MessageBox.Show("您确认要删除选中标签记录吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        rowHanders.ToList().ForEach(hander =>
                        {
                            Book_init_mapping book_init_mapping = gvRecordList.GetRow(hander) as Book_init_mapping;
                            if (null != book_init_mapping)
                            {
                                if (TagInfoDAL.DeletetBookInitMapping(book_init_mapping.tag_id.ToString()))
                                {
                                    gvRecordList.DeleteRow(hander);
                                    gvRecordList.RefreshData();
                                }
                            }
                        });
                    }
                }
            }
            catch(Exception ee) {
                MessageBox.Show("删除失败!"+ee.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private DateTime _dt = DateTime.Now;  //定义一个成员函数用于保存每次的时间点
        private string first_char=string.Empty;
        private void txtISBN_KeyUp(object sender, KeyEventArgs e)
        {
            //var textBox = sender as DevExpress.XtraEditors.TextEdit;
            //if (string.IsNullOrEmpty(first_char))
            //{
            //    first_char = textBox.Text.Trim();
            //}
            //DateTime tempDt = DateTime.Now;          //保存按键按下时刻的时间点
            //TimeSpan ts = tempDt.Subtract(_dt);     //获取时间间隔
            //if (ts.Milliseconds > 50)
            //{
            //    txtISBN.EditValue = "";
            //    txtISBN.Text = "";
            //}//判断时间间隔，如果时间间隔大于50毫秒，则将TextBox清空
            //_dt = tempDt;
        }

        private void txtISBNHidden_TextChanged(object sender, EventArgs e)
        {
            txtISBN.Text = txtISBNHidden.Text;
            this.barCodeISBN2.Text = txtISBN.Text;
        }

        private void txtTagID_EditValueChanged(object sender, EventArgs e)
        {
            if (null != txtTagID.EditValue&&txtTagID.Text.Length>12)
            {
               
                try
                {
                    var bookinfoExt = TagInfoDAL.SelectBookinfoExt(txtTagID.Text.Trim());
                    this.barCodeISBN.Text = bookinfoExt.isbn_no;
                    this.txtBookName.Text = bookinfoExt.book_name;
                    this.barCodeISBN2.Text = bookinfoExt.isbn_no;
                    this.txtAuthor.Text = bookinfoExt.author;
                    this.txtBrief.Text = bookinfoExt.brief;
                    this.txtCreateTime.Text = bookinfoExt.create_time.ToString();
                    this.txtDescribe.Text = bookinfoExt.describe;
                    this.txtPress.Text = bookinfoExt.press;
                    this.txtPrice.Text = bookinfoExt.price.ToString();
                    this.txtPublicate_date.Text = bookinfoExt.publication_date.ToString();
                    imageSlider1.Images.Clear();
                    this.imageSlider1.Images.Add(ImageExtensions.GetImageFromNet($"http://wdb007.oss-cn-hangzhou.aliyuncs.com/" + bookinfoExt.imgurl));
                }
                catch {

                }
            }
        }
        private void WriteNFCBlock(string isbn="123456789")
        {
            string tag_id = this.txtTagID.Text;
            if (string.IsNullOrEmpty(tag_id)) {
                MessageBox.Show("未读取到标签，写入NFC地址失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //string uri = $"{ string.Format(ConnectInit.NFC_Address, isbn) + "&lan=zh_cn" }";
            string uri = $"{ string.Format(ConnectInit.NFC_Address, isbn)}";
            string hexString = HexUtil.Encode(uri);
            hexString = $"{HexUtil.START_DIRECTIVE + hexString}";
            List<string> listData = HexUtil.ToStringArray(hexString);
            var dataLen = Convert.ToString(listData.Count, 16).PadLeft(2, '0');
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            clearOpResult();
            int i = 0;

            Byte[] uid = new Byte[hfReaderDll.HFREADER_ISO15693_SIZE_UID];
            ushort[] addrArray = new ushort[2];
            Byte[] blockAddr = new Byte[1];
            Byte[] blockNum = new Byte[1];

            ISO15693_BLOCKPARAM pBlock = new ISO15693_BLOCKPARAM();
            pBlock.block = new Byte[hfReaderDll.HFREADER_ISO15693_SIZE_BLOCK * hfReaderDll.HFREADER_ISO15693_MAX_BLOCK_NUM];
            Byte[] sendBuffer = new Byte[hfReaderDll.HFREADER_BUFFER_MAX];
            Byte[] rcvBuffer = new Byte[hfReaderDll.HFREADER_BUFFER_MAX];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (GetHexInput("00", blockAddr, 1) <= 0)
            {
                return;
            }
            pBlock.addr = blockAddr[0];
            if (GetHexInput(dataLen, blockNum, 1) <= 0)
            {
                return;
            }
            pBlock.num = blockNum[0];

            //if (GetHexInput(this.textBoxSelectedIso15693Uid.Text, uid, hfReaderDll.HFREADER_ISO15693_SIZE_UID) <= 0)
            if (GetHexInput(tag_id, uid, hfReaderDll.HFREADER_ISO15693_SIZE_UID) <= 0)
            {
                return;
            }

            String s = string.Empty;
            for (int len = 0; len < listData.Count; len++)
            {
                if (len == 0)
                {
                    s += listData[len];
                    continue;
                }
                s += $"\r\n{listData[len]}";
            }

            String[] dataString = new String[32];
            dataString = s.Split('\n');
            if (blockNum[0] > hfReaderDll.HFREADER_ISO15693_MAX_BLOCK_NUM)
            {
                MessageBox.Show("最多可以写入" + hfReaderDll.HFREADER_ISO15693_MAX_BLOCK_NUM.ToString("X").PadLeft(2, '0') + "块");
                return;
            }
            if (blockNum[0] > dataString.Length)
            {
                MessageBox.Show("数据不足，请继续填写");
                return;
            }
            else
            {
                int j = 0;
                for (i = 0; i < blockNum[0]; i++)
                {
                    int pos = dataString[i].IndexOf('\r');
                    Byte[] data = new Byte[hfReaderDll.HFREADER_ISO15693_SIZE_BLOCK];
                    if (pos >= 0)
                    {
                        dataString[i] = dataString[i].Remove(pos);
                    }

                    pos = dataString[i].IndexOf(' ');
                    if (pos >= 0)
                    {
                        dataString[i] = dataString[i].Remove(pos);
                    }

                    s = dataString[i];

                    if (GetHexInput(s, data, hfReaderDll.HFREADER_ISO15693_SIZE_BLOCK) <= 0)
                    {
                        return;
                    }
                    else
                    {
                        for (j = 0; j < hfReaderDll.HFREADER_ISO15693_SIZE_BLOCK; j++)
                        {
                            pBlock.block[i * hfReaderDll.HFREADER_ISO15693_SIZE_BLOCK + j] = data[j];
                        }
                    }
                }
            }

            while (bOperatingSerial) ;
            bOperatingSerial = true;
            int rlt = hfReaderDll.iso15693WriteBlock(serialDevice, addrArray[0], addrArray[1], uid, ref pBlock, sendBuffer, rcvBuffer);
            bOperatingSerial = false;
            if (rlt > 0)
            {
                DisplayOpResult(ref pBlock.result);
                if (pBlock.result.flag == 0)
                {
                    LockTag("01", tag_id);
                }
            }
            //DisplayRcvInf(rcvBuffer, "写多块数据返回：");
            //DisplaySendInf(sendBuffer, "写多块数据：");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}