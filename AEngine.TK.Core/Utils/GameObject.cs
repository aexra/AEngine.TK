using AEngine.TK.Core.Engine;
using AEngine.TK.Core.Rendering;
using OpenTK.Graphics.ES11;
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
    public bool Visible {  get; protected set; }
    public bool Active { get; protected set; }
    public string name;
    public Shader Shader { get; protected set; }
    public GameObject Parent { get; protected set; }
    public List<GameObject> Children { get; protected set; }

    public GameObject()
    {
        transform = new();
        Visible = true;
        Active = true;
        name = Tree.GetUniqueObjectName();
        Children = new List<GameObject>();
    }

    public void Enable() { Visible = Active = true; }
    public void Disable() { Visible = Active = false; }
    public void Show() { Visible = true; }
    public void Hide() { Visible = false; }
    public void Activate() { Active = true; }
    public void Deactivate() { Active = false; }

    public abstract void Update();
    public abstract void Draw();
}
