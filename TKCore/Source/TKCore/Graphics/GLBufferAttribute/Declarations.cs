using OpenTK.Graphics.OpenGL;

namespace TKCore.Graphics;

public struct GLBufferAttribute {
    public UInt32                  AttributeIndex { get; }
    public Int32                   ElementSize    { get; }
    public Int32                   ElementStride  { get; }
    public Int32                   ElementOffset  { get; }
    public UInt32                  UnitDivisor    { get; }
    public VertexAttribPointerType PointerType    { get; }

    public GLBufferAttribute(UInt32 AttributeIndex, Int32 ElementSize, Int32 ElementStride, Int32 ElementOffset, UInt32 UnitDivisor = 0, VertexAttribPointerType PointerType = VertexAttribPointerType.Float) {
        this.AttributeIndex = AttributeIndex;
        this.ElementSize    = ElementSize;
        this.ElementStride  = ElementStride;
        this.ElementOffset  = ElementOffset;
        this.UnitDivisor    = UnitDivisor;
        this.PointerType    = PointerType;
    }
}