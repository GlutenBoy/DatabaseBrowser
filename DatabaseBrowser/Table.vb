Public Class Table
    Public Property Name As String
    Public Property SchemaName As String

    Public Sub New(ByVal tableName As String, ByVal schemaName As String)
        _Name = tableName
        _SchemaName = schemaName
    End Sub

    Public Overrides Function ToString() As String
        Return SchemaName & "." & Name
    End Function
End Class
