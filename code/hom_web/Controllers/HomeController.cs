using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hom_web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// GET: /Home/
        /// 主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

    }
}
