Imports System.IO
Public Class frmOut
    Private fpath As String = ""
    ' https://msdn.microsoft.com/en-us/library/zyzhdc6b(v=vs.110).aspx
    Delegate Sub updateChangeDelegate(path As String)
    Delegate Sub updateDeleteDelegate(path As String)
    Delegate Sub updateCreateDelegate(path As String)
    Delegate Sub updateRenameDelegate(oldpath As String, newpath As String)

    Public Sub New()
        InitializeComponent()
        ckShowDeletes.Checked = CheckState.Checked
    End Sub
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        btnStart.Enabled = False
        Dim dirResults As List(Of String)
        Dim fldrResult As DialogResult = fldrPath.ShowDialog()
        If fldrResult = DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            tvFiles.BeginUpdate()
            fpath = fldrPath.SelectedPath
            Me.Text = fpath
            dirResults = MyDirectory.ListDirectory(fpath)
            lblFileCount.Text = dirResults.Count & " Files"
            For Each path As String In dirResults
                tvFiles.Nodes.Add(path, path, 0)
            Next
            tvFiles.EndUpdate()
            Cursor.Current = Cursors.Default
            btnStart.Enabled = True
        Else
            btnStart.Enabled = True
            Exit Sub
        End If
        ' now watch the same directory for changes
        AddHandler MyDirectory.Change, AddressOf dirChange
        AddHandler MyDirectory.Create, AddressOf dirCreate
        AddHandler MyDirectory.Delete, AddressOf dirDelete
        AddHandler MyDirectory.Renamed, AddressOf dirRename
        MyDirectory.WatchDirectory(fpath)
    End Sub
    ' something was deleted
    Private Sub dirDelete(path As String)
        If tvFiles.InvokeRequired Then
            Dim del = New updateDeleteDelegate(AddressOf updateDelete)
            tvFiles.Invoke(del, path)
        Else
            updateDelete(path)
        End If
    End Sub

    ' something was renamed
    Private Sub dirRename(oldpath As String, newpath As String)
        If tvFiles.InvokeRequired Then
            Dim del = New updateRenameDelegate(AddressOf updateRename)
            tvFiles.Invoke(del, oldpath, newpath)
        Else
            updateRename(oldpath, newpath)
        End If
    End Sub

    ' something was created
    Private Sub dirCreate(path As String)
        If tvFiles.InvokeRequired Then
            Dim del = New updateCreateDelegate(AddressOf updateCreate)
            tvFiles.Invoke(del, path)
        Else
            updateCreate(path)
        End If
    End Sub

    ' something was changed
    Private Sub dirChange(path As String)
        If tvFiles.InvokeRequired Then
            Dim del = New updateChangeDelegate(AddressOf updateChange)
            tvFiles.Invoke(del, path)
        Else
            updateChange(path)
        End If
    End Sub

    Private Sub updateChange(path As String)
        tvFiles.BeginUpdate()
        tvFiles.Nodes.RemoveByKey(path)
        tvFiles.Nodes.Add(path, path, 1)
        tvFiles.EndUpdate()
    End Sub

    Private Sub updateCreate(path As String)
        tvFiles.BeginUpdate()
        tvFiles.Nodes.Add(path, path, 3)
        lblFileCount.Text = MyDirectory.Count & " Files"
        tvFiles.EndUpdate()
    End Sub

    Private Sub updateDelete(path As String)
        If ckShowDeletes.Checked Then
            tvFiles.BeginUpdate()
            tvFiles.Nodes.RemoveByKey(path)
            tvFiles.Nodes.Add(path, path, 2)
            lblFileCount.Text = MyDirectory.Count & " Files"
            tvFiles.EndUpdate()
        Else
            tvFiles.BeginUpdate()
            tvFiles.Nodes.RemoveByKey(path)
            lblFileCount.Text = MyDirectory.Count & " Files"
            tvFiles.EndUpdate()
        End If

    End Sub

    Private Sub updateRename(oldpath As String, newpath As String)
        tvFiles.BeginUpdate()
        tvFiles.Nodes.RemoveByKey(oldpath)
        tvFiles.Nodes.Add(newpath, newpath, 3)
        tvFiles.EndUpdate()
    End Sub
End Class
' File Icon Indexes
'0 file.ico
'1 file_change.ico
'2 file_delete.ico
'3 file_new.ico
