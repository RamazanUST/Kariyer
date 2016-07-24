using Core;
using Kariyer.App_Code;
using Kariyer.Business;
using System;

namespace Kariyer
{
    public partial class ParolaYeni : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string kullaniciAktif = this.Request.QueryString["parolayenile"];

                if (!String.IsNullOrEmpty(kullaniciAktif))
                {
                    var kullaniciId = default(Guid);

                    if (Guid.TryParse(kullaniciAktif, out kullaniciId))
                    {
                        var kullanici = Kullanici.AL(kullaniciId);

                        if (kullanici == null)
                        {
                            Response.Redirect("Login.aspx");
                        }
                        else
                        {
                            try
                            {
                                string mesaj = "Sayın " + kullanici.AD_SOYAD + ",<br /> Parola yenileme isteğimiz onaylanmıştır. Parolanızı değiştirebilirsiniz.";
                                this.K_MESAJ.Text = Utility.UyariVer(HataTip.bilgi, mesaj);
                            }
                            catch (Exception ex)
                            {
                                this.K_MESAJ.Text = Utility.UyariVer(HataTip.hata, ex.Message);
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void K_OK_Click(object sender, EventArgs e)
        {
            try
            {
                string parola = this.K_SİFRE_TEKRAR.Text.Trim();
                Guid id = new Guid(this.Request.QueryString["parolayenile"]);

                Kullanici.ParolaDegistir(id, parola.ToMd5());

                this.K_MESAJ.Text = Utility.UyariVer(HataTip.bilgi, "Parolanızı başarıyla değiştirdiniz.");
            }
            catch (Exception ex)
            {
                this.K_MESAJ.Text = Utility.UyariVer(HataTip.hata, ex.Message);
            }
        }
    }
}