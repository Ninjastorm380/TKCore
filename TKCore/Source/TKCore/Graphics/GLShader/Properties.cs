using OpenTK.Graphics.OpenGL;
using Boolean = System.Boolean;

namespace TKCore.Graphics;

public partial class GLShader : IDisposable {
    internal Int32      Pointer      { get; }
    internal ShaderType Type         { get; }
    internal Boolean    CompileError { get; }
    internal String     CompileLog   { get; }
}