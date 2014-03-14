using hom_Entity;
using hom_IBLL;
using System.Collections.Generic;
using System.Data;

namespace hom_BLL
{
    public class BLL_ArticelClass : BLL_Base, IBLL_ArticelClass
    {

        public bool Add(ArticelClass articelClass)
        {
            return ifa.Create_IDAL_ArticelClass().Add(articelClass);
        }

        public bool Del(long Id)
        {
            return ifa.Create_IDAL_ArticelClass().Del(Id);
        }

        public bool FDel(long Id)
        {
            return ifa.Create_IDAL_ArticelClass().FDel(Id);
        }

        public bool Update(ArticelClass articelClass)
        {
            return ifa.Create_IDAL_ArticelClass().Update(articelClass);
        }

        public List<ArticelClass> getList(string where)
        {
            return ifa.Create_IDAL_ArticelClass().getList(where);
        }

        public DataTable getDt(string where)
        {
            return ifa.Create_IDAL_ArticelClass().getDt(where);
        }

        public ArticelClass getModel(long Id)
        {
            return ifa.Create_IDAL_ArticelClass().getModel(Id);
        }

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public Json getMenu()
        {
            Json model = new Json();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("<li><a href='#'>首页</a></li>");
            sb.AppendLine("<li><a href='#'>文章</a>");
            System.Data.DataTable dt = ifa.Create_IDAL_ArticelClass().getListByPerent(0);
            if (dt.Rows.Count > 0)
            {
                sb.AppendLine("<ul class='ulist_1'>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.AppendLine(string.Format("<li><a href='{0}'>{1}</a></li>", dt.Rows[i]["Link"].ToString(), dt.Rows[i]["ArticelClassName"].ToString()));
                }
                sb.AppendLine("</ul>");
            }
            sb.AppendLine("</li>");


            model.content = sb.ToString();
            model.status = 200;
            model.message = "";
            return model;
        }
    }
}
