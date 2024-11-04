#version 330 core

layout(location = 0) in vec3 MeshVertexPosition;
layout(location = 1) in vec2 MeshTextureCoordinate;
layout(location = 2) in vec3 MeshNormal;
layout(location = 3) in mat4 InstanceModelMatrix;
layout(location = 7) in vec2 InstanceAtlasCoordinate;
layout(location = 8) in float InstanceShininess;
layout(location = 9) in float InstanceAlwaysLit;

out vec3 FragmentPosition;
out vec3 Normal;
out vec2 TexCoords;
out float Shininess;
out float AlwaysLit;

uniform mat4 View;
uniform mat4 Projection;
uniform vec2 AtlasMaximum;

void main() {
    vec4 VertexPosition4 = vec4(MeshVertexPosition, 1.0);
    FragmentPosition = vec3(InstanceModelMatrix * VertexPosition4);
    Normal = mat3(transpose(inverse(InstanceModelMatrix))) * MeshNormal;
    float UVX = (MeshTextureCoordinate.x + InstanceAtlasCoordinate.x) / (AtlasMaximum.x + 1);
    float UVY = (MeshTextureCoordinate.y + InstanceAtlasCoordinate.y) / (AtlasMaximum.y + 1);
    TexCoords = vec2(UVX, UVY);
    Shininess = InstanceShininess;
    AlwaysLit = InstanceAlwaysLit;

    vec4 ModelPosition4 = VertexPosition4 * transpose(InstanceModelMatrix);
    vec4 ViewPosition4 = ModelPosition4 * View;
    vec4 ProjectionPosition4 = ViewPosition4 * Projection;
    gl_Position = ProjectionPosition4;
}
