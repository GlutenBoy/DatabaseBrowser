Imports System.Data
Imports System.Data.SqlClient

Public Class Form1
    Private _connectionString As String = "Data Source=OFFICE-PC\SQLEXPRESS;Initial Catalog=AdventureWorks2017; Integrated Security=true"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSearchAutoComplete()
    End Sub

#Region " UI Events "
    Private Sub txtSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyUp
        If e.KeyCode = Keys.Enter Then
            SearchTable(Me.txtSearch.Text)
        End If
    End Sub

    Private Sub listSearchResult_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listSearchResult.SelectedIndexChanged
        LoadLink(CType(Me.listSearchResult.SelectedItem, Table))
    End Sub

    Private Sub listLinkTo_DoubleClick(sender As Object, e As EventArgs) Handles listLinkTo.DoubleClick
        Dim table As Table

        table = Me.listLinkTo.SelectedItem

        Me.txtSearch.Text = ""
        Me.listSearchResult.Items.Clear()
        Me.listSearchResult.Items.Add(table)
        LoadLink(table)
    End Sub

    Private Sub listLinkTo_KeyUp(sender As Object, e As KeyEventArgs) Handles listLinkTo.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim table As Table

            table = Me.listLinkTo.SelectedItem

            Me.txtSearch.Text = ""
            Me.listSearchResult.Items.Clear()
            Me.listSearchResult.Items.Add(Table)
            LoadLink(Table)
        End If
    End Sub

    Private Sub listLinkFrom_DoubleClick(sender As Object, e As EventArgs) Handles listLinkFrom.DoubleClick
        Dim table As Table

        table = Me.listLinkFrom.SelectedItem

        Me.txtSearch.Text = ""
        Me.listSearchResult.Items.Clear()
        Me.listSearchResult.Items.Add(table)
        LoadLink(table)
    End Sub

    Private Sub listLinkFrom_KeyUp(sender As Object, e As KeyEventArgs) Handles listLinkFrom.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim table As Table

            table = Me.listLinkFrom.SelectedItem

            Me.txtSearch.Text = ""
            Me.listSearchResult.Items.Clear()
            Me.listSearchResult.Items.Add(table)
            LoadLink(table)
        End If
    End Sub
#End Region

    Private Sub SearchTable(ByVal searchString As String)
        Dim dataReader As SqlDataReader
        Dim parameters As New Dictionary(Of String, String)

        Me.listSearchResult.Items.Clear()

        parameters.Add("@SearchString", "%" & searchString & "%")
        dataReader = ExecuteQuery("SELECT TABLE_NAME, TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME LIKE @SearchString ORDER BY TABLE_NAME", parameters)

        Do While dataReader.Read()
            Dim newTable As New Table(dataReader(0), dataReader(1))

            Me.listSearchResult.Items.Add(newTable)
        Loop
    End Sub

    Private Sub LoadLink(ByVal table As Table)
        Dim dataReaderLinkTo As SqlDataReader
        Dim dataReaderLinkFrom As SqlDataReader
        Dim dataReaderStoredProcedures As SqlDataReader
        Dim parameters As New Dictionary(Of String, String)


        Me.listLinkTo.Items.Clear()
        Me.listLinkFrom.Items.Clear()
        Me.listStoredProcedures.Items.Clear()

        parameters.Add("@TableName", table.Name)

        dataReaderLinkFrom = ExecuteQuery("SELECT ku.TABLE_NAME, ku.TABLE_SCHEMA FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS c INNER JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE cu ON cu.CONSTRAINT_NAME = c.CONSTRAINT_NAME INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE ku ON ku.CONSTRAINT_NAME = c.UNIQUE_CONSTRAINT_NAME WHERE cu.TABLE_NAME = @TableName", parameters)
        dataReaderLinkTo = ExecuteQuery("SELECT FK.TABLE_NAME, FK.TABLE_SCHEMA FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS As RC Join INFORMATION_SCHEMA.TABLE_CONSTRAINTS As PK On PK.CONSTRAINT_NAME = RC.UNIQUE_CONSTRAINT_NAME Join INFORMATION_SCHEMA.TABLE_CONSTRAINTS As FK On FK.CONSTRAINT_NAME = RC.CONSTRAINT_NAME WHERE PK.TABLE_NAME = @TableName", parameters)

        'TODO: Option Search with schema name
        parameters = New Dictionary(Of String, String)
        parameters.Add("@TableName", "%" & table.Name & "%")
        dataReaderStoredProcedures = ExecuteQuery("SELECT Name FROM sys.procedures WHERE OBJECT_DEFINITION(OBJECT_ID) LIKE @TableName", parameters)

        Do While dataReaderLinkTo.Read()
            Me.listLinkTo.Items.Add(New Table(dataReaderLinkTo(0), dataReaderLinkTo(1)))
        Loop

        Do While dataReaderLinkFrom.Read()
            Me.listLinkFrom.Items.Add(New Table(dataReaderLinkFrom(0), dataReaderLinkFrom(1)))
        Loop

        Do While dataReaderStoredProcedures.Read()
            Me.listStoredProcedures.Items.Add(dataReaderStoredProcedures(0))
        Loop
    End Sub

    Private Sub LoadSearchAutoComplete()
        Dim dataReader As SqlDataReader
        Dim tableNamesSource As New AutoCompleteStringCollection()

        dataReader = ExecuteQuery("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' ORDER BY TABLE_NAME")

        Do While dataReader.Read()
            tableNamesSource.Add(dataReader(0))
        Loop

        Me.txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.txtSearch.AutoCompleteCustomSource = tableNamesSource
    End Sub

    Private Function ExecuteQuery(ByVal queryString As String, Optional ByVal parameters As Dictionary(Of String, String) = Nothing) As SqlDataReader
        Dim connection As New SqlConnection(_connectionString)

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
End Class
