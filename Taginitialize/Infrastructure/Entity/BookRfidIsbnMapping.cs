using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class BookRfidIsbnMapping
    {

        /// <summary>
        /// id
        /// </summary>		
        public long id
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
        /// rfid_tag_id
        /// </summary>		
        public string rfid_tag_id
        {
            get;
            set;
        }
        /// <summary>
        /// isbn_sequence
        /// </summary>		
        public int isbn_sequence
        {
            get;
            set;
        }
        /// <summary>
        /// isbn_type
        /// </summary>		
        public int isbn_type
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

    }
}
