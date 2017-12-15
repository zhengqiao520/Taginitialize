using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    /// <summary>
    /// TagInfo
    /// </summary>
    public class TagInfo
    {
        public int Id { get; set; }
        public string TagID { get; set; }
        public string ISBN { get; set; }
        public string EPC { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        public string CpuID { get; set; }
        public int TagType { get; set; }
    }
}
