using System;
using System.Collections.Generic;


namespace BinaryTreeEval
{
    public class Program
    {
        public class Node
        {
            public string data;
            public Node left, right, next;

            public Node(string value)
            {
                data = value;
                left = right = next = null;
            }
        }

        static Node buildTree(string s)
        {
            Stack<Node> stackNodes = new Stack<Node>();
            Stack<string> stackValues = new Stack<string>();
            Node n, n1, n2;

            int[] p = new int[10000];
            p['+'] = p['-'] = 1;
            p['/'] = p['*'] = 2;
            p[')'] = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stackValues.Push(s[i].ToString());
                }
                else if (s[i] != '+' && s[i] != '-' && s[i] != '*' && s[i] != '/' && s[i] != '(' && s[i] != ')')
                {
                    string newValue = s[i].ToString();
                    var temp = s[i + 1];
                    if (temp != '+' && temp != '-' && temp != '*' && temp != '/' && temp != '(' && temp != ')')
                    {
                        newValue = s[i].ToString() + temp.ToString();
                        i++;
                    }
                    n = new Node(newValue);
                    stackNodes.Push(n);
                }
                else if (p[s[i]] > 0)
                {
                    //var index = stackValues.Peek()=="*" || stackValues.Peek()=="/"?2:
                    //stackValues.Peek() == "+" || stackValues.Peek() == "-"?1:0
                    while (stackValues.Count != 0 && stackValues.Peek() != "("
                        && (p[Convert.ToChar(stackValues.Peek())] >= p[s[i]]
                            ))
                    {
                        n = new Node(stackValues.Peek());
                        stackValues.Pop();
                        n1 = stackNodes.Peek();
                        stackNodes.Pop();
                        n2 = stackNodes.Peek();
                        stackNodes.Pop();
                        n.left = n2;
                        n.right = n1;

                        stackNodes.Push(n);
                    }

                    stackValues.Push(s[i].ToString());
                }
                else if (s[i] == ')')
                {
                    while (stackValues.Count != 0 && stackValues.Peek() != "(")
                    {
                        n = new Node(stackValues.Peek());
                        stackValues.Pop();
                        n1 = stackNodes.Peek();
                        stackNodes.Pop();
                        n2 = stackNodes.Peek();
                        stackNodes.Pop();
                        n.left = n2;
                        n.right = n1;
                        stackNodes.Push(n);
                    }
                    stackValues.Pop();
                }
            }
            n = stackNodes.Peek();
            return n;
        }

        static void printOrder(Node root)
        {
            if (root != null)
            {
                printOrder(root.left);
                printOrder(root.right);
                Console.Write(root.data);
            }
        }

        static void Main(string[] args)
        {
            string s = "(15+(6+8))";
            s = "(" + s;
            s += ")";
            Node root = buildTree(s);
            printOrder(root);
            Console.ReadLine();
        }
    }
}
