using OpenTK.Graphics.ES20;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEngine.TK.Core.Rendering;

public class Camera
{
    public static Matrix4 view;
    public static Matrix4 projection;
    public static Vector3 position = new Vector3(0, 0, 0);

    private static Vector3 front = new Vector3(0.0f, 0.0f, -1.0f);
    private static Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);

    public static void Init(float fovDegrees = 45.0f, float aspect = 16.0f / 9.0f, float depthNear = 0.1f, float depthFar = 100.0f)
    {
        view = Matrix4.CreateTranslation(position);
        projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(fovDegrees), aspect, depthNear, depthFar);
    }

    public static void LookAt(Vector3 position)
    {

    }

    public static void Translate(Vector3 by)
    {
        position += by;
        view = Matrix4.LookAt(position, position + front, Vector3.UnitY);
        Console.WriteLine(position);
    }
}
