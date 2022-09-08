using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAlgo.Recursion
{
    internal class Fibonacci
    {
        public static int Solve(int number)
        {
            if (number == 1) return 0;
            if (number == 2) return 1;
            return Solve(number - 1) + Solve(number - 2);

        }

        public static int Solve2(int number)
        {
            return number switch
            {
                1 => 0,
                2 => 1,
                _ => Solve2(number - 1) + Solve2(number - 2),

            };
        }
    }
}
