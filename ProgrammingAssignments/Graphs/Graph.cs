﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Graphs
{

    public class Graph
    {
        public Dictionary<int,Node> nodeLookup { get; set;}
        public Graph(int numberOfNodes)
        {
            this.nodeLookup = new Dictionary<int, Node>();
            for (int i = 1; i <= numberOfNodes; i++)
            {
                nodeLookup.Add(i, new Node(i));
            }
        }

        public Node getNode(int value)
        {
            return nodeLookup[value];
        }
        public class Node
        {
            public int id { get; set; }
            public LinkedList<Node> adjacents { get; set;}
            public Node(int id)
            {
                this.id = id;
                this.adjacents = new LinkedList<Node>();
            }

        }
        public void AddEdge(int source, int destination)
        {
            Node A = nodeLookup[source];
            Node B = nodeLookup[destination];

            A.adjacents.AddFirst(B);
        }

        public int hasBFSPath(int source, int destination, HashSet<int> visited)
        {
            visited.Add(source);
            var queue = new LinkedList<int>();
            queue.AddLast(source);

            while (queue.Count > 0)
            {
                var front = queue.First();
                queue.RemoveFirst();
                var adjacents = getNode(front).adjacents;
                foreach (var node in adjacents)
                {
                    if (node.id == destination)
                        return 1;
                    if (!visited.Contains(node.id))
                    {
                        queue.AddLast(node.id);
                        visited.Add(node.id);
                    }
                }
            }

            return 0;
        }

    public int dfsSum(int id, bool[] visited, int sum, List<int> B) {
        visited[id] = true;
        sum += B[id - 1];
        foreach (var node in this.getNode(id).adjacents) {
            if (!visited[node.id]) {
                sum += dfsSum(node.id, visited, 0, B);
            }
        }
        return sum;
    }

    }
}
