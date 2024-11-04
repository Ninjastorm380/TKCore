using OpenTK.Graphics.OpenGL;

namespace TKCore.Graphics;

public partial class GLContext : IGLObject {
    public GLContext() {
        lock (Constants.GL.Lock) {
            Pointer  = GL.GenVertexArray();
            Objects  = new List<IGLObject>(256);
            Disposed = false;
        }
    }
    
    public void Bind() {
        lock (Constants.GL.Lock) GL.BindVertexArray(Pointer);
    }
    
    public void Unbind() {
        lock (Constants.GL.Lock) GL.BindVertexArray(0);
    }

    public void Attach(IGLObject Object) {
        lock (Constants.GL.Lock) {
            GL.BindVertexArray(Pointer);
            Object.Bind();
            Objects.Add(Object);
        }
    }
    
    public void Remove(IGLObject Object) {
        lock (Constants.GL.Lock) {
            GL.BindVertexArray(Pointer);
            Object.Unbind();
            Objects.Remove(Object);
        }
    }
    
    public void Dispose() {
        lock (Constants.GL.Lock) {
            GL.BindVertexArray(Pointer);
        
            foreach (IGLObject Object in Objects) {
                Object.Unbind(); if (!Object.Disposed) Object.Dispose();
            }
        
            GL.DeleteVertexArray(in Pointer);
            GL.BindVertexArray(0);
            Disposed = true;
        }
    }
}