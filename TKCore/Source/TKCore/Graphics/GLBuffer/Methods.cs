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
            GL.BufferData(BufferTarget, Data.Length * 4 * (4 * 4), Data, Usage);
        }
    }
    
    public void Upload(Matrix3[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * 4 * (3 * 3), Data, Usage);
        }
    }
    
    public void Upload(Matrix2[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * 4 * (2 * 2), Data, Usage);
        }
    }
    
    public void Upload(Vector4[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * 4 * (4 * 1), Data, Usage);
        }
    }
    
    public void Upload(Vector3[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * 4 * (3 * 1), Data, Usage);
        }
    }
    
    public void Upload(Vector2[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * 4 * (2 * 1), Data, Usage);
        }
    }
    
    public void Upload(Single[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * 4 * (1 * 1), Data, Usage);
        }
    }
    
    public void Upload(Vector4i[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * 4 * (4 * 1), Data, Usage);
        }
    }
    
    public void Upload(Vector3i[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * 4 * (3 * 1), Data, Usage);
        }
    }
    
    public void Upload(Vector2i[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * 4 * (2 * 1), Data, Usage);
        }
    }
    
    public void Upload(Int32[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * 4 * (1 * 1), Data, Usage);
        }
    }
    
    public void Upload(UInt32[] Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, Data.Length * 4 * (1 * 1), Data, Usage);
        }
    }
    
    public void Upload(Matrix4 Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, 1 * 4 * (4 * 4), ref Data, Usage);
        }
    }
    
    public void Upload(Matrix3 Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, 1 * 4 * (3 * 3), ref Data, Usage);
        }
    }
    
    public void Upload(Matrix2 Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, 1 * 4 * (2 * 2), ref Data, Usage);
        }
    }
    
    public void Upload(Vector4 Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, 1 * 4 * (4 * 1), ref Data, Usage);
        }
    }
    
    public void Upload(Vector3 Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, 1 * 4 * (3 * 1), ref Data, Usage);
        }
    }
    
    public void Upload(Vector2 Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, 1 * 4 * (2 * 1), ref Data, Usage);
        }
    }
    
    public void Upload(Single Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, 1 * 4 * (1 * 1), ref Data, Usage);
        }
    }
    
    public void Upload(Vector4i Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, 1 * 4 * (4 * 1), ref Data, Usage);
        }
    }
    
    public void Upload(Vector3i Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, 1 * 4 * (3 * 1), ref Data, Usage);
        }
    }
    
    public void Upload(Vector2i Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, 1 * 4 * (2 * 1), ref Data, Usage);
        }
    }
    
    public void Upload(Int32 Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, 1 * 4 * (1 * 1), ref Data, Usage);
        }
    }
    
    public void Upload(UInt32 Data, BufferUsageHint Usage) {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
            GL.BufferData(BufferTarget, 1 * 4 * (1 * 1), ref Data, Usage);
        }
    }
    
    void IGLObject.Bind() {
        lock (Constants.GL.Lock) {
            GL.BindBuffer(BufferTarget, Pointer);
        }
    }
    
    void IGLObject.Unbind() {
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