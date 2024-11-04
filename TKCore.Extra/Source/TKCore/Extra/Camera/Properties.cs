using OpenTK.Mathematics;

namespace TKCore.Extra;


public partial class Camera {
    public Single FieldOfView {
        get {
            return BaseFieldOfView;
        }
        set {
            BaseFieldOfView = value % MathHelper.TwoPi;
        }
    }
    
    public Single NearPlane {
        get {
            return BaseNearPlane;
        }
        set {
            if (value <= 0) return;
            BaseNearPlane = value;
        }
    }
    
    public Single FarPlane {
        get {
            return BaseFarPlane;
        }
        set {
            if (value <= BaseNearPlane) return;
            BaseFarPlane = value;
        }
    }
    
    public Single AspectRatio {
        get {
            return BaseAspectRatio;
        }
        set {
            if (value <= 0) return;
            BaseAspectRatio = value;
        }
    }
    
    public Matrix4 Projection {
        get {
            return BaseProjection;
        }
    }
    
    public Matrix4 View {
        get {
            return BaseView;
        }
    }
}