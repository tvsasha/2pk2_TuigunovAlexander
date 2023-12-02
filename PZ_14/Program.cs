namespace PZ_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
           
            try
            {
                using (FileStream f1Stream = new FileStream("f1.txt", FileMode.Open, FileAccess.Read))
                using (FileStream f2Stream = new FileStream("f2.txt", FileMode.Open, FileAccess.Read))
                using (StreamReader f1Reader = new StreamReader("f1.txt"))
                using (StreamReader f2Reader = new StreamReader("f2.txt"))
                using (StreamWriter writer = new StreamWriter("f3.txt"))
                {
                    string lineF1;
                    string lineF2;
                    while ((lineF1 = f1Reader.ReadLine()) != null && (lineF2 = f2Reader.ReadLine()) != null)
                    {
                        writer.WriteLine(lineF1);
                        writer.WriteLine(lineF2);
                    }
                    while ((lineF1 = f1Reader.ReadLine()) != null)
                    {
                        writer.WriteLine(lineF1);
                    }
                    while ((lineF2 = f2Reader.ReadLine()) != null)
                    {
                        writer.WriteLine(lineF2);
                    }
                }
                Console.WriteLine("Слияние файлов завершено. Результат записан в файл f3.txt.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
