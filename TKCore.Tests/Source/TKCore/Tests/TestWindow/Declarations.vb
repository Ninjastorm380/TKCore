Imports OpenTK.Windowing.Desktop
Imports TKCore.Extra

Namespace TKCore.Tests
    Public Partial Class TestWindow : Inherits GameWindow
        Private Camera As Camera
        Private VoxelManager As VoxelManager
        Private LightManager As LightManager
        
        Private CaptureToggle As Boolean
        Private SpeedModifier As Int32
        Private Aspect As Single
    End Class
End Namespace
