using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace hom_webBack.admin.Article
{
    public partial class articel_List : BasePage
    {
        hom_IBLL.IBLL_Articel ibll;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gv_Bind();
            }
        }

        protected void gv_Bind()
        {
            hom_IBLL.IBLL_Articel ibll = ifa.Create_IBLL_Articel();
            gv1.DataSource = ibll.getDt(" and [IsDeleted]=0");
            gv1.DataBind();
        }

        protected void gv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Del"))
            {
                ibll = ifa.Create_IBLL_Articel();
                if (ibll.FDel(int.Parse(e.CommandArgument.ToString())))
                { GetJs("alert('删除成功');"); gv_Bind(); }
            }
        }
    }
}