﻿using AEngine.TK.Core;
using AEngine.TK.Core.Rendering;
using AEngine.TK.Core.Rendering.Buffers;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System.Resources;

namespace AEngine.TK;

internal class BufferAbstraction : Game
{
    private readonly float[] _vertices = [
        0.5f, 0.5f, 0.0f, 1.0f, 1.0f, 1.0f, 0.0f, 0.0f,
        0.5f, -0.5f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f,
        -0.5f, -0.5f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f,
        -0.5f, 0.5f, 0.0f, 0.0f, 1.0f, 1.0f, 0.0f, 1.0f,
    ];
    private readonly uint[] _indices = [
        0, 1, 3,
        1, 2, 3
    ];

    private VertexArray _vertexArray;
    private VertexBuffer _vertexBuffer;
    private IndexBuffer _indexBuffer;

    private Shader _shader;
    private Texture2D _texture;

    public BufferAbstraction(string windowTitle, int initialWindowWidth, int initialWindowHeight) : base(windowTitle, initialWindowWidth, initialWindowHeight)
    {
    }

    protected override void Initialize()
    {

    }

    protected override void LoadContent()
    {
        _shader = new Shader("Resources/Shaders/TextureShader.glsl");

        _vertexArray = new();
        _vertexBuffer = new(_vertices);

        BufferLayout layout = new();
        layout.Add<float>(3);
        layout.Add<float>(2);
        layout.Add<float>(3);

        _vertexArray.AddBuffer(_vertexBuffer, layout);

        _indexBuffer = new IndexBuffer(_indices);

        _texture = AEngine.TK.Core.Management.ResourceManager.Instance.LoadTexture("Resources/Textures/honestree.png");
        _texture.Use();
    }

    protected override void Update()
    {

    }

    protected override void Render()
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.ClearColor(Color4.CornflowerBlue);
        _shader.Use();
        _vertexArray.Bind();
        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}

