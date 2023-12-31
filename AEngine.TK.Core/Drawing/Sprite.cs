﻿using AEngine.TK.Core.Rendering;
using AEngine.TK.Core.Rendering.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace AEngine.TK.Core.Drawing
{
    public class Sprite : IDrawableObject
    {
        public float[] Vertices { get; set; }
        public uint[] Indices { get; set; }
        public VertexArray VertexArray { get; set; }
        public VertexBuffer VertexBuffer { get; set; }
        public IndexBuffer IndexBuffer { get; set; }
        public Shader Shader { get; set; }

        public Sprite()
        {
            Vertices = [
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
            Indices = [
                0,
                1,
                3,
                1,
                2,
                3
            ];
            Load();
        }

        public void Load()
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

            Core.Management.ResourceManager.Instance.LoadTexture("Resources/Textures/honestree.png");
        }

        public void Render()
        {
            VertexArray.Bind();
            GL.DrawElements(PrimitiveType.Triangles, Indices.Length, DrawElementsType.UnsignedInt, 0);
        }
    }
}