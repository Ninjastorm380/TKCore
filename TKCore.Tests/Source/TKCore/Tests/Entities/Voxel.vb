Imports OpenTK.Mathematics
Imports OpenTK.Windowing.Common
Imports TKCore
Imports TKCore.Extra

Public MustInherit Class Voxel : Inherits Movable
    Public AtlasCoordinate As Vector2 = New Vector2(0,0)
    Public Shininess As Single = 2
    Public AlwaysLit As Single = 0
    
    Public MustOverride Sub Tick(Args As FrameEventArgs)
End Class