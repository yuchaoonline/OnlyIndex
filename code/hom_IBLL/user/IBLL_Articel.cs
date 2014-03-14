using hom_Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace hom_IBLL
{
    public interface IBLL_Articel
    {
        bool Add(Articel articel);

        bool Del(long Id);

        bool FDel(long Id);

        bool Update(Articel articel);

        List<Articel> getList(string where);

        DataTable getDt(string where);

        Articel getModel(long Id);

        /// <summary>
        /// 获取从start开始起Count条文章标题及内容简介
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        Json getJsonTC(int Start, int Count);

    }
}
