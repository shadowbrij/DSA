
/*
Problem Description

A students applied for admission in IB Academy. An array of integers B is given representing the strengths of A people i.e. B[i] represents the strength of ith student.

Among the A students some of them knew each other. A matrix C of size M x 2 is given which represents relations where ith relations depicts that C[i][0] and C[i][1] knew each other.

All students who know each other are placed in one batch.

Strength of a batch is equal to sum of the strength of all the students in it.

Now the number of batches are formed are very much, it is impossible for IB to handle them. So IB set criteria for selection: All those batches having strength at least D are selected.

Find the number of batches selected.

NOTE: If student x and student y know each other, student y and z know each other then student x and student z will also know each other.
*/

using System.Collections.Generic;
using ProgrammingAssignments.Graphs;

class Batches {
    public int solve(int A, List<int> B, List<List<int>> C, int D) {
        //should be easy 
        // multiple connected components seems to be present , need to take sum of all connected components
        var E = C.Count;
        var graph = new Graph(A);

        for(int i=0;i<E;i++)
        {
            graph.AddEdge(C[i][0],C[i][1]);
        }
        var visited = new bool[A+1];
        var ans = 0;
        for(int i= 1;i<=A;i++){
            if(!visited[i]){
                var sum = graph.dfsSum(i,visited,0,B);
                if(sum >=D) ans+= 1;
            }
        }
        return ans;
    }
}