namespace PZ_12
{
    internal class Program
    {
        static double evklid(double[,] mas)           // метод для вычисления Евклидовой нормы
        {
            double norms = 0;
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    norms = norms + (mas[i, j] * mas[i, j]);                  
                }
            }

            norms = Math.Sqrt(norms);
            Console.WriteLine(Math.Round(norms, 2));
            return norms;
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            double[,] a = new double[5, 3];
            double f = 0;
            for (int i = 0; i < a.GetLength(0); i++)        //заполнение массива случайными значениями
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = rnd.Next(-100, 100);
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
            f = evklid(a);
            Console.WriteLine($"Евклидова норма для этого массива: {Math.Round(f, 2)}");
        }
    }
}