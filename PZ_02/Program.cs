using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите x и y");
            double x = Convert.ToDouble(Console.ReadLine());          // пользователь вводит данные
            int y = Convert.ToInt32(Console.ReadLine());
            double s, t, v;
            if (y < 2.0)
            {
                s = y - y * Math.Pow(x, 2) / (x + 1);                     //подсчет данных    
            }
            else
            {
                s = -10.6 * x * y;
            }
            if (s <= 0)
            {
                t = y * s + Math.Sin(x) + y;
            }
            else
            {
                t = s - Math.Pow(Math.Cos(s / x), 2.00);
            }
            v = 2.00 * y * x + 3.00 * y * s - s * t;

            Console.WriteLine($"x: {Math.Round(x, 2)}");           //вывод результатов
            Console.WriteLine($"y: {y}");
            Console.WriteLine($"s: {Math.Round(s, 2)}");
            Console.WriteLine($"t: {Math.Round(t, 2)}");
            Console.WriteLine($"v: {Math.Round(v, 2)}");
            Console.ReadKey();
        }
    }
}
