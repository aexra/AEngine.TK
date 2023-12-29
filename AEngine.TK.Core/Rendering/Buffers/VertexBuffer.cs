using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace AEngine.TK.Core.Rendering.Buffers;

public class VertexBuffer : IBuffer
{
    public int BufferId { get; }

    public VertexBuffer(float[] vertices)
    {
        BufferId = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, BufferId);
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.DynamicDraw);
    }

    public void Bind()
    {
        GL.BindBuffer(BufferTarget.ArrayBuffer, BufferId);
    }

    public void Unbind()
    {
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
    }
}
