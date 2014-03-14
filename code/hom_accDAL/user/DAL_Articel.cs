using hom_accDAL;
using hom_Entity;
using hom_IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace hom_accDAL
{
    public class DAL_Articel : DAL_Base, IDAL_Articel
    {
        public bool Add(Articel articel)
        {
            string sql = @"insert into tbl_Articel([OrderId],[ArticelClassId],[Title],[Pic],[Content],[CreateDate],[UpdateDate],[IsTop],[IsDeleted]) 
 values(@OrderId,@ArticelClassId,@Title,@Pic,@Content,@CreateDate,@UpdateDate,@IsTop,@IsDeleted)";
            OleDbParameter[] pa = 
            { 
                new OleDbParameter("@OrderId", OleDbType.BigInt, 64), 
                new OleDbParameter("@ArticelClassId",OleDbType.BigInt, 64),
                new OleDbParameter("@Title",OleDbType.VarWChar, 200),
                new OleDbParameter("@Pic",OleDbType.VarWChar, 200),
                new OleDbParameter("@Content",OleDbType.VarWChar, 4000),
                new OleDbParameter("@CreateDate",OleDbType.Date, 200),
                new OleDbParameter("@UpdateDate",OleDbType.Date, 200),
                new OleDbParameter("@IsTop",OleDbType.SmallInt, 2),
                new OleDbParameter("@IsDeleted",OleDbType.SmallInt, 2)
            };
            pa[0].Value = articel.OrderId;
            pa[1].Value = articel.ArticelClassId;
            pa[2].Value = articel.Title;
            pa[3].Value = articel.Pic;
            pa[4].Value = articel.Content;
            pa[5].Value = articel.CreateDate;
            pa[6].Value = articel.UpdateDate;
            pa[7].Value = articel.IsTop;
            pa[8].Value = articel.IsDeleted;
            int r = accDBHelper.ExcuteSql(accConStr, sql, pa);
            if (r > 0)
                return true;
            else return false;
        }

        public bool Del(long Id)
        {
            string sql = "delete tbl_Articel where [Id]=@Id";
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
            int r = accDBHelper.ExcuteSql(accConStr, "update tbl_Articel set [IsDeleted]=1 where [Id]=" + Id.ToString());
            if (r > 0)
                return true;
            else return false;
        }

        public bool Update(Articel articel)
        {
            string sql = @"update tbl_Articel set [OrderId]=@OrderId,[ArticelClassId]=@ArticelClassId,[Title]=@Title,
[Pic]=@Pic,[Content]=@Content,[CreateDate]=@CreateDate,[UpdateDate]=@UpdateDate,[IsTop]=@IsTop,[IsDeleted]=@IsDeleted where [Id]=@Id";
            OleDbParameter[] pa = 
            { 
                new OleDbParameter("@OrderId", OleDbType.BigInt, 64), 
                new OleDbParameter("@ArticelClassId",OleDbType.BigInt, 64),
                new OleDbParameter("@Title",OleDbType.VarWChar, 200),
                new OleDbParameter("@Pic",OleDbType.VarWChar, 200),
                new OleDbParameter("@Content",OleDbType.VarWChar, 4000),
                new OleDbParameter("@CreateDate",OleDbType.Date, 200),
                new OleDbParameter("@UpdateDate",OleDbType.Date, 200),
                new OleDbParameter("@IsTop",OleDbType.SmallInt, 2),
                new OleDbParameter("@IsDeleted",OleDbType.SmallInt, 2),
                new OleDbParameter("@Id",OleDbType.BigInt, 64)
            };
            pa[0].Value = articel.OrderId;
            pa[1].Value = articel.ArticelClassId;
            pa[2].Value = articel.Title;
            pa[3].Value = articel.Pic;
            pa[4].Value = articel.Content;
            pa[5].Value = articel.CreateDate;
            pa[6].Value = articel.UpdateDate;
            pa[7].Value = articel.IsTop;
            pa[8].Value = articel.IsDeleted;
            pa[9].Value = articel.Id;
            int r = accDBHelper.ExcuteSql(accConStr, sql, pa);
            if (r > 0)
                return true;
            else return false;
        }

        public List<Articel> getList(string where)
        {
            return null;
        }

        public DataTable getDt(string where)
        {
            DataTable dt = new DataTable();
            string sql = "select * from tbl_Articel where 1=1 ";
            dt = accDBHelper.GetDataTabel(accConStr, sql + where);
            return dt;
        }

        public Articel getModel(long Id)
        {
            Articel model = new Articel();
            model.Id = Id;
            DataTable dt = getDt(" and [Id]=" + Id.ToString());
            if (dt.Rows.Count > 0)
            {
                model.ArticelClassId = dt.Rows[0]["ArticelClassId"].ToString() == "" ? 0 : Convert.ToInt64(dt.Rows[0]["ArticelClassId"].ToString());
                model.CreateDate = dt.Rows[0]["CreateDate"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["CreateDate"].ToString());
                model.IsDeleted = dt.Rows[0]["IsDeleted"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[0]["IsDeleted"].ToString());
                model.Content = dt.Rows[0]["Content"].ToString();
                model.OrderId = dt.Rows[0]["OrderId"].ToString() == "" ? 0 : Convert.ToInt64(dt.Rows[0]["OrderId"].ToString());
                model.IsTop = dt.Rows[0]["IsTop"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[0]["IsTop"].ToString());
                model.UpdateDate = dt.Rows[0]["UpdateDate"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["UpdateDate"].ToString());
                model.Title = dt.Rows[0]["Title"].ToString();

            }
            return model;
        }

        /// <summary>
        /// 获取dt根据sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable getDtBySql(string sql)
        {
            return accDBHelper.GetDataTabel(accConStr, sql);
        }
    }
}
