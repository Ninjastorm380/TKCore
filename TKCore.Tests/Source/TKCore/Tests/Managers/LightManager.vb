Imports OpenTK.Windowing.Common
Imports TKCore

Public Class LightManager
    Public Const MaximumSupportedLights As Int32 = 50
    

    Private ReadOnly Lights As List(Of Light) = Nothing
    
    Public Sub New()
        Lights = New List(Of Light)(MaximumSupportedLights)
    End Sub
    
    Public Sub Add(Light As Light)
        If Lights.Contains(Light) = False Then Lights.Add(Light)
    End Sub
    
    Public Sub Remove(Light As Light)
        If Lights.Contains(Light) = True Then Lights.Remove(Light)
    End Sub
    
    Public Function Light(Index As Int32) As Light
        Return Lights(Index)
    End Function
    
    Public Function Count() As Int32
        Return Math.Min(MaximumSupportedLights, Lights.Count)
    End Function
    
    Public Function Contains(Light As Light) As Boolean
        Return Lights.Contains(Light)
    End Function
    
    Public Sub Tick()
        For Each Entry In Lights
            Entry.ApplyOrientation()
        Next
    End Sub
End Class