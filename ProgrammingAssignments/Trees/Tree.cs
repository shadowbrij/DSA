using ProgrammingAssignments.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments
{
    class Tree
    {
        public List<int> RightView(TreeNode A)
        {
            var queue = new LinkedList<TreeNode>();
            var ans = new List<int>();
            queue.AddLast(A);
            var last = A;
            while (queue.Count > 0)
            {
                TreeNode front = queue.First();
                queue.RemoveFirst();
                if (front.left != null)
                {
                    queue.AddLast(front.left);
                }
                if (front.right != null)
                {
                    queue.AddLast(front.right);
                }
                if (last == front)
                {
                    ans.Add(front.val);
                    if (queue.Count > 0)
                    {
                        TreeNode rear = queue.Last();
                        last = rear;
                    }
                }
            }
            return ans;
        }
        public void connect(TreeLinkNode root)
        {
            var P = root;//downwards/vertical
            while (P != null)
            {
                var Q = P; //rightwards/horizontal
                while (Q != null)
                {
                    if (Q.left != null)
                    {
                        if(Q.right != null)
                        {
                            Q.left.next = Q.right;
                        }
                        else
                            Q.left.next = GetNextRight(Q);
                    }
                    else if (Q.right != null)
                    {
                        Q.right.next = GetNextRight(Q);
                    }
                    Q = Q.next;
                }
                if (P.left != null)
                {
                    P = P.left;
                }
                else if (P.right != null)
                {
                    P = P.right;
                }
                else
                    P = GetNextRight(P);
            }
        }
        TreeLinkNode GetNextRight(TreeLinkNode node)
        {
            node = node.next;
            while (node != null)
            {
                if (node.left != null)
                {
                    return node.left;
                }
                else if (node.right != null)
                {
                    return node.right;
                }
                node = node.next;
            }
            return node;
        }
        public void connectUsingQueue(TreeLinkNode root) //TLE
        {
            var queue = new LinkedList<TreeLinkNode>();
            queue.AddLast(root);
            while (queue.Count > 0)
            {
                //dequqe
                var node = queue.First();
                queue.RemoveFirst();

                if (node.next != null)
                {
                    queue.AddLast(node.left);
                }

                if (node.right != null)
                {
                    queue.AddLast(node.right);
                }
                //check if node isn't the last node 
                if (node.right != queue.Last())
                {
                    node.next = queue.First();
                }
            }
        }
        public List<int> RecoverTree(TreeNode A)
        {
            var current = A;
            var ans = new List<int>();
            /*will be using 3 pointer approach discussed in the video explanation*/
            var first = -1;
            var middle = -1;
            var last = -1;
            var prev = A;
            var prevSetfirsttime = false;
            while (current != null)
            {
                if (current.left == null)
                {
                    //print
                    if (!prevSetfirsttime)
                    {
                        prev = current;
                        prevSetfirsttime = true;
                    }
                    if (prev.val > current.val)
                    {
                        if (first == -1)
                        {
                            first = prev.val;
                            middle = current.val;
                        }
                        else
                        {
                            last = current.val;
                        }
                    }
                    prev = current;
                    current = current.right;
                }
                else
                {
                    var rightNode = FindRightNode(current);
                    if (rightNode.right == null)
                    {//visiting for the first time
                        rightNode.right = current;
                        current = current.left;
                        // prev = current;
                    }
                    else
                    {//revisit
                     //print
                        if (prev.val > current.val)
                        {
                            if (first == -1)
                            {
                                first = prev.val;
                                middle = current.val;
                            }
                            else
                            {
                                last = current.val;
                            }
                        }

                        rightNode.right = null;
                        prev = current;
                        current = current.right;
                    }
                }
            }
            ans.Add(first);
            if (last == -1)
            {
                ans.Add(middle);
            }
            else
            {
                ans.Add(last);
            }
            return ans;//.OrderBy(a=>a).ToList();    
        }

        public List<int> RecoverTreeOld(TreeNode A)
        {
            var current = A;
            var ans = new List<int>();

            while (current != null)
            {
                if (current.left == null)
                {
                    //print
                    if (current.right != null && current.val > current.right.val)
                    {
                        ans.Add(current.right.val);
                    }
                    current = current.right;
                }
                else
                {
                    var rightNode = FindRightNode(current);
                    if (rightNode.right == null)
                    {//visiting for the first time
                        rightNode.right = current;
                        current = current.left;
                    }
                    else
                    {//revisit
                     //print
                        if (current.val < rightNode.val)
                            ans.Add(rightNode.val);
                        rightNode.right = null;
                        current = current.right;
                    }
                }
            }
            return ans;
        }

        TreeNode FindRightNode(TreeNode A)
        {
            var temp = A.left;
            while (temp.right != null && temp.right != A)
            {
                temp = temp.right;
            }
            return temp;
        }
        public int Diameter(TreeNode A)
        {
            if (A == null) return int.MinValue;
            var diam = 0;
            Height(A, ref diam);
            return diam;
        }
        public int Height(TreeNode A, ref int diam)
        {
            if (A == null)
                return -1;
            var leftHeight = Height(A.left, ref diam);
            var rightHeight = Height(A.right, ref diam);
            diam = leftHeight + rightHeight + 2;

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public List<int> InOrderTraversal(TreeNode A)
        {
            var list = new List<int>();
            var stack = new Stack<TreeNode>();

            var head = A;

            PushToStack(stack, head);

            while (stack.Count > 0)
            {
                head = stack.Pop();
                list.Add(head.val);

                if (head.right != null)
                {
                    head = head.right;
                    PushToStack(stack, head);
                }
            }

            return list;
        }
        private void PushToStack(Stack<TreeNode> S, TreeNode A)
        {
            while (A != null)
            {
                S.Push(A);
                A = A.left;
            }
        }
    }

    /*  class TreeNode
      {
          public TreeNode(int data)
          {
              this.Val = data;
              this.LeftChild = null;
              this.RightChild = null;
          }
          public int Val;
          public TreeNode LeftChild;
          public TreeNode RightChild;

          public bool HasRight()
          {
              return this.RightChild != null;
          }

          public bool HasLeft()
          {
              return this.LeftChild != null;
          }

      }*/
}
