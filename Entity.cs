class Entity
{
    private int _row;
    public int Row { get => _row; private set => _row = value; }

    private int _column;
    public int Column { get => _column; private set => _column = value; }

    private int _lives;
    public int Lives { get => _lives; private set => _lives = value; }


    private bool _canMove;
    public bool CanMove { get => _canMove; private set => _canMove = value; }

    private bool _isDefeated = false;
    public bool IsDefeated { get => _isDefeated; private set => _isDefeated = value; }


    /// <summary>
    /// Creates a new entity at the given map position with its starting stats.
    /// </summary>
    /// <param name="row">Starting row on the map grid.</param>
    /// <param name="column">Starting column on the map grid.</param>
    /// <param name="hp">Starting number of lives. Defaults to 0.</param>
    public Entity(int row, int column, int hp = 0)
    {
        Row = row;
        Column = column;
        Lives = hp;
    }

    /// <summary>
    /// Tries to move the entity one tile up (row - 1).
    /// </summary>
    /// <param name="map">The map used to validate the destination tile.</param>
    /// <returns>The entity's row after the attempt. It is unchanged if the move was blocked.</returns>
    public int MoveUp(MapGrid map)
    {
        int currentRow = Row;

        Row -= 1;

        CanMove = map.CheckBorders(Row, Column);

        if (!CanMove)
        {
            Row = currentRow;
        }

        return Row;
    }

    /// <summary>
    /// Tries to move the entity one tile down (row + 1).
    /// </summary>
    /// <param name="map">The map used to validate the destination tile.</param>
    /// <returns>The entity's row after the attempt. It is unchanged if the move was blocked.</returns>
    public int MoveDown(MapGrid map)
    {
        int currentRow = Row;

        Row += 1;

        CanMove = map.CheckBorders(Row, Column);

        if (!CanMove)
        {
            Row = currentRow;
        }

        return Row;        
    }

    /// <summary>
    /// Tries to move the entity one tile left (column - 1).
    /// </summary>
    /// <param name="map">The map used to validate the destination tile.</param>
    /// <returns>The entity's column after the attempt. It is unchanged if the move was blocked.</returns>
    public int MoveLeft(MapGrid map)
    {
        int currentColumn = Column;

        Column -= 1;

        CanMove = map.CheckBorders(Row, Column);

        if (!CanMove)
        {
            Column = currentColumn;
        }

        return Column;
    }

    /// <summary>
    /// Tries to move the entity one tile right (column + 1).
    /// </summary>
    /// <param name="map">The map used to validate the destination tile.</param>
    /// <returns>The entity's column after the attempt. It is unchanged if the move was blocked.</returns>
    public int MoveRight(MapGrid map)
    {
        int currentColumn = Column;

        Column += 1;

        CanMove = map.CheckBorders(Row, Column);

        if (!CanMove)
        {
            Column = currentColumn;
        }

        return Column;
    }

    /// <summary>
    /// Reduces the entity's lives by the given amount. If lives hit 0 the entity gets defeated.
    /// </summary>
    /// <param name="damage">The amount of damage to subtract from <see cref="Lives"/>.</param>
    /// <returns>The remaining lives after the damage is applied. This can be zero or negative.</returns>
    public virtual int TakeDamage(int damage)
    {
        Lives -= damage;

        if (Lives <= 0)
            Defeat();

        return Lives;
    }

    /// <summary>
    /// Moves the entity one tile up and two tiles right from its current position.
    /// </summary>
    /// <param name="map">The map used to validate each individual step.</param>
    public virtual void Reposition(MapGrid map)
    {
        MoveUp(map);
        MoveRight(map);
        MoveRight(map);
    }

    /// <summary>
    /// Marks the entity as defeated.
    /// </summary>
    /// <returns>Always <c>true</c>, matching the new value of <see cref="IsDefeated"/>.</returns>
    public virtual bool Defeat()
    {
        return IsDefeated = true;
    }
}