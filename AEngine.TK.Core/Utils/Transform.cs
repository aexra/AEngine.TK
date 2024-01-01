using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AEngine.TK.Core.Utils;

public class Transform
{
    public Vector3 position = Vector3.Zero;
    public Vector3 scale = Vector3.One;
    public Quaternion rotation = new Quaternion();

    public Matrix4 Matrix
    {
        get
        {
            return Matrix4.CreateTranslation(position.X, position.Y, position.Z) * 
                Matrix4.CreateScale(scale.X, scale.Y, scale.Z);
        }
    }
}
