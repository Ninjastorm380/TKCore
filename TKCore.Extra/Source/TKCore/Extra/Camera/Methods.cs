using OpenTK.Mathematics;

namespace TKCore.Extra; 

public partial class Camera : Movable {
    
    public Camera(Single NearPlane, Single FarPlane, Single FieldOfView, Single AspectRatio) {
        BaseNearPlane   = NearPlane;
        BaseFarPlane    = FarPlane;
        BaseFieldOfView = FieldOfView;
        BaseAspectRatio = AspectRatio;
        
        if (BaseAspectRatio <= 0            ) { BaseAspectRatio = 16 / 9; }
        if (BaseNearPlane   <= 0            ) { BaseNearPlane   = 1; }
        if (BaseFarPlane    <= BaseNearPlane) { BaseFarPlane    = BaseNearPlane + 1; }
        if (BaseFieldOfView <= 0            ) { BaseFieldOfView = 45; }
        
        ApplyProjection();
        ApplyOrientation();
    }
    
    public void ApplyProjection() {
        BaseProjection = Matrix4.CreatePerspectiveFieldOfView(BaseFieldOfView, BaseAspectRatio, BaseNearPlane, BaseFarPlane);
    }
    
    public override sealed void ApplyOrientation() {
        base.ApplyOrientation();
        BaseView = Matrix4.LookAt(Translation, Translation + Forward, Up);
    }
}