using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEngine.TK.Core.Rendering
{
    public class Camera
    {
        public static Matrix4 model;
        public static Matrix4 view;
        public static Matrix4 projection;

        public static void Init(float rotationMatrixDegrees = -55.0f, float initialX = 0.0f, float initialY = 0.0f, float initialZ = -3.0f, float fovDegrees = 45.0f, float aspect = 16.0f / 9.0f, float depthNear = 0.1f, float depthFar = 100.0f)
        {
            model = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotationMatrixDegrees));
            view = Matrix4.CreateTranslation(initialX, initialY, initialZ);
            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(fovDegrees), aspect, depthNear, depthFar);
        }
    }
}
