using ProgrammingAssignments.LinkedLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Contests
{
    internal class EvenReverse
    {
            public ListNode solve(ListNode A)
        {
            /*
            Should be doable in 3 steps;
            1. Detach even and odd lists.
            2. reverse the even list
            3. merge
                    */
            //upto lenght 3
            if ((A == null)
                || (A.next == null) //N =1 
                || (A.next.next == null) // N =2 
                || (A.next.next.next == null)) //N = 3
                return A;

            var oddHead = A;
            var tempO = A;
            var evenHead = A.next; ;
            var tempE = evenHead;

            //detach
            while (tempO != null && tempE != null)
            {
                tempO.next = tempE.next;
                if (tempE.next != null)
                    tempE.next = tempE.next.next;//null check

                tempO = tempO.next;
                tempE = tempE.next;
            }

            //reverse even
            ListNode prev = null;
            var current = evenHead;
            var next = evenHead.next;
            while (current != null)
            {
                current.next = prev;
                current = next;
                prev = current;
                if (next != null)
                    next = next.next;
            }
            evenHead = prev;

            //merge
            var temp = oddHead;
            tempE = evenHead;
            while (evenHead != null)
            {
                tempE = tempE.next;
                evenHead.next = temp.next;
                temp.next = evenHead;

                temp = evenHead.next;
                evenHead = tempE;
            }

            return oddHead;
        }
    }
}
