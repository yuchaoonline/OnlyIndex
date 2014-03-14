using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hom_BLL
{
    public class BLL_Base
    {
        protected BLL_Base()
        {
            //创建IDAL接口实例 供BLL调用
            ifa = new hom_Factory.Factory_DAL();
        }

        protected hom_IFactory.IFactory_DAL ifa { get; set; }


    }
}
