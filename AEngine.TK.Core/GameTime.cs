namespace AEngine.TK.Core;

public class GameTime
{
    public TimeSpan TotalGameTime { get; set; }
    public TimeSpan DeltaTime { get; set; }

    public GameTime()
    {
        TotalGameTime = TimeSpan.Zero;
        DeltaTime = TimeSpan.Zero;
    }
    public GameTime(TimeSpan totalGameTime, TimeSpan deltaTime)
    {
        TotalGameTime = totalGameTime;
        DeltaTime = deltaTime;
    }
}
