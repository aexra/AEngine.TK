#shader vertex
#version 330 core
layout (location = 0) in vec3 aPosition;
layout (location = 1) in vec4 aColor;
out vec4 color;
out vec2 windowSize;
uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
uniform vec2 aWindowSize;

void main() 
{
    color = aColor;
    windowSize = aWindowSize;
    gl_Position = vec4(aPosition.xyz, 1.0) * model * view * projection;
}

#shader fragment
#version 330 core
out vec4 outputColor;
in vec4 color;
in vec2 windowSize;
uniform vec3 mousePos;

void main() 
{
    outputColor = color;
}