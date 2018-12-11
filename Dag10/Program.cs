using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dag10
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input\\input.spp");
            var stack = Parse(input);

            Console.WriteLine(stack.Max());
            Console.Read();
        }

        static Stack<int> Parse(string[] input)
        {
            var stack = new Stack<int>();

            foreach (var line in input)
            {
                foreach (var c in line)
                {
                    bool isComment = false;
                    int sum;
                    int a;
                    int b;
                    switch (c)
                    {
                        case ' ':
                            stack.Push(31);
                            break;
                        case ':':
                            sum = 0;
                            while (stack.TryPop(out var result))
                            {
                                sum += result;
                            }
                            stack.Push(sum);
                            break;
                        case '|':
                            stack.Push(3);
                            break;
                        case '\'':
                            sum = 0;
                            sum += stack.Pop();
                            sum += stack.Pop();
                            stack.Push(sum);
                            break;
                        case '.':
                            a = stack.Pop();
                            b = stack.Pop();
                            stack.Push(a - b);
                            stack.Push(b - a);
                            break;
                        case '_':
                            a = stack.Pop();
                            b = stack.Pop();
                            stack.Push(a * b);
                            stack.Push(a);
                            break;
                        case '/':
                            stack.Pop();
                            break;
                        case 'i':
                            stack.Push(stack.Peek());
                            break;
                        case '\\':
                            a = stack.Pop();
                            a++;
                            stack.Push(a);
                            break;
                        case '*':
                            a = stack.Pop();
                            b = stack.Pop();
                            stack.Push((int)Math.Floor((decimal)a / b));
                            break;
                        case ']':
                            a = stack.Pop();
                            if (a % 2 == 0)
                            {
                                stack.Push(1);
                            }
                            break;
                        case '[':
                            a = stack.Pop();
                            if (a % 2 == 1)
                            {
                                stack.Push(a);
                            }
                            break;
                        case '~':
                            a = stack.Pop();
                            b = stack.Pop();
                            var d = stack.Pop();

                            if (a >= b && a >= d)
                            {
                                stack.Push(a);
                            }
                            else if (b >= a && b >= d)
                            {
                                stack.Push(b);
                            }
                            else
                            {
                                stack.Push(d);
                            }
                            break;
                        case 'K':
                            isComment = true;
                            break;
                        default:
                            break;
                    }
                    
                    if (isComment)
                    {
                        break;
                    }
                }
            }
            return stack;
        }
    }
}
