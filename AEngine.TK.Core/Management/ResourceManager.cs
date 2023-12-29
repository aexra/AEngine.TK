using AEngine.TK.Core.Management.Textures;
using AEngine.TK.Core.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEngine.TK.Core.Management;

public sealed class ResourceManager
{
    private static ResourceManager _instance;
    private static readonly object _lock = new();
    private IDictionary<string, Texture2D> _textureCache = new Dictionary<string, Texture2D>();

    public static ResourceManager Instance
    {
        get
        {
            lock(_lock) 
            {
                if (_instance == null)
                {
                    _instance = new ResourceManager();
                }
            }
            return _instance;
        }
    }

    public Texture2D LoadTexture(string textureName)
    {
        _textureCache.TryGetValue(textureName, out var value);
        if (value is not null)
        {
            return value;
        }
        value = TextureFactory.Load(textureName);
        _textureCache.Add(textureName, value);
        return value;
    }
}
