using AEngine.TK.Core.Rendering;
using AEngine.TK.Core.Rendering.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using System.Numerics;

namespace AEngine.TK.Core.Drawing;

public class Sprite : IDrawableObject
{
    public string FileName;
    public string Directory;
    public Texture2D Texture;
    public Vector2 Size;

    public Sprite(string fn = "honestree.png", string dir = "Resources/Textures/")
    {
        FileName = fn;
        Directory = dir;

        Load();
    }

    protected override void Load()
    {
        Texture = Core.Management.ResourceManager.Instance.LoadTexture(Directory + FileName);
        Size = new Vector2(Texture.Width, Texture.Height);
        DefineVertices();
        DefineIndices();

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
    }

    private void DefineVertices()
    {
        float aspect = Size.X / Size.Y;
        if (aspect > 1)
        {
            float otherside = 1 / Size.X * Size.Y;
            Vertices = [
                1f,otherside,0.0f,1.0f,1.0f,1.0f,1.0f,1.0f,0.0f,
                1f,-otherside,0.0f,1.0f,0.0f,1.0f,1.0f,1.0f,0.0f,
                -1f,-otherside,0.0f,0.0f,0.0f,1.0f,1.0f,1.0f,0.0f,
                -1f,otherside,0.0f,0.0f,1.0f,1.0f,1.0f,1.0f,0.0f,
            ];
        }
        else
        {
            float otherside = 1 / Size.Y * Size.X;
            Vertices = [
                otherside,1f,0.0f,1.0f,1.0f,1.0f,1.0f,1.0f,0.0f,
                otherside,-1f,0.0f,1.0f,0.0f,1.0f,1.0f,1.0f,0.0f,
                -otherside,-1f,0.0f,0.0f,0.0f,1.0f,1.0f,1.0f,0.0f,
                -otherside,1f,0.0f,0.0f,1.0f,1.0f,1.0f,1.0f,0.0f,
            ];
        }
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
