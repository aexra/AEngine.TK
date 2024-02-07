using AEngine.TK.Core;
using AEngine.TK.Core.Config;
using AEngine.TK.Core.Drawing;
using AEngine.TK.Core.Engine;
using AEngine.TK.Core.Rendering;
using AEngine.TK.Core.Rendering.Buffers;
using AEngine.TK.Core.Utils;
using Microsoft.VisualBasic;
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
    private int interval = 50;
    private int timer = 0;
    private Particle p;

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
        p = new Particle(Color4.Black);
        p.ScaleTo(0.01f, 0.01f, 1f);
        Tree.Add(p);
    }

    protected override void Update()
    {
        if (!GameWindow.IsFocused)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0;
            if (p.Visible)
            {
                p.Hide();
            } else
            {
                p.Show();
            }
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

