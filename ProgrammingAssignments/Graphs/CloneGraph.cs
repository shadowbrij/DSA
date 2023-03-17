using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Graphs
{
     class UndirectedGraphNode
      {
         public int label;
         public List<UndirectedGraphNode> neighbors;
         public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
     };
    class CloneGraph
    {
        public UndirectedGraphNode cloneGraph(UndirectedGraphNode node)
        {
            var visited = new HashSet<int>();
            var deque = new LinkedList<UndirectedGraphNode>();
            var nodeMap = new Dictionary<int,UndirectedGraphNode>();

            deque.AddLast(node);
            nodeMap.Add(node.label, new UndirectedGraphNode(node.label));

            while(deque.Count > 0)
            {
                var front = deque.First.Value;
                deque.RemoveFirst();

                if(visited.Contains(front.label))
                    continue;

                visited.Add(front.label);

                foreach(var neighourNode in front.neighbors)
                {
                    if (!visited.Contains(neighourNode.label))
                    {
                        var current = new UndirectedGraphNode(neighourNode.label);
                        if(!nodeMap.ContainsKey(neighourNode.label))
                              nodeMap.Add(neighourNode.label,current);

                        deque.AddLast(neighourNode);
                        nodeMap[front.label].neighbors.Add(neighourNode);
                    }
                }

            }
            return nodeMap[node.label];
        }
    }
}
