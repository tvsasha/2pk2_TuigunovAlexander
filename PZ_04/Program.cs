using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1 "); 
            for (int i = -50; i <= 0; i += 5)
            {
                Console.WriteLine(" " + i);
            }
            Console.WriteLine("Задание 2");
            //Задание 2
            char s = 'л';
            for (int i = 0; i <= 7; i++)
            {
                Console.WriteLine(" " + s);
                s++;
            }
            Console.WriteLine("Задание 3");
            //Задание 3
            int m = 10;
            int n = 4;
            char f = '#';
            for (int i = 0; i < m;i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(f);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Задание 4");
            //Задание 4 
            int e = 0;
            for (int i = 0;i <= 1000;i++)
            {
                if (i % 14 == 0)
                {
                    Console.Write(i + "  ");
                    e++;
                }
            }
            Console.WriteLine("\nОбщее число чисел " + e);
            Console.WriteLine("Задание 5");
            //Задание 5
            int ii = 0;
            int jj = 45;
            for (; Math.Abs(ii - jj) > 17; ii++, jj--)
            {
                Console.WriteLine("i: " + ii + ", j: " + jj);
            }

            Console.WriteLine("i: " + ii + ", j: " + jj);
        }
    }
}
