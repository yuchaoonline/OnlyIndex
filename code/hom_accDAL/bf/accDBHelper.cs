using System;
using System.Data;
using System.Data.OleDb;

namespace hom_accDAL
{
    public class accDBHelper
    {
        #region //执行SQL语句

        /// <summary>
        /// 无参执行SQL语句
        /// </summary>
        /// <param name="ConnStr">Sql Server连接字符串</param>
        /// <param name="SqlStr">SQL语句字符串</param>
        /// <returns>返回影响行数</returns>
        public static int ExcuteSql(string ConnStr, string SqlStr)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(ConnStr))
                {
                    conn.Open();
                    using (OleDbCommand com = new OleDbCommand(SqlStr, conn))
                    {
                        int r = com.ExecuteNonQuery();
                        conn.Close(); return r;
                    }

                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// 有参数执行SQL语句
        /// </summary>
        /// <param name="ConnStr">Sql Server连接字符串</param>
        /// <param name="SqlStr">SQL语句</param>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        public static int ExcuteSql(string ConnStr, string SqlStr, params OleDbParameter[] parameter)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(ConnStr))
                using (OleDbCommand com = new OleDbCommand(SqlStr, conn))
                {
                    conn.Open();
                    com.Parameters.AddRange(parameter);
                    int r = com.ExecuteNonQuery();
                    conn.Close();
                    return r;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// 延迟执行SQL语句
        /// </summary>
        /// <param name="ConnStr">Sql Server连接字符串</param>
        /// <param name="SqlStr">SQL语句</param>
        /// <param name="Times">延迟时间（默认30秒）</param>
        /// <returns></returns>
        public static int ExcuteSql(string ConnStr, string SqlStr, int Times)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(ConnStr))
                {
                    conn.Open();
                    using (OleDbCommand com = new OleDbCommand(SqlStr, conn))
                    {
                        com.CommandTimeout = Times;
                        int r = com.ExecuteNonQuery();
                        conn.Close(); return r;
                    }

                }
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region //获取DataTable

        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="ConnStr">Sql Server连接字符串</param>
        /// <param name="SqlStr">SQL查询语句</param>
        /// <returns></returns>
        public static DataTable GetDataTabel(string ConnStr, string SqlStr)
        {
            return GetDataSet(ConnStr, SqlStr).Tables[0];
        }

        #endregion

        #region//获取DataSet

        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="ConnStr">连接字符串</param>
        /// <param name="SqlStr">SQL语句</param>
        /// <returns></returns>
        public static DataSet GetDataSet(string ConnStr, string SqlStr)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(ConnStr))
                {
                    conn.Open();
                    using (OleDbDataAdapter da = new OleDbDataAdapter(SqlStr, conn))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// 获取DataSet（存储过程）
        /// </summary>
        /// <param name="ConnStr">连接字符串</param>
        /// <param name="ProcedureName">存储过程名称</param>
        /// <param name="Parameter">参数</param>
        /// <returns></returns>
        public static DataSet GetDataSetP(string ConnStr, string ProcedureName, OleDbParameter[] Parameter)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(ConnStr))
                using (OleDbDataAdapter da = new OleDbDataAdapter(ProcedureName, conn))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach (OleDbParameter sp in Parameter)
                        da.SelectCommand.Parameters.Add(sp);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region //执行存储过程

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="ConnStr">Sql Server连接字符串</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">参数</param>
        public static int ExcuteProcedure(string ConnStr, string storedProcName, OleDbParameter[] parameters)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(ConnStr))
                {

                    OleDbCommand com = new OleDbCommand(storedProcName, conn);
                    com.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        foreach (OleDbParameter pa in parameters)
                        {
                            com.Parameters.Add(pa);
                        }
                    }
                    conn.Open();
                    int r = com.ExecuteNonQuery();
                    conn.Close();
                    return r;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion
    }
}
