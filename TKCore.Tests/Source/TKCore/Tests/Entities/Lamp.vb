Imports OpenTK.Mathematics
Imports OpenTK.Windowing.Common

Public Class Lamp : Inherits Voxel
    Private ReadOnly LampLight As Light
    
    Public Sub New(LightManager As LightManager)
        MyBase.New()
        AlwaysLit = 1
        LampLight = New Light()
        LampLight.Translation = New Vector3(0, 0, 0)
        LampLight.AmbientColor = New Vector3(0.4, 1, 0.4)
        LampLight.DiffuseColor = New Vector3(0.4, 1, 0.4)
        LampLight.SpecularColor = New Vector3(0.4, 1, 0.4)
        LampLight.AmbientStrength = New Vector3(0.1, 0.1, 0.1)
        LampLight.DiffuseStrength = New Vector3(1, 1, 1)
        LampLight.SpecularStrength = New Vector3(1, 1, 1)
        LampLight.Range = 20
        LampLight.Angle = 180
        LampLight.Strength = MathF.Max(AlwaysLit - 0.4F, 0)
        AtlasCoordinate = New Vector2(1,0)
        LightManager.Add(LampLight)
    End Sub
    
    Public Overrides Sub Tick(Args As FrameEventArgs)
        LampLight.Translation = Translation
        LampLight.Rotation = Rotation
        LampLight.Scale = Scale
    End Sub
End Class