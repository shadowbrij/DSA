using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments
{
    class StacksProblems
    {

        public static string InfixToPostfix(string A)
        {
            var stack = new Stack<char>();
            var operators = new HashSet<char>() { '^', '/', '*', '+', '-','(',')' };
            var ans = new StringBuilder();

            foreach (var ch in A)
            {
                if (!operators.Contains(ch))
                {
                    ans.Append(ch);
                }
                else
                {
                    if (ch == ')')
                    {
                        while (stack.Peek() != '(')
                            ans.Append(stack.Pop());
                        stack.Pop();
                    }
                    else if (stack.Count == 0 || ch == '(' || isHighPrecedence(ch, stack.Peek()))
                    {
                        stack.Push(ch);
                    }
                    else
                    {
                        while (stack.Count > 0 && !isHighPrecedence(ch, stack.Peek()) && stack.Peek() != '(')
                        {
                            ans.Append(stack.Pop());
                        }
                    }
                }
            }
            return ans.ToString();
        }
        static bool isHighPrecedence(char a, char b)
        {
            if (a == b)
                return false;

            if (a == '^')
                return true;
            else if (a == '/' || a == '*')
                return b != '^';
            else
                return (b != '^' && b != '/' && b != '*');

        }
        public static int evalRPN(List<string> A)
        {
            var hs = new HashSet<string>() { "+", "-", "*", "/" };
            var stack = new Stack<int>();
            foreach (var str in A)
            {
                if (hs.Contains(str))
                {
                    var op1 = stack.Pop();
                    var op2 = stack.Pop();
                    var res = 0;
                    switch (str)
                    {
                        case "+": 
                            res = op1 + op2;
                            break;
                        case "-": 
                            res = op2 - op1;
                            break;
                        case "*": 
                            res = op1 * op2;
                            break;
                        case "/": 
                            res = op2 / op1;
                            break;
                        default:break;
                    }
                    stack.Push(res);
                }
                else
                {
                    stack.Push(Convert.ToInt32(str));
                }
            }
            return stack.Pop();
        }
        public static int BalancedParanthesis(string A)
        {
            var hs = new Dictionary<char,char>();
            hs['('] = ')';
            hs['{'] = '}';
            hs['['] = ']';

            var stack = new Stack<char>();
            int i = 0;
            while (i < A.Length)
            {
                if (hs.ContainsKey(A[i]))
                    stack.Push(A[i]);
                else if (stack.Count == 0) return 0;
                else
                {
                    var current = stack.Pop();
                    if (A[i] != hs[current]) return 0;
                }

                i++;
            }
            
            if (stack.Count == 0) return 1;
            else return 0;

        }
    }
}
