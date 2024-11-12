namespace maze_quest_LIB
{
    public class EnemyManager
    {
        private readonly GameState _gameState;

        public EnemyManager(GameState gameState)
        {
            _gameState = gameState;
        }

        public void InitializeEnemies()
        {
            Random rnd = new Random();

            int enemyCount = _gameState.CurrentLevel == 1 ? 1 :
                             _gameState.CurrentLevel == 2 ? 3 : 5;

            _gameState.EnemyX = new int[enemyCount];
            _gameState.EnemyY = new int[enemyCount];

            for (int i = 0; i < enemyCount; i++)
            {
                _gameState.EnemyX[i] = rnd.Next(1, _gameState.Map.GetLength(1) - 1);
                _gameState.EnemyY[i] = rnd.Next(1, _gameState.Map.GetLength(0) - 1);
                _gameState.Map[_gameState.EnemyY[i], _gameState.EnemyX[i]] = 'E';
            }
        }

        public void MoveEnemies()
        {
            Random rnd = new Random();

            for (int i = 0; i < _gameState.EnemyX.Length; i++)
            {
                if (_gameState.EnemyX[i] == -1 || _gameState.EnemyY[i] == -1) continue;

                int direction = rnd.Next(1, 5);

                int newEnemyX = _gameState.EnemyX[i];
                int newEnemyY = _gameState.EnemyY[i];

                switch (direction)
                {
                    case 1: newEnemyX--; break;
                    case 2: newEnemyX++; break;
                    case 3: newEnemyY--; break;
                    case 4: newEnemyY++; break;
                }

                if (newEnemyX > 0 && newEnemyX < _gameState.Map.GetLength(1) - 1 &&
                    newEnemyY > 0 && newEnemyY < _gameState.Map.GetLength(0) - 1 &&
                    _gameState.Map[newEnemyY, newEnemyX] != '#')
                {
                    if (_gameState.PlayerX == newEnemyX && _gameState.PlayerY == newEnemyY)
                    {
                        _gameState.PlayerHealth -= 5;
                        _gameState.Map[_gameState.EnemyY[i], _gameState.EnemyX[i]] = ' ';
                        _gameState.EnemyX[i] = -1;
                        _gameState.EnemyY[i] = -1;

                        if (_gameState.PlayerHealth <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Game Over! A játék véget ért.");
                            System.Threading.Thread.Sleep(2000);
                            Environment.Exit(0);
                        }
                        continue;
                    }

                    _gameState.Map[_gameState.EnemyY[i], _gameState.EnemyX[i]] = ' ';
                    _gameState.EnemyX[i] = newEnemyX;
                    _gameState.EnemyY[i] = newEnemyY;
                    _gameState.Map[_gameState.EnemyY[i], _gameState.EnemyX[i]] = 'E';
                }
            }
        }


    }
}
