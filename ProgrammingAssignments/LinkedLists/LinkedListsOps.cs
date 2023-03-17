using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.LinkedLists
{
    //find the middle element

    public class LinkedListsOps
    {
        public static ListNode swapPairs(ListNode A)
        {
            if (A == null) return null;
            if (A.next == null) return A;

            ListNode prev = null;
            ListNode current = A;
            ListNode next = A.next;

            current.next = prev;
            prev = current;
            current = next;
            next = next.next;
            current.next = prev;

            prev.next = swapPairs(next);


            return current;
        }
        public static ListNode addTwoNumbers(ListNode A, ListNode B)
        {
            var x = A;
            var y = B;
            var carry = 0;
            ListNode head = null;
            ListNode temp = null;
            while (x != null || y != null)
            {
                var a = (x == null ? 0 : x.val);
                var b = (y == null ? 0 : y.val);

                var sum = a + b + carry;
                var data = (sum <= 9 ? sum : sum % 10);
                carry = sum / 10;

                var node = new ListNode(data);
                if (temp == null)
                {
                    head = node;
                    temp = head;
                }
                else
                {
                    temp.next = node;
                    temp = temp.next;
                }

                if (x != null)
                    x = x.next;
                if (y != null)
                    y = y.next;
            }
            if (carry > 0)
            {
                var node = new ListNode(carry);
                temp.next = node;
            }
            return head;
        }
        public static ListNode GenerateList(List<int> A)
        {
            int N = A.Count;
            var head = new ListNode(A[0]);
            var temp = head;
            for(int i = 1; i < N; i++)
            {
                var node = new ListNode(A[i]);
                temp.next = node;
                temp = temp.next;
            }
            return head;
        }
        public static int MiddleElem(ListNode A)
        {

            var count = 0;
            var temp = A;
            while(temp != null)
            {
                temp = temp.next;
                count++;
            }
            count /=2;
            temp = A;
            while (count > 0)
            {
                temp = temp.next;
                count--;
            }

            return temp.val;
        }

        public ListNode InsertAtPosition(ListNode head,int k,int X)
        {
            return head;

        }

        public void PrintLinkedList(ListNode head)
        {
            while(head.next != null)
            {
                Console.Write(head.val);
            }
        }
        public static bool Comp(ListNode A,ListNode B)
        {
            var eq = false;
            eq = Object.ReferenceEquals(A,B);
            return eq;
        }
    }

}
