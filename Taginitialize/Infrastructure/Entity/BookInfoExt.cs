using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public  class BookInfoExt:BookInfo
    {
        public string tag_id {
            get;set;
        }
        public string isbn_type { get; set; }

        public string tag_create_time { get; set; }

        /// <summary>
        /// 图书标签代码
        /// </summary>
        public string topical_code { get; set; }
        /// <summary>
        /// 图书标签名称
        /// </summary>
        public string topical_name { get; set; }

        /// <summary>
        /// 最小适读年龄
        /// </summary>
        public int? min_age { get; set; } = null;
        /// <summary>
        /// 最大适读年龄
        /// </summary>
        public int? max_age { get; set; } = null;
    }
}
