#shader vertex
#version 330 core
layout (location = 0) in vec3 aPosition;
layout (location = 1) in vec2 aTexCoord;
layout (location = 2) in float aIndex;
out vec2 texCoord;
out vec4 color;
out float texIndex;
uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
uniform vec4 aColor;

void main() 
{
    color = aColor;
    texIndex = aIndex;
    texCoord = aTexCoord;
    gl_Position = vec4(aPosition.xyz, 1.0) * model * view * projection;
}

#shader fragment
#version 330 core
out vec4 outputColor;
in float texIndex;
in vec2 texCoord;
in vec4 color;
uniform sampler2D u_Texture[2];
uniform vec3 mousePos;

void main() 
{
    int index = int(texIndex);
    outputColor = texture(u_Texture[index], texCoord) * color;
}