using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Kariyer.Defination;

namespace Kariyer.DTO
{
    public class DTO_KullaniciYeni
    {
        public Guid? FIRMA_ID { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public string AD_SOYAD {
            get
            {
                return (this.AD + " " + this.SOYAD).ToCamel();
            }
        }
        public string E_POSTA { get; set; }
        public string PAROLA { get; set; }
        public bool TEKNIK_KULLANICI { get; set; }
        public bool FIRMA { get; set; }
        public bool AKTIF { get; set; }
        public string MD5
        {
            get
            {
                return this.PAROLA.ToMd5();
            }
        }
    }
}
