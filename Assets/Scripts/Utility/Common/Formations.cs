using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Formations
    {
        public static string LeadingPlus(int num)
        {
            return num > 0 ? "+" + num : num.ToString();
        }

        public static string LeadingPlus(float num)
        {
            return num > 0 ? "+" + num : num.ToString();
        }
    }
}
