using System;
using System.Linq;
using System.Text;
using DevLib.Data;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Infrastructure.Entity;
using Renci.SshNet;

namespace Infrastructure
{
    public class ConnectInit {

        public static string MYSQLConfig = "mysql";
        private const string SQLITEConfig = "sqlite";
        private const string NFCAddress =  "nfc_address";

        public static string MysqlConnectionString {
            get {
                return GetConfigString(MYSQLConfig);
            }
        }
        public static string NFC_Address {
            get {
                return System.Configuration.ConfigurationManager.AppSettings[NFCAddress];
                    //"sm.wdb007.com/wdb007-info/book/detail.html?isbn={0}";
            }
        }
        public static string SqliteConnectionString {
            get {
                return GetConfigString(SQLITEConfig);
            }
        }
        private static string GetConfigString(string name) {
            return System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        public static bool IsUATDataBase {
            get {
                return MYSQLConfig != "mysql";
            }
        }
    }
    public class Utility:DbHelper
    {
        private static Utility _MySqlInstance = null;
        private static Utility _SQLiteInstance = null;
        private static readonly object padlock = new object();
        public static Utility SQLiteInstance
        {
           get
            {
                if (_SQLiteInstance == null)
                {
                    _SQLiteInstance = new Utility(ConnectInit.SqliteConnectionString, DbProvider.SQLite);
                }
                return _SQLiteInstance;
            }
        }
        public static Utility MySqlInstance
        {
            get
            {
                if (_MySqlInstance == null)
                {
                    lock (padlock)
                    {
                        if (_MySqlInstance==null)
                        {
                            
                            _MySqlInstance = new Utility(MysqlDES3DecryptConnctionString, DbProvider.MySQL);
                        }
                    }
                }
                return _MySqlInstance;
            }
        }
        private Utility(string connectString,DbProvider _dbType) :
            base(connectString, _dbType)
        {

        }
        public static string MysqlDES3DecryptConnctionString
        {
            get
            {
                return DES3Decrypt(ConnectInit.MysqlConnectionString);
            }
        }
        private static string CPUID = null;
        public static string CpuId
        {
            get
            {
                if (CPUID != null)
                    return CPUID;
                else
                {
                    //Uses first CPU identifier available in order of preference
                    //Don't get all identifiers, as it is very time consuming
                    string retVal = identifier("Win32_Processor", "UniqueId");
                    if (retVal == "") //If no UniqueID, use ProcessorID
                    {
                        retVal = identifier("Win32_Processor", "ProcessorId");
                        if (retVal == "") //If no ProcessorId, use Name
                        {
                            retVal = identifier("Win32_Processor", "Name");
                            if (retVal == "") //If no Name, use Manufacturer
                            {
                                retVal = identifier("Win32_Processor", "Manufacturer");
                            }
                            //Add clock speed for extra security
                            retVal += identifier("Win32_Processor", "MaxClockSpeed");
                        }
                    }
                    CPUID = retVal;
                }
                return CPUID;
            }
        }
        private static string identifier(string wmiClass, string wmiProperty)
        {
            string result = "";
            System.Management.ManagementClass mc =
        new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                //Only get the first one
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }
        public static string DES3Decrypt(string data, string key= "3DES_MD5_Timestamp123456")
        {
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            DES.Key = Encoding.GetEncoding("GBK").GetBytes(key);
            DES.Mode = CipherMode.ECB;
            DES.Padding = PaddingMode.PKCS7;
            ICryptoTransform DESDecrypt = DES.CreateDecryptor();
            byte[] Buffer = Convert.FromBase64String(data);
            return Encoding.GetEncoding("GBK").GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));

        }
        public static string DES3Encrypt(string data, string key = "3DES_MD5_Timestamp123456")
        {
            ICryptoTransform transform = new TripleDESCryptoServiceProvider { Key = Encoding.GetEncoding("GBK").GetBytes(key), Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 }.CreateEncryptor();
            byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(data);
            return Convert.ToBase64String(transform.TransformFinalBlock(bytes, 0, bytes.Length));
        }
        public static SSHInfo SSHInfo {
            get
            {
                string configSSH = System.Configuration.ConfigurationManager.AppSettings["ssh"].ToString();
                configSSH = DES3Decrypt(configSSH);
                return  JsonConvert.DeserializeObject<SSHInfo>(configSSH);
            }
        }
        public static void EmptyConnection() {
            _MySqlInstance = null;
            _SQLiteInstance = null;
        }
    }

}
