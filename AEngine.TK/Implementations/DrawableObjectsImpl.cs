using AEngine.TK.Core;
using AEngine.TK.Core.Rendering;
using AEngine.TK.Core.Rendering.Buffers;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System.Resources;

namespace AEngine.TK;

internal class DrawableObjectsImpl : Game
{
    private readonly float[] _vertices = [
        1f,
        1f,
        0.0f,
        1.0f,
        1.0f,
        1.0f,
        1.0f,
        1.0f,
        0.0f,
        1f,
        -1f,
        0.0f,
        1.0f,
        0.0f,
        1.0f,
        1.0f,
        1.0f,
        0.0f,
        -1f,
        -1f,
        0.0f,
        0.0f,
        0.0f,
        1.0f,
        1.0f,
        1.0f,
        0.0f,
        -1f,
        1f,
        0.0f,
        0.0f,
        1.0f,
        1.0f,
        1.0f,
        1.0f,
        0.0f,
    ];
    private readonly uint[] _indices = [
        0,
        1,
        3,
        1,
        2,
        3
    ];

    private VertexArray _vertexArray;
    private VertexBuffer _vertexBuffer;
    private IndexBuffer _indexBuffer;

    private Shader _shader;

    public DrawableObjectsImpl(string windowTitle, int initialWindowWidth, int initialWindowHeight) : base(windowTitle, initialWindowWidth, initialWindowHeight)
    {
    }

    protected override void Initialize()
    {

    }

    protected override void LoadContent()
    {
        _shader = new Shader("Resources/Shaders/MulTextures.glsl");
        if (!_shader.CompileShader())
        {
            Console.WriteLine("Failed to Compile Shader");
            return;
        }

        _vertexArray = new();
        _vertexBuffer = new(_vertices);

        BufferLayout layout = new();
        layout.Add<float>(3);
        layout.Add<float>(2);
        layout.Add<float>(3);
        layout.Add<float>(1);

        _vertexArray.AddBuffer(_vertexBuffer, layout);
        _shader.Use();
        _indexBuffer = new IndexBuffer(_indices);

        var textureSamplerUniformLocation = _shader.GetUniformLocation("u_Texture[0]");
        int[] samplers = { 0, 1 };
        GL.Uniform1(textureSamplerUniformLocation, 2, samplers);

        Core.Management.ResourceManager.Instance.LoadTexture("Resources/Textures/honestree.png");
        Core.Management.ResourceManager.Instance.LoadTexture("Resources/Textures/hc.jpg");
    }

    protected override void Update(GameTime gameTime)
    {

    }

    protected override void Render(GameTime gameTime)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.ClearColor(Color4.CornflowerBlue);
        _vertexArray.Bind();
        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}

