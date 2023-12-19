using System;

namespace PZ_16
{
    internal class Program
    {
        static int mapSize = 25; //размер карты
        static char[,] map = new char[mapSize+1, mapSize+1]; //карта
        //координаты на карте игрока
        static int playerY = mapSize / 2;
        static int playerX = mapSize / 2;
        static byte enemies = 10; //количество врагов
        static byte enemyCount = 0;
        static byte buffs = 5; //количество усилений
        static byte buffsTime = 21;
        static int health = 5;  // количество аптечек   
         //параметры игрока
        static byte playerHP = 50;
        static byte playerStrong = 10;
        static byte playerStepCount = 0;
        //параметры консоли
        static int winHeight = 40;
        static int winWidth = 100;
        //
        static byte enemyHP = 30;
        static byte enemyStrong = 5;
        static bool BaffUpActive = false;
        //параметры боса
        static byte bossHP = 40;
        static byte BossStrong = 10;
        static byte bossCount = 0;
        static int bossSpawn = 0;
        static int animationDelay = 100;
        static void Main(string[] args)         
        {
            Preview2();            
        }
        // <summary>
        // генерация карты с расставлением врагов, аптечек, баффов
        // </summary>
        static void GenerationMap()
        {
            Random random = new Random();
            //создание пустой карты
            for (int i = 0; i <  mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = '_';
                }
            }
            map[playerX, playerY] = 'P'; // в середину карты ставится игрок
            //временные координаты для проверки занятости ячейки
            int x;
            int y;
            //добавление врагов
            while (enemies > 0)
            {
                x = random.Next(0, mapSize - 2);
                y = random.Next(1, mapSize - 2);

                //если ячейка пуста  - туда добавляется враг
                if (map[x, y] == '_')
                {
                    map[x, y] = 'E';
                    enemies--; //при добавлении врагов уменьшается количество нерасставленных врагов
                    enemyCount ++;
                }
            }
            //добавление баффов
            while (buffs > 0)
            {
                x = random.Next(0, mapSize-2);
                y = random.Next(1, mapSize-2);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'B';
                    buffs--;
                }
            }
            //добавление аптечек
            while (health > 0)
            {
                x = random.Next(0, mapSize - 2);
                y = random.Next(1, mapSize - 2);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'H';
                    health--;
                }
            }
            UpdateMap(); //отображение заполненной карты на консоли
        }
        // <summary>
        // перемещение персонажа
        // </summary>
        static void Move()
        {
            //предыдущие координаты игрока
            int playerOldY;
            int playerOldX;
            if (playerHP == 0 || playerHP > 50)
            {
                Console.SetCursorPosition(40, 14);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Вы проиграли бой за {playerStepCount} шагов");
                Console.ResetColor();
            }
            else
            {
                while (true)
                {
                    playerOldX = playerX;
                    playerOldY = playerY;
                    //смена координат в зависимости от нажатия клавиш\
                    if (enemyCount <= 11 && enemyCount != 0 && playerHP>0 && playerHP<51) 
                    {
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.UpArrow:
                                playerX--;
                                playerStepCount++;
                                BaffCheck();
                                BaffOver();
                                if (playerX == -1)
                                {
                                    playerX = 23;
                                }
                                CloseInfo1();
                                CloseInfo2();
                                break;
                            case ConsoleKey.DownArrow:
                                playerX++;
                                playerStepCount++;
                                BaffCheck();
                                BaffOver();
                                if (playerX == 25)
                                {
                                    playerX = 0;
                                }
                                CloseInfo1();
                                CloseInfo2();
                                break;
                            case ConsoleKey.LeftArrow:
                                playerY--;
                                playerStepCount++;
                                BaffCheck();
                                BaffOver();
                                if (playerY == -1)
                                {
                                    playerY = 24;
                                }
                                CloseInfo1();
                                CloseInfo2();
                                break;
                            case ConsoleKey.RightArrow:
                                playerY++;
                                playerStepCount++;
                                BaffCheck();
                                BaffOver();
                                if (playerY == 25)
                                {
                                    playerY = 0;
                                }
                                CloseInfo1();
                                CloseInfo2();
                                break;
                            case ConsoleKey.Escape:
                                Preview1();

                                break;
                        }
                        switch (map[playerX, playerY])
                        {
                            case 'E':
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                map[playerOldX, playerOldY] = '_';
                                Console.SetCursorPosition(playerOldY, playerOldX);
                                Console.Write('_');
                                Console.ResetColor();
                                Fight();
                                BaffCheck();
                                BaffOver();
                                CloseInfo1();
                                break;
                            case 'B':
                                BaffUp();
                                BaffCheck();
                                BaffOver();
                                CloseInfo1();
                                CloseInfo2();
                                break;
                            case 'H':
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                map[playerOldX, playerOldY] = '_';
                                Console.SetCursorPosition(playerOldY, playerOldX);
                                Console.Write('_');
                                Console.ResetColor();
                                AidAUP();                           
                                break;
                            case 'D':
                                FightBoss();
                                BaffCheck();
                                BaffOver();
                                CloseInfo1();
                                CloseInfo2();
                                break;

                        }
                        Console.CursorVisible = false; //скрытный курсов
                        //предыдущее положение игрока затирается
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        map[playerOldX, playerOldY] = '_';
                        Console.SetCursorPosition(playerOldY, playerOldX);
                        Console.Write('_');
                        Console.ResetColor();
                        //обновленное положение игрока
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        map[playerX, playerY] = 'P';
                        Console.SetCursorPosition(playerY, playerX);
                        Console.Write('P');
                        Console.ResetColor();
                        //вывод всей нужной информации для пользователя
                        if (playerHP < 10)
                        {
                            //Console.SetCursorPosition(0, mapSize + 2);
                            //Console.WriteLine(new String(' ', Console.BufferWidth));
                        }
                        Console.SetCursorPosition(0, mapSize + 4);
                        Console.WriteLine("Количество шагов: " + playerStepCount);
                        Console.SetCursorPosition(0, mapSize + 2);
                        if (playerHP < 10)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Здоровье игрока: " + " " + playerHP);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("Здоровье игрока: " + playerHP);

                        }
                        Console.SetCursorPosition(0, mapSize + 3);
                        Console.WriteLine("Урон: " + playerStrong);
                    }
                    else if (enemyCount == 0)
                    {
                        if (bossSpawn == 0)
                        {
                            bossSpawn = 1;
                            bossCount = 1;
                            enemies = 1;
                            buffs = 3;
                            health = 3;
                            GenerationMap();
                            UpdateMap();
                        }
                    }
                    else if (playerHP == 0 || playerHP > 51)
                    {

                        {
                            Console.SetCursorPosition(40, 14);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Вы проиграли бой за {playerStepCount} шагов");
                            Console.ResetColor();
                            Preview2();

                        }
                    }
                }
                               
            }
            return;
        }
        // <summary>
        // вывод карты на консоль
        // </summary>
        static void UpdateMap()
        {
            Console.Clear();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    switch (map[i,j])
                    {
                        case 'E':
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("E");
                            Console.ResetColor();
                            Console.ResetColor();
                            break;
                        case '_':
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            Console.ResetColor();
                            break;
                        default:
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            Console.ResetColor();
                            break;
                        case 'H':
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            Console.ResetColor();
                            break;
                        case 'P':
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            Console.ResetColor();
                            break;
                    }
                            
                }
                Console.ResetColor();
                Console.WriteLine();
                
            }
                  
            Console.SetCursorPosition(0, mapSize + 4);
            Console.WriteLine("Количество шагов: " + playerStepCount);
            Console.SetCursorPosition(0, mapSize + 2);
            if (playerHP < 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Здоровье игрока: " + " " + playerHP);
            }
            else 
            {
                Console.WriteLine("Здоровье игрока: "  +playerHP);
                Console.ResetColor();
            }
            
            Console.SetCursorPosition(0, mapSize + 3);
            Console.WriteLine("Урон: " + playerStrong);
            
        }
        
        static void Fight()
        {
            if (bossCount==1)
            {
                FightBoss();
            }
            int playerOldX = playerX;
            int playerOldY = playerY;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(playerOldY, playerOldX);
            Console.Write('_');
            Console.ResetColor();
            byte enemyHP = 30;
            byte enemyStrong = 5;
            Console.SetCursorPosition(playerY, playerX);
            Console.Write('_');
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(playerY, playerX);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("E");
                Console.ResetColor();
                Console.ResetColor();
                Thread.Sleep(animationDelay);
                Console.SetCursorPosition(playerY, playerX);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("P");
                Thread.Sleep(animationDelay);
                Console.ResetColor();
                Console.ResetColor();
            }
            //playerOldX = playerX;
            //playerOldY = playerY;
            //map[playerY, playerX] = '_';
            //map[playerOldX, playerOldY] = '_';
            //playerX = PlayerOldX;
            //playerY = PlayerOldY;
            map[playerY, playerX] = 'P';
            // Обмен ударами между игроком и врагом
            while (playerHP > 0 && enemyHP > 0 && 31 > enemyHP)
            {
                
                enemyHP -= playerStrong; 
                playerHP -= enemyStrong;
            }
            map[playerX, playerY] = 'P';
            
            // Определяем победителя и обновляем карту
            if (playerHP > 0 && playerHP <= 50)
            {
                // Игрок победил, обновляем карту
                //map[playerY, playerX] = 'P'; // символ игрока
                Console.SetCursorPosition(40,14);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Вы победили врага!");
                Console.ResetColor();
                enemyCount--;
            }
            else
            {
                    Console.Clear();
                    Console.SetCursorPosition(40, 14);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Вы проиграли за {playerStepCount} шагов");                    
                    Console.ResetColor();
                    Preview2();
            }

            
        }
        static void BaffUp()
        {
            BaffUpActive = true;
            if (playerStrong>=20)
            {
                Console.SetCursorPosition(40, 6);
                buffsTime = 21;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Действие баффа продлено");
                Console.ResetColor();
            }
            else
            playerStrong *= 2;           
            
        }
        static void AidAUP()
        {
            int playerOldX = playerX;
            int playerOldY = playerY;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(playerOldY, playerOldX);
            Console.Write('_');
            Console.ResetColor();
            byte enemyHP = 30;
            byte enemyStrong = 5;
            Console.SetCursorPosition(playerY, playerX);
            Console.Write('_');
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(playerY, playerX);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("p");
                Console.ResetColor();
                Console.ResetColor();
                Thread.Sleep(animationDelay);
                Console.SetCursorPosition(playerY, playerX);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("P");
                Thread.Sleep(animationDelay);
                Console.ResetColor();
                Console.ResetColor();
            }
            playerHP = 50;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(40, 7);
            Console.WriteLine("Вы использовали аптечку, здоровье повышено до 50 HP ");
            Console.ResetColor();
            
        }
        static void BaffOver()
        {
            if (buffsTime == 0 && playerStrong > 10 ^ buffsTime>20)
            {
                BaffUpActive = false;
                playerStrong /= 2;
                Console.SetCursorPosition(40,  8);
                Console.WriteLine("Действие баффа завершено ");
                buffsTime = 21;
            }
        }
        static void BaffCheck()
        {
            if (BaffUpActive == true)
            {
                buffsTime--;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(40, 8);
                Console.WriteLine($"Бафф активен еще {buffsTime} шагов");
                Console.ResetColor();
            }
            else
            BaffOver();
        }
        static void Preview1()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(40, 16);
            Console.WriteLine("+r-r продолжить игру");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(40, 17);
            Console.WriteLine("-s сохранить игру");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(40, 18);
            Console.WriteLine("-z загрузить сохранение");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(40, 19);
            Console.WriteLine("-n начать новую игру");
            Console.ResetColor();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.R:
                    UpdateMap();
                    Move();
                    break;
                case ConsoleKey.Z:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(40, 15);                                   
                    Console.ResetColor();
                    LoadGame();
                    UpdateMap();
                    Move();
                    break;
                case ConsoleKey.N:
                    NewGame();
                    GenerationMap();
                    Move();
                    UpdateMap();
                    break;
                case ConsoleKey.S:
                    SaveGame();
                    Console.Write("Игра сохранена");
                    UpdateMap();
                    break;
            }
                    return;
        }
        static void Preview2()
        {
            enemies = 10; //количество врагов
            byte enemyCount = 0;
            byte buffs = 5; //количество усилений
            byte buffsTime = 21;
            int health = 5;  // количество аптечек   
             //параметры игрока
            byte playerHP = 50;
            byte playerStrong = 10;
            byte playerStepCount = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(40, 17);
            Console.WriteLine("-z загрузить сохранение");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(40, 16);
            Console.WriteLine("-n начать новую игру");
            Console.ResetColor();
            switch (Console.ReadKey().Key)
            {              
                case ConsoleKey.Z:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(40, 15);
                    Console.ResetColor();
                    LoadGame();
                    break;
                case ConsoleKey.N:
                    NewGame();
                    GenerationMap();
                    Move();
                    UpdateMap();
                    break;
            }
            return;
        }
        static void SaveGame()
        {
            // Создание или перезапись файла save.txt
            using (StreamWriter writer = new StreamWriter("save.txt"))
            {
                writer.WriteLine(playerX);
                writer.WriteLine(playerY);
                writer.WriteLine(playerHP);
                writer.WriteLine(playerStrong);
                writer.WriteLine(playerStepCount);
                writer.WriteLine(enemyCount);
                writer.WriteLine(bossCount);
                // Сохранение карты в файл
                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        writer.Write(map[i, j]);
                    }
                    writer.WriteLine();
                }

            }
        }
        static void LoadGame()
        {
            using (StreamReader reader = new StreamReader("save.txt"))
            {
                playerX = int.Parse(reader.ReadLine());
                playerY = int.Parse(reader.ReadLine());
                playerHP = byte.Parse(reader.ReadLine());
                playerStrong = byte.Parse(reader.ReadLine());
                playerStepCount = byte.Parse(reader.ReadLine());
                enemyCount = byte.Parse(reader.ReadLine());
                bossCount = byte.Parse(reader.ReadLine());
                for (int i = 0; i < mapSize; i++)
                {
                    string save = reader.ReadLine();
                    for (int j = 0; j < mapSize; j++)
                    {
                        map[i, j] = save[j];
                    }
                }
            }
            UpdateMap();
            Move();
        }
        static void NewGame()
        {
            Console.Clear();
            enemies = 10; //количество врагов
            enemyCount = 0;
            buffs = 5; //количество усилений
            buffsTime = 21;
            health = 5;  // количество аптечек   
                                    //параметры игрока
            playerHP = 50;
            playerStrong = 10;
            playerStepCount = 0;
            //параметры консоли
            winHeight = 40;
            winWidth = 100;
            //
            enemyHP = 30;
            enemyStrong = 5;
            BaffUpActive = false;
            //параметры босса
            bossHP = 40;
            BossStrong = 10;
            bossCount = 0;
            bossSpawn = 0;
            playerY = mapSize / 2;
            playerX = mapSize / 2;
            GenerationMap();
            UpdateMap();
            Move();
        }
        static void FightBoss()
        {
            byte enemyHP = 40;
            byte enemyStrong = 10;
            int playerOldX = playerX;
            int playerOldY = playerY;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(playerOldY, playerOldX);
            Console.Write('_');
            Console.ResetColor();
            Console.SetCursorPosition(playerY, playerX);
            Console.Write('_');
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(playerY, playerX);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("E");
                Console.ResetColor();
                Console.ResetColor();
                Thread.Sleep(animationDelay);
                Console.SetCursorPosition(playerY, playerX);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("P");
                Thread.Sleep(animationDelay);
                Console.ResetColor();
                Console.ResetColor();
            }
            // Обмен ударами между игроком и врагом
            while (playerHP > 0 && enemyHP > 0 && 41 > enemyHP && enemyHP != 0)
            {
                enemyHP -= playerStrong;
                playerHP -= enemyStrong;
            }
            if (playerHP <= 50 && playerHP != 0)
            {
                    Console.Clear();
                    Console.SetCursorPosition(40, 15);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Вы победили всех врагов и босса за {playerStepCount} шагов");
                    bossCount = 0;
                    Console.ResetColor();
                    Preview2();
            }
                else if(playerHP>50 || playerHP == 0)
                {
                    Console.Clear();
                    Console.SetCursorPosition(40, 15);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Вы проиграли за {playerStepCount} шагов");
                    bossCount = 0;
                    Console.ResetColor();
                    
                }
            Preview2();
        }
        static void CloseInfo1()
        {
            if (playerHP < 50)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(40, 7);
                Console.WriteLine("                                                                  ");
                Console.ResetColor();
            }          
        }
        static void CloseInfo2()
        {
            Console.SetCursorPosition(40, 14);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                  ");
            Console.ResetColor();
        }
    }  
}