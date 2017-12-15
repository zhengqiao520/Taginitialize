using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
   public class BookInfo
    {

        /// <summary>
        /// isbn_no
        /// </summary>		
        public string isbn_no
        {
            get;
            set;
        }
        /// <summary>
        /// book_name
        /// </summary>		
        public string book_name
        {
            get;
            set;
        }
        /// <summary>
        /// author
        /// </summary>		
        public string author
        {
            get;
            set;
        }
        /// <summary>
        /// press
        /// </summary>		
        public string press
        {
            get;
            set;
        }
        /// <summary>
        /// publication_date
        /// </summary>		
        public DateTime publication_date
        {
            get;
            set;
        }
        /// <summary>
        /// category
        /// </summary>		
        public string category
        {
            get;
            set;
        }
        /// <summary>
        /// price
        /// </summary>		
        public decimal price
        {
            get;
            set;
        }
        /// <summary>
        /// readable
        /// </summary>		
        public string readable
        {
            get;
            set;
        }
        /// <summary>
        /// imgurl
        /// </summary>		
        public string imgurl
        {
            get;
            set;
        }
        public string brief {
            get;set;
        }
        /// <summary>
        /// describe
        /// </summary>		
        public string describe
        {
            get;
            set;
        }
        /// <summary>
        /// create_time
        /// </summary>		
        public DateTime? create_time
        {
            get;
            set;
        }
        /// <summary>
        /// modify_time
        /// </summary>		
        public DateTime? modify_time
        {
            get;
            set;
        }
    }
}
