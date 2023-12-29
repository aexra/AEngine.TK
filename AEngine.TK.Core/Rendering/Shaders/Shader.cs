﻿using AEngine.TK.Core.Rendering.Shaders;
using OpenTK.Graphics.OpenGL4;

namespace AEngine.TK.Core.Rendering;

public class Shader
{
    public int ProgramId { get; private set; }
    private ShaderProgramSource _shaderProgramSource { get; }
    public bool Compiled { get; private set; }

    public Shader(string filePath)
    {
        _shaderProgramSource = ParseShader(filePath);
    }

    public bool CompileShader()
    {
        if (_shaderProgramSource == null)
        {
            Console.WriteLine("ShaderProgramSource is Null");
            return false;
        }
        if (Compiled)
        {
            Console.WriteLine("Shader was already compiled");
            return false;
        }
        int vertexShaderId = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShaderId, _shaderProgramSource.VertexShaderSource);
        GL.CompileShader(vertexShaderId);
        GL.GetShader(vertexShaderId, ShaderParameter.CompileStatus, out var vertexShaderCompilationCode);
        if (vertexShaderCompilationCode != (int)All.True)
        {
            Console.WriteLine(GL.GetShaderInfoLog(vertexShaderId));
            return false;
        }

        int fragmentShaderId = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragmentShaderId, _shaderProgramSource.FragmentShaderSource);
        GL.CompileShader(fragmentShaderId);
        GL.GetShader(fragmentShaderId, ShaderParameter.CompileStatus, out var fragmentShaderCompilationCode);
        if (fragmentShaderCompilationCode != (int)All.True)
        {
            Console.WriteLine(GL.GetShaderInfoLog(fragmentShaderId));
            return false;
        }

        ProgramId = GL.CreateProgram();
        GL.AttachShader(ProgramId, vertexShaderId);
        GL.AttachShader(ProgramId, fragmentShaderId);
        GL.LinkProgram(ProgramId);

        GL.DetachShader(ProgramId, vertexShaderId);
        GL.DetachShader(ProgramId, fragmentShaderId);

        GL.DeleteShader(vertexShaderId);
        GL.DeleteShader(fragmentShaderId);

        Compiled = true;

        return true;
    }

    public void Use()
    {
        if (!Compiled) CompileShader(); 
        GL.UseProgram(ProgramId);
    }

    private static ShaderProgramSource ParseShader(string filePath)
    {
        string[] shaderSource = new string[2];
        eShaderType shaderType = eShaderType.NONE;
        var allLines = File.ReadAllLines(filePath);
        for (int i = 0; i < allLines.Length; i++)
        {
            string current = allLines[i];
            if (current.ToLower().Contains("#shader"))
            {
                if (current.ToLower().Contains("vertex"))
                {
                    shaderType = eShaderType.VERTEX;
                } 
                else if (current.ToLower().Contains("fragment"))
                {
                    shaderType = eShaderType.FRAGMENT;
                }
                else
                {
                    // THROW ERROR ON PARSING *.glsl FILE
                }
            }
            else
            {
                shaderSource[(int)shaderType] += current + Environment.NewLine;
            }
        }
        return new ShaderProgramSource(shaderSource[0], shaderSource[1]);
    }
}