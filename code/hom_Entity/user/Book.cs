using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hom_Entity.user
{
    public class Book : BaseEntity
    {
        /// <summary>
        /// 留言人
        /// </summary>
        public String BookName { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public String QQ { get; set; }
        /// <summary>
        /// 留言人邮箱
        /// </summary>
        public String Email { get; set; }
        /// <summary>
        /// 留言内容
        /// </summary>
        public String Content { get; set; }
        /// <summary>
        /// 回访方式
        /// </summary>
        public int BackLook { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public String Tel { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public String Address { get; set; }
    }
}
