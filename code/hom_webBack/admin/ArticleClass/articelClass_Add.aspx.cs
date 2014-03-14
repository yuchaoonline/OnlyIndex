using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hom_webBack.admin.ArticleClass
{
    public partial class ArticelClassAdd : BasePage
    {
        hom_Entity.ArticelClass model;
        hom_IBLL.IBLL_ArticelClass ibll;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        protected void Bind()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                //修改
                model = new hom_Entity.ArticelClass();
                ibll = ifa.Create_IBLL_ArticelClass();
                model = ibll.getModel(int.Parse(Request.QueryString["Id"]));
                if (model != null)
                {
                    txtArticelClassName.Text = model.ArticelClassName;
                    txtLink.Text = model.Link;
                    txtOrderId.Text = model.OrderId.ToString();
                    txtPerentId.Text = model.PerentId.ToString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ibll = ifa.Create_IBLL_ArticelClass();
            model = new hom_Entity.ArticelClass();

            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                model = ibll.getModel(int.Parse(Request.QueryString["Id"]));
                model.UpdateDate = DateTime.Now;
            }
            else
            {
                model.CreateDate = DateTime.Now;
                model.UpdateDate = model.CreateDate;
                model.IsDeleted = 0;
            }
            model.ArticelClassName = txtArticelClassName.Text;
            model.Link = txtLink.Text;
            model.OrderId = int.Parse(txtOrderId.Text);
            model.PerentId = int.Parse(txtPerentId.Text);

            if (model.Id == 0) { if (ibll.Add(model)) { GetJs("alert('保存成功！');window.location.href='articelClass_List.aspx';"); } }
            else { if (ibll.Update(model)) { GetJs("alert('修改成功！');window.location.href='articelClass_List.aspx';"); } }
        }

    }
}