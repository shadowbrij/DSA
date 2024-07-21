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
            var charMapA = GetCharMap(A);
            var charMapB = GetCharMap(B);
            if (isMatch(charMapA, charMapB))
                return 1;
            else return 0;
        }

        Dictionary<int, bool> GetCharMap(string A)
        {
            var charMap = new Dictionary<int, bool>();
            var stack = new Stack<bool>();
            stack.Push(true); //true == +

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == '+' || A[i] == '-') continue;
                else if (A[i] == '(')
                {
                    if (Adjacent(A[i], A, i))
                    {
                        stack.Push(stack.Peek());
                    }
                    else
                        stack.Push(!stack.Peek());
                }
                else if (A[i] == ')')
                {
                    stack.Pop();
                }
                else
                { // just the character
                    if (stack.Peek())
                        charMap[A[i] - 'a'] = Adjacent(A[i], A, i);
                    else
                        charMap[A[i] - 'a'] = !Adjacent(A[i], A, i);
                }
            }

            return charMap;
        }

        bool Adjacent(char ch, string A, int i)
        {
            if (i == 0 || A[i - 1] == '+' || A[i-1] == '(') return true;
            else return false;
        }

        bool isMatch(Dictionary<int, bool> A, Dictionary<int, bool> B)
        {
            foreach (var kv in A)
            {
                if (!B.ContainsKey(kv.Key) || kv.Value != B[kv.Key]) return false;
            }
            return true;
        }



        /*
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
        */
    }

}
