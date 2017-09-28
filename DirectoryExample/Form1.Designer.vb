<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOut
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOut))
        Me.btnStart = New System.Windows.Forms.Button()
        Me.fldrPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.tvFiles = New System.Windows.Forms.TreeView()
        Me.ilTV = New System.Windows.Forms.ImageList(Me.components)
        Me.lblFileCount = New System.Windows.Forms.Label()
        Me.ckShowDeletes = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(13, 13)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'tvFiles
        '
        Me.tvFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvFiles.ImageIndex = 0
        Me.tvFiles.ImageList = Me.ilTV
        Me.tvFiles.Location = New System.Drawing.Point(13, 42)
        Me.tvFiles.Name = "tvFiles"
        Me.tvFiles.SelectedImageIndex = 0
        Me.tvFiles.Size = New System.Drawing.Size(259, 207)
        Me.tvFiles.TabIndex = 3
        '
        'ilTV
        '
        Me.ilTV.ImageStream = CType(resources.GetObject("ilTV.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilTV.TransparentColor = System.Drawing.Color.Transparent
        Me.ilTV.Images.SetKeyName(0, "file.ico")
        Me.ilTV.Images.SetKeyName(1, "file_change.ico")
        Me.ilTV.Images.SetKeyName(2, "file_delete.ico")
        Me.ilTV.Images.SetKeyName(3, "file_new.ico")
        '
        'lblFileCount
        '
        Me.lblFileCount.AutoSize = True
        Me.lblFileCount.Location = New System.Drawing.Point(94, 18)
        Me.lblFileCount.Name = "lblFileCount"
        Me.lblFileCount.Size = New System.Drawing.Size(0, 13)
        Me.lblFileCount.TabIndex = 4
        '
        'ckShowDeletes
        '
        Me.ckShowDeletes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckShowDeletes.AutoSize = True
        Me.ckShowDeletes.Location = New System.Drawing.Point(180, 18)
        Me.ckShowDeletes.Name = "ckShowDeletes"
        Me.ckShowDeletes.Size = New System.Drawing.Size(92, 17)
        Me.ckShowDeletes.TabIndex = 5
        Me.ckShowDeletes.Text = "Show Deletes"
        Me.ckShowDeletes.UseVisualStyleBackColor = True
        '
        'frmOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.ckShowDeletes)
        Me.Controls.Add(Me.lblFileCount)
        Me.Controls.Add(Me.tvFiles)
        Me.Controls.Add(Me.btnStart)
        Me.Name = "frmOut"
        Me.Text = "Directory Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnStart As Button
    Friend WithEvents fldrPath As FolderBrowserDialog
    Friend WithEvents tvFiles As TreeView
    Friend WithEvents lblFileCount As Label
    Friend WithEvents ilTV As ImageList
    Friend WithEvents ckShowDeletes As CheckBox
End Class
