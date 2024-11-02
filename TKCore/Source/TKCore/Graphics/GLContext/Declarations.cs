namespace TKCore.Graphics;

public partial class GLContext : IGLObject {
    private readonly Int32 Pointer;
    private readonly List<IGLObject> Objects;
    private Boolean Disposed;
}