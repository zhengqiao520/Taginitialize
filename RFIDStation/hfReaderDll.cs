using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;



[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct HFREADER_OPRESULT{
    public uint srcAddr;
    public uint targetAddr;
    public uint flag;
    public uint errType;
    public uint t;
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct HFREADER_FRAME{
    public uint txLen;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
    public Byte[] txFrame;
    public uint rxLen;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
    public Byte[] rxFrame;
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct HFREADER_CONFIG{
    public HFREADER_OPRESULT result;
    public uint workMode;
    public uint readerAddr;
    public uint cmdMode;
    public uint afiCtrl;
    public uint uidSendMode;
    public uint tagStatus;
    public uint baudrate;
    public uint beepStatus;
    public uint afi;
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct HFREADER_VERSION{
    public HFREADER_OPRESULT result;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
    public Byte[] type;
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
    public Byte[] sv;
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
    public Byte[] hv;
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct HFREADER_IO{
    public HFREADER_OPRESULT result;
    public uint out1State;
	public uint out1Frequent;
	public uint out1Cycle;
    public uint out2State;
	public uint out2Frequent;
	public uint out2Cycle;
    public uint relayState;
	public uint relayFrequent;
	public uint relayCycle;
    public uint in1;
    public uint in2;
    public uint in3;
    public uint in4;
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct HFREADER_ACTIVEFRAME{
    public uint num;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64 * 255)]
    public Byte[] uid;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64 * 255)]
    public Byte[] frame;	
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct ISO14443A_UID{
    public uint type;
    public uint len;   
	public uint sak;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
    public Byte[] uid; 
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct ISO14443A_UIDPARAM{
    public HFREADER_OPRESULT result;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
    public ISO14443A_UID[] uid;
	public uint remainNum;
	public uint num;
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct ISO14443A_BLOCKPARAM{
    public HFREADER_OPRESULT result;
    public ISO14443A_UID uid;
	public uint keyType;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public Byte[] key;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 13 * 16)]
	public Byte[] block;
	public uint addr;
	public uint num;
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct ISO14443A_VALUEPARAM{
    public HFREADER_OPRESULT result;
    public ISO14443A_UID uid;
	public uint keyType;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public Byte[] key;
	public uint opCode;
	public uint blockAddr;
	public uint transAddr;
    public int value;
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct ISO14443A_OPPARAM{
    public HFREADER_OPRESULT result;
    public ISO14443A_UID uid;
	public uint keyType;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public Byte[] key;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
	public Byte[] txFrame;
	public uint txLen;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
	public Byte[] rxFrame;
	public uint rxLen;
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct ISO14443A_DTU{
    public HFREADER_OPRESULT result;
    public ISO14443A_UID uid;
	public uint txBit;
    public uint txLen;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
    public Byte[] txFrame;
	public uint rxBit;
    public uint rxLen;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
    public Byte[] rxFrame;
	public uint timeout;
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct ISO15693_BLOCKPARAM{
    public HFREADER_OPRESULT result;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32 * 4)]
	public Byte[] block;
	public uint addr;
	public uint num;
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct ISO15693_UIDPARAM{
    public HFREADER_OPRESULT result;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25 * 8)]
	public Byte[] uid;
	public uint remainNum;
	public uint num;
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct ISO15693_TAGPARAM{
    public HFREADER_OPRESULT result;
    public uint infoFlag;
    public uint dsfid;
    public uint afi;
    public uint blockNum;
    public uint blockSize;
    public uint ic;
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct ISO15693_DTU{
    public HFREADER_OPRESULT result;
    public uint txLen;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
    public Byte[] txFrame;
    public uint rxLen;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
    public Byte[] rxFrame;
	public uint timeout;
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct ISO14443B_INFO
{
    public HFREADER_OPRESULT result;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public Byte[] pupi;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public Byte[] appField;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public Byte[] protocol;
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct ISO14443B_DTU{
    public HFREADER_OPRESULT result;
    public uint txLen;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
    public Byte[] txFrame;
    public uint rxLen;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
    public Byte[] rxFrame;
	public uint timeout;
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct HFREADER_DTUFRAME
{
	public Byte cmd;
    public uint txLen;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
    public Byte[] txFrame;	
	public uint rxLen;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
    public Byte[] rxFrame;	
	public uint timeout;
};



[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct FELICA_DTU{
    public HFREADER_OPRESULT result;
    public uint txLen;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
    public Byte[] txFrame;
    public uint rxLen;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
    public Byte[] rxFrame;
	public uint timeout;
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct FELICA_UIDPARAM{
    public HFREADER_OPRESULT result;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10 * 16)]
	public Byte[] uid;
	public uint remainNum;
	public uint num;
};


namespace RFIDStation
{
    class hfReaderDll
    {
        public const int HFREADER_VERSION_SIZE = 50;
        public const int HFREADER_BUFFER_MAX = 255;
        public const Byte HFREADER_FRAME_HEAD1 = 0x7E;
        public const Byte HFREADER_FRAME_HEAD2 = 0x55;

        public const Byte HFREADER_FRAME_POS_HEAD1 = 0;
        public const Byte HFREADER_FRAME_POS_HEAD2 = 1;
        public const Byte HFREADER_FRAME_POS_LEN = 2;
        public const Byte HFREADER_FRAME_POS_SRCAddr = 3;
        public const Byte HFREADER_FRAME_POS_DESTADDR = 5;
        public const Byte HFREADER_FRAME_POS_CMD = 7;
        public const Byte HFREADER_FRAME_POS_RFU = 8;
        public const Byte HFREADER_FRAME_POS_PAR = 9;
// 
        public const Byte HFREADER_ANT_MAX_NUM = 6;

        public const Byte HFREADER_ISO14443A_LEN_MAX_UID = 10;
        public const Byte HFREADER_ISO14443A_LEN_SIGNAL_UID = 4;
        public const Byte HFREADER_ISO14443A_LEN_DOUBLE_UID = 7;
        public const Byte HFREADER_ISO14443A_LEN_TRIPLE_UID = 10;
        public const Byte HFREADER_ISO14443A_LEN_M1_KEY = 6;
        public const Byte HFREADER_ISO14443A_LEN_M1BLOCK = 16;
        public const Byte HFREADER_ISO14443A_LEN_M1VALUE = 4;
        public const Byte HFREADER_ISO14443A_LEN_M1SECTOR = 4;
        public const Byte HFREADER_ISO14443A_LEN_M0KEY = 4;
        public const Byte HFREADER_ISO14443A_LEN_M0PCK = 2;
        public const Byte HFREADER_ISO14443A_LEN_M0BLOCK = 4;
        public const Byte HFREADER_ISO14443A_LEN_M0CNT = 3;
        public const Byte HFREADER_ISO14443A_LEN_M0SIG = 32;
        public const Byte HFREADER_ISO14443A_M0U2KEY_LEN = 16;
        public const Byte HFREADER_ISO14443A_TOPAZ_BLOCK_LEN = 8;
        public const Byte HFREADER_ISO14443A_TOPAZ_UID_LEN = 7;

        public const Byte HFREADER_ISO14443A_UID_MAX_NUM = 15;
        public const Byte HFREADER_ISO14443A_MOBLOCKNUM_MAX = 52;
        public const Byte HFREADER_ISO14443A_M1BLOCKNUM_MAX = 13;
        public const Byte HFREADER_ISO14443A_TOPAZBLOCKNUM_MAX = 26;

        public const Byte HFREADER_ISO14443B_MAX_PUPI_SIZE = 0x04;
        public const Byte HFREADER_ISO14443B_MAX_APPLI_SIZE = 0x04;
        public const Byte HFREADER_ISO14443B_MAX_PROTOCOL_SIZE = 0x04;
        public const Byte HFREADER_ISO14443B_SIZE_IDCARD_UID = 8;

        public const Byte HFREADER_FELICA_UID_MAX_NUM = 10;
        public const Byte HFREADER_FELICA_UID_LEN = 16;
        public const Byte HFREADER_FELICA_BLOCK_LEN = 16;

        public const Byte HFREADER_ISO14443A_KEY_A = 0x60;  //AUTHENT A command
        public const Byte HFREADER_ISO14443A_KEY_B = 0x61;   //AUTHENT B command

        public const Byte HFREADER_ISO14443A_REQIDLE = 0x26;  //REQUEST IDLE command
        public const Byte HFREADER_ISO14443A_REQALL = 0x52;   //REQUEST ALL command

        public const Byte HFREADER_ISO14443A_VALUE_INCREMENT = 0xC1;   //INCREMENT command
        public const Byte HFREADER_ISO14443A_VALUE_DECREMENT = 0xC0;   //DECREMENT command
        public const Byte HFREADER_ISO14443A_VALUE_RESTORE = 0xC2;   //RESTORE command

        public const Byte HFREADER_ISO14443A_CMD_ACTIVE_SUID = 0x15;
        public const Byte HFREADER_ISO14443A_CMD_READ_UID = 0x16;

        public const Byte HFREADER_ISO14443A_CMD_AUTHRB = 0x70;
        public const Byte HFREADER_ISO14443A_CMD_AUTHWB = 0x71;
        public const Byte HFREADER_ISO14443A_CMD_AUTHRV = 0x72;
        public const Byte HFREADER_ISO14443A_CMD_AUTHWV = 0x73;
        public const Byte HFREADER_ISO14443A_CMD_AUTHV = 0x74;
        public const Byte HFREADER_ISO14443A_CMD_RM0BLOCK = 0x75;
        public const Byte HFREADER_ISO14443A_CMD_WM0BLOCK = 0x76;
        public const Byte HFREADER_ISO14443A_CMD_RATS = 0x77;
        public const Byte HFREADER_ISO14443A_CMD_PCTRLESAM = 0x78;  //ESAM控制
        public const Byte HFREADER_ISO14443A_CMD_APDU = 0x7A;
        public const Byte HFREADER_ISO14443A_CMD_HALT = 0x7B;
        public const Byte HFREADER_ISO14443A_CMD_DESEL = 0x7C;
        public const Byte HFREADER_ISO14443A_CMD_DTU = 0x7F;


        //NTag定制命令
        public const Byte HFREADER_ISO14443A_CMD_RM0SIG = 0x80;
        public const Byte HFREADER_ISO14443A_CMD_M0AUTH = 0x81;
        public const Byte HFREADER_ISO14443A_CMD_RM0CNT = 0x82;


        public const Byte HFREADER_ISO14443A_SIZE_UID = 14;

        public const Byte HFREADER_ISO15693_CMD_ACTIVE_SUID = 0x10;
        public const Byte HFREADER_ISO15693_CMD_READ_UID = 0x11;
        public const Byte HFREADER_ISO15693_CMD_ACTIVE_EAS = 0x13;
// 
        public const Byte HFREADER_ISO15693_CMD_READ_MBLOCK = 0x22;
        public const Byte HFREADER_ISO15693_CMD_WRITE_MBLOCK = 0x23;
        public const Byte HFREADER_ISO15693_CMD_LOCK_BLOCK = 0x2C;

        public const Byte HFREADER_ISO15693_CMD_WRITE_AFI = 0x24;
        public const Byte HFREADER_ISO15693_CMD_LOCK_AFI = 0x25;
        public const Byte HFREADER_ISO15693_CMD_WRITE_DSFID = 0x26;
        public const Byte HFREADER_ISO15693_CMD_LOCK_DSFID = 0x27;
        public const Byte HFREADER_ISO15693_CMD_READ_TAGINF = 0x28;
        public const Byte HFREADER_ISO15693_CMD_SET_EAS = 0x29;
        public const Byte HFREADER_ISO15693_CMD_RESET_EAS = 0x2A;
        public const Byte HFREADER_ISO15693_CMD_LOCK_EAS = 0x2B;
         public const Byte HFREADER_ISO15693_CMD_DTU = 0x2F;
        public const Byte HFREADER_FRAME_MAX_NUM = 64;

        public const Byte HFREADER_ISO15693_MAX_BLOCK_NUM = 32;
        public const Byte HFREADER_ISO15693_MAX_UID_NUM = 25;

        public const Byte HFREADER_ISO15693_SIZE_BLOCK = 4;
        public const Byte HFREADER_ISO15693_SIZE_UID = 8;


        public const Byte HFREADER_FRAME_CMD_SET_CFG = 0xF4;
        public const Byte HFREADER_FRAME_CMD_GET_CFG = 0xF5;
        public const Byte HFREADER_FRAME_CMD_RF_CTRL = 0xF0;
        public const Byte HFREADER_FRAME_CMD_TRIGGLE_CTRL = 0xF1;
        public const Byte HFREADER_FRAME_CMD_SET_IO = 0xE9;
        public const Byte HFREADER_FRAME_CMD_GET_I = 0xE6;
        public const Byte HFREADER_FRAME_CMD_CFG_IO = 0xEA;

        public const Byte HFREADER_CFG_WM_EAS = 1;
        public const Byte HFREADER_CFG_WM_INVENTORY = 2;
        public const Byte HFREADER_CFG_WM_MASK = 0x0F;
        public const Byte HFREADER_CFG_TYPE_ISO15693 = 0x00;
        public const Byte HFREADER_CFG_TYPE_ISO14443A = 0x10;
        public const Byte HFREADER_CFG_TYPE_ISO14443B = 0x20;
        public const Byte HFREADER_CFG_TYPE_FELICA = 0x30;
        public const Byte HFREADER_CFG_TYPE_NFCTYPE2TAG = 0xE0;
        public const Byte HFREADER_CFG_TYPE_MASK = 0xF0;

        public const Byte HFREADER_CFG_BAUDRATE9600 = 5;
        public const Byte HFREADER_CFG_BAUDRATE38400 = 7;
        public const Byte HFREADER_CFG_BAUDRATE115200 = 11;

        public const Byte HFREADER_CFG_TAG_QUIET = 0;
        public const Byte HFREADER_CFG_TAG_NOQUIET = 1;

        public const Byte HFREADER_CFG_UID_ACTIVE = 0;
        public const Byte HFREADER_CFG_UID_POSITIVE = 1;

        public const Byte HFREADER_CFG_AFI_DISABLE = 0;
        public const Byte HFREADER_CFG_AFI_ENABLE = 1;

        public const Byte HFREADER_CFG_INVENTORY_AUTO = 0;
        public const Byte HFREADER_CFG_INVENTORY_TRIGGER = 1;

        public const Byte HFREADER_CFG_QUERY_ENABLE = 0;
        public const Byte HFREADER_CFG_QUERY_DISABLE = 1;

        public const Byte HFREADER_CFG_BUZZER_ENABLE = 1;
        public const Byte HFREADER_CFG_BUZZER_DISABLE = 0;

        public const Byte HFREADER_RF_CLOSE = 0;
        public const Byte HFREADER_RF_OPEN = 1;
        public const Byte HFREADER_RF_RESET = 2;


        public const Byte HFREADER_READ_UID_NORMAL = 0x00;
        public const Byte HFREADER_READ_UID_REPEAT = 0x01;

        public const Byte HFREADER_TRG_INVENTORY = 0x01;
        public const Byte HFREADER_TRG_NO = 0x00;

//         public const Byte HFREADER_TIMEOUT = 200;

        //public static int hr2000Device;
        ///<summary>
        /// API LoadLibrary
        ///</summary>
        [DllImport("Kernel32")]
        public static extern int LoadLibrary(String funcname);

        ///<summary>
        /// API GetProcAddress
        ///</summary>
        [DllImport("Kernel32")]
        public static extern int GetProcAddress(int handle, String funcname);

        ///<summary>
        /// API FreeLibrary
        ///</summary>
        [DllImport("Kernel32")]
        public static extern int FreeLibrary(int handle);



        ///<summary>
        ///通过非托管函数名转换为对应的委托, by jingzhongrong
        ///</summary>
        ///<param name="dllModule">通过LoadLibrary获得的DLL句柄</param>
        ///<param name="functionName">非托管函数名</param>
        ///<param name="t">对应的委托类型</param>
        ///<returns>委托实例，可强制转换为适当的委托类型</returns>
        public static Delegate GetFunctionAddress(int dllModule, string functionName, Type t)
        {
            int address = GetProcAddress(dllModule, functionName);
            if (address == 0)
            {
                return null;
            }
            else
            {
                return Marshal.GetDelegateForFunctionPointer(new IntPtr(address), t);
            }
        }

        ///<summary>
        ///将表示函数地址的IntPtr实例转换成对应的委托
        ///</summary>
        public static Delegate GetDelegateFromIntPtr(IntPtr address, Type t)
        {
            if (address == IntPtr.Zero)
            {
                return null;
            }
            else
            {
                return Marshal.GetDelegateForFunctionPointer(address, t);
            }
        }

        ///<summary>
        ///将表示函数地址的int转换成对应的委托
        ///</summary>
        public static Delegate GetDelegateFromIntPtr(int address, Type t)
        {
            if (address == 0)
            {
                 return null;
            }
            else
            {
                return Marshal.GetDelegateForFunctionPointer(new IntPtr(address), t);
            }
        }


        [DllImport("HFReader.dll", EntryPoint = "hfReaderOpenPort")]
        public static extern int hfReaderOpenPort(String name, String baudrate);

        [DllImport("HFReader.dll", EntryPoint = "hfReaderClosePort")]
        public static extern int hfReaderClosePort(int h);

        [DllImport("HFReader.dll", EntryPoint = "hfReaderOpenUsb")]
        public static extern int hfReaderOpenUsb(ushort vid, ushort pid);

        [DllImport("HFReader.dll", EntryPoint = "hfReaderCloseUsb")]
        public static extern int hfReaderCloseUsb(int h);

        [DllImport("HFReader.dll", EntryPoint = "hfReaderSetConfig")]
        public static extern int hfReaderSetConfig(int h, ushort srcAddr, ushort targetAddr, ref HFREADER_CONFIG pConfig, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "hfReaderGetConfig")]
        public static extern int hfReaderGetConfig(int h, ushort srcAddr, ushort targetAddr, ref HFREADER_CONFIG pConfig, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "hfReaderDefaultConfig")]
        public static extern int hfReaderDefaultConfig(int h, ushort srcAddr, ushort targetAddr, ref HFREADER_CONFIG pConfig, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "hfReaderCtrlRf")]
        public static extern int hfReaderCtrlRf(int h, ushort srcAddr, ushort targetAddr, Byte rfCtrl, ref HFREADER_OPRESULT pResult, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "hfReaderTrigger")]
        public static extern int hfReaderTrigger(int h, ushort srcAddr, ushort targetAddr, Byte triggerCtrl, ref HFREADER_OPRESULT pResult, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "hfReaderSetIo")]
        public static extern int hfReaderSetIo(int h, ushort srcAddr, ushort targetAddr, ref HFREADER_IO pIo, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "hfReaderGetIo")]
        public static extern int hfReaderGetIo(int h, ushort srcAddr, ushort targetAddr, ref HFREADER_IO pIo, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "hfReaderCfgIo")]
        public static extern int hfReaderCfgIo(int h, ushort srcAddr, ushort targetAddr, ref HFREADER_IO pIo, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "hfReaderReceive")]
        public static extern int hfReaderReceive(int h, ref HFREADER_ACTIVEFRAME pReceiveFrame);

        [DllImport("HFReader.dll", EntryPoint = "hfReaderGetVersion")]
        public static extern int hfReaderGetVersion(int h, ushort srcAddr, ushort targetAddr, ref HFREADER_VERSION pVersion, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "hfReaderSetVersion")]
        public static extern int hfReaderSetVersion(int h, ushort srcAddr, ushort targetAddr, ref HFREADER_VERSION pVersion, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "hfReaderSelectAnt")]
        public static extern int hfReaderSelectAnt(int h, ushort srcAddr, ushort targetAddr, Byte[] pAnt, ref HFREADER_OPRESULT pResult, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "hfReaderDtu")]
        public static extern int hfReaderDtu(int h, ushort srcAddr, ushort targetAddr, ref HFREADER_DTUFRAME pDtu, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443AGetUID")]
        public static extern int iso14443AGetUID(int h, ushort srcAddr, ushort targetAddr, Byte mode, ref ISO14443A_UIDPARAM pUid, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443AAuthReadM1Block")]
        public static extern int iso14443AAuthReadM1Block(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_BLOCKPARAM pBlock, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443AAuthWriteM1Block")]
        public static extern int iso14443AAuthWriteM1Block(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_BLOCKPARAM pBlock, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443AAuthReadM1Value")]
        public static extern int iso14443AAuthReadM1Value(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_VALUEPARAM pValue, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443AAuthWriteM1Value")]
        public static extern int iso14443AAuthWriteM1Value(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_VALUEPARAM pValue, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443AAuthOpM1Value")]
        public static extern int iso14443AAuthOpM1Value(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_VALUEPARAM pValue, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443AReadM0Block")]
        public static extern int iso14443AReadM0Block(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_BLOCKPARAM pBlock, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443AWriteM0Block")]
        public static extern int iso14443AWriteM0Block(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_BLOCKPARAM pBlock, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443AReadTopazBlock")]
        public static extern int iso14443AReadTopazBlock(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_BLOCKPARAM pBlock, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443AWriteTopazBlock")]
        public static extern int iso14443AWriteTopazBlock(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_BLOCKPARAM pBlock, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443ARats")]
        public static extern int iso14443ARats(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_OPPARAM pOpInfo, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443ACtrlEsam")]
        public static extern int iso14443ACtrlEsam(int h, ushort srcAddr, ushort targetAddr, Byte index, Byte state, ref ISO14443A_OPPARAM pOpInfo, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443AApdu")]
        public static extern int iso14443AApdu(int h, ushort srcAddr, ushort targetAddr, Byte index, ref ISO14443A_OPPARAM pOpInfo, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443AHalt")]
        public static extern int iso14443AHalt(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_OPPARAM pOpInfo, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443ADsel")]
        public static extern int iso14443ADsel(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_OPPARAM pOpInfo, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443ADtu")]
        public static extern int iso14443ADtu(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_DTU pDtu, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443AReadM0Cnt")]
        public static extern int iso14443AReadM0Cnt(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_OPPARAM pOpInfo, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443AReadM0Sig")]
        public static extern int iso14443AReadM0Sig(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_OPPARAM pOpInfo, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443AAuthM0")]
        public static extern int iso14443AAuthM0(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_OPPARAM pOpInfo, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443AAuthUltralightC")]
        public static extern int iso14443AAuthUltralightC(int h, ushort srcAddr, ushort targetAddr, Byte[] pKey, ref HFREADER_OPRESULT pResult, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "emulNfcType2SetUID")]
        public static extern int emulNfcType2SetUID(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_UID pUid, ref HFREADER_OPRESULT pResult, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "emulNfcType2GetUID")]
        public static extern int emulNfcType2GetUID(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_UID pUid, ref HFREADER_OPRESULT pResult, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "emulNfcType2WriteBlock")]
        public static extern int emulNfcType2WriteBlock(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_BLOCKPARAM pBlock, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "emulNfcType2ReadBlock")]
        public static extern int emulNfcType2ReadBlock(int h, ushort srcAddr, ushort targetAddr, ref ISO14443A_BLOCKPARAM pBlock, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso15693GetUid")]
        public static extern int iso15693GetUid(int h, ushort srcAddr, ushort targetAddr, Byte mode, ref ISO15693_UIDPARAM pUid, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso15693ReadBlock")]
        public static extern int iso15693ReadBlock(int h, ushort srcAddr, ushort targetAddr, Byte[] pUid, ref ISO15693_BLOCKPARAM pReadBlock, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso15693WriteBlock")]
        public static extern int iso15693WriteBlock(int h, ushort srcAddr, ushort targetAddr, Byte[] pUid, ref ISO15693_BLOCKPARAM pWriteBlock, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso15693LockBlock")]
        public static extern int iso15693LockBlock(int h, ushort srcAddr, ushort targetAddr, Byte[] pUid, Byte blockAddr, ref HFREADER_OPRESULT pResult, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso15693WriteAfi")]
        public static extern int iso15693WriteAfi(int h, ushort srcAddr, ushort targetAddr, Byte[] pUid, Byte afi, ref HFREADER_OPRESULT pResult, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso15693LockAfi")]
        public static extern int iso15693LockAfi(int h, ushort srcAddr, ushort targetAddr, Byte[] pUid, ref HFREADER_OPRESULT pResult, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso15693WriteDsfid")]
        public static extern int iso15693WriteDsfid(int h, ushort srcAddr, ushort targetAddr, Byte[] pUid, Byte defid, ref HFREADER_OPRESULT pResult, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso15693LockDsfid")]
        public static extern int iso15693LockDsfid(int h, ushort srcAddr, ushort targetAddr, Byte[] pUid, ref HFREADER_OPRESULT pResult, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso15693ReadTagInfo")]
        public static extern int iso15693ReadTagInfo(int h, ushort srcAddr, ushort targetAddr, Byte[] pUid, ref ISO15693_TAGPARAM pTagInfo, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso15693SetEas")]
        public static extern int iso15693SetEas(int h, ushort srcAddr, ushort targetAddr, Byte[] pUid, Byte cmd, ref HFREADER_OPRESULT pResult, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso15693Dtu")]
        public static extern int iso15693Dtu(int h, ushort srcAddr, ushort targetAddr, ref ISO15693_DTU pDtu, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso15693OpTagsRUidAndBlock")]
        public static extern int iso15693OpTagsRUidAndBlock(int h, ushort srcAddr, ushort targetAddr, Byte[] addr, Byte num, Byte[] pUid, Byte[] pBlock, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443BSelect")]
        public static extern int iso14443BSelect(int h, ushort srcAddr, ushort targetAddr, Byte mode, ref ISO14443B_INFO pInfo, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443BGetIDCardUid")]
        public static extern int iso14443BGetIDCardUid(int h, ushort srcAddr, ushort targetAddr, Byte[] pUid, ref HFREADER_OPRESULT pResult, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443BHalt")]
        public static extern int iso14443BHalt(int h, ushort srcAddr, ushort targetAddr, ref HFREADER_OPRESULT pResult, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "iso14443BDtu")]
        public static extern int iso14443BDtu(int h, ushort srcAddr, ushort targetAddr, ref ISO14443B_DTU pDtu, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "felicaGetUID")]
        public static extern int felicaGetUID(int h, ushort srcAddr, ushort targetAddr, Byte mode, ref FELICA_UIDPARAM pUid, Byte[] pTxFrame, Byte[] pRxFrame);

        [DllImport("HFReader.dll", EntryPoint = "felicaDtu")]
        public static extern int felicaDtu(int h, ushort srcAddr, ushort targetAddr, ref FELICA_DTU pDtu, Byte[] pTxFrame, Byte[] pRxFrame);
    }
}



