using Spectre.Console;
#pragma warning disable IDE0290
class FireElemental : Enemies
{
    /// <summary>
    /// Creates a fire elemental at the given map position.
    /// </summary>
    /// <param name="row">Row of the enemy on the map grid.</param>
    /// <param name="col">Column of the enemy on the map grid.</param>
    public FireElemental(int row, int col) : base(row, col, 3)
    {
        
    }

    /// <summary>
    /// Plays the fire elemental encounter: the player takes damage and the elemental is destroyed.
    /// </summary>
    /// <param name="player">The player who encountered the elemental.</param>
    /// <param name="map">The current map. Passed to the base method but not used by this enemy.</param>
    public override void EnemyEncounter(Player player, MapGrid map)
    {
        AnsiConsole.MarkupLine("[bold darkorange]You have encountered a fire elemental[/]");
        AnsiConsole.MarkupLine("[bold darkorange3]The fire elemental explodes releasing flames that burn the whole room[/]");
        base.EnemyEncounter(player, map);
        EnemyDestroyed();
    }
}