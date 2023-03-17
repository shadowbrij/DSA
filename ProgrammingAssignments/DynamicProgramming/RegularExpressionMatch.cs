using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.DynamicProgramming
{
    class RegularExpressionMatch
    {
        public int isMatch(string A, string B)
        {
            int R = B.Length;
            int S = A.Length;
            var Match = new int[R + 1, S + 1];

            //Match[i,j] -> check if first i chars of A matches the first j chars of B.        
            //Concept : We'll do match  L<--R (right to left)

            /* Below 2 cases we don't inside for loop but conceptually they are needed and are automatically done via array.
                    //you reached at the begining
                  1.  if(i == 0 && j== 0){
                         Match[0,0] = 1;
                    }
                  2.  else if(i==0){ //no regex to match for
                        Match[i,j] = 0;
                    }
                   3. if( j == 0){ //no string to match with
                        if(B[i-1] == '*')
                            Match[i,j] = Match[i-1,j];
                        else
                            Match[i,j] = 0;
                    } 
            */

            Match[0, 0] = 1; //case 1

            //Case 3.

            for (int i = 1; i <= R; i++)
            {
                if (B[i - 1] == '*')
                    Match[i, 0] = Match[i - 1, 0];
                else Match[i, 0] = 0;
            }

            for (int i = 1; i <= R; i++)
            {//regex
                for (int j = 1; j <= S; j++)
                {//string
                    if ((B[i - 1] == '?') || (A[j - 1] == B[i - 1]))
                    {
                        Match[i, j] = Match[i - 1, j - 1];
                    }
                    else if (B[i - 1] == '*')
                    {
                        Match[i, j] = (Match[i, j - 1] + Match[i - 1, j]) > 0 ? 1 : 0;
                    }
                    else Match[i, j] = 0;
                }
            }

            return Match[R, S];

        }

    }
}
