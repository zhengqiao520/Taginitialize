using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class BookEntity
    {
        /// <summary>
        /// rfid
        /// </summary>
        public string rfidCode { get; set; }

        /// <summary>
        /// isbn编号
        /// </summary>
        public string isbnNo { get; set; }

        /// <summary>
        /// 图书状态:损坏(0),正常(1),用户报损未确认(2)
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 原始书格编号
        /// </summary>
        public string originGridCode { get; set; }

        /// <summary>
        /// 当前书格编号
        /// </summary>
        public string currentGridCode { get; set; }

        /// <summary>
        /// 借阅状态：0-上架;1-下架;2-借阅
        /// </summary>
        public int borrowedStatus { get; set; }

        /// <summary>
        /// 上架日期
        /// </summary>
        public DateTime putonDate { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime modifyTime { get; set; }

    }
}
