using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Graphs
{
    class RottenOranges
    {
        public int solve(List<List<int>> A)
        {
            int N = A.Count;
            int M = A[0].Count;
            var rmatrix = new int[N, M];
            var deque = new LinkedList<(int,int)>();
            var ans = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (A[i][j] == 2)
                    {
                        deque.AddLast((i, j));
                    }
                }
            }
            while (deque.Count > 0)
            {
                var front = deque.First.Value;
                deque.RemoveFirst();
                //  visited[front.Item1,front.Item2] = true;

                var dx = new List<int>() { -1, 0, 1, 0 };
                var dy = new List<int>() { 0, 1, 0, -1 };
                for (int k = 0; k < 4; k++)
                {
                    var x = dx[k] + front.Item1; //x cord of adj
                    var y = dy[k] + front.Item2; // y cord of adj
                    if (x >= 0 && x < N && y >= 0 && y < M && A[x][y] != 0)
                    {
                        if (A[x][y] == 1)
                        {
                            A[x][y] = 2;
                            deque.AddLast((x, y));
                            rmatrix[x, y] = rmatrix[front.Item1,front.Item2] + 1;
                        }
                        else
                            rmatrix[x, y] = Math.Min(rmatrix[x, y], rmatrix[front.Item1,front.Item2] + 1);
                        ans = Math.Max(ans, rmatrix[x,y]);
                    }
                }
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (A[i][j] == 1) return -1;
                }
            }

            return ans;
        }
    }

}
