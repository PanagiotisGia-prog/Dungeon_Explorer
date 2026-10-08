using Spectre.Console;

class Game
{ 
    private static bool _quit = false;
    public static bool Quit { get => _quit; set => _quit = value; }

    private static MapGrid? _map;
    public static MapGrid? InitMap { get => _map; private set => _map = value; }

    private static Collision? _collision;
    public static Collision? InitCollision { get => _collision; private set => _collision = value; }

    private static Player? _player;
    public static Player? InitPlayer { get => _player; private set => _player = value; }

    private static Lever? _lever;
    public static Lever? InitLever { get => _lever; private set => _lever = value; }

    private static Treasure? _treasure;
    public static Treasure? InitTreasure { get => _treasure; private set => _treasure = value; }

    private static Enemies[]? _enemies;
    public static Enemies[]? InitEnemies { get => _enemies; private set => _enemies = value; }

    private static Pit[]? _pit;
    public static Pit[]? InitPit { get => _pit; private set => _pit = value; }

    /// <summary>
    /// Default constructor, kept explicitly for consistency with the other classes.
    /// </summary>
    public Game()
    {
        
    }

    /// <summary>
    /// Sets up a new game for the given difficulty and runs it until it ends.
    /// </summary>
    /// <param name="difficulty">The difficulty, which decides the map size and what is placed on it.</param>
    public static void Initialize(Difficulty difficulty)
    {
        bool hasWon = false;

        InitPlayer = new();

        Placement(difficulty);

        if (InitMap == null || InitPlayer == null || InitLever == null || InitEnemies == null || InitPit == null || InitTreasure == null)
            return;

        InitCollision = new(InitPlayer, InitMap);

        InitMap.DisplayMap(InitPlayer);
        
        while (!Quit && !hasWon && InitMap != null && !InitPlayer.IsDefeated)
        {
            var table = new Table();
            table.Border(TableBorder.Double);
            table.AddColumn("Y");
            table.AddColumn("X");
            table.AddColumn("HP");
            table.AddColumn("Arrows");
            table.AddRow($"{InitPlayer.Row}", $"{InitPlayer.Column}", $"{InitPlayer.Lives}", $"{Arrow.Arrows}");
            AnsiConsole.Write(table);

            Console.Write("Choose a direction: ");
            InitPlayer.ControlPlayer(InitMap, InitLever, InitTreasure, InitEnemies);
            if (Quit)
                break;
            InitCollision.CheckCollision(InitLever, InitTreasure, InitEnemies, InitPit);
            InitMap.DisplayMap(InitPlayer);
            hasWon = WinState(InitPlayer, InitLever);
        }
    }


    /// <summary>
    /// Creates the map, lever, treasure, enemies, and pits for the chosen difficulty.
    /// </summary>
    /// <param name="difficulty">The difficulty to build the level for.</param>
    public static void Placement(Difficulty difficulty)
    {
        if (difficulty == Difficulty.Easy)
        {
            InitMap = new(new string[4, 4]);
            InitLever = new(2, 2);
            InitEnemies = [new WindElemental(2, 1), new FireElemental(3, 3), new Dragon(0, 3)];
            InitPit = [new(1, 2)];
            InitTreasure = new(2, 3);
        }
        else if (difficulty == Difficulty.Normal)
        {
            InitMap = new(new string[6, 6]);
            InitLever = new(5, 3);
            InitEnemies = [new WindElemental(0, 3), new WindElemental(4, 1), new FireElemental(2, 4), new FireElemental(5, 5), new Dragon(3, 3)];
            InitPit = [new(2, 2), new(4, 4)];
            InitTreasure = new(3, 4);
        }
        else if (difficulty == Difficulty.Hard)
        {
            InitMap = new(new string[8, 8]);
            InitLever = new(5, 7);
            InitEnemies = [new WindElemental(4, 0), new WindElemental(3, 3), new WindElemental(5, 5), new WindElemental(0, 7), new FireElemental(7, 1), new FireElemental(0, 2), new FireElemental(3, 5), new FireElemental(6, 6), new Dragon(5, 2)];
            InitPit = [new(2, 0), new(6, 3), new(1, 5)];
            InitTreasure = new(7, 2);
        }
        else if (difficulty == Difficulty.Extreme)
        {
            InitMap = new(new string[10, 10]);
            InitLever = new(0, 9);
            InitEnemies = [new WindElemental(6, 0), new WindElemental(3, 2), new WindElemental(9, 3), new WindElemental(0, 5), new WindElemental(5, 6), new WindElemental(8, 7), new FireElemental(9, 0), new FireElemental(2, 1), new FireElemental(7, 3), new FireElemental(2, 7), new FireElemental(4, 8), new FireElemental(6, 9), new Dragon(7, 6), new Dragon(1, 9)];
            InitPit = [new(7, 1), new(0, 2), new(4, 4), new(8, 5), new(9, 8), new(5, 9)];
            InitTreasure = new(9, 5);
        }
        else if (difficulty == Difficulty.Ultimate)
        {
            InitMap = new(new string[12, 12]);
            InitLever = new(0, 11);
            InitEnemies = [new WindElemental(11, 0), new WindElemental(2, 1), new WindElemental(4, 3), new WindElemental(8, 5), new WindElemental(1, 6), new WindElemental(10, 7), new WindElemental(5, 8), new WindElemental(7, 9), new FireElemental(8, 1), new FireElemental(10, 2), new FireElemental(0, 3), new FireElemental(5, 5), new FireElemental(8, 8), new FireElemental(2, 9), new FireElemental(9, 10), new FireElemental(4, 11), new Dragon(4, 0), new Dragon(6, 4), new Dragon(3, 6)];
            InitPit = [new(7, 0), new(2, 3), new(4, 5), new(7, 7), new(0, 8), new(1, 10), new(11, 10), new(7, 11)];
            InitTreasure = new(11, 11);
        }
    }


    /// <summary>
    /// Checks whether the player has escaped the dungeon.
    /// </summary>
    /// <param name="player">The player whose position is checked.</param>
    /// <param name="lever">The lever that controls the exit gate.</param>
    /// <returns><c>true</c> if the player is on the entrance tile (0, 0) and the gate is open, otherwise <c>false</c>.</returns>
    public static bool WinState(Player player, Lever lever)
    {
        if (player.Row == 0 && player.Column == 0 && lever.IsEnabled)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}