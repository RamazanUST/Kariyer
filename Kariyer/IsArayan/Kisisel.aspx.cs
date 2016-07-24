using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kariyer.IsArayan
{
    public partial class Kisisel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.KontrolYukle();
            }
        }

        private void KontrolYukle()
        {

            //Yıl
            this.K_YIL.Items.Add(new ListItem("Yıl", "0"));
            int yil = DateTime.Now.Year - 15;
            for (int i = yil; i >= 1945; i--)
            {
                this.K_YIL.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            //Asker Yıl
            for (int i = DateTime.Now.Year; i >= 1965; i--)
            {
                this.K_AS_YIL.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            //Tecil Yıl
            for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 10; i++)
            {
                this.K_TECIL_YIL.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            //Ay
            this.K_AY.Items.Add(new ListItem("Ay", "0"));
            this.K_AS_AY.Items.Add(new ListItem("Ay", "0"));
            this.K_TECIL_AY.Items.Add(new ListItem("Ay", "0"));
            for (int i = 1; i <= 12; i++)
            {
                this.K_AY.Items.Add(new ListItem(i.ToString(), i.ToString()));
                this.K_AS_AY.Items.Add(new ListItem(i.ToString(), i.ToString()));
                this.K_TECIL_AY.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            //Gün
            this.K_GUN.Items.Add(new ListItem("Gün", "0"));
            for (int i = 1; i <= 31; i++)
            {
                this.K_GUN.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            //Asker Yapılma Tarih

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ((this.K_ERKEK.Checked) || (this.K_KADIN.Checked))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidator1_ServerValidate1(object source, ServerValidateEventArgs args)
        {
            if (this.K_AY.SelectedValue == "0" || this.K_YIL.SelectedValue == "0" || this.K_GUN.SelectedValue == "0")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ((this.K_EVLI.Checked) || (this.K_BEKAR.Checked))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}