using Spectre.Console;
#pragma warning disable IDE0290
class WindElemental : Enemies
{
    /// <summary>
    /// Creates a wind elemental at the given map position.
    /// </summary>
    /// <param name="row">Row of the enemy on the map grid.</param>
    /// <param name="col">Column of the enemy on the map grid.</param>
    public WindElemental(int row, int col) : base(row, col, 1)
    {
        
    }

    /// <summary>
    /// Plays the wind elemental encounter: the player takes damage, is pushed to a new tile,
    /// and the elemental is destroyed.
    /// </summary>
    /// <param name="player">The player who encountered the elemental.</param>
    /// <param name="map">The current map, used to validate the player's repositioning.</param>
    public override void EnemyEncounter(Player player, MapGrid map)
    {
        AnsiConsole.MarkupLine("[bold darkcyan]You have encountered a wind elemental[/]");
        AnsiConsole.MarkupLine("[bold darkturquoise]The elemental starts whirling you around when suddenly explodes releasing a strong wind wave that sends you flying in the dungeon.[/]");
        base.EnemyEncounter(player, map);
        player.Reposition(map);
        EnemyDestroyed();
    }
}