using System.ComponentModel;

namespace Kariyer.Defination
{
    public enum EgitimDurum
    {
        [Description("Yok")]
        Yok = 0,
        [Description("İlköğretim")]
        IlkOgretim = 1,
        [Description("Lise")]
        Lise = 2,
        [Description("Önlisans")]
        OnLisans = 3,
        [Description("Lisans")]
        Lisans = 4,
        [Description("Yüksek Lisans")]
        YuksekLisans = 5,
        [Description("Doktora")]
        Doktora = 6
    }
}
