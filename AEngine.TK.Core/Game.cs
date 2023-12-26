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

    private GameWindowSettings _gameWindowSettings = GameWindowSettings.Default;
    private NativeWindowSettings _nativeWindowSettings = NativeWindowSettings.Default;

    public Game(string windowTitle, int initialWindowWidth, int initialWindowHeight)
    {
        WindowTitle = windowTitle;
        InitialWindowWidth = initialWindowWidth;
        InitialWindowHeight = initialWindowHeight;

        _nativeWindowSettings.ClientSize = new OpenTK.Mathematics.Vector2i(initialWindowWidth, initialWindowHeight);
    }

    public void Run()
    {
        Initialize();
        using GameWindow gameWindow = new GameWindow(_gameWindowSettings, _nativeWindowSettings);
        GameTime gameTime = new();
        gameWindow.Load += LoadContent;
        gameWindow.UpdateFrame += (FrameEventArgs e) =>
        {
            double time = e.Time;
            gameTime.DeltaTime = TimeSpan.FromSeconds(time);
            gameTime.TotalGameTime += TimeSpan.FromSeconds(time);
            Update(gameTime);
        };
        gameWindow.RenderFrame += (FrameEventArgs e) =>
        {
            Render(gameTime);
            gameWindow.SwapBuffers();
        };
        gameWindow.Resize += (ResizeEventArgs e) => 
        {
            GL.Viewport(0, 0, gameWindow.ClientSize.X, gameWindow.ClientSize.Y);
        };
        gameWindow.Run();
    }

    protected abstract void Initialize();
    protected abstract void LoadContent();
    protected abstract void Update(GameTime gameTime);
    protected abstract void Render(GameTime gameTime);
}