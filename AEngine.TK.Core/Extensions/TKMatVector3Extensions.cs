using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEngine.TK.Core.Extensions;

public static class Extensions
{
    public static Vector2 XY(this Vector3 vec)
    {
        return new Vector2(vec.X, vec.Y);
    }
}
