using AEngine.TK.Core;
using AEngine.TK.Core.Drawing;
using AEngine.TK.Core.Rendering;
using AEngine.TK.Core.Rendering.Buffers;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Resources;

namespace AEngine.TK;

internal class DrawableObjectsImpl : Game
{
    Sprite sprite;
    float speed = 1.5f;

    public DrawableObjectsImpl(string windowTitle, int initialWindowWidth, int initialWindowHeight) : base(windowTitle, initialWindowWidth, initialWindowHeight)
    {
    }

    protected override void Initialize()
    {
        Camera.Init();
    }

    protected override void LoadContent()
    {
        sprite = new Sprite();
        sprite.transform.scale = new(0.3f, 0.3f, 0.0f);
    }

    protected override void Update(GameTime gameTime)
    {
        if (!GameWindow.IsFocused)
        {
            return;
        }

        KeyboardState input = GameWindow.KeyboardState;
        Vector3 resultDir = Vector3.Zero;

        if (input.IsKeyDown(Keys.W))
        {
            resultDir.X = 1;
        }

        if (input.IsKeyDown(Keys.S))
        {
            resultDir.X = -1;
        }

        if (input.IsKeyDown(Keys.A))
        {
            resultDir.Y = -1;
        }

        if (input.IsKeyDown(Keys.D))
        {
            resultDir.Y = 1;
        }

        if (input.IsKeyDown(Keys.Space))
        {
            resultDir.Z = 1;
        }

        if (input.IsKeyDown(Keys.LeftShift))
        {
            resultDir.Z = -1;
        }

        Camera.Translate(resultDir, speed / 10);


        sprite.Update();
    }

    protected override void Render(GameTime gameTime)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        GL.ClearColor(Color4.CornflowerBlue);
        sprite.Draw();
    }
}

