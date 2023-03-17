using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.BitManipulations
{
    public class PlayWithNumbers
    {
        public static long ReverseNumber(long A)
        {
            var setbits = new List<int>();
            long B = A;
            int index = 0;
            while (B > 0)
            {
                if ((B & 1) == 1)
                    setbits.Add(index);
                index++;
                B = B >> 1;
            }
            B = 0;
            foreach (int a in setbits)
            {
                B = B | (1L << (32 - a - 1));
            }
            return B;
        }
    }
}
