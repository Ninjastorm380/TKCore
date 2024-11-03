namespace TKCore.Graphics;

public partial class GLProgram : IGLObject {
    private          Boolean Disposed;
    private readonly Int32   Pointer;
    
    private readonly GLShader BaseComputeShader;
    private readonly GLShader BaseVertexShader;
    private readonly GLShader BaseFragmentShader;
    private readonly GLShader BaseGeometryShader;
    private readonly GLShader BaseTesselationControlShader;
    private readonly GLShader BaseTesselationEvaluationShader;
    
    private readonly Dictionary<String, Int32> UniformLocations;
}