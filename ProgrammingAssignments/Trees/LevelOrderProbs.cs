using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Trees
{
    class LevelOrderProbs
    {
        public List<int> LeftView(TreeNode A)
        {
            var queue = new LinkedList<TreeNode>();
            var levels = new List<List<int>>();
            queue.AddLast(A);
            var last = A;
            var currentLevel = new List<int>();
            while (queue.Count > 0)
            {
                TreeNode front = queue.First.Value;
                queue.RemoveFirst();

                if (front.left != null)
                {
                    queue.AddLast(front.left);
                }
                if (front.right != null)
                {
                    queue.AddLast(front.right);
                }
                currentLevel.Add(front.val);

                if (last == front)
                {
                    levels.Add(currentLevel);
                    currentLevel = new List<int>();
                    if (queue.Count > 0)
                    {
                        last = queue.Last.Value;
                    }
                }
            }
            var ans = new List<int>();
            foreach (var level in levels)
            {
                ans.Add(level[0]);
            }
            return ans;
        }
        public List<List<int>> zigzagLevelOrder(TreeNode A)
        {
            var queue = new LinkedList<TreeNode>();
            var levels = new List<List<int>>();
            queue.AddLast(A);
            var last = A;
            var currentLevel = new List<int>();

            while (queue.Count > 0)
            {
                TreeNode front = queue.First.Value;
                queue.RemoveFirst();

                if (front.left != null)
                {
                    queue.AddLast(front.left);
                }
                if (front.right != null)
                {
                    queue.AddLast(front.right);
                }
                currentLevel.Add(front.val);

                if (last == front)
                {
                    levels.Add(currentLevel);
                    currentLevel = new List<int>();
                    if (queue.Count > 0)
                    {
                        last = queue.Last.Value;
                    }
                }
            }
            //Reverse the list at aleternate levels.
            var i = 1;
            foreach (var level in levels)
            {
                if (i++ % 2 != 0) continue;
                InverseList(level);
            }

            return levels;
        }
        void InverseList(List<int> A)
        {
            int N = A.Count;
            for (int i = 0; i < N / 2; i++)
            {
                swap(A, i, N - i - 1);
            }
        }
        void swap(List<int> A, int i, int j)
        {
            if (i == j) return;
            var temp = A[j];
            A[j] = A[i];
            A[i] = temp;
        }
    }
}
