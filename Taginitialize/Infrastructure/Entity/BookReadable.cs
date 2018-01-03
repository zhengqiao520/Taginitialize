using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    /// <summary>
    /// 图书适读年龄
    /// </summary>
    public class BookReadable
    {
        public int id { get; set; }
        public string isbn { get; set; }
        public int? min_age { get; set; }
        public int? max_age { get; set; }
        public DateTime create_time { get; set; }
        public DateTime modify_time { get; set; }

    }
}
