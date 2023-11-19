namespace PZ_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к файлу на диске:");
            string path = Console.ReadLine();
            if (!System.IO.File.Exists(path))                                     // Проверка корректности пути
            {
                Console.WriteLine("Некорректный путь к файлу.");
                return;
            }
            string[] directories = System.IO.Path.GetDirectoryName(path).Split(System.IO.Path.DirectorySeparatorChar);      // Получаем каталоги из пути
            Console.WriteLine("Названия каталогов:");                            // Вывод названий каталогов
            foreach (string directory in directories)
            {
                Console.Write(directory + "\\");
            }
        }
    }
}