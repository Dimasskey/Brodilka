namespace Brodilka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int killedEnemy = 0;
            bool equipWeapon = false;
            bool isStart = true;
            Console.CursorVisible = false;
            Random rand = new Random();
            int health = 10, maxHealth = 10;


            char[] bag = new char[1];

            char[,] map = {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#' },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','-',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#','#','#','#','#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ','#',' ','+',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ','X',' ','#',' ',' ',' ',' ','X',' ','#',' ','X',' ','X',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ','#',' ','+',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ','#',' ',' ','*',' ','*',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ','#','#','#',' ',' ','X',' ',' ',' ','#',' ',' ',' ','X',' ',' ',' ',' ',' ','#' },
                {'#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ','#',' ',' ','*',' ',' ',' ','+',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ','#',' ',' ',' ','+',' ','+',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ','*',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ','X',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#' }
            };

            infoMenu();

            int playerX = 1, playerY = 1;

            while (isStart)
            {
                if (health == 0)
                {
                    Console.Write("GameOver");
                    isStart = false;
                    Console.ReadKey();
                }

                DrawBar(health, maxHealth);
                int randX = rand.Next(1, 19);
                int randY = rand.Next(1, 22);
                Console.SetCursorPosition(0, 20);
                Console.Write("Наш bag: ");
                for (int i = 0; i < bag.Length; i++)
                {
                    Console.Write(bag[i] + " ");
                }

                Console.SetCursorPosition(0, 22);
                Console.Write($"Убитых врагов: {killedEnemy}");
                Console.SetCursorPosition(0, 23);
                Console.Write("Для вызова инфо меню нажмите 'X'");


                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }

                Console.SetCursorPosition(playerY, playerX);
                Console.Write("@");
                ConsoleKeyInfo charKey = Console.ReadKey();
                switch (charKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (map[playerX - 1, playerY] != '#')
                        {
                            playerX--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (map[playerX + 1, playerY] != '#')
                        {
                            playerX++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (map[playerX, playerY - 1] != '#')
                        {
                            playerY--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[playerX, playerY + 1] != '#')
                        {
                            playerY++;
                        }
                        break;
                    case ConsoleKey.C:
                        Console.Clear();
                        Console.WriteLine($"Завершение работы.\n" +
                            $"Собрано {bag.Length - 1} сокровищ.");
                        Console.ReadKey();
                        isStart = false;

                        break;
                    case ConsoleKey.X:
                        Console.Clear();
                        infoMenu();
                        break;


                }
                if (map[playerX, playerY] == 'X')
                {
                    map[playerX, playerY] = 'o';
                    char[] tempBag = new char[bag.Length + 1];
                    for (int i = 0; i < bag.Length; i++)
                    {
                        tempBag[i] = bag[i];
                    }
                    tempBag[tempBag.Length - 2] = 'X';
                    bag = tempBag;
                    while (isStart)
                    {
                        if (map[randX, randY] != '#')
                        {
                            map[randX, randY] = 'X';
                            break;
                        }
                        else
                        {
                            break;
                        }

                    }
                }
                if (map[playerX, playerY] == '*')
                {
                    if (equipWeapon)
                    {
                        map[playerX, playerY] = ' ';
                        killedEnemy += 1;
                    }
                    else
                    {
                        health -= 1;
                    }
                }
                if ((map[playerX, playerY] == '+'))
                {
                    if (health == maxHealth)
                    {
                        continue;
                    }
                    else
                    {
                        health += 1;
                        map[playerX, playerY] = ' ';
                    }
                }
                if ((map[playerX, playerY] == '-'))
                {
                    equipWeapon = true;
                    map[playerX, playerY] = ' ';
                }


                Console.Clear();
            }

        }

        static void DrawBar(int value, int maxValue)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;

            string bar = "";

            for (int i = 0; i < value; i++)
            {
                bar += " ";
            }

            Console.SetCursorPosition(0, 21);
            Console.Write("Ваше здоровье");
            Console.Write('[');
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write(bar);

            Console.BackgroundColor = defaultColor;

            bar = "";

            for (int i = value; i < maxValue; i++)
            {
                bar += " ";
            }

            Console.Write(bar);
            Console.Write(']');
        }

        static void infoMenu()
        {
            Console.Write("Добро пожаловать в игру.\n" +
                "Схема управления:\n" +
                "Стрелка вверх - ход наверх\n" +
                "Стрелка вниз - ход вниз\n" +
                "Стрелка вправо - ход вправо\n" +
                "Стрелка влево - ход влево\n" +
                "Так же на карте есть сокровища которые отмечены знаком 'X'\n" +
                "Враги '*'\n" +
                "Лечение на 1 единицу здоровья '+'\n" +
                "Меч '-', без которого вы не сможете убивать врагов и они будут отнимать по 1 единицы здоровья\n" +
                "Приятной игры!\n" +
                "Для продолжения нажмите любую кнопку");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
