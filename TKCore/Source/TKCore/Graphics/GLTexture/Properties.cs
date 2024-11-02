namespace TKCore.Graphics;

public partial class GLTexture : IGLObject {
    Boolean IGLObject.Disposed {
        get { return Disposed; }
    }

    Int32 IGLObject.Pointer {
        get { return Pointer; }
    }
}