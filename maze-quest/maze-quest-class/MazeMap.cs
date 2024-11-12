namespace maze_quest_LIB
{
    public class MazeMap
    {
        private readonly GameState _gameState;

        public MazeMap(GameState gameState)
        {
            _gameState = gameState;
        }

        public void InitializeCaveMap()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---- Maze Quest ----");
            Console.WriteLine("1. pálya - Barlang");

            System.Threading.Thread.Sleep(3000);
            _gameState.Map = new char[21, 41];

            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 41; j++)
                {
                    if ((i == 0 || i == 20) && (j >= 0 && j < 41))
                    {
                        _gameState.Map[i, j] = '#';
                    }
                    else if ((j == 0 || j == 40) && (i >= 0 && i < 21))
                    {
                        _gameState.Map[i, j] = '#';
                    }
                    else
                    {
                        _gameState.Map[i, j] = ' ';
                    }
                }
            }

            GenerateWalls(20);

            _gameState.Map[_gameState.PlayerY, _gameState.PlayerX] = 'X';
            _gameState.Map[18, 20] = 'O';
            _gameState.Map[1, 39] = 'G';
        }

        public void InitializeJungleMap()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---- Maze Quest ----");
            Console.WriteLine("2. pálya - Dzsungel");
            System.Threading.Thread.Sleep(3000);

            _gameState.Map = new char[21, 41];

            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 41; j++)
                {
                    if ((i == 0 || i == 20) && (j >= 0 && j < 41))
                    {
                        _gameState.Map[i, j] = '#';
                    }
                    else if ((j == 0 || j == 40) && (i >= 0 && i < 21))
                    {
                        _gameState.Map[i, j] = '#';
                    }
                    else
                    {
                        _gameState.Map[i, j] = ' ';
                    }
                }
            }

            GenerateWalls(20);

            _gameState.Map[_gameState.PlayerY, _gameState.PlayerX] = 'X';
            _gameState.Map[2, 20] = 'O';
            _gameState.Map[19, 1] = 'G';
        }

        public void InitializeDesertMap()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---- Maze Quest ----");
            Console.WriteLine("3. pálya - Sivatag");
            System.Threading.Thread.Sleep(3000);

            _gameState.Map = new char[21, 41];
            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 41; j++)
                {
                    if ((i == 0 || i == 20) && (j >= 0 && j < 41))
                    {
                        _gameState.Map[i, j] = '#';
                    }
                    else if ((j == 0 || j == 40) && (i >= 0 && i < 21))
                    {
                        _gameState.Map[i, j] = '#';
                    }
                    else
                    {
                        _gameState.Map[i, j] = ' ';
                    }
                }
            }

            GenerateWalls(20);

            _gameState.Map[_gameState.PlayerY, _gameState.PlayerX] = 'X';
            _gameState.Map[10, 2] = 'O';
            _gameState.Map[1, 1] = 'G';
        }

        private void GenerateWalls(int wallCount)
        {
            Random rnd = new Random();
            int count = 0;

            while (count < wallCount)
            {
                int x = rnd.Next(1, _gameState.Map.GetLength(1) - 1);
                int y = rnd.Next(1, _gameState.Map.GetLength(0) - 1);

                if (_gameState.Map[y, x] == ' ')
                {
                    _gameState.Map[y, x] = '#';
                    count++;
                }
            }
        }
    }
}
