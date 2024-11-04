using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace TKCore.Graphics;

public partial class GLTexture : IGLObject {
    public GLTexture(Byte[] Data, TextureUnit Unit, Vector2i Size, GLTextureInfo Info) {
        lock (Constants.GL.Lock) {
            this.Info   = Info;
            this.Unit   = Unit;
            Pointer     = GL.GenTexture();
            
            GL.ActiveTexture(this.Unit);
            GL.BindTexture(this.Info.TextureTarget, Pointer);
            GL.TexImage2D(this.Info.TextureTarget, 0, this.Info.InternalFormat, Size.X, Size.Y, 0, this.Info.PixelFormat, this.Info.PixelType, Data);
            Disposed = false;
        }
    }
    
    public GLTexture(Byte[] Data, TextureUnit Unit, Vector2i Size, GLTextureInfo Info, GLTextureFilter Filter) {
        lock (Constants.GL.Lock) {
            this.Info   = Info;
            this.Filter = Filter;
            this.Unit   = Unit;
            Pointer     = GL.GenTexture();
            
            GL.ActiveTexture(this.Unit);
            GL.BindTexture(this.Info.TextureTarget, Pointer);
            GL.TexImage2D(this.Info.TextureTarget, 0, this.Info.InternalFormat, Size.X, Size.Y, 0, this.Info.PixelFormat, this.Info.PixelType, Data);
            GL.TexParameteri(this.Info.TextureTarget, TextureParameterName.TextureMinFilter, (Int32)this.Filter.Min);
            GL.TexParameteri(this.Info.TextureTarget, TextureParameterName.TextureMagFilter, (Int32)this.Filter.Mag);
            GL.TexParameteri(this.Info.TextureTarget, TextureParameterName.TextureWrapS,     (Int32)this.Filter.S);
            GL.TexParameteri(this.Info.TextureTarget, TextureParameterName.TextureWrapT,     (Int32)this.Filter.T);
            if (this.Info.GenerateMipMaps) GL.GenerateMipmap(this.Info.TextureTarget);
            Disposed = false;
        }
    }
    
    void IGLObject.Bind() {
        lock (Constants.GL.Lock) {
            GL.ActiveTexture(Unit);
            GL.BindTexture(Info.TextureTarget, Pointer);
        }
    }
    
    void IGLObject.Unbind() {
        lock (Constants.GL.Lock) {
            GL.ActiveTexture(Unit);
            GL.BindTexture(Info.TextureTarget, 0);
        }
    }
    
    void IDisposable.Dispose() {
        lock (Constants.GL.Lock) {
            GL.ActiveTexture(Unit);
            GL.BindTexture(Info.TextureTarget, 0);
            GL.DeleteTexture(in Pointer);
            Disposed = true;
        }
    }
}