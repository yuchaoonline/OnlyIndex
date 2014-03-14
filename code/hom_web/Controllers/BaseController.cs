using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hom_web.Controllers
{
    public class BaseController : Controller
    {
        protected BaseController()
        {
            //创建IBLL接口实例 供页面IBLL调用
            ifa = new hom_Factory.Factory_BLL();
        }

        protected hom_IFactory.IFactory_BLL ifa { get; set; }

    }
}
