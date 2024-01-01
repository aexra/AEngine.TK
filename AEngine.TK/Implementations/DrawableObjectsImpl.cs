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
    float cameraSpeed = 2f;
    List<Sprite> sprites = new();

    public DrawableObjectsImpl(string windowTitle, int initialWindowWidth, int initialWindowHeight) : base(windowTitle, initialWindowWidth, initialWindowHeight)
    {
    }

    protected override void Initialize()
    {
        Camera.Init();
    }

    protected override void LoadContent()
    {
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());
        sprites.Add(new Sprite());

        Random rnd = new Random();
        foreach (var sprite in sprites)
        {
            sprite.transform.position = new System.Numerics.Vector3((float)rnd.NextDouble() * rnd.Next(-2, 2), (float)rnd.NextDouble() * rnd.Next(-2, 2), 0);
        }
    }

    protected override void Update(GameTime Time)
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

        foreach (var sprite in sprites)
        {
            sprite.Update();
        }
    }

    protected override void Render(GameTime gameTime)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        GL.ClearColor(Color4.CornflowerBlue);

        foreach (var sprite in sprites)
        {
            sprite.Draw();
        }
    }
}

