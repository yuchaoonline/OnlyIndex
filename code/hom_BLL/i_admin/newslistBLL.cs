using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HomLibrary;
using hom_DAL;


namespace hom_BLL.i_admin
{
    public class newslistBLL
    {

        private const string sqlstr = "select * from hom_news";
        private static StringBuilder sb;
        /// <summary>
        /// 当前页，每页条数，总页数
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="pagesize">每页条数</param>
        /// <param name="pagecount">总页数</param>
        /// <returns></returns>
        public static DataTable getList(int page, int pagesize, ref int pagecount)
        {
            DataTable dt;
            string sql = "select top " + pagesize + " * from hom_news where news_id not in (select top " + pagesize * (page - 1) + " news_id from hom_news)";

            try
            {
                dt = new DataTable();
                dt = SqlHelpler.GetDataTabel(SqlHelper.ConnStr, "select news_id from hom_news");
                pagecount = dt.Rows.Count / pagesize + 1;
                dt = new DataTable();
                dt = SqlHelpler.GetDataTabel(SqlHelper.ConnStr, sql);
                return dt;
            }
            catch (Exception ex) { throw ex; }
        }
        public static StringBuilder getclassList(int pid, int moPid, int depth, StringBuilder sb)
        {
            string name = SqlHelpler.GetDataTabel(SqlHelper.ConnStr, "select class_name from hom_class where class_id=" + pid.ToString()).Rows[0][0].ToString();
            sb.Append("<li><a href='#'>" + name + "</a></li>");

            return getclassListTemp(pid, moPid, depth, sb);
        }
        public static StringBuilder getclassListTemp(int pid, int moPid, int depth, StringBuilder sb)
        {
            //sb = new StringBuilder();
            //sb.Append("");
            //return sb;
            DataView dv = new DataView(SqlHelpler.GetDataTabel(SqlHelper.ConnStr,
                "select class_id,class_name from hom_class where class_pid=" + pid.ToString() + " order by class_oid asc"));
            foreach (DataRowView drv in dv)
            {
                sb.Append("<li>" + returnfh(depth) + "<a href='newsList.aspx?classid=");
                sb.Append(drv.Row[0].ToString());
                sb.Append("&pid=");
                sb.Append(moPid.ToString());
                sb.Append("'>");
                sb.Append(drv.Row[1].ToString());
                sb.Append("</a>");
                getclassListTemp(Int32.Parse(drv.Row[0].ToString()), moPid, depth + 1, sb);
            }
            return sb;
        }
        private static string returnfh(int count)
        {
            string fh = string.Empty;
            if (count == 0) { fh = "├"; }
            else { fh = ("├").PadLeft(count + 1, '　'); }
            return fh;
        }
    }
}
