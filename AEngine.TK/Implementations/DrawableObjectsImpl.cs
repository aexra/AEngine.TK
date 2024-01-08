using AEngine.TK.Core;
using AEngine.TK.Core.Config;
using AEngine.TK.Core.Drawing;
using AEngine.TK.Core.Engine;
using AEngine.TK.Core.Rendering;
using AEngine.TK.Core.Rendering.Buffers;
using AEngine.TK.Core.Utils;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Reflection;
using System.Resources;

namespace AEngine.TK;

internal class DrawableObjectsImpl : Game
{
    float cameraSpeed = 2f;
    Rectangle rect;

    public DrawableObjectsImpl(string windowTitle, int initialWindowWidth, int initialWindowHeight) : base(windowTitle, initialWindowWidth, initialWindowHeight)
    {
    }

    protected override void Initialize()
    {
        Camera.Init();
        Camera.position.Z += 1.3f;
    }

    protected override void LoadContent()
    {
        rect = new Rectangle(Color4.Cyan);

        Shader shader = new Shader("Resources/Shaders/testRectShader.glsl");
        shader.CompileShader();

        shader.ApplyUniforms += () =>
        {
            shader.SetVector2("aWindowSize", SessionConfig.WindowSize);
            shader.SetVector3("mousePos", new Vector3(Input.MousePosition.X, Input.MousePosition.Y, 0f));
        };

        rect.SetShader(shader);

        Tree.Add(rect);
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

