using Spectre.Console;

class Guide
{
    /// <summary>
    /// Default constructor, kept explicitly for consistency with the other classes.
    /// </summary>
    public Guide()
    {
        
    }

    /// <summary>
    /// Prints the welcome screen: the objectives, the dangers in the dungeon, and the commands table,
    /// then waits for a key press.
    /// </summary>
    public static void Instructions()
    {
        Console.WriteLine("Welcome to dungeon explorer!\nA terminal game where you explore the dungeon trying to find its treasures.");
        Console.WriteLine();
        Console.WriteLine("When you enter in a dungeon the gate behind you closes trapping you inside. Your objectives are:\n- Find the lever to raise the gate\n- Find the treasure\n- Escape from the dungeon");
        Console.WriteLine();
        AnsiConsole.MarkupLine("But beware inside the dungeons there are enemies and traps who can hurt you these are:\n- [DarkSlateGray3]Wind Elementals[/] (deals damage and sends you to another room)\n- [DarkOrange]Fire Elementals[/] (deals damage)\n- [DarkRed_1]Dragons[/] (instant defeat)\n- [Gray63]Pits[/] (instant defeat)");
        Console.WriteLine("If you encounter an elemental, you will take damage and the elemental will be destroyed.\nYou can use your arrows to shoot to any direction you think there is an enemy but beware the arrows are limited, so use them wisely.");
        Console.WriteLine();
        AnsiConsole.MarkupLine("[bold underline]HOW TO PLAY[/]");
        CommandsGuide();
        Console.WriteLine("");
        Console.WriteLine("You can press 'help' to see the commands during your game!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }

    /// <summary>
    /// Prints a table of every command the player can type, grouped into movement, actions, and attack.
    /// </summary>
    public static void CommandsGuide()
    {
        var commandsTable = new Table();
        commandsTable.Border(TableBorder.Rounded);
        commandsTable.AddColumn("Movement");
        commandsTable.AddColumn("Actions");
        commandsTable.AddColumn("Attack");
        commandsTable.AddRow("go up/up\ngo down/down\ngo left/left\ngo right/right", "move lever/lever\ntake treasure/treasure", "shoot up/arrow up\nshoot down/arrow down\nshoot left/arrow left\nshoot right/arrow right");
        AnsiConsole.Write(commandsTable);        
    }
}