namespace PZ_13
{
    internal class Program
    {
        //задача 1
        static double progressArifm(double n)
        {
            double count = 0;
            double a1 = -8;
            double d = -3;
            if (n != 0)
            {
                count = a1 + d * (n - 1);               //поиск n-го члена арифметической прогрессии 
                progressArifm(n - 1);
            }
            return count;
        }
        //задача 2
        static double ProgressGeom(double n)
        {
            double count = 0;
            double a1 = 4;
            double d = -0.01;
            if (n != 0)
            {
                count = a1 * Math.Pow(d, (n - 1));    ////поиск n-го члена геометрической прогрессии 
                ProgressGeom(n - 1);
            }
            return count;
        }
        // задача 3
        static double Numbers(double a, double b)
        {
            if (a <= b)
            {
                Console.Write($"{a} ");
                Numbers(a + 1, b);
            }
            return b;
        }
        //задача 4 (4)
        static void Invert()
        {           
            Char ch = Convert.ToChar(Console.Read());
            if (ch != '.')
            {
                Invert();
                  Console.Write(ch) ;
            }
        }
    static void Main(string[] args)
        {

            //задача 1
            Console.WriteLine("Введите нужный член арифметической прогрессии");
            double su = Convert.ToDouble(Console.ReadLine());
            double nu = 0;
            nu = progressArifm(su);
            Console.WriteLine($"{su}-й член арифметической прогрессии {nu}");
            //задача 2
            Console.WriteLine("Введите нужный член геометрической прогрессии");
            double f = Convert.ToDouble(Console.ReadLine());
            double q = 0;
            q = ProgressGeom(f);
            Console.WriteLine($"{f}-й член геометрической прогрессии {q}");
            //задача 3
            Console.WriteLine("Введите первое число");
            double s = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите первое число");
            double e = Convert.ToDouble(Console.ReadLine());
            double n = 0;
            n = Numbers(s, e);
            Console.ReadLine();
            //задача 4
            Console.WriteLine("Введите необходимые числа через пробел, в конце поставьте точку");
            Invert();            
        }
    }
}