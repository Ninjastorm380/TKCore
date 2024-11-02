using OpenTK.Graphics.OpenGL;
using Boolean = System.Boolean;

namespace TKCore.Graphics;

public partial class GLTexture : IGLObject {
    private          Boolean         Disposed;
    private readonly Int32           Pointer;
    private readonly GLTextureFilter Filter;
    private readonly GLTextureInfo   Info;
    private readonly TextureUnit     Unit;
}