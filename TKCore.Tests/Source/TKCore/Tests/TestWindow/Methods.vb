Imports OpenTK.Windowing.Common
Imports OpenTK.Windowing.Desktop

Namespace TKCore.Tests
    Public Partial Class TestWindow : Inherits GameWindow
        Public Sub New(NativeSettings As NativeWindowSettings, GameSettings As GameWindowSettings)
            MyBase.New(GameSettings, NativeSettings)
        End Sub

        Protected Overrides Sub OnLoad()
            MyBase.OnLoad()
        End Sub

        Protected Overrides Sub OnUpdateFrame(args As FrameEventArgs)
            MyBase.OnUpdateFrame(args)
        End Sub

        Protected Overrides Sub OnRenderFrame(args As FrameEventArgs)
            MyBase.OnRenderFrame(args)
        End Sub

        Protected Overrides Sub OnUnload()
            MyBase.OnUnload()
        End Sub
    End Class
End Namespace
