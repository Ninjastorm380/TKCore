using OpenTK.Graphics.OpenGL;

namespace TKCore.Graphics;

public struct GLTextureFilter {
    public TextureMinFilter Min { get; }
    public TextureMagFilter Mag { get; }
    public TextureWrapMode S { get; }
    public TextureWrapMode T { get; }
    
    public GLTextureFilter(TextureMinFilter Min, TextureMagFilter Mag, TextureWrapMode S, TextureWrapMode T)
    {
        this.Min = Min;
        this.Mag = Mag;
        this.S   = S;
        this.T   = T;
    }
}