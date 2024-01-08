using AEngine.TK.Core.Rendering;
using AEngine.TK.Core.Rendering.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace AEngine.TK.Core.Drawing;

public class Rectangle : IDrawableObject
{
    public string FileName;
    public string Directory;

    public Rectangle(Color4 color, float x = 0, float y = 0, float z = 0, float sx = 1, float sy = 1, float sz = 1)
    {
        Modulate = new Vector4(color.R, color.G, color.B, color.A);
        transform.position = new Vector3(x, y, z);
        transform.scale = new Vector3(sx, sy, sz);
        Load();
    }

    protected override void Load()
    {
        DefineVertices();
        DefineIndices();

        Shader = new Shader("Rendering/Shaders/Default/DefaultRectangleShader.glsl");
        if (!Shader.CompileShader())
        {
            Console.WriteLine("Failed to Compile Shader");
            return;
        }

        VertexArray = new();
        VertexBuffer = new(Vertices);

        BufferLayout layout = new();
        layout.Add<float>(3);

        VertexArray.AddBuffer(VertexBuffer, layout);
        IndexBuffer = new IndexBuffer(Indices);
    }

    private void DefineVertices()
    {
        float aspect = transform.scale.X / transform.scale.Y;
        if (aspect > 1)
        {
            float otherside = 1 / transform.scale.X * transform.scale.Y;
            Vertices = [
                1f, otherside, 0.0f,
                1f, -otherside, 0.0f,
                -1f, -otherside, 0.0f,
                -1f, otherside, 0.0f,
            ];
        }
        else
        {
            float otherside = 1 / transform.scale.Y * transform.scale.X;
            Vertices = [
                otherside, 1f, 0.0f,
                otherside, -1f, 0.0f,
                -otherside, -1f, 0.0f,
                -otherside, 1f, 0.0f,
            ];
        }
    }

    private void DefineIndices()
    {
        Indices = [0, 1, 3, 1, 2, 3];
    }

    public override void Update()
    {

    }

    public override void Draw()
    {
        base.Draw();
        VertexArray.Bind();
        GL.DrawElements(PrimitiveType.Triangles, Indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}
