using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.StacksAndQueues
{
    class CheckTwoBracketExpression
    {
        public int solve(string A, string B)
        {
            var stackA = new Stack<char>();
            var stackB = new Stack<char>();

            buildStack(stackA, A);
            buildStack(stackB, B);


            while (stackA.Count > 0 && stackB.Count > 0)
            {
                if (stackA.Peek() != stackB.Peek())
                    return 0;
                stackA.Pop();
                stackB.Pop();
            }

            while (stackA.Count > 0 && (stackA.Peek() == '+' || stackA.Peek() == '-'))
                stackA.Pop();
            while (stackB.Count > 0 && (stackB.Peek() == '+' || stackB.Peek() == '-'))
                stackB.Pop();

            if (stackA.Count == 0 && stackB.Count == 0)
                return 1;
            else return 0;

        }

        void buildStack(Stack<char> stack, string str)
        {
            var invert = false;
            for (int i = 0; i < str.Length; i++)
            {
                var ch = str[i];
                if (ch == '(')
                {
                    if (i > 0 && (str[i - 1] == '-'))
                        invert = !invert;
                    continue;
                }
                else if (ch == ')')
                {
                    invert = !invert;
                    continue;
                }
                else
                {
                    if ((ch == '+' && invert))
                        stack.Push('-');
                    else if ((ch == '-' && invert))
                        stack.Push('+');
                    else
                        stack.Push(ch);
                }
            }
        }

    }

}
