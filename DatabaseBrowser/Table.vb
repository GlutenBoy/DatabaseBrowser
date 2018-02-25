Imports System.Data.SqlClient

Public Class Table
    Private _columns As List(Of Column)

    Public Property Name As String
    Public Property SchemaName As String

    Public ReadOnly Property Columns() As List(Of Column)
        Get
            If _columns Is Nothing Then
                _columns = GetColumns()
            End If
            Return _columns
        End Get
    End Property

    Public Sub New(ByVal tableName As String, ByVal schemaName As String)
        _Name = tableName
        _SchemaName = schemaName
    End Sub

    Public Overrides Function ToString() As String
        Return SchemaName & "." & Name
    End Function

    Private Function GetColumns() As List(Of Column)
        Dim columns As List(Of Column)
        Dim dataReader As SqlDataReader
        Dim parameters As New Dictionary(Of String, String)

        parameters.Add("@SchemaName", SchemaName)
        parameters.Add("@TableName", Name)
        dataReader = ExecuteQuery("SELECT COLUMN_NAME, DATA_TYPE  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = @SchemaName AND TABLE_NAME = @TableName ORDER BY ORDINAL_POSITION", parameters)

        columns = New List(Of Column)
        Do While dataReader.Read()
            columns.Add(New Column(dataReader(0), dataReader(1)))
        Loop

        Return columns
    End Function
End Class

