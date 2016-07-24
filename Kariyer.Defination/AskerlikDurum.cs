using System.ComponentModel;

namespace Kariyer.Defination
{
    public enum AskerlikDurum
    {
        [Description("Yapıldı")]
        Yapildi = 0,
        [Description("Tecilli")]
        Tecilli = 1,
        [Description("Muaf")]
        Muaf = 2
    }
}
