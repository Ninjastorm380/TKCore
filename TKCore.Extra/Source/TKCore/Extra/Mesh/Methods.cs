using OpenTK.Mathematics;

namespace TKCore.Extra;

public partial class Mesh {
    public Mesh(UInt32[] Indices, Single[] Vertices, Single[] TextureCoordinates) {
        BaseIndices            = Indices;
        BaseVertices           = Vertices;
        BaseTextureCoordinates = TextureCoordinates;
        BaseNormals            = CalculateNormals(BaseVertices);
    }
    
    public Mesh() {
        BaseVertices = [
            +0.5f, +0.5f, +0.5f, -0.5f, +0.5f, +0.5f, +0.5f, -0.5f, +0.5f, -0.5f, +0.5f, +0.5f, -0.5f, -0.5f, +0.5f, +0.5f, -0.5f, +0.5f,
            +0.5f, +0.5f, +0.5f, +0.5f, -0.5f, +0.5f, +0.5f, +0.5f, -0.5f, +0.5f, -0.5f, +0.5f, +0.5f, -0.5f, -0.5f, +0.5f, +0.5f, -0.5f,
            -0.5f, -0.5f, -0.5f, -0.5f, -0.5f, +0.5f, -0.5f, +0.5f, +0.5f, -0.5f, -0.5f, -0.5f, -0.5f, +0.5f, +0.5f, -0.5f, +0.5f, -0.5f,
            -0.5f, -0.5f, -0.5f, -0.5f, +0.5f, -0.5f, +0.5f, -0.5f, -0.5f, -0.5f, +0.5f, -0.5f, +0.5f, +0.5f, -0.5f, +0.5f, -0.5f, -0.5f,
            -0.5f, -0.5f, -0.5f, +0.5f, -0.5f, -0.5f, -0.5f, -0.5f, +0.5f, +0.5f, -0.5f, -0.5f, +0.5f, -0.5f, +0.5f, -0.5f, -0.5f, +0.5f,
            -0.5f, +0.5f, -0.5f, -0.5f, +0.5f, +0.5f, +0.5f, +0.5f, -0.5f, +0.5f, +0.5f, +0.5f, +0.5f, +0.5f, -0.5f, -0.5f, +0.5f, +0.5f];

        BaseTextureCoordinates = [
            +0.500f, +0.333f, +0.000f, +0.333f, +0.500f, +0.000f, +0.000f, +0.333f, +0.000f, +0.000f, +0.500f, +0.000f,
            +0.500f, +0.333f, +0.500f, +0.000f, +1.000f, +0.333f, +0.500f, +0.000f, +1.000f, +0.000f, +1.000f, +0.333f,
            +0.000f, +0.333f, +0.500f, +0.333f, +0.500f, +0.667f, +0.000f, +0.333f, +0.500f, +0.667f, +0.000f, +0.667f,
            +1.000f, +0.333f, +1.000f, +0.667f, +0.500f, +0.333f, +1.000f, +0.667f, +0.500f, +0.667f, +0.500f, +0.333f,
            +0.500f, +1.000f, +0.000f, +1.000f, +0.500f, +0.667f, +0.000f, +1.000f, +0.000f, +0.667f, +0.500f, +0.667f,
            +0.500f, +1.000f, +0.500f, +0.667f, +1.000f, +1.000f, +1.000f, +0.667f, +1.000f, +1.000f, +0.500f, +0.667f
        ];
        
        Array.Resize(ref BaseIndices, BaseVertices.Length); for (UInt32 Index = 0; Index < BaseIndices.Length; Index++) {
            BaseIndices[Index] = Index;
        }

        BaseNormals = CalculateNormals(BaseVertices);
    }
    
    private Single[] CalculateNormals(Single[] Verticies) {
        Single[] Normals = null; Array.Resize(ref Normals, Verticies.Length);
        for (Int32 Index = 0; Index < Verticies.Length; Index += 9) {
            Vector3 A = new Vector3(Verticies[Index + 00], Verticies[Index + 01], Verticies[Index + 02]);
            Vector3 B = new Vector3(Verticies[Index + 03], Verticies[Index + 04], Verticies[Index + 05]);
            Vector3 C = new Vector3(Verticies[Index + 06], Verticies[Index + 07], Verticies[Index + 08]);
            
            Vector3 Normal = Vector3.Normalize(Vector3.Cross(B - A, C - A));

            Normals[Index + 00] = Normal.X;
            Normals[Index + 01] = Normal.Y;
            Normals[Index + 02] = Normal.Z;
            Normals[Index + 03] = Normal.X;
            Normals[Index + 04] = Normal.Y;
            Normals[Index + 05] = Normal.Z;
            Normals[Index + 06] = Normal.X;
            Normals[Index + 07] = Normal.Y;
            Normals[Index + 08] = Normal.Z;
        } return Normals;
    }
}