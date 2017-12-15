using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// 图书标签状态枚举
    /// </summary>
    public enum InitStatusEnum
    {
        /// <summary>
        /// 已建档
        /// </summary>
        RecordInit=0,
        /// <summary>
        /// 已采集(未校对)
        /// </summary>
        RecordGrab=1,
        /// <summary>
        /// 已采集(已校对)
        /// </summary>
        RecordComfirmed = 2,
        /// <summary>
        /// 图书已上架
        /// </summary>
        RecordPubshed=3
    }

    /// <summary>
    /// 标签类型
    /// </summary>
    public enum TagTypeEnum {
        /// <summary>
        /// 高频标签
        /// </summary>
        HighFrequency=0,
        /// <summary>
        /// 超高频
        /// </summary>
        UltrahighFrequency=1
    }
}
