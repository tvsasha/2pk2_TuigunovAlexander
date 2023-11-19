using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[20];
            int minValue = -15;
            int maxValue = 14;
            Random rnd = new Random();
            int maxElement = int.MinValue; // Переменная для хранения максимального элемента массива
            int count = 0;

            for (int i = 0; i < array.Length; i++)  //Цикл для прохода по всем элементам массива.
            {
                array[i] = rnd.Next(minValue, maxValue + 1);
                if (array[i] > maxElement)
                {
                    maxElement = array[i];
                }
            }

            Console.WriteLine("Массив:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine("\nМаксимальный элемент: " + maxElement);

            for (int i = 0; i < array.Length; i++)
            {
                if (Math.Abs(array[i]) > maxElement)
                {
                    count++;
                }
            }

            Console.WriteLine("Количество элементов по модулю больших, чем максимальный: " + count);
        }
    }
}
