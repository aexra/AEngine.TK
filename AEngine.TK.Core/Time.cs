namespace AEngine.TK.Core;

public class Time
{
    public static TimeSpan TotalGameTime { get; set; } = TimeSpan.Zero;
    public static TimeSpan DeltaTime { get; set; } = TimeSpan.Zero;
    public static int deltaTime
    {
        get
        {
            return DeltaTime.Milliseconds;
        }
    }
}
