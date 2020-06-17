Imports System.IO
Imports System.ServiceModel

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub btUpload_Click(sender As Object, e As EventArgs) Handles btDescargar.Click
        Dim _fileTransferService As New FileTransferServiceClient(New BasicHttpBinding() With {.MaxReceivedMessageSize = 2147483647}, New EndpointAddress("http://localhost:65254/FileTransferService.svc"))
        Dim _bytes = New List(Of Byte)
        Dim _nextPartID As Integer = 0
        Dim _fullName As String

        pbProgressBar.Properties.Step = 1
        pbProgressBar.Position = 0
        lbProgress.Text = $"{pbProgressBar.Position * 100:n0}KB de {pbProgressBar.Properties.Maximum * 100:n0}KB"
        Application.DoEvents()

        Do
            If _nextPartID = 0 Then
                Dim _response = _fileTransferService.InitializeDownload(10)
                pbProgressBar.Properties.Maximum = _response.PartCount

                pbProgressBar.PerformStep()
                lbProgress.Text = $"{pbProgressBar.Position * 100:n0}KB de {pbProgressBar.Properties.Maximum * 100:n0}KB"
                Application.DoEvents()

                _fullName = _response.FullName
                _bytes.AddRange(_response.Bytes)
                If _response.Complete Then
                    Exit Do
                Else
                    _nextPartID = _response.NextPartID
                End If
            Else
                Dim _response = _fileTransferService.ContinueDownload(_nextPartID)

                pbProgressBar.PerformStep()
                lbProgress.Text = $"{pbProgressBar.Position * 100:n0}KB de {pbProgressBar.Properties.Maximum * 100:n0}KB"
                Application.DoEvents()

                _bytes.AddRange(_response.Bytes)
                If _response.Complete Then
                    Exit Do
                Else
                    _nextPartID = _response.NextPartID
                End If
            End If
        Loop
        File.WriteAllBytes("C:\Users\DELL\Desktop\" & _fullName, _bytes.ToArray)
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

                pbProgressBar.Position = 0
                Application.DoEvents()
                Dim _bytes = File.ReadAllBytes(files.First)
                pbProgressBar.Properties.Maximum = Math.Round(_bytes.Length / 102400, 0)
                pbProgressBar.Properties.Step = 1
                lbProgress.Text = $"{pbProgressBar.Position * 100:n0}KB de {pbProgressBar.Properties.Maximum * 100:n0}KB"
                Application.DoEvents()

                Dim _currentBytes As New List(Of Byte)
                Dim _headerID As Integer
                For i = 0 To _bytes.Length - 1
                    _currentBytes.Add(_bytes(i))
                    If _currentBytes.Count = 102400 AndAlso i <> _bytes.Length - 1 Then
                        If _headerID = 0 Then
                            _headerID = _fileTransferService.InitializeFileUpload(files.First.Split("\").Last, _currentBytes.ToArray)
                        Else
                            _fileTransferService.ContinueFileUpload(_headerID, _currentBytes.ToArray)
                        End If
                        _currentBytes.Clear()
                        pbProgressBar.PerformStep()
                        lbProgress.Text = $"{pbProgressBar.Position * 100:n0}KB de {pbProgressBar.Properties.Maximum * 100:n0}KB"
                        Application.DoEvents()
                    End If
                Next
                _fileTransferService.FinalizeFileUpload(_headerID, _currentBytes.ToArray)
                pbProgressBar.PerformStep()
                lbProgress.Text = $"{pbProgressBar.Position * 100:n0}KB de {pbProgressBar.Properties.Maximum * 100:n0}KB"
                Application.DoEvents()
            Catch ex As Exception
                pbProgressBar.Position = 0
                Debug.Write("")
            End Try
        End If
    End Sub
End Class
