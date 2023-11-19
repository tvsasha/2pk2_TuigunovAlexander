using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] s = new double[4, 4];
            Random rmd = new Random();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("\n");
                for (int j = 0; j < 4; j++)
                {
                    s[i, j] = rmd.Next(-100, 100) + rmd.NextDouble() ;
                    Console.Write(Math.Round(s[i, j], 2)+"\t");
                }
            }
            double minValue = 0;                                             
            for (int i = 0; i < s.GetLength(0); i++)                            //находим минимальный элемент матрицы
            {
                for (int j = 0; j < s.GetLength(1); j++)
                {
                    if (s[i, j] < minValue)
                    {
                        minValue = s[i, j];
                    }
                }
            }
            double sum = 0;
            for (int i = 0;i < s.GetLength(0); i++)                             // подсчет суммы положительных элементов матрицы
            {
                for (int j = 0;j < s.GetLength(1); j++)
                {
                    if (s[i, j] > 0)
                    {
                        sum += s[i, j];
                    }
                }
            }
            Console.WriteLine("\n" + "Минимальный элемента матрицы " + Math.Round(minValue,2));           // вывод всех значений 
            Console.WriteLine("Сумма положительных элементов матрицы равна " +Math.Round(sum,2));
            double e = minValue * sum;
            Console.WriteLine("Их произведение равно " +Math.Round(e,2));
        }
    }
}
