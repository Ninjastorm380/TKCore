namespace TKCore.Graphics;

public interface IGLObject : IDisposable {
    Boolean Disposed { get; }
    Int32 Pointer { get; }
    void Bind();
    void Unbind();
}