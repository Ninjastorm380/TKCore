
using OpenTK.Graphics.OpenGL;

namespace TKCore.Graphics;

public struct GLTextureInfo {
    public TextureTarget        TextureTarget       { get; }
    public InternalFormat       InternalFormat      { get; }
    public PixelFormat          PixelFormat         { get; }
    public PixelType            PixelType           { get; }
    public System.Boolean       GenerateMipMaps     { get; }
    
    public GLTextureInfo(TextureTarget TextureTarget, InternalFormat InternalFormat, PixelFormat PixelFormat, PixelType PixelType, System.Boolean GenerateMipMaps = false) {
        this.TextureTarget       = TextureTarget;
        this.InternalFormat = InternalFormat;
        this.PixelFormat         = PixelFormat;
        this.PixelType           = PixelType;
        this.GenerateMipMaps     = GenerateMipMaps;
    }
}