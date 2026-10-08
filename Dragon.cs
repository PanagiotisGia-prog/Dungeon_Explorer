using Spectre.Console;
#pragma warning disable IDE0290
class Dragon : Enemies
{
    /// <summary>
    /// Creates a dragon at the given map position.
    /// </summary>
    /// <param name="row">Row of the enemy on the map grid.</param>
    /// <param name="col">Column of the enemy on the map grid.</param>
    /// <remarks>
    /// Its damage is fixed at 6, which matches the player's starting lives,
    /// so walking into it is fatal unless the dragon is shot first.
    /// </remarks>
    public Dragon(int row, int col) : base(row, col, 6)
    {
        
    }

    /// <summary>
    /// Plays the dragon encounter: the player is burned for 6 damage.
    /// </summary>
    /// <param name="player">The player who encountered the dragon.</param>
    /// <param name="map">The current map. Passed to the base method but not used by this enemy.</param>
    public override void EnemyEncounter(Player player, MapGrid map)
    {
        AnsiConsole.MarkupLine("[bold red1]You have encountered a dragon[/]");
        AnsiConsole.MarkupLine("[bold red3_1]The dragon stands tall before you and starts breathing fire incinerating you instantly[/]");
        base.EnemyEncounter(player, map);
    }
}