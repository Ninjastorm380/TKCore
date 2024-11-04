namespace TKCore.Extra;

public partial class Mesh {
    public Single[] Vertices {
        get {
            return BaseVertices;
        }
    }
    
    public Single[] Normals {
        get {
            return BaseNormals;
        }
    }
    
    public UInt32[] Indices {
        get {
            return BaseIndices;
        }
    }
    
    public Single[] TextureCoordinates {
        get {
            return BaseTextureCoordinates;
        }
    }
}