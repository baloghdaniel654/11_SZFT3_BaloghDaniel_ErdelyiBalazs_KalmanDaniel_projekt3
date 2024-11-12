namespace maze_quest_LIB
{
    public class GameState
    {
        public int PlayerX { get; set; } = 10;
        public int PlayerY { get; set; } = 10;
        public int PlayerHealth { get; set; } = 10;
        public int TalismanCount { get; set; } = 0;
        public int CurrentLevel { get; set; } = 1;
        public char[,] Map { get; set; }
        public ConsoleColor PlayerColor { get; set; } = ConsoleColor.Blue;
        public ConsoleColor EnemyColor { get; set; } = ConsoleColor.Red;
        public ConsoleColor HealthColor { get; set; } = ConsoleColor.Green;
        public int[] EnemyX { get; set; }
        public int[] EnemyY { get; set; }
    }
}
