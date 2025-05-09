using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;  // Set background to blue
            Console.ForegroundColor = ConsoleColor.White; // Set text color to white
            Console.Clear();//sets background color
            Console.WriteLine("##---CALCULATOR---##");
            double num1;
            double num2;
            char op;
            double res = 0;
            string str;
            do
            {
                Console.WriteLine("Enter the First number:");
                num1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the Second number:");
                num2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the operation to be performed:");
                op = Convert.ToChar(Console.ReadLine());
                switch (op)
                {
                    case '+':
                        res = num1 + num2;
                        Console.WriteLine($"{num1}+{num2}={res}");
                        break;
                    case '-':
                        res = num1 - num2;
                        Console.WriteLine($"{num1}-{num2}={res}");
                        break;
                    case '*':
                        res = num1 * num2;
                        Console.WriteLine($"{num1}*{num2}={res}");
                        break;
                    case '/':
                        res = num1 / num2;
                        Console.WriteLine($"{num1}/{num2}={res}");
                        break;
                    case '%':
                        res = num1 % num2;
                        Console.WriteLine($"{num1}%{num2}={res}");
                        break;                          
                    default:
                        Console.WriteLine("!!Enter the correct operation to be performed:");
                        break;

                }
                Console.WriteLine("Enter y to continue:");
                str = Console.ReadLine();
            } while (str == "y");

        }
    }
}
