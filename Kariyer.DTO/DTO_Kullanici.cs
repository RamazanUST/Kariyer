using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kariyer.DTO
{
    public class DTO_Kullanici
    {
        public Guid ID { get; set; }
        public Guid? CV_ID { get; set; }
        public Guid? FIRMA_ID { get; set; }
        public string AD_SOYAD { get; set; }
        public string E_POSTA { get; set; }
        public bool TEKNIK_KULLANICI { get; set; }
        public bool FIRMA { get; set; }
        public bool AKTIF { get; set; }
    }
}
