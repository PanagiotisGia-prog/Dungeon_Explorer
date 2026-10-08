using Spectre.Console;

class Treasure
{
    private int _row;
    public int Row { get => _row; init => _row = value; }
    private int _col;
    public int Column { get => _col; init => _col = value; }
    private bool _isTaken = false;
    public bool IsTaken { get => _isTaken; private set => _isTaken = value; }

    /// <summary>
    /// Creates a treasure at the given map position.
    /// </summary>
    /// <param name="row">Row of the treasure on the map grid.</param>
    /// <param name="column">Column of the treasure on the map grid.</param>
    public Treasure(int row, int column)
    {
        Row = row;
        Column = column;
    }

    /// <summary>
    /// Marks the treasure as taken.
    /// </summary>
    /// <returns>Always <c>true</c>, matching the new value of <see cref="IsTaken"/>.</returns>
    public bool TakeTreasure()
    {
        AnsiConsole.MarkupLine("[rapidblink yellow1]You took the treasure, now it's time to leave this dungeon.[/]");
        return IsTaken = true;
    }
}