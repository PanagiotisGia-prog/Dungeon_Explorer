using Spectre.Console;

class Lever
{
    private readonly string _leverSymbol = "[L]";
    public string LeverSymbol { get => _leverSymbol; }

    private int _row;
    public int Row { get => _row; init => _row = value; }

    private int _col;
    public int Column { get => _col; init => _col = value; }

    private bool _isEnabled = false;
    public bool IsEnabled { get => _isEnabled; private set => _isEnabled = value; }

    /// <summary>
    /// Creates a lever at the given map position.
    /// </summary>
    /// <param name="r">Row of the lever on the map grid.</param>
    /// <param name="c">Column of the lever on the map grid.</param>
    public Lever(int r, int c)
    {
        Row = r;
        Column = c;
    }

    /// <summary>
    /// Toggles the lever between on and off.
    /// </summary>
    /// <returns><c>true</c> if the lever is on after the toggle; <c>false</c> if it is off.</returns>
    public bool MoveLever()
    {
        if (IsEnabled == false)
        {
            AnsiConsole.MarkupLine("[slowblink gray63]You hear the door rumbling in the distance. The iron bars must be rising. You can leave the dungeon now![/]");
            IsEnabled = true;
        }
        else
        {
            AnsiConsole.MarkupLine("[slowblink gray63]You hear the door rumbling in the distance. The iron bars must be lowering.[/]");
            IsEnabled = false;
        }

        return IsEnabled;
    }
}