#shader vertex
#version 330 core
layout (location = 0) in vec3 aPosition;
out vec4 color;
out vec2 windowSize;
uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
uniform vec4 aColor;
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
    float distance = sqrt(pow(gl_FragCoord.x - mousePos.x, 2.0) + pow(gl_FragCoord.y - (windowSize.y - mousePos.y), 2.0));
    if (distance < 10) { outputColor = vec4(1.0, 1.0, 1.0, 1-distance/10); }
}