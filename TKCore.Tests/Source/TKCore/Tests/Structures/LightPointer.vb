Imports TKCore

Public Structure LightPointer
    Public ReadOnly PositionName         As String
    Public ReadOnly DirectionName        As String
    Public ReadOnly AmbientName          As String
    Public ReadOnly DiffuseName          As String
    Public ReadOnly SpecularName         As String
    Public ReadOnly AmbientStrengthName  As String
    Public ReadOnly DiffuseStrengthName  As String
    Public ReadOnly SpecularStrengthName As String
    Public ReadOnly RangeName            As String
    Public ReadOnly AngleName            As String
    Public ReadOnly StrengthName         As String
    
    Public Sub New(PositionName As String, DirectionName As String, AmbientName As String, DiffuseName As String, SpecularName As String, AmbientStrengthName As String, DiffuseStrengthName As String, SpecularStrengthName As String, RangeName As String, AngleName As String, StrengthName As String)
        Me.PositionName         = PositionName
        Me.DirectionName        = DirectionName
        Me.AmbientName          = AmbientName
        Me.DiffuseName          = DiffuseName
        Me.SpecularName         = SpecularName
        Me.AmbientStrengthName  = AmbientStrengthName
        Me.DiffuseStrengthName  = DiffuseStrengthName
        Me.SpecularStrengthName = SpecularStrengthName
        Me.RangeName            = RangeName
        Me.AngleName            = AngleName
        Me.StrengthName         = StrengthName
    End Sub
End Structure