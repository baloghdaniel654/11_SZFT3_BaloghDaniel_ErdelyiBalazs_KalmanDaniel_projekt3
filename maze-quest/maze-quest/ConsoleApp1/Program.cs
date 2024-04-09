using System;

class Program
{
    static int playerX = 10;
    static int playerY = 10;
    static int playerHealth = 10;
    static int talismanCount = 0;
    static int currentLevel = 1;
    static char[,] map;
    static ConsoleColor playerColor = ConsoleColor.Blue;
    static ConsoleColor enemyColor = ConsoleColor.Red;
    static ConsoleColor healthColor = ConsoleColor.Green;
    static int enemyX;
    static int enemyY;

    static void Main(string[] args)
    {
        Console.CursorVisible = false;

        while (true)
        {
            switch (currentLevel)
            {
                case 1:
                    InitializeCaveMap();
                    break;
                case 2:
                    InitializeJungleMap();
                    break;
                case 3:
                    InitializeDesertMap();
                    break;
            }

            DrawMap();
            InitializeEnemies();

            while (true)
            {
                MoveEnemies();
                Console.Clear();
                DrawMap();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.Clear();
                MovePlayer(keyInfo.Key);
                DrawMap();
            }
        }
    }

    static void InitializeEnemies()
    {
        Random rnd = new Random();
        enemyX = rnd.Next(1, map.GetLength(1) - 1);
        enemyY = rnd.Next(1, map.GetLength(0) - 1);
        map[enemyY, enemyX] = 'E';
    }

    static void MoveEnemies()
    {
        Random rnd = new Random();
        int direction = rnd.Next(1, 5);

        int newEnemyX = enemyX;
        int newEnemyY = enemyY;

        switch (direction)
        {
            case 1: // Move up
                newEnemyY--;
                break;
            case 2: // Move down
                newEnemyY++;
                break;
            case 3: // Move left
                newEnemyX--;
                break;
            case 4: // Move right
                newEnemyX++;
                break;
        }

        if (map[newEnemyY, newEnemyX] == ' ')
        {
            map[enemyY, enemyX] = ' ';
            enemyX = newEnemyX;
            enemyY = newEnemyY;
            map[enemyY, enemyX] = 'E';
        }
    }

    static void InitializeCaveMap()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1. pálya - Barlang");

        map = new char[21, 41];

        for (int i = 0; i < 21; i++)
        {
            for (int j = 0; j < 41; j++)
            {
                if ((i == 0 || i == 20) && (j >= 0 && j < 41))
                {
                    map[i, j] = '#';
                }
                else if ((j == 0 || j == 40) && (i >= 0 && i < 21))
                {
                    map[i, j] = '#';
                }
                else
                {
                    map[i, j] = ' ';
                }
            }
        }

        map[playerY, playerX] = 'X';
        map[18, 20] = 'O';
    }

    static void InitializeJungleMap()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("2. pálya - Dzsungel");

        map = new char[21, 41];

        for (int i = 0; i < 21; i++)
        {
            for (int j = 0; j < 41; j++)
            {
                if ((i == 0 || i == 20) && (j >= 0 && j < 41))
                {
                    map[i, j] = '#';
                }
                else if ((j == 0 || j == 40) && (i >= 0 && i < 21))
                {
                    map[i, j] = '#';
                }
                else
                {
                    map[i, j] = ' ';
                }
            }
        }

        map[playerY, playerX] = 'X';
        map[2, 20] = 'O';
    }

    static void InitializeDesertMap()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("3. pálya - Sivatag");

        map = new char[21, 41];

        for (int i = 0; i < 21; i++)
        {
            for (int j = 0; j < 41; j++)
            {
                if ((i == 0 || i == 20) && (j >= 0 && j < 41))
                {
                    map[i, j] = '#';
                }
                else if ((j == 0 || j == 40) && (i >= 0 && i < 21))
                {
                    map[i, j] = '#';
                }
                else
                {
                    map[i, j] = ' ';
                }
            }
        }

        map[playerY, playerX] = 'X';
        map[10, 2] = 'O';
    }

    static void MovePlayer(ConsoleKey key)
    {
        int prevPlayerX = playerX;
        int prevPlayerY = playerY;

        switch (key)
        {
            case ConsoleKey.W:
                if (map[playerY - 1, playerX] != '#')
                {
                    playerY--;
                }
                break;
            case ConsoleKey.S:
                if (map[playerY + 1, playerX] != '#')
                {
                    playerY++;
                }
                break;
            case ConsoleKey.A:
                if (map[playerY, playerX - 1] != '#')
                {
                    playerX--;
                }
                break;
            case ConsoleKey.D:
                if (map[playerY, playerX + 1] != '#')
                {
                    playerX++;
                }
                break;
        }

        if (map[playerY, playerX] == 'E')
        {
            PlayerHitEnemy();
        }
        else if (map[playerY, playerX] == 'O')
        {
            talismanCount++;
            map[prevPlayerY, prevPlayerX] = ' ';
            map[playerY, playerX] = 'X';
        }
        else
        {
            map[prevPlayerY, prevPlayerX] = ' ';
            map[playerY, playerX] = 'X';
        }
    }

    static void PlayerHitEnemy()
    {
        map[playerY, playerX] = ' ';
        playerHealth--;
        healthColor = ConsoleColor.Green;

        if (playerHealth <= 0)
        {
            GameOver();
        }
    }


    static void DrawMap()
    {
        Console.SetCursorPosition(0, 0);

        for (int i = 0; i < 21; i++)
        {
            for (int j = 0; j < 41; j++)
            {
                if (map[i, j] == 'X')
                {
                    Console.ForegroundColor = playerColor;
                }
                else if (map[i, j] == 'E')
                {
                    Console.ForegroundColor = enemyColor;
                }
                else if (map[i, j] == 'O')
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else if (map[i, j] == '#')
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.Write(map[i, j]);
            }
            Console.WriteLine();
        }

        Console.ForegroundColor = healthColor;
        Console.SetCursorPosition(0, 22);
        Console.Write("Health: ");
        for (int i = 0; i < playerHealth; i++)
        {
            Console.Write("█");
        }
        Console.ResetColor();
        Console.WriteLine();

        Console.SetCursorPosition(0, 23);
        Console.Write($"Talisman: {talismanCount}");


        if (map[playerY, playerX] != 'X')
        {
            map[playerY, playerX] = ' ';
        }
    }

    static void GameOver()
    {
        Console.Clear();
        Console.WriteLine("Game Over!");
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
        Environment.Exit(0);
    }
}
