using hom_Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace hom_IBLL
{
    public interface IBLL_ArticelClass
    {
        bool Add(ArticelClass articel);

        bool Del(long Id);

        bool FDel(long Id);

        bool Update(ArticelClass articel);

        List<ArticelClass> getList(string where);

        DataTable getDt(string where);

        ArticelClass getModel(long Id);

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        Json getMenu();
    }
}
