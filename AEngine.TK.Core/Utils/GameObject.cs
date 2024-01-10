using AEngine.TK.Core.Engine;
using AEngine.TK.Core.Rendering;
using OpenTK.Graphics.ES11;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

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

    public void Translate(float dx, float dy, float dz)
    {
        transform.Translate(dx, dy, dz);
        foreach (var child in Children)
        {
            child.Translate(dx, dy, dz);
        }
    }
    public void Translate(Vector3 d)
    {
        transform.Translate(d);
        foreach (var child in Children)
        {
            child.Translate(d);
        }
    }
    public void TranslateTo(float x, float y, float z)
    {
        float dx = x - transform.position.X, 
            dy = y - transform.position.Y, 
            dz = z - transform.position.Z;
        transform.TranslateTo(x, y, z);
        foreach (var child in Children)
        {
            child.Translate(dx, dy, dz);
        }
    }
    public void TranslateTo(Vector3 to)
    {
        Vector3 d = to - transform.position;
        transform.TranslateTo(to);
        foreach (var child in Children)
        {
            child.Translate(d);
        }
    }
    public void Scale(float dsx, float dsy, float dsz)
    {
        transform.Scale(dsx, dsy, dsz);
        foreach (var child in Children)
        {
            child.Scale(dsx, dsy, dsz);
        }
    }
    public void Scale(Vector3 ds)
    {
        transform.Scale(ds);
        foreach (var child in Children)
        {
            child.Scale(ds);
        }
    }
    public void ScaleTo(float sx, float sy, float sz)
    {
        float dsx = sx - transform.scale.X,
            dsy = sy - transform.scale.Y,
            dsz = sz - transform.scale.Z;
        transform.ScaleTo(sx, sy, sz);
        foreach (var child in Children)
        {
            child.Scale(dsx, dsy, dsz);
        }
    }
    public void ScaleTo(Vector3 to)
    {
        Vector3 d = to - transform.scale;
        transform.ScaleTo(to);
        foreach (var child in Children)
        {
            child.Scale(d);
        }
    }

    public abstract void Update();
    public abstract void Draw();
}
