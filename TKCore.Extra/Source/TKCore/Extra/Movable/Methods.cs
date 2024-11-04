using OpenTK.Mathematics;

namespace TKCore.Extra;

public abstract partial class Movable {
    public Movable() {
        BaseUp          = Constants.Orientation.Up;
        BaseDown        = Constants.Orientation.Down;
        BaseLeft        = Constants.Orientation.Left;
        BaseRight       = Constants.Orientation.Right;
        BaseForward     = Constants.Orientation.Forward;
        BaseBackward    = Constants.Orientation.Backward;
        BaseTranslation = Vector3.Zero;
        BaseRotation    = Vector3.Zero;
        BaseScale       = Vector3.One;
    }
    
    public virtual void ApplyOrientation() {
        BaseModelMatrix        = Matrix4.CreateScale(BaseScale) *
                                 Matrix4.CreateRotationX(BaseRotation.X) *
                                 Matrix4.CreateRotationY(BaseRotation.Y) *
                                 Matrix4.CreateRotationZ(BaseRotation.Z) *
                                 Matrix4.CreateTranslation(BaseTranslation);
        BaseModelMatrixInverse = BaseModelMatrix.Inverted();
        
        BaseUp       = Vector3.Normalize(Vector3.TransformNormalInverse(Constants.Orientation.Up,       BaseModelMatrixInverse));
        BaseDown     = Vector3.Normalize(Vector3.TransformNormalInverse(Constants.Orientation.Down,     BaseModelMatrixInverse));
        BaseLeft     = Vector3.Normalize(Vector3.TransformNormalInverse(Constants.Orientation.Left,     BaseModelMatrixInverse));
        BaseRight    = Vector3.Normalize(Vector3.TransformNormalInverse(Constants.Orientation.Right,    BaseModelMatrixInverse));
        BaseForward  = Vector3.Normalize(Vector3.TransformNormalInverse(Constants.Orientation.Forward,  BaseModelMatrixInverse));
        BaseBackward = Vector3.Normalize(Vector3.TransformNormalInverse(Constants.Orientation.Backward, BaseModelMatrixInverse));
    }
}
