using Kariyer.DTO;
using Kariyer.Entity;
using Kariyer.Repository;
using Kariyer.Repository.Fabric;
using System;

namespace Kariyer.Business
{
    public class Cv
    {
        public static DTO_Cv_Giris GirisAl(Guid cvID)
        {
            try
            {
                using (UnitOfWork work = new UnitOfWork() )
                {
                    var cv = work.Resolve<ICrud<CV>>().FindById(cvID);

                    return new DTO_Cv_Giris()
                    {
                        CV_BASLIK = cv.CV_BASLIK,
                        MESLEK = cv.MESLEK,
                        IS_DURUM = cv.IS_DURUM
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void GirisDuzenle(Guid cvID, DTO_Cv_Giris cvGiris)
        {
            try
            {
                using (UnitOfWork work = new UnitOfWork())
                {
                    var cv = work.Resolve<ICrud<CV>>().FindById(cvID);

                    cv.CV_BASLIK = cvGiris.CV_BASLIK;
                    cv.MESLEK = cvGiris.MESLEK;
                    cv.IS_DURUM = cvGiris.IS_DURUM;

                    work.Resolve<ICrud<CV>>().Update(cv);

                    work.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
