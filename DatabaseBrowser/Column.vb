Public Class Column
    Public Property Name As String
    Public Property Type As String

    Public Sub New(ByVal columnName As String, ByVal columnType As String)
        _Name = columnName
        _Type = columnType
    End Sub

    Public Overrides Function ToString() As String
        Return Name & " (" & Type & ")"
    End Function
End Class
