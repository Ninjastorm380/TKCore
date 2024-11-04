using OpenTK.Mathematics;

namespace TKCore.Constants;

public static class Orientation {
    public readonly static Vector3 Backward = new Vector3(+0.0f, +0.0f, +1.0f);
    public readonly static Vector3 Up       = new Vector3(+0.0f, +1.0f, +0.0f);
    public readonly static Vector3 Right    = new Vector3(+1.0f, +0.0f, +0.0f);
    
    public readonly static Vector3 Forward  = new Vector3(+0.0f, +0.0f, -1.0f);
    public readonly static Vector3 Down     = new Vector3(+0.0f, -1.0f, +0.0f);
    public readonly static Vector3 Left     = new Vector3(-1.0f, +0.0f, +0.0f);
}