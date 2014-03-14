using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hom_web.Controllers
{
    public class BlogController : BaseController
    {
        hom_IBLL.IBLL_Articel ibll;

        /// <summary>
        /// GET: /Blog/
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// GET: /Blog/Articel/
        /// </summary>
        /// <returns></returns>
        public ActionResult Articel(string classId, string Id)
        {
            ibll = ifa.Create_IBLL_Articel();
            hom_Entity.Articel model = new hom_Entity.Articel();
            string id = Id;
            model = ibll.getModel(int.Parse(id));
            ViewBag.Title = model.Title == "" ? "" : model.Title;
            ViewBag.Content = model.Content == "" ? "" : model.Content;
            return View();
        }

        /// <summary>
        /// /Blog/getArticelTc/
        /// 获取所有文章标题，内容概要，显示在首页
        /// </summary>
        /// <returns></returns>
        public JsonResult getArticelTc()
        {
            hom_IBLL.IBLL_Articel ibll = ifa.Create_IBLL_Articel();
            hom_Entity.Json json = ibll.getJsonTC(0, 30);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// /Blog/getMenu/
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public JsonResult getMenu()
        {
            hom_IBLL.IBLL_ArticelClass ibll = ifa.Create_IBLL_ArticelClass();
            hom_Entity.Json json = ibll.getMenu();
            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }
}
