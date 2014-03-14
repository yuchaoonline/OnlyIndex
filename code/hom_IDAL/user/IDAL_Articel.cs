using hom_Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace hom_IDAL
{
    public interface IDAL_Articel
    {
        bool Add(Articel articel);

        bool Del(long Id);

        bool FDel(long Id);

        bool Update(Articel articel);

        List<Articel> getList(string where);

        DataTable getDt(string where);

        Articel getModel(long Id);

        /// <summary>
        /// 获取dt根据sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataTable getDtBySql(string sql);
    }
}
