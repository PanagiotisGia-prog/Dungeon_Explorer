class Enemies
{
    private int _row;
    public int Row { get => _row; init => _row = value; }

    private int _column;
    public int Column { get => _column; init => _column = value; }

    private int _damage;
    public int Damage { get => _damage; init => _damage = value; }

    private bool _isDestroyed = false;
    public bool IsDestroyed { get => _isDestroyed; private set => _isDestroyed = value; }

    // <summary>
    /// Creates an enemy at the given map position.
    /// </summary>
    /// <param name="row">Row of the enemy on the map grid.</param>
    /// <param name="column">Column of the enemy on the map grid.</param>
    /// <param name="damage">Damage dealt to the player when they encounter this enemy.</param>
    public Enemies(int row, int column, int damage)
    {
        Row = row;
        Column = column;
        Damage = damage;
    }

    /// <summary>
    /// Marks the enemy as destroyed.
    /// </summary>
    /// <returns>Always <c>true</c>, matching the new value of <see cref="IsDestroyed"/>.</returns>
    public virtual bool EnemyDestroyed()
    {
        return _isDestroyed = true;
    }

    /// <summary>
    /// Defines what happens when the player encounters enemy. By default, the player takes
    /// damage equal to <see cref="Damage"/>.
    /// </summary>
    /// <param name="player">The player who encountered the enemy.</param>
    /// <param name="map">The current map. Unused here, but available to derived enemies that need it.</param>
    public virtual void EnemyEncounter(Player player, MapGrid map)
    {
        player.TakeDamage(Damage);
    }

}