using hom_Entity;
using hom_IBLL;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace hom_BLL
{
    public class BLL_Articel : BLL_Base, IBLL_Articel
    {

        public bool Add(Articel articel)
        {
            return ifa.Create_IDAL_Articel().Add(articel);
        }

        public bool Del(long Id)
        {
            return ifa.Create_IDAL_Articel().Del(Id);
        }

        public bool FDel(long Id)
        {
            return ifa.Create_IDAL_Articel().FDel(Id);
        }

        public bool Update(Articel articel)
        {
            return ifa.Create_IDAL_Articel().Update(articel);
        }

        public List<Articel> getList(string where)
        {
            return ifa.Create_IDAL_Articel().getList(where);
        }

        public DataTable getDt(string where)
        {
            return ifa.Create_IDAL_Articel().getDt(where);
        }

        public Articel getModel(long Id)
        {
            return ifa.Create_IDAL_Articel().getModel(Id);
        }

        /// <summary>
        /// 获取从start开始起Count条文章标题及内容简介
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public Json getJsonTC(int Start, int Count)
        {
            string sql = "";
            if (Start == 0)
            {
                sql = string.Format("select top {0} * from [tbl_Articel] where [IsDeleted]=0", Count);
            }
            else sql = string.Format("select top {0} * from [tbl_Articel] where [IsDeleted]=0 and [ID] not in (select top {1} ID from [tbl_Articel] where [IsDeleted]=0) ", Count, Start);
            DataTable dt = ifa.Create_IDAL_Articel().getDtBySql(sql);
            StringBuilder sb = new StringBuilder();
            //sb.Append("[{\"content\":\"");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string title = dt.Rows[i]["Title"].ToString();
                string createdate = dt.Rows[i]["CreateDate"].ToString();
                string content = dt.Rows[i]["Content"].ToString();
                string id = dt.Rows[i]["Id"].ToString();
                content = content.Length > 300 ? (content.Substring(0, 300) + "...") : content;
                content = content.Replace(" ", "&nbsp");
                sb.AppendFormat("<li>");
                sb.AppendFormat("<span class='listTitle'>{0}</span>", title);
                sb.AppendFormat("<span class='listDate'>{0}</span>", createdate);
                sb.AppendFormat("<p>{0}</p> <a href='/blog/Articel/{1}'>查看全文</a></li>", content, id);
            }
            //sb.Append("\",\"message\":\"null\",\"status\":\"200\"}]");

            Json json = new Json();
            json.content = sb.ToString();
            json.message = "";
            json.status = 200;

            return json;
        }
    }
}
