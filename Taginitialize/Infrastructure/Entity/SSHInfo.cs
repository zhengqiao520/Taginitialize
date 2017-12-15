using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class SSHInfo
    {
        private static SSHInfo instance = null;
        private static object obj = new object();
        public SSHInfo()
        {

        }
        public static SSHInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            instance = new SSHInfo();
                        }
                    }
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }
        public string publish_ip { get; set; }
        public string publish_port { get; set; } = "22";
        public string publish_usr { get; set; }
        public string publish_pws { get; set; }
        public string local_ip { get; set; }
        public string local_port { get; set; } = "3306";
        public string local_usr { get; set; }
        public string local_pws { get; set; }
    }
}
