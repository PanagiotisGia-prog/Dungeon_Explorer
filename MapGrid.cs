class MapGrid
{
    private string[,]? _grid;
    public string[,]? Grid { get => _grid; set => _grid = value; }

    private readonly int _firstTile = 0;
    public int FirstTile { get => _firstTile; }

    private int _lastRowTile;
    public int LastRowTile { get => _lastRowTile; init => _lastRowTile = value; }

    private int _lastColTile;
    public int LastColTile { get => _lastColTile; init => _lastColTile = value; }

    /// <summary>
    /// Creates a map from an existing grid and records its size.
    /// </summary>
    /// <param name="grid">The two-dimensional array used as the map. Its dimensions define the map size.</param>
    public MapGrid(string[,] grid)
    {
        Grid = grid;
        LastRowTile = Grid.GetLength(0);
        LastColTile = Grid.GetLength(1);
    }

    /// <summary>
    /// Rebuilds the grid so every tile is empty, except the player's tile, which shows the player symbol.
    /// </summary>
    /// <param name="player">The player whose position and symbol are drawn.</param>
    /// <returns>The updated grid, or <c>null</c> if the map has no grid.</returns>
    public string[,]? CreateMap(Player player)
    {
        for(int i = 0; i < Grid?.GetLength(0); i++)
        {
            for(int j = 0; j < Grid?.GetLength(1); j++)
            {
                if (player.Row == i && player.Column == j && !player.IsDefeated)
                {
                    Grid[i, j] = player.PlayerCharacterSymbol;
                }
                else
                {
                    Grid[i, j] = "[ ]";
                }
            }
        }

        return Grid;
    }


    /// <summary>
    /// Refreshes the map for the player's current position and prints it to the console, one row per line.
    /// </summary>
    /// <param name="player">The player to draw on the map.</param>
    public void DisplayMap(Player player)
    {
        CreateMap(player);

        if (Grid == null)
            return;

        int row = Grid.GetLength(0);
        int col = Grid.GetLength(1);

        for(int i = 0; i < row; i++)
        {
            for(int j = 0; j < col; j++)
            {
                Console.Write($"{Grid[i, j]}");
            }
            Console.WriteLine("");
        }
    }

    /// <summary>
    /// Checks whether a position is inside the map.
    /// </summary>
    /// <param name="currentRow">The row to check.</param>
    /// <param name="currentCol">The column to check.</param>
    public bool CheckBorders(int currentRow, int currentCol)
    {
        if(currentRow < FirstTile || currentCol < FirstTile || currentRow > LastRowTile - 1 || currentCol > LastColTile - 1)
        {
            Console.WriteLine("It appears there is a wall in front of you!");
            return false;
        }
        else
        {
            return true;
        }
    }
}