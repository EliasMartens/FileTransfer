Imports System.Data.Entity

Public Class FileTransferContext
    Inherits DbContext

    Public Sub New()
        'MyBase.New("DefaultConnection")
        MyBase.New()
    End Sub

    Property TransferFiles As DbSet(Of TransferFile)
End Class
