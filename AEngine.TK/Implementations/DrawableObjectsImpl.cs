using AEngine.TK.Core;
using AEngine.TK.Core.Drawing;
using AEngine.TK.Core.Rendering;
using AEngine.TK.Core.Rendering.Buffers;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System.Resources;

namespace AEngine.TK;

internal class DrawableObjectsImpl : Game
{
    Sprite sprite;
    

    public DrawableObjectsImpl(string windowTitle, int initialWindowWidth, int initialWindowHeight) : base(windowTitle, initialWindowWidth, initialWindowHeight)
    {
    }

    protected override void Initialize()
    {
        Camera.Init();
        Console.WriteLine(Camera.model);
        Console.WriteLine(Camera.view);
        Console.WriteLine(Camera.projection);
    }

    protected override void LoadContent()
    {
        sprite = new Sprite();
        sprite.transform.scale = new(0.3f, 0.3f, 0.0f);
    }

    protected override void Update(GameTime gameTime)
    {
        sprite.Update();
    }

    protected override void Render(GameTime gameTime)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        GL.ClearColor(Color4.CornflowerBlue);
        sprite.Draw();
    }
}

