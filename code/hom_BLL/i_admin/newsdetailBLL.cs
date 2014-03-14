using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hom_Model;
using System.Data;
using System.Data.SqlClient;
using HomLibrary;


namespace hom_BLL.i_admin
{
    public class newsdetailBLL
    {
        private const string selectStr = "select * from hom_news";
        private const string updateStr = "update hom_news set";
        public static newsModel getDetail(int id)
        {
            try
            {
                newsModel nm = new newsModel();
                DataTable dt = new DataTable();
                dt = SqlHelpler.GetDataTabel(hom_DAL.SqlHelper.ConnStr, selectStr + " where news_id=" + id.ToString());
                nm.news_oid = Int32.Parse(dt.Rows[0]["news_oid"].ToString());
                nm.news_title = dt.Rows[0]["news_title"].ToString();
                nm.news_stitle = dt.Rows[0]["news_stitle"].ToString();
                nm.news_author = dt.Rows[0]["news_author"].ToString();
                nm.news_time = Convert.ToDateTime(dt.Rows[0]["news_time"].ToString());
                nm.news_hit = Int32.Parse(dt.Rows[0]["news_hit"].ToString());
                nm.news_tipic = dt.Rows[0]["news_tipic"].ToString();
                nm.news_content = dt.Rows[0]["news_content"].ToString();
                nm.news_mark1 = Int32.Parse(dt.Rows[0]["news_mark1"].ToString());
                nm.news_mark2 = Int32.Parse(dt.Rows[0]["news_mark2"].ToString());
                nm.news_mark3 = Int32.Parse(dt.Rows[0]["news_mark3"].ToString());
                return nm;
            }
            catch (Exception ex) { return null; throw ex; }
        }
        public static void updateDetail(newsModel nm)
        {
            try
            {
                SqlParameter[] parame = new SqlParameter[]
                {
                    new SqlParameter("@news_id",nm.news_id),
                    new SqlParameter("@news_oid",nm.news_oid),
                    new SqlParameter("@news_title",nm.news_title),
                    new SqlParameter("@news_stitle",nm.news_stitle),
                    new SqlParameter("@news_author",nm.news_author),
                    new SqlParameter("@news_time",nm.news_time),
                    new SqlParameter("@news_tipic",nm.news_tipic),
                    new SqlParameter("@news_content",nm.news_content),
                    new SqlParameter("@news_mark1",nm.news_mark1),
                    new SqlParameter("@news_mark2",nm.news_mark2),
                    new SqlParameter("@news_mark3",nm.news_mark3)
                };
                SqlHelpler.ExcuteProcedure(hom_DAL.SqlHelper.ConnStr, "proc_hom_newsUpdate", parame);
            }
            catch (Exception ex) { throw ex; }
        }
    }

}
