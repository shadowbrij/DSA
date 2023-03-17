using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.LinkedLists
{
    public class ListNode
    {
        public ListNode(int val)
        {
            this.val = val;
            this.next = null;
        }
        public int val;
        public ListNode next;
    }
}
