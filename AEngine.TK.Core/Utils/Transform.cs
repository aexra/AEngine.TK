using Otk = OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AEngine.TK.Core.Utils
{
    public class Transform
    {
        public Vector3 position = Vector3.Zero;
        public Vector3 scale = Vector3.Zero;
        public Quaternion rotation = Quaternion.Zero;
        public Otk.Matrix4 matrix = new Otk.Matrix4();
    }
}
