using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace AEngine.TK.Core.Rendering;

public class Texture2D : IDisposable
{
    private bool _disposed;
    public int Handle { get; private set; }
    public int Width {  get; set; }
    public int Height { get; set; }
    public TextureUnit TextureSlot { get; set; } = TextureUnit.Texture0;

    public Texture2D(int handle)
    {
        Handle = handle;
    }

    public Texture2D(int handle, int width, int height) : this(handle)
    {
        Width = width;
        Height = height;
    }

    public Texture2D(int handle, int width, int height, TextureUnit textureSlot) : this(handle, width, height)
    {
        TextureSlot = textureSlot;
    }

    ~Texture2D()
    {
        Dispose(false);
    }

    public void Use()
    {
        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, Handle);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            GL.DeleteTexture(Handle);
            _disposed = true;
        }
    }
}
