using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Graphs
{
    class BlackShape
    {
        public int black(List<string> A)
        {
            int N = A.Count;
            int M = A[0].Length;
            var visited = new bool[N, M];
            var ans = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (A[i][j] == 'X' && !visited[i, j])
                    {
                        ans++;
                        //mark adjacents as visited;
                        dfs(A, i, j, visited);
                    }
                    else
                        visited[i, j] = true;
                }
            }

            return ans;
        }
        void dfs(List<string> A, int i, int j, bool[,] visited)
        {
            int N = A.Count;
            int M = A[0].Length;

            if (visited[i, j]) return;

            visited[i, j] = true;

            var dx = new List<int>() { -1, 0, 1, 0 };
            var dy = new List<int>() { 0, 1, 0, -1 };
            for (int k = 0; k < 4; k++)
            {
                int x = i + dx[k];
                int y = j + dy[k];
                if (x >= 0 && x < N && y >= 0 && y < M && !visited[x, y])
                {
                    if (A[x][y] == 'X')
                    {
                        dfs(A, x, y, visited);
                    }
                }
            }

        }
    }

}
