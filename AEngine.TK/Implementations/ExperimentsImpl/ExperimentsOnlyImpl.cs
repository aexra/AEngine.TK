using AEngine.TK.Core;
using AEngine.TK.Core.Config;
using AEngine.TK.Core.Drawing;
using AEngine.TK.Core.Engine;
using AEngine.TK.Core.Rendering;
using AEngine.TK.Core.Rendering.Buffers;
using AEngine.TK.Core.Utils;
using AEngine.TK.Implementations.ExperimentsImpl;
using OpenTK.Graphics.GL;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Reflection;
using System.Resources;

namespace AEngine.TK;

internal class ExperimentsOnlyImpl : Game
{
    float cameraSpeed = 2f;

    public ExperimentsOnlyImpl(string windowTitle, int initialWindowWidth, int initialWindowHeight) : base(windowTitle, initialWindowWidth, initialWindowHeight)
    {
    }

    protected override void Initialize()
    {
        Camera.position.Z += 1.3f;
        Camera.Init();
    }

    protected override void LoadContent()
    {
        Particle p = new Particle(Color4.Black);
        
        Tree.Add(p);
    }

    protected override void Update()
    {
        if (!GameWindow.IsFocused)
        {
            return;
        }

        Tree.Update();
    }

    protected override void Render()
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        GL.ClearColor(Color4.CornflowerBlue);

        Tree.Draw();
    }
}

