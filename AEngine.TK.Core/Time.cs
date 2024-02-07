namespace AEngine.TK.Core;

public class Time
{
    /// <summary>
    /// Total game time in TimeSpan
    /// </summary>
    public static TimeSpan TotalGameTime { get; set; } = TimeSpan.Zero;

    /// <summary>
    /// Time between two last frames in TimeSpan
    /// </summary>
    public static TimeSpan DeltaTime { get; set; } = TimeSpan.Zero;

    /// <summary>
    /// Time between two last frames in milliseconds
    /// </summary>
    public static int deltaTime
    {
        get
        {
            return DeltaTime.Milliseconds;
        }
    }
}
