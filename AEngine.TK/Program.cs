using AEngine.TK.Core;

namespace AEngine.TK;

public class Program
{
    public static void Main(string[] args)
    {
        Game game = new DrawableObjectsImpl("Test", 1200, 700);
        game.Run();
    }
}