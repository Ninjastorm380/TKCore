#version 330 core

struct Light {
    vec3 Position;
    vec3 Direction;
    vec3 AmbientColor;
    vec3 DiffuseColor;
    vec3 SpecularColor;
    vec3 AmbientStrength;
    vec3 DiffuseStrength;
    vec3 SpecularStrength;
    float Range;
    float Angle;
    float Strength;
};

#define MaximumSupportedLights 50

in vec3 FragmentPosition;
in vec3 Normal;
in vec2 TexCoords;
in float Shininess;
in float AlwaysLit;

out vec4 FragColor;

uniform sampler2D TextureAtlas;
uniform Light Lights[MaximumSupportedLights];
uniform int CurrentLightCount;
uniform vec3 DarknessColor = vec3(0, 0, 0);
uniform float MinimumLightLevel = 0.02;

void main() {
    vec3 Result = vec3(0.0);

    vec4 TextureSample = texture(TextureAtlas, TexCoords);
    vec3 TextureColor = TextureSample.rgb;
    float TextureAlpha = TextureSample.a;

    float MinimumLight = clamp(1 - MinimumLightLevel, 0, 1);
    float MaximumLight = 0;
    
    if (AlwaysLit > 0) {
        FragColor = TextureSample * clamp(AlwaysLit, 0, 1);
    }
    else {
        for (int i = 0; i < CurrentLightCount; i++) {
            Light SelectedLight = Lights[i];
            vec3 LightDirection = normalize(SelectedLight.Position - FragmentPosition);
            float LightTravelDistance = distance(SelectedLight.Position, FragmentPosition);
            if (LightTravelDistance <= SelectedLight.Range) {
                vec3 AmbientLight = SelectedLight.AmbientColor * SelectedLight.AmbientStrength;
                vec3 DiffuseLight = SelectedLight.DiffuseColor * max(dot(Normal, LightDirection), 0.0) * SelectedLight.DiffuseStrength;

                // TODO: Implement specular lighting.

                vec3 LightColor = (AmbientLight + DiffuseLight) * SelectedLight.Strength;
                float LightAttenuation = clamp(LightTravelDistance/SelectedLight.Range, MaximumLight, 1);
                vec3 AttenuatedLightColor = mix(LightColor, DarknessColor, LightAttenuation);
                Result += AttenuatedLightColor;
            }
        }
        FragColor = vec4(Result * TextureColor, TextureAlpha);
    }
}