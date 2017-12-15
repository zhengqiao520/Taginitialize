using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class Book_init_user
    {
        /// <summary>
        /// id
        /// </summary>		
        public int id
        {
            get;
            set;
        }
        /// <summary>
        /// user_name
        /// </summary>		
        public string user_name
        {
            get;
            set;
        }
        /// <summary>
        /// user_account
        /// </summary>		
        public string user_account
        {
            get;
            set;
        }
        /// <summary>
        /// user_password
        /// </summary>		
        public string user_password
        {
            get;
            set;
        }
        /// <summary>
        /// remarks
        /// </summary>		
        public string remarks
        {
            get;
            set;
        }
    }
    public class UserInfo:Book_init_user
    {
        private static readonly UserInfo userInstance = new UserInfo();
        private UserInfo() { }
        public static UserInfo Instance
        {
            get
            {
                return userInstance;
            }
        }
    }

}
