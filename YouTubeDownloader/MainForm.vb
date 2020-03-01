#Const CHECK_FOR_DEPENENCIES = True
#Const USE_SERIAL_NUMBERS = False

Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Windows.Shell


Public Class MainForm
    Dim counter As Integer = 0

    'Dictionary of URL -> Video Title
    Dim videos As Dictionary(Of String, String) = New Dictionary(Of String, String)

    'Queue used for downloading (Using URLs)
    Dim queue As List(Of String) = New List(Of String)

    'Events
    Event VideoFetched(ByVal url As String, ByVal title As String)
    Event ShowMessageBox(ByVal message As String, ByVal title As String)
    Event DownloadStarted(ByVal url As String, ByVal title As String)
    Event DownloadFinished(ByVal url As String, ByVal title As String)
    Event ProgressUpdate(ByVal progress As Double)
    Event QueueFinished()
    Event ProcessExited()
    Event UpdateFinished()

    'Delegates
    Delegate Sub InvokeLog(ByVal msg As String)
    Delegate Sub InvokeFetchFinished(ByVal url As String, ByVal title As String)
    Delegate Sub InvokeMessageBox(ByVal message As String, ByVal title As String)
    Delegate Sub InvokeDownloadStarted(ByVal url As String, ByVal title As String)
    Delegate Sub InvokeDownloadFinished(ByVal url As String, ByVal title As String)
    Delegate Sub InvokeParseProgress(ByVal str As String)
    Delegate Sub InvokeProcessExited()
    Delegate Sub InvokeUpdateFinished()


    'Delegate implementations
    Public Sub Log()
        'Preserve old selection
        Dim selectionBegin As Integer = LogBox.SelectionStart
        Dim selectionLength As Integer = LogBox.SelectionLength

        LogBox.AppendText(vbNewLine)
        LogBox.SelectionStart = LogBox.TextLength
        LogBox.ScrollToCaret()

        'Restore old selection
        LogBox.SelectionStart = selectionBegin
        LogBox.SelectionLength = selectionLength
    End Sub
    Public Sub Log(msg As String)
        'Preserve old selection
        Dim selectionBegin As Integer = LogBox.SelectionStart
        Dim selectionLength As Integer = LogBox.SelectionLength

        LogBox.AppendText(vbNewLine & msg)
        LogBox.SelectionStart = LogBox.TextLength
        LogBox.ScrollToCaret()

        'Restore old selection
        LogBox.SelectionStart = selectionBegin
        LogBox.SelectionLength = selectionLength
    End Sub

    Public Sub Status(status As String)
        StatusStripLabel.Text = status
    End Sub

    Private Sub FetchFinishedEventInvoke(ByVal url As String, ByVal title As String)
        RaiseEvent VideoFetched(url, title)
    End Sub

    Private Sub MessageBoxDisplayEventInvoke(ByVal message As String, Optional ByVal title As String = "YouTube Download")
        RaiseEvent ShowMessageBox(message, title)
    End Sub

    Private Sub FinishedDownloadEventInvoke(ByVal url As String, ByVal title As String)
        RaiseEvent DownloadFinished(url, title)
    End Sub

    Private Sub StartDownloadEventInvoke(ByVal url As String, ByVal title As String)
        RaiseEvent DownloadStarted(url, title)
    End Sub

    Private Sub ProcessExitedInvoke()
        RaiseEvent ProcessExited()
    End Sub

    Private Sub ParseProgress(ByVal str As String)
        Dim prog As String = Split(str, " of")(0) 'Get the first part of the message
        prog = prog.Replace("[download]", "") 'Remove the [download] prefix
        prog = prog.TrimEnd("%") 'Remove percent sign
        prog = prog.TrimStart(" ") 'Remove spaces

        If prog = prog.Replace(".", "") Then
            prog = prog & "0"
        Else
            prog = prog.Replace(".", "") 'Remove decimal point
        End If

        'Parsing the number ourselves since for WHATEVER REASON it always fails using any Type.Parse methods
        Dim chars = prog.ToCharArray()
        Dim result As Double = 0.0D
        For i As Integer = 0 To chars.Length - 1
            Select Case chars(i)
                Case "0"
                    result += (0 * Math.Pow(10, chars.Length - i - 1))
                Case "1"
                    result += (1 * Math.Pow(10, chars.Length - i - 1))
                Case "2"
                    result += (2 * Math.Pow(10, chars.Length - i - 1))
                Case "3"
                    result += (3 * Math.Pow(10, chars.Length - i - 1))
                Case "4"
                    result += (4 * Math.Pow(10, chars.Length - i - 1))
                Case "5"
                    result += (5 * Math.Pow(10, chars.Length - i - 1))
                Case "6"
                    result += (6 * Math.Pow(10, chars.Length - i - 1))
                Case "7"
                    result += (7 * Math.Pow(10, chars.Length - i - 1))
                Case "8"
                    result += (8 * Math.Pow(10, chars.Length - i - 1))
                Case "9"
                    result += (9 * Math.Pow(10, chars.Length - i - 1))
            End Select
        Next

        'Clamp result
        If result < 0 Then
            result = 0
        ElseIf result > 1000 Then
            result = 1000
        End If



        RaiseEvent ProgressUpdate(result)
    End Sub


    '==========================================================================================
    '===================================== Event handlers =====================================
    '==========================================================================================

    Sub UpdateProgress(ByVal progress As Double) Handles Me.ProgressUpdate
        Dim v As Integer = Math.Floor(progress) + (1000 * counter)
        If v < StatusStripProgressBar.Minimum Then
            v = StatusStripProgressBar.Minimum
        ElseIf v > StatusStripProgressBar.Maximum Then
            v = StatusStripProgressBar.Maximum
        End If
        StatusStripProgressBar.Value = v

        Dim taskbarProgress As Double = v / (1000 * (counter + 1))
    End Sub

    Sub DownloadStartedHandler(ByVal url As String, ByVal title As String) Handles Me.DownloadStarted
        Status("Downloading video """ & title & """... - " & counter & "/" & youtubeLinkCollectionBox.Items.Count)
    End Sub

    Sub FinishedDownloadHandler(ByVal url As String, ByVal title As String) Handles Me.DownloadFinished
        queue.Remove(url)
        counter += 1
        Log("Finished downloading video """ & title & """!")
        Log()

        Status("Finished downloading video """ & title & """ - " & counter & "/" & youtubeLinkCollectionBox.Items.Count)

        DownloadNext()
    End Sub

    Sub FetchHandler(ByVal url As String, ByVal title As String) Handles Me.VideoFetched
        'If there is no title, fetching went wrong
        If title = Nothing Then
            Status("Could not fetch video title.")
            Log("Could not fetch video title.")
            StatusStripProgressBar.Value = 0
            Return
        End If

        'Add url to Listbox and Dictionary
        If Not videos.ContainsKey(url) Then
            videos.Add(url, title)
            youtubeLinkCollectionBox.Items.Add(title)
            Status("Video URL added to list.")
        Else
            Status("Video URL already in list.")
        End If
    End Sub

    Sub QueueFinishedHandler() Handles Me.QueueFinished
        counter = 0
        StatusStripProgressBar.Value = 0
        StatusStripProgressBar.Visible = False

        DownLoadButton.Enabled = True
        FormatSelector.Enabled = True
        AddLinkButton.Enabled = True
        youtubeLinkBox.Enabled = True
        QueueToolStripMenuItem.Enabled = True

        Status("Downloading finished.")

        Log("================================")
        Log("Finished downloading all videos.")
        Log("================================")
    End Sub

    Sub MessageBox(ByVal message As String, Optional ByVal title As String = "YouTube Download") Handles Me.ShowMessageBox
        MsgBox(message, MsgBoxStyle.OkOnly, title)
    End Sub

    Sub EndUpdate() Handles Me.UpdateFinished
        Me.Enabled = True
        Log("Update finished!")
        Status("Update finished!")
    End Sub


    '==========================================================================================
    '==========================================================================================
    '==========================================================================================
    Private Sub YoutubeLinkCollectionBox_KeyDown(sender As Object, e As KeyEventArgs) Handles youtubeLinkCollectionBox.KeyDown
        If e.KeyCode = Keys.Delete Then
            If youtubeLinkCollectionBox.SelectedItem <> Nothing Then
                DeleteVideoFromList(youtubeLinkCollectionBox.SelectedItem)
            End If
        End If
    End Sub


    Private Sub DownloadNext()
        'If queue is empty, announce it
        If queue.Count = 0 Then
            RaiseEvent QueueFinished()
            Return
        End If

        'Else download a video
        Dim url = queue.First()

        DownloadVideo(url, videos.Item(url))
    End Sub

    Private Sub DownloadVideo(ByVal url As String, ByVal title As String)
        'If file already has been downloaded, skip
        If IO.File.Exists(Application.StartupPath & "\Downloads\" & title & "." & FormatSelector.SelectedItem.ToString().ToLower()) Then
            RaiseEvent DownloadFinished(url, title)
            Log("Video """ & title & """ already downloaded with specified format. Skipping.")
            Return
        End If

        Using Proc = New Process()
            Proc.StartInfo.FileName = Application.StartupPath & "\bin\youtube-dl.exe"

            Dim Format As String = FormatSelector.SelectedItem

            Select Case Format
                Case "MP3"
                    Proc.StartInfo.Arguments = "-x --audio-format mp3 --audio-quality 0 -o ""../Downloads/%(title)s.%(ext)s"" " & url
                Case "M4A"
                    Proc.StartInfo.Arguments = "-x --audio-format m4a --audio-quality 0 -o ""../Downloads/%(title)s.%(ext)s"" " & url
                Case "WAV"
                    Proc.StartInfo.Arguments = "-x --audio-format wav --audio-quality 0 -o ""../Downloads/%(title)s.%(ext)s"" " & url
                Case "MP4"
                    Proc.StartInfo.Arguments = "-f mp4 -o ""../Downloads/%(title)s.%(ext)s"" " & url
                Case "WEBM"
                    Proc.StartInfo.Arguments = "-f webm -o ""../Downloads/%(title)s.%(ext)s"" " & url
            End Select

            Proc.StartInfo.UseShellExecute = False
            Proc.StartInfo.CreateNoWindow = True
            Proc.StartInfo.WorkingDirectory = Application.StartupPath & "\tmp"

            Proc.StartInfo.RedirectStandardOutput = True

            Proc.EnableRaisingEvents = True
            AddHandler Proc.Exited, Sub()
                                        BeginInvoke(New InvokeProcessExited(AddressOf ProcessExitedInvoke))
                                    End Sub

            AddHandler Proc.OutputDataReceived, Sub(sendr As Object, ev As DataReceivedEventArgs)
                                                    If ev.Data <> Nothing Then
                                                        BeginInvoke(New InvokeLog(AddressOf Log), ev.Data)

                                                        If ev.Data.EndsWith("(pass -k to keep)") And (Format = "MP3" Or Format = "M4A" Or Format = "WAV") Then
                                                            BeginInvoke(New InvokeDownloadFinished(AddressOf FinishedDownloadEventInvoke), {url, title})
                                                        ElseIf ev.Data.StartsWith("[download] 100% ") And (Format = "MP4" Or Format = "WEBM") Then
                                                            BeginInvoke(New InvokeDownloadFinished(AddressOf FinishedDownloadEventInvoke), {url, title})
                                                        ElseIf ev.Data.StartsWith("[download]") Then
                                                            BeginInvoke(New InvokeParseProgress(AddressOf ParseProgress), ev.Data)
                                                        End If
                                                    End If
                                                End Sub

            Log("Downloading video """ & title & """...")

            Proc.Start()
            Proc.BeginOutputReadLine()

            BeginInvoke(New InvokeDownloadStarted(AddressOf StartDownloadEventInvoke), {url, title})
        End Using
    End Sub

    Private Sub DownloadProcessExitedHandler()
        Status("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@")
        Log("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@")
    End Sub

    Private Sub DownLoadButton_Click(sender As Object, e As EventArgs) Handles DownLoadButton.Click
        If youtubeLinkCollectionBox.Items.Count = 0 Then
            MsgBox("The queue is empty!", MsgBoxStyle.Information, "YouTube Downloader")
            Return
        End If

        DownLoadButton.Enabled = False
        FormatSelector.Enabled = False
        AddLinkButton.Enabled = False
        youtubeLinkBox.Enabled = False
        QueueToolStripMenuItem.Enabled = False

        StatusStripProgressBar.Visible = True
        StatusStripProgressBar.Maximum = youtubeLinkCollectionBox.Items.Count * 1000
        StatusStripProgressBar.Value = 0
        counter = 0

        For Each url As String In videos.Keys
            queue.Add(url)
        Next

        DownloadNext()
    End Sub

    Private Sub YoutubeLinkBox_KeyDown(sender As Object, e As KeyEventArgs) Handles youtubeLinkBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            AddVideoToList(youtubeLinkBox.Text)
        End If
    End Sub

    Private Sub AddLinkButton_Click(sender As Object, e As EventArgs) Handles AddLinkButton.Click
        AddVideoToList(youtubeLinkBox.Text)
    End Sub

    Private Sub AddVideoToList(url As String)
        Status("Fetching video title...")
        StatusStripProgressBar.Value = StatusStripProgressBar.Maximum
        'Clear link box
        youtubeLinkBox.Text = Nothing

        Dim title As String = Nothing
        Dim link As String = Nothing

        Dim regexpattern As String = "(http|https):\/\/www.youtube.com/watch\?v=([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?"
        'Dim regex As String = "(http|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?"
        Dim m As Match = Regex.Match(url, regexpattern)
        If Not m.Success Then
            Status("Input was not a valid URL")
            Return
        End If


        Using Proc = New Process()
            Proc.StartInfo.FileName = Application.StartupPath + "\bin\youtube-dl.exe"

            'Remove everything like playlist id, start timestamp, etc.
            link = Split(url, "&")(0)

            '-e only outputs the video title
            Proc.StartInfo.Arguments = "-e " & link

            Proc.StartInfo.UseShellExecute = False
            Proc.StartInfo.CreateNoWindow = True
            Proc.StartInfo.WorkingDirectory = Application.StartupPath & "\tmp"

            Proc.StartInfo.RedirectStandardOutput = True

            AddHandler Proc.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                    If e.Data <> Nothing Then
                                                        BeginInvoke(New InvokeFetchFinished(AddressOf FetchFinishedEventInvoke), {link, e.Data})
                                                    End If
                                                End Sub

            Proc.Start()
            Proc.BeginOutputReadLine()
        End Using
    End Sub

    Sub DeleteVideoFromList(ByVal input As String, Optional ByVal isURL As Boolean = False)
        If isURL Then
            youtubeLinkCollectionBox.Items.Remove(videos(input))
            videos.Remove(input)
        Else
            For Each pair As KeyValuePair(Of String, String) In videos
                If pair.Value = input Then
                    videos.Remove(pair.Key)
                    Exit For
                End If
            Next
            youtubeLinkCollectionBox.Items.Remove(input)
        End If
    End Sub

    Sub UpdateYouTubeDL()
        Status("Updating youtube-dl...")
        Log("Updating youtube-dl...")

        Me.Enabled = False

        Using Proc = New Process()
            Proc.StartInfo.FileName = Application.StartupPath + "\bin\youtube-dl.exe"
            Proc.StartInfo.Arguments = "-U"

            Proc.StartInfo.UseShellExecute = False
            Proc.StartInfo.CreateNoWindow = True
            Proc.StartInfo.WorkingDirectory = Application.StartupPath & "\tmp"

            Proc.StartInfo.RedirectStandardOutput = True

            AddHandler Proc.OutputDataReceived, Sub(_sender As Object, _e As DataReceivedEventArgs)
                                                    If _e.Data <> Nothing Then
                                                        BeginInvoke(New InvokeLog(AddressOf Log), _e.Data)
                                                        If _e.Data.StartsWith("Updated youtube-dl to version") Then
                                                            BeginInvoke(New InvokeUpdateFinished(AddressOf EndUpdate))
                                                        ElseIf _e.Data.StartsWith("youtube-dl is up-to-date") Then
                                                            BeginInvoke(New InvokeUpdateFinished(AddressOf EndUpdate))
                                                        End If
                                                    End If
                                                End Sub

            Proc.Start()
            Proc.BeginOutputReadLine()
        End Using
    End Sub

    Sub UpdateApplication()
        Dim client As Net.WebClient = New Net.WebClient()
        Dim xml As String
        Try
#If DEBUG Then
            Xml = client.DownloadString("https://raw.githubusercontent.com/MrPikPik/YouTube-Download/beta/CurrentVersion")
#Else
            xml = client.DownloadString("https://raw.githubusercontent.com/MrPikPik/YouTube-Download/master/CurrentVersion")
#End If
        Catch ex As Exception
            MsgBox("Updating failed.")
            Return
        End Try

        Dim lines As String() = xml.Split(vbNewLine)

        For Each line As String In lines
            MsgBox(line)
        Next
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
#If CHECK_FOR_DEPENENCIES Then
        'Check for required files
        If Not IO.File.Exists(Application.StartupPath & "\bin\youtube-dl.exe") Then
            MsgBox("Missing youtube-dl.exe" & vbNewLine & vbNewLine & "Please reinstall the software!", MsgBoxStyle.Critical, "YouTube Downloader")
            Application.Exit()
        ElseIf Not IO.File.Exists(Application.StartupPath & "\bin\ffmpeg.exe") Then
            MsgBox("Missing ffmpeg.exe" & vbNewLine & vbNewLine & "Please reinstall the software!", MsgBoxStyle.Critical, "YouTube Downloader")
            Application.Exit()
        End If
#End If
        'Check for used directories
        If Not IO.Directory.Exists(Application.StartupPath & "\tmp") Then
            IO.Directory.CreateDirectory(Application.StartupPath & "\tmp")
        End If

        FormatSelector.SelectedIndex = 0

#If USE_SERIAL_NUMBERS Then
        Dim serial As String = InputBox("Your trial version has expired." & vbNewLine & "Please enter your personal product code below:", "Trial expired")
        If serial = Nothing Then
            MsgBox("The provided product code is invalid." & vbNewLine & "The application will now close.")
            Application.Exit()
        ElseIf serial = "urmomgay" Or serial = "faggot" Or serial = "bigghey" Then
            'Huehuehue
        Else
            MsgBox("The provided product code is invalid." & vbNewLine & "The application will now close.")
            Application.Exit()
        End If
#End If


#If DEBUG Then
        'Degubbing: Add 2 Videos to List
        videos.Add("https://www.youtube.com/watch?v=0uHmX4avm8Y", "Nora en Pure - Epiphany")
        youtubeLinkCollectionBox.Items.Add("Nora en Pure - Epiphany")
        videos.Add("https://www.youtube.com/watch?v=8s0syyNXGnM", "Faodail - Wren")
        youtubeLinkCollectionBox.Items.Add("Faodail - Wren")
#End If
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If IO.Directory.Exists(Application.StartupPath & "\tmp") Then
            For Each file As String In IO.Directory.GetFiles(Application.StartupPath & "\tmp")
                IO.File.Delete(file)
            Next
            IO.Directory.Delete(Application.StartupPath & "\tmp")
        End If
    End Sub




#Region """Tool Strip"""
    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Form1_Closing(Nothing, Nothing)
        Application.Exit()
    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        MsgBox("YouTube Downloader" & vbNewLine & "© 2020" & vbNewLine & vbNewLine & "Uses youtube-dl and ffmpeg.", MsgBoxStyle.Information, "About")
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        videos.Clear()
        youtubeLinkCollectionBox.Items.Clear()
        Status("Queue cleared")
    End Sub

    Private Sub DownloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadToolStripMenuItem.Click
        DownLoadButton_Click(sender, e)
    End Sub

    Private Sub UpdateYoutubedlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateYoutubedlToolStripMenuItem.Click
        UpdateYouTubeDL()
    End Sub

    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        UpdateApplication()
    End Sub

#End Region

#Region """Context Menu Linkbox"""
    ''' <summary>
    ''' Handles enabling/disabling menu items
    ''' </summary>
    Private Sub LinkBoxContextMenu_Opening(sender As Object, e As CancelEventArgs) Handles linkBoxContextMenu.Opening
        If youtubeLinkCollectionBox.SelectedItem = Nothing Then
            DeleteToolStripMenuItem.Enabled = False
            CopyURLToolStripMenuItem.Enabled = False
            CopyVideoTitleToolStripMenuItem.Enabled = False
            ShowAvailableFormatsToolStripMenuItem.Enabled = False
            DownloadWithCustomOptionsToolStripMenuItem.Enabled = False
        Else
            DeleteToolStripMenuItem.Enabled = True
            CopyURLToolStripMenuItem.Enabled = True
            CopyVideoTitleToolStripMenuItem.Enabled = True
            ShowAvailableFormatsToolStripMenuItem.Enabled = True
            DownloadWithCustomOptionsToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub DownloadWithCustomOptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadWithCustomOptionsToolStripMenuItem.Click
        If youtubeLinkCollectionBox.SelectedItem <> Nothing Then
            For Each url As String In videos.Keys
                If videos(url) = youtubeLinkCollectionBox.SelectedItem Then
                    'Do stuff

                    Dim customOptions As String = InputBox("Please enter custom download options below." & vbNewLine & "(Output parameter -o will be used and URL will be automatically appended." & vbNewLine & "See youtube-dl documentation for options.)", "YouTube Downloader - Custom Download")
                    If customOptions = Nothing Then
                        Return
                    End If

                    Using Proc = New Process()
                        Proc.StartInfo.FileName = Application.StartupPath & "\bin\youtube-dl.exe"
                        Proc.StartInfo.Arguments = customOptions & " -o ""../Downloads/%(title)s.%(ext)s"" " & url

                        Proc.StartInfo.UseShellExecute = False
                        Proc.StartInfo.CreateNoWindow = True
                        Proc.StartInfo.WorkingDirectory = Application.StartupPath & "\tmp"

                        Proc.StartInfo.RedirectStandardOutput = True

                        AddHandler Proc.OutputDataReceived, Sub(sendr As Object, ev As DataReceivedEventArgs)
                                                                If ev.Data.EndsWith("(pass -k to keep)") Then
                                                                    BeginInvoke(New InvokeDownloadFinished(AddressOf FinishedDownloadEventInvoke), {url, videos(url)})
                                                                Else
                                                                    BeginInvoke(New InvokeLog(AddressOf Log), ev.Data)
                                                                End If
                                                            End Sub

                        Log("Downloading video """ & youtubeLinkCollectionBox.SelectedItem & """...")

                        Proc.Start()

                        Proc.BeginOutputReadLine()

                        Status("Downloading Video """ & youtubeLinkCollectionBox.SelectedItem & """ with custom options.")
                    End Using
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub ShowAvailableFormatsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowAvailableFormatsToolStripMenuItem.Click
        If youtubeLinkCollectionBox.SelectedItem <> Nothing Then
            For Each url As String In videos.Keys
                If videos(url) = youtubeLinkCollectionBox.SelectedItem Then
                    Status("Fetching available video formats...")

                    Dim formats As String = Nothing

                    Using Proc = New Process()
                        Proc.StartInfo.FileName = Application.StartupPath + "\bin\youtube-dl.exe"

                        '-F gets all formats
                        Proc.StartInfo.Arguments = "-F " & url

                        Proc.StartInfo.UseShellExecute = False
                        Proc.StartInfo.CreateNoWindow = True
                        Proc.StartInfo.WorkingDirectory = Application.StartupPath & "\tmp"

                        Proc.StartInfo.RedirectStandardOutput = True

                        AddHandler Proc.OutputDataReceived, Sub(sndr As Object, ev As DataReceivedEventArgs)
                                                                If ev.Data <> Nothing Then
                                                                    formats += ev.Data & vbNewLine
                                                                End If
                                                            End Sub

                        Proc.Start()
                        Proc.BeginOutputReadLine()
                        Proc.WaitForExit()
                    End Using

                    'If there is no title, fetching went wrong
                    If formats = Nothing Then
                        Status("Could not fetch video formats.")
                    Else
                        Dim frmtvwr As FormatViewer = New FormatViewer(formats, youtubeLinkCollectionBox.SelectedItem)
                        frmtvwr.ShowDialog()
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub CopyURLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyURLToolStripMenuItem.Click
        If youtubeLinkCollectionBox.SelectedItem <> Nothing Then
            For Each url As String In videos.Keys
                If videos(url) = youtubeLinkCollectionBox.SelectedItem Then
                    My.Computer.Clipboard.SetText(url)
                End If
            Next
        End If
    End Sub

    Private Sub CopyVideoTitleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyVideoTitleToolStripMenuItem.Click
        If youtubeLinkCollectionBox.SelectedItem <> Nothing Then
            My.Computer.Clipboard.SetText(youtubeLinkCollectionBox.SelectedItem)
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If youtubeLinkCollectionBox.SelectedItem <> Nothing Then
            DeleteVideoFromList(youtubeLinkCollectionBox.SelectedItem)
        End If
    End Sub
#End Region

#Region """Context Menu Log"""
    Private Sub LogContextMenu_Opening(sender As Object, e As CancelEventArgs) Handles LogContextMenu.Opening
        If LogBox.SelectedText = Nothing Then
            CopySelectedToolStripMenuItem.Enabled = False
        Else
            CopySelectedToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub CopySelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopySelectedToolStripMenuItem.Click
        If LogBox.SelectedText <> Nothing Then
            My.Computer.Clipboard.SetText(LogBox.SelectedText)
        End If
    End Sub

    Private Sub ClearToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem1.Click
        LogBox.Clear()
    End Sub
#End Region

#Region """Drag and Drop"""
    Dim isFile As Boolean = False

    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        If isFile Then 'Handle file drops
            For Each file As String In e.Data.GetData(DataFormats.FileDrop)
                'Check if file is a link
                If Not file.ToLower.EndsWith(".url") Then
                    Return
                End If

                Dim filecontents As String() = IO.File.ReadAllLines(file)
                Dim isInternetShortcut = False
                Dim url As String = Nothing
                For Each line As String In filecontents
                    'Check for url header
                    If line = "[InternetShortcut]" Then
                        isInternetShortcut = True
                    End If

                    'Check for url parameter
                    If line.ToLower.StartsWith("url=") Then
                        url = Split(line, "=", 2)(1)
                    End If
                Next

                If isInternetShortcut And (url <> Nothing) Then
                    AddVideoToList(url)
                End If
            Next
        Else 'Handle url drops
            AddVideoToList(e.Data.GetData(DataFormats.Text))
        End If
    End Sub

    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            isFile = False
            e.Effect = DragDropEffects.Copy
        ElseIf e.Data.GetDataPresent(DataFormats.FileDrop) Then
            isFile = True
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

#End Region

End Class