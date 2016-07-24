using Core;
using Kariyer.App_Code;
using Kariyer.Business;
using Kariyer.Defination;
using Kariyer.DTO;
using System;
using System.Web.UI.WebControls;

namespace Kariyer
{
    public partial class KullaniciKayit : System.Web.UI.Page
    {
        #region EventMethod

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.KontrolYukle();
            }
        }

        protected void K_OK_Click(object sender, EventArgs e)
        {
            string ad = this.K_AD.Text.Trim();
            string soyad = this.K_SOYAD.Text.Trim();
            string eposta = this.K_EPOSTA.Text;
            Cinsiyet cinsiyet = this.K_KADIN.Checked ? Cinsiyet.Kadin : Cinsiyet.Erkek;
            string cep = this.K_TELEFON.Text.Trim();
            int yil = this.K_YIL.SelectedValue.ToIntegerValue().Value;
            int ay = this.K_AY.SelectedValue.ToIntegerValue().Value;
            int gun = this.K_GUN.SelectedValue.ToIntegerValue().Value;
            DateTime dogumTarih = new DateTime(yil, ay, gun);
            MedeniDurum medeniDurum = this.K_EVLI.Checked ? MedeniDurum.Evli : MedeniDurum.Bekar;
            string tc = String.Empty;
            string uyruk = string.Empty;

            if (Kullanici.EpostaKontrol(eposta))
            {
                this.K_MESAJ.Text = Utility.UyariVer(HataTip.hata, "Bu e-posta adresi ile kayıtlı kullanıcı bulunmaktadır.");
                return;
            }

            if (this.K_YABANCI.Checked)
            {
                tc = "00000000000";
                uyruk = this.K_UYRUK.Text.Trim();
            }
            else
            {
                tc = this.K_TC.Text.Trim();
                uyruk = "T.C.";

                if (Kullanici.TcKontrol(tc))
                {
                    this.K_MESAJ.Text = Utility.UyariVer(HataTip.hata, "Bu T.C. kimlik numarası ile kayıtlı kullanıcı bulunmaktadır.");
                    return;
                }
            }

            string sifre = this.K_SİFRE_TEKRAR.Text.Trim();

            try
            {
                DTO_KullaniciYeni kullanici = new DTO_KullaniciYeni()
                {
                    AD = ad,
                    SOYAD = soyad,
                    E_POSTA = eposta,
                    FIRMA = false,
                    TEKNIK_KULLANICI = false,
                    PAROLA = sifre,
                    AKTIF = false
                };

                DTO_CvYeni cv = new DTO_CvYeni()
                {
                    AD = ad,
                    SOYAD = soyad,
                    E_POSTA = eposta,
                    CINSIYET = cinsiyet,
                    DOGUM_TARIH = dogumTarih,
                    MEDENIDURUM = medeniDurum,
                    TC = tc,
                    UYRUK = uyruk

                };

                var id = Kullanici.KullanıcıOlustur(kullanici, cv, true);

                string msj  ="Açmış olduğunuz üyeliği aktifleştirebilmeniz için bu mail gönderilmiştir.";
                string link = Prop.WebSiteUrl + "/Login.aspx?aktif="+id+"";
                string aciklama = "Aşağıdaki linkten hesabınıza giriş yaparak üyeliğinizi aktifleştirebilirsiniz :";
                Utility.EmailGonder(kullanici.AD_SOYAD.ToCamel(), kullanici.E_POSTA, "Hesap Aktivasyon", msj, true, link, aciklama);

                this.K_MESAJ.Text = Utility.UyariVer(HataTip.bilgi, "Kaydınız başarıyla oluşturulmuş olup, e-posta adresnize gelen mailden hesabınızı etkinleştirebilirsiniz.");
            }
            catch (Exception ex)
            {
                this.K_MESAJ.Text = Utility.UyariVer(HataTip.hata, ex.Message);
            }
        }

        #endregion

        #region Method

        private void KontrolYukle()
        {
            //Yıl
            this.K_YIL.Items.Add(new ListItem("Yıl", "0"));
            int yil = DateTime.Now.Year - 15;
            for (int i = yil; i >= 1945; i--)
            {
                this.K_YIL.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            //Ay
            this.K_AY.Items.Add(new ListItem("Ay", "0"));
            for (int i = 1; i <= 12; i++)
            {
                this.K_AY.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            //Gün
            this.K_GUN.Items.Add(new ListItem("Gün", "0"));
            for (int i = 1; i <= 31; i++)
            {
                this.K_GUN.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        #endregion

        #region ServerValidate

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

        protected void R_TC_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!this.K_YABANCI.Checked)
            {
                args.IsValid = Checker.IsTc(Convert.ToInt64(this.K_TC.Text));
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void R_UYRUK_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (this.K_YABANCI.Checked)
            {
                args.IsValid = !String.IsNullOrEmpty(this.K_UYRUK.Text);
            }
            else
            {
                args.IsValid = true;
            }
        }

        #endregion

    }
}