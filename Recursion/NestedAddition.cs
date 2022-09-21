using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAlgo.Recursion
{
    internal class NestedAddition
    {

        public int Solve(object[] nestedarray)
        {
            var Total = 0;
            for (var i = 0; i < nestedarray.Length; i++)
            {
                if (nestedarray[i].GetType() == typeof(int))
                {
                    Total += (int)nestedarray[i];
                }
                else if (nestedarray[i].GetType() == typeof(object[]))
                {
                    Total += Solve((object[])nestedarray[i]);
                }
            }
            return Total;
        }


        public int Solve2(object[] nestedarray)
        {
            var Total = 0;
            for (var i = 0; i < nestedarray.Length; i++)
            {
                if (nestedarray[i].GetType() == typeof(int))
                {
                    Total += (int)nestedarray[i];
                }
                else 
                {
                    Total += Solve2((object[])nestedarray[i]);
                }
            }
            return Total;
        }
    }
}
