namespace TKCore.Graphics;

public partial class GLBuffer : IGLObject {
    Boolean IGLObject.Disposed {
        get { return Disposed; }
    }

    Int32 IGLObject.Pointer {
        get { return Pointer; }
    }
}