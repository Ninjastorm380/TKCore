using OpenTK.Graphics.OpenGL;
using Boolean = System.Boolean;

namespace TKCore.Graphics;

public partial class GLBuffer : IGLObject {
    private Boolean Disposed;
    private readonly Int32 Pointer;
    private readonly BufferTarget BufferTarget;
}