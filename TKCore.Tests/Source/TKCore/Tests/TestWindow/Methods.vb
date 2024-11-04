Imports OpenTK.Graphics.OpenGL
Imports OpenTK.Mathematics
Imports OpenTK.Windowing.Common
Imports OpenTK.Windowing.Desktop
Imports OpenTK.Windowing.GraphicsLibraryFramework
Imports TKCore.Extra

Namespace TKCore.Tests
    Public Partial Class TestWindow : Inherits GameWindow
        Public Sub New(NativeSettings As NativeWindowSettings, GameSettings As GameWindowSettings)
            MyBase.New(GameSettings, NativeSettings)
        End Sub

        Protected Overrides Sub OnLoad()
            LightManager = New LightManager()
            VoxelManager = New VoxelManager()
            
            GL.Enable(EnableCap.DepthTest)
            GL.Enable(EnableCap.CullFace)
            GL.Enable(EnableCap.Blend)
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha)
            
            Aspect = CSng(ClientSize.X / CDbl(ClientSize.Y))
            Camera = New Camera(1, 100, MathHelper.DegreesToRadians(45), Aspect)
        
            CaptureToggle = False
            SpeedModifier = 1
        
            VoxelManager.SetAtlasMaximum(New Vector2(1,1))
            VoxelManager.SetDarknessColor(New Vector3(0.01, 0.01, 0.01))
        
            CreateLamps(VoxelManager, LightManager, New Vector3i(-33), New Vector3i(33), 20)
            CreateOrbiters(VoxelManager, Camera, New Vector3i(-70), New Vector3i(70), 50000)
            GL.ClearColor(0,0,0,0)
            MyBase.OnLoad()
        End Sub

        Protected Overrides Sub OnUpdateFrame(Args As FrameEventArgs)
            HandleInput(Args)
            VoxelManager.Tick(Args)
            LightManager.Tick()
            VoxelManager.ApplyLights(LightManager)
            VoxelManager.ApplyCamera(Camera)
            
            MyBase.OnUpdateFrame(args)
        End Sub

        Protected Overrides Sub OnRenderFrame(Args As FrameEventArgs)
            VoxelManager.Draw()
            SwapBuffers()
            MyBase.OnRenderFrame(args)
        End Sub

        Protected Overrides Sub OnUnload()
            SpeedModifier = 1
            CaptureToggle = False
            
            VoxelManager.Dispose()
            MyBase.OnUnload()
        End Sub

        Protected Overrides Sub OnResize(e As ResizeEventArgs)
            Camera.AspectRatio = Aspect
            Camera.ApplyProjection()
            MyBase.OnResize(e)
        End Sub

        Private Sub HandleInput(Args As FrameEventArgs)
            Dim Keyboard As KeyboardState = KeyboardState
            Dim Mouse As MouseState = MouseState
            Dim MouseDelta As Vector2 = New Vector2(Mouse.Delta.Y/7, -(Mouse.Delta.X/7))
        
            ' Mouse Capture Toggle.
            If Keyboard.IsKeyReleased(Keys.Backspace) = True Then
                If CaptureToggle = False Then
                    CaptureToggle = True
                    CursorState = CursorState.Grabbed
                Else
                    CaptureToggle = False
                    CursorState = CursorState.Normal
                End If
            End If
        
            ' Camera Modifier Controls.
            If Keyboard.IsKeyDown(Keys.LeftShift) = True Then SpeedModifier = 3 Else SpeedModifier = 1
        
            ' Camera Position Controls.
            If Keyboard.IsKeyDown(Keys.W)           Then Camera.Translation += (Camera.Forward  * CSng(Args.Time) * 2) * SpeedModifier
            If Keyboard.IsKeyDown(Keys.A)           Then Camera.Translation += (Camera.Left     * CSng(Args.Time) * 2) * SpeedModifier
            If Keyboard.IsKeyDown(Keys.S)           Then Camera.Translation += (Camera.Backward * CSng(Args.Time) * 2) * SpeedModifier
            If Keyboard.IsKeyDown(Keys.D)           Then Camera.Translation += (Camera.Right    * CSng(Args.Time) * 2) * SpeedModifier
            If Keyboard.IsKeyDown(Keys.LeftControl) Then Camera.Translation += (Camera.Down     * CSng(Args.Time) * 2) * SpeedModifier
            If Keyboard.IsKeyDown(Keys.Space)       Then Camera.Translation += (Camera.Up       * CSng(Args.Time) * 2) * SpeedModifier
        
            ' Camera Rotation Controls.
            Dim YawPitchRoll As Vector3 = RadiansToDegrees(Camera.Rotation)
            Dim Yaw As Single   = YawPitchRoll.X
            Dim Pitch As Single = YawPitchRoll.Y
            Dim Roll As Single  = YawPitchRoll.Z
        
            If CaptureToggle = True Then
                Yaw   += (MouseDelta.X) * SpeedModifier * (64 * CSng(Args.Time))
                Pitch += (MouseDelta.Y) * SpeedModifier * (64 * CSng(Args.Time))
            End If
        
            If Keyboard.IsKeyDown(Keys.Q) Then Roll -= (64 * CSng(Args.Time)) * SpeedModifier
            If Keyboard.IsKeyDown(Keys.E) Then Roll += (64 * CSng(Args.Time)) * SpeedModifier
        
            YawPitchRoll = New Vector3(Yaw, Pitch, Roll)
            Camera.Rotation = DegreesToRadians(YawPitchRoll)
            Camera.ApplyOrientation()
        End Sub
        
        Private Shared Sub CreateOrbiters(VoxelManager As VoxelManager, Camera As Camera, Minimum As Vector3i, Maximum As Vector3i, Count As Int32)
            Dim Random As New Random
            For Index = 0 To Count - 1
                Dim Orbiter As New Orbiter(Camera, Random.Next(0, 64))
                Orbiter.AtlasCoordinate = New Vector2(Random.Next(0, 2), Random.Next(0, 2))
                Orbiter.Translation = New Vector3(Random.Next(Minimum.X * 100I, Maximum.X * 100I) / 100F, Random.Next(Minimum.Y * 100I, Maximum.Y * 100I) / 100F, Random.Next(Minimum.Z * 100I, Maximum.Z * 100I) / 100F)
                VoxelManager.Add(Orbiter)
            Next
        End Sub
    
        Private Shared Sub CreateLamps(VoxelManager As VoxelManager, LightManager As LightManager, Minimum As Vector3i, Maximum As Vector3i, Count As Int32)
            Dim Random As New Random
            For Index = 0 To Count - 1
                Dim Lamp As New Lamp(LightManager)
                Lamp.Translation = New Vector3(Random.Next(Minimum.X * 100I, Maximum.X * 100I) / 100F, Random.Next(Minimum.Y * 100I, Maximum.Y * 100I) / 100F, Random.Next(Minimum.Z * 100I, Maximum.Z * 100I) / 100F)
                VoxelManager.Add(Lamp)
            Next
        End Sub
        
        Private Shared Function DegreesToRadians(ByVal Input As Vector3) As Vector3
            Return New Vector3(MathHelper.DegreesToRadians(Input.X), MathHelper.DegreesToRadians(Input.Y), MathHelper.DegreesToRadians(Input.Z))
        End Function

        Private Shared Function RadiansToDegrees(ByVal Input As Vector3) As Vector3
            Return New Vector3(MathHelper.RadiansToDegrees(Input.X), MathHelper.RadiansToDegrees(Input.Y), MathHelper.RadiansToDegrees(Input.Z))
        End Function
    End Class
End Namespace
