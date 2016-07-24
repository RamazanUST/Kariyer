using System.ComponentModel;

namespace Kariyer.Defination
{
    public enum IsAramaDurum
    {
        [Description("Yeni mezunum. İş arıyorum.")]
        YeniMezun = 1,
        [Description("Bir yerde çalışmıyorum. İş arıyorum.")]
        Calismiyor = 2,
        [Description("Yeni iş bulursam, işten ayrılacağım.")]
        Calisiyor = 3,
        [Description("Staj yeri arıyorum.")]
        Staj = 4
    }
}
