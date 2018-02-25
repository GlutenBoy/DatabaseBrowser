Imports System.Data.SqlClient

Module Database
    Public Function ExecuteQuery(ByVal queryString As String, Optional ByVal parameters As Dictionary(Of String, String) = Nothing) As SqlDataReader
        Dim connection As New SqlConnection(My.Settings.ConnectionString)

        Using command As New SqlCommand(queryString, connection)
            command.CommandType = CommandType.Text

            If parameters IsNot Nothing Then
                For Each key As String In parameters.Keys
                    command.Parameters.AddWithValue(key, parameters(key))
                Next
            End If

            connection.Open()

            ' When using CommandBehavior.CloseConnection, the connection will be closed when the   
            ' IDataReader Is Closed.
            Dim dataReader As SqlDataReader = command.ExecuteReader(CommandBehavior.CloseConnection)

            Return dataReader
        End Using
    End Function
End Module
