using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Kariyer.Defination;

namespace Kariyer.DTO
{
    public class DTO_CvYeni
    {
        public Guid KULLANICI_ID { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public string AD_SOYAD
        {
            get
            {
                return (this.AD + " " + this.SOYAD).ToCamel();
            }
        }
        public string E_POSTA { get; set; }
        public string TC { get; set; }
        public DateTime DOGUM_TARIH { get; set; }
        public string UYRUK { get; set; }
        public Cinsiyet CINSIYET { get; set; }
        public MedeniDurum MEDENIDURUM { get; set; }

        public byte Cinsiyet
        {
            get
            {
                return (byte)this.CINSIYET;
            }
        }

        public byte MedeniDurum
        {
            get
            {
                return (byte)this.MEDENIDURUM;
            }
        }
    }
}
