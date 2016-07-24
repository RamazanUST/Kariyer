using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Kariyer.App_Code
{
    public class PageHelper : Page
    {
        public void UserCheck() 
        {
            if (this.IsEmployer.HasValue && this.IsEmployer.Value)
            {
                if (!this.KULLANICI_ID.HasValue || !this.FIRMA_ID.HasValue)
                {
                    Response.Redirect("Logout.aspx");
                }
            }

            if (this.IsEmployee.HasValue && this.IsEmployee.Value)
            {
                if (!this.KULLANICI_ID.HasValue || !this.CV_ID.HasValue)
                {
                    Response.Redirect("Logout.aspx");
                }
            }

            if (this.IsTechnicalUser.HasValue && this.IsTechnicalUser.Value)
            {
                if (!this.KULLANICI_ID.HasValue)
                {
                    Response.Redirect("Logout.aspx");
                }
            }
        }

        public string PageTitle
        {
            get { return this.Title; }
            set { this.Title = value; }
        }

        public bool? IsEmployer { get; set; }
        public bool? IsEmployee { get; set; }
        public bool? IsTechnicalUser { get; set; }

        public Guid? CV_ID
        {
            get
            {
                var cvSession = Session["CurrentCv"];

                if (cvSession == null)
                {
                    return null;
                }

                return new Guid(cvSession.ToString());
            }
        }

        public Guid? KULLANICI_ID
        {
            get 
            {
                var kullaniciSession = Session["CurrentUser"];

                if (kullaniciSession == null)
                {
                    return null;
                }

                return new Guid(kullaniciSession.ToString());
            }
        }

        public Guid? FIRMA_ID
        {
            get
            {
                var firmaSession = Session["CurrentFirm"];

                if (firmaSession == null)
                {
                    return null;
                }

                return new Guid(firmaSession.ToString());
            }
        }
        
    }
}