﻿Imports System.Data.Entity

Public Class FileTransferContext
    Inherits DbContext

    Public Sub New()
        'MyBase.New("DefaultConnection")
        MyBase.New()
    End Sub

    Property FileHeaders As DbSet(Of FileHeader)
    Property FileParts As DbSet(Of FilePart)
End Class
