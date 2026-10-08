using Spectre.Console;

class Collision
{
    private Player? _player;
    public Player? PlayerC { get => _player; private set => _player = value; }

    private MapGrid? _map;
    public MapGrid? MapC { get => _map; private set => _map = value; }


    /// <summary>
    /// Creates a collision checker for the given player and map.
    /// </summary>
    /// <param name="player">The player whose position is checked.</param>
    /// <param name="map">The current map.</param>
    public Collision(Player player, MapGrid map)
    {
        PlayerC = player;
        MapC = map;
    }

    /// <summary>
    /// Runs every collision check for the player's current position.
    /// </summary>
    /// <param name="lever">The lever on the map.</param>
    /// <param name="treasure">The treasure on the map.</param>
    /// <param name="enemies">All enemies on the map. Destroyed ones are ignored by the enemy check.</param>
    /// <param name="pits">All pits on the map.</param>
    public void CheckCollision(Lever lever, Treasure treasure, Enemies[] enemies, Pit[] pits)
    {
        EntranceCollision(lever, treasure);
        LeverCollision(lever);
        TreasureCollision(treasure);
        foreach (Enemies enemy in enemies)
            EnemyCollision(enemy);
        foreach (Pit pit in pits)
            PitCollision(pit);
    }

    /// <summary>
    /// Handles the entrance tile: shows a message depending on whether the gate is open
    /// and whether the treasure was taken.
    /// </summary>
    /// <param name="lever">The lever that controls the entrance gate.</param>
    /// <param name="treasure">The treasure, used to pick the escape message.</param>
    public void EntranceCollision(Lever lever, Treasure treasure)
    {
        if (PlayerC?.Row == 0 && PlayerC.Column == 0 && !lever.IsEnabled)
        {
            AnsiConsole.MarkupLine("[gold3_1]You're at the entrance door of the dungeon." + 
            " You can see the light coming from outside but the gate is down preventing you from leaving the dungeon." + 
            " You must find a way to raise the gates again[/]");
        }
        else if (PlayerC?.Row == 0 && PlayerC.Column == 0 && lever.IsEnabled && treasure.IsTaken)
        {
            AnsiConsole.MarkupLine("[rapidblink gold1]You manage to find the treasure and escape from the dungeon alive! Congratulations![/]");
        }
        else if (PlayerC?.Row == 0 && PlayerC.Column == 0 && lever.IsEnabled)
        {
            AnsiConsole.MarkupLine("[bold gold1]You manage to escape from the dungeon alive even though you didn't manage to find the treasure! Congratulations![/]");
        }
    }

    /// <summary>
    /// Shows a hint when the player stands on the lever's tile, depending on whether it was already pulled.
    /// </summary>
    /// <param name="lever">The lever to check against the player's position.</param>
    public void LeverCollision(Lever lever)
    {
        if (PlayerC?.Row == lever.Row && PlayerC.Column == lever.Column)
        {
            if (!lever.IsEnabled)
            {
                AnsiConsole.MarkupLine("[rapidblink teal]You've found the lever, move it to open the entrance gate[/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[rapidblink steelblue1]The lever is moved, the entrance gate must be open now[/]");
            }
        }
    }

    /// <summary>
    /// Shows a message when the player stands on the treasure's tile, depending on whether it was already taken.
    /// </summary>
    /// <param name="treasure">The treasure to check against the player's position.</param>
    public void TreasureCollision(Treasure treasure)
    {
        if (PlayerC?.Row == treasure.Row && PlayerC.Column == treasure.Column)
        {
            if (!treasure.IsTaken)
            {
                AnsiConsole.MarkupLine("[rapidblink khaki1]You've found the treasure![/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[rapidblink darkkhaki]This is the place where you found the treasure.[/]");
            }
        }        
    }

    /// <summary>
    /// Warns the player when an enemy is in one of the eight surrounding tiles, and starts an
    /// encounter when the player is on the enemy's tile.
    /// </summary>
    /// <param name="enemy">The enemy to check against the player's position.</param>
    public void EnemyCollision(Enemies enemy)
    {
        if (MapC == null)
            return;

        if (PlayerC?.Row == enemy.Row && PlayerC?.Column - 1 == enemy.Column && !enemy.IsDestroyed ||
            PlayerC?.Row == enemy.Row && PlayerC?.Column + 1 == enemy.Column && !enemy.IsDestroyed ||
            PlayerC?.Row - 1 == enemy.Row && PlayerC?.Column == enemy.Column && !enemy.IsDestroyed ||
            PlayerC?.Row + 1 == enemy.Row && PlayerC?.Column == enemy.Column && !enemy.IsDestroyed ||
            PlayerC?.Row - 1 == enemy.Row && PlayerC?.Column - 1 == enemy.Column && !enemy.IsDestroyed ||
            PlayerC?.Row - 1 == enemy.Row && PlayerC?.Column + 1 == enemy.Column && !enemy.IsDestroyed ||
            PlayerC?.Row + 1 == enemy.Row && PlayerC?.Column - 1 == enemy.Column && !enemy.IsDestroyed ||
            PlayerC?.Row + 1 == enemy.Row && PlayerC?.Column + 1 == enemy.Column && !enemy.IsDestroyed
            )
        {
            AnsiConsole.MarkupLine("[rapidblink darkviolet_1]You feel the presence of an enemy in a nearby room. You need to be careful where you choose to go.[/]");
        }
        else if (PlayerC?.Row == enemy.Row && PlayerC?.Column == enemy.Column && !enemy.IsDestroyed)
        {
            enemy.EnemyEncounter(PlayerC, MapC);
        }
    }

    /// <summary>
    /// Warns the player when a pit is in one of the eight surrounding tiles, and defeats the player
    /// when they step onto the pit's tile.
    /// </summary>
    /// <param name="pit">The pit to check against the player's position.</param>
    public void PitCollision(Pit pit)
    {
        if (PlayerC?.Row == pit.Row && PlayerC?.Column - 1 == pit.Column ||
            PlayerC?.Row == pit.Row && PlayerC?.Column + 1 == pit.Column ||
            PlayerC?.Row - 1 == pit.Row && PlayerC?.Column == pit.Column ||
            PlayerC?.Row + 1 == pit.Row && PlayerC?.Column == pit.Column ||
            PlayerC?.Row - 1 == pit.Row && PlayerC?.Column - 1 == pit.Column ||
            PlayerC?.Row - 1 == pit.Row && PlayerC?.Column + 1 == pit.Column ||
            PlayerC?.Row + 1 == pit.Row && PlayerC?.Column - 1 == pit.Column ||
            PlayerC?.Row + 1 == pit.Row && PlayerC?.Column + 1 == pit.Column
            )
        {
            AnsiConsole.MarkupLine("[rapidblink lightsalmon3]You feel a draft. There is a pit in a nearby room.[/]");
        }
        else if (PlayerC?.Row == pit.Row && PlayerC.Column == pit.Column)
        {
            AnsiConsole.MarkupLine("[rapidblink lightsalmon1]You misstepped and fell into the bottomless pit[/]");
            PlayerC.Defeat();
        }
    }
}