using AEngine.TK.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AEngine.TK.Core.Engine;

public class Tree
{
    private static List<GameObject> gameObjects = new List<GameObject>();

    public static GameObject Add(GameObject gameObject)
    {
        gameObjects.Add(gameObject);
        return gameObject;
    }

    public static GameObject Remove(GameObject gameObject)
    {
        gameObjects.Remove(gameObject);
        return gameObject;
    }

    public static List<GameObject> GetAll()
    {
        return gameObjects;
    }

    public static GameObject? Find(string name)
    {
        foreach (GameObject obj in gameObjects) 
        { 
            if (obj.name == name) return obj;
        }
        return null;
    }

    public static string GetUniqueObjectName()
    {
        uint lastIdx = 0;
        List<string> uniqNums = new List<string>();

        foreach (GameObject obj in gameObjects)
        {
            if (obj.name.Contains("GameObject"))
            {
                uniqNums.Add(obj.name);
                lastIdx++;
            }
        }

        while (uniqNums.Contains($"GameObject ({lastIdx})"))
        {
            lastIdx++;
        }

        if (lastIdx == 0) return "GameObject";
        else return $"GameObject ({lastIdx})";
    }

    public static void Update()
    {
        foreach (GameObject obj in gameObjects)
        {
            if (obj.Active)
                obj.Update();
        }
    }

    public static void Draw()
    {
        foreach (GameObject obj in gameObjects)
        {
            if (obj.Visible)
                obj.Draw();
        }
    }

    public static GameObject First() => gameObjects.First();
    public static GameObject Last() => gameObjects.Last();
}
