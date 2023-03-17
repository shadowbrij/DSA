using System;
using System.Linq;

namespace ConsoleApplication5
{
    public class Tries
    {
        private class Node
        {
            private static int NUMBER_OF_CHAR = 26;
            Node[] children = new Node[NUMBER_OF_CHAR];
            int size = 0;
            private Node getNode(char c)
            {
                return children[getCharIndex(c)];
            }
            private void setNode(char c, Node node)
            {
                children[getCharIndex(c)] = node;
            }
            private int getCharIndex(char c)
            {
                return c - 'a';
            }
            public void add(string s)
            {
                add(s, 0);
            }
            private void add(string s, int index)
            {
                size++;
                if (index == s.Length) return;

                char current = s.ElementAt(index);
                Node node = getNode(current);
                if (node == null)
                {
                    node = new Node();
                    setNode(current, node);
                }
                node.add(s, index + 1);
            }
            public int findCount(string s)
            {
                return findCount(s, 0);
            }
            private int findCount(string s, int index)
            {
                if (index == s.Length) return size;
                Node current = getNode(s.ElementAt(index));
                if (current == null) return 0;
                return current.findCount(s, index + 1);
            }
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Node tries = new Node();
            for (int a0 = 0; a0 < n; a0++)
            {
                string[] tokens_op = Console.ReadLine().Split(' ');
                string op = tokens_op[0];
                string contact = tokens_op[1];
                if (op == "add")
                {
                    tries.add(contact);
                }
                else if (op == "find")
                {
                    int count = tries.findCount(contact);
                    Console.WriteLine(count);
                }
            }
            Console.ReadLine();
        }
    }
}
