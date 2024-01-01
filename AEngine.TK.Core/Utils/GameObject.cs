using AEngine.TK.Core.Engine;
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
    public bool visible;
    public bool active;
    public string name;

    public GameObject()
    {
        this.transform = new();
        this.visible = true;
        this.active = true;
        this.name = Tree.GetUniqueObjectName();
    }

    public abstract void Update();
    public abstract void Draw();
}
