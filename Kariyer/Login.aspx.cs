using Kariyer.App_Code;
using Kariyer.Business;
using Kariyer.DTO;
using System;
using System.Web;

namespace Kariyer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string kullaniciAktif = this.Request.QueryString["aktif"];

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
                                Kullanici.AktifEt(kullaniciId);
                                string mesaj = "Sayın " + kullanici.AD_SOYAD + ",<br /> Hesabınız aktif edilmiştir. Giriş yaparak hesabınıza erişebilirsiniz.";
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
            }
        }

        protected void K_OK_Click(object sender, EventArgs e)
        {
            string eposta = this.K_EPOSTA.Text.Trim();
            string parola = this.K_PAROLA.Text.Trim();

            var kullanici = Kullanici.GirisYap(new DTO_GirisYap() { E_POSTA = eposta, PAROLA = parola });

            if (kullanici == null)
            {
                this.K_MESAJ.Text = Utility.UyariVer(HataTip.hata, "Bilgilerinizi kontrol ederek tekrar deneyiniz.");
                return;
            }

            if (!kullanici.AKTIF)
            {
                this.K_MESAJ.Text = Utility.UyariVer(HataTip.hata, "Hesabınız aktif edilmemiş. Lütfen e-posta kutunuzu kontrol ediniz.");
                return;
            }

            Session["CurrentUser"] = kullanici.ID;
            Session["CurrentCv"] = kullanici.CV_ID;

            if (this.K_HATIRLA.Checked)
            {
                HttpCookie cookie = new HttpCookie("KariyerRememberMe");
                cookie.Values.Add("UserId", kullanici.ID.ToString());
                cookie.Expires = DateTime.Now.AddDays(15);
                Response.Cookies.Add(cookie);
            }

            if (kullanici.FIRMA)
            {
                Response.Redirect("/IsVeren/Default.aspx");
            }
            else
            {
                Response.Redirect("/IsArayan/Default.aspx");
            }
        }
    }
}