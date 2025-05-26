using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    public class Graph
    {
        public Dictionary<int, Node> nodeLookup = new Dictionary<int, Node>();
        int NodeCount { get; set; }
        public Graph(int nodes)
        {
            this.NodeCount = nodes;
            for(int p = 0; p<nodes;p++)
            {
                nodeLookup.Add(p, new Node(p));
            }
        }
        public class Node
        {
            public int id { get; set; }
            public LinkedList<Node> adjacent = new LinkedList<Node>();
            public Node(int id)
            {
                this.id = id;
            }
        }

        private Node getNode(int id)
        {
            return nodeLookup[id];
        }
        public void addEdge(int source,int destination)
        {
            Node s = getNode(source);
            Node d = getNode(destination);
            s.adjacent.AddFirst(d);   
        }

        public bool hasPathDFS(int source,int destination)
        {
            Node s = getNode(source);
            Node d = getNode(destination);
            HashSet<int> visited = new HashSet<int>();
            return hasPathDFS(s,d,visited);
        }

        private bool hasPathDFS(Node s, Node d, HashSet<int> visited)
        {
            if (visited.Contains(s.id)) return false;
            visited.Add(s.id);
            if (s == d) return true;
            else
            {
                foreach (Node child in s.adjacent)
                    if (hasPathDFS(child, d, visited))
                        return true;
            }
            return false;
        }
        public bool hasPathBFS(int source,int destination)
        {
            return hasPathBFS(getNode(source), getNode(destination));
        }
        private bool hasPathBFS(Node source,Node Destination)
        {
            Queue<Node> nextToVisit = new Queue<Node>();
            HashSet<int> visited = new HashSet<int>();

            nextToVisit.Enqueue(source);

            while(nextToVisit.Count !=0)
            {
                Node node = nextToVisit.Dequeue();
                if (node == Destination) return true;

                if (visited.Contains(node.id))
                    continue;
                visited.Add(node.id);

                foreach (Node child in node.adjacent)
                    nextToVisit.Enqueue(child);
            }

            return false;
        }

        public int[] PrintMinimumNodeDistances(Node sourcenode,int edgeWeight)
        {
            //throw new NotImplementedException();
            int[] weight = Enumerable.Repeat(-1, this.NodeCount).ToArray();
            Queue<Node> nextToVisit = new Queue<Node>();
            HashSet<int> visited = new HashSet<int>();

            nextToVisit.Enqueue(sourcenode);

            while (nextToVisit.Count != 0)
            {
                Node node = nextToVisit.Dequeue();
                //if (node == Destination) return true;

                if (visited.Contains(node.id))
                    continue;
                visited.Add(node.id);

                foreach (Node child in node.adjacent)
                {
                    nextToVisit.Enqueue(child);
                    weight[child.id] = weight[node.id] + edgeWeight;
                }
            }
            return weight;
        }
    }
    public class SolutionBFS
    {
        static void hMain(String[] args)
        {
            int edgeweight = 6;
            string? queryInput = Console.ReadLine();
            if (queryInput == null)
                throw new InvalidOperationException("Input cannot be null.");
            
            int query = Convert.ToInt32(queryInput);

            for(int i=0;i<query;i++)
            {
                string? inputLine = Console.ReadLine();
                if (inputLine == null)
                    throw new InvalidOperationException("Input cannot be null.");
                int[] sizeofGraph = Array.ConvertAll(inputLine.Split(' '), Int32.Parse);
                int nodes = sizeofGraph[0], edges = sizeofGraph[1];
                Graph graph = new Graph(nodes);
                for (int j=0;j<edges;j++)
                {
                    string? edgeInput = Console.ReadLine();
                    if (edgeInput == null)
                        throw new InvalidOperationException("Edge input cannot be null.");
                    var edge = Array.ConvertAll(edgeInput.Split(' '), Int32.Parse);
                    graph.addEdge(edge[0], edge[1]);
                }
                int sourcenode = Convert.ToInt32(Console.ReadLine());
                int [] arr = graph.PrintMinimumNodeDistances(graph.nodeLookup[sourcenode], edgeweight);
                Console.WriteLine(string.Join(" ", arr));
            }
            Console.ReadLine();
        }

    }

}
