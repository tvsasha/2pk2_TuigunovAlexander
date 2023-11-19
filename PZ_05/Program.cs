using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine (" Введите время нахождения тела в свободном падении");
            double i = Convert.ToDouble(Console.ReadLine());

            double g = 9.8;
            double t = 0;
            double v;
            while (t < i) 
            {
                v = g * t;
                t+=0.5;
                Console.WriteLine("Время: " + t.ToString("0.0") + " с, Скорость: " + v.ToString("0.0") + " м/с");

            }
        }
    }
}
