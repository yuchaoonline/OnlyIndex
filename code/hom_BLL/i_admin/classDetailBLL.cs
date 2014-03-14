using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

using hom_Model;
using System.Data;
using System.Data.SqlClient;
using HomLibrary;
using System.Web.UI.WebControls;


namespace hom_BLL.i_admin
{
    public class classDetailBLL
    {
        private const string selectStr = "select * from hom_class";
        private const string updateStr = "update hom_class set";
        private const string cnStr = "select class_name,class_id from hom_class";
        private const string validateStr = "select class_id from (select * from hom_class where class_pid={0}) as t where class_id={1}";

        //static DataTable dt;
        /// <summary>
        /// 填充到Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static classModel getDetail(int id)
        {
            try
            {
                classModel cm = new classModel();
                DataTable dt = new DataTable();
                dt = HomLibrary.SqlHelpler.GetDataTabel(hom_DAL.SqlHelper.ConnStr, selectStr + " where class_id=" + id.ToString());
                cm.class_oid = Int32.Parse(dt.Rows[0]["class_oid"].ToString());
                cm.class_pid = Int32.Parse(dt.Rows[0]["class_pid"].ToString());
                cm.class_depth = Int32.Parse(dt.Rows[0]["class_depth"].ToString());
                cm.class_name = dt.Rows[0]["class_name"].ToString();
                cm.class_banner = dt.Rows[0]["class_banner"].ToString();
                cm.class_pic = dt.Rows[0]["class_pic"].ToString();
                cm.class_content = dt.Rows[0]["class_content"].ToString();
                return cm;
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="cm"></param>
        public static void updateDetail(classModel cm)
        {
            try
            {
                SqlParameter[] parame = new SqlParameter[]
                {
                new SqlParameter("@class_id",cm.class_id),
                new SqlParameter("@class_oid",cm.class_oid),
                new SqlParameter("@class_pid",cm.class_pid),
                new SqlParameter("@class_depth",cm.class_depth),
                new SqlParameter("@class_name",cm.class_name),
                new SqlParameter("@class_banner",cm.class_banner),
                new SqlParameter("@class_pic",cm.class_pic),
                new SqlParameter("@class_content",cm.class_content)
                };
                SqlHelpler.ExcuteProcedure(hom_DAL.SqlHelper.ConnStr, "proc_hom_classUpdate", parame);
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="cm"></param>
        public static void insertDetail(classModel cm)
        {
            try
            {
                SqlParameter[] parame = new SqlParameter[]
                {
                new SqlParameter("@class_id",cm.class_id),
                new SqlParameter("@class_oid",cm.class_oid),
                new SqlParameter("@class_pid",cm.class_pid),
                new SqlParameter("@class_depth",cm.class_depth),
                new SqlParameter("@class_name",cm.class_name),
                new SqlParameter("@class_banner",cm.class_banner),
                new SqlParameter("@class_pic",cm.class_pic),
                new SqlParameter("@class_content",cm.class_content)
                };
                SqlHelpler.ExcuteProcedure(hom_DAL.SqlHelper.ConnStr, "proc_hom_classInsert", parame);
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// 验证class规则，0为符合，1为id=pid，2是乱伦
        /// </summary>
        /// <param name="id">当前ID</param>
        /// <param name="newsPid">新父pid</param>
        /// <returns>0为符合</returns>
        public static int boolClass(int id, int newsPid)
        {
            if (id == newsPid)
                return 1;
            else if (SqlHelpler.GetDataTabel(hom_DAL.SqlHelper.ConnStr, string.Format(validateStr, id, newsPid)).Rows.Count > 0)
                return 2;
            else return 0;
        }
        /// <summary>
        /// 填充下拉框
        /// </summary>
        /// <param name="ddl"></param>
        public static void fillDropDownList(DropDownList ddl, int id)
        {
            ListItem li0 = new ListItem("顶级目录", "0");
            ddl.Items.Add(li0);
            getDDLitem(0, 0, ddl);
        }
        /// <summary>
        /// 迭代获取下拉框的ListItem[]
        /// </summary>
        /// <param name="pid">父</param>
        /// <param name="depth">深</param>
        /// <param name="i">序</param>
        /// <param name="item">继承</param>
        /// <returns></returns>
        public static DropDownList getDDLitem(int pid, int depth, DropDownList ddl)
        {

            DataView dv = new DataView(HomLibrary.SqlHelpler.GetDataTabel(hom_DAL.SqlHelper.ConnStr, cnStr +
                " where class_pid=" + pid.ToString()));
            foreach (DataRowView dr in dv)
            {
                ListItem li = new ListItem(returnfh(depth) + dr["class_name"].ToString(), dr["class_id"].ToString());
                ddl.Items.Add(li);

                getDDLitem(Int32.Parse(dr["class_id"].ToString()), depth + 1, ddl);
            }
            return ddl;
        }
        /// <summary>
        /// 返回符号、位置
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private static string returnfh(int count)
        {
            string fh = string.Empty;
            if (count == 0) { fh = "├"; }
            else { fh = ("├").PadLeft(count + 1, '　'); }
            return fh;
        }
    }
}
