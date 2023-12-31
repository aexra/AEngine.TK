using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEngine.TK.Core.Utils;

public abstract class GameObject
{
    public Transform transform;

    public GameObject()
    {
        this.transform = new();
    }

    public abstract void Update();
    public abstract void Draw();
}
