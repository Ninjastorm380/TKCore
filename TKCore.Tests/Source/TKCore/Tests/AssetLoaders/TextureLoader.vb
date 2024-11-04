Imports OpenTK.Graphics.OpenGL
Imports OpenTK.Mathematics
Imports StbImageSharp
Imports TKCore.Graphics

Public Class TextureLoader
    Public Shared Function FromFile(Path As String, Unit As TextureUnit) As GLTexture
        'Return New Texture(Path, TextureMinFilter.Nearest, TextureMagFilter.Nearest, TextureWrapMode.ClampToEdge, TextureWrapMode.ClampToEdge, TextureUnit.Texture0)
        StbImage.stbi_set_flip_vertically_on_load(1)
        Dim Image As ImageResult = ImageResult.FromMemory(IO.File.ReadAllBytes(Path), ColorComponents.RedGreenBlueAlpha)
        Dim Filter As New GLTextureFilter(TextureMinFilter.Nearest, TextureMagFilter.Nearest, TextureWrapMode.ClampToEdge, TextureWrapMode.ClampToEdge)
        Dim Info As New GLTextureInfo(TextureTarget.Texture2D, InternalFormat.Rgba, PixelFormat.Rgba, PixelType.UnsignedByte, True)
        Dim Texture As New GLTexture(Image.Data, TextureUnit.Texture0, New Vector2i(Image.Width, Image.Height), Info, Filter)
        Return Texture
    End Function
End Class