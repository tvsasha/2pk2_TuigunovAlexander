using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значения переменных a, b и c:"); //ввод данных пользователем
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());
            double c = Convert.ToDouble(Console.ReadLine());

            double res1 = Math.Pow(a, 2) + Math.Pow(b, 2) - 2.2 * c;   //вычисление значений
            double res6 = Math.Abs(res1);
            double res2 = Math.Pow(res6, 1.0 / 3.0);
            double res3 = Math.Pow(10, -3) * Math.Tan(-8);
            double res4 = (a - c) * (Math.Pow(a, 2) + Math.Pow(b, 2));
            double res5 = Math.Cos(2 * a) / Math.Sin(5);

            double result = res3 - (res4 / (-res2)) - res5;            //вычисление итогового значения

            Console.WriteLine("Результат вычисления: " + result);      //вывод данных
            Console.ReadKey();
        }
    }
}
