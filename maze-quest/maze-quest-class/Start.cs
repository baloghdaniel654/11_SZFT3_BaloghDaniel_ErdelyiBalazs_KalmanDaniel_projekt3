namespace maze_quest_LIB
{
    public class Start
    {
        private readonly GameState _gameState;
        private bool _playing;

        public Start(GameState gameState)
        {
            _gameState = gameState;
            _playing = true;
        }

        public void StartGame()
        {
            ShowMainMenu();
            RunGameLoop();
        }

        private void ShowMainMenu()
        {
            while (_playing)
            {
                Console.Clear();
                Console.WriteLine("---- Maze Quest ----");
                Console.WriteLine("[1] Játék indítása");
                Console.WriteLine("[2] Kilépés");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        _playing = false;
                        break;
                    case ConsoleKey.D2:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private void RunGameLoop()
        {
            Console.CursorVisible = false;

            while (true)
            {
                InitializeLevelMap();

                var enemyManager = new EnemyManager(_gameState);
                enemyManager.InitializeEnemies();

                while (true)
                {
                    enemyManager.MoveEnemies();

                    Console.Clear();
                    new MapDrawer(_gameState).DrawMap();

                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    Console.Clear();
                    new PlayerManager(_gameState).MovePlayer(keyInfo.Key);

                    new MapDrawer(_gameState).DrawMap();
                }
            }
        }
        public void InitializeLevelMap()
        {
            switch (_gameState.CurrentLevel)
            {
                case 1:
                    new MazeMap(_gameState).InitializeCaveMap();
                    break;
                case 2:
                    new MazeMap(_gameState).InitializeJungleMap();
                    break;
                case 3:
                    new MazeMap(_gameState).InitializeDesertMap();
                    break;
            }
        }
    }
}
