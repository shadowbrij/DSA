using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Graphs
{
    class CycleInDirectedGraph
    {
        /*
          A = 5 //no of nodes
 B = [  [1, 2]  //there is an edge from 1->2
        [4, 1] 
        [2, 4] 
        [3, 4] 
        [5, 2] 
        [1, 3] ]
         */
        public int solve(int A, List<List<int>> B)
        {
            //Intialize graph
            Graph graph = new Graph(A);
            foreach(var list in B)
            {
                graph.AddEdge(list[0],list[1]);
            }


            var visited = new bool[A];

            //traversal start
            for (int i = 0; i < A; i++)
            {
                if (!visited[i])
                {
                   visited[i] = true;
                   foreach(var adjacent in graph.getNode(i + 1).adjacents)
                    {
                        var path = new bool[A]; //path array to keep track of path
                        if (!visited[adjacent.id - 1] && dfs(graph, adjacent.id, visited,path) == 1/*means there is a cycle*/)
                        {
                            return 1; //then there is a cycle
                        }
                    }
                }
            }
            return 0;
        }

        private int dfs(Graph graph, int id, bool[] visited, bool[] path)
        {
            //main login is here to detect cycle.

            visited[id-1] = true;
            path[id-1] = true;

            foreach (var adjacent in graph.getNode(id).adjacents)
            {
                if(path[adjacent.id - 1]) return 1; // there is a cycle

                if (!visited[adjacent.id-1] && dfs(graph, adjacent.id, visited, path) == 1)
                {
                    return 1;
                }
            }
            path[id-1] = false;
            return 0;
        }
    }
}
