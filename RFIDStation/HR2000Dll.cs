using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

public struct OGeneralCmdType
{
    public uint SrcAddr;
    public uint TargetAddr;
    public uint Flag;
    public uint ErrType;
};

// GetReaderConfig output 
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct OGetReaderConfig
{
    public uint SrcAddr;
    public uint TargetAddr;
    public uint WorkMode;
    public uint ReaderAddr;
    public uint cmdMode;
    public uint AFICtrl;
    public uint UIDSendMode;
    public uint tagStatus;
    public uint baudrate;
    public uint BeepStatus;
    public uint AFI;
};

// GetUIDInField output
[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public struct OGetUIDInFieldType
{
    public uint SrcAddr;
    public uint TargetAddr;
    public uint UIDSum;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 800)]
    public Byte[] UIDArr;
    public uint remainUIDSum;
};

// FindInterfaceEvent output
public struct OFindInterfaceEventType
{
    public uint SrcAddr;
    public uint TargetAddr;
    public uint IN1;
    public uint IN2;
    public uint IN3;
    public uint IN4;
};

// ReadBlock output
[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public struct OReadBlockType
{
    public uint SrcAddr;
    public uint TargetAddr;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public Byte[] BlockData;
    public uint Flag;
    public uint ErrType;
};

// ReadMBlock output
[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public struct OReadMBlockType
{
    public uint SrcAddr;
    public uint TargetAddr;
    public uint BlockSum;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 400)]
    public Byte[] BlockDataArr;
    public uint Flag;
    public uint ErrType;
};
// ReadLblSysInfo output
public struct OReadLblSysInfoType
{
    public uint SrcAddr;
    public uint TargetAddr;
    public uint Flag;
    public uint ErrType;
    public uint InfoFlag;
    public uint DSFID;
    public uint AFI;
    public uint BlockSum;
    public uint LblSize;
    public uint IC;
};

// GeneralInfoOutput (读写器主动上报的数据，如：标签进入；eas报警;）
[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public struct OGeneralInfoOutputType
{
    public uint SrcAddr;
    public uint TargetAddr;
    public uint Cmd;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public Byte[] uidArr;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
    public Byte[] dataArr;
};

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public struct OGeneralInfoOutputPackageType
{
    public uint cmdSum;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
    public OGeneralInfoOutputType[] cmdArr;     //最多可以接收256个帧
};

//[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public struct iso14443aUid
{
    public uint type;
    public uint len;
    public uint sak;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
    public Byte[] uid;
};

public struct ORcvISO14443AUID
{
    public iso14443aUid uid;
    public uint srcAddr;
    public uint targetAddr;
};

//[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public struct OGetISO14443AUID
{
    public uint remainNum;
    public uint num;
    public uint srcAddr;
    public uint targetAddr;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
    public iso14443aUid[] uid;

};

//[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public struct ORWISO14443ABlock
{
    public iso14443aUid uid;
    public uint keyType;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
    public byte[] key;
    public uint blockNum;
    public uint blockAddr;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
    public byte[] block;
    public uint srcAddr;
    public uint targetAddr;
    public uint flag;
    public uint err;
};

//[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public struct ORWISO14443AValue
{
    public iso14443aUid uid;
    public uint keyType;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
    public byte[] key;
    public uint blockAddr;
    public uint transAddr;
    public int value;
    public uint srcAddr;
    public uint targetAddr;
    public uint flag;
    public uint err;
};

//[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public struct OOpISO14443AValue
{
    public iso14443aUid uid;
    public uint keyType;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
    public byte[] key;
    public uint opCode;
    public uint blockAddr;
    public uint transAddr;
    public int value;
    public uint srcAddr;
    public uint targetAddr;
    public uint flag;
    public uint err;
};


public struct ORISO14443AInfo{
    public iso14443aUid uid;
    public uint keyType;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
    public byte[] key;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
    public byte[] info;
    public uint srcAddr;
    public uint targetAddr;
    public uint flag;
    public uint err;
};


namespace RFIDStation
{
    class HR2000Dll
    {
        public const Byte HR2000_ISO15693CMD_ACTIVE_SUID = 0x10;
        public const Byte HR2000_ISO15693CMD_READ_UID = 0x11;
        public const Byte HR2000_ISO15693CMD_ACTIVE_SEAS = 0x13;

        public const Byte HR2000_ISO15693CMD_READ_SBLOCK = 0x20;
        public const Byte HR2000_ISO15693CMD_WRITE_SBLOCK = 0x21;
        public const Byte HR2000_ISO15693CMD_READ_MBLOCK = 0x22;
        public const Byte HR2000_ISO15693CMD_WRITE_MBLOCK = 0x23;
        public const Byte HR2000_ISO15693CMD_LOCK_BLOCK = 0x2C;

        public const Byte HR2000_ISO15693CMD_READ_MBLOCKEX = 0x32;
        public const Byte HR2000_ISO15693CMD_WRITE_MBLOCKEX = 0x33;
        public const Byte HR2000_ISO15693CMD_WRITE_AFI = 0x24;
        public const Byte HR2000_ISO15693CMD_LOCK_AFI = 0x25;
        public const Byte HR2000_ISO15693CMD_WRITE_DSFID = 0x26;
        public const Byte HR2000_ISO15693CMD_LOCK_DSFID = 0x27;
        public const Byte HR2000_ISO15693CMD_GETINFO = 0x28;
        public const Byte HR2000_ISO15693CMD_SET_EAS = 0x29;
        public const Byte HR2000_ISO15693CMD_RESET_EAS = 0x2A;
        public const Byte HR2000_ISO15693CMD_LOCK_EAS = 0x2B;

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

        public const Byte HR2000_CFG_TYPE_MASK = 0xF0;
        public const Byte HR2000_CFG_TYPE_ISO15693 = 0x00;
        public const Byte HR2000_CFG_TYPE_ISO14443A = 0x10;
        public const Byte HR2000_CFG_WORKMODE_MASK = 0x0F;
        public const Byte HR2000_CFG_WORKMODE_EAS = 0x01;
        public const Byte HR2000_CFG_WORKMODE_INVENTORY = 0x02;
        public const Byte HR2000_CFG_CMDMODE_AUTO = 0x00;
        public const Byte HR2000_CFG_CMDMODE_TRG = 0x01;
        public const Byte HR2000_CFG_SENDUIDMODE_ACTIVE = 0x00;
        public const Byte HR2000_CFG_SENDUIDMODE_POSITIVE = 0x01;
        public const Byte HR2000_CFG_BEEP_DISABLE = 0x00;
        public const Byte HR2000_CFG_BEEP_ENABLE = 0x01;
        public const Byte HR2000_CFG_AFI_DISABLE = 0x00;
        public const Byte HR2000_CFG_AFI_ENABLE = 0x01;
        public const Byte HR2000_CFG_TAG_QUIET = 0x00;
        public const Byte HR2000_CFG_TAG_NOQUIET = 0x01;
        public const Byte HR2000_CFG_BR_9600 = 0x05;
        public const Byte HR2000_CFG_BR_38400 = 0x07;
        public const Byte HR2000_CFG_BR_115200 = 0x0B;

        ///<summary>
        ///打开与HR2000通信的串口
        ///</summary>
        ///<param name="name">串口名称:COMx</param>
        ///<param name="baudrate">串口的波特率:9600/38400/115200</param>
        [DllImport("HR2000.dll", EntryPoint = "OpenPort")]
        public static extern int openPort(String name, String baudrate);

        ///<summary>
        ///关闭与HR2000通信的串口
        ///</summary>
        ///<param name="device">打开串口时获取的设备ID</param>
        [DllImport("HR2000.dll", EntryPoint = "ClosePort")]
        public static extern int closePort(int device);

        ///<summary>
        ///设置HR2000的工作参数，这些工作参数掉电不丢失
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="WorkMode", dir="输入">HR2000的工作模式：EAS(0x01)，Inventory(0x02)</param>
        ///<param name="ReaderAddr", dir="输入">重新设置的读写器地址，设备出厂地址是0x0001</param>
        ///<param name="cmdMode", dir="输入">HR2000的命令模式：自动（0x00），触发（0x01）</param>
        ///<param name="AFICtrl", dir="输入">HR2000的AFI模式：禁止（0x00），使能（0x01）</param>
        ///<param name="UIDSendMode", dir="输入">UID发送模式：主动（0x00），被动（0x01）</param>
        ///<param name="tagStatus", dir="输入">标签状态：静默（0x00），不静默（0x01）</param>
        ///<param name="baudrate", dir="输入">HR2000串口波特率：9600（0x05），38400（0x07），115200（0x0B）</param>
        ///<param name="BeepStatus", dir="输入">蜂鸣器状态：禁止（0x00），使能（0x01）</param>
        ///<param name="AFI", dir="输入">AFI值，当AFI模式是“禁止”时，AFI值无意义</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000返回的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "SetReaderConfig")]
        public static extern int setReaderConfig(int device, ushort SrcAddr, ushort TargetAddr,
                                                 Byte WorkMode, ushort ReaderAddr, Byte cmdMode, Byte AFICtrl,
                                                 Byte UIDSendMode, Byte tagStatus, Byte baudrate, Byte BeepStatus,
                                                 Byte AFI, ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);
        ///<summary>
        ///获取HR2000的工作参数
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="pGetReaderConfig", dir="输出">HR2000返回的读写器的配置信息</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "GetReaderConfig")]
        public static extern int getReaderConfig(int device, ushort SrcAddr, ushort TargetAddr,
                                                 ref OGetReaderConfig pGetReaderConfig, Byte[] pSendBuf, Byte[] pRecBuf);

        ///<summary>
        ///设置HR2000的默认工作参数
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="ReaderAddr", dir="输入">阅读器地址：默认是0x0001</param>
        ///<param name="pGeneralCmdType", dir="输出">HR2000返回的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "SetDefaultReaderConfig")]
        public static extern int setDefaultReaderConfig(int device, ushort SrcAddr, ushort TargetAddr, ushort ReaderAddr,
                                                        ref OGeneralCmdType pGeneralCmdType, Byte[] pSendBuf, Byte[] pRecBuf);

        public const Byte HR2000_RFCTRL_CLOSE = 0x00;
        public const Byte HR2000_RFCTRL_OPEN = 0x01;
        public const Byte HR2000_RFCTRL_RESET = 0x02;
        ///<summary>
        ///设置阅读器射频天线状态
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="RFStatus", dir="输入">射频天线状态：关闭（0x00），开启（0x01），复位（0x02：关闭20ms，然后再开启）</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000设置标签EAS的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "SetRFCtrl")]
        public static extern int setRFCtrl(int device, ushort SrcAddr, ushort TargetAddr, Byte RFStatus,
                                      ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);

        public const Byte HR2000_TRG_NO = 0x00;
        public const Byte HR2000_TRG_INVENTORY = 0x01;
        ///<summary>
        ///触发寻卡
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="Trigger", dir="输入">触发：无效（0x00），触发寻卡（0x01）</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000设置标签EAS的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "SetTriggerCtrl")]
        public static extern int setTriggerCtrl(int device, ushort SrcAddr, ushort TargetAddr, Byte Trigger,
                                      ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);


        public const Byte HR2000_GETUID_MODE_NORMAL = 0x00;
        public const Byte HR2000_GETUID_MODE_REPEAT = 0x01;
        ///<summary>
        ///获取HR2000无线场内标签的UID
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="param", dir="输入">工作参数：普通（0x00），重读（0x01）</param>
        ///<param name="pGetUIDInField", dir="输出">HR2000获取的标签UID信息</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "GetUIDInField")]
        public static extern int getUIDInField(int device, ushort SrcAddr, ushort TargetAddr,
                                               Byte param, ref OGetUIDInFieldType pGetUIDInField, Byte[] pSendBuf, Byte[] pRecBuf);


        ///<summary>
        ///获取HR2000主动上传的无线场内标签的UID
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="pGeneralInfoOutputPkg", dir="输出">HR2000获取的标签UID信息</param>
        [DllImport("HR2000.dll", EntryPoint = "Receive")]
        public static extern int receive(int device, ref OGeneralInfoOutputPackageType pGeneralInfoOutputPkg);


        ///<summary>
        ///读取标签单个数据块内的数据
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="FstAddr", dir="输入">数据块地址</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<param name="pReadBlock", dir="输出">HR2000获取的标签单个数据块内的数据信息</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "ReadBlock")]
        public static extern int readBlock(int device, ushort SrcAddr, ushort TargetAddr, Byte FstAddr, Byte[] UID,
                                           ref OReadBlockType pReadBlock, Byte[] pSendBuf, Byte[] pRecBuf);

        ///<summary>
        ///向标签单个数据块内写入数据
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="FstAddr", dir="输入">数据块地址</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<paam name="dataStr", dir="输入">写入的数据，注意：输入的数据是字符串形式（“001122AA”）</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000写标签数据的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "WriteBlock")]
        public static extern int writeBlock(int device, ushort SrcAddr, ushort TargetAddr, Byte FstAddr, Byte[] UID,
                                           Byte[] dataStr, ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);

        ///<summary>
        ///锁定标签单个数据块内的数据，注意：被锁定的数据块永久性不能写入数据
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="FstAddr", dir="输入">数据块地址</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000锁定标签数据块的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "LockBlock")]
        public static extern int lockBlock(int device, ushort SrcAddr, ushort TargetAddr, Byte FstAddr, Byte[] UID,
                                           ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);


        ///<summary>
        ///读取标签多个数据块内的数据
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="FstAddr", dir="输入">数据块地址</param>
        ///<paam name="BlockSum", dir="输入">数据块数量</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<param name="pReadMBlock", dir="输出">HR2000获取的标签多个数据块内的数据信息</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "ReadMBlock")]
        public static extern int readMBlock(int device, ushort SrcAddr, ushort TargetAddr, Byte FstAddr, Byte BlockSum, 
                                            Byte[] UID, ref OReadMBlockType pReadMBlock, Byte[] pSendBuf, Byte[] pRecBuf);


        ///<summary>
        ///向标签多个数据块内写入数据
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="FstAddr", dir="输入">多个数据块首地址</param>
        ///<paam name="BlockSum", dir="输入">数据块数量</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<paam name="dataStr", dir="输入">写入的数据，注意：输入的数据是字符串形式（“001122AA556677BB”）</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000写标签多个数据的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "WriteMBlock")]
        public static extern int writeMBlock(int device, ushort SrcAddr, ushort TargetAddr, Byte FstAddr, Byte BlockSum, Byte[] UID,
                                             Byte[] dataStr, ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);

        ///<summary>
        ///读取标签信息
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<param name="pReadLblSysInfo", dir="输出">HR2000读取的标签信息</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "ReadLblSysInfo")]
        public static extern int readLblSysInfo(int device, ushort SrcAddr, ushort TargetAddr, Byte[] UID,
                                                ref OReadLblSysInfoType pReadLblSysInfo, Byte[] pSendBuf, Byte[] pRecBuf);





        ///<summary>
        ///写标签AFI值
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="AFIVal", dir="输入">AFI值</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000写标签AFI值的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "WriteAFI")]
        public static extern int writeAFI(int device, ushort SrcAddr, ushort TargetAddr, Byte AFIVal, Byte[] UID,
                                          ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);

        ///<summary>
        ///锁定标签AFI值
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000锁定标签AFI值的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "LockAFI")]
        public static extern int lockAFI(int device, ushort SrcAddr, ushort TargetAddr, Byte[] UID,
                                    ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);

        ///<summary>
        ///写标签DSFID值
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="DSFIDVal", dir="输入">DSFID值</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000写标签DSFID值的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "WriteDSFID")]
        public static extern int writeDSFID(int device, ushort SrcAddr, ushort TargetAddr, Byte DSFIDVal, Byte[] UID,
                                      ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);

        ///<summary>
        ///锁定标签DSFID值
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000锁定标签DSFID值的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "LockDSFID")]
        public static extern int lockDSFID(int device, ushort SrcAddr, ushort TargetAddr, Byte[] UID,
                                      ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);

        ///<summary>
        ///设置标签EAS值
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="Cmd", dir="输入">命令码：置位EAS（0x29），复位EAS（0x2A），锁定EAS（0x2B）</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000设置标签EAS的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "SetEAS")]
        public static extern int setEAS(int device, ushort SrcAddr, ushort TargetAddr, Byte Cmd, Byte[] UID,
                                      ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);


        ///<summary>
        ///读取M24标签多个数据块内的数据
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="FstAddr", dir="输入">数据块地址</param>
        ///<paam name="BlockSum", dir="输入">数据块数量</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<param name="pReadMBlock", dir="输出">HR2000操作标签的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("STM24LRxxx.dll", EntryPoint = "m24ReadMBlock")]
        public static extern int m24ReadMBlock(int device, ushort SrcAddr, ushort TargetAddr, ushort FstAddr, Byte BlockSum,
                                               Byte[] UID, ref OReadMBlockType pReadMBlock, Byte[] pSendBuf, Byte[] pRecBuf);


        ///<summary>
        ///向M24标签多个数据块内写入数据
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="FstAddr", dir="输入">多个数据块首地址</param>
        ///<paam name="BlockSum", dir="输入">数据块数量</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<paam name="dataStr", dir="输入">写入的数据，注意：输入的数据是字符串形式（“001122AA556677BB”）</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000操作标签的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("STM24LRxxx.dll", EntryPoint = "m24WriteMBlock")]
        public static extern int m24WriteMBlock(int device, ushort SrcAddr, ushort TargetAddr, ushort FstAddr, Byte BlockSum, Byte[] UID,
                                                Byte[] dataStr, ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);


        ///<summary>
        ///读取M24标签数据段密码状态
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="pSectorStatus", dir="输出">数据段密码状态</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<paam name="sectorIndex", dir="输入">数据段索引</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000操作标签的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("STM24LRxxx.dll", EntryPoint = "m24ReadSectorStatus")]
        public static extern int m24ReadSectorStatus(int device, ushort SrcAddr, ushort TargetAddr, Byte[] pSectorStatus, Byte[] UID, 
                                                     Byte sectorIndex, ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);


        ///<summary>
        ///锁定M24标签数据段
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<paam name="sectorIndex", dir="输入">数据段索引</param>
        ///<paam name="sectorStatus", dir="输入">数据段密码状态</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000操作标签的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("STM24LRxxx.dll", EntryPoint = "m24LockSector")]
        public static extern int m24LockSector(int device, ushort SrcAddr, ushort TargetAddr, Byte[] UID, Byte sectorIndex, Byte sectorStatus, 
                                               ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);

        ///<summary>
        ///写M24标签数据段密码
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<paam name="pwdIndex", dir="输入">数据段密码索引：1/2/3</param>
        ///<paam name="pSectorPwd", dir="输入">数据段密码：4字节</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000操作标签的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("STM24LRxxx.dll", EntryPoint = "m24WriteSectorPwd")]
        public static extern int m24WriteSectorPwd(int device, ushort SrcAddr, ushort TargetAddr, Byte[] UID, Byte pwdIndex, Byte[] pSectorPwd, 
                                                   ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);

        ///<summary>
        ///提交M24标签数据段当前密码
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<paam name="pwdIndex", dir="输入">数据段密码索引：1/2/3</param>
        ///<paam name="pSectorPwd", dir="输入">数据段密码：4字节</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000操作标签的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("STM24LRxxx.dll", EntryPoint = "m24PresentSectorPwd")]
        public static extern int m24PresentSectorPwd(int device, ushort SrcAddr, ushort TargetAddr, Byte[] UID, Byte pwdIndex, Byte[] pSectorPwd,
                                                     ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);


        ///<summary>
        ///读取M24标签配置寄存器
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<paam name="pCfg", dir="输出">配置参数</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000操作标签的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("STM24LRxxx.dll", EntryPoint = "m24ReadCfg")]
        public static extern int m24ReadCfg(int device, ushort SrcAddr, ushort TargetAddr, Byte[] UID, Byte[] pCfg,
                                            ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);

        ///<summary>
        ///写M24标签EH配置参数
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<paam name="eHCfg", dir="输入">EH配置参数</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000操作标签的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("STM24LRxxx.dll", EntryPoint = "m24WriteEHCfg")]
        public static extern int m24WriteEHCfg(int device, ushort SrcAddr, ushort TargetAddr, Byte[] UID, Byte eHCfg,
                                               ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);


        ///<summary>
        ///写M24标签DO配置参数
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<paam name="dOCfg", dir="输入">DO配置参数</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000操作标签的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("STM24LRxxx.dll", EntryPoint = "m24WriteDOCfg")]
        public static extern int m24WriteDOCfg(int device, ushort SrcAddr, ushort TargetAddr, Byte[] UID, Byte dOCfg,
                                               ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);


        ///<summary>
        ///检测M24标签EHEn状态
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<paam name="pEHEn", dir="输出">EHEn状态</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000操作标签的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("STM24LRxxx.dll", EntryPoint = "m24CheckEHEn")]
        public static extern int m24CheckEHEn(int device, ushort SrcAddr, ushort TargetAddr, Byte[] UID, Byte[] pEHEn,
                                              ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);


        ///<summary>
        ///控制M24标签EHEn状态
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<paam name="UID", dir="输入">标签UID</param>
        ///<paam name="eHEn", dir="输入">EHEn</param>
        ///<param name="pGeneralCmd", dir="输出">HR2000操作标签的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("STM24LRxxx.dll", EntryPoint = "m24CtrlEHEn")]
        public static extern int m24CtrlEHEn(int device, ushort SrcAddr, ushort TargetAddr, Byte[] UID, Byte eHEn,
                                             ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);


        ///<summary>
        ///发送和接收数据帧
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<paam name="pSendBuf", dir="输入">发送的请求帧</param>
        ///<param name="txLen", dir="输入">发送数据帧长度</param>
        ///<param name="pRecBuf", dir="输出">响应接收的数据帧</param>
        ///<param name="timeout", dir="输入">等待响应超时时间</param>
        [DllImport("STM24LRxxx.dll", EntryPoint = "serialWriteFrame")]
        public static extern int serialWriteFrame(int hSerial, Byte[] pSendBuf, ushort txLen, Byte[] pRecBuf, int timeout);

        ///<summary>
        ///读取输入事件
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="pFindInterfaceEvent", dir="输入">HR2000读取输入事件的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "FindInterfaceEvent")]
        public static extern int findInterfaceEvent(int device, ushort SrcAddr, ushort TargetAddr,
                                                    ref OFindInterfaceEventType pFindInterfaceEvent, Byte[] pSendBuf, Byte[] pRecBuf);

        ///<summary>
        ///设置输出事件
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="Relay", dir="输入">继电器输出</param>
        ///<param name="OUT1", dir="输入">OUT1输出</param>
        ///<param name="OUT2", dir="输入">OUT2输出</param>
        ///<param name="pGeneralCmd", dir="输入">HR2000设置输出事件的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "setOutputIfcEvent")]
        public static extern int setOutputIfcEvent(int device, ushort SrcAddr, ushort TargetAddr, Byte Relay, Byte OUT1, Byte OUT2,
                                                   ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);


        ///<summary>
        ///输出接口事件配置
        ///</summary>
        ///<param name="device", dir="输入">打开串口时获取的设备ID</param>
        ///<param name="SrcAddr", dir="输入">源地址：发起通信的设备地址，默认是0x0000</param>
        ///<param name="TargetAddr", dir="输入">目标地址：给出响应的设备地址，默认是0x0001</param>
        ///<param name="Relay", dir="输入">继电器输出</param>
        ///<param name="OUT1", dir="输入">OUT1输出</param>
        ///<param name="OUT2", dir="输入">OUT2输出</param>
        ///<param name="pGeneralCmd", dir="输入">HR2000设置输出事件的结果</param>
        ///<param name="pSendBuf", dir="输出">发送到HR2000的数据帧</param>
        ///<param name="pRecBuf", dir="输出">HR2000响应的数据帧</param>
        [DllImport("HR2000.dll", EntryPoint = "OutputIfcEventConfig")]
        public static extern int outputIfcEventConfig(int device, ushort SrcAddr, ushort TargetAddr, 
                                                      Byte RelayFreq, Byte RelayCycle, Byte OUT1Freq, Byte OUT1Cycle, Byte OUT2Freq, Byte OUT2Cycle,
                                                      ref OGeneralCmdType pGeneralCmd, Byte[] pSendBuf, Byte[] pRecBuf);

        public const Byte HR2000_ISO14443ACMD_ACTIVE_SUID = 0x15;
        public const Byte HR2000_ISO14443ACMD_GET_UID = 0x16;
        public const Byte HR2000_ISO14443ACMD_AUTHRB = 0x70;
        public const Byte HR2000_ISO14443ACMD_AUTHWB = 0x71;
        public const Byte HR2000_ISO14443ACMD_AUTHRV = 0x72;
        public const Byte HR2000_ISO14443ACMD_AUTHWV = 0x73;
        public const Byte HR2000_ISO14443ACMD_AUTHV = 0x74;
        public const Byte HR2000_ISO14443ACMD_RBLOCK = 0x75;
        public const Byte HR2000_ISO14443ACMD_WBLOCK4 = 0x76;
        public const Byte HR2000_RISO14443A_UID_MAX = 15;
        public const Byte HR2000_RISO14443A_MOBLOCKNUM_MAX = 52;
        public const Byte HR2000_RISO14443A_SIG_LEN = 32;
        public const Byte HR2000_RISO14443A_CNT_LEN = 3;
        public const Byte HR2000_RISO14443A_PCK_LEN = 2;

        [DllImport("ISO14443A.dll", EntryPoint = "iso14443AGetUID")]
        public static extern int iso14443AGetUID(int device, ushort SrcAddr, ushort TargetAddr, Byte mode,
                                                 ref OGetISO14443AUID pGetUID, Byte[] pSendBuf, Byte[] pRecBuf);

        [DllImport("ISO14443A.dll", EntryPoint = "iso14443AAuthReadBlock")]
        public static extern int iso14443AAuthReadBlock(int device, ushort SrcAddr, ushort TargetAddr,
                                                        ref ORWISO14443ABlock pISO14443ABlock, Byte[] pSendBuf, Byte[] pRecBuf);

        [DllImport("ISO14443A.dll", EntryPoint = "iso14443AAuthWriteBlock")]
        public static extern int iso14443AAuthWriteBlock(int device, ushort SrcAddr, ushort TargetAddr,
                                                         ref ORWISO14443ABlock pISO14443ABlock, Byte[] pSendBuf, Byte[] pRecBuf);

        [DllImport("ISO14443A.dll", EntryPoint = "iso14443AAuthReadValue")]
        public static extern int iso14443AAuthReadValue(int device, ushort SrcAddr, ushort TargetAddr,
                                                        ref ORWISO14443AValue pISO14443AValue, Byte[] pSendBuf, Byte[] pRecBuf);

        [DllImport("ISO14443A.dll", EntryPoint = "iso14443AAuthWriteValue")]
        public static extern int iso14443AAuthWriteValue(int device, ushort SrcAddr, ushort TargetAddr,
                                                         ref ORWISO14443AValue pISO14443AValue, Byte[] pSendBuf, Byte[] pRecBuf);

        [DllImport("ISO14443A.dll", EntryPoint = "iso14443AAuthValue")]
        public static extern int iso14443AAuthValue(int device, ushort SrcAddr, ushort TargetAddr,
                                                    ref OOpISO14443AValue pOpISO14443AValue, Byte[] pSendBuf, Byte[] pRecBuf);

        [DllImport("ISO14443A.dll", EntryPoint = "iso14443AReadM0Block")]
        public static extern int iso14443AReadM0Block(int device, ushort SrcAddr, ushort TargetAddr,
                                                    ref ORWISO14443ABlock pOpISO14443ABlock, Byte[] pSendBuf, Byte[] pRecBuf);

        [DllImport("ISO14443A.dll", EntryPoint = "iso14443AWriteM0Block")]
        public static extern int iso14443AWriteM0Block(int device, ushort SrcAddr, ushort TargetAddr,
                                                    ref ORWISO14443ABlock pOpISO14443ABlock, Byte[] pSendBuf, Byte[] pRecBuf);

        [DllImport("ISO14443A.dll", EntryPoint = "iso14443AReadM0Sig")]
        public static extern int iso14443AReadM0Sig(int device, ushort SrcAddr, ushort TargetAddr,
                                                  ref ORISO14443AInfo pISO14443AInfo, Byte[] pSendBuf, Byte[] pRecBuf);

        [DllImport("ISO14443A.dll", EntryPoint = "iso14443AReadM0Cnt")]
        public static extern int iso14443AReadM0Cnt(int device, ushort SrcAddr, ushort TargetAddr,
                                                  ref ORISO14443AInfo pISO14443AInfo, Byte[] pSendBuf, Byte[] pRecBuf);

        [DllImport("ISO14443A.dll", EntryPoint = "iso14443AAuthM0")]
        public static extern int iso14443AAuthM0(int device, ushort SrcAddr, ushort TargetAddr,
                                                  ref ORISO14443AInfo pISO14443AInfo, Byte[] pSendBuf, Byte[] pRecBuf);
    }
}



