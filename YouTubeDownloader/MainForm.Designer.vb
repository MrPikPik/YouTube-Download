<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.youtubeLinkBox = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusStripProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.StatusStripLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateYoutubedlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownLoadButton = New System.Windows.Forms.Button()
        Me.youtubeLinkCollectionBox = New System.Windows.Forms.ListBox()
        Me.linkBoxContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyVideoTitleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyURLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowAvailableFormatsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadWithCustomOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.FormatSelector = New System.Windows.Forms.ComboBox()
        Me.AddLinkButton = New System.Windows.Forms.Button()
        Me.LogBox = New System.Windows.Forms.TextBox()
        Me.LogContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopySelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.CheckForUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.linkBoxContextMenu.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.LogContextMenu.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'youtubeLinkBox
        '
        Me.youtubeLinkBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.youtubeLinkBox.Location = New System.Drawing.Point(3, 8)
        Me.youtubeLinkBox.Name = "youtubeLinkBox"
        Me.youtubeLinkBox.Size = New System.Drawing.Size(649, 20)
        Me.youtubeLinkBox.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusStripProgressBar, Me.StatusStripLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 462)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(941, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusStripProgressBar
        '
        Me.StatusStripProgressBar.Name = "StatusStripProgressBar"
        Me.StatusStripProgressBar.Size = New System.Drawing.Size(100, 16)
        Me.StatusStripProgressBar.Visible = False
        '
        'StatusStripLabel
        '
        Me.StatusStripLabel.Name = "StatusStripLabel"
        Me.StatusStripLabel.Size = New System.Drawing.Size(0, 17)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.QueueToolStripMenuItem, Me.InfoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(941, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckForUpdatesToolStripMenuItem, Me.UpdateYoutubedlToolStripMenuItem, Me.QuitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'UpdateYoutubedlToolStripMenuItem
        '
        Me.UpdateYoutubedlToolStripMenuItem.Name = "UpdateYoutubedlToolStripMenuItem"
        Me.UpdateYoutubedlToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.UpdateYoutubedlToolStripMenuItem.Text = "&Update youtube-dl"
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.QuitToolStripMenuItem.Text = "&Quit"
        '
        'QueueToolStripMenuItem
        '
        Me.QueueToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearToolStripMenuItem, Me.DownloadToolStripMenuItem})
        Me.QueueToolStripMenuItem.Name = "QueueToolStripMenuItem"
        Me.QueueToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.QueueToolStripMenuItem.Text = "&Queue"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.ClearToolStripMenuItem.Text = "&Clear"
        '
        'DownloadToolStripMenuItem
        '
        Me.DownloadToolStripMenuItem.Name = "DownloadToolStripMenuItem"
        Me.DownloadToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.DownloadToolStripMenuItem.Text = "&Download"
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.InfoToolStripMenuItem.Text = "&Info"
        '
        'DownLoadButton
        '
        Me.DownLoadButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DownLoadButton.Location = New System.Drawing.Point(821, 6)
        Me.DownLoadButton.Name = "DownLoadButton"
        Me.DownLoadButton.Size = New System.Drawing.Size(117, 21)
        Me.DownLoadButton.TabIndex = 3
        Me.DownLoadButton.Text = "Download"
        Me.DownLoadButton.UseVisualStyleBackColor = True
        '
        'youtubeLinkCollectionBox
        '
        Me.youtubeLinkCollectionBox.ContextMenuStrip = Me.linkBoxContextMenu
        Me.youtubeLinkCollectionBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.youtubeLinkCollectionBox.FormattingEnabled = True
        Me.youtubeLinkCollectionBox.Location = New System.Drawing.Point(0, 0)
        Me.youtubeLinkCollectionBox.Name = "youtubeLinkCollectionBox"
        Me.youtubeLinkCollectionBox.Size = New System.Drawing.Size(941, 202)
        Me.youtubeLinkCollectionBox.TabIndex = 4
        '
        'linkBoxContextMenu
        '
        Me.linkBoxContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem, Me.CopyVideoTitleToolStripMenuItem, Me.CopyURLToolStripMenuItem, Me.ShowAvailableFormatsToolStripMenuItem, Me.DownloadWithCustomOptionsToolStripMenuItem})
        Me.linkBoxContextMenu.Name = "linkBoxContextMenu"
        Me.linkBoxContextMenu.Size = New System.Drawing.Size(250, 114)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'CopyVideoTitleToolStripMenuItem
        '
        Me.CopyVideoTitleToolStripMenuItem.Name = "CopyVideoTitleToolStripMenuItem"
        Me.CopyVideoTitleToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.CopyVideoTitleToolStripMenuItem.Text = "Copy video title"
        '
        'CopyURLToolStripMenuItem
        '
        Me.CopyURLToolStripMenuItem.Name = "CopyURLToolStripMenuItem"
        Me.CopyURLToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.CopyURLToolStripMenuItem.Text = "Copy URL"
        '
        'ShowAvailableFormatsToolStripMenuItem
        '
        Me.ShowAvailableFormatsToolStripMenuItem.Name = "ShowAvailableFormatsToolStripMenuItem"
        Me.ShowAvailableFormatsToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.ShowAvailableFormatsToolStripMenuItem.Text = "Show available formats"
        '
        'DownloadWithCustomOptionsToolStripMenuItem
        '
        Me.DownloadWithCustomOptionsToolStripMenuItem.Name = "DownloadWithCustomOptionsToolStripMenuItem"
        Me.DownloadWithCustomOptionsToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.DownloadWithCustomOptionsToolStripMenuItem.Text = "Download with custom options..."
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.FormatSelector)
        Me.Panel2.Controls.Add(Me.DownLoadButton)
        Me.Panel2.Controls.Add(Me.AddLinkButton)
        Me.Panel2.Controls.Add(Me.youtubeLinkBox)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 424)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(941, 38)
        Me.Panel2.TabIndex = 6
        '
        'FormatSelector
        '
        Me.FormatSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FormatSelector.FormattingEnabled = True
        Me.FormatSelector.Items.AddRange(New Object() {"MP3", "MP4", "M4A", "WAV", "WEBM"})
        Me.FormatSelector.Location = New System.Drawing.Point(739, 6)
        Me.FormatSelector.Name = "FormatSelector"
        Me.FormatSelector.Size = New System.Drawing.Size(76, 21)
        Me.FormatSelector.TabIndex = 4
        '
        'AddLinkButton
        '
        Me.AddLinkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AddLinkButton.Location = New System.Drawing.Point(658, 6)
        Me.AddLinkButton.Name = "AddLinkButton"
        Me.AddLinkButton.Size = New System.Drawing.Size(75, 21)
        Me.AddLinkButton.TabIndex = 1
        Me.AddLinkButton.Text = "Add"
        Me.AddLinkButton.UseVisualStyleBackColor = True
        '
        'LogBox
        '
        Me.LogBox.BackColor = System.Drawing.Color.Black
        Me.LogBox.ContextMenuStrip = Me.LogContextMenu
        Me.LogBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LogBox.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogBox.ForeColor = System.Drawing.Color.White
        Me.LogBox.Location = New System.Drawing.Point(0, 0)
        Me.LogBox.Multiline = True
        Me.LogBox.Name = "LogBox"
        Me.LogBox.ReadOnly = True
        Me.LogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.LogBox.Size = New System.Drawing.Size(941, 194)
        Me.LogBox.TabIndex = 0
        '
        'LogContextMenu
        '
        Me.LogContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopySelectedToolStripMenuItem, Me.ClearToolStripMenuItem1})
        Me.LogContextMenu.Name = "LogContextMenu"
        Me.LogContextMenu.Size = New System.Drawing.Size(149, 48)
        '
        'CopySelectedToolStripMenuItem
        '
        Me.CopySelectedToolStripMenuItem.Name = "CopySelectedToolStripMenuItem"
        Me.CopySelectedToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.CopySelectedToolStripMenuItem.Text = "Copy selected"
        '
        'ClearToolStripMenuItem1
        '
        Me.ClearToolStripMenuItem1.Name = "ClearToolStripMenuItem1"
        Me.ClearToolStripMenuItem1.Size = New System.Drawing.Size(148, 22)
        Me.ClearToolStripMenuItem1.Text = "Clear"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.youtubeLinkCollectionBox)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.LogBox)
        Me.SplitContainer1.Size = New System.Drawing.Size(941, 400)
        Me.SplitContainer1.SplitterDistance = 202
        Me.SplitContainer1.TabIndex = 9
        '
        'CheckForUpdatesToolStripMenuItem
        '
        Me.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem"
        Me.CheckForUpdatesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CheckForUpdatesToolStripMenuItem.Text = "&Check For Updates"
        '
        'MainForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 484)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(450, 158)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "YouTube Downloader"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.linkBoxContextMenu.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.LogContextMenu.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents youtubeLinkBox As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents StatusStripProgressBar As ToolStripProgressBar
    Friend WithEvents StatusStripLabel As ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DownLoadButton As Button
    Friend WithEvents youtubeLinkCollectionBox As ListBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents AddLinkButton As Button
    Friend WithEvents linkBoxContextMenu As ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QueueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents QuitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DownloadToolStripMenuItem As ToolStripMenuItem
    Public WithEvents LogBox As TextBox
    Friend WithEvents CopyVideoTitleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyURLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InfoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FormatSelector As ComboBox
    Friend WithEvents ShowAvailableFormatsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DownloadWithCustomOptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogContextMenu As ContextMenuStrip
    Friend WithEvents CopySelectedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents UpdateYoutubedlToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckForUpdatesToolStripMenuItem As ToolStripMenuItem
End Class
