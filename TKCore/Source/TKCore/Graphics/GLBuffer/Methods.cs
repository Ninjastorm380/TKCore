using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace TKCore.Graphics;

public partial class GLBuffer : IGLObject {
    public GLBuffer(BufferTarget Target) {
        lock (Constants.GL.Lock) {
            Pointer      = GL.GenBuffer();
            BufferTarget = Target;
            Disposed     = false;
        }
    }
    
    public void Add(GLBufferAttribute Attribute) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.VertexAttribPointer(Attribute.AttributeIndex, Attribute.ElementSize, Attribute.PointerType, false, Attribute.ElementStride, (nint)Attribute.ElementOffset);
            GL.VertexAttribDivisor(Attribute.AttributeIndex, Attribute.UnitDivisor);
            GL.EnableVertexAttribArray(Attribute.AttributeIndex);
        }
    }
    
    public void Upload(Matrix4[] Data, BufferUsage Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data, Usage);
        }
    }
    
    public void Upload(Matrix3[] Data, BufferUsage Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data, Usage);
        }
    }
    
    public void Upload(Matrix2[] Data, BufferUsage Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data, Usage);
        }
    }
    
    public void Upload(Vector4[] Data, BufferUsage Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data, Usage);
        }
    }
    
    public void Upload(Vector3[] Data, BufferUsage Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data, Usage);
        }
    }
    
    public void Upload(Vector2[] Data, BufferUsage Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data, Usage);
        }
    }
    
    public void Upload(Single[] Data, BufferUsage Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data, Usage);
        }
    }
    
    public void Upload(Vector4i[] Data, BufferUsage Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data, Usage);
        }
    }
    
    public void Upload(Vector3i[] Data, BufferUsage Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data, Usage);
        }
    }
    
    public void Upload(Vector2i[] Data, BufferUsage Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data, Usage);
        }
    }
    
    public void Upload(Int32[] Data, BufferUsage Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data, Usage);
        }
    }
    
    public void Upload(UInt32[] Data, BufferUsage Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data, Usage);
        }
    }
    
    public void Bind() {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
        }
    }
    
    public void Unbind() {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, 0);
        }
    }
    
    void IDisposable.Dispose() {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.DeleteBuffer(in Pointer);
            GL.BindBuffer(BufferTarget, 0);
            Disposed = true;
        }
    }
}