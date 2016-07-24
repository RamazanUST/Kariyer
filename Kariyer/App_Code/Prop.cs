using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Kariyer.App_Code
{
    public class Prop
    {
        public static string WebSiteUrl
        {
            get
            {
                return HttpContext.Current.Request.IsLocal ? "http://localhost:56105" : "http://www.prismakademi.com";
            }
        }

        public static string MailGonderen
        {
            get
            {
                return WebConfigurationManager.AppSettings["Mail"];
            }
        }

        public static string MailGonderenSifre
        {
            get
            {
                return WebConfigurationManager.AppSettings["Sifre"];
            }
        }
    }
}