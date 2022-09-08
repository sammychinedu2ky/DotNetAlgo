using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAlgo.Recursion
{
    internal class Factorial
    {
        public static int Solve(int number)
        {
            if (number == 2) return number;
            return number * Solve(number - 1);
        }
    }
}
