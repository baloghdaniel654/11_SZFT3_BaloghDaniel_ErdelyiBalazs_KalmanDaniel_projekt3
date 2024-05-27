using System;
using maze_quest_class;

class Program
{
    static vars gameState = new vars();

    static void Main(string[] args)
    {
        bool playing = true;

        while (playing)
        {
            Console.Clear();
            Console.WriteLine("---- Maze Quest ----");
            Console.WriteLine("[1] Játék indítása");
            Console.WriteLine("[2] Kilépés");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    playing = false;
                    break;
                case ConsoleKey.D2:
                    Environment.Exit(0);
                    break;
            }
        }

        Console.CursorVisible = false;

        while (true)
        {
            switch (gameState.CurrentLevel)
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
                CheckForCollisions();
            }
        }
    }

    static void InitializeEnemies()
    {
        Random rnd = new Random();

        if (gameState.CurrentLevel == 1)
        {
            gameState.EnemyX = new int[1];
            gameState.EnemyY = new int[1];
            gameState.EnemyX[0] = rnd.Next(1, gameState.Map.GetLength(1) - 1);
            gameState.EnemyY[0] = rnd.Next(1, gameState.Map.GetLength(0) - 1);
            gameState.Map[gameState.EnemyY[0], gameState.EnemyX[0]] = 'E';
        }
        else if (gameState.CurrentLevel == 2)
        {
            gameState.EnemyX = new int[3];
            gameState.EnemyY = new int[3];
            for (int i = 0; i < 3; i++)
            {
                gameState.EnemyX[i] = rnd.Next(1, gameState.Map.GetLength(1) - 1);
                gameState.EnemyY[i] = rnd.Next(1, gameState.Map.GetLength(0) - 1);
                gameState.Map[gameState.EnemyY[i], gameState.EnemyX[i]] = 'E';
            }
        }
        else if (gameState.CurrentLevel == 3)
        {
            gameState.EnemyX = new int[5];
            gameState.EnemyY = new int[5];
            for (int i = 0; i < 5; i++)
            {
                gameState.EnemyX[i] = rnd.Next(1, gameState.Map.GetLength(1) - 1);
                gameState.EnemyY[i] = rnd.Next(1, gameState.Map.GetLength(0) - 1);
                gameState.Map[gameState.EnemyY[i], gameState.EnemyX[i]] = 'E';
            }
        }
    }

    static void MoveEnemies()
    {
        Random rnd = new Random();

        for (int i = 0; i < gameState.EnemyX.Length; i++)
        {
            int direction = rnd.Next(1, 5);

            int newEnemyX = gameState.EnemyX[i];
            int newEnemyY = gameState.EnemyY[i];

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

            if (gameState.Map[newEnemyY, newEnemyX] == ' ')
            {
                gameState.Map[gameState.EnemyY[i], gameState.EnemyX[i]] = ' ';
                gameState.EnemyX[i] = newEnemyX;
                gameState.EnemyY[i] = newEnemyY;
                gameState.Map[gameState.EnemyY[i], gameState.EnemyX[i]] = 'E';
            }

            if (gameState.EnemyX[i] == gameState.PlayerX && gameState.EnemyY[i] == gameState.PlayerY)
            {
                PlayerHitEnemy();
            }
        }
    }

    static void InitializeCaveMap()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("---- Maze Quest ----");
        Console.WriteLine("1. pálya - Barlang");
        System.Threading.Thread.Sleep(3000);

        gameState.Map = new char[21, 41];

        for (int i = 0; i < 21; i++)
        {
            for (int j = 0; j < 41; j++)
            {
                if ((i == 0 || i == 20) && (j >= 0 && j < 41))
                {
                    gameState.Map[i, j] = '#';
                }
                else if ((j == 0 || j == 40) && (i >= 0 && i < 21))
                {
                    gameState.Map[i, j] = '#';
                }
                else
                {
                    gameState.Map[i, j] = ' ';
                }
            }
        }

        gameState.Map[gameState.PlayerY, gameState.PlayerX] = 'X';
        gameState.Map[18, 20] = 'O'; //Zöld talizmán
        //gameState.Map[5, 15] = 'R';  // Piros talizmán
        gameState.Map[1, 39] = 'G';  // Kapu
    }

    static void InitializeJungleMap()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("---- Maze Quest ----");
        Console.WriteLine("2. pálya - Dzsungel");
        System.Threading.Thread.Sleep(3000);

        gameState.Map = new char[21, 41];

        for (int i = 0; i < 21; i++)
        {
            for (int j = 0; j < 41; j++)
            {
                if ((i == 0 || i == 20) && (j >= 0 && j < 41))
                {
                    gameState.Map[i, j] = '#';
                }
                else if ((j == 0 || j == 40) && (i >= 0 && i < 21))
                {
                    gameState.Map[i, j] = '#';
                }
                else
                {
                    gameState.Map[i, j] = ' ';
                }
            }
        }

        gameState.Map[gameState.PlayerY, gameState.PlayerX] = 'X';
        gameState.Map[2, 20] = 'O';  //Zöld talizmán
        //gameState.Map[15, 30] = 'R'; // Piros talizmán
        gameState.Map[19, 1] = 'G';  // Kapu
    }

    static void InitializeDesertMap()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("---- Maze Quest ----");
        Console.WriteLine("3. pálya - Sivatag");
        System.Threading.Thread.Sleep(3000);

        gameState.Map = new char[21, 41];

        for (int i = 0; i < 21; i++)
        {
            for (int j = 0; j < 41; j++)
            {
                if ((i == 0 || i == 20) && (j >= 0 && j < 41))
                {
                    gameState.Map[i, j] = '#';
                }
                else if ((j == 0 || j == 40) && (i >= 0 && i < 21))
                {
                    gameState.Map[i, j] = '#';
                }
                else
                {
                    gameState.Map[i, j] = ' ';
                }
            }
        }

        gameState.Map[gameState.PlayerY, gameState.PlayerX] = 'X';
        gameState.Map[10, 2] = 'O';  // Zöld talizmán
        //gameState.Map[10, 30] = 'R'; // Piros talizmán
        gameState.Map[1, 1] = 'G';   // Kapu
    }

    static void MovePlayer(ConsoleKey key)
    {
        int prevPlayerX = gameState.PlayerX;
        int prevPlayerY = gameState.PlayerY;

        switch (key)
        {
            case ConsoleKey.W:
                if (gameState.Map[gameState.PlayerY - 1, gameState.PlayerX] != '#')
                {
                    gameState.PlayerY--;
                }
                break;
            case ConsoleKey.S:
                if (gameState.Map[gameState.PlayerY + 1, gameState.PlayerX] != '#')
                {
                    gameState.PlayerY++;
                }
                break;
            case ConsoleKey.A
