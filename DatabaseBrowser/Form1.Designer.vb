<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.listSearchResult = New System.Windows.Forms.ListBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.listLinkFrom = New System.Windows.Forms.ListBox()
        Me.listLinkTo = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.listStoredProcedures = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'listSearchResult
        '
        Me.listSearchResult.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.listSearchResult.FormattingEnabled = True
        Me.listSearchResult.IntegralHeight = False
        Me.listSearchResult.Location = New System.Drawing.Point(266, 38)
        Me.listSearchResult.Name = "listSearchResult"
        Me.listSearchResult.Size = New System.Drawing.Size(248, 577)
        Me.listSearchResult.TabIndex = 1
        '
        'txtSearch
        '
        Me.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtSearch.Location = New System.Drawing.Point(266, 12)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(248, 20)
        Me.txtSearch.TabIndex = 0
        Me.txtSearch.WordWrap = False
        '
        'listLinkFrom
        '
        Me.listLinkFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.listLinkFrom.FormattingEnabled = True
        Me.listLinkFrom.IntegralHeight = False
        Me.listLinkFrom.Location = New System.Drawing.Point(12, 38)
        Me.listLinkFrom.Name = "listLinkFrom"
        Me.listLinkFrom.Size = New System.Drawing.Size(248, 577)
        Me.listLinkFrom.TabIndex = 3
        '
        'listLinkTo
        '
        Me.listLinkTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.listLinkTo.FormattingEnabled = True
        Me.listLinkTo.IntegralHeight = False
        Me.listLinkTo.Location = New System.Drawing.Point(520, 38)
        Me.listLinkTo.Name = "listLinkTo"
        Me.listLinkTo.Size = New System.Drawing.Size(248, 577)
        Me.listLinkTo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Referenced By These Tables"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(516, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Referenced to these Tables"
        '
        'listStoredProcedures
        '
        Me.listStoredProcedures.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.listStoredProcedures.FormattingEnabled = True
        Me.listStoredProcedures.IntegralHeight = False
        Me.listStoredProcedures.Location = New System.Drawing.Point(774, 38)
        Me.listStoredProcedures.Name = "listStoredProcedures"
        Me.listStoredProcedures.Size = New System.Drawing.Size(248, 577)
        Me.listStoredProcedures.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(771, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(204, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Stored Procedures Referencing the Table"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 627)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.listStoredProcedures)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.listLinkTo)
        Me.Controls.Add(Me.listLinkFrom)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.listSearchResult)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database Browser"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents listSearchResult As ListBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents listLinkFrom As ListBox
    Friend WithEvents listLinkTo As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents listStoredProcedures As ListBox
    Friend WithEvents Label3 As Label
End Class
