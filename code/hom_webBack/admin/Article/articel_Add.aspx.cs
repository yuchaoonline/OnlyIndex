using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hom_webBack.admin.Article
{
    public partial class articel_Add : BasePage
    {
        hom_Entity.Articel model;
        hom_IBLL.IBLL_Articel ibll;
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
                model = new hom_Entity.Articel();
                ibll = ifa.Create_IBLL_Articel();
                model = ibll.getModel(int.Parse(Request.QueryString["Id"]));
                if (model != null)
                {
                    txtTitle.Text = model.Title;
                    txtPic.Text = model.Pic;
                    txtContent.Text = model.Content;
                    txtOrderId.Text = model.OrderId.ToString();
                    txtArticelClassId.Text = model.ArticelClassId.ToString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ibll = ifa.Create_IBLL_Articel();
            model = new hom_Entity.Articel();

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
            model.Content = txtContent.Text;
            model.ArticelClassId = Convert.ToInt64(txtArticelClassId.Text);
            model.OrderId = int.Parse(txtOrderId.Text);
            model.Title = txtTitle.Text;
            model.Pic = txtPic.Text;

            if (model.Id == 0) { if (ibll.Add(model)) { GetJs("alert('保存成功！');window.location.href='articel_List.aspx';"); } }
            else { if (ibll.Update(model)) { GetJs("alert('修改成功！');window.location.href='articel_List.aspx';"); } }

        }
    }
}