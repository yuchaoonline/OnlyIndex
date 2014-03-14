using hom_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hom_Entity
{
    /// <summary>
    /// 博文
    /// </summary>
    public class Articel : BaseEntity
    {
        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 标题图片
        /// </summary>
        public string Pic { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public int IsTop { get; set; }

        /// <summary>
        /// 所属分类
        /// </summary>
        public long ArticelClassId { get; set; }
    }
}
