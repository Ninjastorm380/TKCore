using OpenTK.Mathematics;

namespace TKCore.Extra;

public partial class Camera : Movable {
    private Single BaseFieldOfView;
    private Single BaseNearPlane;
    private Single BaseFarPlane;
    private Single BaseAspectRatio;
    private Matrix4 BaseView;
    private Matrix4 BaseProjection;
}