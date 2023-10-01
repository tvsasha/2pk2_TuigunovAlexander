using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PZ_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] s = new int[2][];
            Random random = new Random();
            int minValue = -100;
            int maxValue = 100;
            s[0] = new int[10];
            int rn = random.Next(5, 11);
            s[1] = new int[rn];
            for (int i = 0; i < s.Length; i++)
            {
                for (int x = 0; x < s[i].Length; x++)
                {
                    s[i][x] = random.Next(minValue, maxValue);
                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                for (int x = 0; x < s[i].Length; x++)
                {
                    Console.Write(s[i][x] + " ");
                }
                Console.WriteLine();
            }
            int[] f = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Length > 0)
                {
                    f[i] = s[i][s[i].Length - 1];
                }
            }

            Console.WriteLine("Последний элемент первой строки " + f[0] + " ");             // Вывод одномерного массива с последними элементами строк
            Console.WriteLine("Последний элемент второй строки " + f[1] + " ");

            int[] maxElements = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                int max = int.MinValue;
                for (int x = 0; x < s[i].Length; x++)
                {
                    if (s[i][x] > max)
                    {
                        max = s[i][x];
                    }
                }
                maxElements[i] = max;
            }
            Console.WriteLine("Максимальный элемент первой строки " + maxElements[0] + " ");       // Вывод одномерного массива с максимальными элементами
            Console.WriteLine("Максимальный элемент второй строки " + maxElements[1] + " ");
            for (int i = 0; i < s.Length; i++)
            {
                int left = 0;
                int right = s[i].Length - 1;
                while (left < right)
                {
                    int temp = s[i][left];
                    s[i][left] = s[i][right];
                    s[i][right] = temp;
                    left++;
                    right--;
                }
            }
            Console.WriteLine("Обновленный массив:");
            for (int i = 0; i < s.Length; i++)
            {
                for (int x = 0; x < s[i].Length; x++)
                {
                    Console.Write(s[i][x] + " ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < s.Length; i++)
            {
                int sum = 0;
                for (int x = 0; x < s[i].Length; x++)
                {
                    sum += s[i][x];
                }
                double average = (double)sum / s[i].Length;
                Console.WriteLine("Среднее значение в строке " + (i+1) + ": " + Math.Round(average,2));
            }
            for (int i = 0; i < s.Length; i++)                        // Подсчет общего количества символов в строках каждой строки массива
            {
                int totalCharacters = 0;
                for (int x = 0; x < s[i].Length; x++)
                {
                    totalCharacters += s[i][x].ToString().Length;
                }
                Console.WriteLine("Общее количество символов в строке " + (i + 1) + ": " + totalCharacters);
            }
            for (int t = 0; t < s.Length; t++)                          // Поиск наиболее встречающихся символов в каждой строке ступенчатого массива
            {
                Dictionary<char, int> charCounts = new Dictionary<char, int>();
                for (int x = 0; x < s[t].Length; x++)
                {
                    string numberString = s[t][x].ToString();
                    foreach (char c in numberString)
                    {
                        if (charCounts.ContainsKey(c))
                        {
                            charCounts[c]++;
                        }
                        else
                        {
                            charCounts[c] = 1;
                        }
                    }
                }
                char mostFrequentChar = charCounts.OrderByDescending(x => x.Value).FirstOrDefault().Key;
                Console.WriteLine("Наиболее встречающийся символ в строке " + (t + 1) + ": " + mostFrequentChar);
            }
        }
    }
}
