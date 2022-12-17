using System;
using System.Globalization;
using System.Numerics;

namespace Core.Extensions
{
    public static class ObjectExtensions
    {
        // sbyte byte ushort short nint uint nuint int ulong long 
        // double float decimal
        // char string 
        // datetime

        public static sbyte ToSbyte(this object value)
        {
            var availability = sbyte.TryParse(value.ToString(), out sbyte result);

            if (!availability)
            {
                BigInteger.TryParse(value.ToString(), out BigInteger temp);

                if (temp < sbyte.MinValue)
                    result = sbyte.MinValue;
                else if (temp > sbyte.MaxValue)
                    result = sbyte.MaxValue;
                else
                    result = 0;
            }

            return result;
        }

        public static byte ToByte(this object value)
        {
            var availability = byte.TryParse(value.ToString(), out byte result);

            if (!availability)
            {
                BigInteger.TryParse(value.ToString(), out BigInteger temp);

                if (temp > byte.MaxValue)
                    result = byte.MaxValue;
                else
                    result = 0;
            }

            return result;
        }

        public static ushort ToUshort(this object value)
        {
            var availability = ushort.TryParse(value.ToString(), out ushort result);

            if (!availability)
            {
                BigInteger.TryParse(value.ToString(), out BigInteger temp);

                if (temp > ushort.MaxValue)
                    result = ushort.MaxValue;
                else
                    result = 0;
            }

            return result;
        }

        public static short ToShort(this object value)
        {
            var availability = short.TryParse(value.ToString(), out short result);

            if (!availability)
            {
                BigInteger.TryParse(value.ToString(), out BigInteger temp);

                if (temp < short.MinValue)
                    result = short.MinValue;
                else if (temp > short.MaxValue)
                    result = short.MaxValue;
                else
                    result = 0;
            }

            return result;
        }

        //public static nint ToNint(this object value) { }

        public static uint ToUint(this object value)
        {
            var availability = uint.TryParse(value.ToString(), out uint result);

            if (!availability)
            {
                BigInteger.TryParse(value.ToString(), out BigInteger temp);

                if (temp > uint.MaxValue)
                    result = uint.MaxValue;
                else
                    result = 0;
            }

            return result;
        }

        //public static nuint ToNuint(this object value) { }

        public static int ToInt(this object value)
        {
            if(value is null)
                return 0;

            var availability = int.TryParse(value.ToString(), out int result);

            if (!availability)
            {
                BigInteger.TryParse(value.ToString(), out BigInteger temp);

                if (temp < int.MinValue)
                    result = int.MinValue;
                else if (temp > int.MaxValue)
                    result = int.MaxValue;
                else
                    result = 0;
            }

            return result;
        }

        public static ulong ToUlong(this object value)
        {
            var availability = ulong.TryParse(value.ToString(), out ulong result);

            if (!availability)
            {
                BigInteger.TryParse(value.ToString(), out BigInteger temp);

                if (temp > ulong.MaxValue)
                    result = ulong.MaxValue;
                else
                    result = 0;
            }

            return result;
        }

        public static long ToLong(this object value)
        {
            var availability = long.TryParse(value.ToString(), out long result);

            if (!availability)
            {
                BigInteger.TryParse(value.ToString(), out BigInteger temp);

                if (temp < long.MinValue)
                    result = long.MinValue;
                else if (temp > long.MaxValue)
                    result = long.MaxValue;
                else
                    result = 0;
            }

            return result;
        }

        public static double ToDouble(this object value)
        {
            var availability = double.TryParse(value.ToString(), out double result);

            if (!availability)
                result = 0;

            return result;
        }

        public static double ToDouble(this object value, int accuracy)
        {
            var availability = double.TryParse(value.ToString(), out double result);

            if (!availability)
                result = 0;
            else
            {
                char separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
                var temp = result.ToString().Split(separator);

                result = Convert.ToDouble(temp[0] + separator + temp[1].Remove(accuracy));
            }

            return result;
        }

        public static double ToDoubleWithRound(this object value, int accuracy)
        {
            var availability = double.TryParse(value.ToString(), out double result);

            if (!availability)
                result = 0;
            else
            {
                result = Math.Round(result, accuracy);
            }

            return result;
        }

        public static float ToFloat(this object value)
        {
            var availability = float.TryParse(value.ToString(), out float result);

            if (!availability)
                result = 0;

            return result;
        }

        public static float ToFloat(this object value, int accuracy)
        {
            var availability = float.TryParse(value.ToString(), out float result);

            if (!availability)
                result = 0;
            else
            {
                char separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
                var temp = result.ToString().Split(separator);

                result = float.Parse(temp[0] + separator + temp[1].Remove(accuracy));
            }

            return result;
        }

        public static float ToFloatWithRound(this object value, int accuracy)
        {
            var availability = float.TryParse(value.ToString(), out float result);

            if (!availability)
                result = 0;
            else
            {
                result = (float)Math.Round(result, accuracy);
            }

            return result;
        }

        public static decimal ToDecimal(this object value)
        {
            var availability = decimal.TryParse(value.ToString(), out decimal result);

            if (!availability)
                result = 0;

            return result;
        }

        public static decimal ToDecimal(this object value, int accuracy)
        {
            var availability = decimal.TryParse(value.ToString(), out decimal result);

            if (!availability)
                result = 0;
            else
            {
                char separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
                var temp = result.ToString().Split(separator);

                result = decimal.Parse(temp[0] + separator + temp[1].Remove(accuracy));
            }

            return result;
        }

        public static decimal ToDecimalWithRound(this object value, int accuracy)
        {
            var availability = decimal.TryParse(value.ToString(), out decimal result);

            if (!availability)
                result = 0;
            else
            {
                result = Math.Round(result, accuracy);
            }

            return result;
        }

        public static bool ToBool(this object value)
        {
            bool result;
            if (value.GetType() == typeof(char))
            {
                switch (Convert.ToChar(value))
                {
                    case '0':
                        result = false;
                        break;
                    case '1':
                        result = true;
                        break;
                    default:
                        result = false;
                        break;
                }
            }
            else
            {
                var availability = bool.TryParse(value.ToString(), out result);

                if (!availability)
                    result = false;
            }

            return result;
        }

        public static DateTime ToDatetime(this object value)
        {
            var availability = DateTime.TryParse(value.ToString(), out DateTime result);

            if (!availability)
                result = DateTime.MinValue;

            return result;
        }
    }
}
