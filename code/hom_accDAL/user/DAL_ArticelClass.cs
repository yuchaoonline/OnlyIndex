using hom_Entity;
using hom_IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace hom_accDAL
{
    public class DAL_ArticelClass : DAL_Base, IDAL_ArticelClass
    {
        public bool Add(ArticelClass articelClass)
        {
            string sql = "insert into tbl_ArticelClass([OrderId],[PerentId],[ArticelClassName],[Link],[CreateDate],[UpdateDate],[IsDeleted]) values(@OrderId,@PerentId,@ArticelClassName,@Link,@CreateDate,@UpdateDate,@IsDeleted);";
            OleDbParameter[] pa = 
            { 
                new OleDbParameter("@OrderId", OleDbType.BigInt, 64), 
                new OleDbParameter("@PerentId",OleDbType.BigInt, 64),
                new OleDbParameter("@ArticelClassName",OleDbType.VarWChar, 200),
                new OleDbParameter("@Link",OleDbType.VarWChar, 200),
                new OleDbParameter("@CreateDate",OleDbType.Date, 200),
                new OleDbParameter("@UpdateDate",OleDbType.Date, 200),
                new OleDbParameter("@IsDeleted",OleDbType.SmallInt, 2)
            };
            pa[0].Value = articelClass.OrderId;
            pa[1].Value = articelClass.PerentId;
            pa[2].Value = articelClass.ArticelClassName;
            pa[3].Value = articelClass.Link;
            pa[4].Value = articelClass.CreateDate;
            pa[5].Value = articelClass.UpdateDate;
            pa[6].Value = articelClass.IsDeleted;
            int r = accDBHelper.ExcuteSql(accConStr, sql, pa);
            if (r > 0)
                return true;
            else return false;
        }

        public bool Del(long Id)
        {
            string sql = "delete from tbl_ArticelClass where [Id]=@Id";
            OleDbParameter[] pa = 
            { 
                new OleDbParameter("@Id", OleDbType.BigInt, 64)
            };
            pa[0].Value = Id;
            int r = accDBHelper.ExcuteSql(accConStr, sql, pa);
            if (r > 0)
                return true;
            else return false;
        }

        public bool FDel(long Id)
        {
            int r = accDBHelper.ExcuteSql(accConStr, "update tbl_ArticelClass set [IsDeleted]=1 where [Id]=" + Id.ToString());
            if (r > 0)
                return true;
            else return false;
        }

        public bool Update(ArticelClass articelClass)
        {
            string sql = "update tbl_ArticelClass set [OrderId]=@OrderId,[PerentId]=@PerentId,[ArticelClassName]=@ArticelClassName,[Link]=@Link,[CreateDate]=@CreateDate,[UpdateDate]=@UpdateDate,[IsDeleted]=@IsDeleted where [Id]=@Id;";
            OleDbParameter[] pa = 
            { 
                new OleDbParameter("@OrderId", OleDbType.BigInt, 64), 
                new OleDbParameter("@PerentId",OleDbType.BigInt, 64),
                new OleDbParameter("@ArticelClassName",OleDbType.VarWChar, 200),
                new OleDbParameter("@Link",OleDbType.VarWChar, 200),
                new OleDbParameter("@CreateDate",OleDbType.Date, 200),
                new OleDbParameter("@UpdateDate",OleDbType.Date, 200),
                new OleDbParameter("@IsDeleted",OleDbType.SmallInt, 2),
                new OleDbParameter("@Id",OleDbType.SmallInt, 64)
            };
            pa[0].Value = articelClass.OrderId;
            pa[1].Value = articelClass.PerentId;
            pa[2].Value = articelClass.ArticelClassName;
            pa[3].Value = articelClass.Link;
            pa[4].Value = articelClass.CreateDate;
            pa[5].Value = articelClass.UpdateDate;
            pa[6].Value = articelClass.IsDeleted;
            pa[7].Value = articelClass.Id;
            int r = accDBHelper.ExcuteSql(accConStr, sql, pa);
            if (r > 0)
                return true;
            else return false;
        }

        public List<ArticelClass> getList(string where)
        {
            return null;
        }

        public DataTable getDt(string where)
        {
            DataTable dt = new DataTable();
            string sql = "select * from tbl_ArticelClass where 1=1 ";
            dt = accDBHelper.GetDataTabel(accConStr, sql + where);
            return dt;
        }

        public ArticelClass getModel(long Id)
        {
            ArticelClass model = new ArticelClass();
            model.Id = Id;
            DataTable dt = getDt(" and [Id]=" + Id.ToString());
            if (dt.Rows.Count > 0)
            {
                model.ArticelClassName = dt.Rows[0]["ArticelClassName"].ToString();
                model.CreateDate = Convert.ToDateTime(dt.Rows[0]["CreateDate"]);
                model.IsDeleted = Convert.ToInt32(dt.Rows[0]["IsDeleted"]);
                model.Link = dt.Rows[0]["Link"].ToString();
                model.OrderId = Convert.ToInt64(dt.Rows[0]["OrderId"]);
                model.PerentId = Convert.ToInt64(dt.Rows[0]["PerentId"]);
                model.UpdateDate = Convert.ToDateTime(dt.Rows[0]["UpdateDate"]);
            }
            return model;
        }

        /// <summary>
        /// 获取一个父节点下的子节点
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataTable getListByPerent(long Id)
        {
            DataTable dt = new DataTable();
            string sql = "select * from tbl_ArticelClass where [IsDeleted]=0 and [PerentId]=" + Id.ToString()+" ORDER BY [OrderId] DESC";
            dt = accDBHelper.GetDataTabel(accConStr, sql);
            return dt;
        }
    }
}
