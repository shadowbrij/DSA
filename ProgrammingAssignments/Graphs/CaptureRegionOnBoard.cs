using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Graphs
{
    class CaptureRegionOnBoard
    {
        /*
         Given a 2-D board A of size N x M containing 'X' and 'O', capture all regions surrounded by 'X'.

            A region is captured by flipping all 'O's into 'X's in that surrounded region.
         */
        public List<string> solve(List<string> A)
        {
            int n = A.Count;
            int m = A[0].Length;
            bool[,] visited = new bool[n, m];
            for (int i = 0; i < n; i++)
            {
                if (A[i][0] == 'O')
                {
                    dfs(A, i, 0, visited);
                }
                if (A[i][m - 1] == 'O')
                {
                    dfs(A, i, m - 1, visited);
                }
            }
            for (int i = 0; i < m; i++)
            {
                if (A[0][i] == 'O')
                {
                    dfs(A, 0, i, visited);
                }
                if (A[n - 1][i] == 'O')
                {
                    dfs(A, n - 1, i, visited);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (A[i][j] == 'O' && !visited[i, j])
                    {
                        A[i] = A[i].Remove(j, 1).Insert(j, "X");
                    }
                }
            }
            return A;
        }

        private void dfs(List<string> a, int i, int v, bool[,] visited)
        {
            if (i < 0 || i >= a.Count || v < 0 || v >= a[0].Length || visited[i, v] || a[i][v] == 'X')
            {
                return;
            }
            visited[i, v] = true;
            dfs(a, i + 1, v, visited);
            dfs(a, i - 1, v, visited);
            dfs(a, i, v + 1, visited);
            dfs(a, i, v - 1, visited);
        }
    }
}
