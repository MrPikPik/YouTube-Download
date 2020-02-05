Public Class FormatViewer
    Dim formatText As String = Nothing
    Dim video As String = Nothing

    Sub New(ByVal formats As String, ByVal title As String)
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        formatText = formats
        video = title
    End Sub

    Private Sub FormatViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Available formats for """ & video & """"
        FormatLabel.Text = formatText
        Me.Size = New Size(New Point(FormatLabel.Size.Width + 35, FormatLabel.Size.Height + 95))
        Me.MinimumSize = Me.Size
        Me.MaximumSize = Me.Size

        Button1.Location = New Point((Me.Size.Width / 2) - 48, 6)
        Button1.Size = New Size(80, 23)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainForm.Status("")
        Me.Close()
    End Sub
End Class