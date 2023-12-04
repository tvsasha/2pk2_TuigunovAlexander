namespace PZ_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к каталогу: ");
            string path = Console.ReadLine();
            string[] files = Directory.GetFiles(path);
            foreach (string filePath in files)
            {
                string fileName = Path.GetFileName(filePath);
                Console.WriteLine(fileName);                        //вывод всех файлов указанного каталога
            }
            Console.WriteLine("Введите имя первого файла для сравнения: ");
            string file1Name = Console.ReadLine();
            string file1Path = FindFile(path, file1Name);
            Console.WriteLine("Введите имя второго файла для сравнения: ");
            string file2Name = Console.ReadLine();
            string file2Path = FindFile(path, file2Name);

            if (!string.IsNullOrEmpty(file1Path) && !string.IsNullOrEmpty(file2Path))
            {
                string line1 = File.ReadAllText(file1Path);
                string line2 = File.ReadAllText(file2Path);

                if (line1 == line2)
                {
                    Console.WriteLine("Содержание файлов идентично");
                }
                else
                {
                    Console.WriteLine("Содержание файлов разное");
                }
            }
            else
            {
                Console.WriteLine("Один или оба файла не существуют");
            }

            Console.ReadLine();
        }
        static string FindFile(string directory, string fileName)            // метод для поиска файла в каталоге
        {
            string[] files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);

            foreach (string filePath in files)
            {
                string file = Path.GetFileNameWithoutExtension(filePath);
                if (file == fileName)
                {
                    return filePath;
                }
            }
            return null;
        }
    }
    
}