using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core
{
    public static class Checker
    {
        public static bool IsEmail(object eMail)
        {
            if (eMail == null)
            {
                return false;
            }
            string pattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            return new Regex(pattern).IsMatch(eMail.ToString());
        }

        public static bool IsTc(long tcIdentityNo)
        {
            if (tcIdentityNo.ToString().Length == 11)
            {
                long num = tcIdentityNo;
                long num2 = num / 100L;
                long num3 = num / 100L;
                long num4 = num2 % 10L;
                num2 /= 10L;
                long num5 = num2 % 10L;
                num2 /= 10L;
                long num6 = num2 % 10L;
                num2 /= 10L;
                long num7 = num2 % 10L;
                num2 /= 10L;
                long num8 = num2 % 10L;
                num2 /= 10L;
                long num9 = num2 % 10L;
                num2 /= 10L;
                long num10 = num2 % 10L;
                num2 /= 10L;
                long num11 = num2 % 10L;
                num2 /= 10L;
                long num12 = num2 % 10L;
                num2 /= 10L;
                long num13 = (10L - (((((((num4 + num6) + num8) + num10) + num12) * 3L) + (((num5 + num7) + num9) + num11)) % 10L)) % 10L;
                long num14 = (10L - (((((((num5 + num7) + num9) + num11) + num13) * 3L) + ((((num4 + num6) + num8) + num10) + num12)) % 10L)) % 10L;
                return ((((num3 * 100L) + (num13 * 10L)) + num14) == num);
            }
            return false;
        }

        public static bool IsUrl(object url)
        {
            if (url == null)
            {
                return false;
            }
            return new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?").IsMatch(url.ToString());
        }
    }
}
