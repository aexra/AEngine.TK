using AEngine.TK.Core;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace AEngine.TK;

internal class TestGame : Game
{
    public TestGame(string windowTitle, int initialWindowWidth, int initialWindowHeight) : base(windowTitle, initialWindowWidth, initialWindowHeight)
    {
    }

    protected override void Initialize()
    {
        
    }

    protected override void LoadContent()
    {
        
    }

    protected override void Update(GameTime gameTime)
    {
        
    }

    protected override void Render(GameTime gameTime)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.ClearColor(Color4.CornflowerBlue);
    }
}

