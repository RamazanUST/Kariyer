using Kariyer.App_Code;
using Kariyer.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kariyer
{
    public partial class ParolaUnuttum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void K_OK_Click(object sender, EventArgs e)
        {
            string mail = this.K_EPOSTA.Text.Trim();

            if (!Kullanici.EpostaKontrol(mail))
            {
                this.K_MESAJ.Text = Utility.UyariVer(HataTip.hata, "Girilen e-posta adresi sistemde kayıtlı değil.");
                return;
            }

            var kullanici = Kullanici.AL(mail);

            Utility.EmailGonder(kullanici.AD_SOYAD, mail, "Parola Yenileme İsteği", "Bu e-posta parola yenileme isteğiniz üzerine gönderilmiştir.", true, Prop.WebSiteUrl + "/ParolaYeni.aspx?parolayenile=" + kullanici.ID + "", "Aşağıda bulunan linlten yeni parolanızı oluşturabilirsiniz.");

            this.K_MESAJ.Text = Utility.UyariVer(HataTip.bilgi, "Yenieleme isteği alınmıştır. E-posta kutunuzu kontrol ediniz.");
        }
    }
}