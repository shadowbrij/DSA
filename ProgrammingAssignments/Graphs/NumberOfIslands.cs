using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Graphs
{
    class NumberOfIslands
    {
        public int solve(List<List<int>> A)
        {
            int N = A.Count;
            int M = A[0].Count;
            var visited = new bool[N,M]; //default false
            var ans = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if(A[i][j] == 1 && !visited[i, j])
                    {
                        visited[i,j] = true;
                        ans++;
                        dfs(A,i,j,visited);
                    }
                }
            }

            return ans;
        }

        void dfs(List<List<int>> A,int i,int j,bool[,] visited)
        {
            visited[i, j] = true;
            //3 things to check
            //Neighbour isn't outside the boundry
            //Neighbour isn't visited
            //Neighbour isn't 0?

            var dx = new int[8] {-1,-1,-1,0,0,1,1,1};
            var dy = new int[8] {-1,0,1,-1,1,-1,0,1};
            for(int n = 0; n < 8; n++)
            {
                var x = dx[n] + i;
                var y = dy[n] + j;
                var N = A.Count;
                var M = A[0].Count;

                if ((x >= 0 && x < N) && (y >= 0 && y < M)//case 1
                   && !visited[x, y] //case 2
                   && A[x][y] == 1 //case 3
                    )
                {
                    dfs(A,x,y,visited);
                }
            }

        }

    }
}
