using hom_IFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hom_webBack
{
    public partial class WebForm1 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn1_Click(object sender, EventArgs e)
        {
           
            //hom_IDAL.IDAL_Articel dal = a.Create_IDAL_Articel();
            //DataTable dt = dal.getDt("");
            //Response.Write(dt);
            //object o = Assembly.Load("hom.hom_accDAL").CreateInstance("hom.hom_accDAL.user.DAL_Articel");
        }


    }
}