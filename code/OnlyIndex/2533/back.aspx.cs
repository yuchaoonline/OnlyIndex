using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : BasePage
{
    protected String scriptString;
    hom_Entity.user.Book model;
    hom_IBLL.IBLL_Book ibll;
    protected void Page_Load(object sender, EventArgs e)
    {
        AccessDataSource1.DataFile = ConfigurationManager.AppSettings["accPath"];
        if (!IsPostBack)
        {
            BindList();
        }
    }

    protected void BindList()
    {
        //DataTable dt;
        //ibll = ifa.Create_IBLL_Book();
        //dt = ibll.getDt("IsDeleted=0");


        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        DataView dv = (DataView)AccessDataSource1.Select(DataSourceSelectArguments.Empty);
        pds.DataSource = dv;
        reBookList.DataSource = pds;
        reBookList.DataBind();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindList();
    }
    protected void AccessDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        AspNetPager1.RecordCount = e.AffectedRows;
    }
    protected void reBookList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        String backLook = DataBinder.Eval(e.Item.DataItem, "backlook").ToString();

        Label lblBackLook = e.Item.FindControl("lblBackLook") as Label;

        switch (backLook)
        {
            case "1": lblBackLook.Text = "随时"; break;
            case "2": lblBackLook.Text = "上班时间"; break;
            case "3": lblBackLook.Text = "下班时间"; break;
            default: lblBackLook.Text = "暂无"; break;
        }


        Label lblIndex = e.Item.FindControl("lblIndex") as Label;
        lblIndex.Text = (e.Item.ItemIndex + 1).ToString("D4");
    }
    protected void reBookList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("del"))
        {
            ibll = ifa.Create_IBLL_Book();
            ibll.Del(long.Parse(e.CommandArgument.ToString()));
            BindList();

            scriptString = "alert('删除成功！');";
        }
    }
}