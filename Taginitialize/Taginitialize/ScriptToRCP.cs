using System;
using System.Collections;
using System.Text;

using Phychips.Helper;
using Phychips.Rcp;

namespace Phychips.PR9200
{
    class ScriptToRCP
    {
        static private ScriptToRCP _instance;
        static public Hashtable ht;
        static public int ArrCnt = 0;

        static public string[] keyFragment;

        #region Class Instantiate region
        static StartAutoRead2 startread = new StartAutoRead2();
        static StopAutoRead2 stopread = new StopAutoRead2();
        static Sleep sleep = new Sleep();
        static DeepSleep deepsleep = new DeepSleep();
        static GetRegion getregion = new GetRegion();
        static SetRegion setregion = new SetRegion();
        static Reset reset = new Reset();
        static GetSelect getselect = new GetSelect();
        static SetSelect setselect = new SetSelect();
        static GetQuery getquery = new GetQuery();
        static SetQuery setquery = new SetQuery();
        static GetChannel getchannel = new GetChannel();
        static SetChannel setchannel = new SetChannel();
        static GetFHLBT getfhlbt = new GetFHLBT();
        static SetFHLBT setfhlbt = new SetFHLBT();
        static GetTxPWR getpwr = new GetTxPWR();
        static SetTxPWR setpwr = new SetTxPWR();
        static CWCtrl cwctrl = new CWCtrl();
        static ReadTypeCUII readtypec = new ReadTypeCUII();
        static GetTemperature temperature = new GetTemperature();        
        static GetModulation getmodulation = new GetModulation();
        static SetModulation setmodulation = new SetModulation();
        static GetFHTable getfhtable = new GetFHTable();
        static SetFHTable setfhtable = new SetFHTable();

        static StartAutoReadRSSI startautoreadrssi = new StartAutoReadRSSI();
        //static StopAutoReadRSSI stopautoreadrssi = new StopAutoReadRSSI();

        static GetReaderInformation getreaderinfo = new GetReaderInformation();
        static GetRSSI getrssi = new GetRSSI();
        static ScanRSSI scanrssi = new ScanRSSI();
        static UpdateRegistry updateregistry = new UpdateRegistry();        
        static GetRegistryItem getregistryitem = new GetRegistryItem();        
        static ScriptSleep scriptsleep = new ScriptSleep();

        static ReadTypeCTagData readmemory = new ReadTypeCTagData();        
        static WriteTypeCTagData writememory = new WriteTypeCTagData();

        static BlockWriteTypeC blockwrite = new BlockWriteTypeC();
        static BlockEraseTypeC blockerase = new BlockEraseTypeC();

        //static TestPortEnable testport = new TestPortEnable();
        //static LeakageMode leakmode = new LeakageMode();

        static SetOptFHTable setoptfhtbl= new SetOptFHTable();
        
        static SetFHmode setfhmode = new SetFHmode();
        static GetFHmode getfhmode = new GetFHmode();

        static SetFHmodeLevel setrssiofsmarthopping = new SetFHmodeLevel();
        static GetFHmodeLevel getrssiofsmarthopping = new GetFHmodeLevel();

        static GetSession getsession = new GetSession();
        static SetSession setsession = new SetSession();

        static GetAntiCol getanticol = new GetAntiCol();
        static SetAntiCol setanticol = new SetAntiCol();

        static StartReadTID startreadtid = new StartReadTID();

        static BlockPeramLock blockpermlock = new BlockPeramLock();
        static ReadTypeCLongData readlongmemory = new ReadTypeCLongData();
        static KillRecom killtypec = new KillRecom();
        static LockTypeC locktypec = new LockTypeC();

        #endregion  

        protected ScriptToRCP()
        {
            ht = new Hashtable();

            mkHT();
            ScriptToRCP.keyFragment = new string[ScriptToRCP.ht.Keys.Count];
            ScriptToRCP.ht.Keys.CopyTo(ScriptToRCP.keyFragment,0);
        }

        public static ScriptToRCP Instance()
        {
            if (_instance == null)
            {
                _instance = new ScriptToRCP();
            }
            return _instance;
        }

        #region Hashtable Add region
        void mkHT()
        {
            ht.Add("sleep", sleep);
            ht.Add("deepsleep", deepsleep);

            ht.Add("getreaderinfo", getreaderinfo);

            ht.Add("getregion", getregion);
            ht.Add("setregion", setregion);

            ht.Add("getpwr", getpwr);
            ht.Add("setpwr", setpwr);

            ht.Add("reset", reset);

            ht.Add("getselect", getselect);
            ht.Add("setselect", setselect);

            ht.Add("getquery", getquery);
            ht.Add("setquery", setquery);

            ht.Add("startread", startread);
            ht.Add("stopread", stopread);                        

            ht.Add("getchannel", getchannel);
            ht.Add("setchannel", setchannel);

            ht.Add("getfhlbt", getfhlbt);
            ht.Add("setfhlbt", setfhlbt);
            
            ht.Add("cwctrl", cwctrl);

            ht.Add("readtypec", readtypec);

            ht.Add("getfhtable", getfhtable);
            ht.Add("setfhtable", setfhtable);

            ht.Add("getmodulation", getmodulation);
            ht.Add("setmodulation", setmodulation);

            ht.Add("temperature", temperature);

            ht.Add("startreadrssi", startautoreadrssi);
            //ht.Add("stopreadrssi", stopautoreadrssi);
            
            ht.Add("getrssi", getrssi);
            ht.Add("scanrssi", scanrssi);

            ht.Add("updateregistry", updateregistry);            
            ht.Add("getregistry", getregistryitem);            
            ht.Add("scriptsleep", scriptsleep);

            ht.Add("readmemory", readmemory);
            ht.Add("writememory", writememory);

            ht.Add("blockwrite", blockwrite);
            ht.Add("blockerase", blockerase);

            //ht.Add("testport",testport);
            //ht.Add("leakmode", leakmode);

            ht.Add("setoptfhtbl", setoptfhtbl);

            ht.Add("setfhmode", setfhmode);
            ht.Add("getfhmode", getfhmode);

            ht.Add("setrssiofsmarthopping", setrssiofsmarthopping);
            ht.Add("getrssiofsmarthopping", getrssiofsmarthopping);

            ht.Add("getsession", getsession);
            ht.Add("setsession", setsession);

            ht.Add("getanticol", getanticol);
            ht.Add("setanticol", setanticol);
           
            ht.Add("startreadtid", startreadtid);

            ht.Add("blockpermlock", blockpermlock);
            ht.Add("readlongmemory", readlongmemory);
            ht.Add("locktypec", locktypec);
            ht.Add("killtypec", killtypec);
        }
        #endregion
    }

    abstract class RCPBuilder
    {
        string ds = string.Empty;

        public abstract byte[] CmdToRCP();
        public abstract byte[] CmdToRCP(UInt16 arg);
        public abstract byte[] CmdToRCP(string s);

        public virtual byte[] CmdToRCPExtended()
        {
            byte[] ba = null;
            return ba;
        }
        public virtual string CmdtoDes
        {
            get
            {
                return ds;
            }
        }
        public string ByteArrToString(byte[] ByteArr, bool ArrStyle)
        {
            StringBuilder sb = new StringBuilder();
            string s = "uint8 PHYCHIPS_Arr_";

            if (ArrStyle == false)
            {
                foreach (byte oneByte in ByteArr)
                {
                    sb.Append(oneByte.ToString("X02") + " ");
                }                
            }
            else
            {
                sb.Append(s);
                sb.Append(ScriptToRCP.ArrCnt.ToString()+"[]" + " = ");
                sb.Append("{");
                foreach (byte oneByte in ByteArr)
                {
                    sb.Append("0x");
                    sb.Append(oneByte.ToString("X02") + ", ");                    
                }
                sb.Remove(sb.ToString().LastIndexOf(", "), 2);
                sb.Append("};");
            }
            ScriptToRCP.ArrCnt++;
            return sb.ToString();            
        }
    }

    class StartAutoRead2 : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            byte[] param = new byte[5];

            UInt16 cycle = 0;
            byte mtnu = 100;
            byte mtime = 0;

            param[0] = 0x02; // type C
            param[1] = mtnu; // MTNU
            param[2] = mtime; // MTNU
            param[3] = (byte)((cycle & ((UInt16)0xff00)) >> 8);
            param[4] = (byte)(cycle & ((UInt16)0x00FF));

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STRT_AUTO_READ_EX, param);
        }
        public override byte[] CmdToRCP(UInt16 arg)
        {
            byte[] param = new byte[5];
            byte mtnu = 0;
            byte mtime = 0;

            param[0] = 0x02; // type C
            param[1] = mtnu; // MTNU
            param[2] = mtime; // MTNU
            param[3] = (byte)((arg & ((UInt16)0xff00)) >> 8);
            param[4] = (byte)(arg & ((UInt16)0x00FF));

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STRT_AUTO_READ_EX, param);
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Start Read");
                sb.AppendLine("Start Auto Read");
                sb.AppendLine("cycle(number)");
                sb.AppendLine("Start Read,100");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class StopAutoRead2 : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STOP_AUTO_READ_EX, null);
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Stop Read");
                sb.AppendLine("Stop Auto Read");
                sb.AppendLine("None");
                sb.AppendLine("Stop Read");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class Sleep : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            byte param = 0;
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RD_PWR, new byte[] { param });
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Sleep");
                sb.AppendLine("Set Reader Power Control");
                sb.AppendLine("None");
                sb.AppendLine("Sleep");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class DeepSleep : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            byte param = 1;
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RD_PWR, new byte[]{param});
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Deep Sleep");
                sb.AppendLine("Set Reader Power Control");
                sb.AppendLine("None");
                sb.AppendLine("Deep Sleep");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class GetRegion : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_REGION, null);
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Get Region");
                sb.AppendLine("Get Region Information");
                sb.AppendLine("None");
                sb.AppendLine("Get Region");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class SetRegion : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            byte region = 0x01;
            string[] sa;
            sa = s.Split(',');

            switch (sa[0])
            {
                case "korea":
                    region = 0x11;
                    break;
                case "us":
                    region = 0x21;
                    break;
                case "us2":
                    region = 0x22;
                    break;
                case "europe":
                    region = 0x31;
                    break;
                case "japan":
                    region = 0x41;
                    break;
                case "china1":
                    region = 0x51;
                    break;
                case "china2":
                    region = 0x52;
                    break;
            }
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_REGION, new byte[] { region }); 
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Set Region");
                sb.AppendLine("Set Region Information");
                sb.AppendLine("region(korea, us, us2, europe, japan, china1, china2)");
                sb.AppendLine("Set Region,korea");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class Reset : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RESET, null);
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Reset");
                sb.AppendLine("Set System Reset");
                sb.AppendLine("None");
                sb.AppendLine("Reset");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class GetSelect : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_C_SEL_PARM, null);
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }
        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Get Select");
                sb.AppendLine("Get Type C A/I Select Parameters");
                sb.AppendLine("None");
                sb.AppendLine("Get Select");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class SetSelect : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            string[] sa;
            sa = s.Split(',');

            switch (sa[0])
            {
                case "s0":
                    sa[0] = "0";
                    break;
                case "s1":
                    sa[0] = "1";
                    break;
                case "s2":
                    sa[0] = "2";
                    break;
                case "s3":
                    sa[0] = "3";                    
                    break;
                case "sl":
                    sa[0] = "4";
                    break;
            }

            switch(sa[2])
            {
                case "filetype":
                    sa[2] = "0";
                    break;
                case "epc":
                    sa[2] = "1";
                    break;
                case "tid":
                    sa[2] = "2";
                    break;
                case "file_0":
                    sa[2] = "3";
                    break;                        
            }

            byte[] saVal = new byte[6];

            for (int i = 0; i < saVal.Length; i++)
            {
                saVal[i] = Convert.ToByte(sa[i]);
            }

            byte[] param = new byte[7];
            param[0] = (byte)
                       (
                        +(saVal[0] << 5)
                        +(saVal[1] << 2)
                        +(saVal[2]     )
                       );
            param[1] = 0;
            param[2] = 0;
            param[3] = (byte)((saVal[3] & 0xFF00) >> 8);
            param[4] = (byte)((saVal[3] & 0x00FF));
            param[5] = (byte)(saVal[4]);
            param[6] = 0;

            ByteBuilder bb = new ByteBuilder();
            bb.Append(param);
            bb.Append((byte)(saVal[5]));

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD,RcpProtocol.RCP_CMD_SET_C_SEL_PARM, bb.GetByteArray());
        }
        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Set Select");
                sb.AppendLine("Set Type C A/I Select Parameters");
                sb.AppendLine("Target, Action(h), Memory Bank, Pointer(h), Length(h), Mask(h)");
                sb.AppendLine("Set Select, S0, 000, EPC, 00, 00, 00");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class GetQuery : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_C_QRY_PARM, null);
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Get Query");
                sb.AppendLine("Get Type C A/I Query Parameters");
                sb.AppendLine("None");
                sb.AppendLine("Get Query");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class SetQuery : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            byte[] param = new byte[7];
            byte[] __param = new byte[2];
            string[] sa;
            sa = s.Split(',');

            byte q = 0;

            switch (sa[0])
            {
                case "8":
                    param[0] = (byte)0;
                    break;
                case "64/3":
                    param[0] = (byte)1;
                    break;
                default:
                    param[0] = (byte)1;
                    break;
            }

            param[0] = (byte)(param[0] << 7);

            switch (sa[1])
            {
                case "m1":
                    param[1] = (byte)0;
                    break;
                case "m2":
                    param[1] = (byte)1;
                    break;
                case "m4":
                    param[1] = (byte)2;
                    break;
                case "m8":
                    param[1] = (byte)3;
                    break;
                default:
                    param[1] = (byte)3;
                    break;
            }

            param[1] = (byte)(param[1] << 5);

            switch (sa[2])
            {
                case "enable":
                    param[2] = (byte)1;
                    break;
                case "disable":
                    param[2] = (byte)0;
                    break;
                default:
                    param[2] = (byte)0;
                    break;
            }

            param[2] = (byte)(param[2] << 4);

            switch (sa[3])
            {
                case "all":
                    param[3] = (byte)0;
                    break;
                case "~sl":
                    param[3] = (byte)2;
                    break;
                case "sl":
                    param[3] = (byte)3;
                    break;
                default:
                    param[3] = (byte)0;
                    break;
            }

            param[3] = (byte)(param[3] << 2);

            switch (sa[4])
            {
                case "s0":
                    param[4] = (byte)0;
                    break;
                case "s1":
                    param[4] = (byte)1;
                    break;
                case "s2":
                    param[4] = (byte)2;
                    break;
                case "s3":
                    param[4] = (byte)3;
                    break;
                default:
                    param[4] = (byte)0;
                    break;
            }

            param[4] = (byte)(param[4]);

            __param[0] = (byte)(param[0] + param[1] + param[2] + param[3] + param[4]);

            switch (sa[5])
            {
                case "a":
                    param[5] = (byte)0;
                    break;
                case "b":
                    param[5] = (byte)1;
                    break;
                default:
                    param[5] = (byte)0;
                    break;
            }

            param[5] = (byte)(param[5]<<7);
            q = (byte)(Convert.ToByte(sa[6]) << 3);

            __param[1] = (byte)(param[5] + q);

            ByteBuilder bb = new ByteBuilder();
            bb.Append(__param);
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_C_QRY_PARM, bb.GetByteArray());
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Set Query");
                sb.AppendLine("Set Type C A/I Query Parameters");
                sb.AppendLine("DR,M,TRext,Sel,Session,Target,Q");
                sb.AppendLine("Set Query, 64/3, M8,Disable,All,S0,A,4");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class GetChannel : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_CH, null);
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }
        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Get Channel");
                sb.AppendLine("Get current RF Channel");
                sb.AppendLine("None");
                sb.AppendLine("Get Channel");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class SetChannel : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            byte[] param = new byte[2];
            param[0] = (byte)arg;
            param[1] = 0;

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_CH, param);            
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Set Channel");
                sb.AppendLine("Set current RF Channel");
                sb.AppendLine("channel");
                sb.AppendLine("Set Channel,10");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class GetFHLBT : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_FH_LBT, null);
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }
        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Get FH LBT");
                sb.AppendLine("Get FH and LBT Parameter");
                sb.AppendLine("None");
                sb.AppendLine("Get FH LBT");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class SetFHLBT : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            string[] sa;
            sa = s.Split(',');

            ByteBuilder bb = new ByteBuilder();
            UInt16 read_time;
            UInt16 idle_time;
            UInt16 sense_time;
            float rf_level;

            read_time = UInt16.Parse(sa[0]);
            idle_time = UInt16.Parse(sa[1]);
            sense_time = UInt16.Parse(sa[2]);
            rf_level = float.Parse(sa[3]);

            bb.Append(read_time);
            bb.Append(idle_time);
            bb.Append(sense_time);
            bb.Append((UInt16)(rf_level*10));

            switch (sa[4])
            {
                case "enable":
                    bb.Append((byte)1);                    
                    break;
                case "disable":
                    bb.Append((byte)0);
                    break;
            }

            switch (sa[5])
            {
                case "enable":
                    bb.Append((byte)1);
                    break;
                case "disable":
                    bb.Append((byte)0);
                    break;
            }

            switch (sa[6])
            {
                case "enable":
                    bb.Append((byte)1);
                    break;
                case "disable":
                    bb.Append((byte)0);
                    break;
            }
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD,RcpProtocol.RCP_CMD_SET_FH_LBT,bb.GetByteArray());
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Set FH LBT");
                sb.AppendLine("Set FH and LBT Parameter");
                sb.AppendLine("ReadTime,IdleTime,CW SenseTime, Target RSSI, FH,LBT,CW");
                sb.AppendLine("Set FH LBT,400,100,5,-74,enable,disable,disable");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class GetTxPWR : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_MODULE_TX_PWR, null);
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Get Pwr");
                sb.AppendLine("Get Tx Power Level");
                sb.AppendLine("None");
                sb.AppendLine("Get Pwr");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class SetTxPWR : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            ByteBuilder bb = new ByteBuilder();
            float power = 0f;

            power = (float)Convert.ToDouble(arg);
            bb.Append((UInt16)(power * 10));

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD,RcpProtocol.RCP_CMD_SET_MODULE_TX_PWR ,bb.GetByteArray());
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Set Pwr");
                sb.AppendLine("Set Tx Power Level");
                sb.AppendLine("power");
                sb.AppendLine("Set Pwr,25");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class CWCtrl : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            byte[] bb = null;

            if (s[s.Length - 1] == ',')
            {
                s = s.Substring(0, s.LastIndexOf(','));
            }

            if (s == "on")
            {
                bb = RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_CW, new byte[] { 0xFF });
            }
            else
            {
                bb = RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_CW, new byte[] { 0x00 });
            }
            return bb;
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("CW Ctrl");
                sb.AppendLine("RF CW signal control");
                sb.AppendLine("on,off");
                sb.AppendLine("CW Ctrl,on");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class ReadTypeCUII : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            byte[] param = new byte[5];
            byte mtnu = 0;
            byte mtime = 0;
            byte singlecycle = 1;

            param[0] = 0x02; // type C
            param[1] = mtnu; // MTNU
            param[2] = mtime; // MTNU
            param[3] = (byte)((singlecycle & ((UInt16)0xff00)) >> 8);
            param[4] = (byte)(singlecycle & ((UInt16)0x00FF));

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STRT_AUTO_READ_EX, param);
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Read Type C");
                sb.AppendLine(":Read Type C UII");
                sb.AppendLine("None");
                sb.AppendLine("Read Type C");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class GetTemperature : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_GET_TEMPERATURE, null);
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }
        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Temperature");
                sb.AppendLine("Get Temperature");
                sb.AppendLine("None");
                sb.AppendLine("Temperature");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class GetModulation : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_MODULATION, null);
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }
        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Get Modulation");
                sb.AppendLine("Get Modulation Parameter");
                sb.AppendLine("None");
                sb.AppendLine("Get Modulation");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class SetModulation : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            string[] sa;
            sa = s.Split(',');

            byte blf_MSB, blf_LSB, RxModulation, DR;

            blf_MSB = (byte)((UInt16.Parse(sa[0]) & 0xff00) >> 8);
            blf_LSB = (byte)((UInt16.Parse(sa[0]) & 0x00ff));

            switch (sa[1])
            {
                case "fm0":
                    RxModulation = (byte)0;
                    break;
                case "m2":
                    RxModulation = (byte)1;
                    break;
                case "m4":
                    RxModulation = (byte)2;
                    break;
                case "m8":
                    RxModulation = (byte)3;
                    break;
                default:
                    RxModulation = (byte)3;
                    break;
            }

            switch(sa[2])
            {
                case "8":
                    DR = (byte)0;
                    break;
                case "64/3":
                    DR = (byte)1;
                    break;
                default:
                    DR = (byte)1;
                    break;
            }

            ByteBuilder bb = new ByteBuilder();
            bb.Append((byte)255);
            bb.Append(blf_MSB);
            bb.Append(blf_LSB);
            bb.Append(RxModulation);
            bb.Append(DR);

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_MODULATION, bb.GetByteArray());
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Set Modulation");
                sb.AppendLine("Set Modulation");
                sb.AppendLine("BLF,RXMod,DR");
                sb.AppendLine("Set Modulation,160,m8,64/3");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class GetFHTable : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_HOPPING_TBL, null);
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Get FH Table");
                sb.AppendLine("Get Frequency Hopping Table");
                sb.AppendLine("None");
                sb.AppendLine("Get FH Table");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class SetFHTable : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            if (s[s.Length - 1] == ',')
            {
                s = s.Substring(0, s.LastIndexOf(','));
            }

            string[] sa;
            byte tblSize;
            
            sa = s.Split(',');
            tblSize = (byte)sa.Length;

            ByteBuilder bb = new ByteBuilder();
            bb.Append(tblSize);
            foreach (string val in sa)
            {
                bb.Append(byte.Parse(val));
            }

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD,RcpProtocol.RCP_CMD_SET_HOPPING_TBL,bb.GetByteArray());

            throw new NotImplementedException();
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Set FH Table");
                sb.AppendLine("Set Frequency Hopping Table");
                sb.AppendLine("Channel");
                sb.AppendLine("Set FH Table,1,2,3,4,5,6,7,8,9,10");
                ds = sb.ToString();
                return ds;
            }
        }
    }
    
    class StartAutoReadRSSI : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            byte[] param = new byte[5];

            UInt16 cycle = 100;
            byte mtnu = 0;
            byte mtime = 0;

            param[0] = 0x02; // type C
            param[1] = mtnu; // MTNU
            param[2] = mtime; // MTNU
            param[3] = (byte)((cycle & ((UInt16)0xff00)) >> 8);
            param[4] = (byte)(cycle & ((UInt16)0x00FF));

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STRT_AUTO_READ_RSSI, param);
        }
        public override byte[] CmdToRCP(UInt16 arg)
        {
            byte[] param = new byte[5];
            byte mtnu = 0;
            byte mtime = 0;

            param[0] = 0x02; // type C
            param[1] = mtnu; // MTNU
            param[2] = mtime; // MTNU
            param[3] = (byte)((arg & ((UInt16)0xff00)) >> 8);
            param[4] = (byte)(arg & ((UInt16)0x00FF));

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STRT_AUTO_READ_RSSI, param);
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Start Read RSSI");
                sb.AppendLine("Start Auto Read with Tag RSSI");
                sb.AppendLine("cycle(number)");
                sb.AppendLine("Start Read RSSI,100");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class StopAutoReadRSSI : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STOP_AUTO_READ_RSSI, null);
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Stop Read RSSI");
                sb.AppendLine("Stop Auto Read with Tag RSSI");
                sb.AppendLine("None");
                sb.AppendLine("Stop Read RSSI");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class GetReaderInformation : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            if (s[s.Length - 1] == ',')
            {
                s = s.Substring(0, s.LastIndexOf(','));
            }

            byte b = 0;
            switch (s)
            {
                case "model":
                    b = 0;
                    break;
                case "s/n":
                    b = 1;
                    break;
                case "manufacturer":
                    b = 2;
                    break;
                case "frequency":
                    b = 3;
                    break;
                case "tagtype":
                    b = 4;
                    break;
            }
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_RD_INF, new byte[] { b });
        }
        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Get Reader Info");
                sb.AppendLine("Get Reader Information");
                sb.AppendLine("item(model,s/n,manufacturer, frequency,tagtype)");
                sb.AppendLine("Get Reader Info,manufacturer");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class GetRSSI : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_RSSI, null);
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Get RSSI");
                sb.AppendLine("Get Received signal strength indicator");
                sb.AppendLine("None");
                sb.AppendLine("Get RSSI");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class ScanRSSI : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SCAN_RSSI, null);
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }
    }

    class UpdateRegistry : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            byte b = 1;
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_UPDATE_FLASH, new byte[]{b});
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }
        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Update Registry");
                sb.AppendLine(":Update Registry");
                sb.AppendLine("None");
                sb.AppendLine("Update Registry");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class GetRegistryItem : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            ByteBuilder bb = new ByteBuilder();
            bb.Append((byte)0);
            bb.Append(arg);

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD,RcpProtocol.RCP_GET_REGISTRY_ITEM,bb.GetByteArray());
        }
        public override byte[] CmdToRCP(string s)
        {
            byte[] ba = new byte[2];
            UInt16 i = 0;
            if (s[s.Length - 1] == ',')
            {
                s = s.Substring(0, s.LastIndexOf(','));
            }
            switch (s)
            {
                case "registryversion":
                    i = 0;
                    break;
                case "firmwaredate":
                    i = 1;
                    break;
                case "band":
                    i = 2;
                    break;
                case "txpower":
                    i = 3;
                    break;
                case "fh/lbt":
                    i = 4;
                    break;
                case "anti-collisionmode":
                    i = 5;
                    break;
                case "modulationmode":
                    i = 6;
                    break;
                case "query":
                    i = 7;
                    break;
                case "frequencyhoppingtable":
                    i = 8;
                    break;
                case "txpoweridle":
                    i = 9;
                    break;
            }

            ba[0] = (byte)((i & (UInt16)0xFF00) >> 8);
            ba[1] = (byte)(i & (UInt16)0x00FF);

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_GET_REGISTRY_ITEM, ba);
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Get Registry");
                sb.AppendLine("Get Registry Item");
                sb.AppendLine("item");
                sb.AppendLine("Get Registry,registryversion");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    #region Sleep
    class ScriptSleep : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new GetSleepException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Script Sleep");
                sb.AppendLine("Script Sleep");
                sb.AppendLine("number");
                sb.AppendLine("Script Sleep,1000");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class GetSleepException : Exception
    {

    }
    #endregion

    class ReadTypeCTagData : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            byte mb = 4;

            if (s[s.Length - 1] == ',')
            {
                s = s.Substring(0, s.LastIndexOf(','));
            }

            string[] sa;
            sa = s.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);

            ByteBuilder bb = new ByteBuilder();

            bb.Append(StringHelper.ArgStringHexToByte(sa[0]));

            byte ulMSB;     // length
            byte ulLSB;

            ulMSB = (byte)(StringHelper.ArgStringHexToByte(sa[1]).Length >> (byte)8);
            ulLSB = (byte)(StringHelper.ArgStringHexToByte(sa[1]).Length & 0x00FF);

            bb.Append(ulMSB);
            bb.Append(ulLSB);

            bb.Append(StringHelper.ArgStringHexToByte(sa[1]));


            switch (sa[2])
            {
                case "rfu":
                    mb = 0;
                    break;
                case "epc":
                    mb = 1;
                    break;
                case "tid":
                    mb = 2;
                    break;
                case "uid":
                    mb = 3;
                    break;
            }

            if ( mb > 3 )
            {
                throw new NotImplementedException();
            }

            bb.Append(mb);

            byte saMSB;
            byte saLSB;

            saMSB = (byte)(UInt16.Parse(sa[3]) >> (byte)8);
            saLSB = (byte)(UInt16.Parse(sa[3]) & 0x00FF);

            bb.Append(saMSB);
            bb.Append(saLSB);

            byte LenMSB;
            byte LenLSB;

            LenMSB = (byte)(UInt16.Parse(sa[4]) >> (byte)8);
            LenLSB = (byte)(UInt16.Parse(sa[4]) & 0x00FF);

            bb.Append(LenMSB);
            bb.Append(LenMSB);            

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD,RcpProtocol.RCP_CMD_READ_C_DT, bb.GetByteArray());
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Read Type C Tag Data");
                sb.AppendLine("Read Type C Tag data from specfied memory bank");
                sb.AppendLine("Access Password,EPC(Hex),MB(RFU,EPC,TID,User), Starting Address(Dec),Data Length(Dec)");
                sb.AppendLine("Ex) Read Memory,00000000,E2003411B802011526370494, EPC,0,0");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class WriteTypeCTagData : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            byte mb = 4;

            if (s[s.Length - 1] == ',')
            {
                s = s.Substring(0, s.LastIndexOf(','));
            }

            string[] sa;
            sa = s.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);

            ByteBuilder bb = new ByteBuilder();

            bb.Append(StringHelper.ArgStringHexToByte(sa[0]));

            byte ulMSB;     // length
            byte ulLSB;

            ulMSB = (byte)(StringHelper.ArgStringHexToByte(sa[1]).Length >> (byte)8);
            ulLSB = (byte)(StringHelper.ArgStringHexToByte(sa[1]).Length & 0x00FF);

            bb.Append(ulMSB);
            bb.Append(ulLSB);

            bb.Append(StringHelper.ArgStringHexToByte(sa[1]));


            switch (sa[2])
            {
                case "rfu":
                    mb = 0;
                    break;
                case "epc":
                    mb = 1;
                    break;
                case "tid":
                    mb = 2;
                    break;
                case "uid":
                    mb = 3;
                    break;
            }

            if (mb > 3)
            {
                throw new NotImplementedException();
            }

            bb.Append(mb);

            byte saMSB;
            byte saLSB;

            saMSB = (byte)(UInt16.Parse(sa[3]) >> (byte)8);
            saLSB = (byte)(UInt16.Parse(sa[3]) & 0x00FF);

            bb.Append(saMSB);
            bb.Append(saLSB);

            byte LenMSB;
            byte LenLSB;

            LenMSB = (byte)(StringHelper.ArgStringHexToByte(sa[4]).Length >> (byte)8);
            LenLSB = (byte)(StringHelper.ArgStringHexToByte(sa[4]).Length & 0x00FF);

            bb.Append(LenMSB);
            bb.Append(LenMSB);

            bb.Append(StringHelper.ArgStringHexToByte(sa[4]));

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_WRIT_C_DT, bb.GetByteArray());
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Write Typc C Tag Data");
                sb.AppendLine("Write Type C tag data to specific memory bank");
                sb.AppendLine("Access Password,EPC(Hex),MB(RFU,EPC,TID,User), Starting Address(Dec),Data(Hex)");
                sb.AppendLine("Ex) Write Memory,00000000, E2003411B802011526370494, EPC,0,0");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class BlockWriteTypeC : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            byte mb = 4;

            if (s[s.Length - 1] == ',')
            {
                s = s.Substring(0, s.LastIndexOf(','));
            }

            string[] sa;
            sa = s.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);

            ByteBuilder bb = new ByteBuilder();

            bb.Append(StringHelper.ArgStringHexToByte(sa[0]));

            byte ulMSB;     // length
            byte ulLSB;

            ulMSB = (byte)(StringHelper.ArgStringHexToByte(sa[1]).Length >> (byte)8);
            ulLSB = (byte)(StringHelper.ArgStringHexToByte(sa[1]).Length & 0x00FF);

            bb.Append(ulMSB);
            bb.Append(ulLSB);

            bb.Append(StringHelper.ArgStringHexToByte(sa[1]));


            switch (sa[2])
            {
                case "rfu":
                    mb = 0;
                    break;
                case "epc":
                    mb = 1;
                    break;
                case "tid":
                    mb = 2;
                    break;
                case "uid":
                    mb = 3;
                    break;
            }

            if (mb > 3)
            {
                throw new NotImplementedException();
            }

            bb.Append(mb);

            byte saMSB;
            byte saLSB;

            saMSB = (byte)(UInt16.Parse(sa[3]) >> (byte)8);
            saLSB = (byte)(UInt16.Parse(sa[3]) & 0x00FF);

            bb.Append(saMSB);
            bb.Append(saLSB);

            byte LenMSB;
            byte LenLSB;

            LenMSB = (byte)(StringHelper.ArgStringHexToByte(sa[4]).Length >> (byte)8);
            LenLSB = (byte)(StringHelper.ArgStringHexToByte(sa[4]).Length & 0x00FF);

            bb.Append(LenMSB);
            bb.Append(LenMSB);

            bb.Append(StringHelper.ArgStringHexToByte(sa[4]));

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_BLOCKWRITE_C_DT, bb.GetByteArray());
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Blockwrite Typc C Tag Data");
                sb.AppendLine("Blockwrite Typc C Tag Data");
                sb.AppendLine("Access Password,EPC(Hex),MB(RFU,EPC,TID,User), Starting Address(Dec),Data(Hex)");
                sb.AppendLine("Ex) Block Write,00000000,E2003411B802011526370494,EPC,0,0");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class BlockEraseTypeC : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            byte mb = 4;

            if (s[s.Length - 1] == ',')
            {
                s = s.Substring(0, s.LastIndexOf(','));
            }

            string[] sa;
            sa = s.Split(',');

            ByteBuilder bb = new ByteBuilder();

            bb.Append(StringHelper.ArgStringHexToByte(sa[0]));

            byte ulMSB;     // length
            byte ulLSB;

            ulMSB = (byte)(StringHelper.ArgStringHexToByte(sa[1]).Length >> (byte)8);
            ulLSB = (byte)(StringHelper.ArgStringHexToByte(sa[1]).Length & 0x00FF);

            bb.Append(ulMSB);
            bb.Append(ulLSB);

            bb.Append(StringHelper.ArgStringHexToByte(sa[1]));


            switch (sa[2])
            {
                case "rfu":
                    mb = 0;
                    break;
                case "epc":
                    mb = 1;
                    break;
                case "tid":
                    mb = 2;
                    break;
                case "uid":
                    mb = 3;
                    break;
            }

            if (mb > 3)
            {
                throw new NotImplementedException();
            }

            bb.Append(mb);

            byte saMSB;
            byte saLSB;

            saMSB = (byte)(UInt16.Parse(sa[3]) >> (byte)8);
            saLSB = (byte)(UInt16.Parse(sa[3]) & 0x00FF);

            bb.Append(saMSB);
            bb.Append(saLSB);

            byte LenMSB;
            byte LenLSB;

            LenMSB = (byte)(UInt16.Parse(sa[4]) >> (byte)8);
            LenLSB = (byte)(UInt16.Parse(sa[4]) & 0x00FF);

            bb.Append(LenMSB);
            bb.Append(LenMSB);

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_READ_C_DT, bb.GetByteArray());
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Block Erase Type C Tag Data");
                sb.AppendLine("Block Erase Type C Tag Data");
                sb.AppendLine("Access Password,EPC(Hex),MB(RFU,EPC,TID,User), Starting Address(Dec),Data Length(Dec)");
                sb.AppendLine("Ex) Block Erase,00000000,E2003411B802011526370494, EPC,0,0");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class TestPortEnable : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {            
            throw new NotImplementedException();
        }

        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }

        public override byte[] CmdToRCP(string s)
        {
            TPsetup tp = new TPsetup();            

            byte[] bb = null;

            if (s[s.Length - 1] == ',')
            {
                s = s.Substring(0, s.LastIndexOf(','));
            }

            if (s == "enable")
            {
                tp.RFregSetup(true);
                bb = RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_MODEM_REG, new byte[] { 0xFF, 0xFF, 0x03, 0x28 });
            }
            else
            {
                tp.RFregSetup(false);
                bb = RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_MODEM_REG, new byte[] { 0xFF, 0xFF, 0x03, 0x28 });
            }
            return bb;
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Test Port Enable/Disable");
                sb.AppendLine("testport,enable/disable");
                sb.AppendLine("Ex)tpenable,enable");
                ds = sb.ToString();
                return ds;
            }
        }

        class TPsetup
        {
            public void RFregSetup(bool enable)
            {
                if (enable == true)
                {
                    if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_RF_REG, new byte[] { 0x0F, 0x0F, 0x0F }))) { }

                    System.Threading.Thread.Sleep(20);

                    if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_RF_REG, new byte[] { 0x43, 0x43, 0x7F }))) { }

                    System.Threading.Thread.Sleep(20);
                }
                else
                {
                    if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_RF_REG, new byte[] { 0x0F, 0x0F, 0x00 }))) { }

                    System.Threading.Thread.Sleep(20);

                    if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_RF_REG, new byte[] { 0x43, 0x43, 0x7E }))) { }

                    System.Threading.Thread.Sleep(20);
                }
            }
        }        
    }

    class LeakageMode : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            ByteBuilder bb = new ByteBuilder();
            
            bb.Append(arg);

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, 0xB5, bb.GetByteArray());
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Configure Leakage Mode");
                sb.AppendLine("leakmode, mode(0:disable,1:enable, 2:enable with result report)");
                sb.AppendLine("Ex) leakmode,0");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class SetOptFHTable : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_OPT_FH_TABLE, null);
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Set Opt FH Tbl");
                sb.AppendLine("Set Optimized FH Table");
                sb.AppendLine("None");
                sb.AppendLine("Set Opt FH Tbl");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class SetFHmode : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }

        public override byte[] CmdToRCP(UInt16 arg)
        {
            byte param = (byte)arg;

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_FH_MODE, new byte[] {param});
        }

        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Set FH Mode");
                sb.AppendLine("Set Frequency Hopping Mode");
                sb.AppendLine("mode(1:Optimum mode, 0:Normal mode");
                sb.AppendLine("Set FH Mode,0");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class GetFHmode : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_FH_MODE, null);
        }

        public override byte[] CmdToRCP(UInt16 arg)
        {
            throw new NotImplementedException();
        }

        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Get FH Mode");
                sb.AppendLine("Get Frequency Hopping mode");
                sb.AppendLine("None");
                sb.AppendLine("Get FH Mode");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class SetFHmodeLevel : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }

        public override byte[] CmdToRCP(UInt16 arg)
        {
            byte param = (byte)arg;

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_FH_MODE_REF_LEVEL, new byte[] { param });
        }

        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Set RSSI of Smart hopping");
                sb.AppendLine("Set Tx Leakage RSSI Level for Smart hopping Mode");
                sb.AppendLine("Reference Level(1~255)");
                sb.AppendLine("Set RSSI of Smart hopping,30");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class GetFHmodeLevel : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_FH_MODE_REF_LEVEL, null);
        }

        public override byte[] CmdToRCP(UInt16 arg)
        {
            throw new NotImplementedException();
        }

        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Get RSSI of Smart hopping");
                sb.AppendLine("Get Tx Leakage RSSI Level for Smart hopping Mode");
                sb.AppendLine("None");
                sb.AppendLine("Get RSSI of Smart hopping");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class GetSession : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_SESSION, null);
        }

        public override byte[] CmdToRCP(UInt16 arg)
        {
            throw new NotImplementedException();
        }

        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Get Session");
                sb.AppendLine("Get Current Session");
                sb.AppendLine("None");
                sb.AppendLine("Get Session");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class SetSession : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_SESSION, null);
        }

        public override byte[] CmdToRCP(UInt16 arg)
        {
            throw new NotImplementedException();
        }

        public override byte[] CmdToRCP(string s)
        {
            string[] sa = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            byte[] param = new byte[1];

            switch (sa[0])
            {
                case "s0":
                    param[0] = 0x00;
                    break;
                case "s1":
                    param[0] = 0x01;
                    break;
                case "s2":
                    param[0] = 0x02;
                    break;
                case "s3":
                    param[0] = 0x03;
                    break;
                case "dev":
                    param[0] = 0xF0;
                    break;                
            }
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_SESSION, param);             
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Set Session");
                sb.AppendLine("Set Current Session");
                sb.AppendLine("S0, S1, S2, S3, Dev");
                sb.AppendLine("Set Session,S1");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class GetAntiCol : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_ANTICOL_MODE, null);
        }

        public override byte[] CmdToRCP(UInt16 arg)
        {
            throw new NotImplementedException();
        }

        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Get Anti-Collision Mode");
                sb.AppendLine("Get Anti-Collision algorithm");
                sb.AppendLine("None");
                sb.AppendLine("Get AntiCol");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class SetAntiCol : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();            
        }

        public override byte[] CmdToRCP(UInt16 arg)
        {
            throw new NotImplementedException();
        }

        public override byte[] CmdToRCP(string s)
        {
            string[] sa = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            byte[] param = new byte[4];

            if (sa[0] == "fix")
            {
                param[0] = 0;       //  fixed Q
            }
            else
            {
                param[0] = 1;       //  Dynamic Q
            }
            
            param[1] = Convert.ToByte(sa[1]);
            param[2] = Convert.ToByte(sa[2]);
            param[3] = Convert.ToByte(sa[3]);

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_ANTICOL_MODE, param);         
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Set Anti-Collision Mode");
                sb.AppendLine("Set Anti-Collision algorithm parameter");
                sb.AppendLine("Dynamic/Fix, Start Q, Maximum Q, Minimum Q");
                sb.AppendLine("Set AntiCol,Dynamic,4,7,2");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class StartReadTID : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            byte[] param = new byte[4];

            UInt16 cycle = 100;
            byte mtnu = 0;
            byte mtime = 0;
            
            param[0] = mtnu; // MTNU
            param[1] = mtime; // MTNU
            param[2] = (byte)((cycle & ((UInt16)0xff00)) >> 8);
            param[3] = (byte)(cycle & ((UInt16)0x00FF));

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_READ_C_UII_TID, param);
        }
        public override byte[] CmdToRCP(UInt16 arg)
        {
            byte[] param = new byte[4];

            byte mtnu = 0;
            byte mtime = 0;
            
            param[0] = mtnu; // MTNU
            param[1] = mtime; // MTNU
            param[2] = (byte)((arg & ((UInt16)0xff00)) >> 8);
            param[3] = (byte)(arg & ((UInt16)0x00FF));

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_READ_C_UII_TID, param);
        }
        public override byte[] CmdToRCP(string s)
        {
            throw new NotImplementedException();
        }

        string ds = "";

        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Start Read TID");
                sb.AppendLine("Start Auto Read with Tag RSSI");
                sb.AppendLine("cycle(number)");
                sb.AppendLine("Start Read TID,100");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class BlockPeramLock : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            if (s[s.Length - 1] == ',')
            {
                s = s.Substring(0, s.LastIndexOf(','));
            }

            string[] sa;
            sa = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            ByteBuilder bb = new ByteBuilder();

            bb.Append(StringHelper.ArgStringHexToByte(sa[0]));

            byte ulMSB;     // length
            byte ulLSB;

            ulMSB = (byte)(StringHelper.ArgStringHexToByte(sa[1]).Length >> (byte)8);
            ulLSB = (byte)(StringHelper.ArgStringHexToByte(sa[1]).Length & 0x00FF);

            bb.Append(ulMSB);
            bb.Append(ulLSB);

            bb.Append(StringHelper.ArgStringHexToByte(sa[1]));
            
            bb.Append(Convert.ToByte(sa[2], 16));    //  RFU
            bb.Append(Convert.ToByte(sa[3], 16));    //  R/L
            bb.Append(Convert.ToByte(sa[4], 16));    //  MB
                        
            byte saMSB;
            byte saLSB;

            saMSB = (byte)(UInt16.Parse(sa[5]) >> (byte)8);
            saLSB = (byte)(UInt16.Parse(sa[5]) & 0x00FF);

            bb.Append(saMSB);
            bb.Append(saLSB);

            bb.Append(Convert.ToByte(sa[6],16));    // BR

            byte MaskMSB;
            byte MaskLSB;

            MaskMSB = (byte)(StringHelper.ArgStringHexToByte(sa[7]).Length >> (byte)8);
            MaskLSB = (byte)(StringHelper.ArgStringHexToByte(sa[7]).Length & 0x00FF);

            bb.Append(MaskMSB);
            bb.Append(MaskLSB);
            
            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_PERMALOCK_C, bb.GetByteArray());
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("BlockPermalock Type C Tag");
                sb.AppendLine("BlockPermalock Type C Tag");
                sb.AppendLine("Access Password,EPC(Hex),RFU(Hex),R/L,MB,BP,BR,Mask");
                sb.AppendLine("Ex) Block Permlock,00000000,E2003411B802011526370494,00,01,03,0000,01,FFFF");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class ReadTypeCLongData :RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            byte mb = 4;

            if (s[s.Length - 1] == ',')
            {
                s = s.Substring(0, s.LastIndexOf(','));
            }

            string[] sa;
            sa = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            ByteBuilder bb = new ByteBuilder();

            bb.Append(StringHelper.ArgStringHexToByte(sa[0]));

            byte ulMSB;     // length
            byte ulLSB;

            ulMSB = (byte)(StringHelper.ArgStringHexToByte(sa[1]).Length >> (byte)8);
            ulLSB = (byte)(StringHelper.ArgStringHexToByte(sa[1]).Length & 0x00FF);

            bb.Append(ulMSB);
            bb.Append(ulLSB);

            bb.Append(StringHelper.ArgStringHexToByte(sa[1]));

            switch (sa[2])
            {
                case "rfu":
                    mb = 0;
                    break;
                case "epc":
                    mb = 1;
                    break;
                case "tid":
                    mb = 2;
                    break;
                case "uid":
                    mb = 3;
                    break;
            }

            if (mb > 3)
            {
                throw new NotImplementedException();
            }

            bb.Append(mb);

            byte saMSB;
            byte saLSB;

            saMSB = (byte)(UInt16.Parse(sa[3]) >> (byte)8);
            saLSB = (byte)(UInt16.Parse(sa[3]) & 0x00FF);

            bb.Append(saMSB);
            bb.Append(saLSB);

            byte LenMSB;
            byte LenLSB;

            LenMSB = (byte)(StringHelper.ArgStringHexToByte(sa[4]).Length >> (byte)8);
            LenLSB = (byte)(StringHelper.ArgStringHexToByte(sa[4]).Length & 0x00FF);

            bb.Append(LenMSB);
            bb.Append(LenMSB);

            bb.Append(StringHelper.ArgStringHexToByte(sa[4]));

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_READ_C_DT_EX, bb.GetByteArray());
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Read Type C Tag Long Data");
                sb.AppendLine("Read Type C Tag Long Data/Specific Tag Only");
                sb.AppendLine("Access Password,EPC(Hex),MB(RFU,EPC,TID,User), Starting Address(Dec),Data(Hex)");
                sb.AppendLine("Ex) Read Long Memory,00000000,E2003411B802011526370494,EPC,0,0");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class KillRecom : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            if (s[s.Length - 1] == ',')
            {
                s = s.Substring(0, s.LastIndexOf(','));
            }

            string[] sa;
            sa = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            ByteBuilder bb = new ByteBuilder();

            bb.Append(StringHelper.ArgStringHexToByte(sa[0]));

            byte ulMSB;     // length
            byte ulLSB;

            ulMSB = (byte)(StringHelper.ArgStringHexToByte(sa[1]).Length >> (byte)8);
            ulLSB = (byte)(StringHelper.ArgStringHexToByte(sa[1]).Length & 0x00FF);

            bb.Append(ulMSB);
            bb.Append(ulLSB);

            bb.Append(StringHelper.ArgStringHexToByte(sa[1]));

            bb.Append(StringHelper.ArgStringHexToByte("00"));

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_KILL_RECOM_C, bb.GetByteArray());
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Kill Type C");
                sb.AppendLine("Kill a Tag");
                sb.AppendLine("Kill Password,EPC(Hex)");
                sb.AppendLine("Ex) Kill Type C,AAAAAAAA,E2003411B802011526370494");
                ds = sb.ToString();
                return ds;
            }
        }
    }

    class LockTypeC : RCPBuilder
    {
        public override byte[] CmdToRCP()
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(ushort arg)
        {
            throw new NotImplementedException();
        }
        public override byte[] CmdToRCP(string s)
        {
            if (s[s.Length - 1] == ',')
            {
                s = s.Substring(0, s.LastIndexOf(','));
            }

            string[] sa;
            sa = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            ByteBuilder bb = new ByteBuilder();

            bb.Append(StringHelper.ArgStringHexToByte(sa[0]));

            byte ulMSB;     // length
            byte ulLSB;

            ulMSB = (byte)(StringHelper.ArgStringHexToByte(sa[1]).Length >> (byte)8);
            ulLSB = (byte)(StringHelper.ArgStringHexToByte(sa[1]).Length & 0x00FF);

            bb.Append(ulMSB);
            bb.Append(ulLSB);

            bb.Append(StringHelper.ArgStringHexToByte(sa[1]));            

            byte LDMSB;
            byte LDmid;
            byte LDLSB;

            LDMSB = (byte)(int.Parse(sa[3]) >> (byte)16);
            LDmid = (byte)(int.Parse(sa[3]) >> (byte)8);
            LDLSB = (byte)(int.Parse(sa[3]) & 0x0000FF);

            bb.Append(LDMSB);
            bb.Append(LDmid);
            bb.Append(LDLSB);

            return RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_LOCK_C, bb.GetByteArray());
        }

        string ds = "";
        public override string CmdtoDes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Lock Type C");
                sb.AppendLine("Lock an indicated memory bank in the tag");
                sb.AppendLine("Access Password,EPC(Hex),LD(Hex)");
                sb.AppendLine("Ex) Lock Type C,00000000,E2003411B802011526370494,000000");
                ds = sb.ToString();
                return ds;
            }
        }
    }
}
