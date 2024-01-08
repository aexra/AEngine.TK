#shader vertex
#version 330 core
layout (location = 0) in vec3 aPosition;
layout (location = 1) in vec2 aTexCoord;
layout (location = 2) in float aIndex;
out vec2 texCoord;
out vec4 color;
out float texIndex;
out vec2 windowSize;
uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
uniform vec4 aColor;
uniform vec2 aWindowSize;

void main() 
{
    color = aColor;
    texIndex = aIndex;
    texCoord = aTexCoord;
    windowSize = aWindowSize;
    gl_Position = vec4(aPosition.xyz, 1.0) * model * view * projection;
}

#shader fragment
#version 330 core
out vec4 outputColor;
in float texIndex;
in vec2 texCoord;
in vec4 color;
in vec2 windowSize;
uniform sampler2D u_Texture[2];
uniform vec3 mousePos;

void main() 
{
    int index = int(texIndex);
    outputColor = texture(u_Texture[index], texCoord) * color;
    float distance = sqrt(pow(gl_FragCoord.x - mousePos.x, 2.0) + pow(gl_FragCoord.y - (windowSize.y - mousePos.y), 2.0));
    if (distance < 10) { outputColor = texture(u_Texture[index], texCoord) * vec4(1.0, 1.0, 1.0, 1-distance/10); }
}