namespace TKCore.Graphics;

public partial class GLProgram : IGLObject {
    Boolean IGLObject.Disposed {
        get { return Disposed; }
    }

    Int32 IGLObject.Pointer {
        get { return Pointer; }
    }
    
    internal Boolean    CompileError { get; }
    internal String     CompileLog   { get; }
}