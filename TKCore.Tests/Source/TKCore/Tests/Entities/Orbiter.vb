Imports OpenTK.Mathematics
Imports OpenTK.Windowing.Common
Imports TKCore
Imports TKCore.Extra

Public Class Orbiter : Inherits Voxel
    Private Const MaximumZoneVelocity As Single = 200
    Private Const MaximumStrafeVelocity As Single = 50
    Private ReadOnly TrackedEntity As Movable
    Private ReadOnly TrackedDistance As Single
    Private ZoneVelocity As Vector3
    Private StrafeVelocity As Vector3

    Public Sub New(Entity As Movable, Distance As Single)
        MyBase.New()
        TrackedEntity = Entity
        TrackedDistance = 16
        ZoneVelocity = New Vector3(0)
        StrafeVelocity = New Vector3(0)
    End Sub
    
    Public Overrides Sub Tick(Args As FrameEventArgs)
        Dim Time As Single = CSng(Args.Time)
        
        Dim CurrentDistance As Single = Vector3.Distance(TrackedEntity.Translation, Translation)
        Dim NewRotationMatrix As Matrix4 = Matrix4.LookAt(TrackedEntity.Translation, Translation, Constants.Orientation.Up)
        Rotation = -NewRotationMatrix.ExtractRotation().ToEulerAngles()
        
        If ZoneVelocity.Length > 0 And CurrentDistance > TrackedDistance - 0 Then ZoneVelocity -= (ZoneVelocity.Normalized() * Time) / 8
        If StrafeVelocity.Length > 0 Then StrafeVelocity -= (Time * StrafeVelocity.Normalized()) / 8
        
        
        If CurrentDistance > TrackedDistance - 0 Then ZoneVelocity += (Forward * Time) / 4
        If CurrentDistance < TrackedDistance + 14 Then ZoneVelocity += (Backward * Time) / 4
        If ZoneVelocity.Length > MaximumZoneVelocity Then ZoneVelocity = ZoneVelocity.Normalized() * MaximumZoneVelocity

        StrafeVelocity += (Left * Time) / 7
        If StrafeVelocity.Length > MaximumStrafeVelocity Then StrafeVelocity = StrafeVelocity.Normalized() * MaximumStrafeVelocity

        
        Translation += ZoneVelocity
        Translation += StrafeVelocity
    End Sub
End Class