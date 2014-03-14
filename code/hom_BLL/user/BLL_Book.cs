using hom_Entity;
using hom_Entity.user;
using hom_IBLL;
using System.Collections.Generic;
using System.Data;

namespace hom_BLL
{
    public class BLL_Book : BLL_Base, IBLL_Book
    {

        public bool Add(Book book)
        {
            return ifa.Create_IDAL_Book().Add(book);
        }

        public bool Del(long Id)
        {
            return ifa.Create_IDAL_Book().Del(Id);
        }

        public bool FDel(long Id)
        {
            return ifa.Create_IDAL_Book().FDel(Id);
        }

        public bool Update(Book book)
        {
            return ifa.Create_IDAL_Book().Update(book);
        }

        public List<Book> getList(string where)
        {
            return ifa.Create_IDAL_Book().getList(where);
        }

        public DataTable getDt(string where)
        {
            return ifa.Create_IDAL_Book().getDt(where);
        }

        public Book getModel(long Id)
        {
            return ifa.Create_IDAL_Book().getModel(Id);
        }

    }
}
