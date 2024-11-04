using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace TKCore.Graphics;

public partial class GLProgram : IGLObject {
    public GLProgram(GLShader ComputeShader = null, GLShader FragmentShader = null, GLShader VertexShader = null,
        GLShader GeometryShader = null, GLShader TesselationEvaluationShader = null,
        GLShader TesselationControlShader = null) {
        lock (Constants.GL.Lock) {
            BaseComputeShader               = ComputeShader;
            BaseFragmentShader              = FragmentShader;
            BaseVertexShader                = VertexShader;
            BaseGeometryShader              = GeometryShader;
            BaseTesselationEvaluationShader = TesselationEvaluationShader;
            BaseTesselationControlShader    = TesselationControlShader;
            UniformLocations                = new Dictionary<String, Int32>();

            Pointer = GL.CreateProgram();

            if (IsAllNull()) {
                CompileError = true;
                CompileLog   = $"You must supply at least one shader!";
            }

            if (BaseComputeShader != null) {
                GL.AttachShader(Pointer, BaseComputeShader.Pointer);
            }

            if (BaseFragmentShader != null) {
                GL.AttachShader(Pointer, BaseFragmentShader.Pointer);
            }

            if (BaseVertexShader != null) {
                GL.AttachShader(Pointer, BaseVertexShader.Pointer);
            }

            if (BaseGeometryShader != null) {
                GL.AttachShader(Pointer, BaseGeometryShader.Pointer);
            }

            if (BaseTesselationEvaluationShader != null) {
                GL.AttachShader(Pointer, BaseTesselationEvaluationShader.Pointer);
            }

            if (BaseTesselationControlShader != null) {
                GL.AttachShader(Pointer, BaseTesselationControlShader.Pointer);
            }

            GL.LinkProgram(Pointer);
            Int32 Result = 0;
            GL.GetProgrami(Pointer, ProgramProperty.LinkStatus, ref Result);
            CompileError = (Result == 0);
            GL.GetProgramInfoLog(Pointer, out String Log);
            CompileLog = Log;

            Int32 NumberOfUniforms = 0;
            GL.GetProgrami(Pointer, ProgramProperty.ActiveUniforms, ref NumberOfUniforms);
            for (UInt32 Index = 0; Index <= NumberOfUniforms - 1; Index++) {
                Int32 A = 0;
                Int32 B = 0;
                UniformType C = UniformType.Bool;
                String Key = GL.GetActiveUniform(Pointer, Index, Int32.MaxValue, ref A, ref B, ref C);
                if (String.IsNullOrEmpty(Key)) {
                    continue;
                }

                Int32 Value = GL.GetUniformLocation(Pointer, Key);
                UniformLocations.Add(Key, Value);
            }
            Disposed = false;
        }
    }

    public void Bind() {
        lock (Constants.GL.Lock) {
            GL.UseProgram(Pointer);
        }
    }

    public void Unbind() {
        lock (Constants.GL.Lock) {
            GL.UseProgram(0);
        }
    }

    public void SetUniform(String UniformName, Matrix4 Value) {
        lock (Constants.GL.Lock) {
            if (UniformName == null) {
                throw new ArgumentException("'UniformName' must not be null!");
            }

            GL.UniformMatrix4f(UniformLocations[UniformName], 1, false, in Value);
        }
    }

    public void SetUniform(String UniformName, Matrix3 Value) {
        lock (Constants.GL.Lock) {
            if (UniformName == null) {
                throw new ArgumentException("'UniformName' must not be null!");
            }

            GL.UniformMatrix3f(UniformLocations[UniformName], 1, false, in Value);
        }
    }

    public void SetUniform(String UniformName, Matrix2 Value) {
        lock (Constants.GL.Lock) {
            if (UniformName == null) {
                throw new ArgumentException("'UniformName' must not be null!");
            }

            GL.UniformMatrix2f(UniformLocations[UniformName], 1, false, in Value);
        }
    }

    public void SetUniform(String UniformName, Vector4 Value) {
        lock (Constants.GL.Lock) {
            if (UniformName == null) {
                throw new ArgumentException("'UniformName' must not be null!");
            }

            GL.Uniform4f(UniformLocations[UniformName], 1, in Value);
        }
    }

    public void SetUniform(String UniformName, Vector3 Value) {
        lock (Constants.GL.Lock) {
            if (UniformName == null) {
                throw new ArgumentException("'UniformName' must not be null!");
            }

            GL.Uniform3f(UniformLocations[UniformName], 1, in Value);
        }
    }

    public void SetUniform(String UniformName, Vector2 Value) {
        lock (Constants.GL.Lock) {
            if (UniformName == null) {
                throw new ArgumentException("'UniformName' must not be null!");
            }

            GL.Uniform2f(UniformLocations[UniformName], 1, in Value);
        }
    }

    public void SetUniform(String UniformName, Single Value) {
        lock (Constants.GL.Lock) {
            if (UniformName == null) {
                throw new ArgumentException("'UniformName' must not be null!");
            }

            GL.Uniform1f(UniformLocations[UniformName], Value);
        }
    }

    public void SetUniform(String UniformName, Vector4i Value) {
        lock (Constants.GL.Lock) {
            if (UniformName == null) {
                throw new ArgumentException("'UniformName' must not be null!");
            }

            GL.Uniform4i(UniformLocations[UniformName], 1, in Value);
        }
    }

    public void SetUniform(String UniformName, Vector3i Value) {
        lock (Constants.GL.Lock) {
            if (UniformName == null) {
                throw new ArgumentException("'UniformName' must not be null!");
            }

            GL.Uniform3i(UniformLocations[UniformName], 1, in Value);
        }
    }

    public void SetUniform(String UniformName, Vector2i Value) {
        lock (Constants.GL.Lock) {
            if (UniformName == null) {
                throw new ArgumentException("'UniformName' must not be null!");
            }

            GL.Uniform2i(UniformLocations[UniformName], 1, in Value);
        }
    }

    public void SetUniform(String UniformName, Int32 Value) {
        lock (Constants.GL.Lock) {
            if (UniformName == null) {
                throw new ArgumentException("'UniformName' must not be null!");
            }

            GL.Uniform1i(UniformLocations[UniformName], Value);
        }
    }

    public void SetUniform(String UniformName, UInt32 Value) {
        lock (Constants.GL.Lock) {
            if (UniformName == null) {
                throw new ArgumentException("'UniformName' must not be null!");
            }

            GL.Uniform1ui(UniformLocations[UniformName], Value);
        }
    }

    private System.Boolean IsAllNull() {
        if (BaseComputeShader != null) { return false; }
        if (BaseFragmentShader != null) { return false; }
        if (BaseVertexShader != null) { return false; }
        if (BaseGeometryShader != null) { return false; }
        if (BaseTesselationEvaluationShader != null) { return false; }
        if (BaseTesselationControlShader != null) { return false; }
        
        return true;
    }

    void IDisposable.Dispose() {
        lock (Constants.GL.Lock) {
            GL.DeleteProgram(Pointer);
            UniformLocations.Clear();
            Disposed = true;
        }
    }
}