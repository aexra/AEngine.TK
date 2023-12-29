using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace AEngine.TK.Core.Rendering.Buffers
{
    public class IndexBuffer : IBuffer
    {
        public int BufferId {  get; private set; }
        public IndexBuffer(uint[] indices)
        {
            BufferId = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, BufferId);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.DynamicDraw);
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, BufferId);
        }

        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }
    }
}
