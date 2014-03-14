using hom_Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace hom_IDAL
{
    public interface IDAL_ArticelClass
    {
        bool Add(ArticelClass articelClass);

        bool Del(long Id);

        bool FDel(long Id);

        bool Update(ArticelClass articelClass);

        List<ArticelClass> getList(string where);

        DataTable getDt(string where);

        ArticelClass getModel(long Id);

        /// <summary>
        /// 获取一个父节点下的子节点
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        DataTable getListByPerent(long Id);
    }
}
