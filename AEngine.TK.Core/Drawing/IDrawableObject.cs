using AEngine.TK.Core.Rendering.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using AEngine.TK.Core.Rendering;
using System.Numerics;

namespace AEngine.TK.Core.Drawing
{
    public abstract class IDrawableObject
    {
        protected Vector2 size;
        protected float[] Vertices;
        protected uint[] Indices;
        protected Shader Shader;
        protected VertexArray VertexArray;
        protected VertexBuffer VertexBuffer;
        protected IndexBuffer IndexBuffer;

        IDrawableObject() 
        { 
            
        }

        protected abstract void Load();
        public abstract void Render();
    }
}
