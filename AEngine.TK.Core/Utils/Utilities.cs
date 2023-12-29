using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEngine.TK.Core.Utils
{
    public static class Utilities
    {
        public static int GetSizeOfVertexAttribPointerType(VertexAttribPointerType type)
        {
            switch(type)
            {
                case VertexAttribPointerType.UnsignedByte:
                    return 1;
                case VertexAttribPointerType.UnsignedInt:
                    return 4;
                case VertexAttribPointerType.Float:
                    return 4;
            }
            return 0;
        }
    }
}
