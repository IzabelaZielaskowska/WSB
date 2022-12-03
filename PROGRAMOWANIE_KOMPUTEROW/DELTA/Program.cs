using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DELTA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, this is a program to calculate the quadratic equation.");
            Console.WriteLine("ax^2 + bx + c = 0");
            Console.WriteLine("click to continue");
            Console.WriteLine("-----------------");
            Console.ReadLine();

            Console.Write("Enter the value a: ");
            string number_A = Console.ReadLine();

            Console.Write("Enter the value b: ");
            string number_B = Console.ReadLine();

            Console.Write("Enter the value c: ");
            string number_C = Console.ReadLine();

            double A;
            double B;
            double C;
            double DELTA;

            bool is_NUM_A = double.TryParse(number_A, out A);
            bool is_NUM_B = double.TryParse(number_B, out B);
            bool is_NUM_C = double.TryParse(number_C, out C);

            if (is_NUM_A && is_NUM_B && is_NUM_C)
            {
                DELTA = ((B * B) - (4 * A * C));
                Console.WriteLine("-----------------");
                Console.WriteLine("DELTA = " + DELTA);

                if (DELTA < 0)
                { 
                    Console.WriteLine("No solution");
                }
                else if (DELTA == 0)
                {
                    Console.WriteLine("XO = " + ((-B) / (2 * A)));
                }
                else if (DELTA > 0)
                {
                    Console.WriteLine("X1 = " + ((- B - Math.Sqrt(DELTA))/(2 * A)));
                    Console.WriteLine("X2 = " + ((- B + Math.Sqrt(DELTA))/(2 * A)));
                }
            }
            else
            {
                Console.WriteLine("-----------------");
                Console.WriteLine("It's not a numbers, try again.");
                Console.WriteLine("-----------------");
                Main(args);
            }

            Console.ReadLine();

        }
    }
}
