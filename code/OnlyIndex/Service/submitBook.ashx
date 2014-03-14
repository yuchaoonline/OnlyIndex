<%@ WebHandler Language="C#" Class="submitBook" %>

using System;
using System.Web;

public class submitBook : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");

        hom_Entity.user.Book model;
        hom_IBLL.IBLL_Book ibll;
        hom_IFactory.IFactory_BLL ifa = new hom_Factory.Factory_BLL();
        ibll = ifa.Create_IBLL_Book();
        model = new hom_Entity.user.Book();
        model.Content = context.Request["content"] == null ? "" : context.Request["content"];
        model.BookName = context.Request["name"] == null ? "" : context.Request["name"];
        model.CreateDate = DateTime.Now;
        model.UpdateDate = model.CreateDate;
        model.IsDeleted = 0;
        model.QQ = context.Request["qq"] == null ? "" : context.Request["qq"];
        model.Tel = context.Request["tel"] == null ? "" : context.Request["tel"];
        model.BackLook = int.Parse(context.Request["back"] == null ? "1" : context.Request["back"]);
        model.Address = context.Request["address"] == null ? "" : context.Request["address"];
        model.Email = "暂无";
        ibll.Add(model);
        //context.Response.Write("success");



    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}