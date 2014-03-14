using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class BasePage : System.Web.UI.Page
{
    protected BasePage()
    {
        //创建IBLL接口实例 供页面IBLL调用
        ifa = new hom_Factory.Factory_BLL();
    }

    protected hom_IFactory.IFactory_BLL ifa { get; set; }

    protected void GetJs(string func)
    {
        Response.Write("<script>" + func + "</script>");
    }
}