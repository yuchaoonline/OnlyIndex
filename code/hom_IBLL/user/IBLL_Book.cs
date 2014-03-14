using hom_Entity;
using hom_Entity.user;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace hom_IBLL
{
    public interface IBLL_Book
    {
        bool Add(Book book);

        bool Del(long Id);

        bool FDel(long Id);

        bool Update(Book book);

        List<Book> getList(string where);

        DataTable getDt(string where);

        Book getModel(long Id);

    }
}
