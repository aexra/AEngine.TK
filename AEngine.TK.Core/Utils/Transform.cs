using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AEngine.TK.Core.Utils;

public class Transform
{
    public Vector3 position = Vector3.Zero;
    public Vector3 scale = Vector3.Zero;
    public Quaternion rotation = new Quaternion();

    public Matrix4 Matrix
    {
        get
        {
            return Matrix4.CreateTranslation(position.X, position.Y, position.Z) * 
                Matrix4.CreateScale(scale.X, scale.Y, scale.Z);
        }
    }

    public void Translate(float dx, float dy, float dz)
    {
        position.X += dx;
        position.Y += dy;
        position.Z += dz;
    }
    public void Translate(Vector3 d)
    {
        position.X += d.X;
        position.Y += d.Y;
        position.Z += d.Z;
    }
    public void TranslateTo(float x, float y, float z)
    {
        position.X = x;
        position.Y = y;
        position.Z = z;
    }
    public void TranslateTo(Vector3 to)
    {
        position.X = to.X;
        position.Y = to.Y;
        position.Z = to.Z;
    }
    public void Scale(float dsx, float dsy, float dsz)
    {
        scale.X += dsx;
        scale.Y += dsy;
        scale.Z += dsz;
    }
    public void Scale(Vector3 ds)
    {
        scale.X += ds.X;
        scale.Y += ds.Y;
        scale.Z += ds.Z;
    }
    public void ScaleTo(float sx, float sy, float sz)
    {
        scale.X = sx;
        scale.Y = sy;
        scale.Z = sz;
    }
    public void ScaleTo(Vector3 to)
    {
        scale.X = to.X;
        scale.Y = to.Y;
        scale.Z = to.Z;
    }
}
