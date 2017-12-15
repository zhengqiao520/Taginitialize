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
    }
}
