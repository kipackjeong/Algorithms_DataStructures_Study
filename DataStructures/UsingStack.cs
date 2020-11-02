using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public class UsingStack
    {
        public string StringReverse(string s)
        {
            // edge cases

            // if input is null
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            // create stack to collect chars from string
            var stack = new Stack<char>();
            for (var i = 0; i < s.Length; i++)
            {
                stack.Push(s[i]);
            }

            // collect chars from stack
            var reversed = new StringBuilder();
            while (stack.Count != 0)
            {
                reversed.Append(stack.Pop());
            }

            return reversed.ToString();
        }

        public class BalanceCheck
        {
            public static bool IsBalanced(string s)
            {
                // create stack to collect
                var stack = new Stack<char>();

                // iterate over s,
                for (var i = 0; i < s.Length; i++)
                {
                    //if s[i] is '(,[,{,<', push this into stack
                    if (IsOpenBracket(s[i]))
                    {
                        stack.Push(s[i]);
                    }
                    else if (IsCloseBracket(s[i]))
                    {
                        if (stack.Count == 0)
                            return false;
                        var openBracket = stack.Pop();
                        if (!BracketMatch(s[i], openBracket))
                            return false;
                    }
                    // if s[i] is '),],},>', pop item and compare
                }
                /* after the step above,
                * if the string was balanced bracket, stack should be empty.
                */
                return stack.Count == 0;
            }

            /// <summary>Check if char is open bracket</summary>
            private static bool IsOpenBracket(char o)
            {
                var array = new char[] { '(', '[', '{', '<' };
                return o == '(' || o == '[' || o == '{' || o == '<';
            }

            /// <summary>Check if char is close bracket</summary>
            private static bool IsCloseBracket(char c)
            {
                return c == '(' || c == '[' || c == '{' || c == '<';
            }

            /// <summary>Check if open and close bracket match</summary>
            private static bool BracketMatch(char c, char o)
            {
                switch (c)
                {
                    case ')':
                        if (o != '(')
                            return false;
                        break;

                    case ']':
                        if (o != '[')
                            return false;
                        break;

                    case '}':
                        if (o != '{')
                            return false;
                        break;

                    case '>':
                        if (o != '<')
                            return false;
                        break;
                }
                return true;
            }
        }
    }
}