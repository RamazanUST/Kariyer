//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kariyer.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class KULLANICI
    {
        public KULLANICI()
        {
            this.CV = new HashSet<CV>();
        }
    
        public System.Guid ID { get; set; }
        public Nullable<System.Guid> FIRMA_ID { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public string AD_SOYAD { get; set; }
        public string E_POSTA { get; set; }
        public string PAROLA { get; set; }
        public bool TEKNIK_KULLANICI { get; set; }
        public bool FIRMAMI { get; set; }
        public bool AKTIF { get; set; }
        public bool SILINDI { get; set; }
    
        public virtual ICollection<CV> CV { get; set; }
        public virtual FIRMA FIRMA { get; set; }
    }
}
