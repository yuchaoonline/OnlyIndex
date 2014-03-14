using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace hom_BLL.i_admin
{
    public class classlistBLL
    {
        private const string sqlstr = "select * from hom_class";
        private const string deleteStr = "delete from hom_class";
        static DataTable dt;

        /// <summary>
        /// depth深度，pid父
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static DataTable getList(int depth, int pid)
        {
            dt = new DataTable();
            dt = HomLibrary.SqlHelpler.GetDataTabel(hom_DAL.SqlHelper.ConnStr, sqlstr +
                " where class_pid=" + pid.ToString() + " and class_depth=" + pid.ToString() + " order by class_oid asc");
            return dt;
        }
        /// <summary>
        /// 填充列表
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="depth"></param>
        /// <param name="sb"></param>
        /// <returns></returns>
        public static StringBuilder writeClass(int pid, int depth, StringBuilder sb)
        {
            DataView dv = new DataView(HomLibrary.SqlHelpler.GetDataTabel(hom_DAL.SqlHelper.ConnStr, sqlstr +
                            " where class_pid=" + pid.ToString() + " order by class_oid asc"));
            foreach (DataRowView drv in dv)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine("<td  style='text-align: center'>" + drv["class_id"].ToString() + "/" + drv["class_oid"].ToString() + "</td>");
                sb.AppendLine("<td>");
                sb.AppendLine(returnfh(depth) + drv["class_name"].ToString());
                sb.AppendLine(@"&nbsp;&nbsp;<a href='javascript:void(0);' class='classalter') onclick='classAlter(" + drv["class_id"].ToString() + ")'>修改</a>");
                sb.AppendLine(@"<a href='javascript:void(0);' class='classadd' onclick='classAdd(" + drv["class_id"].ToString() + ")'>添加子类</a>");
                sb.AppendLine(@"<a href='javascript:void(0);' class='classdel' onClick=del(" + drv["class_id"].ToString() + ");>删除</a>");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
                writeClass(Int32.Parse(drv["class_id"].ToString()), depth + 1, sb);
            }
            return sb;
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
        public static int delClass(int id)
        {
            try
            {
                if (HomLibrary.SqlHelpler.GetDataTabel(hom_DAL.SqlHelper.ConnStr,
                    "select class_id from hom_class where class_pid=" + id).Rows.Count > 0)
                {
                    return 1;
                }
                else
                {
                    HomLibrary.SqlHelpler.ExcuteSql(hom_DAL.SqlHelper.ConnStr,
                        deleteStr + " where class_id=" + id);
                    return 0;
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
