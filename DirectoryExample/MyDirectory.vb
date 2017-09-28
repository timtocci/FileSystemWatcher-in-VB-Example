Imports System.IO
Imports System.Security
Imports System.Security.Permissions

''' <summary>
''' Singleton that initializes and handles file watcher changes
''' </summary>
<CLSCompliant(True)> Public Class MyDirectory
    Public Shared Event Change(path As String)
    Public Shared Event Create(path As String)
    Public Shared Event Delete(path As String)
    Public Shared Event Renamed(oldpath As String, newpath As String)
    Private Shared watched As String
    Private Shared retList As List(Of String)
    Public Shared ReadOnly Property Count As Integer
        Get
            Return retList.Count
        End Get
    End Property
    Private Sub New()
    End Sub
    Public Shared Function ListDirectory(path As String) As List(Of String)
        retList = New List(Of String)
        watched = path
        Try
            Dim di As DirectoryInfo = New DirectoryInfo(path)
            For Each file In di.EnumerateFiles("*", SearchOption.AllDirectories)
                retList.Add(file.FullName)
            Next
            For Each folder In di.EnumerateDirectories("*", SearchOption.AllDirectories)
                retList.Add(folder.FullName)
            Next
        Catch ex As DirectoryNotFoundException
            Console.WriteLine("Directory not found: {0}", ex.Message)
        Catch ex As SecurityException
            Console.WriteLine("Security Exception:\n\n{0}", ex.Message)
        Catch ex As Exception
            Console.WriteLine("Exception occurred: {0}", ex.Message)
        End Try
        Return retList
    End Function
    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")>
    Public Shared Sub WatchDirectory(path As String)
        Dim fswatcher As New FileSystemWatcher
        fswatcher.IncludeSubdirectories = True
        fswatcher.Path = path
        fswatcher.Filter = ""
        AddHandler fswatcher.Changed, AddressOf onChanged
        AddHandler fswatcher.Created, AddressOf onCreated
        AddHandler fswatcher.Deleted, AddressOf onDeleted
        AddHandler fswatcher.Renamed, AddressOf onRenamed
        fswatcher.EnableRaisingEvents = True
    End Sub
    Private Shared Sub onChanged(src As Object, evt As FileSystemEventArgs)
        RaiseEvent Change(evt.FullPath)
    End Sub
    Private Shared Sub onDeleted(src As Object, evt As FileSystemEventArgs)
        Dim tList As List(Of String) = New List(Of String)
        Dim thepath As String = evt.FullPath
        For Each path As String In retList
            If path.StartsWith(thepath) Then
                tList.Add(path)
            End If
        Next
        For Each path As String In tList
            retList.Remove(path)
            RaiseEvent Delete(path)
        Next
    End Sub
    Private Shared Sub onCreated(src As Object, evt As FileSystemEventArgs)
        retList.Add(evt.FullPath)
        RaiseEvent Create(evt.FullPath)
    End Sub
    Private Shared Sub onRenamed(src As Object, evt As RenamedEventArgs)
        Dim thepath As String = evt.OldFullPath
        Dim fname As String = ""
        Dim dicRename As Dictionary(Of String, String) = New Dictionary(Of String, String)
        For Each path As String In retList
            If path.StartsWith(thepath) Then
                If Equals(path, thepath) Then
                    dicRename.Add(path, evt.FullPath)
                Else
                    fname = path.Substring(path.LastIndexOf("\") + 1)
                    dicRename.Add(path, evt.FullPath & "\" & fname)
                End If
            End If
        Next
        For Each KVPair As KeyValuePair(Of String, String) In dicRename
            retList.Remove(KVPair.Key)
            retList.Add(KVPair.Value)
            'Console.WriteLine("Renamed from: {0} \n To: {1}", KVPair.Key, KVPair.Value)
            RaiseEvent Renamed(KVPair.Key, KVPair.Value)
        Next
    End Sub
End Class
