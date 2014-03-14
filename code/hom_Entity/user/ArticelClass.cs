using hom_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hom_Entity
{
    public class ArticelClass : BaseEntity
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string ArticelClassName { get; set; }

        /// <summary>
        /// 连接地址
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 父id
        /// </summary>
        public long PerentId { get; set; }


    }
}
