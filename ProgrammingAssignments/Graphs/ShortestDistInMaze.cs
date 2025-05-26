using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Graphs
{
    class ShortestDistInMaze
    {

        /*
Given a matrix of integers A of size N x M describing a maze. The maze consists of empty locations and walls.

1 represents a wall in a matrix and 0 represents an empty location in a wall.

There is a ball trapped in a maze. The ball can go through empty spaces by rolling up, down, left or right, but it won't stop rolling until hitting a wall (maze boundary is also considered as a wall). When the ball stops, it could choose the next direction.

Given two array of integers of size B and C of size 2 denoting the starting and destination position of the ball.

Find the shortest distance for the ball to stop at the destination. The distance is defined by the number of empty spaces traveled by the ball from the starting position (excluded) to the destination (included). If the ball cannot stop at the destination, return -1.
*/
        public int solve(List<List<int>> A, List<int> B, List<int> C)
        {
            int n = A.Count;
            int m = A[0].Count;
            int[,] visited = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    visited[i, j] = int.MaxValue;
                }
            }

            int[] dx = { 0, 0, 1, -1 };
            int[] dy = { 1, -1, 0, 0 };
            
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { B[0], B[1] });
            visited[B[0], B[1]] = 0;

            while (queue.Count > 0)
            {
                int[] curr = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int x = curr[0] + dx[i];
                    int y = curr[1] + dy[i];
                    int dist = visited[curr[0], curr[1]];
                    while (x >= 0 && x < n && y >= 0 && y < m && A[x][y] == 0)
                    {
                        x += dx[i];
                        y += dy[i];
                        dist++;
                    }
                    x -= dx[i];
                    y -= dy[i];
                    dist--;

                    //REVISIT
                    if (visited[x, y] > dist)
                    {
                        visited[x, y] = dist;
                        queue.Enqueue(new int[] { x, y });
                    }
                }
            }
            return visited[C[0], C[1]] == int.MaxValue ? -1 : visited[C[0], C[1]];
        }
    }
}
