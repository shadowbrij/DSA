using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.ArraysProblems
{
    class SheldonAndPairOfCities
    {

        public List<int> solve(int A, int B, int C, List<int> D, List<int> E, List<int> F, List<int> G, List<int> H)
        {
            //seems all pairs shortest path so Floyd Warshall can be used here.
            var distMatrix = new int[A + 1, A + 1];
            for (int i = 0; i <= A; i++)
            {
                for (int j = 0; j <= A; j++)
                {
                    if (i == j) distMatrix[i, j] = 0;
                    else distMatrix[i, j] = -1;
                }
            }

            for (int j = 0; j < B; j++)
            {
                var x = D[j];
                var y = E[j];
                if (x == y) continue;

                if (distMatrix[x, y] == -1)
                {
                    distMatrix[x, y] = F[j];
                    distMatrix[y, x] = F[j];
                }
                else
                { // then there are multi edges 
                    distMatrix[x, y] = Math.Min(distMatrix[x, y], F[j]);
                    distMatrix[y, x] = Math.Min(distMatrix[x, y], F[j]);
                }
            }

            //run Floyd Warshall 
            FloydWarshall(distMatrix, A);

            //queries
            var ans = new List<int>();
            for (int i = 0; i < C; i++)
            {
                var source = G[i];
                var dest = H[i];
                ans.Add(distMatrix[source, dest]);
            }

            return ans;
        }

        void FloydWarshall(int[,] distMatrix, int A)
        {

            for (int k = 1; k <= A; k++)
            { // this will be the temp node.
              //i is source
                for (int i = 1; i <= A; i++)
                {
                    //j is destination
                    for (int j = 1; j <= A; j++)
                    {
                        //temp eithet source or destination.
                        if (i == j || i == k || j == k) continue;
                        //source to temp or temp to destination has no path 
                        if (distMatrix[i, k] == -1 || distMatrix[k, j] == -1) continue;

                        if (distMatrix[i, j] == -1 || distMatrix[i, j] > distMatrix[i, k] + distMatrix[k, j])
                        {
                            distMatrix[i, j] = distMatrix[i, k] + distMatrix[k, j];
                        }
                    }
                }
            }

        }
    }

}
