using AEngine.TK.Core.Rendering.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using AEngine.TK.Core.Rendering;

namespace AEngine.TK.Core.Drawing
{
    public interface IDrawableObject
    {
        float[] Vertices { get; set; }
        uint[] Indices { get; set; }
        Shader Shader { get; set; }
        VertexArray VertexArray { get;  set; }
        VertexBuffer VertexBuffer { get;  set; }
        IndexBuffer IndexBuffer { get;  set; }

        public void Load() { }
        public void Render();
    }
}
