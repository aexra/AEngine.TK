using AEngine.TK.Core.Management;
using AEngine.TK.Core.Utils;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System;

namespace AEngine.TK.Core;

public abstract class Game
{
    protected string WindowTitle { get; set; }
    protected int InitialWindowWidth { get; set; }
    protected int InitialWindowHeight { get; set; }
    protected GameWindow GameWindow { get; private set; }

    private GameWindowSettings _gameWindowSettings = GameWindowSettings.Default;
    private NativeWindowSettings _nativeWindowSettings = NativeWindowSettings.Default;

    public Game(string windowTitle, int initialWindowWidth, int initialWindowHeight)
    {
        WindowTitle = windowTitle;
        InitialWindowWidth = initialWindowWidth;
        InitialWindowHeight = initialWindowHeight;

        _nativeWindowSettings.ClientSize = new OpenTK.Mathematics.Vector2i(initialWindowWidth, initialWindowHeight);
        _nativeWindowSettings.Title = windowTitle;
        _nativeWindowSettings.API = ContextAPI.OpenGL;

        _gameWindowSettings.UpdateFrequency = 144.0;
    }

    public void Run()
    {
        Initialize();
        GameWindow = DisplayManager.Instance.CreateWindow(_gameWindowSettings, _nativeWindowSettings);
        GameTime gameTime = new();
        GameWindow.Load += LoadContent;
        GameWindow.UpdateFrame += (FrameEventArgs e) =>
        {
            double time = e.Time;
            gameTime.DeltaTime = TimeSpan.FromSeconds(time);
            gameTime.TotalGameTime += TimeSpan.FromSeconds(time);
            Update(gameTime);
        };
        GameWindow.RenderFrame += (FrameEventArgs e) =>
        {
            Render(gameTime);
            GameWindow.SwapBuffers();
        };
        GameWindow.Resize += (ResizeEventArgs e) => 
        {
            GL.Viewport(0, 0, GameWindow.ClientSize.X, GameWindow.ClientSize.Y);
        };
        GameWindow.MouseMove += Input.OnMouseMove;
        GameWindow.Run();
    }

    protected abstract void Initialize();
    protected abstract void LoadContent();
    protected abstract void Update(GameTime gameTime);
    protected abstract void Render(GameTime gameTime);
}