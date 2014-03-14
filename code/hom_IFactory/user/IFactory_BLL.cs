using hom_IBLL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hom_IFactory
{
    public interface IFactory_BLL
    {
        IBLL_Articel Create_IBLL_Articel();
        IBLL_ArticelClass Create_IBLL_ArticelClass();
        IBLL_Book Create_IBLL_Book();
    }
}
