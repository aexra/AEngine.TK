using AEngine.TK.Core.Rendering;
using AEngine.TK.Core.Rendering.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace AEngine.TK.Core.Drawing;

public class Sprite : IDrawableObject
{
    public string FileName;

    public Sprite(string fn = "Resources/Textures/honestree.png")
    {
        FileName = fn;

        DefineVertices();
        DefineIndices();
        Load();
    }

    protected override void Load()
    {
        Shader = new Shader("Resources/Shaders/DefaultTextureShader.glsl");
        if (!Shader.CompileShader())
        {
            Console.WriteLine("Failed to Compile Shader");
            return;
        }

        VertexArray = new();
        VertexBuffer = new(Vertices);

        BufferLayout layout = new();
        layout.Add<float>(3);
        layout.Add<float>(2);
        layout.Add<float>(3);
        layout.Add<float>(1);

        VertexArray.AddBuffer(VertexBuffer, layout);
        Shader.Use();
        IndexBuffer = new IndexBuffer(Indices);

        var textureSamplerUniformLocation = Shader.GetUniformLocation("u_Texture[0]");
        int[] samplers = { 0, 1 };
        GL.Uniform1(textureSamplerUniformLocation, 2, samplers);

        Core.Management.ResourceManager.Instance.LoadTexture(FileName);
    }

    private void DefineVertices()
    {
        Vertices = [
            1f,1f,0.0f,1.0f,1.0f,1.0f,1.0f,1.0f,0.0f,
            1f,-1f,0.0f,1.0f,0.0f,1.0f,1.0f,1.0f,0.0f,
            -1f,-1f,0.0f,0.0f,0.0f,1.0f,1.0f,1.0f,0.0f,
            -1f,1f,0.0f,0.0f,1.0f,1.0f,1.0f,1.0f,0.0f,
        ];
    }

    private void DefineIndices()
    {
        Indices = [0, 1, 3, 1, 2, 3];
    }

    public override void Update()
    {
        Shader.SetMatrix4("model", transform.Matrix);
        Shader.SetMatrix4("view", Camera.view);
        Shader.SetMatrix4("projection", Camera.projection);
    }

    public override void Draw()
    {
        VertexArray.Bind();
        GL.DrawElements(PrimitiveType.Triangles, Indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}
