using AEngine.TK.Core;

namespace AEngine.TK;

public class Program
{
    public static void Main(string[] args)
    {
        Game game = new TestGame("Test", 800, 600);
        game.Run();
    }
}