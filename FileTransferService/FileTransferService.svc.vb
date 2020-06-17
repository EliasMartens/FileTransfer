Public Class FileTransferService
    Implements IFileTransferService

    Public Sub New()
    End Sub

    Public Function InitializeFileUpload(pFullName As String, pFirstHundredBytes As Byte()) As Integer Implements IFileTransferService.InitializeFileUpload
        Dim _headerID As Integer
        Using _context As New FileTransferContext
            _context.Configuration.AutoDetectChangesEnabled = False
            Using _transaction = _context.Database.BeginTransaction

                Dim _filePart As New FilePart With {.Content = pFirstHundredBytes}
                _context.FileParts.Add(_filePart)
                _context.SaveChanges()

                Dim _file As New FileHeader With {.FullName = pFullName, .FirstPartID = _filePart.ID, .LastPartID = _filePart.ID, .PartCount = 1}
                _context.FileHeaders.Add(_file)
                _context.SaveChanges()

                _headerID = _file.ID

                _transaction.Commit()
            End Using
        End Using
        Return _headerID
    End Function

    Public Sub ContinueFileUpload(pHeaderID As Integer, pNextHundredBytes As Byte()) Implements IFileTransferService.ContinueFileUpload
        Using _context As New FileTransferContext
            _context.Configuration.AutoDetectChangesEnabled = False
            Using _transaction = _context.Database.BeginTransaction

                Dim _file As FileHeader = _context.FileHeaders.Find(pHeaderID)
                Dim _lastFilePart = _context.FileParts.Find(_file.LastPartID)

                Dim _filePart As New FilePart With {.Content = pNextHundredBytes}
                _context.FileParts.Add(_filePart)
                _context.SaveChanges()

                _lastFilePart.NextID = _filePart.ID
                _context.Entry(_lastFilePart).State = Entity.EntityState.Modified
                _context.SaveChanges()

                _file.LastPartID = _filePart.ID
                _file.PartCount += 1
                _context.Entry(_file).State = Entity.EntityState.Modified
                _context.SaveChanges()

                _transaction.Commit()
            End Using
        End Using
    End Sub

    Public Sub FinalizeFileUpload(pHeaderID As Integer, pHundredBytes() As Byte) Implements IFileTransferService.FinalizeFileUpload
        Using _context As New FileTransferContext
            _context.Configuration.AutoDetectChangesEnabled = False
            Using _transaction = _context.Database.BeginTransaction

                Dim _file As FileHeader = _context.FileHeaders.Find(pHeaderID)
                Dim _lastFilePart = _context.FileParts.Find(_file.LastPartID)

                Dim _filePart As New FilePart With {.Content = pHundredBytes}
                _context.FileParts.Add(_filePart)
                _context.SaveChanges()

                _lastFilePart.NextID = _filePart.ID
                _context.Entry(_lastFilePart).State = Entity.EntityState.Modified
                _context.SaveChanges()

                _file.LastPartID = _filePart.ID
                _file.PartCount += 1
                _file.Complete = True
                _context.Entry(_file).State = Entity.EntityState.Modified
                _context.SaveChanges()

                _transaction.Commit()
            End Using
        End Using
    End Sub

    Public Function InitializeDownload(pHeaderID As Integer) As BeginDownloadResponse Implements IFileTransferService.InitializeDownload
        Dim _fileHeader = New FileTransferContext().FileHeaders.Find(pHeaderID)
        Dim _firstPart = New FileTransferContext().FileParts.Find(_fileHeader.FirstPartID)
        If Not _firstPart.NextID.HasValue Then
            Return New BeginDownloadResponse With {.Bytes = _firstPart.Content, .Complete = True, .FullName = _fileHeader.FullName, .PartCount = _fileHeader.PartCount}
        Else
            Return New BeginDownloadResponse With {.Bytes = _firstPart.Content, .Complete = False, .FullName = _fileHeader.FullName, .NextPartID = _firstPart.NextID.Value, .PartCount = _fileHeader.PartCount}
        End If
    End Function

    Public Function ContinueDownload(pPartID As Integer) As ContinueDownloadResponse Implements IFileTransferService.ContinueDownload
        Dim _part = New FileTransferContext().FileParts.Find(pPartID)
        If Not _part.NextID.HasValue Then
            Return New ContinueDownloadResponse With {.Bytes = _part.Content, .Complete = True}
        Else
            Return New ContinueDownloadResponse With {.Bytes = _part.Content, .Complete = False, .NextPartID = _part.NextID.Value}
        End If
    End Function
End Class
