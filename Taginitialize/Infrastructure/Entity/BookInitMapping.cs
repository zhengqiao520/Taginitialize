using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class Book_init_mapping
    {

        /// <summary>
        /// auto_increment
        /// </summary>		
        public int id
        {
            get;
            set;
        }
        /// <summary>
        /// tag_id
        /// </summary>		
        public string tag_id
        {
            get;
            set;
        }
        /// <summary>
        /// isbn
        /// </summary>		
        public string isbn
        {
            get;
            set;
        }
        /// <summary>
        /// status
        /// </summary>		
        public int status
        {
            get;
            set;
        }
        /// <summary>
        /// account
        /// </summary>		
        public string account
        {
            get;
            set;
        }
        /// <summary>
        /// tag_type
        /// </summary>		
        public int tag_type
        {
            get;
            set;
        }
        /// <summary>
        /// create_time
        /// </summary>		
        public DateTime create_time
        {
            get;
            set;
        }
        /// <summary>
        /// gather_time
        /// </summary>		
        public DateTime gather_time
        {
            get;
            set;
        }
        /// <summary>
        /// filing_time
        /// </summary>		
        public DateTime filing_time
        {
            get;
            set;
        }
        public int isbn_type {
            get;set;
        }
        public int isbn_sequence {
            get;set;
        }

    }

    /// <summary>
    /// 扩展图书信息
    /// </summary>
    public class Book_init_mappingExt:Book_init_mapping {
        public string book_name { get; set; }
    }
}
