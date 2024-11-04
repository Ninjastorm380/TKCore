using OpenTK.Mathematics;

namespace TKCore.Extra;

public abstract partial class Movable {
    private Matrix4 BaseModelMatrix;
    private Matrix4 BaseModelMatrixInverse;
    private Vector3 BaseUp;
    private Vector3 BaseDown;
    private Vector3 BaseLeft;
    private Vector3 BaseRight;
    private Vector3 BaseForward;
    private Vector3 BaseBackward;
    private Vector3 BaseTranslation;
    private Vector3 BaseRotation;
    private Vector3 BaseScale;
}