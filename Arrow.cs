class Arrow
{
    private static int _arrows = 3;
    public static int Arrows { get => _arrows; private set => _arrows = value; }

    /// <summary>
    /// Default constructor, kept explicitly for consistency with the other classes.
    /// </summary>
    public Arrow()
    {
        
    }

    /// <summary>
    /// Uses up one arrow.
    /// </summary>
    /// <returns>The number of arrows the player had <b>before</b> this shot.</returns>
    public static int ReleaseArrow()
    {
        return Arrows--;
    }
}