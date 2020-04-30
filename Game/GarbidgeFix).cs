using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    static class GarbidgeFix_
    {
        public static bool DoublesEquaal(double a, double b)
        {
            var eps = 0.00001;
            return Math.Abs(a - b) < eps;
        }
    }
}
