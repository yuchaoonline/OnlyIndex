using hom_Entity;
using hom_Entity.user;
using hom_IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace hom_accDAL
{
    public class DAL_Book : DAL_Base, IDAL_Book
    {
        public bool Add(Book book)
        {
            string sql = @"insert into tbl_Book([OrderId],[BookName],[QQ],[Email],[Tel],[Address],[BackLook],[Content],[CreateDate],[UpdateDate],[IsDeleted]) 
values(@OrderId,@BookName,@QQ,@Email,@Tel,@Address,@BackLook,@Content,@CreateDate,@UpdateDate,@IsDeleted);";
            OleDbParameter[] pa = 
            { 
                new OleDbParameter("@OrderId", OleDbType.BigInt, 64), 
                new OleDbParameter("@BookName",OleDbType.VarWChar, 200),
                new OleDbParameter("@QQ",OleDbType.VarWChar, 200),
                new OleDbParameter("@Email",OleDbType.VarWChar, 200),
                new OleDbParameter("@Tel",OleDbType.VarWChar, 200),
                new OleDbParameter("@Address",OleDbType.VarWChar, 200),
                new OleDbParameter("@BackLook",OleDbType.Integer, 32),
                new OleDbParameter("@Content",OleDbType.VarWChar, 200),
                new OleDbParameter("@CreateDate",OleDbType.Date, 200),
                new OleDbParameter("@UpdateDate",OleDbType.Date, 200),
                new OleDbParameter("@IsDeleted",OleDbType.SmallInt, 2)
            };
            pa[0].Value = book.OrderId;
            pa[1].Value = book.BookName;
            pa[2].Value = book.QQ;
            pa[3].Value = book.Email;
            pa[4].Value = book.Tel;
            pa[5].Value = book.Address;
            pa[6].Value = book.BackLook;
            pa[7].Value = book.Content;
            pa[8].Value = book.CreateDate;
            pa[9].Value = book.UpdateDate;
            pa[10].Value = book.IsDeleted;
            int r = accDBHelper.ExcuteSql(accConStr, sql, pa);
            if (r > 0)
                return true;
            else return false;
        }

        public bool Del(long Id)
        {
            string sql = "delete from tbl_Book where [Id]=@Id";
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
            int r = accDBHelper.ExcuteSql(accConStr, @"update tbl_Book set [IsDeleted]=1 where [Id]=" + Id.ToString());
            if (r > 0)
                return true;
            else return false;
        }

        public bool Update(Book book)
        {
            string sql = @"update tbl_Book set [OrderId]=@OrderId,[BookName]=@BookName,[QQ]=@QQ,[Email]=@Email,[Tel]=@Tel,[Address]=@Address,[BackLook]=@BackLook,[Content]=@Content,[CreateDate]=@CreateDate,[UpdateDate]=@UpdateDate,[IsDeleted]=@IsDeleted where [Id]=@Id;";
            OleDbParameter[] pa = 
            { 
                new OleDbParameter("@OrderId", OleDbType.BigInt, 64), 
                new OleDbParameter("@BookName",OleDbType.VarWChar, 200),
                new OleDbParameter("@QQ",OleDbType.VarWChar, 200),
                new OleDbParameter("@Email",OleDbType.VarWChar, 200),
                new OleDbParameter("@Tel",OleDbType.VarWChar, 200),
                new OleDbParameter("@Address",OleDbType.VarWChar, 200),
                new OleDbParameter("@BackLook",OleDbType.Integer, 32),
                new OleDbParameter("@Content",OleDbType.VarWChar, 200),
                new OleDbParameter("@CreateDate",OleDbType.Date, 200),
                new OleDbParameter("@UpdateDate",OleDbType.Date, 200),
                new OleDbParameter("@IsDeleted",OleDbType.SmallInt, 2),
                new OleDbParameter("@Id",OleDbType.SmallInt, 64)
            };
            pa[0].Value = book.OrderId;
            pa[1].Value = book.QQ;
            pa[2].Value = book.BookName;
            pa[3].Value = book.Email;
            pa[4].Value = book.Tel;
            pa[5].Value = book.Address;
            pa[6].Value = book.BackLook;
            pa[7].Value = book.Content;
            pa[8].Value = book.CreateDate;
            pa[9].Value = book.UpdateDate;
            pa[10].Value = book.IsDeleted;
            pa[11].Value = book.Id;
            int r = accDBHelper.ExcuteSql(accConStr, sql, pa);
            if (r > 0)
                return true;
            else return false;
        }

        public List<Book> getList(string where)
        {
            return null;
        }

        public DataTable getDt(string where)
        {
            DataTable dt = new DataTable();
            string sql = "select * from tbl_Book where 1=1 ";
            dt = accDBHelper.GetDataTabel(accConStr, sql + where);
            return dt;
        }

        public Book getModel(long Id)
        {
            Book model = new Book();
            model.Id = Id;
            DataTable dt = getDt(" and [Id]=" + Id.ToString());
            if (dt.Rows.Count > 0)
            {
                model.QQ = dt.Rows[0]["ArticelClassName"].ToString();
                model.BookName = dt.Rows[0]["BookName"].ToString();
                model.Email = dt.Rows[0]["Email"].ToString();
                model.Tel = dt.Rows[0]["Tel"].ToString();
                model.Address = dt.Rows[0]["Address"].ToString();
                model.BackLook = Convert.ToInt32(dt.Rows[0]["BackLook"]);
                model.Content = dt.Rows[0]["Content"].ToString();
                model.CreateDate = Convert.ToDateTime(dt.Rows[0]["CreateDate"]);
                model.IsDeleted = Convert.ToInt32(dt.Rows[0]["IsDeleted"]);
                model.OrderId = Convert.ToInt64(dt.Rows[0]["OrderId"]);
                model.UpdateDate = Convert.ToDateTime(dt.Rows[0]["UpdateDate"]);
            }
            return model;
        }

    }
}
