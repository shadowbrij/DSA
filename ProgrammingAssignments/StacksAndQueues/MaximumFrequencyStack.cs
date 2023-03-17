using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.StacksAndQueues
{
    class MaximumFrequencyStack
    {
        public List<int> solve(List<List<int>> A)
        {
            var mapFreq = new Dictionary<int, int>();
            var mapStack = new Dictionary<int, Stack<int>>();
            var ans = new List<int>();
            var maxFrequency = 1;
            foreach (var opr in A)
            {
                if (opr[0] == 2)
                {
                    //Pop
                    var top = mapStack[maxFrequency].Pop();
                    ans.Add(top);
                    if (mapStack[maxFrequency].Count == 0)
                    {
                        maxFrequency -= 1;
                    }
                    mapFreq[top] -= 1;
                }
                else
                {
                    //Push
                    ans.Add(-1);
                    var item = opr[1];
                    if (mapFreq.ContainsKey(item))
                    {
                        mapFreq.Add(item, 1);
                    }
                    else
                    {
                        mapFreq[item] = 1;
                    }
                    var frequency = mapFreq[item];
                    maxFrequency = Math.Max(frequency, maxFrequency);

                    if (mapStack.ContainsKey(frequency))
                    {
                        mapStack[frequency].Push(item);
                    }
                    else
                    {
                        var stack = new Stack<int>();
                        stack.Push(item);
                        mapStack.Add(frequency, stack);
                    }
                }
            }
            return ans;
        }
    }

}
