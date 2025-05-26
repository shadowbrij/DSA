using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.LinkedLists
{
    class LRUCache
    {
        class DLLNode
        {
            public int Value;
            public int Key;
            public DLLNode Left;
            public DLLNode Right;
            public DLLNode(int key, int value) { Key = key; Value = value; Left = null; Right = null; }
        }
        private Dictionary<int, DLLNode> Map;
        private DLLNode Current;
        private DLLNode Head;
        private int Capacity;
        public LRUCache(int capacity)
        {
            //this looks unnecessary, no idea what happens when
            // map reached to its capacity
            Map = new Dictionary<int, DLLNode>(capacity);
            Capacity = capacity;
        }
        public int get(int key)
        {
            if (Map.ContainsKey(key))
            {
                var node = Map[key];
                Map.Remove(node.Key);
                if (ReferenceEquals(node, Head))
                    RemoveHead();
                DeleteNode(node);
                AddNodeToDLL(key, node);
                return node.Value;
            }
            else
            {
                return -1;
            }
        }

        private void RemoveHead()
        {
            Head = Head.Right;
            if (Head != null)
            {
                Head.Left.Right = null;
                Head.Left = null;
            }
        }
        public void set(int key, int value)
        {
            var newNode = new DLLNode(key, value);

            if (Map.ContainsKey(key))
            {
                var node = Map[key];
                Map.Remove(node.Key);

                if (ReferenceEquals(node, Head))
                    RemoveHead();
                DeleteNode(node);
            }
            else if (Map.Count == Capacity)
            {
                Map.Remove(Head.Key);
                RemoveHead();
                //DeleteNode(Head) - Assumed to be grabage collected.
            }

            AddNodeToDLL(key, newNode);
        }

        private void AddNodeToDLL(int key, DLLNode newNode)
        {
            if (Map.Count == 0)
            {
                Head = newNode;
                Current = newNode;
                Map.Add(key, Current);
            }
            else
                PushitToTheEndOfDDList(newNode, key);
        }

        private void PushitToTheEndOfDDList(DLLNode node, int key)
        {
            //insert it at the end, make it current
            if (!ReferenceEquals(Current, node))
            {
                node.Left = Current;
                node.Right = null;
                Current.Right = node;
                Current = node;
                Map[key] = Current;
            }
        }
        private void DeleteNode(DLLNode node)
        {
            if (Current.Left != null && ReferenceEquals(Current, node))
            {
                Current = Current.Left;
                Current.Right = null;
                return;
            }

            if (node.Left != null)
            {
                node.Left.Right = node.Right;
            }
            if (node.Right != null)
            {
                node.Right.Left = node.Left;
            }
            node.Left = null;
            node.Right = null;
        }

    }
}
