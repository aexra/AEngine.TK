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

    private static Vector3 _position;
    private static Vector3 cameraTarget;
    private static Vector3 cameraDirection;
    private static Vector3 up;
    private static Vector3 cameraRight;
    private static Vector3 cameraUp;

    public static void Init(float fovDegrees = 45.0f, float aspect = 16.0f / 9.0f, float depthNear = 0.1f, float depthFar = 100.0f)
    {
        view = Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f);
        projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(fovDegrees), aspect, depthNear, depthFar);

        _position = new Vector3();
        cameraTarget = Vector3.Zero;
        cameraDirection = Vector3.Normalize(_position - cameraTarget);
        up = Vector3.UnitY;
        cameraRight = Vector3.Normalize(Vector3.Cross(up, cameraDirection));
        cameraUp = Vector3.Cross(cameraDirection, cameraRight);
    }
}
