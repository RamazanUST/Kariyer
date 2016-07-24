using Kariyer.DTO;
using Kariyer.Entity;
using Kariyer.Repository;
using Kariyer.Repository.Fabric;
using System;
using System.Web;
using System.Linq;

namespace Kariyer.Business
{
    public static class Kullanici
    {
        public static DTO_Kullanici AL(string ePosta)
        {
            using (UnitOfWork work = new UnitOfWork())
            {
                var kullanici = work.Resolve<ICrud<KULLANICI>>().FindBySelect(c => c.E_POSTA == ePosta);

                if (kullanici == null)
                {
                    return null;
                }

                DTO_Kullanici dtoKullanici = new DTO_Kullanici();

                dtoKullanici.ID = kullanici.ID;
                dtoKullanici.FIRMA_ID = kullanici.FIRMA_ID;
                dtoKullanici.AD_SOYAD = kullanici.AD_SOYAD;
                dtoKullanici.E_POSTA = kullanici.E_POSTA;
                dtoKullanici.FIRMA = kullanici.FIRMAMI;
                dtoKullanici.TEKNIK_KULLANICI = kullanici.TEKNIK_KULLANICI;
                dtoKullanici.AKTIF = kullanici.AKTIF;

                return dtoKullanici;
            }
        }

        public static bool EpostaKontrol(string eposta)
        {
            using (UnitOfWork work = new UnitOfWork())
            {
                return work.Resolve<ICrud<KULLANICI>>().FindByAny(c => c.E_POSTA == eposta);
            }
        }

        public static bool TcKontrol(string tc)
        {
            using (UnitOfWork work = new UnitOfWork())
            {
                return work.Resolve<ICrud<CV>>().FindByAny(c => c.TC_KIMLIK == tc);
            }
        }

        public static DTO_Kullanici AL(Guid kullaniciID)
        {
            using (UnitOfWork work = new UnitOfWork())
            {
                var kullanici = work.Resolve<ICrud<KULLANICI>>().FindById(kullaniciID);

                if (kullanici == null)
                {
                    return null;
                }

                DTO_Kullanici dtoKullanici = new DTO_Kullanici();

                dtoKullanici.ID = kullanici.ID;
                dtoKullanici.FIRMA_ID = kullanici.FIRMA_ID;
                dtoKullanici.AD_SOYAD = kullanici.AD_SOYAD;
                dtoKullanici.E_POSTA = kullanici.E_POSTA;
                dtoKullanici.FIRMA = kullanici.FIRMAMI;
                dtoKullanici.TEKNIK_KULLANICI = kullanici.TEKNIK_KULLANICI;
                dtoKullanici.AKTIF = kullanici.AKTIF;

                return dtoKullanici;
            }
        }

        public static void AktifEt(Guid kullaniciID)
        {
            using (UnitOfWork work = new UnitOfWork())
            {
                var kullanici = work.Resolve<ICrud<KULLANICI>>().FindById(kullaniciID);

                try
                {
                    kullanici.AKTIF = true;

                    work.Resolve<ICrud<KULLANICI>>().Update(kullanici);
                    work.Save();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void ParolaDegistir(Guid kullaniciID, string parola)
        {
            using (UnitOfWork work = new UnitOfWork())
            {
                var kullanici = work.Resolve<ICrud<KULLANICI>>().FindById(kullaniciID);

                try
                {
                    kullanici.PAROLA = parola;

                    work.Resolve<ICrud<KULLANICI>>().Update(kullanici);
                    work.Save();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static DTO_Kullanici GirisYap(DTO_GirisYap login)
        {
            using (UnitOfWork work = new UnitOfWork())
            {
                var kullanici = work.Resolve<ICrud<KULLANICI>>().FindBySelect(c => c.E_POSTA == login.E_POSTA && c.PAROLA == login.MD5);

                if (kullanici == null)
                {
                    return null;
                }

                DTO_Kullanici dtoKullanici = new DTO_Kullanici();

                dtoKullanici.ID = kullanici.ID;
                dtoKullanici.CV_ID = kullanici.CV.Select(c => c.ID).FirstOrDefault();
                dtoKullanici.FIRMA_ID = kullanici.FIRMA_ID;
                dtoKullanici.AD_SOYAD = kullanici.AD_SOYAD;
                dtoKullanici.E_POSTA = kullanici.E_POSTA;
                dtoKullanici.FIRMA = kullanici.FIRMAMI;
                dtoKullanici.TEKNIK_KULLANICI = kullanici.TEKNIK_KULLANICI;
                dtoKullanici.AKTIF = kullanici.AKTIF;

                return dtoKullanici;
            }
        }

        public static Guid KullanıcıOlustur(DTO_KullaniciYeni kullanici, DTO_CvYeni cv, bool cvMi)
        {
            try
            {
                KULLANICI newKullanici = new KULLANICI();

                newKullanici.ID = Guid.NewGuid();
                newKullanici.FIRMA_ID = kullanici.FIRMA ? kullanici.FIRMA_ID : null;
                newKullanici.AD = kullanici.AD;
                newKullanici.SOYAD = kullanici.AD_SOYAD;
                newKullanici.AD_SOYAD = kullanici.AD_SOYAD;
                newKullanici.E_POSTA = kullanici.E_POSTA;
                newKullanici.PAROLA = kullanici.MD5;
                newKullanici.TEKNIK_KULLANICI = kullanici.TEKNIK_KULLANICI;
                newKullanici.FIRMAMI = kullanici.FIRMA;
                newKullanici.SILINDI = false;
                newKullanici.AKTIF = kullanici.AKTIF;

                using (UnitOfWork work = new UnitOfWork())
                {
                    work.Resolve<ICrud<KULLANICI>>().Insert(newKullanici);

                    if (cvMi)
                    {
                        CV newCv = new CV();

                        newCv.ID = Guid.NewGuid();
                        newCv.KULLANICI_ID = newKullanici.ID;
                        newCv.AD = cv.AD;
                        newCv.SOYAD = cv.SOYAD;
                        newCv.AD_SOYAD = cv.AD_SOYAD;
                        newCv.E_POSTA = cv.E_POSTA;
                        newCv.TC_KIMLIK = cv.TC;
                        newCv.DOGUM_TARIH = cv.DOGUM_TARIH;
                        newCv.UYRUK = cv.UYRUK;
                        newCv.CINSIYET = cv.Cinsiyet;
                        newCv.MEDENI_DURUM = cv.MedeniDurum;
                        newCv.OLUSTURAN = cv.AD_SOYAD;
                        newCv.OLUSTURMA_TARIH = DateTime.Now;
                        newCv.SILINDI = false;

                        work.Resolve<ICrud<CV>>().Insert(newCv);
                    }

                    work.Save();

                    return newKullanici.ID;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DTO_Kullanici GetCurrent
        {
            get
            {
                var kullaniciSession = HttpContext.Current.Session["KullaniciID"];

                if (kullaniciSession == null)
                {
                    return null;
                }

                Guid kullaniciID = new Guid(kullaniciSession.ToString());

                using (UnitOfWork work = new UnitOfWork())
                {
                    var kullanici = work.Resolve<ICrud<KULLANICI>>().FindById(kullaniciID);

                    if (kullanici == null)
                    {
                        return null;
                    }

                    DTO_Kullanici dtoKullanici = new DTO_Kullanici();

                    dtoKullanici.ID = kullanici.ID;
                    dtoKullanici.FIRMA_ID = kullanici.FIRMA_ID;
                    dtoKullanici.AD_SOYAD = kullanici.AD_SOYAD;
                    dtoKullanici.E_POSTA = kullanici.E_POSTA;
                    dtoKullanici.FIRMA = kullanici.FIRMAMI;
                    dtoKullanici.TEKNIK_KULLANICI = kullanici.TEKNIK_KULLANICI;
                    dtoKullanici.AKTIF = kullanici.AKTIF;

                    return dtoKullanici;
                }
            }
        }
    }
}
