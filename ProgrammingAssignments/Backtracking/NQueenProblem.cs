using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Backtracking
{
    class NQueenProblem
    {
        List<List<string>> ans;
        int N ;
        //We can place only one queen in a row, So we just need to track the column position at which the queen is placed.
        // we don't need the entire AxA matrix;
        int[] column;
        public List<List<string>> solveNQueens(int A)
        {
            N = A;
            ans = new List<List<string>>();
            if (A == 1)
            {
                ans.Add(new List<string>() { "Q" });
                return ans;
            }

            column = new int[N];
            PlaceNQueen(0, column);

            return ans;
        }

        void PlaceNQueen(int row, int[] column)
        {
            //base case; when we are done placing each queens.
            if(row == N)
            {
                ans.Add(DeserializeCurrentAnswer());
                return;

            }

            //there is a Queen placed at `row` . check for possibilities of remaining queens.
            for(int col = 0; col < N; col++)
            {
                if (isValid(row,col,column))
                {
                    column[row] = col;
                    //if(PlaceNQueen(row+1,column)) return true;
                    PlaceNQueen(row + 1, column);
                    column[row] = -1;
                }
            }
            //return false;

        }

        private bool isValid(int rowCurrentQueen, int colCurrentQueen, int[] column)
        {
            for(int i= 0; i < rowCurrentQueen; i++)
            {
                if(!check(rowCurrentQueen,colCurrentQueen,i,column[i]))
                       return false;
            }
            return true;
        }

        bool check(int r1,int c1,int r2, int c2)
        {
            if(r1 == r2 
                || c1 == c2 
                || ((r1-c1) == (r2 -c2)) 
                || ((r1+c1) == (r2+c2))
                )
                return false;

            return true;
        }
        private List<string> DeserializeCurrentAnswer()
        {
            var ans = new List<string>();
            StringBuilder sb;
            for (int i = 0; i < N; i++)
            {
                sb = new StringBuilder();
                for (int j = 0; j < N; j++)
                {
                    if(column[i] == j)
                    {
                        sb.Append('Q');
                    }
                    else
                    {
                        sb.Append('.');
                    }
                }
                ans.Add(sb.ToString());
            }
            return ans;
        }
    }

}
