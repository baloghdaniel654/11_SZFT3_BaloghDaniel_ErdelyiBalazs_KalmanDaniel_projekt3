namespace maze_quest_LIB
{
    public class MapDrawer
    {
        private readonly GameState _gameState;

        public MapDrawer(GameState gameState)
        {
            _gameState = gameState;
        }

        private ConsoleColor GetWallColor()
        {
            switch (_gameState.CurrentLevel)
            {
                case 1: return ConsoleColor.Gray;
                case 2: return ConsoleColor.Green;
                case 3: return ConsoleColor.Yellow;
                default: return ConsoleColor.Gray;
            }
        }

        public void DrawMap()
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 41; j++)
                {
                    if (_gameState.Map[i, j] == 'X')
                    {
                        Console.ForegroundColor = _gameState.PlayerColor;
                    }
                    else if (_gameState.Map[i, j] == 'E')
                    {
                        Console.ForegroundColor = _gameState.EnemyColor;
                    }
                    else if (_gameState.Map[i, j] == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    else if (_gameState.Map[i, j] == 'R')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (_gameState.Map[i, j] == 'G')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    }
                    else if (_gameState.Map[i, j] == '#')
                    {
                        Console.ForegroundColor = GetWallColor();
                    }
                    else
                    {
                        Console.ResetColor();
                    }

                    Console.SetCursorPosition(j, i);
                    Console.Write(_gameState.Map[i, j]);
                }
            }

            Console.SetCursorPosition(0, 22);
            Console.Write("Élet: ");
            for (int i = 0; i < _gameState.PlayerHealth; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("█");
            }

            Console.ResetColor();

            Console.SetCursorPosition(0, 23);
            Console.Write($"Talizmán: {_gameState.TalismanCount}");
        }
    }
}
