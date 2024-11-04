using OpenTK.Mathematics;

namespace TKCore.Extra;

public abstract partial class Movable {
    public Vector3 Left {
        get {
            return BaseLeft;
        }
    }
    
    public Vector3 Right {
        get {
            return BaseRight;
        }
    }
    
    public Vector3 Up {
        get {
            return BaseUp;
        }
    }
    
    public Vector3 Down {
        get {
            return BaseDown;
        }
    }
    
    public Vector3 Forward {
        get {
            return BaseForward;
        }
    }
    
    public Vector3 Backward {
        get {
            return BaseBackward;
        }
    }
    
    public Vector3 Translation {
        get {
            return BaseTranslation;
        }
        set {
            BaseTranslation = value;
        }
    }
    
    public Vector3 Rotation {
        get {
            return BaseRotation;
        }
        set {
            BaseRotation = value;
        }
    }
    
    public Vector3 Scale {
        get {
            return BaseScale;
        }
        set {
            BaseScale = value;
        }
    }
    
    public Matrix4 ModelMatrix {
        get {
            return BaseModelMatrix;
        }
        set {
            BaseModelMatrix        = value;
            BaseModelMatrixInverse = BaseModelMatrix.Inverted();
            BaseRotation           = BaseModelMatrix.ExtractRotation().Xyz;
            BaseTranslation        = BaseModelMatrix.ExtractTranslation();
            BaseScale              = BaseModelMatrix.ExtractScale();
        }
    }
    
    public Matrix4 ModelMatrixInverse {
        get {
            return BaseModelMatrixInverse;
        }
        set {
            BaseModelMatrixInverse = value;
            BaseModelMatrix        = BaseModelMatrixInverse.Inverted();
            BaseRotation           = BaseModelMatrix.ExtractRotation().Xyz;
            BaseTranslation        = BaseModelMatrix.ExtractTranslation();
            BaseScale              = BaseModelMatrix.ExtractScale();
        }
    }
}