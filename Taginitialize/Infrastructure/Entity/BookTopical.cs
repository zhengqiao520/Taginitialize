using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    /// <summary>
    /// 图书主题表
    /// </summary>
    public class BookTopical
    {
        public int id { get; set; }
        public string isbn { get; set; }
        public string topical_code { get; set; }
        public DateTime create_time { get; set; }
    }
    public class BookTopicalExt: BookTopical
    {
        public string topical_name { get; set; }
    }
    /// <summary>
    /// 图书主题映射表
    /// </summary>
    public class BooktopicalMappings
    {
        public int id { get; set; }
        public string topical_code { get; set; }
        public string topical_name { get; set; }
    }
}
