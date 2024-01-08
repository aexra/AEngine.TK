using AEngine.TK.Core.Rendering.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using AEngine.TK.Core.Rendering;
using AEngine.TK.Core.Utils;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using AEngine.TK.Core.Config;
using System.Reflection;

namespace AEngine.TK.Core.Drawing;

public abstract class IDrawableObject : GameObject
{
    protected float[] Vertices;
    protected uint[] Indices;
    protected VertexArray VertexArray;
    protected VertexBuffer VertexBuffer;
    protected IndexBuffer IndexBuffer;

    public Vector4 Modulate = Vector4.One;

    public IDrawableObject() : base()
    {
       
    }

    public IDrawableObject(Vector3 position) : this() 
    {
        transform.position = position;  
    }

    public IDrawableObject(Vector3 position, Vector3 scale) : this(position) 
    { 
        transform.scale = scale;
    }

    public IDrawableObject(Vector3 position, Vector3 size, Quaternion rotation) : this(position, size)
    {
        transform.rotation = rotation;
    }

    protected abstract void Load();
    public override void Draw()
    {
        Shader.ApplyNativeUniforms += () =>
        {
            Shader.SetVector4("aColor", Modulate);
            Shader.SetMatrix4("model", transform.Matrix);
            Shader.SetMatrix4("view", Camera.view);
            Shader.SetMatrix4("projection", Camera.projection);
        };
        Shader.Use();
    }

    public void SetShader(Shader newShader)
    {
        Shader = newShader;
    }
}
