using OpenTK.Graphics.OpenGL4;

namespace AEngine.TK.Core.Rendering.Buffers;

public struct BufferElement
{
    public VertexAttribPointerType Type;
    public int Count;
    public bool Normalized;
}
