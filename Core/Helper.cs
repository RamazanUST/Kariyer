using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Core
{
    public static class Helper
    {

        public static string GuidPrv(this Guid guid)
        {
            if (guid == null)
            {
                return "gdnull";
            }

            return Regex.Replace(guid.ToString(), "-", String.Empty).ToUpper();
        }

        public static Guid? GuidPbl(this string textGuid)
        {
            if (String.IsNullOrEmpty(textGuid))
            {
                return null;
            }

            string yeni1 = textGuid.ToLower().Substring(0, 8) + "-";
            string yeni2 = textGuid.ToLower().Substring(8, 4) + "-";
            string yeni3 = textGuid.ToLower().Substring(12, 4) + "-";
            string yeni4 = textGuid.ToLower().Substring(16, 4) + "-";
            string yeni5 = textGuid.ToLower().Substring(20, 12);
            string yeni = yeni1 + yeni2 + yeni3 + yeni4 + yeni5;

            return yeni.ToGuidValue();
        }

        public static string ClearCharacters(this string Text)
        {
            string strReturn = Text.Trim();

            strReturn = strReturn.Replace("ğ", "g");
            strReturn = strReturn.Replace("Ğ", "G");
            strReturn = strReturn.Replace("ü", "u");
            strReturn = strReturn.Replace("Ü", "U");
            strReturn = strReturn.Replace("ş", "s");
            strReturn = strReturn.Replace("Ş", "S");
            strReturn = strReturn.Replace("ı", "i");
            strReturn = strReturn.Replace("İ", "I");
            strReturn = strReturn.Replace("ö", "o");
            strReturn = strReturn.Replace("Ö", "O");
            strReturn = strReturn.Replace("ç", "c");
            strReturn = strReturn.Replace("Ç", "C");
            strReturn = strReturn.Replace("-", "+");
            strReturn = strReturn.Replace(" ", "-");
            strReturn = strReturn.Replace("#", "");
            strReturn = strReturn.Replace(":", "");
            strReturn = strReturn.Replace("--","-");
            strReturn = strReturn.Trim();
            // strReturn = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9+]").Replace(strReturn, "");
            strReturn = strReturn.Trim();
            strReturn = strReturn.Replace("+", "-");

            return strReturn;
        }

        public static string ToCamel(this string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }

        public static string GetEnumDescription<T>(T value) where T : struct
        {
            try
            {
                DescriptionAttribute[] customAttributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                return ((customAttributes.Length > 0) ? customAttributes[0].Description : value.ToString());
            }
            catch (NullReferenceException)
            {
            }
            catch
            {
            }
            return value.ToStringValue();
        }

        public static IDictionary<int, string> GetEnumDescriptionList<T>() where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentNullException("Değer enum olmalıdır.");
            }

            Dictionary<int, string> list = new Dictionary<int, string>();
            var enumValues = Enum.GetValues(typeof(T));

            foreach (var value in enumValues)
            {
                list.Add(Convert.ToInt32(value), GetEnumDescription((T)value));
            }

            return list;
        }

        public static IDictionary<int, string> GetEnumList<T>() 
        {
            if (!typeof(T).IsEnum) 
            {
                throw new ArgumentNullException("Değer enum olmalıdır");
            }

            Dictionary<int, string> List = new Dictionary<int,string>();
            string[] enumValues = Enum.GetNames(typeof(T));

            return enumValues.Select((value, key) => new { value, key }).ToDictionary(x => x.key, x => x.value);
        }

        public static String ReplaceText(this string text)
        {
            StringBuilder sb = new StringBuilder(HttpUtility.HtmlEncode(text));
            sb.Replace("&lt;b&gt;", "<b>");
            sb.Replace("&lt;/b&gt;", "</b>");
            sb.Replace("&lt;i&gt;", "<i>");
            sb.Replace("&lt;/i&gt;", "</i>");
            sb.Replace("\r\n", "<br>");

            return sb.ToString();
        }

        public static bool ContainsCI(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }
    }
}
