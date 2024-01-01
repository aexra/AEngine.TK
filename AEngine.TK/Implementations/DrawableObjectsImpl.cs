using AEngine.TK.Core;
using AEngine.TK.Core.Drawing;
using AEngine.TK.Core.Engine;
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
    float cameraSpeed = 2f;
    Sprite sprite;

    public DrawableObjectsImpl(string windowTitle, int initialWindowWidth, int initialWindowHeight) : base(windowTitle, initialWindowWidth, initialWindowHeight)
    {
    }

    protected override void Initialize()
    {
        Camera.Init();
        Camera.Translate(new Vector3(0, 0, 2));
    }

    protected override void LoadContent()
    {
        Tree.Add(new Sprite());
    }

    protected override void Update()
    {
        if (!GameWindow.IsFocused)
        {
            return;
        }

        KeyboardState input = GameWindow.KeyboardState;
        Vector3 dir = new Vector3(0,0,0);

        if (input.IsKeyDown(Keys.W))
        {
            dir.X--;
        }

        if (input.IsKeyDown(Keys.S))
        {
            dir.X++;
        }

        if (input.IsKeyDown(Keys.A))
        {
            dir.Y--;
        }

        if (input.IsKeyDown(Keys.D))
        {
            dir.Y++;
        }

        if (input.IsKeyDown(Keys.Space))
        {
            dir.Z++;
        }

        if (input.IsKeyDown(Keys.LeftShift))
        {
            dir.Z--;
        }

        Camera.Translate(new Vector3(dir.Y * cameraSpeed * Time.deltaTime / 1000,
            dir.Z * (cameraSpeed / 2) * Time.deltaTime / 1000,
            dir.X * cameraSpeed * Time.deltaTime / 1000));

        Tree.Update();
    }

    protected override void Render()
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        GL.ClearColor(Color4.CornflowerBlue);

        Tree.Draw();
    }
}

