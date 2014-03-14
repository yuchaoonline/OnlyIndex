using hom_IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace hom_IFactory
{
    public interface IFactory_DAL
    {
        IDAL_Articel Create_IDAL_Articel();
        IDAL_ArticelClass Create_IDAL_ArticelClass();
        IDAL_Book Create_IDAL_Book();
    }
}
