using Core;

namespace Kariyer.DTO
{
    public class DTO_GirisYap
    {
        public string E_POSTA { get; set; }
        public string PAROLA { get; set; }
        public bool BENI_HATIRLA { get; set; }
        public string MD5
        {
            get
            {
                return this.PAROLA.ToMd5();
            }
        }
    }
}
