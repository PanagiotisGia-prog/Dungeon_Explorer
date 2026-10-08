using Spectre.Console;

class Player : Entity
{
    private readonly string _playerCharacterSymbol = "[C]";
    public string PlayerCharacterSymbol { get => _playerCharacterSymbol; }

    /// <summary>
    /// Creates the player at the top-left corner of the map (0, 0) with 6 lives.
    /// </summary>
    public Player() : base(0, 0, 6)
    {
        
    }
    
    /// <summary>
    /// Reads one command from the console and performs the matching action for the player.
    /// </summary>
    /// <param name="map">The map used to validate movement.</param>
    /// <param name="lever">The lever the player can pull when standing on its tile.</param>
    /// <param name="treasure">The treasure the player can pick up when standing on its tile.</param>
    /// <param name="enemies">All enemies on the map, used to check whether an arrow hits anything.</param>
    public void ControlPlayer(MapGrid map, Lever lever, Treasure treasure, Enemies[] enemies)
    {
        string command = (Console.ReadLine() ?? string.Empty).ToLower().Trim();

        switch (command)
        {
            case "go up":
            case "up":
                MoveUp(map);
            break;

            case "go down":
            case "down":
                MoveDown(map);
            break;

            case "go left":
            case "left":
                MoveLeft(map);
            break;

            case "go right":
            case "right":
                MoveRight(map);
            break;

            case "move lever":
            case "lever":
                if (Row == lever.Row && Column == lever.Column)
                    lever.MoveLever();
                else
                    Console.WriteLine("There is no lever around you.");
            break;

            case "take treasure":
            case "treasure":
                if (Row == treasure.Row && Column == treasure.Column && !treasure.IsTaken)
                    treasure.TakeTreasure();
                else if (treasure.IsTaken)
                    Console.WriteLine("You've already took the treasure.");
                else
                    Console.WriteLine("You need to find the treasure first.");
            break;

            case "shoot up":
            case "arrow up":
                if (Arrow.Arrows <= 0)
                {
                    AnsiConsole.MarkupLine("[rapidblink darkred_1]You're out of arrows![/]");
                }
                else
                {
                    Console.WriteLine("You shot an arrow hoping to find it's target.");
                    Arrow.ReleaseArrow();

                    foreach (Enemies enemy in enemies)
                    {
                        if (Row > enemy.Row && Column == enemy.Column && !enemy.IsDestroyed)
                        {
                            AnsiConsole.MarkupLine("[slowblink lime]You hear a distant growling! Looks like you manage to hit something.[/]");
                            enemy.EnemyDestroyed();
                            return;
                        }
                    }
                }
            break;

            case "shoot down":
            case "arrow down":
                if (Arrow.Arrows <= 0)
                {
                    AnsiConsole.MarkupLine("[rapidblink darkred_1]You're out of arrows![/]");
                }
                else
                {
                    Console.WriteLine("You shot an arrow hoping to find it's target.");
                    Arrow.ReleaseArrow();

                    foreach (Enemies enemy in enemies)
                    {                    
                        if (Row < enemy.Row && Column == enemy.Column && !enemy.IsDestroyed)
                        {
                            AnsiConsole.MarkupLine("[slowblink lime]You hear a distant growling! Looks like you manage to hit something.[/]");
                            enemy.EnemyDestroyed();
                            return;
                        }
                    }
                }
            break;

            case "shoot left":
            case "arrow left":
                if (Arrow.Arrows <= 0)
                {
                    AnsiConsole.MarkupLine("[rapidblink darkred_1]You're out of arrows![/]");
                }
                else
                {
                    Console.WriteLine("You shot an arrow hoping to find it's target.");
                    Arrow.ReleaseArrow();

                    foreach (Enemies enemy in enemies)
                    {
                        if (Row == enemy.Row && Column > enemy.Column && !enemy.IsDestroyed)
                        {
                            AnsiConsole.MarkupLine("[slowblink lime]You hear a distant growling! Looks like you manage to hit something.[/]");
                            enemy.EnemyDestroyed();
                            return;
                        }
                    }
                }
            break;

            case "shoot right":
            case "arrow right":
                if (Arrow.Arrows <= 0)
                {
                    AnsiConsole.MarkupLine("[rapidblink darkred_1]You're out of arrows![/]");
                }
                else
                {
                    Console.WriteLine("You shot an arrow hoping to find it's target.");
                    Arrow.ReleaseArrow();

                    foreach (Enemies enemy in enemies)
                    {
                        if (Row == enemy.Row && Column < enemy.Column && !enemy.IsDestroyed)
                        {
                            AnsiConsole.MarkupLine("[slowblink lime]You hear a distant growling! Looks like you manage to hit something.[/]");
                            enemy.EnemyDestroyed();
                            return;
                        }
                    }
                }
            break;

            case "quit game":
            case "quit":
                Game.Quit = true;
            break;

            case "help":
                Guide.CommandsGuide();
            break;
            
            default:
                Console.WriteLine("Invalid direction!");
            break;
        }
    }


    /// <summary>
    /// Shows a message telling the player how much health was lost, then applies the damage.
    /// </summary>
    /// <param name="damage">The amount of damage to subtract from the player's lives.</param>
    /// <returns>The player's remaining lives after the damage is applied.</returns>
    public override int TakeDamage(int damage)
    {

        AnsiConsole.MarkupLine($"[red]You've lost {damage} hp.[/]");

        return base.TakeDamage(damage);
    }

    /// <summary>
    /// Shows the defeat message and marks the player as defeated.
    /// </summary>
    /// <returns>Always <c>true</c>, matching the new value of <see cref="Entity.IsDefeated"/>.</returns>
    public override bool Defeat()
    {
        AnsiConsole.MarkupLine("[red3]You've been defeated![/]");
        return base.Defeat();
    }
}