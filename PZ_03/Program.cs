using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> k = new Dictionary<int, string>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Выберите время записи: \n 1: 08:00-09:00 \n 2: 09:00-10:00 \n 3: 10:00-11:00 \n 4: 11:00-12:00 \n 5: 12:00-13:00 \n 6: 13:00-14:00 \n 7: 14:00-15:00 \n 8: 15:00-16:00 \n 9: 16:00-17:00");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        if (k.ContainsKey(1))
                            Console.WriteLine("Время 08:00-09:00 уже занято ");
                        else
                        {
                            Console.WriteLine("Введите имя \nВведите номер телефона");
                            k.Add(1, "Занято");
                        }
                        break;
                    case 2:
                        if (k.ContainsKey(2))
                            Console.WriteLine("Время 09:00-10:00 уже занято");
                        else
                        {
                            Console.WriteLine("Введите имя \nВведите номер телефона");
                            k.Add(2, "Занято");
                        }
                        break;
                    case 3:
                        if (k.ContainsKey(3))
                            Console.WriteLine("Время 10:00-11:00 уже занято");
                        else
                        {
                            k.Add(3, "Занято");
                            Console.WriteLine("Введите имя \nВведите номер телефона");
                        }
                        break;
                    case 4:
                        if (k.ContainsKey(4))
                            Console.WriteLine("Время 11:00-12:00 уже занято");
                        else
                        {
                            k.Add(4, "Занято");
                            Console.WriteLine("Введите имя \nВведите номер телефона");
                        }
                        break;
                    case 5:
                        if (k.ContainsKey(5))
                            Console.WriteLine("Время 12:00-13:00 уже занято");
                        else
                        {
                            k.Add(5, "Занято");
                            Console.WriteLine("Введите имя \nВведите номер телефона");
                        }
                        break;
                    case 6:
                        if (k.ContainsKey(6))
                            Console.WriteLine("Время 13:00-14:00 уже занято");
                        else
                        {
                            k.Add(6, "Занято");
                            Console.WriteLine("Введите имя \nВведите номер телефона");
                        }
                        break;
                    case 7:
                        if (k.ContainsKey(7))
                            Console.WriteLine("Время 14:00-15:00 уже занято");
                        else
                        {
                            k.Add(7, "Занято");
                            Console.WriteLine("Введите имя \nВведите номер телефона");
                        }
                        break;
                    case 8:
                        if (k.ContainsKey(8))
                            Console.WriteLine("Время 15:00-16:00 уже занято");
                        else
                        {
                            k.Add(8, "Занято");
                            Console.WriteLine("Введите имя \nВведите номер телефона");
                        }
                        break;
                    case 9:
                        if (k.ContainsKey(9))
                            Console.WriteLine("Время 16:00-17:00 уже занято");
                        else
                        {
                            k.Add(9, "Занято");
                            Console.WriteLine("Введите имя \nВведите номер телефона");
                        } break;
                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
        }
    }      }
