using Core;
using Kariyer.App_Code;
using Kariyer.Business;
using Kariyer.Defination;
using Kariyer.DTO;
using System;
using System.Web.UI.WebControls;

namespace Kariyer.IsArayan
{
    public partial class Giris : PageHelper
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                base.IsEmployee = true;
                base.UserCheck();

                var isDurumu = Helper.GetEnumDescriptionList<IsAramaDurum>();
                this.K_IS_DURUM.DataSource = isDurumu;
                this.K_IS_DURUM.DataTextField = "Value";
                this.K_IS_DURUM.DataValueField = "Key";
                this.K_IS_DURUM.DataBind();
                this.K_IS_DURUM.Items.Insert(0, new ListItem("Seçiniz", "0"));

                try
                {
                    var giris = Cv.GirisAl(this.CV_ID.Value);
                    this.K_BASLIK.Text = giris.CV_BASLIK;
                    this.K_MESLEK.Text = giris.MESLEK;
                    this.K_IS_DURUM.SelectedValue = giris.IS_DURUM.HasValue ? giris.IS_DURUM.ToString() : "0";

                }
                catch (Exception ex)
                {
                    Utility.UyariVer(HataTip.hata, ex.Message);
                }

            }
        }

        protected void K_OK_Click(object sender, EventArgs e)
        {
            try
            {
                string baslik = this.K_BASLIK.Text.Trim();
                string meslek = this.K_MESLEK.Text.Trim();
                byte isDurum = ((byte)this.K_IS_DURUM.SelectedValue.ToIntegerValue());

                DTO_Cv_Giris giris = new DTO_Cv_Giris()
                {
                    CV_BASLIK = baslik,
                    MESLEK = meslek,
                    IS_DURUM = isDurum

                };

                Cv.GirisDuzenle(this.CV_ID.Value, giris);

                Response.Redirect("/IsArayan/Kisisel.aspx");
            }
            catch (Exception ex)
            {
                Utility.UyariVer(HataTip.hata, ex.Message);
            }
        }
    }
}