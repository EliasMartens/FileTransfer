Imports System.IO
Imports System.ServiceModel

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub btUpload_Click(sender As Object, e As EventArgs) Handles btDescargar.Click
        Dim _fileTransferService As New FileTransferServiceClient(New BasicHttpBinding() With {.MaxReceivedMessageSize = 2147483647}, New EndpointAddress("http://localhost:65254/FileTransferService.svc"))
        Dim _file = _fileTransferService.DownloadLastFile()
        File.WriteAllBytes("C:\Users\DELL\Desktop\" & _file.FullName, _file.Bytes)
    End Sub

    Private Sub btUpload_DragOver(sender As Object, e As DragEventArgs) Handles Me.DragOver
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Link
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub btUpload_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        Dim files As String() = TryCast(e.Data.GetData(DataFormats.FileDrop), String())
        If files IsNot Nothing AndAlso files.Any() Then
            Dim _fileTransferService As New FileTransferServiceClient(New BasicHttpBinding, New EndpointAddress("http://localhost:65254/FileTransferService.svc"))
            Try
                _fileTransferService.UploadFile(files.First.Split("\").Last, File.ReadAllBytes(files.First))
            Catch ex As Exception
                Debug.Write("")
            End Try
        End If
    End Sub
End Class
