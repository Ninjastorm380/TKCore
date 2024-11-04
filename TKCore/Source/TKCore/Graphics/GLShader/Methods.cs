using OpenTK.Graphics.OpenGL;

namespace TKCore.Graphics;

public partial class GLShader : IDisposable {
    public GLShader(Byte[] Data, ShaderType ShaderType) {
        lock (Constants.GL.Lock) {
            if (Data == null) {
                throw new ArgumentException("'Data' must not be null!");
            }
            
            ShaderSource = System.Text.Encoding.ASCII.GetString(Data);
            Type    = ShaderType;
            Pointer = GL.CreateShader(Type);
            GL.ShaderSource(Pointer, ShaderSource);
            GL.CompileShader(Pointer);
            Int32 Result = 0;
            GL.GetShaderi(Pointer, ShaderParameterName.CompileStatus, ref Result);
            CompileError = (Result == 0);
            GL.GetShaderInfoLog(Pointer, out String Log);
            CompileLog = Log;
        }
    }

    public void Dispose() {
        lock (Constants.GL.Lock) {
            GL.DeleteShader(Pointer);
        }
    }
}