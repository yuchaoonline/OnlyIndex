using hom_IBLL;
using hom_IFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hom_Factory
{
    public class Factory_BLL : IFactory_BLL
    {
        public IBLL_Articel Create_IBLL_Articel()
        {
            return (IBLL_Articel)DependencyProvider.GetBLLObject("BLL_Articel");
        }

        public IBLL_ArticelClass Create_IBLL_ArticelClass()
        {
            return (IBLL_ArticelClass)DependencyProvider.GetBLLObject("BLL_ArticelClass");

        }
        public IBLL_Book Create_IBLL_Book()
        {
            return (IBLL_Book)DependencyProvider.GetBLLObject("BLL_Book");

        }
    }
}
