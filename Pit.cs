class Pit
{
    private int _row;
    public int Row { get => _row; init => _row = value; }

    private int _col;
    public int Column { get => _col; init => _col = value; }

    /// <summary>
    /// Creates a pit at the given map position.
    /// </summary>
    /// <param name="row">Row of the pit on the map grid.</param>
    /// <param name="column">Column of the pit on the map grid.</param>
    public Pit(int row, int column)
    {
        Row = row;
        Column = column;
    }
}