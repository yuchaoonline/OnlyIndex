using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hom_Entity
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// 数据Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public long OrderId { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDeleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}
