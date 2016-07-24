using System.ComponentModel;

namespace Kariyer.Defination
{
    public enum Seyahat
    {
        [Description("Hiçbir zaman seyahat edemem.")]
        Edemem = 0,
        [Description("Her zaman seyahat edebilirim.")]
        Edebilirim = 1,
        [Description("Zaman zaman seyehat edebilirim.")]
        Arasira = 2
    }
}
