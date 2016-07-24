using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kariyer.Master
{
    public partial class IsArayan : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var kullaniciID = Session["CurrentUser"];
            var cvID = Session["CurrentCv"];

            if (kullaniciID == null || cvID == null)
            {
                Response.Redirect("/Login.aspx");
            }
        }
    }
}