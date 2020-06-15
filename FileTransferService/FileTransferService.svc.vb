' NOTE: You can use the "Rename" command on the context menu to change the class name "Service1" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.vb at the Solution Explorer and start debugging.
Public Class FileTransferService
    Implements IFileTransferService

    Public Sub New()
    End Sub

    Public Sub UploadFile(bytes() As Byte) Implements IFileTransferService.UploadFile
        Using _context As New FileTransferContext
            _context.Configuration.AutoDetectChangesEnabled = False
            Using _transaction = _context.Database.BeginTransaction
                Dim _file As New TransferFile With {.File = bytes}
                _context.TransferFiles.Add(_file)
                _context.SaveChanges()
                _transaction.Commit()
            End Using
        End Using
    End Sub
End Class
