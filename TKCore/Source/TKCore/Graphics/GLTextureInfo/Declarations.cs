
using OpenTK.Graphics.OpenGL;

namespace TKCore.Graphics;

public struct GLTextureInfo {
    public TextureTarget        TextureTarget       { get; }
    public PixelInternalFormat  PixelInternalFormat { get; }
    public PixelFormat          PixelFormat         { get; }
    public PixelType            PixelType           { get; }
    public System.Boolean       GenerateMipMaps     { get; }
    public GenerateMipmapTarget MipmapTarget        { get; }
    
    public GLTextureInfo(TextureTarget TextureTarget, PixelInternalFormat PixelInternalFormat, PixelFormat PixelFormat, PixelType PixelType, System.Boolean GenerateMipMaps = false) {
        this.TextureTarget       = TextureTarget;
        this.PixelInternalFormat = PixelInternalFormat;
        this.PixelFormat         = PixelFormat;
        this.PixelType           = PixelType;
        this.GenerateMipMaps     = GenerateMipMaps;

        if (!GenerateMipMaps) return;

        MipmapTarget = TextureTarget switch {
            TextureTarget.Texture1D                 => GenerateMipmapTarget.Texture1D,
            TextureTarget.Texture2D                 => GenerateMipmapTarget.Texture2D,
            TextureTarget.Texture3D                 => GenerateMipmapTarget.Texture3D,
            TextureTarget.Texture1DArray            => GenerateMipmapTarget.Texture1DArray,
            TextureTarget.Texture2DMultisample      => GenerateMipmapTarget.Texture2DMultisample,
            TextureTarget.TextureCubeMap            => GenerateMipmapTarget.TextureCubeMap,
            TextureTarget.Texture2DMultisampleArray => GenerateMipmapTarget.Texture2DMultisampleArray,
            TextureTarget.TextureCubeMapArray       => GenerateMipmapTarget.TextureCubeMapArray,
            _                                       => MipmapTarget
        };
    }
}