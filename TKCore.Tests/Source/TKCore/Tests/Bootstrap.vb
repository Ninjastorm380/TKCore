Imports System
Imports OpenTK.Mathematics
Imports OpenTK.Windowing.Common
Imports OpenTK.Windowing.Desktop

Namespace TKCore.Tests
    Module Bootstrap
        Sub Main(Args As String())
            Dim NativeSettings As New NativeWindowSettings : With NativeSettings
                .Vsync = VSyncMode.On
                .ClientSize = New Vector2i(1024, 768)
            End With
            
            Dim GameSettings As New GameWindowSettings : With GameSettings
                .Win32SuspendTimerOnDrag = True
                .UpdateFrequency = 0
            End With
            
            Dim Window As New TestWindow(NativeSettings, GameSettings) : With Window
                .Run()
                .Dispose()
            End With
        End Sub
    End Module
End NameSpace