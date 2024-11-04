Imports OpenTK.Mathematics
Imports TKCore
Imports TKCore.Extra

Public Class Light : Inherits Movable
    Public AmbientColor As Vector3
    Public DiffuseColor As Vector3
    Public SpecularColor As Vector3
    Public AmbientStrength As Vector3
    Public DiffuseStrength As Vector3
    Public SpecularStrength As Vector3
    Public Range As Single
    Public Angle As Single
    Public Strength As Single
End Class