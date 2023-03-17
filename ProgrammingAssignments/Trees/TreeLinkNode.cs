using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Trees
{
    class TreeLinkNode
    {
      public int val;
      public TreeLinkNode left;
      public TreeLinkNode right, next;
      public TreeLinkNode(int x) { this.val = x; this.left = this.right = null; this.next = null; }
  }
}
