using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEngine.TK.Core.Drawing;
using AEngine.TK.Core.Engine;
using AEngine.TK.Core.Utils;
using OpenTK.Mathematics;

namespace AEngine.TK.Implementations.ExperimentsImpl;

public class Particle : GameObject
{
    private Rectangle _rect;

    public Particle(Color4 color, float x = 0, float y = 0, float z = 0, float sx = 1f, float sy = 1f, float sz = 1f) : base()
    {
        transform.position = new Vector3(x, y, z);
        transform.scale = new Vector3(sx, sy, sz);
        _rect = new(color);
        _rect.Translate(x, y, z);
        _rect.ScaleTo(sx, sy, sz);
        Children.Add(_rect);
    }

    public override void Update()
    {
        _rect.Update();
    }
    
    public override void Draw()
    {
        _rect.Draw();
    }
}
