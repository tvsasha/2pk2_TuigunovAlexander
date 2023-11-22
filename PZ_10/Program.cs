namespace PZ_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст: ");     
            string input = Console.ReadLine();
            var charCount = new Dictionary<char, int>();          //создание словаря
            foreach (char c in input)                             //прохождение по всем символам
            {
                if (char.IsLetter(c))
                {
                    if (charCount.ContainsKey(c))
                    {
                        charCount[c]++;
                    }
                    else
                    {
                        charCount[c] = 1;
                    }
                }
            }
            var letter = charCount.OrderByDescending(x => x.Value).FirstOrDefault().Key; //нахождение наиболее часто встречающегося символа 
            var count = charCount[letter];
            Console.WriteLine($"Наиболее часто встречающийся символ: {letter}");
            Console.WriteLine($"Количество: {count}");
        }
    }
    
}