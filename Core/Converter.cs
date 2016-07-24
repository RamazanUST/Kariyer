using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Core
{
    [DebuggerStepThrough]
    public static class Converter
    {
        public static bool? ToBooleanValue(this object value)
        {
            if (value == null)
            {
                return null;
            }

            try
            {
                return new bool?(Convert.ToBoolean(value));
            }
            catch (FormatException)
            {
                return null;
            }
            catch (InvalidCastException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool ToBooleanValue(this object value, bool defaultValue)
        {
            bool? x = ToBooleanValue(value);

            if (!x.HasValue)
            {
                return defaultValue;
            }
            return x.GetValueOrDefault();
        }

        public static Char? ToCharValue(this object value)
        {
            if (value == null)
            {
                return null;
            }
            try
            {
                return new char?(Convert.ToChar(value));
            }
            catch (FormatException)
            {
                return null;
            }
            catch (InvalidCastException)
            {
                return null;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (OverflowException)
            {
                return null;
            }
        }

        public static Char ToCharValue(this object value, char defaulValue)
        {
            char? x = ToCharValue(value);

            if (x.HasValue)
            {
                return defaulValue;
            }
            return x.GetValueOrDefault();
        }

        public static DateTime? ToDateTimeValue(this object value)
        {
            if (value == null)
            {
                return null;
            }
            try
            {
                return new DateTime?(Convert.ToDateTime(value));
            }
            catch (FormatException)
            {
                return null;
            }
            catch (InvalidCastException)
            {
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static DateTime ToDateTimeValue(this object value, DateTime defaultValue)
        {
            DateTime? x = ToDateTimeValue(value);
            if (!x.HasValue)
            {
                return defaultValue;
            }
            return x.GetValueOrDefault();
        }

        public static decimal? ToDecimalValue(this object value)
        {
            if (value == null)
            {
                return null;
            }
            try
            {
                return new decimal?(Convert.ToDecimal(value));
            }
            catch (FormatException)
            {
                return null;
            }
            catch (InvalidCastException)
            {
                return null;
            }
            catch (OverflowException)
            {
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static decimal ToDecimalValue(this object value, decimal defaultValue)
        {
            decimal? x = ToDecimalValue(value);
            if (!x.HasValue)
            {
                return defaultValue;
            }
            return x.GetValueOrDefault();
        }

        public static double? ToDoubleValue(this object value)
        {
            if (value == null)
            {
                return null;
            }
            try
            {
                return new double?(Convert.ToDouble(value));
            }
            catch (FormatException)
            {
                return null;
            }
            catch (InvalidCastException)
            {
                return null;
            }
            catch (OverflowException)
            {
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static double ToDoubleValue(this object value, double defaultValue)
        {
            double? x = ToDoubleValue(value);
            if (!x.HasValue)
            {
                return defaultValue;
            }
            return x.GetValueOrDefault();
        }

        public static Guid? ToGuidValue(this object value)
        {
            if (value == null)
            {
                return null;
            }
            try
            {
                return new Guid(value.ToString());
            }
            catch (FormatException)
            {
                return null;
            }
            catch (OverflowException)
            {
                return null;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static Guid ToGuidValue(this object value, Guid defaultValue)
        {
            Guid? x = ToGuidValue(value);
            if (!x.HasValue)
            {
                return defaultValue;
            }
            return x.GetValueOrDefault();
        }

        public static int? ToIntegerValue(this object value)
        {
            if (value == null)
            {
                return null;
            }
            if (value is string)
            {
                string str = value as string;
                int length = str.IndexOfAny(new char[] { ',', '.' });
                if ((length > 0) && (length < (str.Length - 1)))
                {
                    foreach (char ch in str.Substring(length + 1))
                    {
                        if (!ch.Equals('0'))
                        {
                            return null;
                        }
                    }
                    value = str.Substring(0, length);
                }
            }
            try
            {
                return new int?(Convert.ToInt32(value));
            }
            catch (FormatException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (InvalidCastException)
            {
                return null;
            }
            catch (OverflowException)
            {
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static int ToIntegerValue(this object value, int defaultValue)
        {
            int? x = ToIntegerValue(value);
            if (!x.HasValue)
            {
                return defaultValue;
            }
            return x.GetValueOrDefault();
        }

        public static string ToStringValue(this object value)
        {
            return ToStringValue(value, true, true);
        }

        public static string ToStringValue(this object value, bool convertEmptyStringToNull, bool trim)
        {
            if (value == null)
            {
                return null;
            }
            string str = Convert.ToString(value);
            if (trim)
            {
                str = str.Trim();
            }
            if (convertEmptyStringToNull && (str.Length == 0))
            {
                return null;
            }
            return str;
        }

        public static string ToMd5(this object value)
        {
            string x = value.ToStringValue();

            if (String.IsNullOrEmpty(x))
            {
                return null;
            }

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] byt = Encoding.UTF8.GetBytes(x);

            byt = md5.ComputeHash(byt);

            StringBuilder sb = new StringBuilder();

            foreach (byte b in byt)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            return sb.ToStringValue();

        }
    }
}
