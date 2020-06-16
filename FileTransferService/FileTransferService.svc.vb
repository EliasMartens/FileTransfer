Public Class FileTransferService
    Implements IFileTransferService

    Public Sub New()
    End Sub

    Public Sub UploadFile(pFullName As String, pBytes() As Byte) Implements IFileTransferService.UploadFile
        Using _context As New FileTransferContext
            _context.Configuration.AutoDetectChangesEnabled = False
            Using _transaction = _context.Database.BeginTransaction
                Dim _file As New FileHeader With {.FullName = pFullName, .Content = pBytes}
                _context.FileHeaders.Add(_file)
                _context.SaveChanges()
                _transaction.Commit()
            End Using
        End Using
    End Sub

    Public Sub InitializeFileUpload(pFullName As String, pFirstHundredBytes As Byte()) Implements IFileTransferService.UploadFile
        Using _context As New FileTransferContext
            _context.Configuration.AutoDetectChangesEnabled = False
            Using _transaction = _context.Database.BeginTransaction

                Dim _filePart As New FilePart With {.Content = pFirstHundredBytes}
                _context.FileParts.Add(_filePart)
                _context.SaveChanges()

                Dim _file As New FileHeader With {.FullName = pFullName, .FirstPartID = _filePart.ID}
                _context.FileHeaders.Add(_file)
                _context.SaveChanges()

                _filePart.HeaderID = _file.ID
                _context.Entry(_filePart).State = Entity.EntityState.Modified
                _context.SaveChanges()

                _transaction.Commit()
            End Using
        End Using
    End Sub

    Public Sub ContinueFileUpload(pLastFilePartID As Integer, pNextHundredBytes As Byte()) Implements IFileTransferService.UploadFile
        Using _context As New FileTransferContext
            _context.Configuration.AutoDetectChangesEnabled = False
            Using _transaction = _context.Database.BeginTransaction

                Dim _filePart As New FilePart With {.Content = pNextHundredBytes}
                _context.FileParts.Add(_filePart)
                _context.SaveChanges()

                Dim _lastFilePart = _context.FileParts.Find(pLastFilePartID)
                _lastFilePart.NextID = _filePart.ID
                _context.Entry(_lastFilePart).State = Entity.EntityState.Modified
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
                Dim _serviceFile = _context.FileHeaders.ToList.LastOrDefault
                _file = New ResponseFile With {.FullName = _serviceFile.FullName, .Bytes = _serviceFile.Content}
            End Using
        End Using
        Return _file
    End Function
End Class
