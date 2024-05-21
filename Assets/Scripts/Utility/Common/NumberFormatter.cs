using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class NumberFormatter
    {
        public static string LeadingPlus(int num)
        {
            return num > 0 ? "+" + num : num.ToString();
        }

        public static string LeadingPlus(float num)
        {
            return num > 0 ? "+" + num : num.ToString();
        }

        public static string ToKMB(float num)
        {
            if (num > 999999999 || num < -999999999)
                return num.ToString("0,,,.###B", CultureInfo.InvariantCulture);
            else if (num > 999999 || num < -999999)
                return num.ToString("0,,.##M", CultureInfo.InvariantCulture);
            else if (num > 999 || num < -999)
                return num.ToString("0,.#K", CultureInfo.InvariantCulture);
            else
                return num.ToString(CultureInfo.InvariantCulture);
        }

        public static string LeadingPlusToKMB(float num)
        {
            string plus = num > 0 ? "+" : string.Empty;
            string kmbNum = ToKMB(num);
            return plus + kmbNum;
        }
    }
}
