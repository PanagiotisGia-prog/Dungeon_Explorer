using Spectre.Console;

class MainMenu
{
    /*
    ▐▓▓▓▓▌ ▐▓▌▐▓▌▐▓▌ ▐▓▌▐▓▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▌▐▓▌ ▐▓▌    ▐▓▓▓▓▌▐▓▌ ▐▓▌▐▓▓▓▓▌▐▓▌   ▐▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▌
    ▐▓▌ ▐▓▌▐▓▌▐▓▌▐▓▓▌▐▓▌▐▓▌    ▐▓▌   ▐▓▌▐▓▌▐▓▓▌▐▓▌    ▐▓▌    ▐▓▐▓▌ ▐▓▌▐▓▌▐▓▌   ▐▓▌▐▓▌▐▓▌▐▓▌▐▓▌   ▐▓▌▐▓▌
    ▐▓▌ ▐▓▌▐▓▌▐▓▌▐▓▐▓▐▓▌▐▓▌▐▓▓▌▐▓▓▓▌ ▐▓▌▐▓▌▐▓▐▓▐▓▌    ▐▓▓▓▌   ▐▓▌  ▐▓▓▓▓▌▐▓▌   ▐▓▌▐▓▌▐▓▓▓▓▌▐▓▓▓▌ ▐▓▓▓▓▌
    ▐▓▌ ▐▓▌▐▓▌▐▓▌▐▓▌▐▓▓▌▐▓▌ ▐▓▌▐▓▌   ▐▓▌▐▓▌▐▓▌▐▓▓▌    ▐▓▌    ▐▓▐▓▌ ▐▓▌   ▐▓▌   ▐▓▌▐▓▌▐▓▐▓▌ ▐▓▌   ▐▓▐▓▌ 
    ▐▓▓▓▓▌ ▐▓▓▓▓▌▐▓▌ ▐▓▌▐▓▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▌▐▓▌ ▐▓▌    ▐▓▓▓▓▌▐▓▌ ▐▓▌▐▓▌   ▐▓▓▓▓▌▐▓▓▓▓▌▐▓▌▐▓▌▐▓▓▓▓▌▐▓▌▐▓▌
    */
    
    /// <summary>
    /// Default constructor, kept explicitly for consistency with the other classes.
    /// </summary>
    public MainMenu()
    {
        
    }
        
    /// <summary>
    /// Prints the "Dungeon Explorer" title banner and waits for the user to press a key to continue.
    /// </summary>
    public static void DisplayTitle()
    {
        AnsiConsole.MarkupLine("[DarkSeaGreen1]▐▓▓▓▓▌ ▐▓▌▐▓▌▐▓▌ ▐▓▌▐▓▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▌▐▓▌ ▐▓▌    ▐▓▓▓▓▌▐▓▌ ▐▓▌▐▓▓▓▓▌▐▓▌   ▐▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▌[/]");
        AnsiConsole.MarkupLine("[DarkSeaGreen2_1]▐▓▌ ▐▓▌▐▓▌▐▓▌▐▓▓▌▐▓▌▐▓▌    ▐▓▌   ▐▓▌▐▓▌▐▓▓▌▐▓▌    ▐▓▌    ▐▓▐▓▌ ▐▓▌▐▓▌▐▓▌   ▐▓▌▐▓▌▐▓▌▐▓▌▐▓▌   ▐▓▌▐▓▌[/]");
        AnsiConsole.MarkupLine("[DarkSeaGreen3]▐▓▌ ▐▓▌▐▓▌▐▓▌▐▓▐▓▐▓▌▐▓▌▐▓▓▌▐▓▓▓▌ ▐▓▌▐▓▌▐▓▐▓▐▓▌    ▐▓▓▓▌   ▐▓▌  ▐▓▓▓▓▌▐▓▌   ▐▓▌▐▓▌▐▓▓▓▓▌▐▓▓▓▌ ▐▓▓▓▓▌[/]");
        AnsiConsole.MarkupLine("[DarkSeaGreen2]▐▓▌ ▐▓▌▐▓▌▐▓▌▐▓▌▐▓▓▌▐▓▌ ▐▓▌▐▓▌   ▐▓▌▐▓▌▐▓▌▐▓▓▌    ▐▓▌    ▐▓▐▓▌ ▐▓▌   ▐▓▌   ▐▓▌▐▓▌▐▓▐▓▌ ▐▓▌   ▐▓▐▓▌ [/]");
        AnsiConsole.MarkupLine("[DarkSeaGreen]▐▓▓▓▓▌ ▐▓▓▓▓▌▐▓▌ ▐▓▌▐▓▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▌▐▓▌ ▐▓▌    ▐▓▓▓▓▌▐▓▌ ▐▓▌▐▓▌   ▐▓▓▓▓▌▐▓▓▓▓▌▐▓▌▐▓▌▐▓▓▓▓▌▐▓▌▐▓▌[/]");
        Console.WriteLine("\n");
        Console.WriteLine("Press any key to continue!");
        Console.ReadKey(true);
    }
}