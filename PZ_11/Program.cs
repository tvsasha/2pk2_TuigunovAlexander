namespace PZ_11
{
    internal class Program
    {
        
        
            static void PowerA234(double A, out double B, out double C, out double D)         //процедура для поиска квадрата, куба и четвертой степени
            {
                B = A * A;
                C = B * A;
                D = C * A;
                return;
            }
            static void Main(string[] args)
            {
                double r;
                double n;
                double x;
                Console.WriteLine("Введите число");
                for (int i = 0; i < 5; i++)                                              //Пятикратное использование метода PowerA234
            {
                    double c = Convert.ToDouble(Console.ReadLine());
                    PowerA234(c, out r, out n, out x);
                    Console.WriteLine($"Число {c}\nв квадрате: {r}\nв кубе: {n}\nв четвертой степени: {x}");
                    Console.WriteLine("Введите следующее число");
                }

            }
        
    }
}