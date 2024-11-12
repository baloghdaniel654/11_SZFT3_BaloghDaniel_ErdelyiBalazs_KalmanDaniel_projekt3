namespace maze_quest_LIB
{
    public class PlayerManager
    {
        private readonly GameState _gameState;

        public PlayerManager(GameState gameState)
        {
            _gameState = gameState;
        }

        public void MovePlayer(ConsoleKey key)
        {
            int prevPlayerX = _gameState.PlayerX;
            int prevPlayerY = _gameState.PlayerY;

            int newX = _gameState.PlayerX;
            int newY = _gameState.PlayerY;

            switch (key)
            {
                case ConsoleKey.W: newY--; break;
                case ConsoleKey.S: newY++; break;
                case ConsoleKey.A: newX--; break;
                case ConsoleKey.D: newX++; break;
            }

            if (newX >= 0 && newY >= 0 && newX < _gameState.Map.GetLength(1) && newY < _gameState.Map.GetLength(0) && _gameState.Map[newY, newX] != '#')
            {
                _gameState.Map[prevPlayerY, prevPlayerX] = ' ';

                _gameState.PlayerX = newX;
                _gameState.PlayerY = newY;

                if (_gameState.Map[_gameState.PlayerY, _gameState.PlayerX] == 'O')
                {
                    _gameState.TalismanCount++;
                    _gameState.Map[_gameState.PlayerY, _gameState.PlayerX] = ' ';
                }

                if (_gameState.Map[_gameState.PlayerY, _gameState.PlayerX] != 'G')
                {
                    _gameState.Map[_gameState.PlayerY, _gameState.PlayerX] = 'X';
                }

                if (_gameState.Map[_gameState.PlayerY, _gameState.PlayerX] == 'G')
                {
                    _gameState.CurrentLevel++;

                    if (_gameState.CurrentLevel > 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Gratulálunk! Minden szintet teljesített!");
                        System.Threading.Thread.Sleep(2000);
                        new Start(_gameState).ShowMainMenu();
                    }
                    else
                    {
                        new Start(_gameState).InitializeLevelMap();
                    }
                }
            }
        }

    }
}
