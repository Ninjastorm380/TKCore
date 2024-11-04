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
            GL.VertexAttribPointer(Attribute.AttributeIndex, Attribute.ElementSize, Attribute.PointerType, false, Attribute.ElementStride, Attribute.ElementOffset);
            GL.VertexAttribDivisor(Attribute.AttributeIndex, Attribute.UnitDivisor);
            GL.EnableVertexAttribArray(Attribute.AttributeIndex);
        }
    }
    
    public void Upload(Matrix4[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * Constants.ByteSize.Matrix4, Data, Usage);
        }
    }
    
    public void Upload(Matrix3[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * Constants.ByteSize.Matrix3, Data, Usage);
        }
    }
    
    public void Upload(Matrix2[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * Constants.ByteSize.Matrix2, Data, Usage);
        }
    }
    
    public void Upload(Vector4[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * Constants.ByteSize.Vector4, Data, Usage);
        }
    }
    
    public void Upload(Vector3[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * Constants.ByteSize.Vector3, Data, Usage);
        }
    }
    
    public void Upload(Vector2[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * Constants.ByteSize.Vector2, Data, Usage);
        }
    }
    
    public void Upload(Single[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * Constants.ByteSize.Single, Data, Usage);
        }
    }
    
    public void Upload(Vector4i[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * Constants.ByteSize.Vector4i, Data, Usage);
        }
    }
    
    public void Upload(Vector3i[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * Constants.ByteSize.Vector3i, Data, Usage);
        }
    }
    
    public void Upload(Vector2i[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * Constants.ByteSize.Vector2i, Data, Usage);
        }
    }
    
    public void Upload(Int32[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * Constants.ByteSize.Int32, Data, Usage);
        }
    }
    
    public void Upload(UInt32[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * Constants.ByteSize.UInt32, Data, Usage);
        }
    }
    
    public void Upload(Matrix4 Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Constants.ByteSize.Matrix4, ref Data, Usage);
        }
    }
    
    public void Upload(Matrix3 Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Constants.ByteSize.Matrix3, ref Data, Usage);
        }
    }
    
    public void Upload(Matrix2 Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Constants.ByteSize.Matrix2, ref Data, Usage);
        }
    }
    
    public void Upload(Vector4 Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Constants.ByteSize.Vector4, ref Data, Usage);
        }
    }
    
    public void Upload(Vector3 Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Constants.ByteSize.Vector3, ref Data, Usage);
        }
    }
    
    public void Upload(Vector2 Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Constants.ByteSize.Vector2, ref Data, Usage);
        }
    }
    
    public void Upload(Single Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Constants.ByteSize.Single, ref Data, Usage);
        }
    }
    
    public void Upload(Vector4i Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Constants.ByteSize.Vector4i, ref Data, Usage);
        }
    }
    
    public void Upload(Vector3i Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Constants.ByteSize.Vector3i, ref Data, Usage);
        }
    }
    
    public void Upload(Vector2i Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Constants.ByteSize.Vector2i, ref Data, Usage);
        }
    }
    
    public void Upload(Int32 Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Constants.ByteSize.Int32, ref Data, Usage);
        }
    }
    
    public void Upload(UInt32 Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Constants.ByteSize.UInt32, ref Data, Usage);
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
            GL.DeleteBuffer(Pointer);
            GL.BindBuffer(BufferTarget, 0);
            Disposed = true;
        }
    }
}