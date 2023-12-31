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

    }

    protected override void LoadContent()
    {
        sprite = new Sprite();
    }

    protected override void Update(GameTime gameTime)
    {

    }

    protected override void Render(GameTime gameTime)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.ClearColor(Color4.CornflowerBlue);
        sprite.Render();
    }
}

