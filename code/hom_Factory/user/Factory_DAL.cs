using hom_IDAL;
using hom_IFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace hom_Factory
{
    public class Factory_DAL : IFactory_DAL
    {
        public IDAL_Articel Create_IDAL_Articel()
        {
            return (IDAL_Articel)DependencyProvider.GetDALObject("DAL_Articel");
        }

        public IDAL_ArticelClass Create_IDAL_ArticelClass()
        {
            return (IDAL_ArticelClass)DependencyProvider.GetDALObject("DAL_ArticelClass");

        }
        public IDAL_Book Create_IDAL_Book()
        {
            return (IDAL_Book)DependencyProvider.GetDALObject("DAL_Book");

        }
    }
}
