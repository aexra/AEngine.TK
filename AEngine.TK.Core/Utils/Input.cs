using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AEngine.TK.Core.Utils;

public class Input
{
    public static Vector2 MousePosition;

    public static void OnMouseMove(MouseMoveEventArgs e)
    {
        MousePosition = new Vector2(e.X, e.Y);
    }
}
