using System;
using System.Collections.Generic;
using System.Configuration;

using System.Text;

namespace hom_accDAL
{
    public class DAL_Base
    {
        //access连接字符串
        public string accConStr
        {
            get { return ConfigurationManager.ConnectionStrings["accConnStr"].ToString(); }
        }
    }
}
