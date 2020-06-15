Public Class FileTransferService
    Implements IFileTransferService

    Public Sub New()
    End Sub

    Public Sub UploadFile(pFullName As String, pBytes() As Byte) Implements IFileTransferService.UploadFile
        Using _context As New FileTransferContext
            _context.Configuration.AutoDetectChangesEnabled = False
            Using _transaction = _context.Database.BeginTransaction
                Dim _file As New ServiceFile With {.FullName = pFullName, .Content = pBytes}
                _context.TransferFiles.Add(_file)
                _context.SaveChanges()
                _transaction.Commit()
            End Using
        End Using
    End Sub

    Public Function DownloadLastFile() As ResponseFile Implements IFileTransferService.DownloadLastFile
        Dim _file As ResponseFile
        Using _context As New FileTransferContext
            _context.Configuration.AutoDetectChangesEnabled = False
            Using _transaction = _context.Database.BeginTransaction
                Dim _serviceFile = _context.TransferFiles.ToList.LastOrDefault
                _file = New ResponseFile With {.FullName = _serviceFile.FullName, .Bytes = _serviceFile.Content}
            End Using
        End Using
        Return _file
    End Function
End Class
