using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Backtracking
{
    class SudoKu
    {
        int N = 9;
        int n = 3;//Math.Sqrt(9) for a clock
        char[,] charA = new char[9, 9];
        //List<List<char>> charA = new List<List<char>>();
        public List<string> solve(List<string> A)
        {
            int L = A.Count;
            for (int i = 0; i < L; i++)
            {
                var charArr = A[i].ToCharArray();
                for (int j = 0; j < L; j++)
                {
                    charA[i, j] = charArr[j];
                }
            }

            FillSudoKu(0, 0);

            var ans = new List<string>();
            for (int i = 0; i < L; i++)
            {
                var sb = new StringBuilder();
                for (int j = 0; j < L; j++)
                {
                    sb.Append(charA[i, j]);
                }
                ans.Add(sb.ToString());
            }
            return ans;
        }

        bool FillSudoKu(int i, int j)
        {
            //will check numbers 1toN if they can be put on a cell.
            if (j == N){ // at last column then go to a new row.
                i += 1;
                j = 0;
            }
            if (i == N) return true; // if at last row then we are done.

            if (charA[i, j] != '.')
                return FillSudoKu(i, j + 1);

            for (int k = 1; k <= 9; k++)
            {
                char ch = (char)('0' + k);
                if (isValid(i, j, ch))
                {
                    charA[i, j] = ch;
                    if (FillSudoKu(i, j + 1))
                        return true;
                    charA[i, j] = '.';
                }
            }
            return false;
        }

        //check if we can place an integer k at A[row][col]
        bool isValid(int row, int col, char k)
        {
            //check for all rows and columns
            for (int i = 0; i < N; i++)
            {
                if (charA[i, col] == k || charA[row, i] == k)
                    return false;
            }

            //check for a block of 3x3
            //first index of current block
            int r = row - (row % 3);
            int c = col - (col % 3);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    if (charA[i + r, j + c] == k)
                        return false;
            }

            return true;
        }
    }
}
