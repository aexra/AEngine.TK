#shader vertex
#version 330 core
layout (location = 0) in vec3 aPosition;
out vec4 color;
uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
uniform vec4 aColor;

void main() 
{
    color = aColor;
    gl_Position = vec4(aPosition.xyz, 1.0) * model * view * projection;
}

#shader fragment
#version 330 core
out vec4 outputColor;
in vec4 color;

void main() 
{
    outputColor = color;
}