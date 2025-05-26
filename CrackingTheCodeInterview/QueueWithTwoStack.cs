using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirtyDaysOfCode
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    class QueueWithTwoStack
    {

        static Stack<int> stackOne = new Stack<int>();
        static Stack<int> stackTwo = new Stack<int>();

        //static void Main(String[] args)
        //{
        //    /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        //    string? input = Console.ReadLine();
        //    if (input == null)
        //        throw new InvalidOperationException("Input cannot be null.");
        //        
        //    int queries = Convert.ToInt32(input);
        //    for (int i = 0; i < queries; i++)
        //    {
        //        string? queryInput = Console.ReadLine();
        //        if (queryInput == null) break;
        //        
        //        int[] type = Array.ConvertAll(queryInput.Split(' '), int.Parse);
        //        if (type[0] == 1) Enqueue(type[1]);
        //        else if (type[0] == 2) Dequeue();
        //        else if (type[0] == 3) PrintElement();
        //    }
        //    Console.ReadLine();
        //}
        private static void Enqueue(int data)
        {
            stackOne.Push(data);
        }
        private static void Dequeue()
        {
            if (stackTwo.Count != 0)
            {
                stackTwo.Pop();
            }
            else
            {
                CopyStack();
                stackTwo.Pop();
            }
        }
        private static void PrintElement()
        {
            if (stackTwo.Count != 0)
            {
                Console.WriteLine(stackTwo.Peek());
            }
            else CopyStack();
            Console.WriteLine(stackTwo.Peek());
        }
        private static void CopyStack()
        {
            while (!(stackOne.Count == 0))
            {
                stackTwo.Push(stackOne.Pop());
            }
        }
    }
}
